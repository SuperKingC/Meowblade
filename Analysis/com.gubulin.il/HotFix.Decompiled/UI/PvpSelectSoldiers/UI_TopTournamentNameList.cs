using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentNameList : GComponent, IUiController
{
	public GGraph Mask;

	public UI_TopTournamentNameListDialog Dialog;

	public const string URL = "ui://82mo10n5aveldh4";

	public static string Name = "UI_TopTournamentNameList";

	private UI_TopTournamentNameList TopTournamentNameList;

	public static string GetURL()
	{
		return "ui://82mo10n5aveldh4";
	}

	public static UI_TopTournamentNameList CreateInstance()
	{
		return (UI_TopTournamentNameList)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentNameList");
	}

	public static UI_TopTournamentNameList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentNameList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldh4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_TopTournamentNameListDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
		TopTournamentNameList = null;
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_TopTournamentNameListDialog.Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		TopTournamentNameList = this;
		object value;
		int changeId = (parameters.TryGetValue("ChangeId", out value) ? ((int)value) : (-1));
		InitPanel(changeId);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private async void InitPanel(int changeId)
	{
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		await Dialog.Init();
		if (changeId <= -1)
		{
			uiService.ShowWaitingAnimation(show: false);
			uiService.ClearUiTouchable();
		}
		else
		{
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
		}
	}
}
