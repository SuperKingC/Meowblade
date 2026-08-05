using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierPotentialTipPanel : GComponent
{
	public GGraph mask;

	public UI_SoldierPotentialTip Tip;

	public const string URL = "ui://7dantnbi108mt7h";

	public static string Name = "UI_SoldierPotentialTipPanel";

	public static string GetURL()
	{
		return "ui://7dantnbi108mt7h";
	}

	public static UI_SoldierPotentialTipPanel CreateInstance()
	{
		return (UI_SoldierPotentialTipPanel)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierPotentialTipPanel");
	}

	public static UI_SoldierPotentialTipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierPotentialTipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbi108mt7h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Tip = (UI_SoldierPotentialTip)(object)((GComponent)this).GetChild("Tip");
	}
}
