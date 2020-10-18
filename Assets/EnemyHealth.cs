using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health;
    public Animator EnemyAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Health = Health - 1;
            if (Health <= 0)
            {
                EnemyAnimator.SetBool("Died", true);
            }
        }
    }
}
