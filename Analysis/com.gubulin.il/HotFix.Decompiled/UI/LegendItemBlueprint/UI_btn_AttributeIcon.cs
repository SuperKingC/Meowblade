using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_AttributeIcon : GButton
{
	public Controller Type;

	public Controller button;

	public GImage n5;

	public GImage n4;

	public UI_com_LegendItem Item;

	public GLoader attIcon;

	public GTextField attDesc;

	public const string URL = "ui://h09dvkcgqyyy4h";

	public static string Name = "UI_btn_AttributeIcon";

	public static string GetURL()
	{
		return "ui://h09dvkcgqyyy4h";
	}

	public static UI_btn_AttributeIcon CreateInstance()
	{
		return (UI_btn_AttributeIcon)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_AttributeIcon");
	}

	public static UI_btn_AttributeIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AttributeIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgqyyy4h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Item = (UI_com_LegendItem)(object)((GComponent)this).GetChild("Item");
		attIcon = (GLoader)((GComponent)this).GetChild("attIcon");
		attDesc = (GTextField)((GComponent)this).GetChild("attDesc");
		string id = "ui://h09dvkcgqyyy4h".Replace("ui://", "") + "-" + ((GObject)attDesc).id;
		((GObject)attDesc).text = LanguagesManager.GetDesc(id);
	}
}
