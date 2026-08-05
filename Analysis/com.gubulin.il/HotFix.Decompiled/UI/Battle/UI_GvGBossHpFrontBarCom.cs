using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_GvGBossHpFrontBarCom : GComponent
{
	public Controller Type;

	public GImage bar;

	public GImage bar_2;

	public GImage bar_3;

	public GImage bar_4;

	public GImage bar_5;

	public const string URL = "ui://twlbabiclqo8la";

	public static string Name = "UI_GvGBossHpFrontBarCom";

	public static string GetURL()
	{
		return "ui://twlbabiclqo8la";
	}

	public static UI_GvGBossHpFrontBarCom CreateInstance()
	{
		return (UI_GvGBossHpFrontBarCom)(object)UIPackage.CreateObject("Battle", "GvGBossHpFrontBarCom");
	}

	public static UI_GvGBossHpFrontBarCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossHpFrontBarCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabiclqo8la", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		bar = (GImage)((GComponent)this).GetChild("bar");
		bar_2 = (GImage)((GComponent)this).GetChild("bar");
		bar_3 = (GImage)((GComponent)this).GetChild("bar");
		bar_4 = (GImage)((GComponent)this).GetChild("bar");
		bar_5 = (GImage)((GComponent)this).GetChild("bar");
	}
}
