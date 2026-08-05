using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_LuckSlotsLock : GComponent
{
	public UI_mc_LuckdrawBackLock n28;

	public UI_mc_LuckdrawBackLock n29;

	public UI_mc_LuckdrawBackLock n30;

	public UI_mc_LuckdrawBackLock n31;

	public UI_mc_LuckdrawBackLock n32;

	public UI_mc_LuckdrawBackLock n33;

	public UI_mc_LuckdrawBackLock n34;

	public UI_mc_LuckdrawBackLock n35;

	public UI_mc_LuckdrawBackLock n36;

	public UI_mc_LuckdrawBackLock n37;

	public UI_mc_LuckdrawBackLock n38;

	public UI_mc_LuckdrawBackLock n39;

	public UI_mc_LuckdrawBackLock n40;

	public UI_mc_LuckdrawBackLock n41;

	public UI_mc_LuckdrawBackLock n42;

	public UI_mc_LuckdrawBackLock n43;

	public UI_mc_LuckdrawBackLock n44;

	public UI_mc_LuckdrawBackLock n45;

	public const string URL = "ui://k2sprg26laau4m";

	public static string Name = "UI_mc_LuckSlotsLock";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4m";
	}

	public static UI_mc_LuckSlotsLock CreateInstance()
	{
		return (UI_mc_LuckSlotsLock)(object)UIPackage.CreateObject("IslandComeAgain", "mc_LuckSlotsLock");
	}

	public static UI_mc_LuckSlotsLock CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_LuckSlotsLock).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		n28 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n28");
		n29 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n29");
		n30 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n30");
		n31 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n31");
		n32 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n32");
		n33 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n33");
		n34 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n34");
		n35 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n35");
		n36 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n36");
		n37 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n37");
		n38 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n38");
		n39 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n39");
		n40 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n40");
		n41 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n41");
		n42 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n42");
		n43 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n43");
		n44 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n44");
		n45 = (UI_mc_LuckdrawBackLock)(object)((GComponent)this).GetChild("n45");
	}
}
