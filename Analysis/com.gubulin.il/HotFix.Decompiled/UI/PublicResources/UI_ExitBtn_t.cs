using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_ExitBtn_t : GButton
{
	public Controller button;

	public GImage n0;

	public GImage n1;

	public const string URL = "ui://kt6rg65ol3scu";

	public static string Name = "UI_ExitBtn_t";

	public static string GetURL()
	{
		return "ui://kt6rg65ol3scu";
	}

	public static UI_ExitBtn_t CreateInstance()
	{
		return (UI_ExitBtn_t)(object)UIPackage.CreateObject("PublicResources", "ExitBtn_t");
	}

	public static UI_ExitBtn_t CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExitBtn_t).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ol3scu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
