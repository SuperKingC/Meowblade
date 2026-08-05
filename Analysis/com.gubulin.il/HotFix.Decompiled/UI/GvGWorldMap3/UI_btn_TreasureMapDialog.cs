using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_TreasureMapDialog : GButton
{
	public Controller button;

	public Controller hasOuterTech;

	public GImage n5;

	public GImage n8;

	public GTextField n6;

	public GTextField n9;

	public GLoader n7;

	public GImage n10;

	public const string URL = "ui://4eq8fgd2dc6m8c";

	public static string Name = "UI_btn_TreasureMapDialog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2dc6m8c";
	}

	public static UI_btn_TreasureMapDialog CreateInstance()
	{
		return (UI_btn_TreasureMapDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_TreasureMapDialog");
	}

	public static UI_btn_TreasureMapDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TreasureMapDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2dc6m8c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		hasOuterTech = ((GComponent)this).GetController("hasOuterTech");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://4eq8fgd2dc6m8c".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id2 = "ui://4eq8fgd2dc6m8c".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id2);
		n7 = (GLoader)((GComponent)this).GetChild("n7");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
