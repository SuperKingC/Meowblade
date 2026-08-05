using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_TimeCounter : GComponent
{
	public GImage n65;

	public GImage n66;

	public GTextField TimeOnIsland;

	public Transition TimeCounterHeartBeat;

	public const string URL = "ui://hd2s9kukskm15m";

	public static string Name = "UI_TimeCounter";

	public static string GetURL()
	{
		return "ui://hd2s9kukskm15m";
	}

	public static UI_TimeCounter CreateInstance()
	{
		return (UI_TimeCounter)(object)UIPackage.CreateObject("GvGWorldMap2", "TimeCounter");
	}

	public static UI_TimeCounter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TimeCounter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukskm15m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		TimeOnIsland = (GTextField)((GComponent)this).GetChild("TimeOnIsland");
		string id = "ui://hd2s9kukskm15m".Replace("ui://", "") + "-" + ((GObject)TimeOnIsland).id;
		((GObject)TimeOnIsland).text = LanguagesManager.GetDesc(id);
		TimeCounterHeartBeat = ((GComponent)this).GetTransition("TimeCounterHeartBeat");
	}
}
