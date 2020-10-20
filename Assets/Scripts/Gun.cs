using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int Bullets;
    public GameObject BulletPrefab;
    public GameObject SpawnPoint;
    public GameObject CartridgePrefab;
    public GameObject SpawnCartridgePoint;
    public int BulletSpeed = 80;
    public float Timer;
    public float ShotPeriod = 0.2f;
    public Animation anim;

    public GameObject Flash;
    private AudioSource _audioSource;
    public AudioSource _emptyAudioSource;

    public Vector3 StartPosition;
    public Vector3 AimPosition;
    public Camera ThisCamera;

    public delegate void MyShoot(int ammo);
    public event MyShoot OnShoot;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        OnShoot?.Invoke(Bullets);
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            ThisCamera.fieldOfView = Mathf.Clamp(ThisCamera.fieldOfView - Time.deltaTime * 80f, 60f, 80f);// 60f + Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition, AimPosition, Time.deltaTime * 10f);
        }
        else
        {
            ThisCamera.fieldOfView = Mathf.Clamp(ThisCamera.fieldOfView + Time.deltaTime * 80f, 60f, 80f); //80f - Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition, StartPosition, Time.deltaTime * 10f);
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Timer = Timer + Time.deltaTime;
            if (Bullets > 0)
            {
                if (Timer > ShotPeriod)
                {
                    OnShoot?.Invoke(Bullets);
                    Timer = 0f;
                    Bullets = Bullets - 1;

                    var tSP = SpawnPoint.transform;
                    GameObject newBullet = Instantiate(BulletPrefab, tSP.position, tSP.rotation * Quaternion.Euler(90, 0, 0));
                    newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint.transform.forward * BulletSpeed;

                    var tSCP = SpawnCartridgePoint.transform;
                    GameObject newCartridge = Instantiate(CartridgePrefab, tSCP.position, tSCP.rotation * Quaternion.Euler(Random.Range(80, 100), 0, 0));
                    newCartridge.GetComponent<Rigidbody>().velocity = SpawnPoint.transform.right * Random.Range(0.9f, 1.1f);

                    _audioSource.pitch = Random.Range(0.8f, 1.2f);
                    _audioSource.Play();

                    Flash.SetActive(true);
                    anim.Play();
                    Invoke("HideFlash", 0.1f);
                }
            }
            else
            {
                if (Timer > ShotPeriod)
                {
                    Timer = 0f;
                    _emptyAudioSource.pitch = Random.Range(0.8f, 1.2f);
                    _emptyAudioSource.Play();
                    Debug.Log("Нет пуль!!!");
                    OnShoot?.Invoke(0);
                }
            }
        }
    }

    public void AddAmmo(int ammo)
    {
        Bullets += ammo;
        OnShoot?.Invoke(Bullets);
    }

    public void HideFlash()
    {
        Flash.SetActive(false);
    }
}
