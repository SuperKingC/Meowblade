using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_DailyMissionBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField n4;

	public GImage RedDot;

	public const string URL = "ui://k2sprg26ke8pag";

	public static string Name = "UI_DailyMissionBtn";

	public static string GetURL()
	{
		return "ui://k2sprg26ke8pag";
	}

	public static UI_DailyMissionBtn CreateInstance()
	{
		return (UI_DailyMissionBtn)(object)UIPackage.CreateObject("IslandComeAgain", "DailyMissionBtn");
	}

	public static UI_DailyMissionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DailyMissionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26ke8pag", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://k2sprg26ke8pag".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
	}
}
