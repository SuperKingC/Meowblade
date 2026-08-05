using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_btn_Jump : GButton
{
	public Controller button;

	public GImage n6;

	public GTextField n5;

	public const string URL = "ui://rx5ntv988vxl1g";

	public static string Name = "UI_btn_Jump";

	public static string GetURL()
	{
		return "ui://rx5ntv988vxl1g";
	}

	public static UI_btn_Jump CreateInstance()
	{
		return (UI_btn_Jump)(object)UIPackage.CreateObject("ReturningRewards", "btn_Jump");
	}

	public static UI_btn_Jump CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Jump).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv988vxl1g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://rx5ntv988vxl1g".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
