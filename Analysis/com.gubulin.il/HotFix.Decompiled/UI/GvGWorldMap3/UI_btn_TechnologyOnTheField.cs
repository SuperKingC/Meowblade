using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_TechnologyOnTheField : GButton
{
	public Controller button;

	public GImage n7;

	public GImage n3;

	public GImage n5;

	public GImage RedDot;

	public const string URL = "ui://4eq8fgd2bqhp1m";

	public static string Name = "UI_btn_TechnologyOnTheField";

	public static string GetURL()
	{
		return "ui://4eq8fgd2bqhp1m";
	}

	public static UI_btn_TechnologyOnTheField CreateInstance()
	{
		return (UI_btn_TechnologyOnTheField)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_TechnologyOnTheField");
	}

	public static UI_btn_TechnologyOnTheField CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TechnologyOnTheField).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2bqhp1m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
	}
}
