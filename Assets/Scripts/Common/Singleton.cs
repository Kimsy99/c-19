using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
	private static T instance;

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<T>();
				if (instance == null)
				{
					GameObject newGameObject = new GameObject();
					instance = newGameObject.AddComponent<T>();
				}
			}

			return instance;
		}
	}

	// In case any Singleton class has Awake method, we need to prepare here as well 
	protected virtual void Awake()
	{
		instance = this as T;
	}
}