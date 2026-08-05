using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_no : GButton
{
	public Controller button;

	public GImage background;

	public GTextField Title;

	public GGraph n7;

	public const string URL = "ui://b9wlonaqmpf91b";

	public static string Name = "UI_no";

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf91b";
	}

	public static UI_no CreateInstance()
	{
		return (UI_no)(object)UIPackage.CreateObject("LegendItemCultivation", "no");
	}

	public static UI_no CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_no).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf91b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://b9wlonaqmpf91b".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		n7 = (GGraph)((GComponent)this).GetChild("n7");
	}
}
