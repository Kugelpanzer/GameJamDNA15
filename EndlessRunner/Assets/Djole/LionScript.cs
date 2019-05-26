using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScript : MonoBehaviour
{

    public Animator anim;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(transform.position.x, target.transform.position.y);
    }
}
