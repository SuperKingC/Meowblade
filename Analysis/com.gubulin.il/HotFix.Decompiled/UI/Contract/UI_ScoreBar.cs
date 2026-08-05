using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_ScoreBar : GButton
{
	public GImage bar;

	public const string URL = "ui://avplaivdnacht69";

	public static string Name = "UI_ScoreBar";

	public static string GetURL()
	{
		return "ui://avplaivdnacht69";
	}

	public static UI_ScoreBar CreateInstance()
	{
		return (UI_ScoreBar)(object)UIPackage.CreateObject("Contract", "ScoreBar");
	}

	public static UI_ScoreBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdnacht69", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
