using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserGunScript : MonoBehaviour
{
    [SerializeField] private LineRenderer beam;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float LaserDamage;
    [SerializeField] private float range;
    public ParticleSystem muzzleParticles;
    public ParticleSystem hitParticles;
    private Ray ray;
    public Animator anim;
    public GameObject BeamHole;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateBeam();
        anim = this.gameObject.GetComponent<Animator>();
    }

    private void ActivateBeam()
    {
        beam.enabled = true;
        muzzleParticles.Play();
        hitParticles.Play();
        anim.SetBool("Shooting", true);
    }

    private void DeactivateBeam()
    {
        beam.enabled = false;
        beam.SetPosition(0,muzzle.position);
        beam.SetPosition(1,muzzle.position);
        muzzleParticles.Stop();
        hitParticles.Stop();
        anim.SetBool("Shooting", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) ActivateBeam();
        else if(Input.GetMouseButtonUp(0)) DeactivateBeam();
    }

    void FixedUpdate()
    {
        if(!beam.enabled) return;

        ray = new Ray(muzzle.position, muzzle.forward);
        bool cast = Physics.Raycast(ray, out RaycastHit hit, range);
        Vector3 hitposition = cast? hit.point: muzzle.position + muzzle.forward * range;

        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Metal") 
            {
                GameObject gO = hit.collider.gameObject;
                gO.GetComponent<MaterialScript>().TakingDamageScript(LaserDamage);
            }
        }
        
        beam.SetPosition(0,muzzle.position);
        beam.SetPosition(1,hitposition);
        hitParticles.transform.position = hitposition;
    }   

    public void HideWeapon()
    {
        this.gameObject.SetActive(false);
    }

    public void ActivateWeapon()
    {
        WeaponsManager.ActiveWeapon = WeaponsManager.Instance.WeaponsList.IndexOf(this.anim);
    }
}
