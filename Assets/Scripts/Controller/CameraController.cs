using UnityEngine;

/// <summary>
/// Cameras can apply this script to smoothly follow a target.
/// </summary>
public class CameraController : MonoBehaviour
{
	private Camera cam;
	public Transform primaryTarget = null;
	public Transform secondaryTarget = null;
	public float primaryTargetWeightage = 5;
	public float secondaryTargetWeightage = 1;
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
		Vector2 secondPos = secondaryTarget == null ? mousePos : (Vector2)secondaryTarget.position;
		float fx = (primaryTarget.position.x * primaryTargetWeightage + secondPos.x * secondaryTargetWeightage) / (primaryTargetWeightage + secondaryTargetWeightage);
		float fy = (primaryTarget.position.y * primaryTargetWeightage + secondPos.y * secondaryTargetWeightage) / (primaryTargetWeightage + secondaryTargetWeightage);
		float vcx = transform.position.x, vcy = transform.position.y;
		
		// Smoothly follow target and second target
		transform.Translate((fx - vcx) * cameraSpeedFactor * Time.deltaTime, (fy - vcy) * cameraSpeedFactor * Time.deltaTime, 0);

		// Smoothly adjust camera size
		cam.orthographicSize += (camSize - cam.orthographicSize) * cameraSpeedFactor * Time.deltaTime;
	}
}
