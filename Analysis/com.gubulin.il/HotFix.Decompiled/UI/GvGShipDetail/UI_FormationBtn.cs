using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_FormationBtn : GButton
{
	public Controller button;

	public GLoader formationIcon;

	public GTextField name;

	public GTextField LevelTitle;

	public GTextField Level;

	public GGroup selectPhalanxGropu;

	public const string URL = "ui://u6x0b1gnfdarb";

	public static string Name = "UI_FormationBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnfdarb";
	}

	public static UI_FormationBtn CreateInstance()
	{
		return (UI_FormationBtn)(object)UIPackage.CreateObject("GvGShipDetail", "FormationBtn");
	}

	public static UI_FormationBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FormationBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnfdarb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		formationIcon = (GLoader)((GComponent)this).GetChild("formationIcon");
		name = (GTextField)((GComponent)this).GetChild("name");
		LevelTitle = (GTextField)((GComponent)this).GetChild("LevelTitle");
		string id = "ui://u6x0b1gnfdarb".Replace("ui://", "") + "-" + ((GObject)LevelTitle).id;
		((GObject)LevelTitle).text = LanguagesManager.GetDesc(id);
		Level = (GTextField)((GComponent)this).GetChild("Level");
		selectPhalanxGropu = (GGroup)((GComponent)this).GetChild("selectPhalanxGropu");
	}
}
