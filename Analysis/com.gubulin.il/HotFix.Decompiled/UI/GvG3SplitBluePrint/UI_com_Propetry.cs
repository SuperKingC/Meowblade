using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_com_Propetry : GComponent
{
	public Controller Type;

	public Controller State;

	public GImage line;

	public GImage n6;

	public GImage n8;

	public GImage n7;

	public GImage n9;

	public GRichTextField content;

	public const string URL = "ui://7uylntmmkq2d12";

	public static string Name = "UI_com_Propetry";

	public static string GetURL()
	{
		return "ui://7uylntmmkq2d12";
	}

	public static UI_com_Propetry CreateInstance()
	{
		return (UI_com_Propetry)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "com_Propetry");
	}

	public static UI_com_Propetry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Propetry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmkq2d12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		line = (GImage)((GComponent)this).GetChild("line");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		content = (GRichTextField)((GComponent)this).GetChild("content");
	}
}
