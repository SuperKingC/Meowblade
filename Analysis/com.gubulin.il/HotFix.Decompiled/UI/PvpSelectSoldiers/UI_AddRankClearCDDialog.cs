using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_AddRankClearCDDialog : GComponent, IUiController
{
	public GGraph back;

	public UI_ClearCDDialog ConfirmDialog;

	public Transition showTip;

	public const string URL = "ui://82mo10n5qxbi8q";

	public static string Name = "UI_AddRankClearCDDialog";

	private Coroutine RankBattleCdCoroutine;

	private int curRankBattleCd;

	private int PvPClearCdSingleTime;

	private Dictionary<string, int> PvPClearCdSingleCost;

	private int targetId;

	public static string GetURL()
	{
		return "ui://82mo10n5qxbi8q";
	}

	public static UI_AddRankClearCDDialog CreateInstance()
	{
		return (UI_AddRankClearCDDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "AddRankClearCDDialog");
	}

	public static UI_AddRankClearCDDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddRankClearCDDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5qxbi8q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		ConfirmDialog = (UI_ClearCDDialog)(object)((GComponent)this).GetChild("ConfirmDialog");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void BeforeDestroy()
	{
		if (RankBattleCdCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RankBattleCdCoroutine);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		DataInit(parameters);
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
		((GObject)ConfirmDialog.exitBtn).onClick.Add(new EventCallback0(End));
		((GObject)ConfirmDialog.RefreshCardBtn).onClick.Add(new EventCallback0(ConfirmClickEvent));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)ConfirmDialog.exitBtn).onClick.Remove(new EventCallback0(End));
		((GObject)ConfirmDialog.RefreshCardBtn).onClick.Remove(new EventCallback0(ConfirmClickEvent));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void DataInit(Dictionary<string, object> parameters)
	{
		if (parameters.TryGetValue("CurRankBattleCd", out var value))
		{
			curRankBattleCd = (int)value;
		}
		if (parameters.TryGetValue("TargetId", out var value2))
		{
			targetId = (int)value2;
		}
		PvPClearCdSingleTime = RankDataHelper.PvPClearCdSingleTime;
		PvPClearCdSingleCost = RankDataHelper.PvPClearCdSingleCost;
		ConfirmDialog.DialogMiddleContent.DialogMiddleContentInit();
		PreparationTimeInit();
	}

	private void RenderMainUi()
	{
		RenderClearCdText();
		bool enabled = RenderCost(curRankBattleCd);
		((GObject)ConfirmDialog.RefreshCardBtn).enabled = enabled;
	}

	private bool RenderCost(int _rankBattleCd)
	{
		if (_rankBattleCd <= 0)
		{
			((GObject)ConfirmDialog.DialogMiddleContent).visible = false;
			return false;
		}
		float multiple = Mathf.CeilToInt((float)_rankBattleCd / (float)PvPClearCdSingleTime);
		return ConfirmDialog.DialogMiddleContent.RenderDialogMiddleContent(PvPClearCdSingleCost, multiple);
	}

	private void RenderClearCdText()
	{
		ConfirmDialog.icon.url = "ui://PublicResources/Gem";
	}

	private void ConfirmClickEvent()
	{
		Action action = delegate
		{
			End();
			UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.ClearRankBattleCdText();
		};
		RankDataHelper.ClearRankCd(targetId, action);
	}

	private void PreparationTimeInit()
	{
		if (curRankBattleCd <= 0)
		{
			curRankBattleCd = 0;
		}
		((GObject)ConfirmDialog.compoundNum).text = UiHelper.ParseTime(curRankBattleCd) ?? "";
		if (curRankBattleCd > 0 && RankBattleCdCoroutine == null)
		{
			RankBattleCdCoroutine = FGUIManager.Instance.OpenIEnumerator(RenderRankBattleCd(curRankBattleCd));
		}
	}

	private IEnumerator RenderRankBattleCd(int battleCd)
	{
		if (battleCd <= 0 && RankBattleCdCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RankBattleCdCoroutine);
		}
		yield return (object)new WaitForSeconds(1f);
		battleCd--;
		((GObject)ConfirmDialog.compoundNum).text = UiHelper.ParseTime(battleCd) ?? "";
		bool _enabled = RenderCost(curRankBattleCd);
		((GObject)ConfirmDialog.RefreshCardBtn).enabled = _enabled;
		RankBattleCdCoroutine = FGUIManager.Instance.OpenIEnumerator(RenderRankBattleCd(battleCd));
	}
}
