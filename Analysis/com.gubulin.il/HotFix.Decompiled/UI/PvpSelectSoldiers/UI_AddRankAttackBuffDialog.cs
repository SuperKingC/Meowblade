using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

namespace UI.PvpSelectSoldiers;

public class UI_AddRankAttackBuffDialog : GComponent, IUiController
{
	public GGraph back;

	public UI_AttackBuffDialog ConfirmDialog;

	public Transition showTip;

	public const string URL = "ui://82mo10n5qxbi8i";

	public static string Name = "UI_AddRankAttackBuffDialog";

	private int curAttackBuffNum;

	private int maxAttackBuffNum;

	public static string GetURL()
	{
		return "ui://82mo10n5qxbi8i";
	}

	public static UI_AddRankAttackBuffDialog CreateInstance()
	{
		return (UI_AddRankAttackBuffDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "AddRankAttackBuffDialog");
	}

	public static UI_AddRankAttackBuffDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddRankAttackBuffDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5qxbi8i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		ConfirmDialog = (UI_AttackBuffDialog)(object)((GComponent)this).GetChild("ConfirmDialog");
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
		curAttackBuffNum = RankDataHelper.PvpRankProgress.AttackBuffCnt;
		maxAttackBuffNum = RankDataHelper.PvPMaxAttackBuff;
		((GObject)ConfirmDialog.compoundNum).data = curAttackBuffNum;
		ConfirmDialog.DialogMiddleContent.DialogMiddleContentInit();
	}

	private void RenderMainUi()
	{
		int previewBuff = (int)((GObject)ConfirmDialog.compoundNum).data;
		RenderBuffInfo(previewBuff);
		RenderCost(previewBuff);
	}

	private void RenderBuffInfo(int previewBuff)
	{
		if (previewBuff <= 0)
		{
			ConfirmDialog.icon.url = "";
			((GObject)ConfirmDialog.tip).text = "";
			return;
		}
		List<string> attackBuffAbilities = RankDataHelper.GetAttackBuffAbilities(previewBuff - 1);
		string text = attackBuffAbilities[0];
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(text.ToString());
		ConfirmDialog.icon.LoadAbilityIcon(gDEAbilityData.Icon);
		((GObject)ConfirmDialog.tip).text = gDEAbilityData.Description;
	}

	private void RenderCost(int previewBuff)
	{
		((GObject)ConfirmDialog.compoundNum).text = $"{previewBuff}/{maxAttackBuffNum}";
		bool flag = previewBuff == curAttackBuffNum;
		((GObject)ConfirmDialog.RefreshCardBtn).enabled = !flag;
		((GObject)ConfirmDialog.DialogMiddleContent).visible = !flag;
		if (!flag)
		{
			Dictionary<string, int> attackBuffCost = RankDataHelper.GetAttackBuffCost(previewBuff - 1);
			if (((GObject)ConfirmDialog.DialogMiddleContent).visible)
			{
				bool enabled = ConfirmDialog.DialogMiddleContent.RenderDialogMiddleContent(attackBuffCost);
				((GObject)ConfirmDialog.RefreshCardBtn).enabled = enabled;
			}
		}
	}

	private void IncreaseBuff(EventContext context)
	{
		int num = (int)((GObject)ConfirmDialog.compoundNum).data;
		if (num < maxAttackBuffNum)
		{
			num++;
			((GObject)ConfirmDialog.compoundNum).data = num;
			RenderBuffInfo(num);
			RenderCost(num);
		}
	}

	private void Reduce(EventContext context)
	{
		int num = (int)((GObject)ConfirmDialog.compoundNum).data;
		if (num > curAttackBuffNum)
		{
			num--;
			((GObject)ConfirmDialog.compoundNum).data = num;
			RenderBuffInfo(num);
			RenderCost(num);
		}
	}

	private void ConfirmClickEvent()
	{
		int num = (int)((GObject)ConfirmDialog.compoundNum).data;
		int addBuffCnt = num - curAttackBuffNum;
		Action action = delegate
		{
			UI_LadderTournamentPanel.LadderTournamentPanel?.AttackStrengthen?.UpdateBuffNum();
			End();
		};
		RankDataHelper.AddAttackBuffCnt(action, addBuffCnt);
	}
}
