using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_ProductIconWithText : GComponent
{
	public GLoader Icon;

	public GTextField Num;

	public Transition DisAppear;

	public const string URL = "ui://kt6rg65op0qlv4lw";

	public static string Name = "UI_com_ProductIconWithText";

	public static string GetURL()
	{
		return "ui://kt6rg65op0qlv4lw";
	}

	public static UI_com_ProductIconWithText CreateInstance()
	{
		return (UI_com_ProductIconWithText)(object)UIPackage.CreateObject("PublicResources", "com_ProductIconWithText");
	}

	public static UI_com_ProductIconWithText CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProductIconWithText).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65op0qlv4lw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		DisAppear = ((GComponent)this).GetTransition("DisAppear");
	}
}
