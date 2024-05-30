using UnityEngine;
using UnityEngine.AI;

public class NavMeshZombuLast : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;

    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        UpdateNavMeshCheckpoint();
    }

    private void UpdateNavMeshCheckpoint()
    {
        _navMeshAgent.destination = _playerPosition.position;
    }
}