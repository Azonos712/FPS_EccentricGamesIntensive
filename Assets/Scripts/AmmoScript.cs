using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{
    public Gun Gun;
    public Text Text;

    void Awake() { Gun.OnUIShoot += ShowAmmo; }
    void ShowAmmo(int ammo) { Text.text = "Ammo: " + ammo; }
}
