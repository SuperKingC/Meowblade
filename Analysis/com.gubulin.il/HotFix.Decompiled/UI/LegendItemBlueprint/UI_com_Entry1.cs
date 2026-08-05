using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_Entry1 : GComponent
{
	public Controller Type;

	public GImage n0;

	public GImage n5;

	public GRichTextField NewEntry;

	public GRichTextField OldEntry;

	public GImage n4;

	public const string URL = "ui://h09dvkcgqz9p3w";

	public static string Name = "UI_com_Entry1";

	public static string GetURL()
	{
		return "ui://h09dvkcgqz9p3w";
	}

	public static UI_com_Entry1 CreateInstance()
	{
		return (UI_com_Entry1)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_Entry1");
	}

	public static UI_com_Entry1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Entry1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgqz9p3w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		NewEntry = (GRichTextField)((GComponent)this).GetChild("NewEntry");
		OldEntry = (GRichTextField)((GComponent)this).GetChild("OldEntry");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
