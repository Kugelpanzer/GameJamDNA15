using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed;
    public float backSpeed;



    //Energy-----------------------------
    public float Energy;
    public float currEnergy;

    //MOVE ---------------------------------
    public float SprintCost;
    public float MoveCost;


    //STUN---------------------------------------
    public float stunStrength;
    public int stunDuration;
    private int currStun;

    Rigidbody2D rb;

    private Vector3 backVector;
    private Vector3 stunVector;
    private Vector2 moveVector;
    private Vector3 moveHolder;
    private Vector2 vLeft, vRight, vUp, vDown;
    private GameObject controller;

    public int FoodRestoration;
    public Sprite DeathAnim;

    private void MoveScript()
    {
        vLeft = Vector2.zero;
        vRight = Vector2.zero;
        vUp = Vector2.zero;
        vDown = Vector2.zero;

        backVector= -Vector2.right * Time.deltaTime*backSpeed;
        /* if (Input.GetKey(KeyCode.A))
         {
             vRight = -Vector2.right;
         }*/
        if (Input.GetKey(KeyCode.W))
        {
            EnergySpend(MoveCost / 60);
            vUp = Vector2.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (currStun <= 0)
            {
                vLeft = Vector2.right;
                EnergySpend(SprintCost / 60);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            EnergySpend(MoveCost / 60);
            vUp = -Vector2.up;
        }

      
        moveVector = (vLeft + vUp + vDown).normalized * moveSpeed * Time.deltaTime;
        moveHolder = moveVector;

        rb.MovePosition(transform.position+ moveHolder + stunVector +backVector);

    }
    private void StunActive()
    {
        if (currStun > 0)
        {
            stunVector= -Vector2.right *stunStrength * Time.deltaTime;
            currStun--;
        }
        else
        {
            stunVector = Vector3.zero;
        }
    }

    private void EnergySpend(float val)
    {
        currEnergy -= val;
        if(currEnergy <= 0)
        {
            DeathTrigger(2);
        }
    }
   

    public void DeathTrigger(int cause)
    {
        Debug.Log("umro si");
        GetComponent<SpriteRenderer>().sprite = DeathAnim;
       // Debug.Break();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currEnergy = Energy;
        controller = GameObject.Find("controller");
    }

    // Update is called once per frame
    void Update()
    {
        MoveScript();
        StunActive();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            currEnergy += FoodRestoration;
            Destroy(collision.gameObject);

        }
        else if(collision.gameObject.tag == "Rock")
        {
            currStun = stunDuration;
            Destroy(collision.gameObject);
        }

    }



}
