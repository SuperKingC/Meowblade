using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_EnemyStandardFormationSketchMap : GComponent
{
	public UI_SoldierFormation PosId1;

	public UI_SoldierFormation PosId2;

	public UI_SoldierFormation PosId3;

	public UI_SoldierFormation PosId4;

	public UI_SoldierFormation PosId5;

	public UI_SoldierFormation PosId6;

	public UI_SoldierFormation PosId7;

	public UI_SoldierFormation PosId8;

	public UI_SoldierFormation PosId9;

	public GComponent DraggingIcon;

	public const string URL = "ui://0i520nzmtlapo7p";

	public static string Name = "UI_EnemyStandardFormationSketchMap";

	public static string GetURL()
	{
		return "ui://0i520nzmtlapo7p";
	}

	public static UI_EnemyStandardFormationSketchMap CreateInstance()
	{
		return (UI_EnemyStandardFormationSketchMap)(object)UIPackage.CreateObject("LordOfDreams", "EnemyStandardFormationSketchMap");
	}

	public static UI_EnemyStandardFormationSketchMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyStandardFormationSketchMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtlapo7p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PosId1 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("PosId1");
		PosId2 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("PosId2");
		PosId3 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("PosId3");
		PosId4 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("PosId4");
		PosId5 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("PosId5");
		PosId6 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("PosId6");
		PosId7 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("PosId7");
		PosId8 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("PosId8");
		PosId9 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("PosId9");
		DraggingIcon = (GComponent)((GComponent)this).GetChild("DraggingIcon");
	}
}
