using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_GvGInsurance : GButton
{
	public Controller button;

	public Controller State;

	public GImage n3;

	public GImage n4;

	public GTextField n5;

	public GImage n6;

	public Transition t0;

	public const string URL = "ui://bfjg32hujljf6h";

	public static string Name = "UI_btn_GvGInsurance";

	public static string GetURL()
	{
		return "ui://bfjg32hujljf6h";
	}

	public static UI_btn_GvGInsurance CreateInstance()
	{
		return (UI_btn_GvGInsurance)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_GvGInsurance");
	}

	public static UI_btn_GvGInsurance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_GvGInsurance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32hujljf6h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://bfjg32hujljf6h".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
