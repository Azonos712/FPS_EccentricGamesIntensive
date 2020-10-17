using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public GameObject LoseObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyFoot")
        {
            Health = Health - 1;
            if (Health <= 0)
            {
                LoseObject.SetActive(true);
            }
        }
    }
}
