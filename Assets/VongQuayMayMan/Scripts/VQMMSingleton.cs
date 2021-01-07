using UnityEngine;

public class VQMMSingleton<T> : MonoBehaviour where T : MonoBehaviour {

	private static T _instance;

	public static T Instance
	{
		get
		{
			if(VQMMSingleton<T>._instance == null)
			{
				VQMMSingleton<T>._instance = (T) Object.FindObjectOfType(typeof(T));
				if(VQMMSingleton<T>._instance == null)
					VQMMSingleton<T>._instance = (T) new GameObject("_SingleBehaviour_<" + typeof (T).ToString() + ">").AddComponent<T>();
			}
			return VQMMSingleton<T>._instance;
		}
	}
}
