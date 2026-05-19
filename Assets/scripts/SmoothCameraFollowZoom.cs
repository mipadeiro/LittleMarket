using UnityEngine;

public class SmoothCameraFollowZoom : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Camera Offset")]
    public float offsetX = 0f;
    public float offsetY = 5f;
    public float offsetZ = -10f;

    [Header("Smooth Follow")]
    public float smoothTime = 0.25f;
    private Vector3 velocity;

    [Header("Zoom In")]
    public Transform[] zoomObjects;      // objetos que causam zoom
    public float targetOffset = 3f;      // distância mínima para ativar o zoom
    public float normalZoom = 60f;       // FOV normal
    public float zoomIn = 40f;           // FOV aproximado
    public float zoomSpeed = 5f;         // velocidade da transição do zoom
    private bool started = false;

    public float timer = 2f; // Tempo em segundos para iniciar a câmera


    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Start()
    {
        Invoke("StartCam", timer);
    }

    void LateUpdate()
    {
        if (!target) return;


        // Smooth follow
        if (started)
        {
            Vector3 offset = new Vector3(offsetX, offsetY, offsetZ);
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref velocity,
                smoothTime
            );
        }


        // Check if target is near objects

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


        // Smooth zoom

        if (cam)
        {
            float targetZoom = shouldZoomIn ? zoomIn : normalZoom;

            cam.fieldOfView = Mathf.Lerp(
                cam.fieldOfView,
                targetZoom,
                Time.deltaTime * zoomSpeed
            );
        }
    }

    void StartCam()
    {
        started = true;
    }
}