using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_SignInPnael : GComponent
{
	public Controller RetroactiveSignInAvailable;

	public UI_SignInBack Back;

	public GList SignInLabelList;

	public GTextField Desc;

	public GTextField ActivityTime;

	public GTextField n5;

	public GImage n7;

	public GImage n8;

	public UI_RetroactiveSignInInfoPortrait RetroactiveSignInInfo;

	public const string URL = "ui://kozswd8hndjaf";

	public static string Name = "UI_SignInPnael";

	public static string GetURL()
	{
		return "ui://kozswd8hndjaf";
	}

	public static UI_SignInPnael CreateInstance()
	{
		return (UI_SignInPnael)(object)UIPackage.CreateObject("SpecialActivity", "SignInPnael");
	}

	public static UI_SignInPnael CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SignInPnael).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndjaf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RetroactiveSignInAvailable = ((GComponent)this).GetController("RetroactiveSignInAvailable");
		Back = (UI_SignInBack)(object)((GComponent)this).GetChild("Back");
		SignInLabelList = (GList)((GComponent)this).GetChild("SignInLabelList");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		ActivityTime = (GTextField)((GComponent)this).GetChild("ActivityTime");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://kozswd8hndjaf".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		RetroactiveSignInInfo = (UI_RetroactiveSignInInfoPortrait)(object)((GComponent)this).GetChild("RetroactiveSignInInfo");
	}
}
