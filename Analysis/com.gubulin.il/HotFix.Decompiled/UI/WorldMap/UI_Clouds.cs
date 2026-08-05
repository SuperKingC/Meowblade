using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_Clouds : GComponent
{
	public GImage DoomsdayIslands_Cloud;

	public GImage RedRockPlateau_Cloud;

	public GImage DesertAncientCity_Cloud;

	public GImage ImpasseFortress_Cloud;

	public GImage FrigidMountains_Cloud;

	public GImage KeelField_Cloud;

	public GImage ScreamGorge_Cloud;

	public GImage WildFronts_Cloud;

	public GImage Jungle_Cloud;

	public GImage Marsh_Cloud;

	public GImage ForestMist_Cloud;

	public const string URL = "ui://c9n2h0ksm7wz9c";

	public static string Name = "UI_Clouds";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz9c";
	}

	public static UI_Clouds CreateInstance()
	{
		return (UI_Clouds)(object)UIPackage.CreateObject("WorldMap", "Clouds");
	}

	public static UI_Clouds CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Clouds).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz9c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		DoomsdayIslands_Cloud = (GImage)((GComponent)this).GetChild("DoomsdayIslands_Cloud");
		RedRockPlateau_Cloud = (GImage)((GComponent)this).GetChild("RedRockPlateau_Cloud");
		DesertAncientCity_Cloud = (GImage)((GComponent)this).GetChild("DesertAncientCity_Cloud");
		ImpasseFortress_Cloud = (GImage)((GComponent)this).GetChild("ImpasseFortress_Cloud");
		FrigidMountains_Cloud = (GImage)((GComponent)this).GetChild("FrigidMountains_Cloud");
		KeelField_Cloud = (GImage)((GComponent)this).GetChild("KeelField_Cloud");
		ScreamGorge_Cloud = (GImage)((GComponent)this).GetChild("ScreamGorge_Cloud");
		WildFronts_Cloud = (GImage)((GComponent)this).GetChild("WildFronts_Cloud");
		Jungle_Cloud = (GImage)((GComponent)this).GetChild("Jungle_Cloud");
		Marsh_Cloud = (GImage)((GComponent)this).GetChild("Marsh_Cloud");
		ForestMist_Cloud = (GImage)((GComponent)this).GetChild("ForestMist_Cloud");
	}
}
