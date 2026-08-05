using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_Islandlocation : GComponent
{
	public Controller Type;

	public Controller Step;

	public GImage n1;

	public UI_btn_IslandLocation Positioning;

	public GTextField n2;

	public GTextField n3;

	public GTextField IslandName;

	public GTextField n7;

	public GTextField n8;

	public GTextField n9;

	public GTextField n11;

	public GTextField n6;

	public GTextField n12;

	public GTextField n13;

	public GTextField n14;

	public GGroup n15;

	public const string URL = "ui://4eq8fgd2qf7c7s";

	public static string Name = "UI_com_Islandlocation";

	public static string GetURL()
	{
		return "ui://4eq8fgd2qf7c7s";
	}

	public static UI_com_Islandlocation CreateInstance()
	{
		return (UI_com_Islandlocation)(object)UIPackage.CreateObject("GvGWorldMap3", "com_Islandlocation");
	}

	public static UI_com_Islandlocation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Islandlocation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qf7c7s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Step = ((GComponent)this).GetController("Step");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Positioning = (UI_btn_IslandLocation)(object)((GComponent)this).GetChild("Positioning");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://4eq8fgd2qf7c7s".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://4eq8fgd2qf7c7s".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://4eq8fgd2qf7c7s".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://4eq8fgd2qf7c7s".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id5 = "ui://4eq8fgd2qf7c7s".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id5);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id6 = "ui://4eq8fgd2qf7c7s".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id6);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id7 = "ui://4eq8fgd2qf7c7s".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id7);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id8 = "ui://4eq8fgd2qf7c7s".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id8);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id9 = "ui://4eq8fgd2qf7c7s".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id9);
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id10 = "ui://4eq8fgd2qf7c7s".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id10);
		n15 = (GGroup)((GComponent)this).GetChild("n15");
	}
}
