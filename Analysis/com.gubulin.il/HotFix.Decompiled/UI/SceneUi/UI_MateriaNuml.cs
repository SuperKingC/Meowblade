using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_MateriaNuml : GComponent
{
	public GTextField curNum;

	public GTextField sprit;

	public GTextField requireNum;

	public const string URL = "ui://rujfbplhnwjt17";

	public static string Name = "UI_MateriaNuml";

	public static string GetURL()
	{
		return "ui://rujfbplhnwjt17";
	}

	public static UI_MateriaNuml CreateInstance()
	{
		return (UI_MateriaNuml)(object)UIPackage.CreateObject("SceneUi", "MateriaNuml");
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
		curNum = (GTextField)((GComponent)this).GetChild("curNum");
		sprit = (GTextField)((GComponent)this).GetChild("sprit");
		requireNum = (GTextField)((GComponent)this).GetChild("requireNum");
	}
}
