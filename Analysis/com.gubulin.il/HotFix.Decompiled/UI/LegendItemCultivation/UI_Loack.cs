using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_Loack : GButton
{
	public Controller button;

	public GImage background;

	public GRichTextField title;

	public const string URL = "ui://b9wlonaqtpmth";

	public static string Name = "UI_Loack";

	public static string GetURL()
	{
		return "ui://b9wlonaqtpmth";
	}

	public static UI_Loack CreateInstance()
	{
		return (UI_Loack)(object)UIPackage.CreateObject("LegendItemCultivation", "Loack");
	}

	public static UI_Loack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Loack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqtpmth", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		background = (GImage)((GComponent)this).GetChild("background");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9wlonaqtpmth".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
