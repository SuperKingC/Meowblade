using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	private static object _lock = new object();

	private static bool _applicationIsQuitting = false;

	public static T Instance
	{
		get
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			if ((Object)(object)_instance != (Object)null)
			{
				return _instance;
			}
			GameObject val = new GameObject();
			val.AddComponent<T>();
			((Object)val).name = "(singleton) " + typeof(T).ToString();
			_instance = val.GetComponent<T>();
			return _instance;
		}
	}

	private void Awake()
	{
		if ((Object)(object)Instance == (Object)(object)this)
		{
			Object.DontDestroyOnLoad((Object)(object)((Component)((Component)this).transform).gameObject);
			InitInstance();
		}
		else
		{
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
	}

	public virtual void OnDestroy()
	{
		if ((Object)(object)_instance == (Object)(object)this)
		{
			_applicationIsQuitting = true;
		}
	}

	public virtual void InitInstance()
	{
	}

	public virtual void RecreateInstance()
	{
		Object.Destroy((Object)(object)((Component)(object)Instance).gameObject);
		_instance = default(T);
	}
}
