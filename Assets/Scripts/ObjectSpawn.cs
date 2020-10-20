using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject SpawnPrefab;
    public float MinSpawnPeriod;
    public float MaxSpawnPeriod;
    public float Timer;

    public float OffsetValue;
    float _period;

    private void Start()
    {
        _period = Random.Range(MinSpawnPeriod, MaxSpawnPeriod);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= _period)
        {
            Timer = 0;
            Vector3 randomOffset = new Vector3(Random.Range(-OffsetValue, OffsetValue), 0f, Random.Range(-OffsetValue, OffsetValue));
            Instantiate(SpawnPrefab, transform.position + randomOffset, transform.rotation);
            _period = Random.Range(MinSpawnPeriod, MaxSpawnPeriod);
        }
    }
}
