using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_Businessman : GComponent
{
	public Controller State;

	public GImage n9;

	public GImage n8;

	public UI_mc_Bubble01 BigPrize;

	public UI_mc_Bubble02 n11;

	public const string URL = "ui://k2sprg26laau6e";

	public static string Name = "UI_mc_Businessman";

	public static string GetURL()
	{
		return "ui://k2sprg26laau6e";
	}

	public static UI_mc_Businessman CreateInstance()
	{
		return (UI_mc_Businessman)(object)UIPackage.CreateObject("IslandComeAgain", "mc_Businessman");
	}

	public static UI_mc_Businessman CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Businessman).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau6e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		BigPrize = (UI_mc_Bubble01)(object)((GComponent)this).GetChild("BigPrize");
		n11 = (UI_mc_Bubble02)(object)((GComponent)this).GetChild("n11");
	}
}
