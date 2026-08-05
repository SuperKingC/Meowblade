using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_SignInReward : GComponent
{
	public Controller button;

	public GImage n3;

	public GLoader icon;

	public const string URL = "ui://kozswd8hndjaq";

	public static string Name = "UI_SignInReward";

	public static string GetURL()
	{
		return "ui://kozswd8hndjaq";
	}

	public static UI_SignInReward CreateInstance()
	{
		return (UI_SignInReward)(object)UIPackage.CreateObject("SpecialActivity", "SignInReward");
	}

	public static UI_SignInReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SignInReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndjaq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
