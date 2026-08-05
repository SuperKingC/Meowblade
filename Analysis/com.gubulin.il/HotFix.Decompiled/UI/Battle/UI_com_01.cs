using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_com_01 : GComponent
{
	public GImage n19;

	public GImage n20;

	public GTextField infoText;

	public GLoader n22;

	public Transition t0;

	public const string URL = "ui://twlbabici9nwpi";

	public static string Name = "UI_com_01";

	public static string GetURL()
	{
		return "ui://twlbabici9nwpi";
	}

	public static UI_com_01 CreateInstance()
	{
		return (UI_com_01)(object)UIPackage.CreateObject("Battle", "com_01");
	}

	public static UI_com_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabici9nwpi", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		infoText = (GTextField)((GComponent)this).GetChild("infoText");
		n22 = (GLoader)((GComponent)this).GetChild("n22");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
