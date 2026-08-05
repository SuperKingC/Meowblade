using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_dec_block07 : GComponent
{
	public GImage n139;

	public GImage n140;

	public GImage n141;

	public GGroup n142;

	public Transition t0;

	public const string URL = "ui://th385mtt7ztlo5y";

	public static string Name = "UI_dec_block07";

	public static string GetURL()
	{
		return "ui://th385mtt7ztlo5y";
	}

	public static UI_dec_block07 CreateInstance()
	{
		return (UI_dec_block07)(object)UIPackage.CreateObject("GvGOuterTech", "dec_block07");
	}

	public static UI_dec_block07 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_block07).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtt7ztlo5y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n139 = (GImage)((GComponent)this).GetChild("n139");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		n142 = (GGroup)((GComponent)this).GetChild("n142");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
