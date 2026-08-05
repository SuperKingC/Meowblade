using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_RecordsFilter : GButton
{
	public Controller button;

	public Controller IsAll;

	public Controller Type;

	public GImage n2;

	public GGroup n8;

	public GComponent ShipIcon;

	public GTextField Desc;

	public GGroup n6;

	public GTextField AllDesc;

	public GGroup n7;

	public const string URL = "ui://b3fc6085stwv28";

	public static string Name = "UI_com_RecordsFilter";

	public static string GetURL()
	{
		return "ui://b3fc6085stwv28";
	}

	public static UI_com_RecordsFilter CreateInstance()
	{
		return (UI_com_RecordsFilter)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_RecordsFilter");
	}

	public static UI_com_RecordsFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RecordsFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv28", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsAll = ((GComponent)this).GetController("IsAll");
		Type = ((GComponent)this).GetController("Type");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n8 = (GGroup)((GComponent)this).GetChild("n8");
		ShipIcon = (GComponent)((GComponent)this).GetChild("ShipIcon");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		n6 = (GGroup)((GComponent)this).GetChild("n6");
		AllDesc = (GTextField)((GComponent)this).GetChild("AllDesc");
		string id = "ui://b3fc6085stwv28".Replace("ui://", "") + "-" + ((GObject)AllDesc).id;
		((GObject)AllDesc).text = LanguagesManager.GetDesc(id);
		n7 = (GGroup)((GComponent)this).GetChild("n7");
	}
}
