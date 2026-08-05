using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGTalent.OuterTechStatic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.OuterTech;
using UI.GvGWorldMap3;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGTalent;

public class UI_main_GvGTalentPanel : GComponent, IUiController
{
	public Controller Type;

	public GGraph n15;

	public GLoader background;

	public GGraph Holder;

	public UI_com_Talents Talents;

	public UI_com_SpecialTalentsTypeALL WholeSpecialTalents;

	public UI_main_GvGSpecialTalentsDialog SpecialTalentsDialog;

	public GButton BackBtn;

	public UI_com_Title Title;

	public GComponent Points;

	public GGroup n18;

	public GGraph TalentInfoMask;

	public UI_com_TalentInfoDialog TalentInfo;

	public GButton HelpBtn;

	public UI_com_OuterTechDormantPopup UseDormantConfirm;

	public Transition ShowTalentInfo_Right;

	public Transition ShowTalentInfo_Left;

	public const string URL = "ui://4r1llhd8ran30";

	public static string Name = "UI_main_GvGTalentPanel";

	private readonly Lazy<深层共鸣TalentEffect> _深层共鸣Lazy = new Lazy<深层共鸣TalentEffect>(() => new 深层共鸣TalentEffect());

	private readonly Lazy<十六加八TalentEffect> _十六加八Lazy = new Lazy<十六加八TalentEffect>(() => new 十六加八TalentEffect());

	private readonly Lazy<蛰伏TalentEffect> _蛰伏Lazy = new Lazy<蛰伏TalentEffect>(() => new 蛰伏TalentEffect());

	private const float TalentInfoShowTime = 0.333f;

	private readonly Dictionary<int, UI_btn_Talent> _talents = new Dictionary<int, UI_btn_Talent>(100);

	private readonly Dictionary<string, UI_com_Line> _lines = new Dictionary<string, UI_com_Line>(120);

	private readonly HashSet<int> _existingLines = new HashSet<int>();

	private FairyGUITip _fairyGUITip;

	private bool _isLeft;

	private const float MaxScale = 1f;

	private const float MinScale = 0.5f;

	private const float ScaleDivide = 0.6f;

	private 深层共鸣TalentEffect 深层共鸣 => _深层共鸣Lazy.Value;

	private 十六加八TalentEffect 十六加八 => _十六加八Lazy.Value;

	private 蛰伏TalentEffect 蛰伏 => _蛰伏Lazy.Value;

	public bool IsTalentOuterTechBuffsActive => 十六加八.十六加八IsActive || 蛰伏.蛰伏IsActive;

	public string TalentOuterTechBuffsDesc
	{
		get
		{
			if (!IsTalentOuterTechBuffsActive)
			{
				return string.Empty;
			}
			string text = "GvG3TalentReduceDesc".ToLanguage();
			if (十六加八.十六加八IsActive)
			{
				text += Environment.NewLine;
				text += 十六加八.十六加八Desc;
			}
			if (蛰伏.蛰伏IsActive)
			{
				text += Environment.NewLine;
				text += 蛰伏.蛰伏Desc;
			}
			return text;
		}
	}

	private string PointIconUrl { get; set; }

	private float TalentsWidth => ((GObject)Talents).width;

	private float TalentsHeight => ((GObject)Talents).height;

	private float CurrentScale => ((GObject)Talents).scaleX;

	private float ScreenWidth => ((GObject)this).width;

	private float ScreenHeight => ((GObject)this).height;

	private float MaxX => TalentsWidth * CurrentScale / 2f;

	private float MinX => ScreenWidth - TalentsWidth * CurrentScale / 2f;

	private float MaxY => TalentsHeight * CurrentScale / 2f;

	private float MinY => ScreenHeight - TalentsHeight * CurrentScale / 2f;

	private float ScreenCenterX => ((GObject)this).width / 2f;

	private float ScreenCenterY => ((GObject)this).height / 2f;

	private int CurrentShowSpecialTalentsType { get; set; }

	private bool SpecialTalentsInitialized { get; set; }

	public static string GetURL()
	{
		return "ui://4r1llhd8ran30";
	}

	public static UI_main_GvGTalentPanel CreateInstance()
	{
		return (UI_main_GvGTalentPanel)(object)UIPackage.CreateObject("GvGTalent", "main_GvGTalentPanel");
	}

