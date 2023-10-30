using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public GameObject ExplosionParticles;
    public Material ClosedWindow;
   
    public void Explosion(Transform ObjectPos)
    {
        Instantiate(ExplosionParticles, ObjectPos.position, Quaternion.identity);
    }

    public void CloseWindow(Renderer window)
    {
        window.material = ClosedWindow;
    }
}
