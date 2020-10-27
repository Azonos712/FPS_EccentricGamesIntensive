using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 5;
    public GameObject LoseObject;
    public GameObject HitObject;

    public delegate void EventHealth(int health);
    public event EventHealth OnUIHealth;

    private void Start() { OnUIHealth?.Invoke(_health); }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyFoot")
            TakeDamage();
    }

    public void TakeDamage()
    {
        _health = _health - 1;
        if (_health <= 0)
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.02f * 0.2f;
            LoseObject.SetActive(true);
        }
        else
        {
            HitObject.SetActive(true);
        }

        OnUIHealth?.Invoke(_health);
        Invoke("SetHitUIFalse", 0.15f);
    }

    void SetHitUIFalse() { HitObject.SetActive(false); }
}