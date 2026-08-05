using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMapRecord2;

public class UI_EnemyStandardFormationSketchMap : GComponent
{
	public UI_PvpFormationBack Background;

	public UI_SoldierFormation OurFormation0;

	public UI_SoldierFormation OurFormation1;

	public UI_SoldierFormation OurFormation2;

	public UI_SoldierFormation OurFormation3;

	public UI_SoldierFormation OurFormation4;

	public UI_SoldierFormation OurFormation5;

	public UI_SoldierFormation OurFormation6;

	public UI_SoldierFormation OurFormation7;

	public UI_SoldierFormation OurFormation8;

	public GComponent DraggingIcon;

	public const string URL = "ui://5xc1njmujjrn2l";

	public static string Name = "UI_EnemyStandardFormationSketchMap";

	public static string GetURL()
	{
		return "ui://5xc1njmujjrn2l";
	}

	public static UI_EnemyStandardFormationSketchMap CreateInstance()
	{
		return (UI_EnemyStandardFormationSketchMap)(object)UIPackage.CreateObject("GvGWorldMapRecord2", "EnemyStandardFormationSketchMap");
	}

	public static UI_EnemyStandardFormationSketchMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyStandardFormationSketchMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5xc1njmujjrn2l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (UI_PvpFormationBack)(object)((GComponent)this).GetChild("Background");
		OurFormation0 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation0");
		OurFormation1 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation1");
		OurFormation2 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation2");
		OurFormation3 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation3");
		OurFormation4 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation4");
		OurFormation5 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation5");
		OurFormation6 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation6");
		OurFormation7 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation7");
		OurFormation8 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation8");
		DraggingIcon = (GComponent)((GComponent)this).GetChild("DraggingIcon");
	}
}
