using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_TopThreeItems : GComponent
{
	public GImage n12;

	public GImage n13;

	public GImage n14;

	public GList RewardList;

	public GImage n15;

	public GImage n0;

	public GTextField n11;

	public const string URL = "ui://82mo10n5t7wpde6";

	public static string Name = "UI_TopThreeItems";

	public static string GetURL()
	{
		return "ui://82mo10n5t7wpde6";
	}

	public static UI_TopThreeItems CreateInstance()
	{
		return (UI_TopThreeItems)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopThreeItems");
	}

	public static UI_TopThreeItems CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopThreeItems).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5t7wpde6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		RewardList = (GList)((GComponent)this).GetChild("RewardList");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://82mo10n5t7wpde6".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
	}
}
