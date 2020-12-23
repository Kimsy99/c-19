using UnityEngine;

/// <summary>
/// Cameras can apply this script to smoothly follow a target.
/// </summary>
public class CameraController : MonoBehaviour
{
    private Camera cam;
    public Transform cameraTarget = null;
    public Transform secondTarget = null;
    public float cameraTargetWeightage = 5;
    public float camSize = 4;
    [SerializeField] private float cameraSpeedFactor = 3;
    private Vector2 mousePos = new Vector2();

    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 secondPos = secondTarget == null ? mousePos : (Vector2)secondTarget.position;
        float fx = (cameraTarget.position.x * cameraTargetWeightage + secondPos.x) / (1 + cameraTargetWeightage), fy = (cameraTarget.position.y * cameraTargetWeightage + secondPos.y) / (1 + cameraTargetWeightage);
        float vcx = transform.position.x, vcy = transform.position.y;
        
        // Smoothly follow target and second target
        transform.Translate((fx - vcx) * cameraSpeedFactor * Time.deltaTime, (fy - vcy) * cameraSpeedFactor * Time.deltaTime, 0);

        // Smoothly adjust camera size
        cam.orthographicSize += (camSize - cam.orthographicSize) * cameraSpeedFactor * Time.deltaTime;
    }
}
