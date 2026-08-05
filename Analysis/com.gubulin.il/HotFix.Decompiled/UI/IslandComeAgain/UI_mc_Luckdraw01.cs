using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_Luckdraw01 : GComponent
{
	public Controller State;

	public UI_mc_LuckdrawBg n31;

	public UI_btn_LuckdrawPositive Content;

	public UI_btn_LuckdrawBack n28;

	public GImage n30;

	public Transition ToFront;

	public Transition ToBack;

	public const string URL = "ui://k2sprg26laau4t";

	public static string Name = "UI_mc_Luckdraw01";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4t";
	}

	public static UI_mc_Luckdraw01 CreateInstance()
	{
		return (UI_mc_Luckdraw01)(object)UIPackage.CreateObject("IslandComeAgain", "mc_Luckdraw01");
	}

	public static UI_mc_Luckdraw01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Luckdraw01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n31 = (UI_mc_LuckdrawBg)(object)((GComponent)this).GetChild("n31");
		Content = (UI_btn_LuckdrawPositive)(object)((GComponent)this).GetChild("Content");
		n28 = (UI_btn_LuckdrawBack)(object)((GComponent)this).GetChild("n28");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		ToFront = ((GComponent)this).GetTransition("ToFront");
		ToBack = ((GComponent)this).GetTransition("ToBack");
	}
}