	public static UI_main_GvGTalentPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGTalentPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8ran30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n15 = (GGraph)((GComponent)this).GetChild("n15");
		background = (GLoader)((GComponent)this).GetChild("background");
		Holder = (GGraph)((GComponent)this).GetChild("Holder");
		Talents = (UI_com_Talents)(object)((GComponent)this).GetChild("Talents");
		WholeSpecialTalents = (UI_com_SpecialTalentsTypeALL)(object)((GComponent)this).GetChild("WholeSpecialTalents");
		SpecialTalentsDialog = (UI_main_GvGSpecialTalentsDialog)(object)((GComponent)this).GetChild("SpecialTalentsDialog");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		Points = (GComponent)((GComponent)this).GetChild("Points");
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		TalentInfoMask = (GGraph)((GComponent)this).GetChild("TalentInfoMask");
		TalentInfo = (UI_com_TalentInfoDialog)(object)((GComponent)this).GetChild("TalentInfo");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
		UseDormantConfirm = (UI_com_OuterTechDormantPopup)(object)((GComponent)this).GetChild("UseDormantConfirm");
		ShowTalentInfo_Right = ((GComponent)this).GetTransition("ShowTalentInfo_Right");
		ShowTalentInfo_Left = ((GComponent)this).GetTransition("ShowTalentInfo_Left");
	}

	public void BeforeDestroy()
	{
		WholeSpecialTalents.OnDestroy();
		TalentsUiDestroy();
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (_fairyGUITip == null)
		{
			_fairyGUITip = new FairyGUITip();
		}
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		TalentsUiInit();
		GestureInit();
		((GObject)TalentInfo).enabled = false;
		WholeSpecialTalents.OnInit(深层共鸣, 十六加八);
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
		{
			Singleton<GvGTalentsManager>.Instance.GetActiveTalents(RenderTalentUi, isFirst: false);
		});
		void FocusSomeTalent()
		{
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			if (parameters != null)
			{
				object value;
				int num = (parameters.TryGetValue("AreaIdx", out value) ? ((int)value) : 0);
				object value2;
				int talentIdx = (parameters.TryGetValue("TalentIdx", out value2) ? ((int)value2) : 0);
				if (num != 0 && talentIdx != 0)
				{
					FocusTalentArea(num);
					((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
					{
						UI_btn_Talent uI_btn_Talent = _talents[talentIdx];
						((GObject)uI_btn_Talent).onClick.Call();
						((GButton)uI_btn_Talent).selected = true;
					});
				}
			}
		}
		void RenderTalentUi()
		{
			if (!((GObject)this).isDisposed)
			{
				RenderUi();
				FocusSomeTalent();
			}
		}
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)TalentInfoMask).onClick.Add(new EventCallback0(CloseTalentInfoDialog));
		((GObject)TalentInfo.Unlock).onClick.Add(new EventCallback1(OnClickUnlockTalent));
		((GObject)(Points as UI_addCouponBtn).addButton).onClick.Add(new EventCallback0(ShowJumpTip));
		((GObject)SpecialTalentsDialog.Mask).onClick.Add(new EventCallback0(OnSpecialTalentsMaskClick));
		((GObject)TalentInfo.OuterTechBuff).onClick.Set(new EventCallback1(DisplayOuterTechBuff));
		((GObject)HelpBtn).onClick.Set(new EventCallback0(OnHelpClick));
		((GObject)TalentInfo.TalentDesc.Desc).onClickLink.Set(new EventCallback1(OnClickTalentTip));
		((GButton)TalentInfo.RechargeTipSwitch).onChanged.Set(new EventCallback0(OnSwitchRechargeTip));
		((GObject)UseDormantConfirm.Dialog.Confirm).onClick.Set(new EventCallback0(OnConfirmUseDormant));
		((GObject)UseDormantConfirm.Dialog.Cancel).onClick.Set(new EventCallback0(OnCancelUseDormant));
		WholeSpecialTalents.RegisterEventListeners();
		TalentAreaInit();
		GvGStoreHouseManager instance = Singleton<GvGStoreHouseManager>.Instance;
		instance.OnChange = (Action)Delegate.Combine(instance.OnChange, new Action(UpdateTalentPoint));
		SharedMessenger.AddListener("ON__GVG3_TALENTS_RESET", RenderUi);
		SharedMessenger.AddListener<int>("ON_GVG3_OUTTERTECH_RESET", RenderOuterTechBuffs);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Remove(new EventCallback0(End));
		((GObject)TalentInfoMask).onClick.Remove(new EventCallback0(CloseTalentInfoDialog));
		((GObject)TalentInfo.Unlock).onClick.Remove(new EventCallback1(OnClickUnlockTalent));
		((GObject)(Points as UI_addCouponBtn).addButton).onClick.Remove(new EventCallback0(ShowJumpTip));
		((GObject)SpecialTalentsDialog.Mask).onClick.Remove(new EventCallback0(OnSpecialTalentsMaskClick));
		((GObject)TalentInfo.OuterTechBuff).onClick.Clear();
		((GObject)HelpBtn).onClick.Clear();
		((GObject)TalentInfo.TalentDesc.Desc).onClick.Clear();
		((GObject)TalentInfo.RechargeTipSwitch).onClick.Clear();
		WholeSpecialTalents.UnregisterEventListeners();
		((GObject)UseDormantConfirm.Dialog.Confirm).onClick.Clear();
		((GObject)UseDormantConfirm.Dialog.Cancel).onClick.Clear();
		TalentAreaClear();
		GvGStoreHouseManager instance = Singleton<GvGStoreHouseManager>.Instance;
		instance.OnChange = (Action)Delegate.Remove(instance.OnChange, new Action(UpdateTalentPoint));
		SharedMessenger.RemoveListener("ON__GVG3_TALENTS_RESET", RenderUi);
		SharedMessenger.RemoveListener<int>("ON_GVG3_OUTTERTECH_RESET", RenderOuterTechBuffs);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void RenderUi()
	{
		RenderTalents();
		RenderTalentLines();
		UpdateTalentPoint();
		SpecialTalentsDialogInit();
		WholeSpecialTalents.Render();
		UpdateSpecialTalentLogo();
	}

	private void RenderOuterTechBuffs(int eOuterTechName)
	{
		switch (eOuterTechName)
		{
		case 604:
			RenderO邪魔外道();
			break;
		case 605:
			RenderO蛰伏();
			break;
		}
	}

	private void UpdateTalentPoint()
	{
		PointIconUrl = "ui://PublicResources/" + UiHelper.GetIcon("I32017");
		GLoader asLoader = Points.GetChild("icon").asLoader;
		if (string.IsNullOrEmpty(asLoader.url))
		{
			asLoader.url = PointIconUrl;
		}
		GTextField asTextField = Points.GetChild("num").asTextField;
		((GObject)asTextField).text = Singleton<GvGStoreHouseManager>.Instance.GetItemCount("I32017").ToString();
	}

	private void TalentsUiInit()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		GObject[] children = ((GComponent)Talents.Content).GetChildren();
		for (int i = 0; i < children.Length; i++)
		{
			if (children[i] is UI_btn_Talent uI_btn_Talent)
			{
				uI_btn_Talent.Init();
				((GObject)uI_btn_Talent).onClick.Add(new EventCallback1(ShowTalentInfo));
				_talents.Add(uI_btn_Talent.Idx, uI_btn_Talent);
			}
		}
	}

	private void TalentsUiDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		foreach (KeyValuePair<int, UI_btn_Talent> talent in _talents)
		{
			((GObject)talent.Value).onClick.Remove(new EventCallback1(ShowTalentInfo));
		}
	}

	private void RenderTalents()
	{
		foreach (KeyValuePair<int, UI_btn_Talent> talent in _talents)
		{
			RenderTalent(talent.Value);
		}
		RenderO邪魔外道();
		SetFourTalentsSelected(selected: true);
		RenderO蛰伏();
		((GButton)TalentInfo.RechargeTipSwitch).selected = !GameLocalDataManager.GetDontShowUseDormantTip();
	}

	private void RenderO邪魔外道()
	{
		bool flag = OuterTechHelper.IsO邪魔外道Active();
		Talents.Content.hasOuterTech.SetSelectedIndex(flag ? 1 : 0);
	}

	private void RenderTalent(UI_btn_Talent talent)
	{
		GvGTalentUiModel data = talent.Data;
		talent.Status.selectedIndex = (int)data.GetState();
		if (talent.Status.selectedIndex == 1)
		{
			((GComponent)talent).GetTransition("t0").Play(-1, 0f, 0f, -1f, (PlayCompleteCallback)null);
		}
	}

	private void UpdateTalent(int idx)
	{
		if (!_talents.TryGetValue(idx, out var value))
		{
			return;
		}
		GvGTalentUiModel data = value.Data;
		value.Status.selectedIndex = (int)data.GetState();
		for (int i = 0; i < data.ParentTalent.Count; i++)
		{
			int key = data.ParentTalent[i];
			if (_talents.TryGetValue(key, out var value2))
			{
				value2.Status.selectedIndex = (int)value2.Data.GetState();
			}
		}
	}

	private void RenderTalentInfoDialog(UI_btn_Talent talent)
	{
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		foreach (UI_btn_Talent value in _talents.Values)
		{
			if (value.Idx != talent.Idx)
			{
				((GButton)value).selected = false;
			}
		}
		GvGTalentUiModel data = talent.Data;
		((GObject)TalentInfo.TalentName).text = data.Name;
		((GObject)TalentInfo.TypeName).text = data.TypeName;
		((GObject)TalentInfo.TalentDesc.Desc).text = data.Desc;
		TalentInfo.Status.selectedIndex = (int)data.GetState();
		bool flag = OuterTechHelper.IsO邪魔外道Active();
		bool flag2 = GvGTalentConfigHelper.OuterTechAdditionalStartPoint.Contains((eTalent)data.Idx);
		TalentInfo.hasOuterTech.selectedIndex = ((flag && flag2) ? 1 : 0);
		((GObject)TalentInfo.outerTechIcon).onClick.Set((EventCallback0)delegate
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			FairyGUITip.ShowTip((GObject)(object)TalentInfo.outerTechIcon, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
			{
				((GObject)popup.title).text = "GvG3OuterTechUnlockTalentTip".ToLanguage();
			});
		});
		TalentInfo.TalentIcon.url = talent.Icon.url;
		TalentInfo.ConsumeIcon.url = PointIconUrl;
		if (TalentInfo.Status.selectedIndex == 1)
		{
			int activateNextTalentConsumePoints = Singleton<GvGTalentsManager>.Instance.GetActivateNextTalentConsumePoints();
			int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount("I32017");
			float num = 0f;
			if (十六加八.十六加八IsActive)
			{
				num += 十六加八.十六加八_减免Value;
			}
			if (蛰伏.蛰伏IsActive)
			{
				num += 蛰伏.蛰伏_减免Value;
			}
			activateNextTalentConsumePoints = Mathf.CeilToInt((float)activateNextTalentConsumePoints * (1f - num));
			((GObject)TalentInfo.Num).text = activateNextTalentConsumePoints.ToString();
			((GObject)TalentInfo.Unlock).data = data.Idx;
			TalentInfo.Type.selectedIndex = ((itemCount < activateNextTalentConsumePoints) ? 1 : 0);
			((GObject)TalentInfo.OuterTechBuff).visible = IsTalentOuterTechBuffsActive;
		}
		Vector2 val = ((GObject)talent).LocalToRoot(Vector2.zero, GRoot.inst);
		_isLeft = val.x > ScreenCenterX;
		if (_isLeft)
		{
			ShowTalentInfoPlay(-240f, 280f);
		}
		else
		{
			ShowTalentInfoPlay(((GObject)this).width, ((GObject)this).width - ((GObject)TalentInfo).width);
		}
		((GObject)TalentInfo).enabled = true;
	}

	private void DisplayOuterTechBuff(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject target = (GObject)context.sender;
		FairyGUITip.ShowTip(target, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = TalentOuterTechBuffsDesc;
		});
	}

	private void RenderO蛰伏()
	{
		if (!OuterTechHelper.IsO蛰伏Active())
		{
			蛰伏.蛰伏IsActive = false;
			TalentInfo.hasOuterTech2.selectedIndex = 0;
			return;
		}
		OuterTechModel techState = OuterTechHelper.GetTechState();
		if (techState.o蛰伏_LimitTime > 0)
		{
			蛰伏.蛰伏IsActive = true;
			TalentInfo.hasOuterTech2.selectedIndex = 2;
		}
		else if (techState.o蛰伏_Valid)
		{
			蛰伏.蛰伏IsActive = false;
			TalentInfo.hasOuterTech2.selectedIndex = 1;
		}
		else
		{
			蛰伏.蛰伏IsActive = false;
			TalentInfo.hasOuterTech2.selectedIndex = 3;
		}
	}

	private void ShowTalentInfoPlay(float startX, float endX)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		((GObject)TalentInfo).visible = true;
		((GObject)TalentInfo).alpha = 0f;
		((GObject)TalentInfo).x = startX;
		((GObject)TalentInfoMask).visible = false;
		((GObject)TalentInfo).TweenFade(1f, 0.333f);
		((GObject)TalentInfo).TweenMoveX(endX, 0.333f);
		((GComponent)(object)this).SetTimeout(0.333f).OnComplete((GTweenCallback)delegate
		{
			string text = ((GObject)TalentInfo.TalentDesc.Desc).text;
			((GObject)TalentInfo.TalentDesc.Desc).text = text;
			((GObject)TalentInfoMask).visible = true;
		});
	}

	private void ShowTalentInfoPlayReverse(float endX)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		((GObject)TalentInfo).TweenFade(0f, 0.333f);
		((GObject)TalentInfo).TweenMoveX(endX, 0.333f);
		((GComponent)(object)this).SetTimeout(0.333f).OnComplete((GTweenCallback)delegate
		{
			((GObject)TalentInfoMask).visible = false;
			((GObject)TalentInfo).visible = false;
		});
	}

	private void TalentLinesInit()
	{
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		if (_existingLines.Count > 0)
		{
			return;
		}
		Vector2 val3 = default(Vector2);
		foreach (UI_btn_Talent value3 in _talents.Values)
		{
			foreach (int item in value3.Data.ParentTalent)
			{
				int num = Mathf.Min(value3.Idx, item);
				int num2 = Mathf.Max(value3.Idx, item);
				string text = $"{num}_{num2}";
				int hashCode = text.GetHashCode();
				if (!_existingLines.Contains(hashCode) && _talents.TryGetValue(num, out var value) && _talents.TryGetValue(num2, out var value2))
				{
					Vector2 val = ((GObject)value).xy - ((GObject)value2).xy;
					Vector2 val2 = (((GObject)value).xy + ((GObject)value2).xy) / 2f;
					((Vector2)(ref val3))._002Ector(0f, -1f);
					float magnitude = ((Vector2)(ref val)).magnitude;
					float rotation = Vector2.SignedAngle(val3, val);
					GvGTalentLine lineData = new GvGTalentLine(text, num, num2, magnitude, rotation, val2.x, val2.y);
					UI_com_Line uI_com_Line = UI_com_Line.CreateInstance_ILRuntime();
					((GComponent)Talents.Content).AddChild((GObject)(object)uI_com_Line);
					((GComponent)Talents.Content).SetChildIndex((GObject)(object)uI_com_Line, 0);
					_lines.Add(text, uI_com_Line);
					_existingLines.Add(hashCode);
					uI_com_Line.LineInit(lineData);
				}
			}
		}
	}

	private void RenderTalentLines()
	{
		TalentLinesInit();
		foreach (UI_com_Line value in _lines.Values)
		{
			value.UpdateLineStatus();
		}
	}

	private void UpdateTalentLines(int idx)
	{
		if (!_talents.TryGetValue(idx, out var value))
		{
			return;
		}
		GvGTalentUiModel data = value.Data;
		for (int i = 0; i < data.ParentTalent.Count; i++)
		{
			int num = Mathf.Min(value.Idx, data.ParentTalent[i]);
			int num2 = Mathf.Max(value.Idx, data.ParentTalent[i]);
			string key = $"{num}_{num2}";
			if (_lines.TryGetValue(key, out var value2))
			{
				value2.UpdateLineStatus();
			}
		}
	}

	private void OnHelpClick()
	{
		UiHelper.OpenHelpPage("元魔之力", "远征相关", "元魔之力");
	}

	private static void OnClickTalentTip(EventContext context)
	{
		object data = context.data;
		if (data != null && data is string text && text == UI_main_SuppressBonusLimitPanel.Name)
		{
			UnityUiService.Instance.OpenPanel(UI_main_SuppressBonusLimitPanel.Name, new Dictionary<string, object>());
		}
	}

	private void OnClickUnlockTalent(EventContext context)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (Type.selectedIndex == 0)
		{
			return;
		}
		object data = ((GObject)context.sender).data;
		if (data != null)
		{
			int num = (int)data;
			if (((GButton)TalentInfo.RechargeTipSwitch).selected && TalentInfo.hasOuterTech2.selectedIndex == 1)
			{
				((GObject)UseDormantConfirm).visible = true;
				((GObject)UseDormantConfirm).data = num;
			}
			else
			{
				ActivateTalent(num);
			}
		}
	}

	private void OnConfirmUseDormant()
	{
		int talentIdx = (int)((GObject)UseDormantConfirm).data;
		((GObject)UseDormantConfirm).visible = false;
		ActivateTalent(talentIdx);
	}

	private void OnCancelUseDormant()
	{
		((GObject)UseDormantConfirm).visible = false;
	}

	private void OnSwitchRechargeTip()
	{
		if (((GButton)TalentInfo.RechargeTipSwitch).selected)
		{
			"GVG3CardI67605TipON".ToLanguage().ToTip();
			GameLocalDataManager.MarkDontShowUseDormantTip(dontShow: false);
		}
		else
		{
			"GVG3CardI67605TipOFF".ToLanguage().ToTip();
			GameLocalDataManager.MarkDontShowUseDormantTip(dontShow: true);
		}
	}

	private void ActivateTalent(int talentIdx)
	{
		Singleton<GvGTalentsManager>.Instance.ActivateTalent(talentIdx, OnFinished);
		void OnFinished()
		{
			CloseTalentInfoDialog();
			RenderO邪魔外道();
			UpdateTalent(talentIdx);
			UpdateTalentLines(talentIdx);
			UpdateCurrentSpecialTalents(CurrentShowSpecialTalentsType);
			WholeSpecialTalents.RenderSpecials();
		}
	}

	private void CloseTalentInfoDialog()
	{
		((GObject)TalentInfo).touchable = false;
		if (_isLeft)
		{
			ShowTalentInfoPlayReverse(-240f);
		}
		else
		{
			ShowTalentInfoPlayReverse(((GObject)this).width);
		}
		foreach (UI_btn_Talent value in _talents.Values)
		{
			((GButton)value).selected = false;
		}
		SetFourTalentsSelected(selected: true);
	}

	private void ShowTalentInfo(EventContext context)
	{
		if (Type.selectedIndex == 1)
		{
			UI_btn_Talent uI_btn_Talent = (UI_btn_Talent)(object)context.sender;
			if (uI_btn_Talent != null)
			{
				RenderTalentInfoDialog(uI_btn_Talent);
			}
		}
	}

	private void SetFourTalentsSelected(bool selected)
	{
		if (Singleton<GvGTalentsManager>.Instance.GetEffectiveTalentsNum() > 0 || !_talents.TryGetValue(0, out var value))
		{
			return;
		}
		GvGTalentUiModel data = value.Data;
		for (int i = 0; i < data.ParentTalent.Count; i++)
		{
			int key = data.ParentTalent[i];
			if (_talents.TryGetValue(key, out var value2))
			{
				((GButton)value2).selected = selected;
			}
		}
	}

	private void OnTalentsScaleChanged(float scaleValue)
	{
		Type.selectedIndex = ((!(scaleValue <= 0.6f)) ? 1 : 0);
		((GObject)Talents.Content).touchable = Type.selectedIndex == 1;
	}

	private void UpdateSpecialTalentsType(int type)
	{
		if (Type.selectedIndex == 1)
		{
			CurrentShowSpecialTalentsType = type;
			UpdateCurrentSpecialTalents(CurrentShowSpecialTalentsType);
			GComponent asCom = ((GComponent)SpecialTalentsDialog).GetChild($"Type{Mathf.Abs(CurrentShowSpecialTalentsType)}").asCom;
			Transition transition = asCom.GetTransition("Appear");
			transition.invalidateBatchingEveryFrame = true;
			transition.Play();
			asCom.EnsureBoundsCorrect();
			((GComponent)Talents.Background).GetTransition($"SelectType{CurrentShowSpecialTalentsType}").Play();
		}
	}

	private void UpdateSpecialTalentLogo()
	{
		int[] array = new int[4] { 1, 2, 4, 8 };
		int[] array2 = array;
		foreach (int num in array2)
		{
			int type = -num;
			GComponent asCom = ((GComponent)Talents.Background).GetChild($"Logo{num}").asCom;
			asCom.GetController("Lv").SetSelectedIndex(Singleton<GvGTalentsManager>.Instance.GetCurSpecialTalentLevel(type));
		}
	}

	private Vector2 GetTalentAreaFocusPos(int type)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		return (Vector2)(type switch
		{
			-1 => new Vector2(ScreenCenterX, ScreenCenterY + 450f), 
			-2 => new Vector2(ScreenCenterX + 730f, ScreenCenterY), 
			-4 => new Vector2(ScreenCenterX, ScreenCenterY - 450f), 
			-8 => new Vector2(ScreenCenterX - 730f, ScreenCenterY), 
			_ => new Vector2(ScreenCenterX, ScreenCenterY), 
		});
	}

	private void FocusTalentArea(int type, float duration = 0.5f)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		((GObject)Holder).touchable = false;
		Vector2 talentAreaFocusPos = GetTalentAreaFocusPos(type);
		((GObject)Talents).TweenScale(new Vector2(1f, 1f), duration).OnComplete((GTweenCallback)delegate
		{
			OnTalentsScaleChanged(CurrentScale);
			int num = Mathf.Abs(CurrentShowSpecialTalentsType);
			GComponent asCom = ((GComponent)SpecialTalentsDialog).GetChild($"Type{num}").asCom;
			Transition transition = asCom.GetTransition("Appear");
			transition.PlayReverse();
			transition.Stop(true, true);
			asCom.EnsureBoundsCorrect();
			UpdateSpecialTalentsType(type);
			((GObject)Holder).touchable = true;
		});
		((GObject)Talents).TweenMove(talentAreaFocusPos, duration);
	}

	private void ReturnWhole(float duration = 0.5f)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		((GObject)Holder).touchable = false;
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(ScreenCenterX, ScreenCenterY);
		((GObject)Talents).TweenScale(new Vector2(0.5f, 0.5f), duration).OnComplete((GTweenCallback)delegate
		{
			OnTalentsScaleChanged(CurrentScale);
			((GObject)Holder).touchable = true;
		});
		((GObject)Talents).TweenMove(val, duration);
	}

	private void TalentsPosCorrectOnReturnWhole(float duration = 0.5f)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		if (!(CurrentScale > 0.5f))
		{
			((GObject)Holder).touchable = false;
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(ScreenCenterX, ScreenCenterY);
			((GObject)Talents).TweenMove(val, duration).OnComplete((GTweenCallback)delegate
			{
				((GObject)Holder).touchable = true;
			});
		}
	}

	private void FocusCenter()
	{
		ReturnWhole();
	}

	private void ShowJumpTip()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		UI_addButton addButton = (Points as UI_addCouponBtn).addButton;
		UI_JumpTip uI_JumpTip = FairyGUITip.ShowTip<UI_JumpTip>((GObject)(object)addButton, eFairyGUITipDir.Down);
		uI_JumpTip.Render(Name);
	}

	private void OnTalentAreaClick(EventContext context)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (Type.selectedIndex == 0)
		{
			int type = (int)((GObject)context.sender).data;
			FocusTalentArea(type);
		}
	}

	private void TalentAreaInit()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		((GObject)Talents.Background.Area1).data = -1;
		((GObject)Talents.Background.Area2).data = -2;
		((GObject)Talents.Background.Area4).data = -4;
		((GObject)Talents.Background.Area8).data = -8;
		((GObject)Talents.Background.Area1).onClick.Add(new EventCallback1(OnTalentAreaClick));
		((GObject)Talents.Background.Area2).onClick.Add(new EventCallback1(OnTalentAreaClick));
		((GObject)Talents.Background.Area4).onClick.Add(new EventCallback1(OnTalentAreaClick));
		((GObject)Talents.Background.Area8).onClick.Add(new EventCallback1(OnTalentAreaClick));
		((GObject)Talents.Content).touchable = false;
		CurrentShowSpecialTalentsType = -1;
	}

	private void TalentAreaClear()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		((GObject)Talents.Background.Area1).onClick.Remove(new EventCallback1(OnTalentAreaClick));
		((GObject)Talents.Background.Area2).onClick.Remove(new EventCallback1(OnTalentAreaClick));
		((GObject)Talents.Background.Area4).onClick.Remove(new EventCallback1(OnTalentAreaClick));
		((GObject)Talents.Background.Area8).onClick.Remove(new EventCallback1(OnTalentAreaClick));
	}

	private void UpdateSpecialTalentInfoOnSwipeEnd()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (Type.selectedIndex == 1)
		{
			Vector2 logicScreenPos = default(Vector2);
			((Vector2)(ref logicScreenPos))._002Ector(ScreenCenterX, ScreenCenterY);
			int posBelongArea = GetPosBelongArea(logicScreenPos);
			int num = Mathf.Abs(CurrentShowSpecialTalentsType);
			((GComponent)SpecialTalentsDialog).GetChild($"Type{num}").asCom.GetTransition("Appear").PlayReverse();
			UpdateSpecialTalentsType(posBelongArea);
		}
	}

	private int GetPosBelongArea(Vector2 logicScreenPos)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = ((GObject)Talents).RootToLocal(logicScreenPos, GRoot.inst);
		val.y *= -1f;
		if (Mathf.Abs(val.x) < 1f)
		{
			return (val.y >= 0f) ? (-1) : (-4);
		}
		float num = 0.746f;
		float num2 = Mathf.Abs(val.y / val.x);
		if (val.y > 0f && val.x > 0f)
		{
			return (num2 > num) ? (-1) : (-8);
		}
		if (val.y > 0f && val.x < 0f)
		{
			return (num2 > num) ? (-1) : (-2);
		}
		if (val.y < 0f && val.x < 0f)
		{
			return (num2 > num) ? (-4) : (-2);
		}
		return (num2 > num) ? (-4) : (-8);
	}

	private void SpecialTalentsDialogInit()
	{
		if (!SpecialTalentsInitialized)
		{
			RenderSpecialTalents(-1);
			RenderSpecialTalents(-2);
			RenderSpecialTalents(-4);
			RenderSpecialTalents(-8);
			SpecialTalentsInitialized = true;
		}
	}

	private void RenderSpecialTalents(int type)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		List<GDEGvGTalentConfigData> list = Singleton<GvGTalentsManager>.Instance.SpecialTalents[type];
		int num = Mathf.Abs(type);
		GComponent asCom = ((GComponent)SpecialTalentsDialog).GetChild($"Type{num}").asCom;
		GList asList = asCom.GetChild("Specials").asList;
		asList.onClickItem.Set((EventCallback0)delegate
		{
			((GObject)SpecialTalentsDialog.Mask).visible = true;
		});
		((GObject)asCom).data = type;
		((GObject)asList).data = type;
		asList.itemRenderer = new ListItemRenderer(RenderSpecialTalent);
		asList.numItems = list.Count;
		int currentSpecialTalentCount = Singleton<GvGTalentsManager>.Instance.GetCurrentSpecialTalentCount(type);
		int nextSpecialCount = Singleton<GvGTalentsManager>.Instance.GetNextSpecialCount(type, currentSpecialTalentCount, 深层共鸣.深层共鸣Value);
		Controller controller = asCom.GetController("OuterTechIsActive");
		if (controller != null)
		{
			controller.SetSelectedIndex(深层共鸣.深层共鸣IsActive ? 1 : 0);
		}
		string arg = (深层共鸣.深层共鸣IsActive ? "#6df2e7" : "#E6BF73");
		bool flag = currentSpecialTalentCount >= nextSpecialCount;
		asCom.GetChild("OuterTechMark").visible = !flag;
		asCom.GetChild("Tip").text = (flag ? $"{currentSpecialTalentCount}" : $"{currentSpecialTalentCount}/[color={arg}]{nextSpecialCount}[/color]");
	}

	private void RenderSpecialTalent(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		int key = (int)((GObject)((GObject)((GObject)asButton).parent).parent).data;
		GDEGvGTalentConfigData gDEGvGTalentConfigData = Singleton<GvGTalentsManager>.Instance.SpecialTalents[key][index];
		string iconName = gDEGvGTalentConfigData.Icon ?? string.Empty;
		((GComponent)asButton).GetChild("Icon").asLoader.url = iconName.ToPublicResourcesRgbIcon();
		((GComponent)asButton).GetChild("Desc").asCom.GetChild("Desc").text = "GvGSpecialTalentTitle".ToLanguage() + gDEGvGTalentConfigData.Desc;
		((GComponent)asButton).GetChild("Desc").asCom.GetChild("TalentName").text = gDEGvGTalentConfigData.Name;
		((GComponent)asButton).GetChild("TalentName").text = gDEGvGTalentConfigData.Name;
		((GComponent)asButton).GetChild("Point").text = 深层共鸣.GetSpecialParentTalent(gDEGvGTalentConfigData);
		((GComponent)asButton).GetController("Lv").SetSelectedIndex(index + 1);
		((GComponent)asButton).GetController("Status").selectedIndex = (Singleton<GvGTalentsManager>.Instance.SpecialTalentEffective(gDEGvGTalentConfigData.Idx) ? 1 : 0);
		Controller controller = ((GComponent)asButton).GetController("OuterTechIsActive");
		if (controller != null)
		{
			controller.SetSelectedIndex(深层共鸣.深层共鸣IsActive ? 1 : 0);
		}
		((GObject)asButton).data = gDEGvGTalentConfigData.Idx;
	}

	private void OnSpecialTalentsMaskClick()
	{
		int num = Mathf.Abs(CurrentShowSpecialTalentsType);
		GList asList = ((GComponent)SpecialTalentsDialog).GetChild($"Type{num}").asCom.GetChild("Specials").asList;
		if (asList.selectedIndex >= 0)
		{
			((GComponent)asList).GetChildAt(asList.selectedIndex).asButton.selected = false;
		}
		((GObject)SpecialTalentsDialog.Mask).visible = false;
	}

	private void UpdateCurrentSpecialTalents(int type)
	{
		int num = Mathf.Abs(type);
		GComponent asCom = ((GComponent)SpecialTalentsDialog).GetChild($"Type{num}").asCom;
		int currentSpecialTalentCount = Singleton<GvGTalentsManager>.Instance.GetCurrentSpecialTalentCount(type);
		int nextSpecialCount = Singleton<GvGTalentsManager>.Instance.GetNextSpecialCount(type, currentSpecialTalentCount, 深层共鸣.深层共鸣Value);
		Controller controller = asCom.GetController("OuterTechIsActive");
		if (controller != null)
		{
			controller.SetSelectedIndex(深层共鸣.深层共鸣IsActive ? 1 : 0);
		}
		string arg = (深层共鸣.深层共鸣IsActive ? "#6df2e7" : "#E6BF73");
		bool flag = currentSpecialTalentCount >= nextSpecialCount;
		asCom.GetChild("OuterTechMark").visible = !flag;
		asCom.GetChild("Tip").text = (flag ? $"{currentSpecialTalentCount}" : $"{currentSpecialTalentCount}/[color={arg}]{nextSpecialCount}[/color]");
		GList asList = asCom.GetChild("Specials").asList;
		for (int i = 0; i < asList.numItems; i++)
		{
			GButton asButton = ((GComponent)asList).GetChildAt(i).asButton;
			int idx = (int)((GObject)asButton).data;
			((GComponent)asButton).GetController("Status").selectedIndex = (Singleton<GvGTalentsManager>.Instance.SpecialTalentEffective(idx) ? 1 : 0);
		}
		GComponent asCom2 = ((GComponent)Talents.Background).GetChild($"Logo{num}").asCom;
		asCom2.GetController("Lv").SetSelectedIndex(Singleton<GvGTalentsManager>.Instance.GetCurSpecialTalentLevel(type));
	}

	private void GestureInit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		SwipeGesture val = new SwipeGesture((GObject)(object)Holder);
		val.onMove.Add(new EventCallback1(OnSwipeMove));
		val.onEnd.Add(new EventCallback1(OnSwipeEnd));
		PinchGesture val2 = new PinchGesture((GObject)(object)Holder);
		val2.onBegin.Add(new EventCallback1(OnPinchBegin));
		val2.onAction.Add(new EventCallback1(OnPinch));
		val2.onEnd.Add(new EventCallback1(OnPinchEnd));
		((GObject)Holder).onClick.Add(new EventCallback1(OnHolderClick));
	}

	private void OnPinchBegin(EventContext context)
	{
	}

	private void OnPinch(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		PinchGesture val = (PinchGesture)context.sender;
		float num = Mathf.Clamp(CurrentScale + val.delta * 0.25f, 0.5f, 1f);
		((GObject)Talents).SetScale(num, num);
		TalentsPosCorrect();
	}

	private void OnPinchEnd(EventContext context)
	{
		TalentsPosCorrect();
		OnTalentsScaleChanged(CurrentScale);
		TalentsPosCorrectOnReturnWhole(0.1f);
		OnSwipeEnd(context);
	}

	private void OnSwipeMove(EventContext context)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		if (!(CurrentScale <= 0.5f))
		{
			SwipeGesture val = (SwipeGesture)context.sender;
			Vector2 val2 = new Vector2
			{
				x = Mathf.Round(val.delta.x),
				y = Mathf.Round(val.delta.y)
			};
			UI_com_Talents talents = Talents;
			((GObject)talents).xy = ((GObject)talents).xy + val2;
			TalentsPosCorrect();
		}
	}

	private void OnSwipeEnd(EventContext context)
	{
		if (!(CurrentScale <= 0.5f))
		{
			UpdateSpecialTalentInfoOnSwipeEnd();
		}
	}

	private void OnHolderClick(EventContext context)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (Type.selectedIndex == 0)
		{
			Vector2 position = context.inputEvent.position;
			Vector2 logicScreenPos = ((GObject)GRoot.inst).GlobalToLocal(position);
			int posBelongArea = GetPosBelongArea(logicScreenPos);
			FocusTalentArea(posBelongArea);
		}
	}

	private void TalentsPosCorrect()
	{
		float num = Mathf.Max(MinX, MaxX);
		float num2 = Mathf.Min(MinX, MaxX);
		float num3 = Mathf.Max(MinY, MaxY);
		float num4 = Mathf.Min(MinY, MaxY);
		((GObject)Talents).x = Mathf.Clamp(((GObject)Talents).x, num2, num);
		((GObject)Talents).y = Mathf.Clamp(((GObject)Talents).y, num4, num3);
	}
}
