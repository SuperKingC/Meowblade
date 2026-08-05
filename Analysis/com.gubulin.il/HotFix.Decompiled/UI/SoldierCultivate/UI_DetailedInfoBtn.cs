using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_DetailedInfoBtn : GButton
{
	public Controller button;

	public GImage n9;

	public const string URL = "ui://7dantnbionm25";

	public static string Name = "UI_DetailedInfoBtn";

	public static string GetURL()
	{
		return "ui://7dantnbionm25";
	}

	public static UI_DetailedInfoBtn CreateInstance()
	{
		return (UI_DetailedInfoBtn)(object)UIPackage.CreateObject("SoldierCultivate", "DetailedInfoBtn");
	}

	public static UI_DetailedInfoBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DetailedInfoBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm25", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
