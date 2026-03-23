using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public Transform targetPoint;
    private NavMeshAgent agent;
    private bool hasFood = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void ReceiveShawarma()
    {
        if (hasFood) return;

        hasFood = true;
        Invoke(nameof(MoveToPoint), 0);
    }

    void MoveToPoint()
    {
        agent.SetDestination(targetPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
