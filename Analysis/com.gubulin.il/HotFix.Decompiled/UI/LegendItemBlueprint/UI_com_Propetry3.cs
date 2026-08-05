using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_Propetry3 : GComponent
{
	public Controller Type;

	public Controller State;

	public GImage line;

	public GImage n6;

	public GImage n8;

	public GImage n7;

	public GImage n9;

	public GRichTextField content;

	public const string URL = "ui://h09dvkcgqz9p3x";

	public static string Name = "UI_com_Propetry3";

	public static string GetURL()
	{
		return "ui://h09dvkcgqz9p3x";
	}

	public static UI_com_Propetry3 CreateInstance()
	{
		return (UI_com_Propetry3)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_Propetry3");
	}

	public static UI_com_Propetry3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Propetry3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgqz9p3x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
