using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_dec_RobotBottom : GComponent
{
	public Controller c1;

	public GImage n7;

	public GImage n8;

	public GImage n6;

	public Transition t0;

	public const string URL = "ui://h09dvkcgrtmo1i";

	public static string Name = "UI_dec_RobotBottom";

	public static string GetURL()
	{
		return "ui://h09dvkcgrtmo1i";
	}

	public static UI_dec_RobotBottom CreateInstance()
	{
		return (UI_dec_RobotBottom)(object)UIPackage.CreateObject("LegendItemBlueprint", "dec_RobotBottom");
	}

	public static UI_dec_RobotBottom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_RobotBottom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgrtmo1i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
