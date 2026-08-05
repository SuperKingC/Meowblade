using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_selected : GButton
{
	public Controller select;

	public GImage n142;

	public GImage n143;

	public const string URL = "ui://b9yxt7u0eb6p3c";

	public static string Name = "UI_selected";

	public static string GetURL()
	{
		return "ui://b9yxt7u0eb6p3c";
	}

	public static UI_selected CreateInstance()
	{
		return (UI_selected)(object)UIPackage.CreateObject("AccountInfo", "selected");
	}

	public static UI_selected CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_selected).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0eb6p3c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		select = ((GComponent)this).GetController("select");
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n143 = (GImage)((GComponent)this).GetChild("n143");
	}
}
