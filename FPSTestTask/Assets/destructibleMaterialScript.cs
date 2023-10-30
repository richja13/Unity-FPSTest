using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build;
using UnityEditor.Rendering.Universal.ShaderGraph;
using UnityEngine;

public class destructibleMaterialScript : MonoBehaviour
{
    public static destructibleMaterialScript Instance;
    public List<CreateMaterialType> materialType = new List<CreateMaterialType>();
    public List<GameObject> material;
    public enum materialTypeList
    {
        Metal, Wood, Gold,Concrete
    }
    public materialTypeList materialName;
    public float materialMaxHp;
    // Start is called before the first frame update

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for(int i = 0; i < material.Count; i++)
        {
            material[i].tag = materialName.ToString();
            materialType.Add(new CreateMaterialType(material[i],materialName.ToString(),materialMaxHp)); 
        }
    }

    public void TakingDamage(float dmg, GameObject m)
    {
        float hp = materialType[material.IndexOf(m)].MaterialCurrentHp -= dmg;
        if(hp < 0)
        {
            DestroyMaterial(m);
        }
    }

    void DestroyMaterial(GameObject m)
    {
        Destroy(m);
    }
}
