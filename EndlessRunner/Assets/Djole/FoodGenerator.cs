using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{


    //Happines -----------------------------
    public float crowdHappiness;
    float currHappiness;
    public float crowdRiotPoint;

    public GameObject Rock;
    public GameObject Food;

    public List<Transform> SpawnPoint = new List<Transform>();
    public List<bool> TakenPoints = new List<bool>();
    
    public int spawnTimer;
    private int currTimer;

    private GameObject Lion;
    private GameObject Player;
    private GameObject EndOfCrowd;

    private float dist, fullDist;
    public float distPercent;

    private void ResetPoints()
    {
        for (int i = 0; i < TakenPoints.Count; i++)
        {
            TakenPoints[i] = false;
        }
    }
    private void Spawn(GameObject item)
    {
        int rand = Random.Range(0, SpawnPoint.Count);
        if (TakenPoints[rand] && TakenPoints.Contains(false))
        {
            Spawn(item);
        }
        else 
        {
            GameObject curr = Instantiate(item);
            curr.transform.position = SpawnPoint[rand].position;
        }

    }
    private void PointInitialize()
    {
        foreach(Transform t in SpawnPoint)
        {
            bool i=false;
            TakenPoints.Add(i);
        }
    }
    #region CrowdMethods
    private void CheckCrowd()
    {
        if (currHappiness <= 0)
        {
           // Player.GetComponent<PlayerScript>().DeathTrigger();
        }
        if (currHappiness <= crowdRiotPoint)
        {
            GetComponent<ControllerScirpt>().crowdMaddnes = true;
        }
    }

    private void CalcCrowd()
    {
        fullDist = Lion.transform.position.x - EndOfCrowd.transform.position.x;
        dist= Lion.transform.position.x - Player.transform.position.x;
        distPercent =  dist/ (fullDist/100);

    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        TakenPoints.Clear();
        PointInitialize();
        Lion = GameObject.Find("LionObj");
        Player = GameObject.Find("PlayerObj");
        EndOfCrowd = GameObject.Find("EndCrowdObj");
    }

    // Update is called once per frame
    void Update()
    {
        if (currTimer > 0)
        {
            currTimer--;
        }
        else
        {
            currTimer = spawnTimer;
            ResetPoints();
        }
        CheckCrowd();
        CalcCrowd();
    }


}
