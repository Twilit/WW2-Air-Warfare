using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delaycannonshot : MonoBehaviour
{

    ParticleSystem shot;
    [SerializeField] GameObject Gun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Gunobject()
    {
     
        yield return new WaitForSeconds(10);
         Gun.SetActive(false);

 

        
       

        
    }
    

}
