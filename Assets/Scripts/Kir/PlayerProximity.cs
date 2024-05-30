using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProximity : MonoBehaviour
{
    [SerializeField] private Transform _mob;

    [SerializeField] private Camera _playerCamera;

    [SerializeField] private AudioSource _proximityAudioSource;

    [SerializeField] private float _maxDistance = 50f;

    [SerializeField] private float _agreDistance = 20f;
    [SerializeField] private float _criticalDistance = 5f;

    [SerializeField] private float _shakeIntensity = 0.2f;
    [SerializeField] private float _speedIncreaseRate = 0.1f;

    private Vector3 originalCameraPosition;

    private NavMeshZombu _navMeshMob;

    private float _timeWithinAgreDistance;
    private bool _isPlayerWithinAgreDistance;

    private void Start()
    {
        _playerCamera = Camera.main;

        originalCameraPosition = _playerCamera.transform.localPosition;

        _navMeshMob = _mob.GetComponent<NavMeshZombu>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _mob.position);

        if (distance <= _criticalDistance)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            if (distance <= _agreDistance)
            {
                if (!_isPlayerWithinAgreDistance)
                {
                    _isPlayerWithinAgreDistance = true;
                    _timeWithinAgreDistance = 0f;
                }

                _timeWithinAgreDistance += Time.deltaTime;

                float newSpeed = _navMeshMob.GetInitialSpeed() + (_speedIncreaseRate * _timeWithinAgreDistance);
                _navMeshMob.SetSpeed(newSpeed);

                _navMeshMob.SetTargetPosition(transform.position);
            }
            else
            {
                if (_isPlayerWithinAgreDistance)
                {
                    _isPlayerWithinAgreDistance = false;
                    _navMeshMob.SetSpeed(_navMeshMob.GetInitialSpeed());
                }
            }

            float proximityFactor = Mathf.Clamp01(1 - (distance / _maxDistance));

            _proximityAudioSource.volume = proximityFactor;

            float shakeAmount = _shakeIntensity * proximityFactor;
            _playerCamera.transform.localPosition = originalCameraPosition + Random.insideUnitSphere * shakeAmount;
        }
    }

    private void OnDisable()
    {
        _playerCamera.transform.localPosition = originalCameraPosition;
    }
}