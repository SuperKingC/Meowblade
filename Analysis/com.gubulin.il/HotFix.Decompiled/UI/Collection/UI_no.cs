using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Collection;

public class UI_no : GButton
{
	public Controller button;

	public GImage background;

	public GTextField title;

	public const string URL = "ui://ehe4tm5zb8ch1b";

	public static string Name = "UI_no";

	public static string GetURL()
	{
		return "ui://ehe4tm5zb8ch1b";
	}

	public static UI_no CreateInstance()
	{
		return (UI_no)(object)UIPackage.CreateObject("Collection", "no");
	}

	public static UI_no CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_no).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5zb8ch1b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://ehe4tm5zb8ch1b".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
