using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_Details : GComponent
{
	public Controller mainAttrPopup;

	public GImage n67;

	public UI_AtrributesContent Atrributes;

	public UI_com_SwitchMainAtt popupMask;

	public const string URL = "ui://b9wlonaqtpmtc";

	public static string Name = "UI_Details";

	public static string GetURL()
	{
		return "ui://b9wlonaqtpmtc";
	}

	public static UI_Details CreateInstance()
	{
		return (UI_Details)(object)UIPackage.CreateObject("LegendItemCultivation", "Details");
	}

	public static UI_Details CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Details).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqtpmtc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mainAttrPopup = ((GComponent)this).GetController("mainAttrPopup");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		Atrributes = (UI_AtrributesContent)(object)((GComponent)this).GetChild("Atrributes");
		popupMask = (UI_com_SwitchMainAtt)(object)((GComponent)this).GetChild("popupMask");
	}
}
