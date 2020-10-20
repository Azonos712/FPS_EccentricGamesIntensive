using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject _player;
    public Animator EnemyAnimator;
    NavMeshAgent _navMesh;
    public int Health;
    public BodyPart[] AllBodyParts;
    bool _takenDmg = false;
    float _timer = 0;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _navMesh.SetDestination(_player.transform.position);
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) > 2f)
        {
            EnemyAnimator.SetBool("Attack", false);
            _navMesh.speed = 1.5f;

            if (_takenDmg)
            {
                _timer += Time.deltaTime;
                _navMesh.speed = 0f;
                if (_timer >= 0.7f)
                {
                    _takenDmg = false;
                    _timer = 0;
                }
            }
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

    public void TakeDamage()
    {
        //TODO: Останавливать модель при получении урона
        if (_takenDmg != true)
        {
            _takenDmg = true;
            EnemyAnimator.SetTrigger("Hit");
        }
        Health = Health - 1;

        if (Health <= 0)
        {
            _navMesh.enabled = false;
            EnemyAnimator.enabled = false;
            this.enabled = false;

            foreach (var item in AllBodyParts)
            {
                var rgbd = item.GetComponent<Rigidbody>();
                rgbd.isKinematic = false;
                rgbd.AddForce(0f, 400f, 0f);
                rgbd.AddForce(-transform.forward * 700f);

            }
        }
    }
}
