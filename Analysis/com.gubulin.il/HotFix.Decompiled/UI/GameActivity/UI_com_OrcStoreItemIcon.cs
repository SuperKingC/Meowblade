using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_OrcStoreItemIcon : GComponent
{
	public Controller Type;

	public GLoader frame;

	public GLoader itemIcon;

	public GTextField desc;

	public const string URL = "ui://29q48tv6hwkc5f8m";

	public static string Name = "UI_com_OrcStoreItemIcon";

	public static string GetURL()
	{
		return "ui://29q48tv6hwkc5f8m";
	}

	public static UI_com_OrcStoreItemIcon CreateInstance()
	{
		return (UI_com_OrcStoreItemIcon)(object)UIPackage.CreateObject("GameActivity", "com_OrcStoreItemIcon");
	}

	public static UI_com_OrcStoreItemIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OrcStoreItemIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6hwkc5f8m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		itemIcon = (GLoader)((GComponent)this).GetChild("itemIcon");
		desc = (GTextField)((GComponent)this).GetChild("desc");
	}
}
