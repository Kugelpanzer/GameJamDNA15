using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneraotr : MonoBehaviour
{
    //Happines -----------------------------
    public float crowdHappiness;
    float currHappiness;

    public GameObject Rock;
    public GameObject Food;

    public List<Transform> SpawnPoint = new List<Transform>();
    public List<bool> TakenPoints = new List<bool>();
    
    public int spawnTimer;
    private int currTimer;

    private void ResetPoints()
    {
        for (int i = 0; i < TakenPoints.Count; i++)
        {
            TakenPoints[i] = false;
        }
    }
    private void Spawn()
    {
        int rand = Random.Range(0, SpawnPoint.Count);
        if (TakenPoints[rand] && TakenPoints.Contains(false))
        {
            Spawn();
        }
        else 
        {
            
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
