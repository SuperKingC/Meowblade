using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Souvenir;

public class UI_com_Content : GComponent
{
	public GImage windowBack;

	public GLoader Icon;

	public GTextField n3;

	public GTextField ItemStock;

	public GTextField ItemName;

	public GList Content;

	public const string URL = "ui://8kibkcqi8zhy1";

	public static string Name = "UI_com_Content";

	public static string GetURL()
	{
		return "ui://8kibkcqi8zhy1";
	}

	public static UI_com_Content CreateInstance()
	{
		return (UI_com_Content)(object)UIPackage.CreateObject("Souvenir", "com_Content");
	}

	public static UI_com_Content CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Content).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8kibkcqi8zhy1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://8kibkcqi8zhy1".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		ItemStock = (GTextField)((GComponent)this).GetChild("ItemStock");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		Content = (GList)((GComponent)this).GetChild("Content");
	}
}
