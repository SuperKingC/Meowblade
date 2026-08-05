using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_dec_light02 : GComponent
{
	public GImage n4;

	public UI_dec_light01 n5;

	public UI_dec_light01 n6;

	public UI_dec_light01 n7;

	public UI_dec_light01 n8;

	public UI_dec_light01 n9;

	public UI_dec_light01 n10;

	public UI_dec_light01 n11;

	public Transition light;

	public const string URL = "ui://4eq8fgd29m6ysas";

	public static string Name = "UI_dec_light02";

	public static string GetURL()
	{
		return "ui://4eq8fgd29m6ysas";
	}

	public static UI_dec_light02 CreateInstance()
	{
		return (UI_dec_light02)(object)UIPackage.CreateObject("GvGWorldMap3", "dec_light02");
	}

	public static UI_dec_light02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd29m6ysas", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (UI_dec_light01)(object)((GComponent)this).GetChild("n5");
		n6 = (UI_dec_light01)(object)((GComponent)this).GetChild("n6");
		n7 = (UI_dec_light01)(object)((GComponent)this).GetChild("n7");
		n8 = (UI_dec_light01)(object)((GComponent)this).GetChild("n8");
		n9 = (UI_dec_light01)(object)((GComponent)this).GetChild("n9");
		n10 = (UI_dec_light01)(object)((GComponent)this).GetChild("n10");
		n11 = (UI_dec_light01)(object)((GComponent)this).GetChild("n11");
		light = ((GComponent)this).GetTransition("light");
	}
}
