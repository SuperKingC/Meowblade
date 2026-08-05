using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpGrade;

public class UI_com_consumptionText : GComponent
{
	public Controller c1;

	public GImage n36;

	public GTextField consumption;

	public GImage n38;

	public const string URL = "ui://lrjfe94hxfax5p";

	public static string Name = "UI_com_consumptionText";

	public static string GetURL()
	{
		return "ui://lrjfe94hxfax5p";
	}

	public static UI_com_consumptionText CreateInstance()
	{
		return (UI_com_consumptionText)(object)UIPackage.CreateObject("UpGrade", "com_consumptionText");
	}

	public static UI_com_consumptionText CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_consumptionText).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hxfax5p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		c1 = ((GComponent)this).GetController("c1");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		consumption = (GTextField)((GComponent)this).GetChild("consumption");
		n38 = (GImage)((GComponent)this).GetChild("n38");
	}
}
