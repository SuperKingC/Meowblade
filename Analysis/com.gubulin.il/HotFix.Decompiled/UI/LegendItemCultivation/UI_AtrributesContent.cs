using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_AtrributesContent : GComponent
{
	public UI_AttributeBack primeAttribute;

	public GList SubEntries;

	public GList FxSuitEntries;

	public GGroup n95;

	public const string URL = "ui://b9wlonaqlofp13";

	public static string Name = "UI_AtrributesContent";

	public static string GetURL()
	{
		return "ui://b9wlonaqlofp13";
	}

	public static UI_AtrributesContent CreateInstance()
	{
		return (UI_AtrributesContent)(object)UIPackage.CreateObject("LegendItemCultivation", "AtrributesContent");
	}

	public static UI_AtrributesContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AtrributesContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqlofp13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		primeAttribute = (UI_AttributeBack)(object)((GComponent)this).GetChild("primeAttribute");
		SubEntries = (GList)((GComponent)this).GetChild("SubEntries");
		FxSuitEntries = (GList)((GComponent)this).GetChild("FxSuitEntries");
		n95 = (GGroup)((GComponent)this).GetChild("n95");
	}
}
