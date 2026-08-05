using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_ActivatePremium : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n3;

	public GImage n5;

	public Transition t0;

	public const string URL = "ui://bfjg32hukcdl65";

	public static string Name = "UI_btn_ActivatePremium";

	public static string GetURL()
	{
		return "ui://bfjg32hukcdl65";
	}

	public static UI_btn_ActivatePremium CreateInstance()
	{
		return (UI_btn_ActivatePremium)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_ActivatePremium");
	}

	public static UI_btn_ActivatePremium CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ActivatePremium).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32hukcdl65", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
