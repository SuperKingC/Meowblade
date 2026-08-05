using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_ReturningScore : GComponent
{
	public GImage n3;

	public GImage n0;

	public GTextField Score;

	public const string URL = "ui://rx5ntv98win2h";

	public static string Name = "UI_com_ReturningScore";

	public static string GetURL()
	{
		return "ui://rx5ntv98win2h";
	}

	public static UI_com_ReturningScore CreateInstance()
	{
		return (UI_com_ReturningScore)(object)UIPackage.CreateObject("ReturningRewards", "com_ReturningScore");
	}

	public static UI_com_ReturningScore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ReturningScore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Score = (GTextField)((GComponent)this).GetChild("Score");
	}

	public void Update(int score)
	{
		((GObject)Score).text = score.ToString();
	}
}
