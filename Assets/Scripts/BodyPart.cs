using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public Enemy ThisEnemy;
    void Start() { GetComponent<Rigidbody>().isKinematic = true; }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            ThisEnemy.TakeDamage();
    }
}
