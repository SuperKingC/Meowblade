using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_HeadPortrait : GComponent
{
	public Controller Type;

	public GGraph Mask;

	public GImage n7;

	public GLoader icon;

	public const string URL = "ui://hozu168rzbfu30";

	public static string Name = "UI_com_HeadPortrait";

	public static string GetURL()
	{
		return "ui://hozu168rzbfu30";
	}

	public static UI_com_HeadPortrait CreateInstance()
	{
		return (UI_com_HeadPortrait)(object)UIPackage.CreateObject("GvGBrawlFight", "com_HeadPortrait");
	}

	public static UI_com_HeadPortrait CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_HeadPortrait).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rzbfu30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
