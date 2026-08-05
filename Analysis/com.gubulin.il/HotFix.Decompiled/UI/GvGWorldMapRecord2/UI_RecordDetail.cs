using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMapRecord2;

public class UI_RecordDetail : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://5xc1njmujjrn32";

	public static string Name = "UI_RecordDetail";

	public static string GetURL()
	{
		return "ui://5xc1njmujjrn32";
	}

	public static UI_RecordDetail CreateInstance()
	{
		return (UI_RecordDetail)(object)UIPackage.CreateObject("GvGWorldMapRecord2", "RecordDetail");
	}

	public static UI_RecordDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RecordDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5xc1njmujjrn32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
