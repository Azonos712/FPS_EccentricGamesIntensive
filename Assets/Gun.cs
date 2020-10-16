using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int Bullets;
    public GameObject BulletPrefab;
    public GameObject SpawnPoint;
    public int BulletSpeed = 80;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Bullets > 0)
            {
                Bullets = Bullets - 1;
                GameObject newBullet = Instantiate(BulletPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint.transform.forward * BulletSpeed;
            }
            else
                Debug.Log("Нет пуль!!!");
        }
    }
}
