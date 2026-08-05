using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_ConsumeItem : GComponent
{
	public Controller IsEnough;

	public GLoader ItemIcon;

	public GTextField Num;

	public const string URL = "ui://fpjheycbowndv4fj";

	public static string Name = "UI_ConsumeItem";

	public static string GetURL()
	{
		return "ui://fpjheycbowndv4fj";
	}

	public static UI_ConsumeItem CreateInstance()
	{
		return (UI_ConsumeItem)(object)UIPackage.CreateObject("GvGAmplifierForge", "ConsumeItem");
	}

	public static UI_ConsumeItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConsumeItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbowndv4fj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsEnough = ((GComponent)this).GetController("IsEnough");
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
	}
}
