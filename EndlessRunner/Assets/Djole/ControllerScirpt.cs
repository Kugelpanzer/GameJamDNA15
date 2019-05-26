using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScirpt : MonoBehaviour
{
    public int ScorePoints;
    public bool crowdMaddnes;
    public float stageSpeed;

    [Tooltip("in seconds")]
    public int scoreTick;
    private int currTick;
    int currVal;


    public Transform first;

    private void Start()
    {
        scoreTick *= 60;
    }
    private void Update()
    {
        if (currTick <= 0)
        {
            currVal =(int) GetComponent<FoodGenerator>().currHappiness;
            ScorePoints += currVal / 10;
            currTick = scoreTick;
        }
        else
        {
            currTick--;
        }
    }
}
