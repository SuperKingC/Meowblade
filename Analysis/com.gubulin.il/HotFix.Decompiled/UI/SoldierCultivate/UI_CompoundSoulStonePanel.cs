using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_CompoundSoulStonePanel : GComponent
{
	public GGraph mask;

	public UI_CompoundSoulStoneDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://7dantnbibunlt8q";

	public static string Name = "UI_CompoundSoulStonePanel";

	public static string GetURL()
	{
		return "ui://7dantnbibunlt8q";
	}

	public static UI_CompoundSoulStonePanel CreateInstance()
	{
		return (UI_CompoundSoulStonePanel)(object)UIPackage.CreateObject("SoldierCultivate", "CompoundSoulStonePanel");
	}

	public static UI_CompoundSoulStonePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CompoundSoulStonePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbibunlt8q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_CompoundSoulStoneDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}
