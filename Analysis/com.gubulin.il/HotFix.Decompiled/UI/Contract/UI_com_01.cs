using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_com_01 : GComponent
{
	public GLoader n59;

	public Transition t0;

	public const string URL = "ui://avplaivdi9nwtob";

	public static string Name = "UI_com_01";

	public static string GetURL()
	{
		return "ui://avplaivdi9nwtob";
	}

	public static UI_com_01 CreateInstance()
	{
		return (UI_com_01)(object)UIPackage.CreateObject("Contract", "com_01");
	}

	public static UI_com_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdi9nwtob", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n59 = (GLoader)((GComponent)this).GetChild("n59");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
