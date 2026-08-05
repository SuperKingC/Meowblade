using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_NeedItem : GComponent
{
	public Controller ItemQuantity;

	public GLoader ItemIcon;

	public GTextField Count2;

	public GTextField Count;

	public const string URL = "ui://p4ocf6q0a04vo";

	public static string Name = "UI_com_NeedItem";

	public static string GetURL()
	{
		return "ui://p4ocf6q0a04vo";
	}

	public static UI_com_NeedItem CreateInstance()
	{
		return (UI_com_NeedItem)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_NeedItem");
	}

	public static UI_com_NeedItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NeedItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0a04vo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		ItemQuantity = ((GComponent)this).GetController("ItemQuantity");
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		Count2 = (GTextField)((GComponent)this).GetChild("Count2");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}
