using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_LegendItemReplaceAnim : GComponent
{
	public GGraph mask;

	public GLoader LegendItem;

	public GLoader LegendItemReplace;

	public GMovieClip n1109;

	public Transition ShowReplace;

	public Transition ShowFlash;

	public const string URL = "ui://b9wlonaqrsoihs";

	public static string Name = "UI_LegendItemReplaceAnim";

	public static string GetURL()
	{
		return "ui://b9wlonaqrsoihs";
	}

	public static UI_LegendItemReplaceAnim CreateInstance()
	{
		return (UI_LegendItemReplaceAnim)(object)UIPackage.CreateObject("LegendItemCultivation", "LegendItemReplaceAnim");
	}

	public static UI_LegendItemReplaceAnim CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemReplaceAnim).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqrsoihs", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		LegendItem = (GLoader)((GComponent)this).GetChild("LegendItem");
		LegendItemReplace = (GLoader)((GComponent)this).GetChild("LegendItemReplace");
		n1109 = (GMovieClip)((GComponent)this).GetChild("n1109");
		ShowReplace = ((GComponent)this).GetTransition("ShowReplace");
		ShowFlash = ((GComponent)this).GetTransition("ShowFlash");
	}
}
