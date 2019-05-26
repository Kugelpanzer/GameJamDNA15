﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    GameObject controller;
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Controller");
        moveSpeed = controller.GetComponent<ControllerScirpt>().stageSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = controller.GetComponent<ControllerScirpt>().stageSpeed;
        transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
       // transform.position += -Vector3.right * moveSpeed * Time.deltaTime;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
 
}
