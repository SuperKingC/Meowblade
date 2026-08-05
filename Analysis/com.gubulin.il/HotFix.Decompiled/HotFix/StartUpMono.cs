using System;
using System.Collections;
using System.Collections.Generic;
using Shift.Legion.ClientApi;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HotFix;

public class StartUpMono : MonoBehaviour
{
	public enum eSceneName
	{
		Load,
		Update,
		Game
	}

	public static StartUpMono Instance;

	public List<Type> InitList_Step_Load;

	public List<Type> InitList_Step_Update;

	public List<Type> InitList_Step_Game;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		InitList_Step_Load = new List<Type> { typeof(VersionManager) };
		InitList_Step_Update = new List<Type>
		{
			typeof(UnityUiService),
			typeof(UiAudioManager)
		};
		InitList_Step_Game = new List<Type>
		{
			typeof(TopUiCanvas),
			typeof(FGUIManager),
			typeof(GameController),
			typeof(SpawnManager),
			typeof(GameDataService),
			typeof(ThinkingDataHelper),
			typeof(CaptureScreenshotManager),
			typeof(UnityRequestHelper),
			typeof(SentryController),
			typeof(QuickPlayReplayService)
		};
		((MonoBehaviour)this).StartCoroutine(RealStart());
	}

	private IEnumerator RealStart()
	{
		yield return (object)new WaitForEndOfFrame();
		Init(InitList_Step_Load);
		((Component)Instance).gameObject.AddComponent<LoadController>();
	}

	public static void Init(List<Type> list)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		for (int i = 0; i < list.Count; i++)
		{
			Type type = list[i];
			GameObject val = GameObject.Find(type.FullName);
			if ((Object)(object)val == (Object)null)
			{
				val = new GameObject();
				((Object)val).name = type.FullName;
				val.AddComponent(type);
				Object.DontDestroyOnLoad((Object)(object)val);
			}
			else if ((Object)(object)val.GetComponent(type) == (Object)null)
			{
				val.AddComponent(type);
				Object.DontDestroyOnLoad((Object)(object)val);
			}
		}
	}

	public static void Init_LoadScene(Scene scene, LoadSceneMode mode)
	{
		Init(Instance.InitList_Step_Load);
		((Component)Instance).gameObject.AddComponent<LoadController>();
	}

	public static void Init_UpdateScene(Scene scene, LoadSceneMode mode)
	{
		Init(Instance.InitList_Step_Update);
		((Component)Instance).gameObject.AddComponent<UpdateController>();
		SceneManager.sceneLoaded -= Init_UpdateScene;
	}

	public static void Init_GameScene(Scene scene, LoadSceneMode mode)
	{
		Init(Instance.InitList_Step_Game);
		SceneManager.sceneLoaded -= Init_GameScene;
	}

	public static void LoadScene(eSceneName _name)
	{
		switch (_name)
		{
		case eSceneName.Load:
			SceneManager.sceneLoaded += Init_LoadScene;
			SceneManager.LoadScene("Load");
			break;
		case eSceneName.Update:
			SceneManager.sceneLoaded += Init_UpdateScene;
			SceneManager.LoadScene("Update");
			break;
		case eSceneName.Game:
			SceneManager.sceneLoaded += Init_GameScene;
			SceneManager.LoadScene("Game");
			break;
		}
	}

	public Coroutine MakeCoroutine(IEnumerator _ienumerator)
	{
		return ((MonoBehaviour)this).StartCoroutine(_ienumerator);
	}

	public Coroutine CreateTimer(Action _action, float tm, int cnt = 1)
	{
		return ((MonoBehaviour)this).StartCoroutine(DoTimer(_action, tm, cnt));
	}

	public void StopCoroutineTimer(Coroutine timer)
	{
		((MonoBehaviour)this).StopCoroutine(timer);
	}

	private IEnumerator DoTimer(Action _action, float tm, int cnt)
	{
		if (cnt == -1)
		{
			while (true)
			{
				_action?.Invoke();
				yield return (object)new WaitForSeconds(tm);
			}
		}
		for (int i = 0; i < cnt; i++)
		{
			_action?.Invoke();
			yield return (object)new WaitForSeconds(tm);
		}
	}
}
