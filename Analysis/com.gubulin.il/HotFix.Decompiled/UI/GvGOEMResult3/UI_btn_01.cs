using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMResult3;

public class UI_btn_01 : GButton
{
	public GImage n225;

	public GImage n226;

	public Transition t0;

	public const string URL = "ui://5k1s1pjxjz9z62";

	public static string Name = "UI_btn_01";

	public static string GetURL()
	{
		return "ui://5k1s1pjxjz9z62";
	}

	public static UI_btn_01 CreateInstance()
	{
		return (UI_btn_01)(object)UIPackage.CreateObject("GvGOEMResult3", "btn_01");
	}

	public static UI_btn_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5k1s1pjxjz9z62", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n225 = (GImage)((GComponent)this).GetChild("n225");
		n226 = (GImage)((GComponent)this).GetChild("n226");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
