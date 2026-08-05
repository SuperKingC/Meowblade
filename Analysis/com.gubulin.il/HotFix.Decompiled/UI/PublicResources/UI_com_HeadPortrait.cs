using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_HeadPortrait : GComponent
{
	public Controller Type;

	public GGraph Mask;

	public GLoader icon;

	public const string URL = "ui://kt6rg65oigs2v4nt";

	public static string Name = "UI_com_HeadPortrait";

	public static string GetURL()
	{
		return "ui://kt6rg65oigs2v4nt";
	}

	public static UI_com_HeadPortrait CreateInstance()
	{
		return (UI_com_HeadPortrait)(object)UIPackage.CreateObject("PublicResources", "com_HeadPortrait");
	}

	public static UI_com_HeadPortrait CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_HeadPortrait).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oigs2v4nt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
