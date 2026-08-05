using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_com_MythLevelValueUpdate : GComponent
{
	public GImage n14;

	public GMovieClip n15;

	public GMovieClip n17;

	public GMovieClip n19;

	public GImage n21;

	public GMovieClip n22;

	public GMovieClip n23;

	public GMovieClip n24;

	public GImage n26;

	public GMovieClip n27;

	public GMovieClip n28;

	public GMovieClip n29;

	public GGroup n31;

	public Transition t0;

	public const string URL = "ui://7dantnbipbt76tck";

	public static string Name = "UI_com_MythLevelValueUpdate";

	public static string GetURL()
	{
		return "ui://7dantnbipbt76tck";
	}

	public static UI_com_MythLevelValueUpdate CreateInstance()
	{
		return (UI_com_MythLevelValueUpdate)(object)UIPackage.CreateObject("SoldierCultivate", "com_MythLevelValueUpdate");
	}

	public static UI_com_MythLevelValueUpdate CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MythLevelValueUpdate).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbipbt76tck", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GMovieClip)((GComponent)this).GetChild("n15");
		n17 = (GMovieClip)((GComponent)this).GetChild("n17");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GMovieClip)((GComponent)this).GetChild("n22");
		n23 = (GMovieClip)((GComponent)this).GetChild("n23");
		n24 = (GMovieClip)((GComponent)this).GetChild("n24");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GMovieClip)((GComponent)this).GetChild("n27");
		n28 = (GMovieClip)((GComponent)this).GetChild("n28");
		n29 = (GMovieClip)((GComponent)this).GetChild("n29");
		n31 = (GGroup)((GComponent)this).GetChild("n31");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
