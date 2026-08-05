using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_dec_block05 : GComponent
{
	public UI_dec_block07 n139;

	public UI_dec_block07 n136;

	public GImage n135;

	public UI_dec_block06 n137;

	public UI_dec_block06 n138;

	public UI_dec_block08 n140;

	public UI_dec_block08 n141;

	public const string URL = "ui://th385mtt7ztlo5w";

	public static string Name = "UI_dec_block05";

	public static string GetURL()
	{
		return "ui://th385mtt7ztlo5w";
	}

	public static UI_dec_block05 CreateInstance()
	{
		return (UI_dec_block05)(object)UIPackage.CreateObject("GvGOuterTech", "dec_block05");
	}

	public static UI_dec_block05 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_block05).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtt7ztlo5w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n139 = (UI_dec_block07)(object)((GComponent)this).GetChild("n139");
		n136 = (UI_dec_block07)(object)((GComponent)this).GetChild("n136");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		n137 = (UI_dec_block06)(object)((GComponent)this).GetChild("n137");
		n138 = (UI_dec_block06)(object)((GComponent)this).GetChild("n138");
		n140 = (UI_dec_block08)(object)((GComponent)this).GetChild("n140");
		n141 = (UI_dec_block08)(object)((GComponent)this).GetChild("n141");
	}
}
