using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_StrategySelection : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n7;

	public GLoader n6;

	public const string URL = "ui://ebc4ciwrx1i01w";

	public static string Name = "UI_btn_StrategySelection";

	public static string GetURL()
	{
		return "ui://ebc4ciwrx1i01w";
	}

	public static UI_btn_StrategySelection CreateInstance()
	{
		return (UI_btn_StrategySelection)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_StrategySelection");
	}

	public static UI_btn_StrategySelection CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_StrategySelection).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrx1i01w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n6 = (GLoader)((GComponent)this).GetChild("n6");
	}
}
