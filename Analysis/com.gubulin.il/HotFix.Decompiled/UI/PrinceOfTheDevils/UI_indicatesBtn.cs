using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_indicatesBtn : GComponent
{
	public GImage n16;

	public GImage n15;

	public GImage n14;

	public Transition t0;

	public const string URL = "ui://zko5n3veql4lfa";

	public static string Name = "UI_indicatesBtn";

	public static string GetURL()
	{
		return "ui://zko5n3veql4lfa";
	}

	public static UI_indicatesBtn CreateInstance()
	{
		return (UI_indicatesBtn)(object)UIPackage.CreateObject("PrinceOfTheDevils", "indicatesBtn");
	}

	public static UI_indicatesBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_indicatesBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3veql4lfa", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
