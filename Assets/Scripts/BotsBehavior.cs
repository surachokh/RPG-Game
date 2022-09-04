using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotsBehavior : MonoBehaviour
{

    [SerializeField]bool isCollision = false;

    NavMeshAgent agent;
    [SerializeField] float radius;
    [SerializeField] GameObject player;
    [SerializeField] Animator anim;
    [SerializeField] Movement movement;
    [SerializeField] Score score;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        if(isCollision)
        {
            GetAttacked();
        }

        MoveToPlayer();
        WalkAnimator();
    }

    void MoveToPlayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= radius)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    void WalkAnimator()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        if (speed == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isCollision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollision = false;
        }
    }

    void GetAttacked()
    {
        if(movement.GetComponent<Animator>().GetBool("isPunching"))
        {
            Destroy(gameObject);
            score.score++;
        }
    }

}
