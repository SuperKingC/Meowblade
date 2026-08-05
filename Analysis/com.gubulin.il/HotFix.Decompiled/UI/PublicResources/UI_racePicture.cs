using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_racePicture : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public GImage n11;

	public GImage n12;

	public const string URL = "ui://kt6rg65oldghti6";

	public static string Name = "UI_racePicture";

	public static string GetURL()
	{
		return "ui://kt6rg65oldghti6";
	}

	public static UI_racePicture CreateInstance()
	{
		return (UI_racePicture)(object)UIPackage.CreateObject("PublicResources", "racePicture");
	}

	public static UI_racePicture CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_racePicture).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oldghti6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
