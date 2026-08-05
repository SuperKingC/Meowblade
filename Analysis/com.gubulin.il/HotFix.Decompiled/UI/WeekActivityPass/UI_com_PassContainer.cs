using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_com_PassContainer : GComponent
{
	public GImage n6;

	public UI_com_BuyPassSmall Advance;

	public UI_com_BuyPassSmall Premium;

	public GGroup n5;

	public const string URL = "ui://11dkggb8uxdc34";

	public static string Name = "UI_com_PassContainer";

	public static string GetURL()
	{
		return "ui://11dkggb8uxdc34";
	}

	public static UI_com_PassContainer CreateInstance()
	{
		return (UI_com_PassContainer)(object)UIPackage.CreateObject("WeekActivityPass", "com_PassContainer");
	}

	public static UI_com_PassContainer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PassContainer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8uxdc34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Advance = (UI_com_BuyPassSmall)(object)((GComponent)this).GetChild("Advance");
		Premium = (UI_com_BuyPassSmall)(object)((GComponent)this).GetChild("Premium");
		n5 = (GGroup)((GComponent)this).GetChild("n5");
	}
}
