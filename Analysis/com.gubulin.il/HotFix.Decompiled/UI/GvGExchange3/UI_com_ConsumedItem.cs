using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_ConsumedItem : GComponent
{
	public Controller color;

	public GLoader Icon;

	public GTextField Num;

	public const string URL = "ui://tt2iq07onhzv1d";

	public static string Name = "UI_com_ConsumedItem";

	public static string GetURL()
	{
		return "ui://tt2iq07onhzv1d";
	}

	public static UI_com_ConsumedItem CreateInstance()
	{
		return (UI_com_ConsumedItem)(object)UIPackage.CreateObject("GvGExchange3", "com_ConsumedItem");
	}

	public static UI_com_ConsumedItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ConsumedItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07onhzv1d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		color = ((GComponent)this).GetController("color");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
	}
}
