using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpgradePotential;

public class UI_Arrowhead : GComponent
{
	public GImage n0;

	public GImage n1;

	public GImage n2;

	public GGroup n3;

	public Transition t0;

	public const string URL = "ui://l5ik1uclpanqtb6";

	public static string Name = "UI_Arrowhead";

	public static string GetURL()
	{
		return "ui://l5ik1uclpanqtb6";
	}

	public static UI_Arrowhead CreateInstance()
	{
		return (UI_Arrowhead)(object)UIPackage.CreateObject("UpgradePotential", "Arrowhead");
	}

	public static UI_Arrowhead CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Arrowhead).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclpanqtb6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GGroup)((GComponent)this).GetChild("n3");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
