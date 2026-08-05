using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_FinalBossPop : GComponent
{
	public GGraph n106;

	public GTextField n107;

	public const string URL = "ui://0i520nzmdy01odw";

	public static string Name = "UI_FinalBossPop";

	public static string GetURL()
	{
		return "ui://0i520nzmdy01odw";
	}

	public static UI_FinalBossPop CreateInstance()
	{
		return (UI_FinalBossPop)(object)UIPackage.CreateObject("LordOfDreams", "FinalBossPop");
	}

	public static UI_FinalBossPop CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FinalBossPop).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmdy01odw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n106 = (GGraph)((GComponent)this).GetChild("n106");
		n107 = (GTextField)((GComponent)this).GetChild("n107");
		string id = "ui://0i520nzmdy01odw".Replace("ui://", "") + "-" + ((GObject)n107).id;
		((GObject)n107).text = LanguagesManager.GetDesc(id);
	}
}
