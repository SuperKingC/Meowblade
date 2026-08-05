using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using RSG;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Interfaces;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Tips;

public class UI_LoadingPanel : GComponent, IUiController, IUiPanel, IAnyLoadingTotalListener, IAnyLoadingProgressListener
{
	private class waitStoryInfo
	{
		public bool hasChecked = false;

		public int waitingForLoadStoryCount = 0;

		public bool waitingForLoadStory = false;

		public string waitUIName = string.Empty;

		public waitStoryInfo()
		{
			hasChecked = false;
			waitUIName = string.Empty;
			waitingForLoadStoryCount = 12;
			waitingForLoadStory = true;
		}
	}

	public UI_LoadingBackground background;

	public GImage n9;

	public GRichTextField instructions;

	public GMovieClip anime;

	public GGraph soldierCarrierTest;

	public GImage wihteMask;

	public GGraph spineTest;

	public Transition showText;

	public Transition product;

	public Transition disappearText;

	public Transition ImageEnter;

	public Transition ImageExit;

	public Transition ImageExitReverse;

	public Transition disappearAnime;

	public const string URL = "ui://47lbpgx9ouqt18";

	public static string Name = "UI_LoadingPanel";

	private waitStoryInfo _waitStoryInfo;

	private float _minTime;

	private float _startTime;

	private bool isDisposeDone = false;

	private Coroutine _Coroutine_ShowSoldiersQueue;

	private Coroutine _Coroutine_ShowSoldiersRun;

	private bool _ended;

	private List<string> _soldiers = new List<string>();

	private float _soldierSpeed;

	private List<KeyValuePair<GGraph, KeyValuePair<float, float>>> SpineList = new List<KeyValuePair<GGraph, KeyValuePair<float, float>>>();

	private float _timeDifference;

	private float _canProduct;

	private int _productIndex;

	private List<float> RollYList = new List<float> { 980f, 990f, 1000f };

	private List<float> scaleList = new List<float> { 28f, 29f, 30f };

	private bool beenPlayed;

	public bool queueType;

	private LoadingAnimationDirection _directon;

	private int _total;

	private int _progress;

	private bool _hidePanel;

	public static string GetURL()
	{
		return "ui://47lbpgx9ouqt18";
	}

	public static UI_LoadingPanel CreateInstance()
	{
		return (UI_LoadingPanel)(object)UIPackage.CreateObject("Tips", "LoadingPanel");
	}

