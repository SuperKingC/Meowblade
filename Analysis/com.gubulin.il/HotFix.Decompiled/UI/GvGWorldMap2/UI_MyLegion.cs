using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_MyLegion : GButton
{
	public Controller CampId;

	public GImage n0;

	public UI_Avatar Avatar;

	public GImage n2;

	public GTextField SoldierCount;

	public GTextField StayIslandName;

	public GTextField State;

	public GTextField n5;

	public GLoader n8;

	public const string URL = "ui://hd2s9kukfu2633";

	public static string Name = "UI_MyLegion";

	public static string GetURL()
	{
		return "ui://hd2s9kukfu2633";
	}

	public static UI_MyLegion CreateInstance()
	{
		return (UI_MyLegion)(object)UIPackage.CreateObject("GvGWorldMap2", "MyLegion");
	}

	public static UI_MyLegion CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyLegion).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukfu2633", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		SoldierCount = (GTextField)((GComponent)this).GetChild("SoldierCount");
		StayIslandName = (GTextField)((GComponent)this).GetChild("StayIslandName");
		string id = "ui://hd2s9kukfu2633".Replace("ui://", "") + "-" + ((GObject)StayIslandName).id;
		((GObject)StayIslandName).text = LanguagesManager.GetDesc(id);
		State = (GTextField)((GComponent)this).GetChild("State");
		string id2 = "ui://hd2s9kukfu2633".Replace("ui://", "") + "-" + ((GObject)State).id;
		((GObject)State).text = LanguagesManager.GetDesc(id2);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id3 = "ui://hd2s9kukfu2633".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id3);
		n8 = (GLoader)((GComponent)this).GetChild("n8");
	}
}
