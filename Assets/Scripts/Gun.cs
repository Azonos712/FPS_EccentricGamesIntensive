using UnityEngine;

public class Gun : MonoBehaviour
{
    int _bullets = 30;
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
    public event MyShoot OnUIShoot;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        OnUIShoot?.Invoke(_bullets);
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
            ZoomCamera(-Time.deltaTime * 80f, AimPosition);
        else
            ZoomCamera(Time.deltaTime * 80f, StartPosition);

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Timer = Timer + Time.deltaTime;
            if (Timer > ShotPeriod)
            {
                if (_bullets > 0)
                {
                    _bullets = _bullets - 1;

                    SpawnBullet();

                    SpawnCartridge();

                    PlayShotSound();

                    Flash.SetActive(true);
                    anim.Play();
                    Invoke("HideFlash", 0.1f);
                }
                else
                {
                    PlayEmptyShotSound();
                }

                OnUIShoot?.Invoke(_bullets);
                Timer = 0f;
            }
        }
    }

    void ZoomCamera(float fieldOfView, Vector3 point)
    {
        ThisCamera.fieldOfView = Mathf.Clamp(ThisCamera.fieldOfView + fieldOfView, 60f, 80f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, point, Time.deltaTime * 10f);
    }

    void SpawnBullet()
    {
        var tSP = SpawnPoint.transform;
        GameObject newBullet = Instantiate(BulletPrefab, tSP.position, tSP.rotation * Quaternion.Euler(90, 0, 0));
        newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint.transform.forward * BulletSpeed;
    }

    void SpawnCartridge()
    {
        var tSCP = SpawnCartridgePoint.transform;
        GameObject newCartridge = Instantiate(CartridgePrefab, tSCP.position, tSCP.rotation * Quaternion.Euler(Random.Range(80, 100), 0, 0));
        newCartridge.GetComponent<Rigidbody>().velocity = SpawnPoint.transform.right * Random.Range(0.9f, 1.1f);
    }

    void PlayShotSound()
    {
        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.Play();
    }

    void PlayEmptyShotSound()
    {
        _emptyAudioSource.pitch = Random.Range(0.8f, 1.2f);
        _emptyAudioSource.Play();
    }

    public void AddAmmo(int ammo)
    {
        _bullets += ammo;
        OnUIShoot?.Invoke(_bullets);
    }

    void HideFlash() { Flash.SetActive(false); }
}