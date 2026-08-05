using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_compoundSoulStoneBtn : GButton
{
	public Controller button;

	public GImage n5;

	public GImage title;

	public const string URL = "ui://7dantnbibunlt8c";

	public static string Name = "UI_compoundSoulStoneBtn";

	public static string GetURL()
	{
		return "ui://7dantnbibunlt8c";
	}

	public static UI_compoundSoulStoneBtn CreateInstance()
	{
		return (UI_compoundSoulStoneBtn)(object)UIPackage.CreateObject("SoldierCultivate", "compoundSoulStoneBtn");
	}

	public static UI_compoundSoulStoneBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_compoundSoulStoneBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbibunlt8c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		title = (GImage)((GComponent)this).GetChild("title");
	}
}
