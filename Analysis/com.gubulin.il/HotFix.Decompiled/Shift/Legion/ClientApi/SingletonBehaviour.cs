using UnityEngine;

namespace Shift.Legion.ClientApi;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	private static object _lock = new object();

	private static bool _applicationIsQuitting = false;

	public static T Instance
	{
		get
		{
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			if (_applicationIsQuitting)
			{
				return default(T);
			}
			lock (_lock)
			{
				if ((Object)(object)_instance != (Object)null)
				{
					return _instance;
				}
				_instance = (T)(object)Object.FindObjectOfType(typeof(T));
				if (Object.FindObjectsOfType(typeof(T)).Length > 1)
				{
					Debug.LogError((object)"[Singleton] Something went really wrong  - there should never be more than 1 singleton! Reopening the scene might fix it.");
					return _instance;
				}
				if ((Object)(object)_instance != (Object)null)
				{
					return _instance;
				}
				GameObject val = new GameObject();
				_instance = val.AddComponent<T>();
				((Object)val).name = "(singleton) " + typeof(T).ToString();
				return _instance;
			}
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
