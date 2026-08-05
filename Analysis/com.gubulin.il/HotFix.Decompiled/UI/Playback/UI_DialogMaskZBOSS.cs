using FairyGUI;
using FairyGUI.Utils;

namespace UI.Playback;

public class UI_DialogMaskZBOSS : GComponent
{
	public GImage n14;

	public GImage n16;

	public GGroup n20;

	public GImage n15;

	public GImage n17;

	public GGroup n21;

	public Transition t0;

	public const string URL = "ui://9u6qpm6pf6zz1o";

	public static string Name = "UI_DialogMaskZBOSS";

	public static string GetURL()
	{
		return "ui://9u6qpm6pf6zz1o";
	}

	public static UI_DialogMaskZBOSS CreateInstance()
	{
		return (UI_DialogMaskZBOSS)(object)UIPackage.CreateObject("Playback", "DialogMaskZBOSS");
	}

	public static UI_DialogMaskZBOSS CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DialogMaskZBOSS).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://9u6qpm6pf6zz1o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n20 = (GGroup)((GComponent)this).GetChild("n20");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n21 = (GGroup)((GComponent)this).GetChild("n21");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
