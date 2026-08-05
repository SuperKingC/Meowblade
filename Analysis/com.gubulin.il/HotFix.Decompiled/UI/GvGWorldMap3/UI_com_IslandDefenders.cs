using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_IslandDefenders : GComponent
{
	public Controller Obedience;

	public Controller Buff;

	public GImage n0;

	public GImage n16;

	public GTextField Title;

	public GImage n23;

	public GList Soldiers;

	public GImage n14;

	public GLoader ObedienceIcon;

	public GTextField ObedienceValue;

	public GTextField Obedience0;

	public GGroup n12;

	public GTextField n7;

	public GList Abilities;

	public GGroup n15;

	public GImage n17;

	public GTextField AverageCombatPower;

	public GTextField ResurrectionCountdown;

	public GTextField n24;

	public const string URL = "ui://4eq8fgd2mdde25";

	public static string Name = "UI_com_IslandDefenders";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mdde25";
	}

	public static UI_com_IslandDefenders CreateInstance()
	{
		return (UI_com_IslandDefenders)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandDefenders");
	}

	public static UI_com_IslandDefenders CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandDefenders).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mdde25", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Obedience = ((GComponent)this).GetController("Obedience");
		Buff = ((GComponent)this).GetController("Buff");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		Soldiers = (GList)((GComponent)this).GetChild("Soldiers");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		ObedienceIcon = (GLoader)((GComponent)this).GetChild("ObedienceIcon");
		ObedienceValue = (GTextField)((GComponent)this).GetChild("ObedienceValue");
		Obedience0 = (GTextField)((GComponent)this).GetChild("Obedience0");
		string id = "ui://4eq8fgd2mdde25".Replace("ui://", "") + "-" + ((GObject)Obedience0).id;
		((GObject)Obedience0).text = LanguagesManager.GetDesc(id);
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://4eq8fgd2mdde25".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		Abilities = (GList)((GComponent)this).GetChild("Abilities");
		n15 = (GGroup)((GComponent)this).GetChild("n15");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		AverageCombatPower = (GTextField)((GComponent)this).GetChild("AverageCombatPower");
		ResurrectionCountdown = (GTextField)((GComponent)this).GetChild("ResurrectionCountdown");
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id3 = "ui://4eq8fgd2mdde25".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id3);
	}
}
