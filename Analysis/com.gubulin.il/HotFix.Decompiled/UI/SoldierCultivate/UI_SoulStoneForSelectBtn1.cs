using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoulStoneForSelectBtn1 : GButton
{
	public Controller button;

	public GButton iconBtn;

	public const string URL = "ui://7dantnbiwqizt9q";

	public static string Name = "UI_SoulStoneForSelectBtn1";

	public static string GetURL()
	{
		return "ui://7dantnbiwqizt9q";
	}

	public static UI_SoulStoneForSelectBtn1 CreateInstance()
	{
		return (UI_SoulStoneForSelectBtn1)(object)UIPackage.CreateObject("SoldierCultivate", "SoulStoneForSelectBtn1");
	}

	public static UI_SoulStoneForSelectBtn1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoulStoneForSelectBtn1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbiwqizt9q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		iconBtn = (GButton)((GComponent)this).GetChild("iconBtn");
	}
}
