public class LevelDataManager : Singleton<LevelDataManager>
{
	public readonly LevelData[] levelData = new LevelData[5];

	protected override void Awake()
	{
		base.Awake();
		if (FindObjectsOfType<SceneLoader>().Length > 1)
			Destroy(gameObject);
		else
			DontDestroyOnLoad(gameObject);
	}
}
