using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_WorkNum : GButton
{
	public Controller button;

	public GTextField title;

	public GMovieClip n8;

	public const string URL = "ui://rujfbplhwj3d1e";

	public static string Name = "UI_WorkNum";

	public static string GetURL()
	{
		return "ui://rujfbplhwj3d1e";
	}

	public static UI_WorkNum CreateInstance()
	{
		return (UI_WorkNum)(object)UIPackage.CreateObject("SceneUi", "WorkNum");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		title = (GTextField)((GComponent)this).GetChild("title");
		n8 = (GMovieClip)((GComponent)this).GetChild("n8");
	}
}
