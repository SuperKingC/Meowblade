using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_DungeonDissolveDialog : GComponent
{
	public GImage back;

	public UI_btn_confirm4 Confirm;

	public GTextField Tip;

	public GTextField n31;

	public const string URL = "ui://k19peou7i2rhp5n";

	public static string Name = "UI_com_DungeonDissolveDialog";

	public static string GetURL()
	{
		return "ui://k19peou7i2rhp5n";
	}

	public static UI_com_DungeonDissolveDialog CreateInstance()
	{
		return (UI_com_DungeonDissolveDialog)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_DungeonDissolveDialog");
	}

	public static UI_com_DungeonDissolveDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DungeonDissolveDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7i2rhp5n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Confirm = (UI_btn_confirm4)(object)((GComponent)this).GetChild("Confirm");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		n31 = (GTextField)((GComponent)this).GetChild("n31");
	}
}
