using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_AttributeIcon2 : GButton
{
	public Controller Type;

	public Controller button;

	public Controller level;

	public UI_com_LegendItem Item;

	public GLoader attIcon;

	public GTextField attDesc;

	public const string URL = "ui://h09dvkcgtvyq5ltfb";

	public static string Name = "UI_btn_AttributeIcon2";

	public static string GetURL()
	{
		return "ui://h09dvkcgtvyq5ltfb";
	}

	public static UI_btn_AttributeIcon2 CreateInstance()
	{
		return (UI_btn_AttributeIcon2)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_AttributeIcon2");
	}

	public static UI_btn_AttributeIcon2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AttributeIcon2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgtvyq5ltfb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		button = ((GComponent)this).GetController("button");
		level = ((GComponent)this).GetController("level");
		Item = (UI_com_LegendItem)(object)((GComponent)this).GetChild("Item");
		attIcon = (GLoader)((GComponent)this).GetChild("attIcon");
		attDesc = (GTextField)((GComponent)this).GetChild("attDesc");
		string id = "ui://h09dvkcgtvyq5ltfb".Replace("ui://", "") + "-" + ((GObject)attDesc).id;
		((GObject)attDesc).text = LanguagesManager.GetDesc(id);
	}
}
