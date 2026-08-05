using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameMaths;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Battle;
using UI.BlackMarketer;
using UI.Tips;
using UnityEngine;

namespace UI.Guide;

public class UI_Guide : GComponent, IUiController
{
	public GGraph mask;

	public GGraph dibble;

	public UI_Finger Finger;

	public UI_skip2 SkipBtn;

	public GGraph clickMask;

	public Transition breathe;

	public const string URL = "ui://5vxjvcrbqy8of";

	public static string Name = "UI_Guide";

	private const float HIGHLIGHT_TRANSFORM_TOLERANCE = 0.0001f;

	private Vector2 skipPosSave;

	private Dictionary<string, object> guideData = new Dictionary<string, object>();

	private Vector2 _offsetPos;

	private Vector2 _offsetSize;

	private readonly List<Vector2> highlightTransformList = new List<Vector2>
	{
		new Vector2
		{
			x = 0f,
			y = 0f
		},
		new Vector2
		{
			x = 0f,
			y = 0f
		}
	};

	private UI_npc npc;

	private UI_tips tips;

	private UI_FrameBorder frameBorder;

	private UI_Finger fingerArrow;

	private string npcName;

	private List<string> targetData = new List<string>();

	private Transition curArrowAnimation;

	private bool hiddendibble;

	private bool showFinger;

	private Vector2 fingerPos = Vector2.zero;

	private bool hideAllGuideUi;

	private float maskAlpha;

	private CustomTaskCompletionSource<bool> callback = null;

	private IGuidePrompt _prompt;

	private GameStateEntity _gameStateEntity;

	private float findingTime = 0f;

	private Coroutine findingCoroutine;

	private bool canClick;

	private bool _findSoldierUpgradeSuccessSkillFrame;

	private GGraph clickComponent
	{
		get
		{
			if (!hiddendibble)
			{
				return dibble;
			}
			return clickMask;
		}
	}

	public static string GetURL()
	{
		return "ui://5vxjvcrbqy8of";
	}

	public static UI_Guide CreateInstance()
	{
		return (UI_Guide)(object)UIPackage.CreateObject("Guide", "Guide");
	}

