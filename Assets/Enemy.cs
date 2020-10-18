using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject _player;
    public Animator EnemyAnimator;
    NavMeshAgent _navMesh;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _navMesh.SetDestination(_player.transform.position);
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) > 2f)
        {
            EnemyAnimator.SetBool("Attack", false);
            _navMesh.speed = 1.5f;
        }
        else
        {
            EnemyAnimator.SetBool("Attack", true);
            _navMesh.speed = 0f;

            Vector3 fromTo = _player.transform.position - transform.position;
            Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);
            Quaternion targetRotation = Quaternion.LookRotation(fromToXZ);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 4f);
        }
    }
}
