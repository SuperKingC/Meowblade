using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_Bonus : GComponent
{
	public GLoader ItemIcon;

	public GTextField Count;

	public const string URL = "ui://p4ocf6q0dc6m5";

	public static string Name = "UI_com_Bonus";

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6m5";
	}

	public static UI_com_Bonus CreateInstance()
	{
		return (UI_com_Bonus)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_Bonus");
	}

	public static UI_com_Bonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Bonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6m5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}
