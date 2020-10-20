using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject BangEffectPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Collider[] allColliders = Physics.OverlapSphere(transform.position, 5f);
            foreach (var item in allColliders)
            {
                if (item.attachedRigidbody)
                {
                    if (item.GetComponent<BodyPart>())
                    {
                        item.GetComponent<BodyPart>().ThisEnemy.TakeDamage();
                    }
                    if (item.attachedRigidbody.GetComponent<PlayerHealth>())
                    {
                        item.attachedRigidbody.GetComponent<PlayerHealth>().Health--;
                    }

                    Vector3 direction = (item.transform.position - transform.position).normalized;
                    item.attachedRigidbody.AddForce(direction * 1000f);
                }
            }
            Instantiate(BangEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
