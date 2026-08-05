using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_btn_GvGResetTalents : GButton
{
	public Controller button;

	public Controller State;

	public GImage n5;

	public GTextField Time;

	public const string URL = "ui://4r1llhd8xohkj";

	public static string Name = "UI_btn_GvGResetTalents";

	public static string GetURL()
	{
		return "ui://4r1llhd8xohkj";
	}

	public static UI_btn_GvGResetTalents CreateInstance()
	{
		return (UI_btn_GvGResetTalents)(object)UIPackage.CreateObject("GvGTalent", "btn_GvGResetTalents");
	}

	public static UI_btn_GvGResetTalents CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_GvGResetTalents).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8xohkj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Time = (GTextField)((GComponent)this).GetChild("Time");
	}
}
