using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Muzzle;
    public float BulletSpeed;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)  && !anim.GetCurrentAnimatorStateInfo(0).IsName("CannonShoot")) anim.SetTrigger("Shoot");
    }

    void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPrefab, Muzzle.position, Quaternion.identity);
        Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed, ForceMode.Impulse);
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
