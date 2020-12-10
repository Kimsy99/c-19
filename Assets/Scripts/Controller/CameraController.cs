using UnityEngine;

/// <summary>
/// Cameras can apply this script to smoothly follow a target.
/// </summary>
public class CameraController : MonoBehaviour
{
	private Camera cam;
	[SerializeField] private Transform cameraTarget;
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
		float fx = (cameraTarget.position.x*5 + mousePos.x) / 6, fy = (cameraTarget.position.y*5 + mousePos.y) / 6;
		float vcx = transform.position.x, vcy = transform.position.y;
			
		transform.Translate((fx - vcx) * cameraSpeedFactor * Time.deltaTime, (fy - vcy) * cameraSpeedFactor * Time.deltaTime, 0);
	}
}
