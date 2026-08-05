using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_Avatar : GComponent
{
	public Controller Type;

	public GGraph mask;

	public GLoader Iconloader;

	public const string URL = "ui://kqd1t06osv6o1z";

	public static string Name = "UI_Avatar";

	public static string GetURL()
	{
		return "ui://kqd1t06osv6o1z";
	}

	public static UI_Avatar CreateInstance()
	{
		return (UI_Avatar)(object)UIPackage.CreateObject("QuickBattle", "Avatar");
	}

	public static UI_Avatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Avatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06osv6o1z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Iconloader = (GLoader)((GComponent)this).GetChild("Iconloader");
	}
}
