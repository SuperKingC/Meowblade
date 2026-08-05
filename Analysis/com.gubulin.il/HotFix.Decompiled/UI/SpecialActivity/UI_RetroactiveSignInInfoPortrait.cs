using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_RetroactiveSignInInfoPortrait : GComponent
{
	public GImage n5;

	public GImage n6;

	public GTextField n0;

	public GTextField MissedCnt;

	public UI_btn_GoToRetroactiveSignIn BuyMtg;

	public GTextField n7;

	public const string URL = "ui://kozswd8hsk4vf4i";

	public static string Name = "UI_RetroactiveSignInInfoPortrait";

	public static string GetURL()
	{
		return "ui://kozswd8hsk4vf4i";
	}

	public static UI_RetroactiveSignInInfoPortrait CreateInstance()
	{
		return (UI_RetroactiveSignInInfoPortrait)(object)UIPackage.CreateObject("SpecialActivity", "RetroactiveSignInInfoPortrait");
	}

	public static UI_RetroactiveSignInInfoPortrait CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RetroactiveSignInInfoPortrait).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hsk4vf4i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://kozswd8hsk4vf4i".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		MissedCnt = (GTextField)((GComponent)this).GetChild("MissedCnt");
		BuyMtg = (UI_btn_GoToRetroactiveSignIn)(object)((GComponent)this).GetChild("BuyMtg");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://kozswd8hsk4vf4i".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
	}
}
