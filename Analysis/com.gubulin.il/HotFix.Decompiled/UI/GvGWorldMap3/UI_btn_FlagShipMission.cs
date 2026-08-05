using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_FlagShipMission : GButton
{
	public Controller button;

	public Controller Step;

	public Controller Progress;

	public Controller RedDot;

	public GImage n15;

	public GImage n16;

	public GImage n18;

	public GImage n3;

	public GLoader n17;

	public GButton n20;

	public const string URL = "ui://4eq8fgd2qf7c7p";

	public static string Name = "UI_btn_FlagShipMission";

	public static string GetURL()
	{
		return "ui://4eq8fgd2qf7c7p";
	}

	public static UI_btn_FlagShipMission CreateInstance()
	{
		return (UI_btn_FlagShipMission)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_FlagShipMission");
	}

	public static UI_btn_FlagShipMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FlagShipMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qf7c7p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Step = ((GComponent)this).GetController("Step");
		Progress = ((GComponent)this).GetController("Progress");
		RedDot = ((GComponent)this).GetController("RedDot");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n17 = (GLoader)((GComponent)this).GetChild("n17");
		n20 = (GButton)((GComponent)this).GetChild("n20");
	}
}
