using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_TitleGroup02 : GComponent
{
	public GImage n17;

	public GLoader n18;

	public const string URL = "ui://c9n2h0ksn62lml";

	public static string Name = "UI_TitleGroup02";

	public static string GetURL()
	{
		return "ui://c9n2h0ksn62lml";
	}

	public static UI_TitleGroup02 CreateInstance()
	{
		return (UI_TitleGroup02)(object)UIPackage.CreateObject("WorldMap", "TitleGroup02");
	}

	public static UI_TitleGroup02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TitleGroup02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksn62lml", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GLoader)((GComponent)this).GetChild("n18");
	}
}
