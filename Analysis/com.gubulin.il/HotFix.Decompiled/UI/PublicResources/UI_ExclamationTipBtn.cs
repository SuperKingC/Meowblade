using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_ExclamationTipBtn : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://kt6rg65oju9ntek";

	public static string Name = "UI_ExclamationTipBtn";

	public static string GetURL()
	{
		return "ui://kt6rg65oju9ntek";
	}

	public static UI_ExclamationTipBtn CreateInstance()
	{
		return (UI_ExclamationTipBtn)(object)UIPackage.CreateObject("PublicResources", "ExclamationTipBtn");
	}

	public static UI_ExclamationTipBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExclamationTipBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oju9ntek", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
