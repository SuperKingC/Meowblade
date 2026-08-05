using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_QualifiedSoldierIconMiddle : GButton
{
	public Controller button;

	public Controller Status;

	public GImage n7;

	public GGraph spineBack;

	public const string URL = "ui://avplaivdiqflt5y";

	public static string Name = "UI_QualifiedSoldierIconMiddle";

	public static string GetURL()
	{
		return "ui://avplaivdiqflt5y";
	}

	public static UI_QualifiedSoldierIconMiddle CreateInstance()
	{
		return (UI_QualifiedSoldierIconMiddle)(object)UIPackage.CreateObject("Contract", "QualifiedSoldierIconMiddle");
	}

	public static UI_QualifiedSoldierIconMiddle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QualifiedSoldierIconMiddle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdiqflt5y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GImage)((GComponent)this).GetChild("n7");
		spineBack = (GGraph)((GComponent)this).GetChild("spineBack");
	}
}
