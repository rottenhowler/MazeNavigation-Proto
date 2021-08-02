using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    public NavMeshPath Path { get { return navMeshAgent.path; } }

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        GetComponent<Rigidbody>().inertiaTensor = Vector3.one * 0.01f;
    }

    public void GoTo(Vector3 destination)
    {
        navMeshAgent.destination = destination;
    }

    void FixedUpdate()
    {
        if (navMeshAgent.hasPath)
        {
            if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
            {
                transform.LookAt(Path.corners[1]);
                animator.SetFloat("Speed", 1f);
            }
            else
            {
                navMeshAgent.ResetPath();
            }
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}
