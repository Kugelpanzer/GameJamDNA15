using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScirpt : MonoBehaviour
{
    public int ScorePoints;
    public bool crowdMaddnes;
    public float stageSpeed;
    public GameObject player;
    [Tooltip("in seconds")]
    public int scoreTick;
    private int currTick;
    int currVal;


    public Transform first;

    private void Start()
    {
        scoreTick *= 60;
        currTick = scoreTick;
    }
    private void Update()
    {
        if (!player.GetComponent<PlayerScript>().dead)
        {
            
            if (currTick <= 0)
            {
                currVal = (int)GetComponent<FoodGenerator>().currHappiness;
                ScorePoints += currVal / 10;
                currTick = scoreTick;
            }
            else
            {
                currTick--;
            }
        }
        else
        {
            stageSpeed = 0;
        }

    }
}
