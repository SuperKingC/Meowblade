using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_DefenderInfo : GComponent
{
	public Controller Type;

	public GImage n8;

	public GList Soldiers;

	public GImage n1;

	public GTextField CurrentSoldierNum;

	public GImage n4;

	public GTextField FormationNum;

	public GGroup n7;

	public GImage n9;

	public GTextField n10;

	public const string URL = "ui://4eq8fgd2mdde2i";

	public static string Name = "UI_com_DefenderInfo";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mdde2i";
	}

	public static UI_com_DefenderInfo CreateInstance()
	{
		return (UI_com_DefenderInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_DefenderInfo");
	}

	public static UI_com_DefenderInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DefenderInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mdde2i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		Soldiers = (GList)((GComponent)this).GetChild("Soldiers");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		CurrentSoldierNum = (GTextField)((GComponent)this).GetChild("CurrentSoldierNum");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		FormationNum = (GTextField)((GComponent)this).GetChild("FormationNum");
		n7 = (GGroup)((GComponent)this).GetChild("n7");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://4eq8fgd2mdde2i".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
	}
}
