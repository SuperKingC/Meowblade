using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_PropetryLock : GButton
{
	public Controller button;

	public GGraph n6;

	public GImage bg;

	public GImage n4;

	public GTextField Title;

	public GGraph n7;

	public const string URL = "ui://b9wlonaqmpf91n";

	public static string Name = "UI_PropetryLock";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://b9wlonaqmpf91n".Replace("ui://", ""), ((GObject)Title).id, button.selectedIndex);
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf91n";
	}

	public static UI_PropetryLock CreateInstance()
	{
		return (UI_PropetryLock)(object)UIPackage.CreateObject("LegendItemCultivation", "PropetryLock");
	}

	public static UI_PropetryLock CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PropetryLock).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf91n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
	}
}
