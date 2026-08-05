using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_GoToBuild : GComponent
{
	public Controller BuildState;

	public GTextField n15;

	public GTextField n159;

	public GTextField n160;

	public GImage n161;

	public const string URL = "ui://k19peou7dnvl1x";

	public static string Name = "UI_com_GoToBuild";

	public static string GetURL()
	{
		return "ui://k19peou7dnvl1x";
	}

	public static UI_com_GoToBuild CreateInstance()
	{
		return (UI_com_GoToBuild)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_GoToBuild");
	}

	public static UI_com_GoToBuild CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GoToBuild).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl1x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BuildState = ((GComponent)this).GetController("BuildState");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://k19peou7dnvl1x".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
		n159 = (GTextField)((GComponent)this).GetChild("n159");
		string id2 = "ui://k19peou7dnvl1x".Replace("ui://", "") + "-" + ((GObject)n159).id;
		((GObject)n159).text = LanguagesManager.GetDesc(id2);
		n160 = (GTextField)((GComponent)this).GetChild("n160");
		string id3 = "ui://k19peou7dnvl1x".Replace("ui://", "") + "-" + ((GObject)n160).id;
		((GObject)n160).text = LanguagesManager.GetDesc(id3);
		n161 = (GImage)((GComponent)this).GetChild("n161");
	}
}
