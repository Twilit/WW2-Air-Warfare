using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBomb : MonoBehaviour
{
    #region Variable
    public bool primed = false;
    public AudioSource whistle;
    public GameObject explosion;

    private CapsuleCollider capCollider;
    private Rigidbody rb;
    #endregion

    #region BuiltIn Methods
    void Start()
    {
        capCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        whistle.Play();
        Invoke("PrimeBomb", 0.4f);

        rb.AddForce(Vector3.down * 60000);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        whistle.Stop();
        Explosion();
    }
    #endregion

    #region Custom Methods
    void PrimeBomb()
    {
        if (primed == false)
        {
            capCollider.enabled = true;
            primed = true;
        }
    }

    void Explosion()
    {
        if (primed)
        {
            //EXPLOSION
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
#endregion
}
