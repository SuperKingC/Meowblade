using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_CloseBattlePass : GButton
{
	public Controller button;

	public GImage back;

	public GLoader n14;

	public const string URL = "ui://bfjg32huo4fr4j";

	public static string Name = "UI_btn_CloseBattlePass";

	public static string GetURL()
	{
		return "ui://bfjg32huo4fr4j";
	}

	public static UI_btn_CloseBattlePass CreateInstance()
	{
		return (UI_btn_CloseBattlePass)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_CloseBattlePass");
	}

	public static UI_btn_CloseBattlePass CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CloseBattlePass).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huo4fr4j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		n14 = (GLoader)((GComponent)this).GetChild("n14");
	}
}
