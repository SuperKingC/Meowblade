using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_dec_light03 : GComponent
{
	public GImage n77;

	public GImage n79;

	public GImage n80;

	public GImage n82;

	public GImage n84;

	public GGroup n86;

	public GImage n78;

	public GImage n81;

	public GImage n83;

	public GImage n85;

	public GGroup n87;

	public Transition t0;

	public const string URL = "ui://th385mtt7ztlo66";

	public static string Name = "UI_dec_light03";

	public static string GetURL()
	{
		return "ui://th385mtt7ztlo66";
	}

	public static UI_dec_light03 CreateInstance()
	{
		return (UI_dec_light03)(object)UIPackage.CreateObject("GvGOuterTech", "dec_light03");
	}

	public static UI_dec_light03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtt7ztlo66", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		n80 = (GImage)((GComponent)this).GetChild("n80");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n86 = (GGroup)((GComponent)this).GetChild("n86");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n87 = (GGroup)((GComponent)this).GetChild("n87");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
