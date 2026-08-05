using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_dec_SmelterFrame : GComponent
{
	public Controller c1;

	public GImage n9;

	public GImage n10;

	public GGraph n11;

	public Transition t0;

	public const string URL = "ui://h09dvkcgrtmo1m";

	public static string Name = "UI_dec_SmelterFrame";

	public static string GetURL()
	{
		return "ui://h09dvkcgrtmo1m";
	}

	public static UI_dec_SmelterFrame CreateInstance()
	{
		return (UI_dec_SmelterFrame)(object)UIPackage.CreateObject("LegendItemBlueprint", "dec_SmelterFrame");
	}

	public static UI_dec_SmelterFrame CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_SmelterFrame).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgrtmo1m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		c1 = ((GComponent)this).GetController("c1");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GGraph)((GComponent)this).GetChild("n11");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
