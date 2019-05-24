using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Mainmenu : MonoBehaviour
{

    private void Start()
    {
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //SceneManager.UnloadSceneAsync(0);

    } 

    public void QuitGame()
    {

        Debug.Log("QUIT!"); 
        Application.Quit(); 
    }
    
}