	public static UI_Guide CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Guide).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbqy8of", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		dibble = (GGraph)((GComponent)this).GetChild("dibble");
		Finger = (UI_Finger)(object)((GComponent)this).GetChild("Finger");
		SkipBtn = (UI_skip2)(object)((GComponent)this).GetChild("SkipBtn");
		clickMask = (GGraph)((GComponent)this).GetChild("clickMask");
		breathe = ((GComponent)this).GetTransition("breathe");
	}

	private void SkipClick()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		skipPosSave = ((GObject)clickComponent).size;
		((GObject)clickComponent).SetSize(0f, 0f);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Parent", this);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkipPanel.Name, dictionary);
	}

	public void YesSkip()
	{
		ILRequestHelper<SkipCurrentStoryResponse>.Request((EventContext)null, (Func<Task<SkipCurrentStoryResponse>>)(() => GameController.Contexts.Service<INetworkService>().SkipCurrentStory(-1L, Name)), (Action<SkipCurrentStoryResponse>)delegate(SkipCurrentStoryResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers.Instance.StoryManager.Skip(Name);
			}
		});
	}

	public void NoSkip()
	{
		((GObject)clickComponent).SetSize(skipPosSave.x, skipPosSave.y);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		if (Math.Abs(Time.timeScale) < float.Epsilon)
		{
			Time.timeScale = 1f;
		}
		if (!string.IsNullOrWhiteSpace(npcName))
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(npcName);
		}
	}

	public void UpdateLayout()
	{
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Unknown result type (might be due to invalid IL or missing references)
		//IL_0622: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_063a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0721: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d0: Unknown result type (might be due to invalid IL or missing references)
		if (npc == null && guideData.ContainsKey("Guider") && ((Dictionary<string, string>)guideData["Guider"]).ContainsKey("Image") && !string.IsNullOrEmpty(((Dictionary<string, string>)guideData["Guider"])["Image"]) && ((Dictionary<string, string>)guideData["Guider"]).ContainsKey("X") && !string.IsNullOrEmpty(((Dictionary<string, string>)guideData["Guider"])["X"]) && ((Dictionary<string, string>)guideData["Guider"]).ContainsKey("Y") && !string.IsNullOrEmpty(((Dictionary<string, string>)guideData["Guider"])["Y"]) && ((Dictionary<string, string>)guideData["Guider"]).ContainsKey("Width") && !string.IsNullOrEmpty(((Dictionary<string, string>)guideData["Guider"])["Width"]) && ((Dictionary<string, string>)guideData["Guider"]).ContainsKey("Height") && !string.IsNullOrEmpty(((Dictionary<string, string>)guideData["Guider"])["Height"]))
		{
			npc = UI_npc.CreateInstance();
			((GObject)npc).sortingOrder = 109;
			Dictionary<string, string> dictionary = (Dictionary<string, string>)guideData["Guider"];
			npcName = dictionary["Image"];
			npc.avatar.url = "ui://PublicResources/" + npcName;
			if (dictionary.ContainsKey("Name") && !string.IsNullOrEmpty(dictionary["Name"]))
			{
				((GObject)npc.nickName).text = dictionary["Name"];
			}
			Vector2 val = FGUIManager.Instance.StageAmendXY(new Vector2(NumericParser.Float(dictionary["X"]), NumericParser.Float(dictionary["Y"])));
			((GObject)npc).SetXY(val.x, val.y);
			((GObject)npc).SetSize(NumericParser.Float(dictionary["Width"]), NumericParser.Float(dictionary["Height"]));
			((GComponent)GRoot.inst).AddChild((GObject)(object)npc);
		}
		if (tips == null && guideData.ContainsKey("Tip") && ((Dictionary<string, string>)guideData["Tip"]).ContainsKey("Content") && !string.IsNullOrEmpty(((Dictionary<string, string>)guideData["Tip"])["Content"]) && ((Dictionary<string, string>)guideData["Tip"]).ContainsKey("X") && !string.IsNullOrEmpty(((Dictionary<string, string>)guideData["Tip"])["X"]) && ((Dictionary<string, string>)guideData["Tip"]).ContainsKey("Y") && !string.IsNullOrEmpty(((Dictionary<string, string>)guideData["Tip"])["Y"]) && ((Dictionary<string, string>)guideData["Tip"]).ContainsKey("Width") && !string.IsNullOrEmpty(((Dictionary<string, string>)guideData["Tip"])["Width"]) && ((Dictionary<string, string>)guideData["Tip"]).ContainsKey("Height") && !string.IsNullOrEmpty(((Dictionary<string, string>)guideData["Tip"])["Height"]))
		{
			tips = UI_tips.CreateInstance();
			((GObject)tips).SetScale(0f, 0f);
			((GObject)tips).sortingOrder = 108;
			((GObject)tips.skip).onClick.Add(new EventCallback0(SkipClick));
			Dictionary<string, string> dictionary2 = (Dictionary<string, string>)guideData["Tip"];
			((GObject)tips.content).text = dictionary2["Content"];
			((GObject)tips).SetSize(NumericParser.Float(dictionary2["Width"]), NumericParser.Float(dictionary2["Height"]));
			Vector2 val2 = FGUIManager.Instance.StageAmendXY(new Vector2(NumericParser.Float(dictionary2["X"]) - ((GObject)tips).width / 2f, NumericParser.Float(dictionary2["Y"]) + ((GObject)tips).height / 2f));
			((GComponent)GRoot.inst).AddChild((GObject)(object)tips);
			((GObject)tips).SetXY(val2.x, val2.y);
		}
		Vector2 val3 = highlightTransformList[0] + _offsetPos;
		Vector2 val4 = highlightTransformList[1] + _offsetSize;
		((GObject)clickComponent).SetSize(val4.x, val4.y);
		((GObject)clickComponent).SetXY(val3.x, val3.y);
		if (!(((GObject)clickComponent).size.x > 0f) || !(((GObject)clickComponent).size.y > 0f) || hideAllGuideUi)
		{
			return;
		}
		if (hiddendibble)
		{
			((GObject)Finger).alpha = 1f;
			((GObject)Finger).SetXY(((GObject)clickComponent).x, ((GObject)clickComponent).y);
			return;
		}
		if (frameBorder == null)
		{
			frameBorder = UI_FrameBorder.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)frameBorder);
		}
		((GObject)frameBorder).sortingOrder = 2011;
		((GObject)frameBorder).SetSize(val4.x, val4.y);
		((GObject)frameBorder).SetXY(val3.x, val3.y);
		if (showFinger && fingerArrow == null)
		{
			fingerArrow = UI_Finger.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)fingerArrow);
			((GObject)fingerArrow).sortingOrder = 2011;
			((GObject)fingerArrow).SetSize(230f, 230f);
			((GObject)fingerArrow).SetPivot(0.5f, 0.5f, true);
			((GObject)fingerArrow).touchable = false;
			if (fingerPos != Vector2.zero)
			{
				((GObject)fingerArrow).xy = fingerPos;
			}
			else
			{
				((GObject)fingerArrow).SetXY(((GObject)clickComponent).x, ((GObject)clickComponent).y);
			}
		}
		else
		{
			Transition obj = curArrowAnimation;
			if (obj != null)
			{
				obj.Stop();
			}
			curArrowAnimation = _prompt.PlayTransition(clickComponent);
		}
	}

	private void UpdateHighlightTransform(Vector2 _pos, Vector2 _size)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		highlightTransformList[0] = _pos;
		highlightTransformList[1] = _size;
		UpdateLayout();
	}

	public void Find_FGUI_Control(GObject aim1)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		if (((aim1 == null) ? null : ((object)aim1.parent)?.GetType()) == typeof(GList))
		{
			GList val = (GList)aim1.parent;
			int childIndex = ((GComponent)val).GetChildIndex(aim1);
			val.ScrollToView(val.ChildIndexToItemIndex(childIndex));
		}
		else
		{
			object obj;
			if (aim1 == null)
			{
				obj = null;
			}
			else
			{
				GComponent parent = aim1.parent;
				obj = ((parent != null) ? ((GObject)parent).parent : null);
			}
			if (obj != null && ((object)((GObject)aim1.parent).parent).GetType() == typeof(GList))
			{
				GList val2 = (GList)((GObject)aim1.parent).parent;
				int childIndex2 = ((GComponent)val2).GetChildIndex((GObject)(object)aim1.parent);
				val2.ScrollToView(val2.ChildIndexToItemIndex(childIndex2));
			}
		}
		Vector2 gObjectPositionOnGRoot = UiHelper.GetGObjectPositionOnGRoot(aim1, new Vector2(aim1.width / 2f, aim1.height / 2f));
		Vector2 val3 = default(Vector2);
		((Vector2)(ref val3))._002Ector(aim1.size.x + 20f, aim1.size.y + 20f);
		if (aim1 is UI_FormationItemBtn)
		{
			((Vector2)(ref val3))._002Ector(330f, 240f);
		}
		Vector2 val4 = gObjectPositionOnGRoot - highlightTransformList[0];
		if (!(((Vector2)(ref val4)).magnitude > 0.0001f))
		{
			val4 = val3 - highlightTransformList[1];
			if (!(((Vector2)(ref val4)).magnitude > 0.0001f))
			{
				return;
			}
		}
		UpdateHighlightTransform(gObjectPositionOnGRoot, val3);
	}

	public void Find_FGUI_GameObject(GameObject aim1)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		BoxCollider componentInChildren = aim1.GetComponentInChildren<BoxCollider>();
		float num = componentInChildren.size.x * aim1.transform.lossyScale.x * 100f;
		float num2 = componentInChildren.size.y * ((Component)componentInChildren).transform.lossyScale.y * 100f;
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(num, num2);
		Vector3 val2 = aim1.transform.TransformPoint(componentInChildren.center);
		Vector2 val3 = Vector2.op_Implicit(GameController.Contexts.Service<ICameraService>().WorldToScreenPoint(Vector3.op_Implicit(val2)));
		val3.y = (float)Screen.height - val3.y;
		Vector2 val4 = ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val3));
		Vector2 val5 = val4 - highlightTransformList[0];
		if (!(((Vector2)(ref val5)).magnitude > 0.0001f))
		{
			val5 = val - highlightTransformList[1];
			if (!(((Vector2)(ref val5)).magnitude > 0.0001f))
			{
				return;
			}
		}
		UpdateHighlightTransform(val4, val);
	}

	public void Find_FGUI_Control(List<GObject> aim1)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		List<Vector2> list = new List<Vector2>();
		for (int i = 0; i < aim1.Count; i++)
		{
			Vector2 zero = Vector2.zero;
			if (aim1[i].pivotAsAnchor)
			{
				((Vector2)(ref zero))._002Ector(aim1[i].pivotX * aim1[i].width, aim1[i].pivotY * aim1[i].height);
			}
			list[i] = aim1[i].LocalToGlobal(new Vector2(aim1[i].width / 2f - zero.x, aim1[i].height / 2f - zero.y));
		}
		UpdateHighlightTransform(list[0], aim1[0].size);
	}

	private Vector2 GetFingerPos(string uiName)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(uiName))
		{
			return Vector2.one * 5000f;
		}
		List<string> list = new List<string> { uiName };
		object obj = UiTagManager.Instance.FindObjectByTag(list[0]);
		if (obj == null)
		{
			return Vector2.one * 5000f;
		}
		GObject val = (GObject)((obj is GObject) ? obj : null);
		if (val != null)
		{
			return UiHelper.GetGObjectPositionOnGRoot(val, new Vector2(val.width / 2f, val.height / 2f));
		}
		return Vector2.one * 5000f;
	}

	private bool FindControl(List<string> nameList, bool reUpdateLayout = false)
	{
		if (nameList.Count != 1)
		{
			return false;
		}
		string text = nameList[0];
		_findSoldierUpgradeSuccessSkillFrame = string.Equals(text, "UpgradeSuccessPanel.FrameLoader");
		object obj = UiTagManager.Instance.FindObjectByTag(text);
		if (obj == null)
		{
			if (hiddendibble && reUpdateLayout)
			{
				if (callback.CanSkip)
				{
					callback.Skip = true;
				}
				callback.TrySetResult(result: true);
				End();
			}
			return false;
		}
		GameObject val = (GameObject)((obj is GameObject) ? obj : null);
		if (val != null)
		{
			Find_FGUI_GameObject(val);
			return true;
		}
		GObject val2 = (GObject)((obj is GObject) ? obj : null);
		if (val2 != null)
		{
			bool flag = (!val2.visible || !val2.touchable || val2.isDisposed) && (hiddendibble || showFinger);
			if (flag && reUpdateLayout)
			{
				return false;
			}
			Find_FGUI_Control(val2);
			if (!reUpdateLayout && flag)
			{
				SetGuideUiVisible(canShow: false);
			}
			return true;
		}
		return false;
	}

	private void ReUpdateLayout(object parameter)
	{
		bool flag = FindControl(targetData, reUpdateLayout: true);
		SetGuideUiVisible(flag);
		if (!flag && _findSoldierUpgradeSuccessSkillFrame)
		{
			End();
		}
	}

	private void SetGuideUiVisible(bool canShow)
	{
		if (clickComponent != null && !((GObject)clickComponent).isDisposed)
		{
			((GObject)clickComponent).alpha = (canShow ? 1f : 0f);
		}
		if (_prompt != null && !_prompt.IsDispose())
		{
			_prompt.SetVisible(canShow);
		}
		if (frameBorder != null && !((GObject)frameBorder).isDisposed)
		{
			((GObject)frameBorder).visible = canShow;
		}
		if (Finger != null && !((GObject)Finger).isDisposed && hiddendibble)
		{
			((GObject)Finger).alpha = (canShow ? 1f : 0f);
		}
		if (fingerArrow != null && !((GObject)fingerArrow).isDisposed && showFinger)
		{
			((GObject)fingerArrow).visible = canShow;
		}
	}

	private void ClickDibble(EventContext context)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		if (canClick && (!hiddendibble || ((GObject)clickComponent).alpha != 0f))
		{
			if (Math.Abs(((GObject)clickComponent).size.x) < float.Epsilon || Math.Abs(((GObject)clickComponent).size.y) < float.Epsilon)
			{
				End();
			}
			Vector2 val = ((GObject)GRoot.inst).GlobalToLocal(new Vector2(context.inputEvent.x, context.inputEvent.y));
			if (val.x >= ((GObject)clickComponent).x - ((GObject)clickComponent).width / 2f && val.x <= ((GObject)clickComponent).x + ((GObject)clickComponent).width / 2f && val.y >= ((GObject)clickComponent).y - ((GObject)clickComponent).height / 2f && val.y <= ((GObject)clickComponent).y + ((GObject)clickComponent).height / 2f)
			{
				End();
			}
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GObject)this).onClick.Add(new EventCallback1(ClickDibble));
		Timers.inst.Add(0.2f, 0, new TimerCallback(ReUpdateLayout));
		GameManagers.Instance.Messenger.AddListener("SCREEN_RESIZE", OnScreenResize);
		GameManagers.Instance.Messenger.AddListener<string, bool>("CHANGE_GUIDE_FINGER_VISIBLE", ChangeFingerVisible);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		((GObject)this).onClick.Remove(new EventCallback1(ClickDibble));
		Timers.inst.Remove(new TimerCallback(ReUpdateLayout));
		GameManagers.Instance.Messenger.RemoveListener("SCREEN_RESIZE", OnScreenResize);
		GameManagers.Instance.Messenger.RemoveListener<string, bool>("CHANGE_GUIDE_FINGER_VISIBLE", ChangeFingerVisible);
	}

	private void OnScreenResize()
	{
		((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
	}

	private void ChangeFingerVisible(string tag, bool display)
	{
		if (targetData.Contains(tag) && Finger != null && !((GObject)Finger).isDisposed && hiddendibble)
		{
			((GObject)Finger).alpha = (display ? 1f : 0f);
			((GObject)clickComponent).touchable = display;
		}
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		((GObject)this).SetXY(0f, 0f);
		if (parameters == null)
		{
			End();
			return;
		}
		canClick = false;
		((GObject)mask).alpha = (maskAlpha = 1f);
		((GObject)dibble).SetSize(0f, 0f);
		((GObject)clickMask).SetSize(0f, 0f);
		((GObject)clickMask).visible = false;
		((GObject)this).sortingOrder = 107;
		guideData = parameters;
		((GObject)Finger).visible = true;
		((GObject)Finger).alpha = 0f;
		LoadGuidePrompt(guideData);
		if (parameters.TryGetValue("Background", out var value))
		{
			Dictionary<string, object> dictionary = (Dictionary<string, object>)value;
			if (dictionary.TryGetValue("Color", out var value2))
			{
				string[] array = value2.ToString().Split(',');
				if (array.Length == 3)
				{
					mask.shape.color = Color32.op_Implicit(new Color32(byte.Parse(array[0]), byte.Parse(array[1]), byte.Parse(array[2]), byte.MaxValue));
				}
			}
			if (dictionary.TryGetValue("Opacity", out var value3))
			{
				((DisplayObject)mask.shape).alpha = (maskAlpha = NumericParser.Float(value3.ToString()));
			}
			if (dictionary.TryGetValue("MaskVisible", out var value4))
			{
				bool.TryParse(value4.ToString(), out var result);
				((GComponent)this).opaque = result;
				hiddendibble = !result;
				((GObject)clickMask).visible = !result;
			}
			if (dictionary.TryGetValue("HideGuideUi", out var value5))
			{
				hideAllGuideUi = value5.ToString() == "1";
				((DisplayObject)mask.shape).alpha = (maskAlpha = (hideAllGuideUi ? 0f : 1f));
			}
			if (dictionary.TryGetValue("ShowFinger", out var value6))
			{
				showFinger = value6.ToString() == "1";
				if (showFinger && dictionary.TryGetValue("FingerPos", out var value7))
				{
					fingerPos = GetFingerPos(value7.ToString());
				}
			}
		}
		if (!parameters.TryGetValue("taskCompletionSource", out var value8))
		{
			return;
		}
		callback = value8 as CustomTaskCompletionSource<bool>;
		if (callback.CanSkip)
		{
			((GObject)SkipBtn).x = 1705f;
			((GObject)SkipBtn).visible = true;
			((GObject)SkipBtn).onClick.Set((EventCallback0)delegate
			{
				callback.Skip = true;
				callback.TrySetResult(result: true);
				End();
			});
		}
	}

	private void LoadGuidePrompt(Dictionary<string, object> parameters)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		string text = "Arrow";
		if (parameters.TryGetValue("Background", out var value))
		{
			Dictionary<string, object> dictionary = (Dictionary<string, object>)value;
			if (dictionary.TryGetValue("Prompt", out var value2))
			{
				text = value2.ToString();
			}
		}
		parameters.TryGetValue("OffsetPos", out var value3);
		_offsetPos = (Vector2)((value3 == null) ? Vector2.zero : ((Vector2)value3));
		parameters.TryGetValue("OffsetSize", out var value4);
		_offsetSize = (Vector2)((value4 == null) ? Vector2.zero : ((Vector2)value4));
		string text2 = text;
		string text3 = text2;
		GObject val;
		if (!(text3 == "Arrow"))
		{
			if (!(text3 == "EnterMainCity"))
			{
				throw new Exception("Guide prompt create failed");
			}
			val = (GObject)(object)UI_com_MaincityEntrance.CreateInstance_ILRuntime();
		}
		else
		{
			val = (GObject)(object)UI_arrow.CreateInstance_ILRuntime();
		}
		val.touchable = false;
		((GComponent)GRoot.inst).AddChild(val);
		val.sortingOrder = 2012;
		_prompt = (IGuidePrompt)val;
		_prompt.SetAlpha(0f);
	}

	private IEnumerator FindObject(List<string> nameList)
	{
		if (findingTime > 1.5f)
		{
			FGUIManager.Instance.CloseIEnumerator(findingCoroutine);
			End();
		}
		else if (FindControl(nameList))
		{
			canClick = true;
			((GObject)mask).alpha = maskAlpha;
			targetData = nameList;
			if (UI_BlackMarketerPanel.BlackMarketerPanel != null)
			{
				UiHelper.blackMarketStoryPlayed = true;
			}
			FGUIManager.Instance.CloseIEnumerator(findingCoroutine);
		}
		else
		{
			yield return (object)new WaitForSeconds(0.5f);
			findingTime += 0.5f;
			findingCoroutine = FGUIManager.Instance.OpenIEnumerator(FindObject(nameList));
		}
	}

	public void OnShow()
	{
		if (guideData.TryGetValue("Highlight", out var value))
		{
			if (findingCoroutine != null)
			{
				FGUIManager.Instance.CloseIEnumerator(findingCoroutine);
			}
			findingCoroutine = FGUIManager.Instance.OpenIEnumerator(FindObject((List<string>)value));
			return;
		}
		canClick = true;
		UpdateLayout();
		if (UI_BlackMarketerPanel.BlackMarketerPanel != null)
		{
			UiHelper.blackMarketStoryPlayed = true;
		}
	}

	public void BeforeDestroy()
	{
		if (findingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(findingCoroutine);
		}
	}

	public void Destroy()
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		if (frameBorder != null)
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)frameBorder, true);
		}
		if (npc != null)
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)npc, true);
		}
		if (tips != null)
		{
			((GObject)tips.skip).onClick.Remove(new EventCallback0(SkipClick));
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)tips, true);
		}
		if (fingerArrow != null)
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)fingerArrow, true);
		}
		_prompt?.RemoveSelf();
	}
}
