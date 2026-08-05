using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_OurInfomationBar : GComponent
{
	public GTextField ArmyGroupLevel;

	public GTextField ArmyGroupName;

	public UI_RankingListAvatar Avatar;

	public GImage iconBack;

	public GLoader Iconloader;

	public GLoader Frameloader;

	public GGroup n6;

	public GList OurMedalList;

	public const string URL = "ui://82mo10n5vxze5s";

	public static string Name = "UI_OurInfomationBar";

	public static string GetURL()
	{
		return "ui://82mo10n5vxze5s";
	}

	public static UI_OurInfomationBar CreateInstance()
	{
		return (UI_OurInfomationBar)(object)UIPackage.CreateObject("PvpSelectSoldiers", "OurInfomationBar");
	}

	public static UI_OurInfomationBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OurInfomationBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5vxze5s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
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
		((GComponent)this).ConstructFromXML(xml);
		ArmyGroupLevel = (GTextField)((GComponent)this).GetChild("ArmyGroupLevel");
		ArmyGroupName = (GTextField)((GComponent)this).GetChild("ArmyGroupName");
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		Iconloader = (GLoader)((GComponent)this).GetChild("Iconloader");
		Frameloader = (GLoader)((GComponent)this).GetChild("Frameloader");
		n6 = (GGroup)((GComponent)this).GetChild("n6");
		OurMedalList = (GList)((GComponent)this).GetChild("OurMedalList");
	}
}
