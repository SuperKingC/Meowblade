using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_ReturnItemsPopup : GComponent
{
	public GGraph Mask;

	public UI_ConfirmDialog Dialog;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public Transition ShowDialog;

	public const string URL = "ui://b9yxt7u0t1jrf";

	public static string Name = "UI_ReturnItemsPopup";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jrf";
	}

	public static UI_ReturnItemsPopup CreateInstance()
	{
		return (UI_ReturnItemsPopup)(object)UIPackage.CreateObject("AccountInfo", "ReturnItemsPopup");
	}

	public static UI_ReturnItemsPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReturnItemsPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jrf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_ConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}
