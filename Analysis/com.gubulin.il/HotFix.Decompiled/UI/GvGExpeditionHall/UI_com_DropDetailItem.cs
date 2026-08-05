using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_DropDetailItem : GComponent
{
	public GTextField itemName;

	public GTextField itemRate;

	public const string URL = "ui://k19peou7h49y6p93";

	public static string Name = "UI_com_DropDetailItem";

	public static string GetURL()
	{
		return "ui://k19peou7h49y6p93";
	}

	public static UI_com_DropDetailItem CreateInstance()
	{
		return (UI_com_DropDetailItem)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_DropDetailItem");
	}

	public static UI_com_DropDetailItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DropDetailItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7h49y6p93", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		itemName = (GTextField)((GComponent)this).GetChild("itemName");
		string id = "ui://k19peou7h49y6p93".Replace("ui://", "") + "-" + ((GObject)itemName).id;
		((GObject)itemName).text = LanguagesManager.GetDesc(id);
		itemRate = (GTextField)((GComponent)this).GetChild("itemRate");
		string id2 = "ui://k19peou7h49y6p93".Replace("ui://", "") + "-" + ((GObject)itemRate).id;
		((GObject)itemRate).text = LanguagesManager.GetDesc(id2);
	}
}
