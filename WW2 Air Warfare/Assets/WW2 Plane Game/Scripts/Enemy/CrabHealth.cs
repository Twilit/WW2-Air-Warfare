using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabHealth : MonoBehaviour
{
    public Text crabHealthUIText;
    public Slider crabHealthUIBar;

    [SerializeField]
    private int crabMaxHealth = 1000;
    private int crabCurrentHealth = 1000;

    void Start()
    {
        crabCurrentHealth = crabMaxHealth;
    }

    void Update()
    {
        crabHealthUIText.text = "MECHA PHANTOM DECAPOD: " + crabCurrentHealth;
        crabHealthUIBar.value = crabCurrentHealth;
    }

    void Death()
    {
        GameManager.instance.ShowWinScreen();
        Destroy(gameObject);
    }

    public void DealDamage(int damage)
    {
        crabCurrentHealth -= damage;

        if (crabCurrentHealth <= 0)
        {
            Death();
        }
    }
}
