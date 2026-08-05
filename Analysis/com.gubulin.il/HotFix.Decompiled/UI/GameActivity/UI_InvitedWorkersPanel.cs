using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_InvitedWorkersPanel : GComponent
{
	public GGraph Mask;

	public UI_InvitedWorkersDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://29q48tv6h95m2o";

	public static string Name = "UI_InvitedWorkersPanel";

	public static string GetURL()
	{
		return "ui://29q48tv6h95m2o";
	}

	public static UI_InvitedWorkersPanel CreateInstance()
	{
		return (UI_InvitedWorkersPanel)(object)UIPackage.CreateObject("GameActivity", "InvitedWorkersPanel");
	}

	public static UI_InvitedWorkersPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InvitedWorkersPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6h95m2o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_InvitedWorkersDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}
