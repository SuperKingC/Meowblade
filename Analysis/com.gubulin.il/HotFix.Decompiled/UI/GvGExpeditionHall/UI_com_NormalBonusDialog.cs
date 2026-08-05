using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_NormalBonusDialog : GComponent
{
	public GImage tipBack;

	public GTextField n1;

	public GList ItemList;

	public GTextField n49;

	public const string URL = "ui://k19peou7nroy34";

	public static string Name = "UI_com_NormalBonusDialog";

	public static string GetURL()
	{
		return "ui://k19peou7nroy34";
	}

	public static UI_com_NormalBonusDialog CreateInstance()
	{
		return (UI_com_NormalBonusDialog)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_NormalBonusDialog");
	}

	public static UI_com_NormalBonusDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NormalBonusDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7nroy34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://k19peou7nroy34".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		ItemList = (GList)((GComponent)this).GetChild("ItemList");
		n49 = (GTextField)((GComponent)this).GetChild("n49");
		string id2 = "ui://k19peou7nroy34".Replace("ui://", "") + "-" + ((GObject)n49).id;
		((GObject)n49).text = LanguagesManager.GetDesc(id2);
	}
}
