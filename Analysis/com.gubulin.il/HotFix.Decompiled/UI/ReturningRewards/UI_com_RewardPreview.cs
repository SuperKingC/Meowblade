using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_com_RewardPreview : GComponent
{
	public GImage Background;

	public GImage n5;

	public GImage n9;

	public GImage n10;

	public GImage n6;

	public GImage n7;

	public GList Rewards;

	public GTextField n3;

	public GButton Confirm;

	public const string URL = "ui://rx5ntv98win22";

	public static string Name = "UI_com_RewardPreview";

	public static string GetURL()
	{
		return "ui://rx5ntv98win22";
	}

	public static UI_com_RewardPreview CreateInstance()
	{
		return (UI_com_RewardPreview)(object)UIPackage.CreateObject("ReturningRewards", "com_RewardPreview");
	}

	public static UI_com_RewardPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RewardPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win22", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		Rewards = (GList)((GComponent)this).GetChild("Rewards");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://rx5ntv98win22".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		Confirm = (GButton)((GComponent)this).GetChild("Confirm");
	}
}
