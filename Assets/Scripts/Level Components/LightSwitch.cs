using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
	private Ken ken;

	[SerializeField] private SteelDoor[] steelDoorsToUnlock = null;
	[SerializeField] private GameObject lights = null;
	[SerializeField] private Light2D globalLight = null;
	[SerializeField] private GameObject securityBeams = null;

	void Awake()
	{
		ken = FindObjectOfType<Ken>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		foreach (SteelDoor steelDoor in steelDoorsToUnlock)
			steelDoor.isOpen = true;
		AudioManager.Instance.Play(AudioEnum.EnergyOff);
		lights.SetActive(true);
		globalLight.intensity = 0;
		ken.shooting.HeldWeapon.flashLight.SetActive(true);
		securityBeams.SetActive(false);
		Destroy(gameObject);
	}
}
