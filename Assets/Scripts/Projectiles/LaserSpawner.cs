using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
	private Camera cam;
	private LineRenderer lineRenderer;
	private WeaponAim weaponAim;
	[SerializeField] private GameObject laserEnd = null;
	public float damage;

	void Awake()
	{
		cam = Camera.main;
		lineRenderer = GetComponent<LineRenderer>();
		weaponAim = GetComponentInParent<WeaponAim>();

		gameObject.SetActive(false);
	}

	void Update()
	{
		lineRenderer.widthMultiplier = Random.Range(0.08F, 0.14F);
	}

	void FixedUpdate()
	{
		ShootLaser();
	}

	void ShootLaser()
	{
		int layerMask = LayerMask.GetMask("Enemy", "Wall");
		Vector2 directionVector = Quaternion.Euler(0, 0, weaponAim.AimAngle) * Vector2.right;
		Vector2 laserEnd = (Vector2)transform.position + directionVector*100;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, directionVector, Mathf.Infinity, layerMask);
		if (hit)
		{
			SetLaserPoints(transform.position, hit.point);
			NPCHealth npcHealth = hit.collider.gameObject.GetComponentInParent<NPCHealth>();
			BossHealth bossHealth = hit.collider.gameObject.GetComponentInParent<BossHealth>();
			if (npcHealth != null)
				npcHealth.Damage(damage, true);
			else if (bossHealth != null)
				bossHealth.Damage(damage, true);
		}
		else
			SetLaserPoints(transform.position, laserEnd);
	}

	private void SetLaserPoints(Vector2 startPosition, Vector2 endPosition)
	{
		lineRenderer.SetPosition(0, startPosition);
		lineRenderer.SetPosition(1, endPosition);
		laserEnd.transform.position = endPosition;
	}

	public bool IsLaserOn
	{
		get => gameObject.activeInHierarchy;
		set
		{
			gameObject.SetActive(value);
			if (value)
			{
				ShootLaser();
				AudioManager.Instance.Play(AudioEnum.Laser);
			}
			else
				AudioManager.Instance.Stop(AudioEnum.Laser);
		}
	}
}
