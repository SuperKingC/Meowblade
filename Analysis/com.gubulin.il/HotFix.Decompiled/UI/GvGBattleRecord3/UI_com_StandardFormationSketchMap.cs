using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_StandardFormationSketchMap : GComponent
{
	public UI_com_PvpFormationBack Background;

	public GComponent DraggingIcon;

	public UI_btn_SoldierFormation OurFormation0;

	public UI_btn_SoldierFormation OurFormation1;

	public UI_btn_SoldierFormation OurFormation2;

	public UI_btn_SoldierFormation OurFormation3;

	public UI_btn_SoldierFormation OurFormation4;

	public UI_btn_SoldierFormation OurFormation5;

	public UI_btn_SoldierFormation OurFormation6;

	public UI_btn_SoldierFormation OurFormation7;

	public UI_btn_SoldierFormation OurFormation8;

	public const string URL = "ui://b3fc6085stwvs";

	public static string Name = "UI_com_StandardFormationSketchMap";

	public static string GetURL()
	{
		return "ui://b3fc6085stwvs";
	}

	public static UI_com_StandardFormationSketchMap CreateInstance()
	{
		return (UI_com_StandardFormationSketchMap)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_StandardFormationSketchMap");
	}

	public static UI_com_StandardFormationSketchMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StandardFormationSketchMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwvs", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (UI_com_PvpFormationBack)(object)((GComponent)this).GetChild("Background");
		DraggingIcon = (GComponent)((GComponent)this).GetChild("DraggingIcon");
		OurFormation0 = (UI_btn_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation0");
		OurFormation1 = (UI_btn_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation1");
		OurFormation2 = (UI_btn_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation2");
		OurFormation3 = (UI_btn_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation3");
		OurFormation4 = (UI_btn_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation4");
		OurFormation5 = (UI_btn_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation5");
		OurFormation6 = (UI_btn_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation6");
		OurFormation7 = (UI_btn_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation7");
		OurFormation8 = (UI_btn_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation8");
	}
}
