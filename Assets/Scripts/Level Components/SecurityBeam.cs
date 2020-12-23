using UnityEngine;

public class SecurityBeam : Laser
{
	private float baseDirection;
	private float dAngle;
	[SerializeField] private float currentDAngle = 0;
	private bool isRotatingClockwise = true;
	[SerializeField] private float rotateRate = 30;

	[SerializeField] private bool isRotating = true;

	private SecuritySystem securitySystem;

	protected override void Awake()
	{
		base.Awake();
		Transform beamMark1 = transform.Find("BeamMark1");
		Transform beamMark2 = transform.Find("BeamMark2");
		dAngle = Vector2.SignedAngle(beamMark1.localPosition, beamMark2.localPosition);
		baseDirection = Vector2.SignedAngle(Vector2.right, beamMark1.localPosition);

		securitySystem = GameObject.Find("SecuritySystem").GetComponent<SecuritySystem>();
	}

	protected override void Update()
	{
		base.Update();

		if (isRotating)
		{
			if (isRotatingClockwise)
			{
				if (currentDAngle < dAngle)
					currentDAngle = Mathf.Min(currentDAngle + Time.deltaTime * rotateRate, dAngle);
				else
					isRotatingClockwise = false;
			}
			else
			{
				if (currentDAngle > 0)
					currentDAngle = Mathf.Max(currentDAngle - Time.deltaTime * rotateRate, 0);
				else
					isRotatingClockwise = true;
			}
		}

		ShootLaser(LayerMask.GetMask("Wall", "Player"), baseDirection + currentDAngle);
	}

	protected override void OnLaserHit(RaycastHit2D hit)
	{
		if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			if (!securitySystem.IsAlertMode)
				securitySystem.IsAlertMode = true;
		}
	}
}
