using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
	private Camera cam;
	private LineRenderer lineRenderer;
	private WeaponAim weaponAim;
	[SerializeField] private GameObject laserEnd;
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
		int layerMask = 1 << 10 | 1 << 12;
		Vector2 laserEnd = transform.position + Quaternion.Euler(0, 0, weaponAim.AimAngle) * Vector2.right * 100;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, laserEnd, Mathf.Infinity, layerMask);
		if (hit)
		{
			SetLaserPoints(transform.position, hit.point);
			NPCHealthBar npcHealth = hit.collider.gameObject.GetComponentInChildren<NPCHealthBar>();
			if (npcHealth != null)
			{
				hit.collider.gameObject.GetComponent<Flashable>().Flash();
				npcHealth.hp -= damage;
			}
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
				AudioManager.Instance.Play(SoundEnum.Laser);
			}
			else
				AudioManager.Instance.Stop(SoundEnum.Laser);
		}
	}
}
