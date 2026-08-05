using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItems;

public class UI_com_BlueprintList : GComponent
{
	public Controller State;

	public GTextField Tip0;

	public GList BlueprintList;

	public const string URL = "ui://l6qef30pfz2se";

	public static string Name = "UI_com_BlueprintList";

	public static string GetURL()
	{
		return "ui://l6qef30pfz2se";
	}

	public static UI_com_BlueprintList CreateInstance()
	{
		return (UI_com_BlueprintList)(object)UIPackage.CreateObject("LegendItems", "com_BlueprintList");
	}

	public static UI_com_BlueprintList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BlueprintList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30pfz2se", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		Tip0 = (GTextField)((GComponent)this).GetChild("Tip0");
		string id = "ui://l6qef30pfz2se".Replace("ui://", "") + "-" + ((GObject)Tip0).id;
		((GObject)Tip0).text = LanguagesManager.GetDesc(id);
		BlueprintList = (GList)((GComponent)this).GetChild("BlueprintList");
	}
}
