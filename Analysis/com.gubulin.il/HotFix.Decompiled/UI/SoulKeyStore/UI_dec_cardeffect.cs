using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoulKeyStore;

public class UI_dec_cardeffect : GComponent
{
	public Controller Soulkeytype;

	public GImage n41;

	public GImage n40;

	public GImage n42;

	public GImage n44;

	public Transition t0;

	public const string URL = "ui://3nd2hqkiqmsbu";

	public static string Name = "UI_dec_cardeffect";

	public static string GetURL()
	{
		return "ui://3nd2hqkiqmsbu";
	}

	public static UI_dec_cardeffect CreateInstance()
	{
		return (UI_dec_cardeffect)(object)UIPackage.CreateObject("SoulKeyStore", "dec_cardeffect");
	}

	public static UI_dec_cardeffect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_cardeffect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkiqmsbu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Soulkeytype = ((GComponent)this).GetController("Soulkeytype");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
