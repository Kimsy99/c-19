using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
	public Transition currentTransition; // 当前的过场预设
	public bool IsLoadable { get; private set; } // 现在是否可以转场
	public int data;

	private readonly int outParameter = Animator.StringToHash("Out");

	protected override void Awake()
	{
		base.Awake();
		if (FindObjectsOfType<SceneLoader>().Length > 1)
			Destroy(gameObject);
		else
			DontDestroyOnLoad(gameObject);
		IsLoadable = true;
	}

	public void LoadScene(string SceneName, Transition transition = null)
	{
		// 如果现在不能转换场景直接返回
		if (!IsLoadable) return;

		// 如果有设置过场就设置过场
		if (transition != null)
			currentTransition = transition;

		// 开始转换场景
		StartCoroutine(LoadLevel(SceneName));
	}

	private IEnumerator LoadLevel(string levelName)
	{
		Canvas canvas = currentTransition.GetComponentInChildren<Canvas>();
		canvas.sortingOrder = 110;
		// 异步加载场景
		AsyncOperation loading = SceneManager.LoadSceneAsync(levelName);

		// 不允许场景加载完后直接转换
		loading.allowSceneActivation = false;

		// 现在不再能转换场景
		IsLoadable = false;

		// 开始过场
		currentTransition.StartTrans();

		// 等待一帧
		// 理由再下面有解释，但其实这里本来不需要，因为检查动画前还夹着一个检查加载的过程。基本不会在一帧内就加载完
		// 但是保险起见还是在播放动画后延迟一帧
		yield return null;

		// 等待场景加载几乎完成
		while (loading.progress < 0.899)
			yield return null;

		// 等待动画播放完成
		while (!currentTransition.IsAnimationDone())
			yield return null;

		// 允许场景加载完成
		loading.allowSceneActivation = true;

		// 等待场景加载彻底完成
		while (loading.progress != 1)
			yield return null;

		if (levelName.StartsWith("Level "))
		{
			canvas.worldCamera = GameObject.Find("UICamera").GetComponent<Camera>();
			canvas.sortingOrder = 100;
			TextMeshProUGUI levelLabel = GameObject.Find("LevelLabel").GetComponent<TextMeshProUGUI>();
			TextMeshProUGUI levelSubLabel = GameObject.Find("LevelSubLabel").GetComponent<TextMeshProUGUI>();
			levelLabel.text = levelName;
			levelSubLabel.text = GetLevelGreeting(levelName);
			yield return new WaitForSeconds(2);
			levelLabel.GetComponent<Animator>().SetTrigger(outParameter);
			levelSubLabel.GetComponent<Animator>().SetTrigger(outParameter);
		}

		// 结束过场
		currentTransition.EndTrans();

		// 等待一帧
		// 因为我发现如果在开始动画后不等待一帧的话，第二个动画其实还没开始播放，
		// 后面检测动画完成检测的就是第一个动画，就起不到检测第二个动画的作用。
		yield return null;

		// 等待动画播放完成
		while (!currentTransition.IsAnimationDone())
			yield return null;

		//print("Done");

		// 可以继续转换场景
		IsLoadable = true;
	}

	private string GetLevelGreeting(string levelName)
	{
		switch (levelName)
		{
			case "Level 1":
				return "The C-19 Hospital";
			case "Level 2":
				return "Experimental Area Square";
			case "Level 3":
				return "Virus Laboratory";
			case "Level 4":
				return "Quarantine Administration Center";
			case "Level 5":
				return "Boundary to the Outside World";
			default:
				return "missingno";
		}
	}
}
