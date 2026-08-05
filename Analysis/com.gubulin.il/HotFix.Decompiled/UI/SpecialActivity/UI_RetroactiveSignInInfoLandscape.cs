using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_RetroactiveSignInInfoLandscape : GComponent
{
	public GImage n6;

	public GImage n7;

	public GTextField n0;

	public GTextField n5;

	public GTextField MissedCnt;

	public UI_btn_GoToRetroactiveSignIn BuyMtg;

	public const string URL = "ui://kozswd8hy8cyf4f";

	public static string Name = "UI_RetroactiveSignInInfoLandscape";

	public static string GetURL()
	{
		return "ui://kozswd8hy8cyf4f";
	}

	public static UI_RetroactiveSignInInfoLandscape CreateInstance()
	{
		return (UI_RetroactiveSignInInfoLandscape)(object)UIPackage.CreateObject("SpecialActivity", "RetroactiveSignInInfoLandscape");
	}

	public static UI_RetroactiveSignInInfoLandscape CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RetroactiveSignInInfoLandscape).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hy8cyf4f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://kozswd8hy8cyf4f".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://kozswd8hy8cyf4f".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		MissedCnt = (GTextField)((GComponent)this).GetChild("MissedCnt");
		BuyMtg = (UI_btn_GoToRetroactiveSignIn)(object)((GComponent)this).GetChild("BuyMtg");
	}
}
