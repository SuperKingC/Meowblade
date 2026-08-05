using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvG.Common.Model;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_GvGBonusPanel : GComponent, IUiController
{
	public GLoader background;

	public GGraph _mask;

	public UI_GvGBonusDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://0i520nzmtajuo8s";

	public static string Name = "UI_GvGBonusPanel";

	private string IZId;

	private string CampId;

	private int IZProgress;

	private List<GvGIZManager.UserCampMissionData> UserCampMissions;

	private List<GvGIZManager.CampMissionData> CampMissions;

	private FinalBossDamageRewardTable DamageRewards;

	private string LastWBId;

	private float MyRankingPercent;

	public static string GetURL()
	{
		return "ui://0i520nzmtajuo8s";
	}

	public static UI_GvGBonusPanel CreateInstance()
	{
		return (UI_GvGBonusPanel)(object)UIPackage.CreateObject("LordOfDreams", "GvGBonusPanel");
	}

	public static UI_GvGBonusPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBonusPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtajuo8s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		_mask = (GGraph)((GComponent)this).GetChild("_mask");
		Dialog = (UI_GvGBonusDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		Popup.Play();
		((GObject)Dialog).visible = true;
		if (parameters.TryGetValue("IZId", out var value))
		{
			IZId = value.ToString();
		}
		if (parameters.TryGetValue("CampId", out var value2))
		{
			CampId = value2.ToString();
		}
		if (parameters.TryGetValue("LastWBId", out var value3))
		{
			LastWBId = value3.ToString();
		}
		if (parameters.TryGetValue("IZProgress", out var value4))
		{
			IZProgress = (int)value4;
		}
		MyRankingPercent = -1f;
		GvGIZManager.Instance.LoadDataOnce();
		ArchiveExtension_WorldBossRecord.Model worldBossRecordModel = GameManagers.Instance.UserArchiveManager.GetWorldBossRecordModel();
		if (worldBossRecordModel.Records.TryGetValue(IZId, out var value5))
		{
			((GObject)Dialog.CurScoreText).text = string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText413"), value5.TotalScore);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		GvGIZManager instance = GvGIZManager.Instance;
		instance.OnDataLoaded = (Action)Delegate.Combine(instance.OnDataLoaded, new Action(OnDataLoaded));
		((GObject)_mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		GvGIZManager instance = GvGIZManager.Instance;
		instance.OnDataLoaded = (Action)Delegate.Remove(instance.OnDataLoaded, new Action(OnDataLoaded));
		((GObject)_mask).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OnDataLoaded()
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			return;
		}
		UserCampMissions = GvGIZManager.Instance.GetUserCampMissions(IZId, CampId);
		if (UserCampMissions != null)
		{
			Dialog.ScoreBonusList.SetVirtual();
			Dialog.ScoreBonusList.itemRenderer = new ListItemRenderer(UserCampMissionSlotRerderer);
			Dialog.ScoreBonusList.numItems = UserCampMissions.Count;
		}
		CampMissions = GvGIZManager.Instance.GetCampMissions(IZId, CampId);
		if (UserCampMissions != null)
		{
			Dialog.MissionBonusList.SetVirtual();
			Dialog.MissionBonusList.itemRenderer = new ListItemRenderer(CampMissionSlotRerderer);
			Dialog.MissionBonusList.numItems = CampMissions.Count;
		}
		if (DamageRewards == null)
		{
			DamageRewards = GvGIZManager.Instance.GetDamageRewardTable(IZId);
			if (DamageRewards != null)
			{
				Dialog.DamageRewardList.itemRenderer = new ListItemRenderer(DamageRewardRerderer);
				Dialog.DamageRewardList.numItems = DamageRewards.row.Count;
				UpdateDamageRewardListTip();
			}
		}
		ILRequestHelper<GvGWorldBossRecordRanking2Response>.Request((EventContext)null, (Func<Task<GvGWorldBossRecordRanking2Response>>)(() => GameController.Contexts.Service<INetworkService>().GvGWorldBossRecordRanking2(IZId, LastWBId, "Max3Summary")), (Action<GvGWorldBossRecordRanking2Response>)delegate(GvGWorldBossRecordRanking2Response response)
		{
			if (!response.Result)
			{
				ILRuntimeDebug.LogError("GvGWorldBossRecordRanking 请求失败！");
			}
			else if (response.Model != null)
			{
				MyRankingPercent = ((response.TotalRank == 0 || response.SelfRank < 0) ? (-1f) : ((float)(response.SelfRank + 1) / (float)response.TotalRank));
				if (!((GObject)this).isDisposed)
				{
					Dialog.DamageRewardList.numItems = DamageRewards.row.Count;
				}
			}
		});
	}

	private void UpdateDamageRewardListTip()
	{
		Dialog.Type.selectedIndex = IZProgress;
		Dialog.KillBossTip.Type.selectedIndex = IZProgress;
		if (IZProgress == 1)
		{
			GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(LastWBId);
			Dialog.BossIcon.Avatar.Type.selectedIndex = 1;
			Dialog.KillBossTip.Avatar.Avatar.Type.selectedIndex = 1;
			Dialog.BossIcon.Avatar.Iconloader.url = "ui://PublicResources/" + gvGWorldBossInfoByWBId.Icon;
			Dialog.KillBossTip.Avatar.Avatar.Iconloader.url = "ui://PublicResources/" + gvGWorldBossInfoByWBId.Icon;
		}
	}

	public void UpdateDamageRewardListRebornTime(string timeText)
	{
		if (Dialog.PageController.selectedIndex == 2 && Dialog.Type.selectedIndex == 0)
		{
			((GObject)Dialog.Time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText414") + "[color=#ffff00]" + timeText + "[/color]" + LanguagesManager.GetDesc("CsharpCodeZhTcText415") + "[color=#c601ff]" + LanguagesManager.GetDesc("CsharpCodeZhTcText416") + "[/color]" + LanguagesManager.GetDesc("CsharpCodeZhTcText417");
		}
	}

	private void UserCampMissionSlotRerderer(int index, GObject obj)
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		GvGIZManager.UserCampMissionData data = UserCampMissions[index];
		UI_ScoreBonusSlot uI_ScoreBonusSlot = (UI_ScoreBonusSlot)(object)obj;
		UI_ScoreBonusSlotWrapper wrapper = uI_ScoreBonusSlot.Wrapper;
		((GObject)wrapper.Title).text = $"{data.BonusName}x{data.BonusNum}";
		((GObject)wrapper.TargetScore).text = $"{data.TargetScore}";
		FGUIManager.Instance.SetItemIconAndFrame(wrapper.Icon.rewardIcon, data.BonusId, null, "", frameVisible: false);
		((GObject)wrapper.Icon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(data.BonusId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
		uI_ScoreBonusSlot.StateController.selectedIndex = ((data.State == eCampMissionState.Claimed) ? 1 : 0);
	}

	private void CampMissionSlotRerderer(int index, GObject obj)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		GvGIZManager.CampMissionData data = CampMissions[index];
		UI_MissionBonusSlot uI_MissionBonusSlot = (UI_MissionBonusSlot)(object)obj;
		uI_MissionBonusSlot.Avatar.HeadPortrait.icon.url = data.Icon;
		((GObject)uI_MissionBonusSlot.Title).text = data.Title ?? "";
		((GObject)uI_MissionBonusSlot.Desc).text = data.Desc ?? "";
		uI_MissionBonusSlot.BonusList.SetVirtual();
		uI_MissionBonusSlot.BonusList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			UI_BonusItem uI_BonusItem = (UI_BonusItem)(object)o;
			uI_BonusItem.ShowNum.selectedIndex = 1;
			((GObject)uI_BonusItem.num).text = $"{data.Bonuses[i].Num}";
			FGUIManager.Instance.SetItemIconAndFrame(uI_BonusItem.rewardIcon, data.Bonuses[i].ItemId, null, "", frameVisible: false);
			((GObject)uI_BonusItem).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(data.Bonuses[i].ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		};
		uI_MissionBonusSlot.BonusList.numItems = data.Bonuses.Count;
		uI_MissionBonusSlot.StateController.selectedIndex = 0;
		if (data.State == eCampMissionState.Completed)
		{
			uI_MissionBonusSlot.StateController.selectedIndex = 1;
		}
		if (data.State == eCampMissionState.Claimed)
		{
			uI_MissionBonusSlot.StateController.selectedIndex = 2;
		}
	}

	private void DamageRewardRerderer(int index, GObject obj)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		FinalBossDamageRewardTable_Row finalBossDamageRewardTable_Row = DamageRewards.row[index];
		UI_DamageRewardSlot uI_DamageRewardSlot = (UI_DamageRewardSlot)(object)obj;
		List<FinalBossDamageRewardTable_Row_R> bonuses = finalBossDamageRewardTable_Row.r;
		uI_DamageRewardSlot.RankingController.selectedIndex = index;
		uI_DamageRewardSlot.BonusList.SetVirtual();
		uI_DamageRewardSlot.BonusList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			UI_DamageBonusItem uI_DamageBonusItem = (UI_DamageBonusItem)(object)o;
			int number = (int)NumericParser.Float(bonuses[i].cnt);
			((GObject)uI_DamageBonusItem.num).text = number.ShortNumberFormat() ?? "";
			FGUIManager.Instance.SetItemIconAndFrame(uI_DamageBonusItem.rewardIcon, bonuses[i].ItemId, null, "", frameVisible: false);
			((GObject)uI_DamageBonusItem).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(bonuses[i].ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		};
		uI_DamageRewardSlot.BonusList.numItems = bonuses.Count;
		if (NumericParser.Float(finalBossDamageRewardTable_Row.min) < MyRankingPercent && MyRankingPercent <= NumericParser.Float(finalBossDamageRewardTable_Row.max))
		{
			float num = MyRankingPercent * 100f;
			uI_DamageRewardSlot.ShowMyRank.selectedIndex = 1;
			((GObject)uI_DamageRewardSlot.MyRanking).text = ((num == 100f) ? $"{num:N0}%" : $"{num:N1}%");
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.SetSelfImageByWebRequestAndStorage(Name, uI_DamageRewardSlot.Avatar.HeadPortrait.icon));
		}
		else
		{
			uI_DamageRewardSlot.ShowMyRank.selectedIndex = 0;
		}
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}
}
