using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_woodBlack2 : GComponent
{
	public GImage n45;

	public const string URL = "ui://avplaivdyqml4m";

	public static string Name = "UI_woodBlack2";

	public static string GetURL()
	{
		return "ui://avplaivdyqml4m";
	}

	public static UI_woodBlack2 CreateInstance()
	{
		return (UI_woodBlack2)(object)UIPackage.CreateObject("Contract", "woodBlack2");
	}

	public static UI_woodBlack2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_woodBlack2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdyqml4m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n45 = (GImage)((GComponent)this).GetChild("n45");
	}
}
