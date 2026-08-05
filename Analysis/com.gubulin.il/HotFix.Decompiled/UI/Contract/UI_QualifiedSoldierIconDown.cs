using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_QualifiedSoldierIconDown : GButton
{
	public Controller button;

	public Controller Status;

	public GImage n6;

	public GGraph spineBack;

	public const string URL = "ui://avplaivddecwt5a";

	public static string Name = "UI_QualifiedSoldierIconDown";

	public static string GetURL()
	{
		return "ui://avplaivddecwt5a";
	}

	public static UI_QualifiedSoldierIconDown CreateInstance()
	{
		return (UI_QualifiedSoldierIconDown)(object)UIPackage.CreateObject("Contract", "QualifiedSoldierIconDown");
	}

	public static UI_QualifiedSoldierIconDown CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QualifiedSoldierIconDown).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivddecwt5a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		spineBack = (GGraph)((GComponent)this).GetChild("spineBack");
	}
}
