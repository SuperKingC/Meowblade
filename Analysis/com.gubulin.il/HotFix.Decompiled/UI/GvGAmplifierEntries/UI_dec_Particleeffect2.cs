using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierEntries;

public class UI_dec_Particleeffect2 : GComponent
{
	public GImage mask;

	public GImage n10;

	public GImage n11;

	public Transition t3;

	public const string URL = "ui://f1wmtifuir181h";

	public static string Name = "UI_dec_Particleeffect2";

	public static string GetURL()
	{
		return "ui://f1wmtifuir181h";
	}

	public static UI_dec_Particleeffect2 CreateInstance()
	{
		return (UI_dec_Particleeffect2)(object)UIPackage.CreateObject("GvGAmplifierEntries", "dec_Particleeffect2");
	}

	public static UI_dec_Particleeffect2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_Particleeffect2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifuir181h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		mask = (GImage)((GComponent)this).GetChild("mask");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		t3 = ((GComponent)this).GetTransition("t3");
	}
}
