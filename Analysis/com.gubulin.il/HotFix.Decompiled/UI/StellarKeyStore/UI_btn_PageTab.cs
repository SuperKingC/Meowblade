using FairyGUI;
using FairyGUI.Utils;

namespace UI.StellarKeyStore;

public class UI_btn_PageTab : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n4;

	public GImage n8;

	public GImage RedDot;

	public GLoader Icon;

	public const string URL = "ui://khops95lyjovm";

	public static string Name = "UI_btn_PageTab";

	public static string GetURL()
	{
		return "ui://khops95lyjovm";
	}

	public static UI_btn_PageTab CreateInstance()
	{
		return (UI_btn_PageTab)(object)UIPackage.CreateObject("StellarKeyStore", "btn_PageTab");
	}

	public static UI_btn_PageTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PageTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://khops95lyjovm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
	}
}
