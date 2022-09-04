using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    Camera cam;
    [SerializeField] LayerMask groundMask;

    [SerializeField] Animator anim;
    [SerializeField] float destroyTime = 0f;
    NavMeshAgent navMeshAgent;

    [SerializeField] GameController gameController;

    void Start()
    {
        cam = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameController.playState)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            navMeshAgent.isStopped = false;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                MovementControl(hit.point);
                WalkAnimator();
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            Attack();
        }
    }

    void MovementControl(Vector3 target)
    {
        if (target != Vector3.zero)
        {
            navMeshAgent.SetDestination(target);
        }

    }

    void WalkAnimator()
    {
        float speed = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
        if(speed >= Mathf.Epsilon)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void Attack()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;
        anim.SetTrigger("attack");
        anim.SetBool("isWalking", false);
    }

}


