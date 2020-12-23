using UnityEngine;

public class SecuritySystem : MonoBehaviour
{
	private Animator animator;
	private readonly int isAlertModeParameter = Animator.StringToHash("IsAlertMode");
	[SerializeField] private GameObject alarmLights = null;
	private Transform securityTurrets;

	void Awake()
	{
		animator = GetComponent<Animator>();
		securityTurrets = transform.Find("SecurityTurrets");
	}

	public bool IsAlertMode
	{
		get => animator.GetBool(isAlertModeParameter);
		set
		{
			animator.SetBool(isAlertModeParameter, value);
			if (value)
			{
				AudioManager.Instance.Play(AudioEnum.Alarm);
				alarmLights.SetActive(true);
				Invoke(nameof(DisableAlertMode), 21);
			}
			for (int i = 0; i < securityTurrets.childCount; i++)
				securityTurrets.GetChild(i).GetComponent<Turret>().Activated = value;
		}
	}

	public void DisableAlertMode()
	{
		AudioManager.Instance.Stop(AudioEnum.Alarm);
		alarmLights.SetActive(false);
		IsAlertMode = false;
	}
}
