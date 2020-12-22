using UnityEngine;

public class Laser : MonoBehaviour
{
	protected LineRenderer lineRenderer;
	[SerializeField] private GameObject laserEnd = null;
	[SerializeField] protected float widthMin = 0.08F, widthMax = 0.14F;

	protected virtual void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	protected virtual void Update()
	{
		lineRenderer.widthMultiplier = Random.Range(widthMin, widthMax);
	}

	protected void ShootLaser(int layerMask, float angle)
	{
		Vector2 directionVector = Quaternion.Euler(0, 0, angle) * Vector2.right;
		Vector2 laserEnd = (Vector2)transform.position + directionVector * 100;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, directionVector, Mathf.Infinity, layerMask);
		if (hit)
		{
			SetLaserPoints(transform.position, hit.point);
			OnLaserHit(hit);
		}
		else
			SetLaserPoints(transform.position, laserEnd);
	}

	protected virtual void OnLaserHit(RaycastHit2D hit) {}

	private void SetLaserPoints(Vector2 startPosition, Vector2 endPosition)
	{
		lineRenderer.SetPosition(0, startPosition);
		lineRenderer.SetPosition(1, endPosition);
		laserEnd.transform.position = endPosition;
	}
}
