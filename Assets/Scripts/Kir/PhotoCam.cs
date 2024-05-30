using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoCam : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private LayerMask _obstacleLayer;

    [SerializeField] private NavMeshZombu _navMeshZombu;

    [SerializeField] private Light _spotLight;

    [SerializeField] private AudioSource _audioSourcePhoto;
    [SerializeField] private AudioClip _audioClipPhoto;

    [SerializeField] private AudioSource _audioSourcePhotoVoice;
    [SerializeField] private List<AudioClip> _audioSourcePhotoVoices;

    private Camera _camera;
    private GameObject _cameraTargetPrefab;

    private float _cooldownTime = 30.0f;
    private float _nextPhotoTime = 0f;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
        _cameraTargetPrefab = GameObject.FindGameObjectWithTag("Mob");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time >= _nextPhotoTime)
        {
            CapturePhoto();
            _nextPhotoTime = Time.time + _cooldownTime;
        }
    }

    private void CapturePhoto()
    {
        StartCoroutine(FlashOnCamera());

        PlaySoundPhoto(_audioClipPhoto);

        _camera.enabled = true;

        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _camera.targetTexture = renderTexture;
        Texture2D photo = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        _camera.Render();

        RenderTexture.active = renderTexture;
        photo.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        photo.Apply();

        RenderTexture.active = null;
        _camera.targetTexture = null;
        Destroy(renderTexture);

        if (IsTargetInPhoto(photo))
        {
            StaticInfo.CapturedImages.Add(photo);

            if (StaticInfo.CapturedImages.Count == 1)
                PlaySoundPhotoVoice(_audioSourcePhotoVoices[0]);
            else if (StaticInfo.CapturedImages.Count == 2)
                PlaySoundPhotoVoice(_audioSourcePhotoVoices[1]);
            else if (StaticInfo.CapturedImages.Count == 3)
                PlaySoundPhotoVoice(_audioSourcePhotoVoices[2]);
        }

        _navMeshZombu.SetTargetPosition(_camera.transform.position);

        _camera.enabled = false;
    }

    IEnumerator FlashOnCamera()
    {
        _spotLight.enabled = true;
        yield return new WaitForSeconds(0.25f);
        _spotLight.enabled = false;
    }

    private bool IsTargetInPhoto(Texture2D photo)
    {
        Renderer targetRenderer = _cameraTargetPrefab.GetComponent<Renderer>();
        Bounds targetBounds = targetRenderer.bounds;

        Vector3[] pointsToCheck = new Vector3[]
        {
            targetBounds.center,
            targetBounds.min,
            targetBounds.max,
            new Vector3(targetBounds.min.x, targetBounds.min.y, targetBounds.max.z),
            new Vector3(targetBounds.min.x, targetBounds.max.y, targetBounds.min.z),
            new Vector3(targetBounds.max.x, targetBounds.min.y, targetBounds.min.z),
            new Vector3(targetBounds.max.x, targetBounds.max.y, targetBounds.min.z),
            new Vector3(targetBounds.min.x, targetBounds.max.y, targetBounds.max.z),
            new Vector3(targetBounds.max.x, targetBounds.min.y, targetBounds.max.z)
        };

        foreach (var point in pointsToCheck)
        {
            Vector3 screenPoint = _camera.WorldToScreenPoint(point);

            if (screenPoint.x > 0 && screenPoint.x < Screen.width &&
                screenPoint.y > 0 && screenPoint.y < Screen.height &&
                screenPoint.z > 0)
            {
                if (!IsObstructed(point))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool IsObstructed(Vector3 targetPoint)
    {
        Vector3 direction = targetPoint - _camera.transform.position;
        float distance = Vector3.Distance(_camera.transform.position, targetPoint);

        if (Physics.Raycast(_camera.transform.position, direction, distance, _obstacleLayer))
        {
            return true;
        }

        return false;
    }

    private void PlaySoundPhoto(AudioClip clip)
    {
        if (clip != null && _audioSourcePhoto != null)
        {
            _audioSourcePhoto.PlayOneShot(clip);
        }
    }

    private void PlaySoundPhotoVoice(AudioClip clip)
    {
        if (clip != null && _audioSourcePhotoVoice != null)
        {
            _audioSourcePhotoVoice.PlayOneShot(clip);
        }
    }
}