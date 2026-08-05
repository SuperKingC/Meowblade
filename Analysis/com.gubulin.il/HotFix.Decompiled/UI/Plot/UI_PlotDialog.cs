using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Plot;

public class UI_PlotDialog : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static PlayCompleteCallback _003C_003E9__55_0;

		internal void _003CUpdateDialog_003Eb__55_0()
		{
		}
	}

	public GGraph mask;

	public GLoader titleImage;

	public GLoader NPCR;

	public GImage backgroundR;

	public GRichTextField nameR;

	public GGroup NpcNameRight;

	public GImage n29;

	public GLoader NPCL;

	public GGraph backgroundL;

	public GRichTextField nameL;

	public GGroup NpcNameLeft;

	public UI_clickarea clickarea;

	public UI_skip1 skip;

	public GGroup TipGroup;

	public UI_PlotNpc PlotNpc;

	public GGroup mainGroup;

	public Transition ShowSkipBtn;

	public Transition showUp;

	public Transition showNpc;

	public const string URL = "ui://56axd6he8h2b9";

	public static string Name = "UI_PlotDialog";

	private int curStep;

	private bool isShaking;

	private List<Dictionary<string, object>> plotList;

	private int typingAt;

	private string conversationCache;

	private bool isAnimating;

	private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

	private float InitDialogX;

	private float InitDialogY;

	private float InitDialogDeltaWidth;

	private GTweener _titleImageTween;

	private CustomTaskCompletionSource<bool> callback = null;

	private List<string> textureList = new List<string>();

	public static string GetURL()
	{
		return "ui://56axd6he8h2b9";
	}

	public static UI_PlotDialog CreateInstance()
	{
		return (UI_PlotDialog)(object)UIPackage.CreateObject("Plot", "PlotDialog");
	}

	public static UI_PlotDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlotDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56axd6he8h2b9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		titleImage = (GLoader)((GComponent)this).GetChild("titleImage");
		NPCR = (GLoader)((GComponent)this).GetChild("NPCR");
		backgroundR = (GImage)((GComponent)this).GetChild("backgroundR");
		nameR = (GRichTextField)((GComponent)this).GetChild("nameR");
		string id = "ui://56axd6he8h2b9".Replace("ui://", "") + "-" + ((GObject)nameR).id;
		((GObject)nameR).text = LanguagesManager.GetDesc(id);
		NpcNameRight = (GGroup)((GComponent)this).GetChild("NpcNameRight");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		NPCL = (GLoader)((GComponent)this).GetChild("NPCL");
		backgroundL = (GGraph)((GComponent)this).GetChild("backgroundL");
		nameL = (GRichTextField)((GComponent)this).GetChild("nameL");
		string id2 = "ui://56axd6he8h2b9".Replace("ui://", "") + "-" + ((GObject)nameL).id;
		((GObject)nameL).text = LanguagesManager.GetDesc(id2);
		NpcNameLeft = (GGroup)((GComponent)this).GetChild("NpcNameLeft");
		clickarea = (UI_clickarea)(object)((GComponent)this).GetChild("clickarea");
		skip = (UI_skip1)(object)((GComponent)this).GetChild("skip");
		TipGroup = (GGroup)((GComponent)this).GetChild("TipGroup");
		PlotNpc = (UI_PlotNpc)(object)((GComponent)this).GetChild("PlotNpc");
		mainGroup = (GGroup)((GComponent)this).GetChild("mainGroup");
		ShowSkipBtn = ((GComponent)this).GetTransition("ShowSkipBtn");
		showUp = ((GComponent)this).GetTransition("showUp");
		showNpc = ((GComponent)this).GetTransition("showNpc");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)clickarea).onClick.Add(new EventCallback1(FireClickOnMask));
		((GObject)mask).onClick.Add(new EventCallback0(NextStep));
		((GObject)skip).onClick.Add(new EventCallback0(SkipEvent));
		SharedMessenger.AddListener<bool>("APP_PAUSE", OnApplicationPause);
		SharedMessenger.AddListener<bool>("APP_FOCUS", OnApplicationFocus);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)clickarea).onClick.Remove(new EventCallback1(FireClickOnMask));
		((GObject)mask).onClick.Remove(new EventCallback0(NextStep));
		((GObject)skip).onClick.Remove(new EventCallback0(SkipEvent));
		SharedMessenger.RemoveListener<bool>("APP_PAUSE", OnApplicationPause);
		SharedMessenger.RemoveListener<bool>("APP_FOCUS", OnApplicationFocus);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		InitDialogDeltaWidth = ((GObject)clickarea).width - ((GObject)clickarea.dialogue).width;
		InitDialogX = ((GObject)clickarea.dialogue).x;
		InitDialogY = ((GObject)clickarea.dialogue).y;
		((GObject)mask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		((GComponent)skip).GetChild("title").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		((GObject)skip).visible = false;
		((GObject)clickarea).visible = false;
		((GObject)NpcNameRight).visible = false;
		((GObject)PlotNpc).visible = false;
		mask.shape.color = new Color(0f, 0f, 0f);
		((DisplayObject)mask.shape).alpha = 0.5f;
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("PlotPanel", skip);
		curStep = 0;
		plotList = new List<Dictionary<string, object>>();
		if (parameters.TryGetValue("StoryScripts", out var value))
		{
			plotList = (List<Dictionary<string, object>>)value;
		}
		else
		{
			Debug.LogError((object)"未包含StoryScripts");
			End();
		}
		if (parameters.TryGetValue("taskCompletionSource", out var value2))
		{
			callback = value2 as CustomTaskCompletionSource<bool>;
			if (callback.CanSkip)
			{
				((GObject)skip).visible = true;
			}
		}
		UpdatePanel(curStep);
		((GObject)this).sortingOrder = 100;
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("PlotPanel", skip);
	}

	private void NextStep()
	{
		if (!isShaking)
		{
			((GButton)clickarea).selected = true;
			curStep++;
			if (curStep >= plotList.Count)
			{
				End();
			}
			else
			{
				UpdatePanel(curStep);
			}
		}
	}

	private void FireClickOnMask(EventContext e)
	{
		try
		{
			((EventDispatcher)mask).BubbleEvent(e.type, (object)null);
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError(ex.Message);
		}
	}

	private void CancelConversationAnimation()
	{
		cancellationTokenSource.Cancel(throwOnFirstException: false);
		isAnimating = false;
		if (!string.IsNullOrEmpty(conversationCache))
		{
			((GObject)clickarea.dialogue).text = conversationCache;
			((GObject)clickarea).alpha = 1f;
		}
	}

	private void OnApplicationPause(bool isPause)
	{
		CancelConversationAnimation();
	}

	private void OnApplicationFocus(bool isFocus)
	{
		CancelConversationAnimation();
	}

	private void SkipEvent()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object> { { "Parent", this } };
		if (callback != null)
		{
			callback.Skip = true;
			callback.TrySetResult(result: true);
		}
		End();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		Time.timeScale = 1f;
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	public void UpdatePanel(int index)
	{
		if (index >= plotList.Count)
		{
			Debug.LogWarning((object)"未设置剧情列表");
			End();
			return;
		}
		Dictionary<string, object> dictionary = plotList[index];
		if (!dictionary.TryGetValue("Type", out var value))
		{
			return;
		}
		object obj = value;
		object obj2 = obj;
		switch (obj2 as string)
		{
		case "Dialog":
			UpdateDialog(dictionary);
			break;
		case "Background":
			UpdateBackground(dictionary);
			UpdatePanel(++curStep);
			break;
		case "SwitchScene":
		{
			if (dictionary.TryGetValue("Scene", out var value3))
			{
				SwitchToScene(value3.ToString(), delegate
				{
					UpdatePanel(++curStep);
				});
			}
			else
			{
				UpdatePanel(++curStep);
			}
			break;
		}
		case "ClearDialog":
			ClearDialog();
			UpdatePanel(++curStep);
			break;
		case "Waiting":
		{
			if (dictionary.TryGetValue("Timeout", out var value2))
			{
				ScriptApi.CreateTimer(NumericParser.Float(value2.ToString()), delegate
				{
					UpdatePanel(++curStep);
				});
			}
			break;
		}
		default:
			UpdatePanel(++curStep);
			break;
		}
	}

	private async void TypeWord(string content)
	{
		if (cancellationTokenSource.IsCancellationRequested)
		{
			cancellationTokenSource = new CancellationTokenSource();
		}
		typingAt = 0;
		isAnimating = true;
		((GObject)clickarea.dialogue).text = "";
		foreach (char character in content)
		{
			GRichTextField dialogue = clickarea.dialogue;
			((GObject)dialogue).text = ((GObject)dialogue).text + character;
			typingAt++;
			if (cancellationTokenSource.IsCancellationRequested || !isAnimating)
			{
				break;
			}
			await Task.Delay(30, cancellationTokenSource.Token);
		}
		isAnimating = false;
		cancellationTokenSource.Cancel(throwOnFirstException: false);
		if (typingAt < content.Length)
		{
			GRichTextField dialogue2 = clickarea.dialogue;
			((GObject)dialogue2).text = ((GObject)dialogue2).text + content.Substring(typingAt);
		}
	}

	private void FadeInConversation()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		isAnimating = true;
		((GObject)clickarea).alpha = 0f;
		GTween.To(0f, 1f, 0.6f).SetTarget((object)clickarea).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
		{
			if (isAnimating)
			{
				((GObject)clickarea).alpha = tweener.value.x;
			}
			else
			{
				tweener.Kill(true);
			}
		})
			.OnComplete((GTweenCallback1)delegate(GTweener tweener)
			{
				((GObject)clickarea).alpha = 1f;
				isAnimating = false;
				tweener.Kill(false);
			});
	}

	private void ShakeConversation()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		isShaking = true;
		GTween.Shake(((GObject)clickarea).position, 16f, 0.4f).SetTarget((object)clickarea).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			((GObject)clickarea).position = new Vector3(tweener.value.x, tweener.value.y, ((GObject)clickarea).position.z);
		})
			.OnComplete((GTweenCallback)delegate
			{
				isShaking = false;
			});
	}

	private void UpdateDialog(Dictionary<string, object> scriptLine)
	{
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		scriptLine.TryGetValue("Effects", out var value);
		scriptLine.TryGetValue("Content", out var value2);
		((GObject)clickarea).visible = value2 != null;
		conversationCache = value2?.ToString() ?? "";
		GRichTextField val = PlotNpc.nameL;
		object value3;
		bool flag = scriptLine.TryGetValue("LeftAvatar", out value3);
		bool flag2 = value != null && ((List<string>)value).Contains("AlignCenter");
		if (flag)
		{
			PlotNpc.NPCL.url = "ui://PublicResources/" + value3.ToString();
			((DisplayObject)PlotNpc.NPCL.image).graphics.flip = (FlipType)1;
			((GObject)clickarea.background).size = new Vector2(((GObject)clickarea).width, ((GObject)clickarea).height);
			clickarea.background.url = "ui://56axd6hevrbpf";
			((GObject)clickarea.title).visible = true;
			((GObject)clickarea).width = 1010f;
			((GTextField)clickarea.dialogue).align = (AlignType)0;
			((GTextField)clickarea.dialogue).color = Color32.op_Implicit(new Color32((byte)80, (byte)40, (byte)10, byte.MaxValue));
			((GTextField)clickarea.dialogue).autoSize = (AutoSizeType)2;
			((GTextField)clickarea.dialogue).verticalAlign = (VertAlignType)0;
			((GObject)clickarea.dialogue).width = ((GObject)clickarea).width - InitDialogDeltaWidth;
			((GObject)clickarea.dialogue).SetXY(InitDialogX, InitDialogY);
			if (flag2)
			{
				((GObject)TipGroup).SetXY((1920f - ((GObject)mainGroup).width) / 2f + (((GObject)mainGroup).width - ((GObject)TipGroup).width), 383f);
			}
			else
			{
				((GObject)TipGroup).SetXY((1920f - ((GObject)mainGroup).width) / 2f + (((GObject)mainGroup).width - ((GObject)TipGroup).width), (1080f - ((GObject)TipGroup).height) / 2f + ((GObject)TipGroup).height + 30f);
			}
			if (!((GObject)PlotNpc).visible)
			{
				((GObject)PlotNpc).alpha = 0f;
				((GObject)clickarea).SetScale(0f, 0f);
				((GObject)PlotNpc).visible = true;
				Transition obj = showUp;
				object obj2 = _003C_003Ec._003C_003E9__55_0;
				if (obj2 == null)
				{
					PlayCompleteCallback val2 = delegate
					{
					};
					_003C_003Ec._003C_003E9__55_0 = val2;
					obj2 = (object)val2;
				}
				obj.Play(1, 0.1f, (PlayCompleteCallback)obj2);
			}
			showNpc.Play();
			((GObject)clickarea.dialogue).text = conversationCache;
		}
		else
		{
			((GObject)PlotNpc).visible = false;
			((GObject)clickarea.background).size = new Vector2(((GObject)GRoot.inst).width, 971f);
			bool flag3 = ((DisplayObject)mask.shape).alpha > 0.9f;
			clickarea.background.url = (flag3 ? string.Empty : "ui://56axd6heqtmod");
			((GObject)clickarea.title).visible = false;
			((GObject)clickarea).width = ((GObject)GRoot.inst).width;
			((GObject)clickarea.dialogue).text = conversationCache;
			((GTextField)clickarea.dialogue).color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
			((GTextField)clickarea.dialogue).autoSize = (AutoSizeType)2;
			((GObject)clickarea.dialogue).width = ((GObject)GRoot.inst).width;
			((GTextField)clickarea.dialogue).verticalAlign = (VertAlignType)1;
			((GTextField)clickarea.dialogue).align = (AlignType)1;
			float num = ((!flag2) ? (1080f - ((GObject)TipGroup).height + 50f) : ((1080f - ((GObject)TipGroup).height) / 2f));
			if (value != null && ((List<string>)value).Contains("LordAppear"))
			{
				FGUIManager.Instance.PlayTimeLine("LordAppear");
			}
			((GObject)TipGroup).SetXY((1920f - ((GObject)TipGroup).width) / 2f, num);
			FadeInConversation();
			((GObject)clickarea.dialogue).SetXY((((GObject)clickarea).width - ((GObject)clickarea.dialogue).width) / 2f, (((GObject)clickarea).height - ((GObject)clickarea.dialogue).height) / 2f);
		}
		if (value != null && ((List<string>)value).Contains("BackHidden"))
		{
			clickarea.background.url = "";
		}
		if (scriptLine.TryGetValue("RightAvatar", out var value4))
		{
			NPCR.url = "ui://PublicResources/" + value4.ToString();
			val = nameR;
			((GObject)NpcNameRight).visible = true;
		}
		else
		{
			((GObject)NpcNameRight).visible = false;
		}
		if (value != null)
		{
			List<string> list = (List<string>)value;
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				if (list[num2].Contains("SetYValue"))
				{
					string value5 = list[num2].Split(':')[1];
					((GObject)clickarea).y = Convert.ToInt32(value5);
					break;
				}
			}
		}
		if (scriptLine.TryGetValue("Name", out var value6))
		{
			((GObject)val).text = value6.ToString();
		}
		if (value != null)
		{
			List<string> list2 = (List<string>)value;
			if (list2.Contains("Shake"))
			{
				ShakeConversation();
			}
			if (list2.Contains("Ha"))
			{
				UiAudioManager.Instance.PlaySoundEffect("Ha");
			}
			if (list2.Contains("Oh"))
			{
				UiAudioManager.Instance.PlaySoundEffect("Oh");
			}
		}
	}

	private void ClearDialog()
	{
		((GObject)clickarea).visible = false;
		((GObject)NpcNameRight).visible = false;
		((GObject)PlotNpc).visible = false;
	}

	private void UpdateBackground(Dictionary<string, object> scriptLine)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		if (scriptLine.TryGetValue("Opacity", out var value))
		{
			((DisplayObject)mask.shape).alpha = NumericParser.Float(value.ToString());
		}
		GTweener titleImageTween = _titleImageTween;
		if (titleImageTween != null)
		{
			titleImageTween.Kill(false);
		}
		((GObject)titleImage).alpha = 0f;
		if (scriptLine.TryGetValue("Image", out var value2))
		{
			titleImage.url = $"ui://Plot/{value2}";
			_titleImageTween = ((GObject)titleImage).TweenFade(1f, 0.6f).SetEase((EaseType)0);
			_titleImageTween.OnComplete((GTweenCallback)delegate
			{
				_titleImageTween = null;
			});
		}
	}

	private void SwitchToScene(string scene, Action callback)
	{
		switch (scene)
		{
		case "BattleField":
			CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
			{
				{
					"LevelId",
					GameManagers.Instance.UserArchiveManager.GetCurrentLevelId()
				},
				{ "Asset", "Prefabs/BattleField" },
				{ "ForceCloseOtherUi", false },
				{ "TaskCompletionSource", null }
			}));
			break;
		case "MainCity.Left":
			CommandFactory.CreateOpenSceneCommand(scene, new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				}
			}));
			break;
		case "MainCity.Right":
			CommandFactory.CreateOpenSceneCommand(scene, new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				}
			}));
			break;
		}
		ScriptApi.CreateTimer(GameController.Contexts.input.fixedDeltaTime.value * 3f, callback);
	}
}
