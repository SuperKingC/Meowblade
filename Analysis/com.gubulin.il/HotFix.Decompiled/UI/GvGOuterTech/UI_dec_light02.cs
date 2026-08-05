using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_dec_light02 : GComponent
{
	public GImage n63;

	public GImage n64;

	public GImage n65;

	public GImage n66;

	public GImage n67;

	public GImage n68;

	public GImage n69;

	public GImage n70;

	public Transition t0;

	public const string URL = "ui://th385mtt7ztlo61";

	public static string Name = "UI_dec_light02";

	public static string GetURL()
	{
		return "ui://th385mtt7ztlo61";
	}

	public static UI_dec_light02 CreateInstance()
	{
		return (UI_dec_light02)(object)UIPackage.CreateObject("GvGOuterTech", "dec_light02");
	}

	public static UI_dec_light02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtt7ztlo61", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
