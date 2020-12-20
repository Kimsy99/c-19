#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.Rendering;

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class TransparencySortGraphicsHelper
{
	static TransparencySortGraphicsHelper()
	{
		OnLoad();
	}

	[RuntimeInitializeOnLoadMethod]
	static void OnLoad()
	{
		GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
		GraphicsSettings.transparencySortAxis = new Vector3(0, 1.0F, 0);
		//Debug.Log("Transparency sort mode set to Custom Axis " + GraphicsSettings.transparencySortAxis);
	}
}
