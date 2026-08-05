using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMForge3;

public class UI_com_AnimationTaser : GComponent
{
	public GImage n168;

	public GImage n167;

	public GImage n169;

	public GImage n173;

	public GImage n172;

	public GImage n171;

	public GImage n174;

	public GImage n175;

	public Transition t0;

	public const string URL = "ui://hotvoz3ppg604z";

	public static string Name = "UI_com_AnimationTaser";

	public static string GetURL()
	{
		return "ui://hotvoz3ppg604z";
	}

	public static UI_com_AnimationTaser CreateInstance()
	{
		return (UI_com_AnimationTaser)(object)UIPackage.CreateObject("GvGOEMForge3", "com_AnimationTaser");
	}

	public static UI_com_AnimationTaser CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AnimationTaser).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hotvoz3ppg604z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n168 = (GImage)((GComponent)this).GetChild("n168");
		n167 = (GImage)((GComponent)this).GetChild("n167");
		n169 = (GImage)((GComponent)this).GetChild("n169");
		n173 = (GImage)((GComponent)this).GetChild("n173");
		n172 = (GImage)((GComponent)this).GetChild("n172");
		n171 = (GImage)((GComponent)this).GetChild("n171");
		n174 = (GImage)((GComponent)this).GetChild("n174");
		n175 = (GImage)((GComponent)this).GetChild("n175");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
