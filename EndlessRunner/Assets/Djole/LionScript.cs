using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScript : MonoBehaviour
{

    public Sprite running, eating;
    public GameObject target;

    public void ChangeSprite(string s)
    {
        switch (s)
        {
            case "eat":
                GetComponent<SpriteRenderer>().sprite = eating;
                break;
            case "run":
                GetComponent<SpriteRenderer>().sprite = running;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(transform.position.x, target.transform.position.y);
    }
}
