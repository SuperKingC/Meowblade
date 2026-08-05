using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_curtainMain : GButton
{
	public Controller button;

	public UI_cuttainMainItemLast n16;

	public GImage n17;

	public const string URL = "ui://xogvri2hs2vz9";

	public static string Name = "UI_curtainMain";

	public static string GetURL()
	{
		return "ui://xogvri2hs2vz9";
	}

	public static UI_curtainMain CreateInstance()
	{
		return (UI_curtainMain)(object)UIPackage.CreateObject("LegendItemsDraw", "curtainMain");
	}

	public static UI_curtainMain CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_curtainMain).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hs2vz9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n16 = (UI_cuttainMainItemLast)(object)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
	}
}
