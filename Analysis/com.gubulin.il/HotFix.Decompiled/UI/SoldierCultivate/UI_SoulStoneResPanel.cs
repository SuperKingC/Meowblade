using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoulStoneResPanel : GComponent
{
	public GGraph mask;

	public UI_SoulStoneList SoulStoneList;

	public UI_SoulStoneList2 StoneList;

	public Transition ShowSoulStoneList;

	public const string URL = "ui://7dantnbibunlt8p";

	public static string Name = "UI_SoulStoneResPanel";

	public static string GetURL()
	{
		return "ui://7dantnbibunlt8p";
	}

	public static UI_SoulStoneResPanel CreateInstance()
	{
		return (UI_SoulStoneResPanel)(object)UIPackage.CreateObject("SoldierCultivate", "SoulStoneResPanel");
	}

	public static UI_SoulStoneResPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoulStoneResPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbibunlt8p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		SoulStoneList = (UI_SoulStoneList)(object)((GComponent)this).GetChild("SoulStoneList");
		StoneList = (UI_SoulStoneList2)(object)((GComponent)this).GetChild("StoneList");
		ShowSoulStoneList = ((GComponent)this).GetTransition("ShowSoulStoneList");
	}
}
