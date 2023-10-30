using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMaterialType
{
    public GameObject Obj{get;set;}
    public string MaterialType{get;set;}
    private float MaxMaterialHp{get;set;}
    public float MaterialCurrentHp;
    
    public CreateMaterialType(GameObject obj,string materialType, float maxMaterialHp)
    {
        this.Obj = obj;
        this.MaterialType = materialType;
        this.MaxMaterialHp = maxMaterialHp;
        MaterialCurrentHp = maxMaterialHp;
        this.Obj.tag = materialType;
    }
}
