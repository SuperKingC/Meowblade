using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_ItemPrice : GComponent
{
	public GRichTextField Num;

	public GLoader icon;

	public GGroup n14;

	public const string URL = "ui://b9yxt7u0cazt3h";

	public static string Name = "UI_ItemPrice";

	public static string GetURL()
	{
		return "ui://b9yxt7u0cazt3h";
	}

	public static UI_ItemPrice CreateInstance()
	{
		return (UI_ItemPrice)(object)UIPackage.CreateObject("AccountInfo", "ItemPrice");
	}

	public static UI_ItemPrice CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ItemPrice).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0cazt3h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Num = (GRichTextField)((GComponent)this).GetChild("Num");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
	}
}
