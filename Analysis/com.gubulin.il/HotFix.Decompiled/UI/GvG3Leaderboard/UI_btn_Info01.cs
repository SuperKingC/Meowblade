using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_btn_Info01 : GButton
{
	public Controller button;

	public GImage n184;

	public GImage n185;

	public const string URL = "ui://ylvfgf90cbjb6o";

	public static string Name = "UI_btn_Info01";

	public static string GetURL()
	{
		return "ui://ylvfgf90cbjb6o";
	}

	public static UI_btn_Info01 CreateInstance()
	{
		return (UI_btn_Info01)(object)UIPackage.CreateObject("GvG3Leaderboard", "btn_Info01");
	}

	public static UI_btn_Info01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Info01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90cbjb6o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n184 = (GImage)((GComponent)this).GetChild("n184");
		n185 = (GImage)((GComponent)this).GetChild("n185");
	}
}
