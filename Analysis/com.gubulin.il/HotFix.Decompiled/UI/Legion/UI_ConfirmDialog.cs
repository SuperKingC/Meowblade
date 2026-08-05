using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_ConfirmDialog : GComponent
{
	public GImage back;

	public GTextField tip;

	public GButton noBtn;

	public GButton yesBtn;

	public const string URL = "ui://lrhs6zw7z7z643p";

	public static string Name = "UI_ConfirmDialog";

	public static string GetURL()
	{
		return "ui://lrhs6zw7z7z643p";
	}

	public static UI_ConfirmDialog CreateInstance()
	{
		return (UI_ConfirmDialog)(object)UIPackage.CreateObject("Legion", "ConfirmDialog");
	}

	public static UI_ConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7z7z643p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		noBtn = (GButton)((GComponent)this).GetChild("noBtn");
		yesBtn = (GButton)((GComponent)this).GetChild("yesBtn");
	}
}
