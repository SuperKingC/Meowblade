using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

namespace UI.Tips;

public class UI_UndergroundCityUpGrade : GComponent, IUiController
{
	public GGraph mask;

	public UI_LordUpgradeTipDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://47lbpgx9mixq6";

	public static string Name = "UI_UndergroundCityUpGrade";

	public static string GetURL()
	{
		return "ui://47lbpgx9mixq6";
	}

	public static UI_UndergroundCityUpGrade CreateInstance()
	{
		return (UI_UndergroundCityUpGrade)(object)UIPackage.CreateObject("Tips", "UndergroundCityUpGrade");
	}

	public static UI_UndergroundCityUpGrade CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UndergroundCityUpGrade).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9mixq6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_LordUpgradeTipDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 103;
		((GObject)Dialog.levelNum).text = string.Format(LanguagesManager.GetDesc("DungeonLevelUp-LevelText"), new object[1] { GameManagers.Instance.UserArchiveManager.GetDungeonLevel() });
		((GObject)Dialog.tip2).text = string.Format(LanguagesManager.GetDesc("DungeonLevelUp-TipText"), new object[1] { (int)parameters["LastLimit"] });
		((GObject)Dialog.tip3).text = string.Format("{0}", (int)parameters["CurLimit"]);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.ConfirmBtn).onClick.Remove(new EventCallback0(End));
	}

	public void OnShow()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		ShowDialog.Play((PlayCompleteCallback)delegate
		{
			Dialog.showDial.Play();
		});
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
