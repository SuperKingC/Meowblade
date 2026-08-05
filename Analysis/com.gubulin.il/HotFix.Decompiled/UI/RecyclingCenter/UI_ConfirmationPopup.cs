using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_ConfirmationPopup : GComponent
{
	public GGraph Mask;

	public UI_ConfirmDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://72poq8plkxix14";

	public static string Name = "UI_ConfirmationPopup";

	public static string GetURL()
	{
		return "ui://72poq8plkxix14";
	}

	public static UI_ConfirmationPopup CreateInstance()
	{
		return (UI_ConfirmationPopup)(object)UIPackage.CreateObject("RecyclingCenter", "ConfirmationPopup");
	}

	public static UI_ConfirmationPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmationPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxix14", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_ConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}
