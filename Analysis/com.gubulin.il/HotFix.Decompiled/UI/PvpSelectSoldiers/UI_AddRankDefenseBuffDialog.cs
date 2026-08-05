using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_AddRankDefenseBuffDialog : GComponent, IUiController
{
	public GGraph back;

	public UI_DefenseBuffDialog ConfirmDialog;

	public Transition showTip;

	public const string URL = "ui://82mo10n5qxbi8n";

	public static string Name = "UI_AddRankDefenseBuffDialog";

	private int BuffSingleTime;

	private Dictionary<string, int> BuffSingleCost;

	private string BuffAbilities;

	private int DefenseBuffTime;

	private int RemainingTime;

	private const int Hour = 3600;

	public static string GetURL()
	{
		return "ui://82mo10n5qxbi8n";
	}

	public static UI_AddRankDefenseBuffDialog CreateInstance()
	{
		return (UI_AddRankDefenseBuffDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "AddRankDefenseBuffDialog");
	}

	public static UI_AddRankDefenseBuffDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddRankDefenseBuffDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5qxbi8n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		ConfirmDialog = (UI_DefenseBuffDialog)(object)((GComponent)this).GetChild("ConfirmDialog");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		DataInit();
		RenderMainUi();
	}

	public void OnShow()
	{
		showTip.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GObject)ConfirmDialog.exitBtn).onClick.Add(new EventCallback0(End));
		((GObject)ConfirmDialog.reduceBtn).onClick.Add(new EventCallback1(Reduce));
		((GObject)ConfirmDialog.increaseBtn).onClick.Add(new EventCallback1(IncreaseBuff));
		((GObject)ConfirmDialog.RefreshCardBtn).onClick.Add(new EventCallback0(ConfirmClickEvent));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GObject)ConfirmDialog.exitBtn).onClick.Remove(new EventCallback0(End));
		((GObject)ConfirmDialog.reduceBtn).onClick.Remove(new EventCallback1(Reduce));
		((GObject)ConfirmDialog.increaseBtn).onClick.Remove(new EventCallback1(IncreaseBuff));
		((GObject)ConfirmDialog.RefreshCardBtn).onClick.Remove(new EventCallback0(ConfirmClickEvent));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void DataInit()
	{
		BuffSingleTime = RankDataHelper.PvPDefenseBuffSingleTime;
		BuffSingleCost = RankDataHelper.PvPDefenseBuffSingleCost;
		BuffAbilities = RankDataHelper.PvPDefenseBuffAbilities?[0];
		DefenseBuffTime = RankDataHelper.PvPMaxDefenseBuffTime;
		int num = (int)GameController.Instance.GetServerTime();
		RemainingTime = ((RankDataHelper.PvpRankProgress.DefenseBuffExpiredAt - num > 0) ? (RankDataHelper.PvpRankProgress.DefenseBuffExpiredAt - num) : 0);
		((GObject)ConfirmDialog.compoundNum).data = RemainingTime;
		ConfirmDialog.DialogMiddleContent.DialogMiddleContentInit();
	}

	private void RenderMainUi()
	{
		int sceonds = (int)((GObject)ConfirmDialog.compoundNum).data;
		RenderBuffInfo();
		RenderCost(sceonds);
	}

	private void RenderBuffInfo()
	{
		if (!string.IsNullOrEmpty(BuffAbilities))
		{
			GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(BuffAbilities);
			ConfirmDialog.icon.LoadAbilityIcon(gDEAbilityData.Icon);
			((GObject)ConfirmDialog.tip).text = gDEAbilityData.Description;
		}
	}

	private void RenderCost(int _sceonds)
	{
		((GObject)ConfirmDialog.compoundNum).text = UiHelper.ParseTime(_sceonds) ?? "";
		bool flag = _sceonds == RemainingTime;
		((GObject)ConfirmDialog.RefreshCardBtn).enabled = !flag;
		((GObject)ConfirmDialog.DialogMiddleContent).visible = !flag;
		if (!flag)
		{
			int num = Mathf.CeilToInt((float)(_sceonds - RemainingTime) / 60f);
			int num2 = BuffSingleTime / 60;
			float multiple = (float)num * 100f / ((float)num2 * 100f);
			if (((GObject)ConfirmDialog.DialogMiddleContent).visible)
			{
				bool enabled = ConfirmDialog.DialogMiddleContent.RenderDialogMiddleContent(BuffSingleCost, multiple);
				((GObject)ConfirmDialog.RefreshCardBtn).enabled = enabled;
			}
		}
	}

	private void IncreaseBuff(EventContext context)
	{
		int num = (int)((GObject)ConfirmDialog.compoundNum).data;
		if (num < DefenseBuffTime)
		{
			num += 3600;
			if (num >= DefenseBuffTime)
			{
				num = DefenseBuffTime;
			}
			((GObject)ConfirmDialog.compoundNum).data = num;
			RenderCost(num);
		}
	}

	private void Reduce(EventContext context)
	{
		int num = (int)((GObject)ConfirmDialog.compoundNum).data;
		if (num > RemainingTime)
		{
			num -= 3600;
			if (num <= RemainingTime)
			{
				num = RemainingTime;
			}
			((GObject)ConfirmDialog.compoundNum).data = num;
			RenderCost(num);
		}
	}

	private void ConfirmClickEvent()
	{
		int addTime = (int)((GObject)ConfirmDialog.compoundNum).data - RemainingTime;
		Action action = delegate
		{
			End();
		};
		RankDataHelper.AddDefenseBuffTime(addTime, action);
	}
}
