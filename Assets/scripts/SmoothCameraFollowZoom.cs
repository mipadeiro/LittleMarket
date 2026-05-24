using UnityEngine;

public class SmoothCameraFollowZoom : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Camera Offset")]
    public float offsetX = 0f;
    public float offsetY = 5f;
    public float offsetZ = -10f;

    [Header("X Clamp")]
    public float maxXCam = 8f;
    public float minXCam = -6f;

    [Header("Smooth Follow")]
    public float smoothTime = 0.25f;
    private Vector3 velocity;

    [Header("Zoom Settings")]
    public Transform[] zoomObjects;
    public float targetOffset = 3f;
    public float normalZoom = 60f;
    public float zoomIn = 40f;
    public float zoomSpeed = 5f;

    private Camera cam;
    private bool started = false;

    [Header("Zoom Out Override")]
    private bool zoomOutHeld = false;
    public float zoomOutFOV = 35f;
    public Vector3 zoomOutOffset = new Vector3(-1.42f, 6.23f, -16.21f);

    public float timer = 2f;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Start()
    {
        Invoke(nameof(StartCam), timer);
    }

    void LateUpdate()
    {
        if (!started || target == null) return;

        HandleFollow();
        HandleZoom();
    }

    void HandleFollow()
    {
        Vector3 offset = zoomOutHeld
            ? zoomOutOffset
            : new Vector3(offsetX, offsetY, offsetZ);

        Vector3 targetPosition = target.position + offset;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minXCam, maxXCam);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime
        );
    }

    void HandleZoom()
    {
        if (!cam) return;

        float targetZoom = normalZoom;

        if (zoomOutHeld)
        {
            targetZoom = zoomOutFOV;
        }
        else
        {
            bool shouldZoomIn = false;

            foreach (Transform obj in zoomObjects)
            {
                if (!obj) continue;

                float distance = Vector3.Distance(target.position, obj.position);
                if (distance <= targetOffset)
                {
                    shouldZoomIn = true;
                    break;
                }
            }

            targetZoom = shouldZoomIn ? zoomIn : normalZoom;
        }

        cam.fieldOfView = Mathf.Lerp(
            cam.fieldOfView,
            targetZoom,
            Time.deltaTime * zoomSpeed
        );
    }

    public void SetZoomOut(bool state)
    {
        zoomOutHeld = state;
    }

    void StartCam()
    {
        started = true;
    }
}