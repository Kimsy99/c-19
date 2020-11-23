using UnityEngine;

public class KenFlash : Flashable
{
	private ParticleSystem blood;
	private AudioSource hurt;

	protected override void Start()
	{
		base.Start();
		blood = GetComponentInChildren<ParticleSystem>();
		hurt = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flash();
			blood.Play();
			hurt.Play();
        }
    }
}
