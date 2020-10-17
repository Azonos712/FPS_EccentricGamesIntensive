using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject HitEffect;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(HitEffect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
