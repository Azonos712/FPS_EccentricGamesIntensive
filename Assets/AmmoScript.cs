using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{
    public Gun gun;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        gun.OnShoot += SetAmmo;
    }

    void SetAmmo(int ammo)
    {
        text.text = "Ammo: " + ammo;
    }
}
