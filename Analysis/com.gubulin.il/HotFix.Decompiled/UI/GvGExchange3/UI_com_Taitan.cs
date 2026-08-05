using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_Taitan : GComponent
{
	public Controller State;

	public GLoader n1;

	public const string URL = "ui://tt2iq07odip34q";

	public static string Name = "UI_com_Taitan";

	public static string GetURL()
	{
		return "ui://tt2iq07odip34q";
	}

	public static UI_com_Taitan CreateInstance()
	{
		return (UI_com_Taitan)(object)UIPackage.CreateObject("GvGExchange3", "com_Taitan");
	}

	public static UI_com_Taitan CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Taitan).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odip34q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
	}
}
