using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_ComboBox1 : GComponent
{
	public Controller buttonController;

	public Controller listController;

	public GTextField title;

	public GImage icon;

	public GGraph listBg;

	public GList list;

	public const string URL = "ui://b9yxt7u0t1jre";

	public static string Name = "UI_ComboBox1";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jre";
	}

	public static UI_ComboBox1 CreateInstance()
	{
		return (UI_ComboBox1)(object)UIPackage.CreateObject("AccountInfo", "ComboBox1");
	}

	public static UI_ComboBox1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ComboBox1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jre", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		buttonController = ((GComponent)this).GetController("buttonController");
		listController = ((GComponent)this).GetController("listController");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9yxt7u0t1jre".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		icon = (GImage)((GComponent)this).GetChild("icon");
		listBg = (GGraph)((GComponent)this).GetChild("listBg");
		list = (GList)((GComponent)this).GetChild("list");
	}
}
