using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_DrawLegendItem : GButton
{
	public Controller button;

	public GTextField num;

	public UI_DrawBtn DrawBtn;

	public UI_ItemDisplay Icon;

	public const string URL = "ui://2eraz3j9y9rzm";

	public static string Name = "UI_DrawLegendItem";

	public static string GetURL()
	{
		return "ui://2eraz3j9y9rzm";
	}

	public static UI_DrawLegendItem CreateInstance()
	{
		return (UI_DrawLegendItem)(object)UIPackage.CreateObject("LegendItemDungeon", "DrawLegendItem");
	}

	public static UI_DrawLegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DrawLegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9y9rzm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://2eraz3j9y9rzm".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		DrawBtn = (UI_DrawBtn)(object)((GComponent)this).GetChild("DrawBtn");
		Icon = (UI_ItemDisplay)(object)((GComponent)this).GetChild("Icon");
	}
}
