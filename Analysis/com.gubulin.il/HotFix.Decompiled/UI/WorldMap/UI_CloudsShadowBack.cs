using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_CloudsShadowBack : GComponent
{
	public GImage ForestMist_Shadow;

	public GImage Marsh_Shadow;

	public GImage Jungle_Shadow;

	public GImage WildFronts_Shadow;

	public GImage ScreamGorge_Shadow;

	public GImage KeelField_Shadow;

	public GImage ImpasseFortress_Shadow;

	public GImage DesertAncientCity_Shadow;

	public GImage RedRockPlateau_Shadow;

	public GImage DoomsdayIslands_Shadow;

	public GImage FrigidMountains_Shadow;

	public GImage cloud_shadow_outside_1;

	public GImage cloud_shadow_outside_2;

	public GImage cloud_shadow_outside_3;

	public GImage cloud_shadow_outside_4;

	public GImage cloud_shadow_outside_5;

	public GGroup outsideGroup;

	public const string URL = "ui://c9n2h0ksm7wz9g";

	public static string Name = "UI_CloudsShadowBack";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz9g";
	}

	public static UI_CloudsShadowBack CreateInstance()
	{
		return (UI_CloudsShadowBack)(object)UIPackage.CreateObject("WorldMap", "CloudsShadowBack");
	}

	public static UI_CloudsShadowBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CloudsShadowBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz9g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		ForestMist_Shadow = (GImage)((GComponent)this).GetChild("ForestMist_Shadow");
		Marsh_Shadow = (GImage)((GComponent)this).GetChild("Marsh_Shadow");
		Jungle_Shadow = (GImage)((GComponent)this).GetChild("Jungle_Shadow");
		WildFronts_Shadow = (GImage)((GComponent)this).GetChild("WildFronts_Shadow");
		ScreamGorge_Shadow = (GImage)((GComponent)this).GetChild("ScreamGorge_Shadow");
		KeelField_Shadow = (GImage)((GComponent)this).GetChild("KeelField_Shadow");
		ImpasseFortress_Shadow = (GImage)((GComponent)this).GetChild("ImpasseFortress_Shadow");
		DesertAncientCity_Shadow = (GImage)((GComponent)this).GetChild("DesertAncientCity_Shadow");
		RedRockPlateau_Shadow = (GImage)((GComponent)this).GetChild("RedRockPlateau_Shadow");
		DoomsdayIslands_Shadow = (GImage)((GComponent)this).GetChild("DoomsdayIslands_Shadow");
		FrigidMountains_Shadow = (GImage)((GComponent)this).GetChild("FrigidMountains_Shadow");
		cloud_shadow_outside_1 = (GImage)((GComponent)this).GetChild("cloud_shadow_outside_1");
		cloud_shadow_outside_2 = (GImage)((GComponent)this).GetChild("cloud_shadow_outside_2");
		cloud_shadow_outside_3 = (GImage)((GComponent)this).GetChild("cloud_shadow_outside_3");
		cloud_shadow_outside_4 = (GImage)((GComponent)this).GetChild("cloud_shadow_outside_4");
		cloud_shadow_outside_5 = (GImage)((GComponent)this).GetChild("cloud_shadow_outside_5");
		outsideGroup = (GGroup)((GComponent)this).GetChild("outsideGroup");
	}
}
