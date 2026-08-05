using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;

namespace UI.IslandComeAgain;

public class UI_TroopsChangeConfirmPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_TroopsChangeConfirmDialog Dialog;

	public const string URL = "ui://k2sprg26fuww8t";

	public static string Name = "UI_TroopsChangeConfirmPanel";

	public static string GetURL()
	{
		return "ui://k2sprg26fuww8t";
	}

	public static UI_TroopsChangeConfirmPanel CreateInstance()
	{
		return (UI_TroopsChangeConfirmPanel)(object)UIPackage.CreateObject("IslandComeAgain", "TroopsChangeConfirmPanel");
	}

	public static UI_TroopsChangeConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TroopsChangeConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26fuww8t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_TroopsChangeConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
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
		((GObject)Dialog.Confirm).data = true;
		((GObject)Dialog.Close).data = false;
		ShowGroupInfo();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback1(ConfirmEvent));
		((GObject)Dialog.Close).onClick.Add(new EventCallback1(ConfirmEvent));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnBattleEnd);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback1(ConfirmEvent));
		((GObject)Dialog.Close).onClick.Remove(new EventCallback1(ConfirmEvent));
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnBattleEnd);
	}

	private void ConfirmEvent(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		bool arg = (bool)((GObject)context.sender).data;
		SharedMessenger.Broadcast("ISLAND_COME_AGAIN_LEGION_CHANGE_CONFIRM", arg);
		End();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void OnBattleEnd(string uiName)
	{
		if (string.Equals(uiName, UI_IslandComeAgainBattleResultPanel.Name))
		{
			End();
		}
	}

	private void ShowGroupInfo()
	{
		List<ShipSummaryUnitInfo> oldUnitInfo = Singleton<GvGInstanceZone>.Instance.OldUnitInfo;
		List<ShipSummaryUnitInfo> curSoldiers = ((oldUnitInfo != null && oldUnitInfo.Count <= 0) ? Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo : Singleton<GvGInstanceZone>.Instance.OldUnitInfo);
		Dialog.OldGroupInfo.SetOurPos(Singleton<GvGInstanceZone>.Instance.OldFormationId, curSoldiers, isOld: true);
		Dialog.CurrentGroupInfo.SetOurPos(Singleton<GvGInstanceZone>.Instance.FormationId, Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo);
	}
}
