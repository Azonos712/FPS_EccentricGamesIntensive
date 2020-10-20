using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public GameObject LoseObject;
    public GameObject HitObject;

    public delegate void EventHealth(int health);
    public event EventHealth OnHealth;

    private void Start()
    {
        OnHealth?.Invoke(Health);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyFoot")
        {
            Health = Health - 1;
            if (Health <= 0)
            {
                Time.timeScale = 0.2f;
                Time.fixedDeltaTime = 0.02f * 0.2f;
                LoseObject.SetActive(true);
            }
            else
            {
                HitObject.SetActive(true);
            }
            OnHealth?.Invoke(Health);

            Invoke("SetHitUIFalse", 0.15f);
        }
    }

    void SetHitUIFalse()
    {
        HitObject.SetActive(false);
    }
}
