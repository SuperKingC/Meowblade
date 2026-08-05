using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierFormationInfoPanel : GComponent
{
	public GGraph mask;

	public UI_SoldierFormationInfo Dialog;

	public const string URL = "ui://7dantnbimol06y";

	public static string Name = "UI_SoldierFormationInfoPanel";

	public static string GetURL()
	{
		return "ui://7dantnbimol06y";
	}

	public static UI_SoldierFormationInfoPanel CreateInstance()
	{
		return (UI_SoldierFormationInfoPanel)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierFormationInfoPanel");
	}

	public static UI_SoldierFormationInfoPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierFormationInfoPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbimol06y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_SoldierFormationInfo)(object)((GComponent)this).GetChild("Dialog");
	}
}
