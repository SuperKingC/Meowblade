using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_CompoundDialogPageLeftBtn : GButton
{
	public Controller button;

	public GLoader icon;

	public const string URL = "ui://7dantnbibunlt92";

	public static string Name = "UI_CompoundDialogPageLeftBtn";

	public static string GetURL()
	{
		return "ui://7dantnbibunlt92";
	}

	public static UI_CompoundDialogPageLeftBtn CreateInstance()
	{
		return (UI_CompoundDialogPageLeftBtn)(object)UIPackage.CreateObject("SoldierCultivate", "CompoundDialogPageLeftBtn");
	}

	public static UI_CompoundDialogPageLeftBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CompoundDialogPageLeftBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbibunlt92", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
