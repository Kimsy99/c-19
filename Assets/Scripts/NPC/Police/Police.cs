using System.Collections;
using UnityEngine;

public class Police : Zombie1
{
	private GameObject weaponHolder;
	private NPCHeldWeapon npcHeldWeapon;
	private Coroutine shootingCoroutine;

	protected override void Awake()
	{
		base.Awake();
		weaponHolder = transform.Find("WeaponHolder").gameObject;
		npcHeldWeapon = weaponHolder.GetComponentInChildren<NPCHeldWeapon>();
		GetComponent<NPCHealth>().OnDie += Die;
	}

	void Start()
	{
		shootingCoroutine = StartCoroutine(Shot());
	}

	private void Die()
	{
		weaponHolder.SetActive(false);
		StopAllCoroutines();
	}

	public new IEnumerator Shot()
	{
		yield return new WaitForSeconds(3);
		npcHeldWeapon.Shoot();
		StartCoroutine(Shot());
	}
}
