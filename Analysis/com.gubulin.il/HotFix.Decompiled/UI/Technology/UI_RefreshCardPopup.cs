using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_RefreshCardPopup : GComponent
{
	public GGraph back;

	public UI_Dialog ConfirmDialog;

	public Transition showTip;

	public const string URL = "ui://7ca77a3fnwky3j";

	public static string Name = "UI_RefreshCardPopup";

	public static string GetURL()
	{
		return "ui://7ca77a3fnwky3j";
	}

	public static UI_RefreshCardPopup CreateInstance()
	{
		return (UI_RefreshCardPopup)(object)UIPackage.CreateObject("Technology", "RefreshCardPopup");
	}

	public static UI_RefreshCardPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RefreshCardPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fnwky3j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		ConfirmDialog = (UI_Dialog)(object)((GComponent)this).GetChild("ConfirmDialog");
		showTip = ((GComponent)this).GetTransition("showTip");
	}
}
