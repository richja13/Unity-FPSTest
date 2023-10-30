using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float BulletDamage = 15;
    public GameObject hitParticles;
   // public GameObject BulletHole;
    // Update is called once per frame

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Concrete")
        {
            other.gameObject.GetComponent<MaterialScript>().TakingDamageScript(BulletDamage);
        }    
        Instantiate(hitParticles,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
