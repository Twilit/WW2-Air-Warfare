using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    //reffrences to UI elemnts to be used in other scripts
    public Slider playerHealth;
    public Text score;
    public Text playerHealthTxt;
    public Text timeTxt;

    public bool won;
    
    //creating a reffrence to the winpanel and loespannel
    public GameObject losePanel;
    public GameObject winPanel;

    public static int amountkilled;




    // Use this for initialization
    void Start() {
        //winPanel.SetActive(false);
        amountkilled = 0;
        
        




    }
	
	// Update is called once per frame
	void Update () {

            //If the player has survived 180 seconds then the they win
           

        







    }   
}
