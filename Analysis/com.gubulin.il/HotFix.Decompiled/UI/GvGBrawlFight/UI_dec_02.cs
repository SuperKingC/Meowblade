using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_dec_02 : GComponent
{
	public GImage n35;

	public GImage n36;

	public GImage n37;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public const string URL = "ui://hozu168riwm74f";

	public static string Name = "UI_dec_02";

	public static string GetURL()
	{
		return "ui://hozu168riwm74f";
	}

	public static UI_dec_02 CreateInstance()
	{
		return (UI_dec_02)(object)UIPackage.CreateObject("GvGBrawlFight", "dec_02");
	}

	public static UI_dec_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168riwm74f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
	}
}
