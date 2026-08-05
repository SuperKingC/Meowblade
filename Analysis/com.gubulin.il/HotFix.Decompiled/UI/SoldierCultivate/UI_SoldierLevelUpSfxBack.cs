using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierLevelUpSfxBack : GButton
{
	public Controller button;

	public GGraph SfxBack;

	public const string URL = "ui://7dantnbigawyt7i";

	public static string Name = "UI_SoldierLevelUpSfxBack";

	public static string GetURL()
	{
		return "ui://7dantnbigawyt7i";
	}

	public static UI_SoldierLevelUpSfxBack CreateInstance()
	{
		return (UI_SoldierLevelUpSfxBack)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierLevelUpSfxBack");
	}

	public static UI_SoldierLevelUpSfxBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierLevelUpSfxBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbigawyt7i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
