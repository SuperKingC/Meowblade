using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGMode3Collecting;

public class UI_com_CollectingItem : GComponent
{
	public GLoader Icon;

	public GTextField Num;

	public const string URL = "ui://n2y4xuvarxuqe";

	public static string Name = "UI_com_CollectingItem";

	public static string GetURL()
	{
		return "ui://n2y4xuvarxuqe";
	}

	public static UI_com_CollectingItem CreateInstance()
	{
		return (UI_com_CollectingItem)(object)UIPackage.CreateObject("GvGMode3Collecting", "com_CollectingItem");
	}

	public static UI_com_CollectingItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CollectingItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuqe", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		string id = "ui://n2y4xuvarxuqe".Replace("ui://", "") + "-" + ((GObject)Num).id;
		((GObject)Num).text = LanguagesManager.GetDesc(id);
	}
}
