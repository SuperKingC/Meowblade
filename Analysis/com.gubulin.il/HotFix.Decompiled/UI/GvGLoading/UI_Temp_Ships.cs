using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGLoading;

public class UI_Temp_Ships : GComponent
{
	public GImage n2;

	public GImage n5;

	public GImage n8;

	public GGroup n7;

	public Transition t0;

	public const string URL = "ui://wvi1oqrw9u003";

	public static string Name = "UI_Temp_Ships";

	public static string GetURL()
	{
		return "ui://wvi1oqrw9u003";
	}

	public static UI_Temp_Ships CreateInstance()
	{
		return (UI_Temp_Ships)(object)UIPackage.CreateObject("GvGLoading", "Temp_Ships");
	}

	public static UI_Temp_Ships CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Temp_Ships).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://wvi1oqrw9u003", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n7 = (GGroup)((GComponent)this).GetChild("n7");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
