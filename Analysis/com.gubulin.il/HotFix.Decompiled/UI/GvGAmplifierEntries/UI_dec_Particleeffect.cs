using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierEntries;

public class UI_dec_Particleeffect : GComponent
{
	public GImage mask;

	public GImage n8;

	public GImage n0;

	public GImage n3;

	public GImage n9;

	public Transition t0;

	public Transition t2;

	public const string URL = "ui://f1wmtifuir181f";

	public static string Name = "UI_dec_Particleeffect";

	public static string GetURL()
	{
		return "ui://f1wmtifuir181f";
	}

	public static UI_dec_Particleeffect CreateInstance()
	{
		return (UI_dec_Particleeffect)(object)UIPackage.CreateObject("GvGAmplifierEntries", "dec_Particleeffect");
	}

	public static UI_dec_Particleeffect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_Particleeffect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifuir181f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GImage)((GComponent)this).GetChild("mask");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		t0 = ((GComponent)this).GetTransition("t0");
		t2 = ((GComponent)this).GetTransition("t2");
	}
}
