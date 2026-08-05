using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using Spine.Unity;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_GvGBattleEndPanel : GComponent, IUiController
{
	public Controller LevelController;

	public Controller TipsTypeController;

	public Controller PanelTypeController;

	public GLoader background;

	public GGraph _mask;

	public GImage panelBack;

	public GTextField tip;

	public UI_BossHealthBar BossHealthBar;

	public GTextField BossName;

	public GTextField DamageTitle;

	public GTextField Damage;

	public GImage n118;

	public UI_Avatar BossAvatar;

	public GGraph SfxLoaderDown2;

	public GGraph SfxLoaderDown1;

	public GLoader Level;

	public GRichTextField MLevelText;

	public GGraph SfxLoaderUp;

	public GGroup BattleResult;

	public GGraph FailSfx;

	public GImage n108;

	public GGroup logo;

	public UI_TodayMyBestPanel TodayMyBestPanel;

	public UI_ConfirmBtn ConfirmBtn;

	public const string URL = "ui://0i520nzmt300o5z";

	public static string Name = "UI_GvGBattleEndPanel";

	private string uiTitleAnimName = "ui_title_lightray_rotate";

	private List<string> textureList = new List<string>();

	private ArchiveExtension_WorldBossRecord.Model WorldBossRecord;

	private Action OnCloseCallback;

	private S2C_BattleResult.Request BattleResultRequest;

	private bool IsShowTodayBest = false;

	private const string IS_STAMP = "IS_STAMP";

	private const string IS_PUSH_AWAY = "IS_PUSH_AWAY";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://0i520nzmt300o5z".Replace("ui://", ""), ((GObject)tip).id, TipsTypeController.selectedIndex);
		((GObject)tip).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://0i520nzmt300o5z";
	}

	public static UI_GvGBattleEndPanel CreateInstance()
	{
		return (UI_GvGBattleEndPanel)(object)UIPackage.CreateObject("LordOfDreams", "GvGBattleEndPanel");
	}

	public static UI_GvGBattleEndPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBattleEndPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmt300o5z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		LevelController = ((GComponent)this).GetController("LevelController");
		TipsTypeController = ((GComponent)this).GetController("TipsTypeController");
		PanelTypeController = ((GComponent)this).GetController("PanelTypeController");
		background = (GLoader)((GComponent)this).GetChild("background");
		_mask = (GGraph)((GComponent)this).GetChild("_mask");
		panelBack = (GImage)((GComponent)this).GetChild("panelBack");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://0i520nzmt300o5z".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		BossHealthBar = (UI_BossHealthBar)(object)((GComponent)this).GetChild("BossHealthBar");
		BossName = (GTextField)((GComponent)this).GetChild("BossName");
		string id2 = "ui://0i520nzmt300o5z".Replace("ui://", "") + "-" + ((GObject)BossName).id;
		((GObject)BossName).text = LanguagesManager.GetDesc(id2);
		DamageTitle = (GTextField)((GComponent)this).GetChild("DamageTitle");
		string id3 = "ui://0i520nzmt300o5z".Replace("ui://", "") + "-" + ((GObject)DamageTitle).id;
		((GObject)DamageTitle).text = LanguagesManager.GetDesc(id3);
		Damage = (GTextField)((GComponent)this).GetChild("Damage");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		BossAvatar = (UI_Avatar)(object)((GComponent)this).GetChild("BossAvatar");
		SfxLoaderDown2 = (GGraph)((GComponent)this).GetChild("SfxLoaderDown2");
		SfxLoaderDown1 = (GGraph)((GComponent)this).GetChild("SfxLoaderDown1");
		Level = (GLoader)((GComponent)this).GetChild("Level");
		MLevelText = (GRichTextField)((GComponent)this).GetChild("MLevelText");
		SfxLoaderUp = (GGraph)((GComponent)this).GetChild("SfxLoaderUp");
		BattleResult = (GGroup)((GComponent)this).GetChild("BattleResult");
		FailSfx = (GGraph)((GComponent)this).GetChild("FailSfx");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		logo = (GGroup)((GComponent)this).GetChild("logo");
		TodayMyBestPanel = (UI_TodayMyBestPanel)(object)((GComponent)this).GetChild("TodayMyBestPanel");
		ConfirmBtn = (UI_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		UiHelper.LoadSpine_AB(FailSfx, uiTitleAnimName, 100f, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "ui_title_lightray_rotate_victory", true);
		});
		if (parameters.TryGetValue("BattleResultRequest", out var value))
		{
			BattleResultRequest = (S2C_BattleResult.Request)value;
		}
		if (parameters.TryGetValue("WorldBossRecord", out var value2))
		{
			WorldBossRecord = (ArchiveExtension_WorldBossRecord.Model)value2;
		}
		if (parameters.TryGetValue("Actions", out var value3))
		{
			Dictionary<string, Action> dictionary = (Dictionary<string, Action>)value3;
			if (dictionary.TryGetValue("OnClose", out var value4))
			{
				OnCloseCallback = value4;
			}
		}
		string iZId = BattleResultRequest.IZId;
		string wBId = BattleResultRequest.WBId;
		string battleResultKey = BattleResultRequest.BattleResultKey;
		DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		string key = $"{dailyRefreshTime.Year}_{dailyRefreshTime.Month}_{dailyRefreshTime.Day}";
		((GObject)TodayMyBestPanel.List).visible = false;
		if (!WorldBossRecord.Records.TryGetValue(iZId, out var value5) || !value5.EveryDayRecords.TryGetValue(key, out var value6))
		{
			return;
		}
		((GObject)TodayMyBestPanel.List).visible = true;
		OnRewardUserModel latestRecords = value6.LatestRecords;
		((GObject)Damage).text = $"{latestRecords.TotalDamage}";
		((GProgressBar)BossHealthBar).value = GvGWorldController.Instance.BossCurHp;
		((GProgressBar)BossHealthBar).max = GvGWorldController.Instance.BossMaxHp;
		if (!string.IsNullOrEmpty(latestRecords.ScoreDesc))
		{
			int num = int.Parse(latestRecords.ScoreDesc);
			if (num > 6)
			{
				LevelController.selectedIndex = 7;
				((GObject)MLevelText).text = $"{num - 6}";
			}
			else
			{
				LevelController.selectedIndex = num;
			}
			AttachSfx(num);
		}
		else
		{
			LevelController.selectedIndex = 0;
		}
		GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(wBId);
		if (gvGWorldBossInfoByWBId != null)
		{
			BossAvatar.HeadPortrait.icon.url = "ui://PublicResources/" + gvGWorldBossInfoByWBId.Icon;
			((GObject)BossName).text = gvGWorldBossInfoByWBId.BossName;
		}
		List<OnRewardUserModel> allBossTop = value6.AllBossTop4;
		for (int num2 = 0; num2 < 4; num2++)
		{
			UI_TodayMyBestSlot uI_TodayMyBestSlot = (UI_TodayMyBestSlot)(object)((GComponent)TodayMyBestPanel.List).GetChildAt(num2).asCom;
			((GObject)uI_TodayMyBestSlot).data = "";
			if (num2 >= allBossTop.Count)
			{
				((GObject)uI_TodayMyBestSlot).visible = false;
				continue;
			}
			OnRewardUserModel onRewardUserModel = allBossTop[num2];
			if (num2 < 3 && onRewardUserModel.BattleResultKey == latestRecords.BattleResultKey)
			{
				IsShowTodayBest = true;
			}
			if (IsShowTodayBest)
			{
				if (onRewardUserModel.BattleResultKey == latestRecords.BattleResultKey)
				{
					((GObject)uI_TodayMyBestSlot).data = "IS_STAMP";
				}
				else
				{
					((GObject)uI_TodayMyBestSlot).data = "IS_PUSH_AWAY";
				}
			}
			uI_TodayMyBestSlot.Wrapper.NumberController.selectedIndex = num2;
			((GObject)uI_TodayMyBestSlot.Wrapper.DamageText).text = $"{onRewardUserModel.TotalDamage}";
			((GObject)uI_TodayMyBestSlot.Wrapper.Score).text = $"{onRewardUserModel.Score}";
			if (onRewardUserModel.ScoreMultiplier - 1f > float.Epsilon)
			{
				((GObject)uI_TodayMyBestSlot.Wrapper.Ratio).visible = true;
				((GObject)uI_TodayMyBestSlot.Wrapper.arrow).visible = true;
				((GObject)uI_TodayMyBestSlot.Wrapper.Ratio).text = $"(x{onRewardUserModel.ScoreMultiplier})";
				int score = (int)((float)onRewardUserModel.Score / onRewardUserModel.ScoreMultiplier);
				CheckScoreMultiplierTip(uI_TodayMyBestSlot.Wrapper.ScoreMultiplierTip, score);
				((GObject)uI_TodayMyBestSlot.Wrapper.ScoreMultiplierTip).onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
			}
			GvGWorldBossInfo gvGWorldBossInfoByWBId2 = GvGConfigHelper.GetGvGWorldBossInfoByWBId(onRewardUserModel.WBId);
			if (gvGWorldBossInfoByWBId2 != null)
			{
				uI_TodayMyBestSlot.Wrapper.Avatar.HeadPortrait.icon.url = "ui://PublicResources/" + gvGWorldBossInfoByWBId2.Icon;
			}
		}
		((GObject)TodayMyBestPanel.TodayTotalScore).text = $"{value6.TodayTotalScore}";
		((GObject)TodayMyBestPanel.TotalScore).text = $"{value5.TotalScore}";
		TipsTypeController.selectedIndex = (IsShowTodayBest ? 1 : 0);
		SetControllerPageText();
	}

	private void AttachSfx(int level)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		Vector3 size = Vector3.one * 100f;
		if (0 < level && level <= 3)
		{
			FGUIManager.Instance.AddTextSpecialEffects(SfxLoaderUp, $"class_fx_{level * 2}", size);
		}
		else if (level == 4)
		{
			FGUIManager.Instance.AddTextSpecialEffects(SfxLoaderUp, "class_fx_7", size);
			FGUIManager.Instance.AddTextSpecialEffects(SfxLoaderDown1, "ui_gvg_score_7", size);
		}
		else if (level == 5)
		{
			FGUIManager.Instance.AddTextSpecialEffects(SfxLoaderUp, "class_fx_8", size);
			FGUIManager.Instance.AddTextSpecialEffects(SfxLoaderDown1, "ui_gvg_score_8", size);
		}
		else if (level > 5)
		{
			FGUIManager.Instance.AddTextSpecialEffects(SfxLoaderUp, "class_fx_9_1", size);
			FGUIManager.Instance.AddTextSpecialEffects(SfxLoaderDown1, "class_fx_9_2", size);
			FGUIManager.Instance.AddTextSpecialEffects(SfxLoaderDown2, "ui_gvg_score_9", size);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)ConfirmBtn).onClick.Set(new EventCallback0(OnConfirm));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)ConfirmBtn).onClick.Clear();
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		SpawnManager.Instance.UnloadAnimation(uiTitleAnimName);
	}

	private void End()
	{
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		OnCloseCallback?.Invoke();
	}

	private void CheckScoreMultiplierTip(GGraph exclamationMarkBtn, int score)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		((GObject)exclamationMarkBtn).data = new Dictionary<string, object>
		{
			{
				"Title",
				LanguagesManager.GetDesc("CsharpCodeZhTcText411") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText412"), score)
			},
			{
				"Pos",
				(object)new Vector2(((GObject)this).width / 2f, ((GObject)this).height / 2f - 100f)
			}
		};
	}

	private void OnConfirm()
	{
		if (IsShowTodayBest)
		{
			PanelTypeController.selectedIndex = 1;
			IsShowTodayBest = false;
			for (int i = 0; i < 4; i++)
			{
				UI_TodayMyBestSlot uI_TodayMyBestSlot = (UI_TodayMyBestSlot)(object)((GComponent)TodayMyBestPanel.List).GetChildAt(i).asCom;
				if (((GObject)uI_TodayMyBestSlot).data != null)
				{
					if (((GObject)uI_TodayMyBestSlot).data.ToString() == "IS_STAMP")
					{
						uI_TodayMyBestSlot.Stamp.Play();
						uI_TodayMyBestSlot.Wrapper.IsNew.selectedIndex = 1;
					}
					else if (((GObject)uI_TodayMyBestSlot).data.ToString() == "IS_PUSH_AWAY")
					{
						uI_TodayMyBestSlot.PushAway.Play();
					}
				}
			}
		}
		else
		{
			End();
		}
	}
}