	public static UI_LoadingPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LoadingPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9ouqt18", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (UI_LoadingBackground)(object)((GComponent)this).GetChild("background");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		instructions = (GRichTextField)((GComponent)this).GetChild("instructions");
		anime = (GMovieClip)((GComponent)this).GetChild("anime");
		soldierCarrierTest = (GGraph)((GComponent)this).GetChild("soldierCarrierTest");
		wihteMask = (GImage)((GComponent)this).GetChild("wihteMask");
		spineTest = (GGraph)((GComponent)this).GetChild("spineTest");
		showText = ((GComponent)this).GetTransition("showText");
		product = ((GComponent)this).GetTransition("product");
		disappearText = ((GComponent)this).GetTransition("disappearText");
		ImageEnter = ((GComponent)this).GetTransition("ImageEnter");
		ImageExit = ((GComponent)this).GetTransition("ImageExit");
		ImageExitReverse = ((GComponent)this).GetTransition("ImageExitReverse");
		disappearAnime = ((GComponent)this).GetTransition("disappearAnime");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		_waitStoryInfo = new waitStoryInfo();
		CheckHasPlayingStoriesLine();
		GameController.Contexts.gameState.ReplaceLoadingPanel(this);
		_minTime = (float)parameters["MinTime"];
		_startTime = Time.realtimeSinceStartup;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		((GObject)this).sortingOrder = 120;
		((GObject)instructions).alpha = 0f;
		if (!parameters.ContainsKey("Background"))
		{
			Debug.LogWarning((object)"未包含背景图片");
			End();
			return;
		}
		if (parameters.ContainsKey("Instructions"))
		{
			((GObject)instructions).text = parameters["Instructions"].ToString();
			((GObject)instructions).sortingOrder = 1000;
		}
		else
		{
			parameters.TryGetValue("ContextTags", out var value);
			GetRandomTip((List<string>)value);
		}
		if (parameters.ContainsKey("QueueType"))
		{
			queueType = (bool)parameters["QueueType"];
		}
		if (parameters.ContainsKey("Direction"))
		{
			_directon = (LoadingAnimationDirection)parameters["Direction"];
		}
		_hidePanel = parameters.TryGetValue("Hide", out var value2) && (bool)value2;
		if (_directon == LoadingAnimationDirection.Right)
		{
			((GObject)anime).scaleX = 1f;
		}
		else if (_directon == LoadingAnimationDirection.Left)
		{
			((GObject)anime).scaleX = -1f;
		}
		ImageEnter.Play();
		ImageEnter.SetHook("showText", (TransitionHook)delegate
		{
			showText.Play();
		});
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener("LOAD_STORIES", OnLoadStories);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", OnUIOpened);
		SharedMessenger.AddListener<string, Dictionary<string, object>, TaskCompletionSource<bool>>("ACTION_OPEN_UI", OnActionOpenUI);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener("LOAD_STORIES", OnLoadStories);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", OnUIOpened);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>, TaskCompletionSource<bool>>("ACTION_OPEN_UI", OnActionOpenUI);
	}

	private void OnLoadStories()
	{
		List<string> playingStories = GameManagers.Instance.StoryManager.PlayingStories;
		if (playingStories.Count > 0)
		{
			_waitStoryInfo.hasChecked = true;
		}
	}

	private void CheckHasPlayingStoriesLine()
	{
		if (_waitStoryInfo.hasChecked)
		{
			return;
		}
		Dictionary<string, string> playingStoriesLine = GameManagers.Instance.StoryManager.PlayingStoriesLine;
		if (playingStoriesLine.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<string, string> item in playingStoriesLine)
		{
			GDEStoryData gDEStoryData = GDMgr.Get<GDEStoryData>(item.Value);
			if (gDEStoryData != null && !string.IsNullOrEmpty(gDEStoryData.Payload) && gDEStoryData.Payload.Contains("ACTION_OPEN_UI"))
			{
				_waitStoryInfo.hasChecked = true;
				break;
			}
		}
	}

	private void OnUIOpened(string uiId, Dictionary<string, object> parameters)
	{
		CheckHasPlayingStoriesLine();
		if (_waitStoryInfo.hasChecked && !(_waitStoryInfo.waitUIName != uiId))
		{
			_waitStoryInfo.waitingForLoadStory = false;
		}
	}

	private void OnActionOpenUI(string uiName, Dictionary<string, object> parameters, TaskCompletionSource<bool> taskCompletionSource)
	{
		CheckHasPlayingStoriesLine();
		if (_waitStoryInfo.hasChecked)
		{
			_waitStoryInfo.waitUIName = uiName;
			_waitStoryInfo.waitingForLoadStoryCount = 0;
		}
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		FGUIManager.Instance.CloseIEnumerator(_Coroutine_ShowSoldiersQueue);
		FGUIManager.Instance.CloseIEnumerator(_Coroutine_ShowSoldiersRun);
	}

	public void OnShow()
	{
		((GObject)this).alpha = (_hidePanel ? 0f : 1f);
	}

	public override void Dispose()
	{
		isDisposeDone = true;
		((GComponent)this).Dispose();
	}

	private bool NeedWaitStory()
	{
		return _waitStoryInfo != null && !string.IsNullOrEmpty(_waitStoryInfo.waitUIName) && _waitStoryInfo.waitingForLoadStory && _waitStoryInfo.waitingForLoadStoryCount > 0;
	}

	private bool NeedWaitRecover()
	{
		return GameController.Contexts.Service<IUiService>().IsRecoveringBackupUis();
	}

	private void WaitForLoadComplete()
	{
		if (NeedWaitStory())
		{
			_waitStoryInfo.waitingForLoadStoryCount--;
			if (_waitStoryInfo.waitingForLoadStoryCount <= 0)
			{
				_waitStoryInfo.waitingForLoadStory = false;
			}
		}
		bool flag = NeedWaitStory();
		bool flag2 = NeedWaitRecover();
		if (flag || flag2)
		{
			ScriptApi.CreateTimer(0.2f, WaitForLoadComplete);
		}
		else
		{
			_End();
		}
	}

	private void _End()
	{
		if (!_ended)
		{
			_ended = true;
			ScriptApi.CreateTimer(0.05f, ImageExitPlay);
			ScriptApi.CreateTimer(0.75f, End);
		}
	}

	public void End()
	{
		FGUIManager.Instance.CloseIEnumerator(_Coroutine_ShowSoldiersQueue);
		FGUIManager.Instance.CloseIEnumerator(_Coroutine_ShowSoldiersRun);
		for (int i = 0; i < SpineList.Count; i++)
		{
			((GObject)SpineList[i].Key).alpha = 0f;
			((GObject)SpineList[i].Key).Dispose();
			SpineList.RemoveAt(i);
		}
		if (!isDisposeDone)
		{
			((GObject)this).visible = false;
			GameController.Contexts.Service<IUiService>().ClosePanel(Name);
			UnregisterUiEventListeners();
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)((GObject)((GObject)this).parent).parent, true);
			SharedMessenger.Broadcast("CLOSE_UI", Name);
		}
	}

	public Promise LoadComplete()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		showText.Stop();
		Promise promise = new Promise();
		float num = Time.realtimeSinceStartup - _startTime;
		if (num < _minTime)
		{
			ScriptApi.CreateTimer(_minTime - num, delegate
			{
				InternalLoadComplete(promise);
			});
		}
		else
		{
			InternalLoadComplete(promise);
		}
		return promise;
	}

	private void InternalLoadComplete(Promise promise)
	{
		if (!isDisposeDone)
		{
			promise.Resolve();
			if (NeedWaitStory() || NeedWaitRecover())
			{
				WaitForLoadComplete();
			}
			else
			{
				_End();
			}
		}
	}

	private void ImageExitPlay()
	{
		if (!isDisposeDone)
		{
			disappearText.Play();
			disappearAnime.Play();
			if (_directon == LoadingAnimationDirection.Right)
			{
				ImageExit.Play();
			}
			else if (_directon == LoadingAnimationDirection.Left)
			{
				ImageExitReverse.Play();
			}
		}
	}

	private IEnumerator ShowSoldiersRun()
	{
		while (true)
		{
			for (int i = SpineList.Count - 1; i >= 0; i--)
			{
				KeyValuePair<GGraph, KeyValuePair<float, float>> soldierSpine = SpineList[i];
				if (_directon == LoadingAnimationDirection.Right)
				{
					if (((GObject)soldierSpine.Key).x <= ((GObject)GRoot.inst).width + soldierSpine.Value.Key / 2f)
					{
						((GObject)soldierSpine.Key).SetXY(((GObject)soldierSpine.Key).x + 0.03f * soldierSpine.Value.Value, ((GObject)soldierSpine.Key).y);
					}
					else
					{
						((GObject)soldierSpine.Key).alpha = 0f;
						((GObject)soldierSpine.Key).Dispose();
						SpineList.RemoveAt(i);
					}
				}
				else if (_directon == LoadingAnimationDirection.Left)
				{
					if (((GObject)soldierSpine.Key).x >= (0f - soldierSpine.Value.Key) / 2f)
					{
						((GObject)soldierSpine.Key).SetXY(((GObject)soldierSpine.Key).x - 0.03f * soldierSpine.Value.Value, ((GObject)soldierSpine.Key).y);
					}
					else
					{
						((GObject)soldierSpine.Key).alpha = 0f;
						((GObject)soldierSpine.Key).Dispose();
						SpineList.RemoveAt(i);
					}
				}
			}
			yield return null;
		}
	}

	private void GetRandomTip(List<string> contextTags = null)
	{
		List<GDETipData> list = GDMgr.GetAllItems<GDETipData>().ToList();
		((GObject)instructions).text = list[GameManagers.Instance.RandomManager.Int(list.Count)].Content;
	}

	public void OnAnyLoadingProgress(GameStateEntity entity, int value)
	{
		_progress = Math.Min(value, _total);
	}

	public void OnAnyLoadingTotal(GameStateEntity entity, int value)
	{
		_total = value;
	}
}
