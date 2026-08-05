using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_Map : GComponent
{
	public GImage Sea1;

	public UI_Unknown1 Unknown1;

	public UI_ForestMist ForestMist;

	public UI_Marsh Marsh;

	public UI_Jungle Jungle;

	public UI_WildFronts WildFronts;

	public UI_ScreamGorge ScreamGorge;

	public UI_KeelField KeelField;

	public UI_FrigidMountains FrigidMountains;

	public UI_ImpasseFortress ImpasseFortress;

	public UI_DesertAncientCity DesertAncientCity;

	public UI_RedRockPlateau RedRockPlateau;

	public UI_DoomsdayIslands DoomsdayIslands;

	public UI_Unknown2 Unknown2;

	public UI_AreaHighlightLoader AreaHighlightLoader;

	public GImage n48;

	public GImage n49;

	public GImage n50;

	public GImage n51;

	public GImage n52;

	public GImage n53;

	public GImage n54;

	public GImage n55;

	public GImage n57;

	public GImage n58;

	public GImage n59;

	public GImage n60;

	public GImage lighthouseLight;

	public GImage GaussianBlur;

	public UI_CloudsAnimation CloudsAnimation;

	public UI_Clouds Clouds;

	public GMovieClip n61;

	public GMovieClip n62;

	public UI_UILayer UILayer;

	public GGraph ForestMist_pos;

	public GGraph Marsh_pos;

	public GGraph Jungle_pos;

	public GGraph WildFronts_pos;

	public GGraph ScreamGorge_pos;

	public GGraph KeelField_pos;

	public GGraph FrigidMountains_pos;

	public GGraph ImpasseFortress_pos;

	public GGraph DesertAncientCity_pos;

	public GGraph RedRockPlateau_pos;

	public GGraph DoomsdayIslands_pos;

	public Transition Loop;

	public const string URL = "ui://c9n2h0ksm7wz9p";

	public static string Name = "UI_Map";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz9p";
	}

	public static UI_Map CreateInstance()
	{
		return (UI_Map)(object)UIPackage.CreateObject("WorldMap", "Map");
	}

	public static UI_Map CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Map).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz9p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
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
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected O, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Sea1 = (GImage)((GComponent)this).GetChild("Sea1");
		Unknown1 = (UI_Unknown1)(object)((GComponent)this).GetChild("Unknown1");
		ForestMist = (UI_ForestMist)(object)((GComponent)this).GetChild("ForestMist");
		Marsh = (UI_Marsh)(object)((GComponent)this).GetChild("Marsh");
		Jungle = (UI_Jungle)(object)((GComponent)this).GetChild("Jungle");
		WildFronts = (UI_WildFronts)(object)((GComponent)this).GetChild("WildFronts");
		ScreamGorge = (UI_ScreamGorge)(object)((GComponent)this).GetChild("ScreamGorge");
		KeelField = (UI_KeelField)(object)((GComponent)this).GetChild("KeelField");
		FrigidMountains = (UI_FrigidMountains)(object)((GComponent)this).GetChild("FrigidMountains");
		ImpasseFortress = (UI_ImpasseFortress)(object)((GComponent)this).GetChild("ImpasseFortress");
		DesertAncientCity = (UI_DesertAncientCity)(object)((GComponent)this).GetChild("DesertAncientCity");
		RedRockPlateau = (UI_RedRockPlateau)(object)((GComponent)this).GetChild("RedRockPlateau");
		DoomsdayIslands = (UI_DoomsdayIslands)(object)((GComponent)this).GetChild("DoomsdayIslands");
		Unknown2 = (UI_Unknown2)(object)((GComponent)this).GetChild("Unknown2");
		AreaHighlightLoader = (UI_AreaHighlightLoader)(object)((GComponent)this).GetChild("AreaHighlightLoader");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		lighthouseLight = (GImage)((GComponent)this).GetChild("lighthouseLight");
		GaussianBlur = (GImage)((GComponent)this).GetChild("GaussianBlur");
		CloudsAnimation = (UI_CloudsAnimation)(object)((GComponent)this).GetChild("CloudsAnimation");
		Clouds = (UI_Clouds)(object)((GComponent)this).GetChild("Clouds");
		n61 = (GMovieClip)((GComponent)this).GetChild("n61");
		n62 = (GMovieClip)((GComponent)this).GetChild("n62");
		UILayer = (UI_UILayer)(object)((GComponent)this).GetChild("UILayer");
		ForestMist_pos = (GGraph)((GComponent)this).GetChild("ForestMist_pos");
		Marsh_pos = (GGraph)((GComponent)this).GetChild("Marsh_pos");
		Jungle_pos = (GGraph)((GComponent)this).GetChild("Jungle_pos");
		WildFronts_pos = (GGraph)((GComponent)this).GetChild("WildFronts_pos");
		ScreamGorge_pos = (GGraph)((GComponent)this).GetChild("ScreamGorge_pos");
		KeelField_pos = (GGraph)((GComponent)this).GetChild("KeelField_pos");
		FrigidMountains_pos = (GGraph)((GComponent)this).GetChild("FrigidMountains_pos");
		ImpasseFortress_pos = (GGraph)((GComponent)this).GetChild("ImpasseFortress_pos");
		DesertAncientCity_pos = (GGraph)((GComponent)this).GetChild("DesertAncientCity_pos");
		RedRockPlateau_pos = (GGraph)((GComponent)this).GetChild("RedRockPlateau_pos");
		DoomsdayIslands_pos = (GGraph)((GComponent)this).GetChild("DoomsdayIslands_pos");
		Loop = ((GComponent)this).GetTransition("Loop");
	}
}
