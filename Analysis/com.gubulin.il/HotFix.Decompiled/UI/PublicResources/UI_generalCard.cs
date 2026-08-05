using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_generalCard : GButton
{
	public Controller button;

	public UI_generalCardBack1 generalCardBack;

	public UI_generalCardLight generalCardLight;

	public const string URL = "ui://kt6rg65ovv0uf2";

	public static string Name = "UI_generalCard";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0uf2";
	}

	public static UI_generalCard CreateInstance()
	{
		return (UI_generalCard)(object)UIPackage.CreateObject("PublicResources", "generalCard");
	}

	public static UI_generalCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_generalCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0uf2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		generalCardBack = (UI_generalCardBack1)(object)((GComponent)this).GetChild("generalCardBack");
		generalCardLight = (UI_generalCardLight)(object)((GComponent)this).GetChild("generalCardLight");
	}
}
