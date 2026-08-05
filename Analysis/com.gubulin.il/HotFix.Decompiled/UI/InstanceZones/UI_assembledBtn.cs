using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_assembledBtn : GButton
{
	public Controller button;

	public GImage n10;

	public const string URL = "ui://f4wr270rmm8nj";

	public static string Name = "UI_assembledBtn";

	public static string GetURL()
	{
		return "ui://f4wr270rmm8nj";
	}

	public static UI_assembledBtn CreateInstance()
	{
		return (UI_assembledBtn)(object)UIPackage.CreateObject("InstanceZones", "assembledBtn");
	}

	public static UI_assembledBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_assembledBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rmm8nj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
