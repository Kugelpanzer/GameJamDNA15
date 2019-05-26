using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    public GameObject Player;
    public Slider Energy;
    public Slider Happines;

    public Text Score1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score1.text= GetComponent<ControllerScirpt>().ScorePoints.ToString();
        Happines.value = GetComponent<FoodGenerator>().currHappiness;
        Energy.value = Player.GetComponent<PlayerScript>().currEnergy;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("DjScene2");
    }
}
