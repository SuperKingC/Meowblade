using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_FormulaOemRewardCount : GComponent
{
	public GImage n29;

	public GTextField RewardCount;

	public GTextField n26;

	public const string URL = "ui://tt2iq07oj1h82y";

	public static string Name = "UI_com_FormulaOemRewardCount";

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h82y";
	}

	public static UI_com_FormulaOemRewardCount CreateInstance()
	{
		return (UI_com_FormulaOemRewardCount)(object)UIPackage.CreateObject("GvGExchange3", "com_FormulaOemRewardCount");
	}

	public static UI_com_FormulaOemRewardCount CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaOemRewardCount).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h82y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n29 = (GImage)((GComponent)this).GetChild("n29");
		RewardCount = (GTextField)((GComponent)this).GetChild("RewardCount");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id = "ui://tt2iq07oj1h82y".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id);
	}
}
