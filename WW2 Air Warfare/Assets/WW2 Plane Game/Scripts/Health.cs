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

    Animator anim;

    public Renderer rend;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        // setting the current health the same as max health at the start of the game
        CurrentHealth = maximumHealth;
        rend = GetComponentInChildren<Renderer>();
        audioSrc = GetComponent<AudioSource>();
        rend = GetComponentInChildren<Renderer>();

    }
    void Update()
    {
        //print(rend.isVisible);
        //if enemy is dead then and the rendere is not visible destory the enemy
        if (IsDead && !rend.isVisible)
        {
            Destroy(gameObject);
        }
    }

    //  public string currenthealth
    //   {
    //      get { return currentHealth; }
    //     set {
    //       if (value < 100)
    //      {
    //         CurrentHealth = 100;
    //    }
    //   }
    //}

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
            if (gameObject.tag != "player") //POSIBLE IDEA if (gameObject.tag == "Enemy1")

            {
                //seting the boolen for dead as true if the Enemey health is 0
                anim.SetBool("Dead", true);
                audioSrc.clip = deathsound;
                audioSrc.Play();
                GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
            }



        }

    }
}

