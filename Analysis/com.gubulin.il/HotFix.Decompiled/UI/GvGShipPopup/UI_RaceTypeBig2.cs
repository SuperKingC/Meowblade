using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_RaceTypeBig2 : GButton
{
	public Controller button;

	public Controller IsNotAvailable;

	public GImage n14;

	public GImage n18;

	public GGroup n19;

	public GImage n15;

	public GLoader icon;

	public const string URL = "ui://pwrbvhpvirg26j";

	public static string Name = "UI_RaceTypeBig2";

	public static string GetURL()
	{
		return "ui://pwrbvhpvirg26j";
	}

	public static UI_RaceTypeBig2 CreateInstance()
	{
		return (UI_RaceTypeBig2)(object)UIPackage.CreateObject("GvGShipPopup", "RaceTypeBig2");
	}

	public static UI_RaceTypeBig2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RaceTypeBig2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvirg26j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsNotAvailable = ((GComponent)this).GetController("IsNotAvailable");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GGroup)((GComponent)this).GetChild("n19");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
