using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPurification3;

public class UI_dec_02 : GComponent
{
	public GImage n1;

	public GImage n6;

	public UI_dec_light01 n10;

	public UI_dec_light02 n9;

	public GImage n8;

	public GImage n2;

	public GImage n5;

	public GImage n3;

	public GImage n4;

	public GImage n7;

	public GImage n11;

	public GImage n12;

	public GImage n13;

	public GImage n14;

	public Transition t0;

	public const string URL = "ui://v7vqvgvmzs6gm4";

	public static string Name = "UI_dec_02";

	public static string GetURL()
	{
		return "ui://v7vqvgvmzs6gm4";
	}

	public static UI_dec_02 CreateInstance()
	{
		return (UI_dec_02)(object)UIPackage.CreateObject("GvGPurification3", "dec_02");
	}

	public static UI_dec_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmzs6gm4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
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
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n10 = (UI_dec_light01)(object)((GComponent)this).GetChild("n10");
		n9 = (UI_dec_light02)(object)((GComponent)this).GetChild("n9");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
