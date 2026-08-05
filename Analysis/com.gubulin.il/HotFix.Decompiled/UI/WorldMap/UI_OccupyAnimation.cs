using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_OccupyAnimation : GComponent
{
	public GMovieClip main;

	public const string URL = "ui://c9n2h0ksj93ujn";

	public static string Name = "UI_OccupyAnimation";

	public static string GetURL()
	{
		return "ui://c9n2h0ksj93ujn";
	}

	public static UI_OccupyAnimation CreateInstance()
	{
		return (UI_OccupyAnimation)(object)UIPackage.CreateObject("WorldMap", "OccupyAnimation");
	}

	public static UI_OccupyAnimation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OccupyAnimation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksj93ujn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		main = (GMovieClip)((GComponent)this).GetChild("main");
	}
}
