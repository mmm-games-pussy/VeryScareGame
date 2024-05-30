using UnityEngine;
using UnityEngine.AI;

public class NavMeshZombu : MonoBehaviour
{
    [SerializeField] private float _distanceToChangeCheckpoint = 2f;

    [SerializeField] private float _initialSpeed = 3.5f;

    private NavMeshAgent _navMeshAgent;

    private GameObject[] _checkpoints;

    private int _currentCheckpointID;
    private int _previousCheckpointID;

    private Vector3 _targetPosition;

    private bool _hasNewTarget;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _checkpoints = GameObject.FindGameObjectsWithTag("NavMeshCheckpoint");

        _navMeshAgent.speed = _initialSpeed;
    }

    private void Start()
    {
        StartNavMesh();
    }

    private void FixedUpdate()
    {
        if (_hasNewTarget)
        {
            _navMeshAgent.destination = _targetPosition;
            _hasNewTarget = false;
        }
        else
        {
            UpdateNavMeshCheckpoint();
        }
    }

    private void StartNavMesh()
    {
        _currentCheckpointID = Random.Range(0, _checkpoints.Length);
        _navMeshAgent.destination = _checkpoints[_currentCheckpointID].transform.position;
    }

    private void UpdateNavMeshCheckpoint()
    {
        if (_navMeshAgent.remainingDistance <= _distanceToChangeCheckpoint)
        {
            _previousCheckpointID = _currentCheckpointID;

            do
            {
                _currentCheckpointID = Random.Range(0, _checkpoints.Length);
            }
            while (_currentCheckpointID == _previousCheckpointID);

            _navMeshAgent.destination = _checkpoints[_currentCheckpointID].transform.position;
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        _targetPosition = position;
        _hasNewTarget = true;
    }

    public void SetSpeed(float speed)
    {
        _navMeshAgent.speed = speed;
    }

    public float GetInitialSpeed()
    {
        return _initialSpeed;
    }
}