using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{

    public int rockChance = 20;
    public int foodChance = 20;
    public int spawnTry;
    int currTry;
    //Happines -----------------------------
    //public float crowdHappiness;
    public float currHappiness;

    [Tooltip("less or equal Curr Happiness")]
    public float crowdRiotPoint;

    public GameObject Rock;
    public GameObject Food;

    public List<Transform> SpawnPoint = new List<Transform>();
    private List<bool> TakenPoints = new List<bool>();

    public int spawnTimer;
    private int currTimer;

    private GameObject Lion;
    private GameObject Player;
    private GameObject EndOfCrowd;

    private float dist, fullDist;
    private float currDist;

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
            TakenPoints[rand] = true;
        }

    }
    private void PointInitialize()
    {
        foreach (Transform t in SpawnPoint)
        {
            bool i = false;
            TakenPoints.Add(i);
        }
    }
    #region CrowdMethods
    private void CheckCrowd()
    {

        if (currHappiness <= 0)
        {
            Player.GetComponent<PlayerScript>().DeathTrigger(0);
        }
        else if (currHappiness >= 100)
        {
            Player.GetComponent<PlayerScript>().DeathTrigger(1);
        }
        if (currHappiness <= crowdRiotPoint)
        {
            GetComponent<ControllerScirpt>().crowdMaddnes = true;
        }
    }

    private void CalcCrowd()
    {
        fullDist = Lion.transform.position.x - EndOfCrowd.transform.position.x;
        dist = Lion.transform.position.x - Player.transform.position.x;
        currDist = dist / (fullDist / 100);
        currHappiness = 100f - currDist;

    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {

        TakenPoints.Clear();
        PointInitialize();
        Lion = GameObject.Find("LionObjPoint");
        Player = GameObject.Find("PlayerObj");
        EndOfCrowd = GameObject.Find("EndCrowdObj");
        CalcCrowd();
    }
    public void ThrowRock()
    {
        int rand = Random.Range(0, 100);
        if (rand <= rockChance + (int)(currDist / 2))
        {
            Spawn(Rock);
        }
    }
    public void ThrowFood()
    {
        int rand = Random.Range(0, 100);
        if (rand <= foodChance)
        {
            Spawn(Food);
        }
    }
    // Update is called once per frame
    void Update()
    {
        CalcCrowd();
        CheckCrowd();
        if (currTimer > 0)
        {
            currTimer--;
        }
        else
        {
            currTimer = spawnTimer;
            ResetPoints();
        }

        if (currTry <= 0)
        {
            ThrowRock();
            ThrowFood();
            currTry = spawnTry;
        }
        else
        {
            currTry--;
        }





    }



}
