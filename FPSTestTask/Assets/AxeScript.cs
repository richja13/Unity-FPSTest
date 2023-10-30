using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AxeScript : MonoBehaviour
{
    public Transform AttackPos;
    private SphereCollider AttackCollider;
    public float MeleeDamage, attackRange;
    private Animator anim;
    public bool IsAttacking;
    public ParticleSystem axeParticles;

    void Awake()
    {
        anim = GetComponent<Animator>();
        AttackCollider = GetComponent<SphereCollider>();
        AttackCollider.radius = attackRange;
    }
    // Start is called before the first frame update
    void Start()
    {
        IsAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("AxeSwing")) anim.SetTrigger("Attack");
    }

    public void StartMeleeAttack()
    {
       IsAttacking = true;
    }

    public void EndMeleeAttack()
    {
        IsAttacking = false;
    }

    public void HideWeapon()
    {
        this.gameObject.SetActive(false);
    }

    public void ActivateWeapon()
    {
        WeaponsManager.ActiveWeapon = WeaponsManager.Instance.WeaponsList.IndexOf(this.anim);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(AttackPos.position.x,AttackPos.position.y,AttackPos.position.z),attackRange);
    }


    
    void OnTriggerStay(Collider other)
    {
        if(other != null)   Debug.Log(other.gameObject.tag);
      
        if(other.gameObject.tag == "Wood" && IsAttacking)
        {
            other.gameObject.GetComponent<MaterialScript>().TakingDamageScript(MeleeDamage);
            axeParticles.Play();
        }
    }

    
}
