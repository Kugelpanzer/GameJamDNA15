using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    GameObject controller;
    private float moveSpeed;

    public Transform snap;
    // Start is called before the first frame update
    void Start()
    {
        snap = transform.GetChild(0);
        controller = GameObject.Find("Controller");
        moveSpeed = controller.GetComponent<ControllerScirpt>().stageSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = controller.GetComponent<ControllerScirpt>().stageSpeed;
        transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);

    }
    private void OnBecameInvisible()
    {
        if (controller != null)
        {
            ControllerScirpt cs = controller.GetComponent<ControllerScirpt>();
            if (cs.first != null)
                transform.position = cs.first.position;
            cs.first = snap;
        }

    }
}
