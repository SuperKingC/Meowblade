using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_dec_ForgeProgress : GComponent
{
	public GImage n20;

	public const string URL = "ui://h09dvkcgrtmo20";

	public static string Name = "UI_dec_ForgeProgress";

	public static string GetURL()
	{
		return "ui://h09dvkcgrtmo20";
	}

	public static UI_dec_ForgeProgress CreateInstance()
	{
		return (UI_dec_ForgeProgress)(object)UIPackage.CreateObject("LegendItemBlueprint", "dec_ForgeProgress");
	}

	public static UI_dec_ForgeProgress CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_ForgeProgress).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgrtmo20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n20 = (GImage)((GComponent)this).GetChild("n20");
	}
}
