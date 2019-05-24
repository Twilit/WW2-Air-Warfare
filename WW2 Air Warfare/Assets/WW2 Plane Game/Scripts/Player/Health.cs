using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int maximumHealth = 100;
    //seting a maximum health variable as 100 which can be changed in the inspector

    [SerializeField] private int CurrentHealth = 0;

    AudioSource audioSrc;
    [SerializeField] AudioClip deathsound;

    public GameObject explosionPrefab;

    // Use this for initialization
    void Start()
    {

        // setting the current health the same as max health at the start of the game
        CurrentHealth = maximumHealth;
        audioSrc = GetComponent<AudioSource>();

    }
    void Update()
    {
        //print(rend.isVisible);
        //if enemy is dead then and the rendere is not visible destory the enemy
        if (IsDead)
        {
            Destroy(gameObject);
        }
    }



    public bool IsDead { get { return CurrentHealth <= 0; } }
    //using IsDead to get the result of the code current health <=0

    public int GetHealth()
    {
        return CurrentHealth;
    }

    public int getMaxHealth()
    {
        return maximumHealth;

    }

    public void Damage(int damageValue)
    {
        CurrentHealth -= damageValue;
        //if the code is equles to or less that 0 then the game object will be destoryed.

        if (CurrentHealth <= 0)
        {
            //if the objects is not nuseing the player tag then add 50 to the players score and destroy the game object
            if (gameObject.tag != "Player") //POSIBLE IDEA if (gameObject.tag == "Enemy1")

            {
                //seting the boolen for dead as true if the Enemey health is 0

                audioSrc.clip = deathsound;
                audioSrc.Play();
                GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
                
            }
            else
            {
                //playerCam.transform.parent = null;
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }


        }

    }
}
