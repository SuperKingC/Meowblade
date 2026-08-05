using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_dec_SceneAnimation : GComponent
{
	public GImage n141;

	public UI_dec_SceneAnimationLight01 n142;

	public GImage n147;

	public GImage n148;

	public GImage n149;

	public GImage n150;

	public GImage n152;

	public GImage n153;

	public Transition t0;

	public const string URL = "ui://k19peou7mntx3n";

	public static string Name = "UI_dec_SceneAnimation";

	public static string GetURL()
	{
		return "ui://k19peou7mntx3n";
	}

	public static UI_dec_SceneAnimation CreateInstance()
	{
		return (UI_dec_SceneAnimation)(object)UIPackage.CreateObject("GvGExpeditionHall", "dec_SceneAnimation");
	}

	public static UI_dec_SceneAnimation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_SceneAnimation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7mntx3n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
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
		n141 = (GImage)((GComponent)this).GetChild("n141");
		n142 = (UI_dec_SceneAnimationLight01)(object)((GComponent)this).GetChild("n142");
		n147 = (GImage)((GComponent)this).GetChild("n147");
		n148 = (GImage)((GComponent)this).GetChild("n148");
		n149 = (GImage)((GComponent)this).GetChild("n149");
		n150 = (GImage)((GComponent)this).GetChild("n150");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
