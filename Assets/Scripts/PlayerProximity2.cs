using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProximity2 : MonoBehaviour
{
    [SerializeField] private Transform _mob;

    [SerializeField] private Camera _playerCamera;

    [SerializeField] private float _maxDistance = 50f;

    [SerializeField] private float _criticalDistance = 5f;

    [SerializeField] private float _shakeIntensity = 0.2f;

    private Vector3 originalCameraPosition;

    private void Start()
    {
        _playerCamera = Camera.main;

        originalCameraPosition = _playerCamera.transform.localPosition;
    }

    private void Update()
    {
        if (_mob != null)
        {
            float distance = Vector3.Distance(transform.position, _mob.position);

            if (distance <= _criticalDistance)
            {
                SceneManager.LoadScene(4);
            }
            else
            {
                float proximityFactor = Mathf.Clamp01(1 - (distance / _maxDistance));

                float shakeAmount = _shakeIntensity * proximityFactor;
                _playerCamera.transform.localPosition = originalCameraPosition + Random.insideUnitSphere * shakeAmount;
            }
        }
    }

    private void OnDisable()
    {
        _playerCamera.transform.localPosition = originalCameraPosition;
    }
}