using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMapRecord2;

public class UI_LogFilter : GButton
{
	public Controller button;

	public GList SwitchList;

	public const string URL = "ui://5xc1njmuqyk93d";

	public static string Name = "UI_LogFilter";

	public static string GetURL()
	{
		return "ui://5xc1njmuqyk93d";
	}

	public static UI_LogFilter CreateInstance()
	{
		return (UI_LogFilter)(object)UIPackage.CreateObject("GvGWorldMapRecord2", "LogFilter");
	}

	public static UI_LogFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LogFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5xc1njmuqyk93d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		SwitchList = (GList)((GComponent)this).GetChild("SwitchList");
	}
}
