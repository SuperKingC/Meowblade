using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_DecorateAndSave : GButton
{
	public Controller button;

	public Controller clickChange;

	public GImage n0;

	public GLoader icon;

	public GLoader SaveIcon;

	public const string URL = "ui://b9yxt7u0wgrq30";

	public static string Name = "UI_DecorateAndSave";

	public static string GetURL()
	{
		return "ui://b9yxt7u0wgrq30";
	}

	public static UI_DecorateAndSave CreateInstance()
	{
		return (UI_DecorateAndSave)(object)UIPackage.CreateObject("AccountInfo", "DecorateAndSave");
	}

	public static UI_DecorateAndSave CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DecorateAndSave).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0wgrq30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		clickChange = ((GComponent)this).GetController("clickChange");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		SaveIcon = (GLoader)((GComponent)this).GetChild("SaveIcon");
	}
}
