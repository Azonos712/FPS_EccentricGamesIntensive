using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    public Text Text;

    void Awake() { PlayerHealth.OnUIHealth += ShowHealth; }
    void ShowHealth(int health) { Text.text = "Health: " + health; }
}
