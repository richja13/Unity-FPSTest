using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponsManager : MonoBehaviour
{
    public static WeaponsManager Instance;
    public List<Animator> WeaponsList;
    public static int ActiveWeapon;
    [SerializeField] private TMP_Text CurrentWeaponText;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ActiveWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1 )&& !WeaponsList[0].gameObject.activeInHierarchy)
        {
            ChangeWeapon(0); 
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && !WeaponsList[1].gameObject.activeInHierarchy) 
        {
            ChangeWeapon(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3) && !WeaponsList[2].gameObject.activeInHierarchy) 
        {
            ChangeWeapon(2);
        }
    }

    void ChangeWeapon(int number)
    {
        WeaponsList[ActiveWeapon].SetTrigger("Hide");
        WeaponsList[number].gameObject.SetActive(true);
        CurrentWeaponText.text = (number + 1) + "-" + WeaponsList[number].gameObject.name;
    }
}
