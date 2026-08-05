using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_dec_block04 : GComponent
{
	public GImage n141;

	public GImage n142;

	public GGroup n143;

	public Transition t0;

	public const string URL = "ui://h09dvkcgr0qr5ltf1";

	public static string Name = "UI_dec_block04";

	public static string GetURL()
	{
		return "ui://h09dvkcgr0qr5ltf1";
	}

	public static UI_dec_block04 CreateInstance()
	{
		return (UI_dec_block04)(object)UIPackage.CreateObject("LegendItemBlueprint", "dec_block04");
	}

	public static UI_dec_block04 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_block04).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgr0qr5ltf1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n141 = (GImage)((GComponent)this).GetChild("n141");
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n143 = (GGroup)((GComponent)this).GetChild("n143");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
