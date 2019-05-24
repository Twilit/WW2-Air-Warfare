﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{//acessing the Health script and the slider

    //making UI text elements that hold the text elemnts as well as a element to hold the players health scrips

    public waypoint crabWaypoints;
    public Health healthscript;
    public Text healthTxt;
    public Slider healthBar;

    public Text scoreNum;
    public Text timeNum;
    public GameObject LosePanel;
    public GameObject HealthPanel;
    public GameObject ThrottleSlider;
    public GameObject AmmoCounter;
    //haveing the score varible be  be a static variable means that only one copy of it exists
    //
    public static int score;



    // Use this for initialization
    void Start()
    {
        GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        healthBar = manager.playerHealth;
        healthTxt = manager.playerHealthTxt;


        
        //seting the max health value of the health bar by useing the max health variable from the health script
        healthBar.maxValue = healthscript.getMaxHealth();
        //doing th same here but with the players current Health
        healthBar.value = healthscript.GetHealth();
        healthTxt.text = "Player: " + healthscript.GetHealth();
        
        StartCoroutine("UpdateUI");

    }
    //makeing this uodate score a public and satic fuction lets me call it from anywere to add

    public static void updateScore(int amount)
    {
        score += amount;
    }

    private void Update()
    {
        if (crabWaypoints.reachedEnd)
        {
            Lose();
        }
    }

    // Update is called once per frame
    IEnumerator UpdateUI()
    {
        healthBar.value = healthscript.GetHealth();
        healthTxt.text = "Health: " + healthscript.GetHealth();
        //timeNum.text = "Time" + (int)Time.time;
        //scoreNum.text = "Score: " + score + "";
        if(healthscript.IsDead)
        {
            Lose();
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("UpdateUI");
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        LosePanel.SetActive(true);
        HealthPanel.SetActive(false);
        ThrottleSlider.SetActive(false);
        AmmoCounter.SetActive(false);
        StartCoroutine(LoadLevelAfterDelay(3));
    }
}
