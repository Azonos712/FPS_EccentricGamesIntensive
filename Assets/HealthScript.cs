using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public PlayerHealth ph;
    public Text text;

    private void Awake()
    {
        ph.OnHealth += SetHealth;
    }

    void SetHealth(int health)
    {
        text.text = "Health: " + health;
    }
}
