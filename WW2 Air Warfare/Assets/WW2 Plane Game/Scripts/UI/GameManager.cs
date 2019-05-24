using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    //reffrences to UI elemnts to be used in other scripts
    public Slider playerHealth;
    public Text score;
    public Text playerHealthTxt;
    public Text timeTxt;
    public float delay = 5;
     public string NewLevel= "MainMenu";



    public bool won;

    //creating a reffrence to the winpanel and loespannel
    public GameObject LosePanel;
    public GameObject winPanel;

    public GameObject HealthPanel;
    public GameObject ThrottleSlider;
    public GameObject AmmoCounter;

    public static int amountkilled;

    public static GameManager instance;



    // Use this for initialization
    void Start() {

        if (instance == null)
            instance = this;
        //winPanel.SetActive(false);
        amountkilled = 0;

        winPanel.SetActive(false);
        LosePanel.SetActive(false);




    }

    // Update is called once per frame
    void Update() {

    }

    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
        HealthPanel.SetActive(false);
        ThrottleSlider.SetActive(false);
        AmmoCounter.SetActive(false);

        StartCoroutine(LoadLevelAfterDelay(delay));


    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
