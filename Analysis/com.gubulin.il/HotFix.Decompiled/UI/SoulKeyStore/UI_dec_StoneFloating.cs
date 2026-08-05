using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoulKeyStore;

public class UI_dec_StoneFloating : GComponent
{
	public GImage n0;

	public Transition t0;

	public const string URL = "ui://3nd2hqkit9an14";

	public static string Name = "UI_dec_StoneFloating";

	public static string GetURL()
	{
		return "ui://3nd2hqkit9an14";
	}

	public static UI_dec_StoneFloating CreateInstance()
	{
		return (UI_dec_StoneFloating)(object)UIPackage.CreateObject("SoulKeyStore", "dec_StoneFloating");
	}

	public static UI_dec_StoneFloating CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_StoneFloating).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkit9an14", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
