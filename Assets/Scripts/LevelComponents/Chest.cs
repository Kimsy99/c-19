using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviour
{
	[Header("Reward Position")]
	[SerializeField] private float xRandomPosition = 2f;
	[SerializeField] private float yRandomPosition = 2f;
	
	[SerializeField] private GameObject[] rewards = null;
	
	private bool canReward;
	private bool rewardDelivered;
	private Vector3 rewardRandomPosition;

	private Animator animator;
	private readonly int chestOpenedParameter = Animator.StringToHash("Rewarded");

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			if (canReward)
			{
				RewardPlayer();
			}
		}
	}

	private void RewardPlayer()
	{
		if (canReward && !rewardDelivered)
		{
			animator.SetTrigger(chestOpenedParameter);
			rewardRandomPosition.x = Random.Range(-xRandomPosition, xRandomPosition);
			rewardRandomPosition.y = Random.Range(-yRandomPosition, yRandomPosition);
			Instantiate(SelectReward(), transform.position + rewardRandomPosition, Quaternion.identity);

			rewardDelivered = true;
		}
	}

	private GameObject SelectReward()
	{
		int randomRewardIndex = Random.Range(0, rewards.Length);
		return rewards[randomRewardIndex];
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			canReward = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			canReward = false;
		}
}
}