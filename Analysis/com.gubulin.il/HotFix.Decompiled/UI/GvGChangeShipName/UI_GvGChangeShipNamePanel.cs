using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvGChangeShipName;

public class UI_GvGChangeShipNamePanel : GComponent, IUiController
{
	public GLoader background;

	public GGraph Mask;

	public GImage n1;

	public GImage n10;

	public GTextField n13;

	public GTextInput NameInput;

	public UI_ConfirmNameBtn ChangeNameBtn;

	public const string URL = "ui://3pjle3p4ntp93n";

	public static string Name = "UI_GvGChangeShipNamePanel";

	private UICallbackParam<Action<string>> OnConfirm;

	private string ShipId;

	public static string GetURL()
	{
		return "ui://3pjle3p4ntp93n";
	}

	public static UI_GvGChangeShipNamePanel CreateInstance()
	{
		return (UI_GvGChangeShipNamePanel)(object)UIPackage.CreateObject("GvGChangeShipName", "GvGChangeShipNamePanel");
	}

	public static UI_GvGChangeShipNamePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGChangeShipNamePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3pjle3p4ntp93n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id = "ui://3pjle3p4ntp93n".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id);
		NameInput = (GTextInput)((GComponent)this).GetChild("NameInput");
		ChangeNameBtn = (UI_ConfirmNameBtn)(object)((GComponent)this).GetChild("ChangeNameBtn");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("ShipId", out var value))
		{
			ShipId = value.ToString();
			GvGMode3ShipModel myShipData = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(ShipId);
			((GObject)NameInput).text = myShipData.PermanentData.ShipName.ToRealShipName();
		}
		if (parameters.TryGetValue("OnConfirm", out var value2))
		{
			OnConfirm = (UICallbackParam<Action<string>>)value2;
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)ChangeNameBtn).onClick.Add(new EventCallback0(ConfirmAndChange));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)ChangeNameBtn).onClick.Clear();
	}

	private void ConfirmAndChange()
	{
		Singleton<GvGMode3RoomManager>.Instance.ChangeShipName(ShipId, ((GObject)NameInput).text, delegate(string newName)
		{
			OnConfirm?.Callback?.Invoke(newName);
			End();
		});
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
