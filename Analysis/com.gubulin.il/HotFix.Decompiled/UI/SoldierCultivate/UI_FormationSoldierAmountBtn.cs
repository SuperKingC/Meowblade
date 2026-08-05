using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_FormationSoldierAmountBtn : GButton
{
	public Controller button;

	public const string URL = "ui://7dantnbioomct7q";

	public static string Name = "UI_FormationSoldierAmountBtn";

	public static string GetURL()
	{
		return "ui://7dantnbioomct7q";
	}

	public static UI_FormationSoldierAmountBtn CreateInstance()
	{
		return (UI_FormationSoldierAmountBtn)(object)UIPackage.CreateObject("SoldierCultivate", "FormationSoldierAmountBtn");
	}

	public static UI_FormationSoldierAmountBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FormationSoldierAmountBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbioomct7q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
	}
}
