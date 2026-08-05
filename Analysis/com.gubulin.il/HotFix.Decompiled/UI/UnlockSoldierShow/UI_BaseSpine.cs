using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_BaseSpine : GComponent
{
	public GImage n82;

	public UI_dec_light03 n81;

	public Transition t0;

	public const string URL = "ui://ia1am3ehkfyut3e";

	public static string Name = "UI_BaseSpine";

	public static string GetURL()
	{
		return "ui://ia1am3ehkfyut3e";
	}

	public static UI_BaseSpine CreateInstance()
	{
		return (UI_BaseSpine)(object)UIPackage.CreateObject("UnlockSoldierShow", "BaseSpine");
	}

	public static UI_BaseSpine CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BaseSpine).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehkfyut3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n81 = (UI_dec_light03)(object)((GComponent)this).GetChild("n81");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
