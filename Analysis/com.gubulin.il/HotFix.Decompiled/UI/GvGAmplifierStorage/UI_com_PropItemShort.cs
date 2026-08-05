using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierStorage;

public class UI_com_PropItemShort : GComponent
{
	public GTextField PropName;

	public GTextField PropEffect;

	public GGroup n79;

	public const string URL = "ui://fwpu36398jf611";

	public static string Name = "UI_com_PropItemShort";

	public static string GetURL()
	{
		return "ui://fwpu36398jf611";
	}

	public static UI_com_PropItemShort CreateInstance()
	{
		return (UI_com_PropItemShort)(object)UIPackage.CreateObject("GvGAmplifierStorage", "com_PropItemShort");
	}

	public static UI_com_PropItemShort CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PropItemShort).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fwpu36398jf611", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		PropName = (GTextField)((GComponent)this).GetChild("PropName");
		PropEffect = (GTextField)((GComponent)this).GetChild("PropEffect");
		n79 = (GGroup)((GComponent)this).GetChild("n79");
	}
}
