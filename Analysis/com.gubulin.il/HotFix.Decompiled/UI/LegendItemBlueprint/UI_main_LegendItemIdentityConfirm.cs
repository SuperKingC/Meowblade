using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.LegendItemBlueprint;

public class UI_main_LegendItemIdentityConfirm : GComponent, IUiController
{
	private enum DialogType
	{
		ForgeConfirm,
		PutOnConfirm
	}

	public GGraph Mask;

	public UI_com_LegendItemIdentityConfirm Dialog;

	public const string URL = "ui://h09dvkcgaz6v4c";

	public static string Name = "UI_main_LegendItemIdentityConfirm";

	private Action ConfirmAction;

	private DialogType dialogType;

	public static string GetURL()
	{
		return "ui://h09dvkcgaz6v4c";
	}

	public static UI_main_LegendItemIdentityConfirm CreateInstance()
	{
		return (UI_main_LegendItemIdentityConfirm)(object)UIPackage.CreateObject("LegendItemBlueprint", "main_LegendItemIdentityConfirm");
	}

	public static UI_main_LegendItemIdentityConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LegendItemIdentityConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgaz6v4c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_LegendItemIdentityConfirm)(object)((GComponent)this).GetChild("Dialog");
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
		ConfirmAction = (parameters.TryGetValue("ConfirmAction", out var value) ? (value as Action) : null);
		dialogType = (parameters.TryGetValue("DialogType", out var value2) ? ((DialogType)Enum.ToObject(typeof(DialogType), (int)value2)) : DialogType.ForgeConfirm);
		switch (dialogType)
		{
		case DialogType.ForgeConfirm:
			Dialog.Type.selectedIndex = 0;
			break;
		case DialogType.PutOnConfirm:
			Dialog.Type.selectedIndex = 1;
			break;
		}
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
		((GObject)Dialog.Cancel).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback0(Confirm));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.Cancel).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(Confirm));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Confirm()
	{
		ConfirmAction?.Invoke();
		End();
	}
}
