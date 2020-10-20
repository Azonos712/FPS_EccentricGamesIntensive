using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff : MonoBehaviour
{
    float _timer;
    public float TimeOff = 1f;
    bool _lightSwitch = false;
    public GameObject L;

    void Update()
    {
        _timer = _timer + Time.deltaTime;
        if (_timer >= TimeOff)
        {
            _timer = 0f;
            L.SetActive(!_lightSwitch);
            L.SetActive(_lightSwitch);
            L.SetActive(!_lightSwitch);
            _lightSwitch = !_lightSwitch;
        }
    }
}
