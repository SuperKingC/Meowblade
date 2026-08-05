using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_Cloth03 : GComponent
{
	public Controller State;

	public GImage n18;

	public GImage n20;

	public GImage n21;

	public GImage n22;

	public GImage n23;

	public const string URL = "ui://k2sprg26laau5h";

	public static string Name = "UI_mc_Cloth03";

	public static string GetURL()
	{
		return "ui://k2sprg26laau5h";
	}

	public static UI_mc_Cloth03 CreateInstance()
	{
		return (UI_mc_Cloth03)(object)UIPackage.CreateObject("IslandComeAgain", "mc_Cloth03");
	}

	public static UI_mc_Cloth03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Cloth03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau5h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
	}
}
