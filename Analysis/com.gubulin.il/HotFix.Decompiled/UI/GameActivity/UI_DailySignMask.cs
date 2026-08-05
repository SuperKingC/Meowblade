using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_DailySignMask : GButton
{
	public Controller button;

	public GImage Mask;

	public const string URL = "ui://29q48tv6koyg3b";

	public static string Name = "UI_DailySignMask";

	public static string GetURL()
	{
		return "ui://29q48tv6koyg3b";
	}

	public static UI_DailySignMask CreateInstance()
	{
		return (UI_DailySignMask)(object)UIPackage.CreateObject("GameActivity", "DailySignMask");
	}

	public static UI_DailySignMask CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DailySignMask).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6koyg3b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Mask = (GImage)((GComponent)this).GetChild("Mask");
	}
}
