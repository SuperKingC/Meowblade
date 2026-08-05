using FairyGUI;
using FairyGUI.Utils;

namespace UI.Certification;

public class UI_exchangeBtn : GButton
{
	public Controller button;

	public GImage back;

	public GLoader icon;

	public const string URL = "ui://56q48tcqqy9ww";

	public static string Name = "UI_exchangeBtn";

	public static string GetURL()
	{
		return "ui://56q48tcqqy9ww";
	}

	public static UI_exchangeBtn CreateInstance()
	{
		return (UI_exchangeBtn)(object)UIPackage.CreateObject("Certification", "exchangeBtn");
	}

	public static UI_exchangeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_exchangeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqqy9ww", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
