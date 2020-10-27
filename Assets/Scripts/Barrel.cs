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
                    var bd = item.GetComponent<BodyPart>();
                    if (bd)
                        bd.ThisEnemy.TakeDamage();

                    var ph = item.attachedRigidbody.GetComponent<PlayerHealth>();
                    if (ph)
                        ph.TakeDamage();

                    Vector3 direction = (item.transform.position - transform.position).normalized;
                    item.attachedRigidbody.AddForce(direction * 1000f);
                }
            }
            Instantiate(BangEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
