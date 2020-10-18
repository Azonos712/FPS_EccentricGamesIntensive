using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int Bullets;
    public GameObject BulletPrefab;
    public GameObject SpawnPoint;
    public int BulletSpeed = 80;
    public float Timer;
    public float ShotPeriod = 0.2f;
    public Animation anim;

    public GameObject Flash;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Timer = Timer + Time.deltaTime;
            if (Bullets > 0)
            {
                if (Timer > ShotPeriod)
                {
                    Timer = 0f;
                    Bullets = Bullets - 1;
                    GameObject newBullet = Instantiate(BulletPrefab, SpawnPoint.transform.position, Quaternion.Euler(90, 0, 0));
                    newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint.transform.forward * BulletSpeed;
                    Flash.SetActive(true);
                    anim.Play();
                    Invoke("HideFlash", 0.1f);
                }
            }
            else
                Debug.Log("Нет пуль!!!");
        }
    }

    public void HideFlash()
    {
        Flash.SetActive(false);
    }
}
