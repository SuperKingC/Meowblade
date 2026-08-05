using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_occupationePicture : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n3;

	public GImage n4;

	public GImage n5;

	public GImage n6;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public const string URL = "ui://kt6rg65omimfv4s7";

	public static string Name = "UI_occupationePicture";

	public static string GetURL()
	{
		return "ui://kt6rg65omimfv4s7";
	}

	public static UI_occupationePicture CreateInstance()
	{
		return (UI_occupationePicture)(object)UIPackage.CreateObject("PublicResources", "occupationePicture");
	}

	public static UI_occupationePicture CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_occupationePicture).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65omimfv4s7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
