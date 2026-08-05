using FairyGUI;
using FairyGUI.Utils;

namespace UI.AddCredit;

public class UI_FirstTimeDouble : GButton
{
	public Controller button;

	public GImage n5;

	public const string URL = "ui://4pot8w0vavmf4";

	public static string Name = "UI_FirstTimeDouble";

	public static string GetURL()
	{
		return "ui://4pot8w0vavmf4";
	}

	public static UI_FirstTimeDouble CreateInstance()
	{
		return (UI_FirstTimeDouble)(object)UIPackage.CreateObject("AddCredit", "FirstTimeDouble");
	}

	public static UI_FirstTimeDouble CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FirstTimeDouble).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pot8w0vavmf4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
