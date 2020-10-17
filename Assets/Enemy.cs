using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public Animator EnemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) > 2f)
        {
            EnemyAnimator.SetBool("Attack", false);
            GetComponent<NavMeshAgent>().speed = 1.5f;
        }
        else
        {
            EnemyAnimator.SetBool("Attack", true);
            GetComponent<NavMeshAgent>().speed = 0;
        }
    }
}
