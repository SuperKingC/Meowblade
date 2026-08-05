using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_MaxIconSlot : GComponent
{
	public GImage n1;

	public GImage max;

	public Transition t0;

	public const string URL = "ui://kt6rg65oabdlv4as";

	public static string Name = "UI_com_MaxIconSlot";

	public static string GetURL()
	{
		return "ui://kt6rg65oabdlv4as";
	}

	public static UI_com_MaxIconSlot CreateInstance()
	{
		return (UI_com_MaxIconSlot)(object)UIPackage.CreateObject("PublicResources", "com_MaxIconSlot");
	}

	public static UI_com_MaxIconSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MaxIconSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oabdlv4as", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		max = (GImage)((GComponent)this).GetChild("max");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
