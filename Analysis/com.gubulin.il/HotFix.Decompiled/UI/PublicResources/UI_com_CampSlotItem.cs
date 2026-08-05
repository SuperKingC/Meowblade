using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_CampSlotItem : GComponent
{
	public Controller button;

	public GLoader frame;

	public GLoader icon;

	public const string URL = "ui://kt6rg65oabdlv4au";

	public static string Name = "UI_com_CampSlotItem";

	public static string GetURL()
	{
		return "ui://kt6rg65oabdlv4au";
	}

	public static UI_com_CampSlotItem CreateInstance()
	{
		return (UI_com_CampSlotItem)(object)UIPackage.CreateObject("PublicResources", "com_CampSlotItem");
	}

	public static UI_com_CampSlotItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampSlotItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oabdlv4au", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
