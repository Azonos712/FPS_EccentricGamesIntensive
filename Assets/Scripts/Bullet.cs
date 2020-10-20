using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject HitEffect;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        var temp = Instantiate(HitEffect, gameObject.transform.position, gameObject.transform.rotation);
        Invoke("Destroy(temp)", 2f);
    }
}
