using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_ReforgeCostItemAndNum : GComponent
{
	public Controller hasFrame;

	public GGraph n2;

	public GLoader Icon;

	public GTextField num;

	public const string URL = "ui://b9wlonaqmpf91m";

	public static string Name = "UI_ReforgeCostItemAndNum";

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf91m";
	}

	public static UI_ReforgeCostItemAndNum CreateInstance()
	{
		return (UI_ReforgeCostItemAndNum)(object)UIPackage.CreateObject("LegendItemCultivation", "ReforgeCostItemAndNum");
	}

	public static UI_ReforgeCostItemAndNum CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReforgeCostItemAndNum).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf91m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		hasFrame = ((GComponent)this).GetController("hasFrame");
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
