using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_BossBreakDownTip : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n3;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2v9mdqb6sep";

	public static string Name = "UI_btn_BossBreakDownTip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2v9mdqb6sep";
	}

	public static UI_btn_BossBreakDownTip CreateInstance()
	{
		return (UI_btn_BossBreakDownTip)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_BossBreakDownTip");
	}

	public static UI_btn_BossBreakDownTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BossBreakDownTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2v9mdqb6sep", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
