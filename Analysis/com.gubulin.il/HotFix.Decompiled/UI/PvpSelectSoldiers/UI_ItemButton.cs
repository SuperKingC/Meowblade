using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ItemButton : GComponent
{
	public GGraph FxBack;

	public GImage Bg;

	public GLoader icon;

	public GGraph FxForeground;

	public GRichTextField title;

	public const string URL = "ui://82mo10n5shlxdao";

	public static string Name = "UI_ItemButton";

	public static string GetURL()
	{
		return "ui://82mo10n5shlxdao";
	}

	public static UI_ItemButton CreateInstance()
	{
		return (UI_ItemButton)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ItemButton");
	}

	public static UI_ItemButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ItemButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5shlxdao", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		FxBack = (GGraph)((GComponent)this).GetChild("FxBack");
		Bg = (GImage)((GComponent)this).GetChild("Bg");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		FxForeground = (GGraph)((GComponent)this).GetChild("FxForeground");
		title = (GRichTextField)((GComponent)this).GetChild("title");
	}
}
