using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_ShowRankBattleBuff : GComponent, IUiController
{
	public UI_AttackBuffBtn AttackBuff;

	public UI_DefenseBuffBtn DefenseBuff;

	public GGraph Mask;

	public UI_SkillDialog SkillDialog;

	public const string URL = "ui://82mo10n5lt7m8r";

	public static string Name = "UI_ShowRankBattleBuff";

	public static UI_ShowRankBattleBuff ShowRankBattleBuffPanel;

	private int myAttackBuffNum;

	private string attackBuffId;

	private string defenseBuffId;

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m8r";
	}

	public static UI_ShowRankBattleBuff CreateInstance()
	{
		return (UI_ShowRankBattleBuff)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ShowRankBattleBuff");
	}

	public static UI_ShowRankBattleBuff CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShowRankBattleBuff).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m8r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		AttackBuff = (UI_AttackBuffBtn)(object)((GComponent)this).GetChild("AttackBuff");
		DefenseBuff = (UI_DefenseBuffBtn)(object)((GComponent)this).GetChild("DefenseBuff");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		SkillDialog = (UI_SkillDialog)(object)((GComponent)this).GetChild("SkillDialog");
	}

	public void BeforeDestroy()
	{
		ShowRankBattleBuffPanel = null;
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		ShowRankBattleBuffPanel = this;
		DataInit(parameters);
		RenderMainUi();
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
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)AttackBuff).onClick.Add(new EventCallback0(AttackBuffInfo));
		((GObject)DefenseBuff).onClick.Add(new EventCallback0(DefenseBuffInfo));
		((GObject)Mask).onClick.Add(new EventCallback0(CloseSkillDialog));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)AttackBuff).onClick.Remove(new EventCallback0(AttackBuffInfo));
		((GObject)DefenseBuff).onClick.Remove(new EventCallback0(DefenseBuffInfo));
		((GObject)Mask).onClick.Remove(new EventCallback0(CloseSkillDialog));
	}

	private void DataInit(Dictionary<string, object> parameters)
	{
		if (parameters.TryGetValue("AttackBuffNum", out var value))
		{
			myAttackBuffNum = (int)value;
		}
		if (parameters.TryGetValue("AttackBuffId", out var value2))
		{
			attackBuffId = value2.ToString();
		}
		if (parameters.TryGetValue("DefenseBuffId", out var value3))
		{
			defenseBuffId = value3.ToString();
		}
	}

	private void RenderMainUi()
	{
		((GObject)AttackBuff).visible = !string.IsNullOrEmpty(attackBuffId);
		((GObject)DefenseBuff).visible = !string.IsNullOrEmpty(defenseBuffId);
	}

	private void AttackBuffInfo()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		((GObject)Mask).visible = true;
		SkillDialog.RenderDialog(attackBuffId, ((GObject)AttackBuff).xy);
	}

	private void DefenseBuffInfo()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		((GObject)Mask).visible = true;
		Vector2 pos = default(Vector2);
		((Vector2)(ref pos))._002Ector(((GObject)DefenseBuff).x - ((GObject)SkillDialog).width, ((GObject)DefenseBuff).y);
		SkillDialog.RenderDialog(defenseBuffId, pos);
	}

	private void CloseSkillDialog()
	{
		((GObject)SkillDialog).visible = false;
		((GObject)Mask).visible = false;
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
