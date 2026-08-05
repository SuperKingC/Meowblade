using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_OpenSoliders : GButton
{
	public Controller button;

	public Controller Status;

	public GGraph n4;

	public GImage n3;

	public const string URL = "ui://82mo10n5gwv067";

	public static string Name = "UI_OpenSoliders";

	public static string GetURL()
	{
		return "ui://82mo10n5gwv067";
	}

	public static UI_OpenSoliders CreateInstance()
	{
		return (UI_OpenSoliders)(object)UIPackage.CreateObject("PvpSelectSoldiers", "OpenSoliders");
	}

	public static UI_OpenSoliders CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OpenSoliders).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5gwv067", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
