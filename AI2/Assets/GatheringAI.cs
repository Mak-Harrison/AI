using UnityEngine;
using UnityEngine.AI;

public class GatheringAI : MonoBehaviour
{
    public enum AIState { Idle, Search, Fetch, Deliver, ReturningHome }
    public AIState currentState = AIState.Idle;

    private NavMeshAgent agent;
    private GameObject targetedResource;

    [Header("Key Locations")]
    public Transform bakeryPoint;
    public Transform gloomFieldPoint;
    public Transform homeBase;        // Where the AI rests

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = AIState.ReturningHome; // Start by going to home base
    }

    void Update()
    {
        switch (currentState)
        {
            case AIState.Idle:
                // Wait a moment, then look for work
                Invoke("StartSearching", 2f);
                break;

            case AIState.Search:
                ScanForResources();
                break;

            case AIState.Fetch:
                MoveToResource();
                break;

            case AIState.Deliver:
                DeliverResource();
                break;

            case AIState.ReturningHome:
                GoHome();
                break;
        }
    }

    void StartSearching() { currentState = AIState.Search; }

    void ScanForResources()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Soul");
        if (target == null) target = GameObject.FindGameObjectWithTag("Gloomroot");
        if (target == null) target = GameObject.FindGameObjectWithTag("Egg");

        if (target != null)
        {
            targetedResource = target;
            currentState = AIState.Fetch;
        }
        else
        {
            // If the world is empty, go rest
            currentState = AIState.ReturningHome;
        }
    }

    void MoveToResource()
    {
        if (targetedResource == null) { currentState = AIState.Search; return; }
        agent.SetDestination(targetedResource.transform.position);

        if (Vector3.Distance(transform.position, targetedResource.transform.position) < 1.2f)
        {
            // Logical Pickup
            if (targetedResource.CompareTag("Soul")) Collectable.hasSoul = true;
            if (targetedResource.CompareTag("Gloomroot")) Collectable.hasGloomroot = true;
            if (targetedResource.CompareTag("Egg")) Collectable.hasEgg = true;

            // Visual Pickup
            targetedResource.transform.parent = this.transform;
            targetedResource.transform.localPosition = new Vector3(0, 1, 1);

            currentState = AIState.Deliver;
        }
    }

    void DeliverResource()
    {
        Transform dest = (targetedResource != null && targetedResource.CompareTag("Soul")) ? gloomFieldPoint : bakeryPoint;
        agent.SetDestination(dest.position);

        if (!agent.pathPending && agent.remainingDistance < 1.2f)
        {
            Destroy(targetedResource);
            currentState = AIState.ReturningHome; // Go home after work is done
        }
    }

    void GoHome()
    {
        agent.SetDestination(homeBase.position);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentState = AIState.Idle; // Relax at home
        }
    }
}
