using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_jobSschedule : GProgressBar
{
	public GImage back;

	public GImage bar;

	public GTextField time;

	public GImage n5;

	public const string URL = "ui://kt6rg65oheur6i";

	public static string Name = "UI_jobSschedule";

	public static string GetURL()
	{
		return "ui://kt6rg65oheur6i";
	}

	public static UI_jobSschedule CreateInstance()
	{
		return (UI_jobSschedule)(object)UIPackage.CreateObject("PublicResources", "jobSschedule");
	}

	public static UI_jobSschedule CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_jobSschedule).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oheur6i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		bar = (GImage)((GComponent)this).GetChild("bar");
		time = (GTextField)((GComponent)this).GetChild("time");
		string id = "ui://kt6rg65oheur6i".Replace("ui://", "") + "-" + ((GObject)time).id;
		((GObject)time).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
