using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierEntries;

public class UI_btn_StorageEntry : GButton
{
	public GImage n120;

	public GImage n116;

	public UI_dec_Particleeffect n119;

	public GImage n117;

	public UI_dec_Particleeffect2 n124;

	public Transition t0;

	public const string URL = "ui://f1wmtifub4va13";

	public static string Name = "UI_btn_StorageEntry";

	public static string GetURL()
	{
		return "ui://f1wmtifub4va13";
	}

	public static UI_btn_StorageEntry CreateInstance()
	{
		return (UI_btn_StorageEntry)(object)UIPackage.CreateObject("GvGAmplifierEntries", "btn_StorageEntry");
	}

	public static UI_btn_StorageEntry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_StorageEntry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifub4va13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n120 = (GImage)((GComponent)this).GetChild("n120");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		n119 = (UI_dec_Particleeffect)(object)((GComponent)this).GetChild("n119");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n124 = (UI_dec_Particleeffect2)(object)((GComponent)this).GetChild("n124");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
