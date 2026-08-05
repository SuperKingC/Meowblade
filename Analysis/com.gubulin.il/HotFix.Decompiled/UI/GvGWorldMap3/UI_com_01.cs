using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_01 : GComponent
{
	public Controller Camp;

	public GLoader n19;

	public GLoader FlagShip;

	public GLoader n18;

	public GImage n26;

	public GMovieClip n16;

	public GMovieClip n17;

	public GMovieClip n20;

	public GMovieClip n21;

	public GMovieClip n22;

	public GMovieClip n23;

	public GMovieClip n24;

	public GMovieClip n25;

	public GImage n27;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://4eq8fgd2sjg6s6f";

	public static string Name = "UI_com_01";

	public static string GetURL()
	{
		return "ui://4eq8fgd2sjg6s6f";
	}

	public static UI_com_01 CreateInstance()
	{
		return (UI_com_01)(object)UIPackage.CreateObject("GvGWorldMap3", "com_01");
	}

	public static UI_com_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2sjg6s6f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n19 = (GLoader)((GComponent)this).GetChild("n19");
		FlagShip = (GLoader)((GComponent)this).GetChild("FlagShip");
		n18 = (GLoader)((GComponent)this).GetChild("n18");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n16 = (GMovieClip)((GComponent)this).GetChild("n16");
		n17 = (GMovieClip)((GComponent)this).GetChild("n17");
		n20 = (GMovieClip)((GComponent)this).GetChild("n20");
		n21 = (GMovieClip)((GComponent)this).GetChild("n21");
		n22 = (GMovieClip)((GComponent)this).GetChild("n22");
		n23 = (GMovieClip)((GComponent)this).GetChild("n23");
		n24 = (GMovieClip)((GComponent)this).GetChild("n24");
		n25 = (GMovieClip)((GComponent)this).GetChild("n25");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
