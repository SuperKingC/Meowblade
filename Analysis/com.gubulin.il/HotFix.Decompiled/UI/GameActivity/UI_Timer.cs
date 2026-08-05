using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_Timer : GComponent
{
	public GImage n26;

	public GTextField limitTime;

	public const string URL = "ui://29q48tv6vujs7w";

	public static string Name = "UI_Timer";

	public static string GetURL()
	{
		return "ui://29q48tv6vujs7w";
	}

	public static UI_Timer CreateInstance()
	{
		return (UI_Timer)(object)UIPackage.CreateObject("GameActivity", "Timer");
	}

	public static UI_Timer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Timer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6vujs7w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n26 = (GImage)((GComponent)this).GetChild("n26");
		limitTime = (GTextField)((GComponent)this).GetChild("limitTime");
	}
}
