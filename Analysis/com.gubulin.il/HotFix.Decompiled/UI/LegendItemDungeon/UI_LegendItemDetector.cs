using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_LegendItemDetector : GComponent
{
	public GTextField n0;

	public GTextField SignalText;

	public GGraph SpineBack;

	public const string URL = "ui://2eraz3j9qjbr1u";

	public static string Name = "UI_LegendItemDetector";

	public static string GetURL()
	{
		return "ui://2eraz3j9qjbr1u";
	}

	public static UI_LegendItemDetector CreateInstance()
	{
		return (UI_LegendItemDetector)(object)UIPackage.CreateObject("LegendItemDungeon", "LegendItemDetector");
	}

	public static UI_LegendItemDetector CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemDetector).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9qjbr1u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://2eraz3j9qjbr1u".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		SignalText = (GTextField)((GComponent)this).GetChild("SignalText");
		string id2 = "ui://2eraz3j9qjbr1u".Replace("ui://", "") + "-" + ((GObject)SignalText).id;
		((GObject)SignalText).text = LanguagesManager.GetDesc(id2);
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
	}
}
