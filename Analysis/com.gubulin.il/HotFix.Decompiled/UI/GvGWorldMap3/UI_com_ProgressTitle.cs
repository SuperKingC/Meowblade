using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_ProgressTitle : GComponent
{
	public Controller Progress;

	public GImage n33;

	public GImage n37;

	public GImage n36;

	public GImage n34;

	public GMovieClip n38;

	public GMovieClip n39;

	public GImage n35;

	public GLoader n41;

	public GGroup n42;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2qw45gy";

	public static string Name = "UI_com_ProgressTitle";

	public static string GetURL()
	{
		return "ui://4eq8fgd2qw45gy";
	}

	public static UI_com_ProgressTitle CreateInstance()
	{
		return (UI_com_ProgressTitle)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ProgressTitle");
	}

	public static UI_com_ProgressTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProgressTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qw45gy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Progress = ((GComponent)this).GetController("Progress");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n38 = (GMovieClip)((GComponent)this).GetChild("n38");
		n39 = (GMovieClip)((GComponent)this).GetChild("n39");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n41 = (GLoader)((GComponent)this).GetChild("n41");
		n42 = (GGroup)((GComponent)this).GetChild("n42");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
