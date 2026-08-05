using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_DropDownDialog : GComponent
{
	public GImage windowBack;

	public GTextField Title;

	public UI_ComboBoxList ComboBoxList;

	public const string URL = "ui://47lbpgx9yzxz3n";

	public static string Name = "UI_DropDownDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9yzxz3n";
	}

	public static UI_DropDownDialog CreateInstance()
	{
		return (UI_DropDownDialog)(object)UIPackage.CreateObject("Tips", "DropDownDialog");
	}

	public static UI_DropDownDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DropDownDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9yzxz3n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://47lbpgx9yzxz3n".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		ComboBoxList = (UI_ComboBoxList)(object)((GComponent)this).GetChild("ComboBoxList");
	}
}
