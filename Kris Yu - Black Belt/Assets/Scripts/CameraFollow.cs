using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform[] players = new Transform[2];

    [Header("Zoom Settings")]
    public float minZoom = 10;
    public float maxZoom = 200f;
    public float zoomLimiter = 10f;
    public float smoothTime = 0.2f;

    private Camera cam;
    private Vector3 velocity;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void LateUpdate()
    {
        if (players[0] == null && players[1] == null) return;

        Vector3 targetPosition;

        if (players[0] == null)
        {
            targetPosition = new Vector3(players[1].position.x, players[1].position.y + 2, -10);
        }
        else if (players[1] == null)
        {
            targetPosition = new Vector3(players[0].position.x, players[0].position.y + 2, -10);
        }
        else
        {
            Vector3 midpoint = (players[0].position + players[1].position) / 2f;
            targetPosition = new Vector3(midpoint.x, midpoint.y + 2, -10);

            float distance = Vector3.Distance(players[0].position, players[1].position);
            float targetZoom = Mathf.Clamp(minZoom + (distance / zoomLimiter), minZoom, maxZoom);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * 5f);
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}