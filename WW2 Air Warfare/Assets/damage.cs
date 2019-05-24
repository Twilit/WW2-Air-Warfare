using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    void OnColliderEnter(Collider collision)
    {

        if (collision.tag == "Player")
        {
            var hit = collision.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(10);


            }

            Destroy(gameObject);
        }
    }
}


