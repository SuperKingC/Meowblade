using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_dec_01 : GComponent
{
	public GImage n44;

	public GImage n45;

	public Transition t0;

	public const string URL = "ui://249h3k3du1h2s59";

	public static string Name = "UI_dec_01";

	public static string GetURL()
	{
		return "ui://249h3k3du1h2s59";
	}

	public static UI_dec_01 CreateInstance()
	{
		return (UI_dec_01)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "dec_01");
	}

	public static UI_dec_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3du1h2s59", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
