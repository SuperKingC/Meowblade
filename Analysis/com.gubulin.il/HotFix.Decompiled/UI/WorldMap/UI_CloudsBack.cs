using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_CloudsBack : GComponent
{
	public GImage ForestMist_Cloud;

	public GImage Marsh_Cloud;

	public GImage Jungle_Cloud;

	public GImage WildFronts_Cloud;

	public GImage ScreamGorge_Cloud;

	public GImage KeelField_Cloud;

	public GImage ImpasseFortress_Cloud;

	public GImage DesertAncientCity_Cloud;

	public GImage RedRockPlateau_Cloud;

	public GImage DoomsdayIslands_Cloud;

	public GImage FrigidMountains_Cloud;

	public GImage cloud_outside_1;

	public GImage cloud_outside_2;

	public GImage cloud_outside_3;

	public GImage cloud_outside_4;

	public GImage cloud_outside_5;

	public GImage cloud_outside_6;

	public GImage cloud_outside_7;

	public GImage cloud_outside_8;

	public GImage cloud_outside_9;

	public const string URL = "ui://c9n2h0ksm7wz9e";

	public static string Name = "UI_CloudsBack";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz9e";
	}

	public static UI_CloudsBack CreateInstance()
	{
		return (UI_CloudsBack)(object)UIPackage.CreateObject("WorldMap", "CloudsBack");
	}

	public static UI_CloudsBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CloudsBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz9e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ForestMist_Cloud = (GImage)((GComponent)this).GetChild("ForestMist_Cloud");
		Marsh_Cloud = (GImage)((GComponent)this).GetChild("Marsh_Cloud");
		Jungle_Cloud = (GImage)((GComponent)this).GetChild("Jungle_Cloud");
		WildFronts_Cloud = (GImage)((GComponent)this).GetChild("WildFronts_Cloud");
		ScreamGorge_Cloud = (GImage)((GComponent)this).GetChild("ScreamGorge_Cloud");
		KeelField_Cloud = (GImage)((GComponent)this).GetChild("KeelField_Cloud");
		ImpasseFortress_Cloud = (GImage)((GComponent)this).GetChild("ImpasseFortress_Cloud");
		DesertAncientCity_Cloud = (GImage)((GComponent)this).GetChild("DesertAncientCity_Cloud");
		RedRockPlateau_Cloud = (GImage)((GComponent)this).GetChild("RedRockPlateau_Cloud");
		DoomsdayIslands_Cloud = (GImage)((GComponent)this).GetChild("DoomsdayIslands_Cloud");
		FrigidMountains_Cloud = (GImage)((GComponent)this).GetChild("FrigidMountains_Cloud");
		cloud_outside_1 = (GImage)((GComponent)this).GetChild("cloud_outside_1");
		cloud_outside_2 = (GImage)((GComponent)this).GetChild("cloud_outside_2");
		cloud_outside_3 = (GImage)((GComponent)this).GetChild("cloud_outside_3");
		cloud_outside_4 = (GImage)((GComponent)this).GetChild("cloud_outside_4");
		cloud_outside_5 = (GImage)((GComponent)this).GetChild("cloud_outside_5");
		cloud_outside_6 = (GImage)((GComponent)this).GetChild("cloud_outside_6");
		cloud_outside_7 = (GImage)((GComponent)this).GetChild("cloud_outside_7");
		cloud_outside_8 = (GImage)((GComponent)this).GetChild("cloud_outside_8");
		cloud_outside_9 = (GImage)((GComponent)this).GetChild("cloud_outside_9");
	}
}
