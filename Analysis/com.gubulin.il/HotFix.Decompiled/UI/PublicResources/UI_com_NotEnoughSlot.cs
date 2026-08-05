using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_NotEnoughSlot : GComponent
{
	public GImage n5;

	public GImage n6;

	public Transition t0;

	public const string URL = "ui://kt6rg65oabdlv4at";

	public static string Name = "UI_com_NotEnoughSlot";

	public static string GetURL()
	{
		return "ui://kt6rg65oabdlv4at";
	}

	public static UI_com_NotEnoughSlot CreateInstance()
	{
		return (UI_com_NotEnoughSlot)(object)UIPackage.CreateObject("PublicResources", "com_NotEnoughSlot");
	}

	public static UI_com_NotEnoughSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NotEnoughSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oabdlv4at", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
