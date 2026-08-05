using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpGrade;

public class UI_com_goodItemConsume : GComponent
{
	public Controller check;

	public GLoader frame;

	public GLoader icon;

	public GTextField curPrice;

	public GButton ExclamationMarkBtn1st;

	public const string URL = "ui://lrjfe94hxfax5o";

	public static string Name = "UI_com_goodItemConsume";

	public static string GetURL()
	{
		return "ui://lrjfe94hxfax5o";
	}

	public static UI_com_goodItemConsume CreateInstance()
	{
		return (UI_com_goodItemConsume)(object)UIPackage.CreateObject("UpGrade", "com_goodItemConsume");
	}

	public static UI_com_goodItemConsume CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_goodItemConsume).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hxfax5o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		check = ((GComponent)this).GetController("check");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		curPrice = (GTextField)((GComponent)this).GetChild("curPrice");
		ExclamationMarkBtn1st = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn1st");
	}
}
