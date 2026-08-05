using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_Halo : GButton
{
	public Controller button;

	public Controller Type;

	public GGraph mask;

	public GGraph back0;

	public GGraph back1;

	public GGraph back2;

	public GGraph back3;

	public GGraph back4;

	public const string URL = "ui://rujfbplhxooo1k";

	public static string Name = "UI_Halo";

	public static string GetURL()
	{
		return "ui://rujfbplhxooo1k";
	}

	public static UI_Halo CreateInstance()
	{
		return (UI_Halo)(object)UIPackage.CreateObject("SceneUi", "Halo");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		back0 = (GGraph)((GComponent)this).GetChild("back0");
		back1 = (GGraph)((GComponent)this).GetChild("back1");
		back2 = (GGraph)((GComponent)this).GetChild("back2");
		back3 = (GGraph)((GComponent)this).GetChild("back3");
		back4 = (GGraph)((GComponent)this).GetChild("back4");
	}
}
