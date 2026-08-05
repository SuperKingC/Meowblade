using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_PropertyClickArea : GButton
{
	public GGraph n114;

	public const string URL = "ui://kt6rg65ofw8e6d";

	public static string Name = "UI_PropertyClickArea";

	public static string GetURL()
	{
		return "ui://kt6rg65ofw8e6d";
	}

	public static UI_PropertyClickArea CreateInstance()
	{
		return (UI_PropertyClickArea)(object)UIPackage.CreateObject("PublicResources", "PropertyClickArea");
	}

	public static UI_PropertyClickArea CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PropertyClickArea).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ofw8e6d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n114 = (GGraph)((GComponent)this).GetChild("n114");
	}
}
