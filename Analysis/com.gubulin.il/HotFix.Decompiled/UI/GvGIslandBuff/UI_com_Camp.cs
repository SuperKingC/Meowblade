using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGIslandBuff;

public class UI_com_Camp : GComponent
{
	public Controller Camp;

	public GLoader n8;

	public const string URL = "ui://zh7jgfijnungg9";

	public static string Name = "UI_com_Camp";

	public static string GetURL()
	{
		return "ui://zh7jgfijnungg9";
	}

	public static UI_com_Camp CreateInstance()
	{
		return (UI_com_Camp)(object)UIPackage.CreateObject("GvGIslandBuff", "com_Camp");
	}

	public static UI_com_Camp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Camp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnungg9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n8 = (GLoader)((GComponent)this).GetChild("n8");
	}
}
