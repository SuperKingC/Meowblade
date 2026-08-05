using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_DisplayLegendSlot : GComponent
{
	public GImage n5;

	public GImage n0;

	public GImage n1;

	public GImage n2;

	public GTextField Tip;

	public GTextField Tip1;

	public GImage note;

	public const string URL = "ui://7dantnbifjjstah";

	public static string Name = "UI_DisplayLegendSlot";

	public static string GetURL()
	{
		return "ui://7dantnbifjjstah";
	}

	public static UI_DisplayLegendSlot CreateInstance()
	{
		return (UI_DisplayLegendSlot)(object)UIPackage.CreateObject("SoldierCultivate", "DisplayLegendSlot");
	}

	public static UI_DisplayLegendSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DisplayLegendSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbifjjstah", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id = "ui://7dantnbifjjstah".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
		Tip1 = (GTextField)((GComponent)this).GetChild("Tip1");
		string id2 = "ui://7dantnbifjjstah".Replace("ui://", "") + "-" + ((GObject)Tip1).id;
		((GObject)Tip1).text = LanguagesManager.GetDesc(id2);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
