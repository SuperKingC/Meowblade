using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentLogComponent : GComponent
{
	public Controller Type;

	public GImage n13;

	public GGraph n3;

	public GTextField Index;

	public GImage n4;

	public GTextField WinningPercentage;

	public GImage n7;

	public GTextField Score;

	public GList BattleLogList;

	public const string URL = "ui://82mo10n5aveldh3";

	public static string Name = "UI_TopTournamentLogComponent";

	private int myUserId;

	private int currentDayIndex;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	private List<Dictionary<string, object>> showBattleLogData = new List<Dictionary<string, object>>();

	private const int MaxShowLogNum = 6;

	public static string GetURL()
	{
		return "ui://82mo10n5aveldh3";
	}

	public static UI_TopTournamentLogComponent CreateInstance()
	{
		return (UI_TopTournamentLogComponent)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentLogComponent");
	}

	public static UI_TopTournamentLogComponent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentLogComponent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldh3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		Index = (GTextField)((GComponent)this).GetChild("Index");
		string id = "ui://82mo10n5aveldh3".Replace("ui://", "") + "-" + ((GObject)Index).id;
		((GObject)Index).text = LanguagesManager.GetDesc(id);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		WinningPercentage = (GTextField)((GComponent)this).GetChild("WinningPercentage");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		BattleLogList = (GList)((GComponent)this).GetChild("BattleLogList");
	}

	public void RenderBattleRecord(int btnIndex, float winningPercentage, List<Dictionary<string, object>> _showBattleLogData, int _currentDayIndex)
	{
		if (_showBattleLogData != null && _showBattleLogData.Count > 0)
		{
			showBattleLogData = _showBattleLogData;
			SetTypeSelectIndex(winningPercentage);
			currentDayIndex = _currentDayIndex;
			((GObject)Index).text = btnIndex.ToString();
			((GObject)Score).text = string.Format("+{0}", showBattleLogData[0]["Score"]);
			RenderLogList();
		}
	}

	private void SetTypeSelectIndex(float winningPercentage)
	{
		((GObject)WinningPercentage).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint((winningPercentage * 100f).ToString("N1")) + "%";
		if (winningPercentage >= 1f)
		{
			Type.selectedIndex = 0;
		}
		else if (winningPercentage >= 0.8f)
		{
			Type.selectedIndex = 1;
		}
		else
		{
			Type.selectedIndex = 2;
		}
	}

	private void RenderLogList()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		myUserId = GameController.Contexts.gameState.user.value.UserId;
		BattleLogList.itemRenderer = new ListItemRenderer(RenderLogDetail);
		BattleLogList.numItems = showBattleLogData.Count;
		loadWebImageTaskQueue?.Start();
		BattleLogList.ResizeToFit((showBattleLogData.Count > 6) ? showBattleLogData.Count : 6);
	}

	private void RenderLogDetail(int index, GObject obj)
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		if (obj is UI_TopTournamentLogTitle uI_TopTournamentLogTitle)
		{
			Dictionary<string, object> dictionary = showBattleLogData[index];
			int num = (int)dictionary["UserId"];
			uI_TopTournamentLogTitle.Type.selectedIndex = ((num == myUserId) ? 1 : 0);
			FGUIManager.Instance.GetUserMedal(num, uI_TopTournamentLogTitle.medalList, uI_TopTournamentLogTitle.isShowMedal);
			loadWebImageTaskQueue?.AddTask(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, num, uI_TopTournamentLogTitle.Avatar.HeadPortrait.icon, uI_TopTournamentLogTitle.UserName)));
			((GObject)uI_TopTournamentLogTitle).data = num;
			((GObject)uI_TopTournamentLogTitle).onClick.Set(new EventCallback1(CheckLogDetail));
		}
	}

	private void CheckLogDetail(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		if (data != null)
		{
			if (currentDayIndex != 0)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleLogPanel.Name, new Dictionary<string, object>
				{
					{
						"CurrentUserId",
						(int)data
					},
					{ "TopTournamentDayIndex", currentDayIndex }
				});
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleLogPanel.Name, new Dictionary<string, object>
				{
					{
						"CurrentUserId",
						(int)data
					},
					{ "TopTournamentDayIndex", currentDayIndex },
					{ "LastTurnRankChangeRecord", null }
				});
			}
		}
	}
}
