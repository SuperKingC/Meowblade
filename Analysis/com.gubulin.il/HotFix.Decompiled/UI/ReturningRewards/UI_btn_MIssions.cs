using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_btn_MIssions : GButton
{
	public Controller button;

	public Controller Claimeable;

	public GImage n5;

	public GLoader n7;

	public GImage n6;

	public const string URL = "ui://rx5ntv98win2k";

	public static string Name = "UI_btn_MIssions";

	public static string GetURL()
	{
		return "ui://rx5ntv98win2k";
	}

	public static UI_btn_MIssions CreateInstance()
	{
		return (UI_btn_MIssions)(object)UIPackage.CreateObject("ReturningRewards", "btn_MIssions");
	}

	public static UI_btn_MIssions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_MIssions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Claimeable = ((GComponent)this).GetController("Claimeable");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GLoader)((GComponent)this).GetChild("n7");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
