using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.Rendering.Universal.ShaderGraph;
using UnityEngine;
using UnityEngine.Events;

public class MaterialScript : MonoBehaviour
{
    private float materialcurrentHp;
    public float materialMaxHp;
    public enum materialTypeList
    {
        Metal, Wood, Concrete
    }
    public materialTypeList materialName;
    private Material material;
    public GameObject materialParticles;
    [SerializeField] private UnityEvent TriggerEvent;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        materialcurrentHp = materialMaxHp;
        this.gameObject.tag = materialName.ToString();
    }

    public void TakingDamageScript(float dmg)
    {
        materialcurrentHp -= dmg;
        if(materialcurrentHp <= 0) Destroy(this.gameObject);;
    }

    void OnDestroy()
    {
        TriggerEvent.Invoke();
        GameObject mP = Instantiate(materialParticles,transform.position,Quaternion.identity);
        mP.GetComponent<ParticleSystemRenderer>().material = material;
    }

}
