using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMResult3;

public class UI_com_OemBonus : GComponent
{
	public GLoader ItemIcon;

	public GTextField Count;

	public GImage n210;

	public const string URL = "ui://5k1s1pjxpzxd7";

	public static string Name = "UI_com_OemBonus";

	public static string GetURL()
	{
		return "ui://5k1s1pjxpzxd7";
	}

	public static UI_com_OemBonus CreateInstance()
	{
		return (UI_com_OemBonus)(object)UIPackage.CreateObject("GvGOEMResult3", "com_OemBonus");
	}

	public static UI_com_OemBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OemBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5k1s1pjxpzxd7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		n210 = (GImage)((GComponent)this).GetChild("n210");
	}
}
