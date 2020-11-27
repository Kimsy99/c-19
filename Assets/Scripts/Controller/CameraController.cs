using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Camera cam;
	[SerializeField] private GameObject cameraFocus;
	[SerializeField] private float cameraSpeedFactor = 3;
	private Vector2 mousePos = new Vector2();

	// Update is called once per frame
	void Update()
	{
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		float fx = (cameraFocus.transform.position.x*5 + mousePos.x) / 6, fy = (cameraFocus.transform.position.y*5 + mousePos.y) / 6;
		float vcx = transform.position.x, vcy = transform.position.y;
			
		transform.Translate((fx - vcx) * cameraSpeedFactor * Time.deltaTime, (fy - vcy) * cameraSpeedFactor * Time.deltaTime, 0);
	}
}
