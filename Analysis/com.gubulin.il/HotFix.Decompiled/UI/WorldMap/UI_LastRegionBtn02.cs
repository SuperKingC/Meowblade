using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_LastRegionBtn02 : GButton
{
	public Controller button;

	public Controller c1;

	public GImage n6;

	public GTextField name;

	public GImage note;

	public GImage n7;

	public GLoader n8;

	public GImage n10;

	public GTextField n11;

	public const string URL = "ui://c9n2h0ksn62lmk";

	public static string Name = "UI_LastRegionBtn02";

	public static string GetURL()
	{
		return "ui://c9n2h0ksn62lmk";
	}

	public static UI_LastRegionBtn02 CreateInstance()
	{
		return (UI_LastRegionBtn02)(object)UIPackage.CreateObject("WorldMap", "LastRegionBtn02");
	}

	public static UI_LastRegionBtn02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LastRegionBtn02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksn62lmk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		c1 = ((GComponent)this).GetController("c1");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://c9n2h0ksn62lmk".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GLoader)((GComponent)this).GetChild("n8");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://c9n2h0ksn62lmk".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
	}
}
