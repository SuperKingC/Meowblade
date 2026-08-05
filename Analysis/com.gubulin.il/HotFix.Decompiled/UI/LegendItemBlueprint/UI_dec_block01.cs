using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_dec_block01 : GComponent
{
	public UI_dec_block03 n139;

	public UI_dec_block03 n143;

	public GImage n137;

	public UI_dec_block02 n138;

	public UI_dec_block02 n144;

	public UI_dec_block04 n141;

	public UI_dec_block04 n142;

	public const string URL = "ui://h09dvkcgr0qr5ltev";

	public static string Name = "UI_dec_block01";

	public static string GetURL()
	{
		return "ui://h09dvkcgr0qr5ltev";
	}

	public static UI_dec_block01 CreateInstance()
	{
		return (UI_dec_block01)(object)UIPackage.CreateObject("LegendItemBlueprint", "dec_block01");
	}

	public static UI_dec_block01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_block01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgr0qr5ltev", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n139 = (UI_dec_block03)(object)((GComponent)this).GetChild("n139");
		n143 = (UI_dec_block03)(object)((GComponent)this).GetChild("n143");
		n137 = (GImage)((GComponent)this).GetChild("n137");
		n138 = (UI_dec_block02)(object)((GComponent)this).GetChild("n138");
		n144 = (UI_dec_block02)(object)((GComponent)this).GetChild("n144");
		n141 = (UI_dec_block04)(object)((GComponent)this).GetChild("n141");
		n142 = (UI_dec_block04)(object)((GComponent)this).GetChild("n142");
	}
}
