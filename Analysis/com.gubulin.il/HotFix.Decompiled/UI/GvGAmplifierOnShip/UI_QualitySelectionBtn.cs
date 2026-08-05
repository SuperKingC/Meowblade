using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_QualitySelectionBtn : GButton
{
	public Controller button;

	public Controller Quality;

	public GImage n124;

	public GImage n125;

	public GLoader n126;

	public GImage n127;

	public const string URL = "ui://pwlamcyxgp16m";

	public static string Name = "UI_QualitySelectionBtn";

	public static string GetURL()
	{
		return "ui://pwlamcyxgp16m";
	}

	public static UI_QualitySelectionBtn CreateInstance()
	{
		return (UI_QualitySelectionBtn)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "QualitySelectionBtn");
	}

	public static UI_QualitySelectionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QualitySelectionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp16m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Quality = ((GComponent)this).GetController("Quality");
		n124 = (GImage)((GComponent)this).GetChild("n124");
		n125 = (GImage)((GComponent)this).GetChild("n125");
		n126 = (GLoader)((GComponent)this).GetChild("n126");
		n127 = (GImage)((GComponent)this).GetChild("n127");
	}
}
