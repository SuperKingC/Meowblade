using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_PreviewContent : GComponent
{
	public GImage n3;

	public GTextField n5;

	public UI_com_Entries Entries;

	public UI_com_AllFx AllFx;

	public const string URL = "ui://h09dvkcgjpqaw";

	public static string Name = "UI_com_PreviewContent";

	public static string GetURL()
	{
		return "ui://h09dvkcgjpqaw";
	}

	public static UI_com_PreviewContent CreateInstance()
	{
		return (UI_com_PreviewContent)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_PreviewContent");
	}

	public static UI_com_PreviewContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PreviewContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgjpqaw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://h09dvkcgjpqaw".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		Entries = (UI_com_Entries)(object)((GComponent)this).GetChild("Entries");
		AllFx = (UI_com_AllFx)(object)((GComponent)this).GetChild("AllFx");
	}
}
