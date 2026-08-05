using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;

namespace UI.PvpSelectSoldiers;

public class UI_DefenseTime : GButton
{
	public Controller button;

	public GImage n5;

	public GTextField buffTime;

	public const string URL = "ui://82mo10n5wmk56k";

	public static string Name = "UI_DefenseTime";

	public static string GetURL()
	{
		return "ui://82mo10n5wmk56k";
	}

	public static UI_DefenseTime CreateInstance()
	{
		return (UI_DefenseTime)(object)UIPackage.CreateObject("PvpSelectSoldiers", "DefenseTime");
	}

	public static UI_DefenseTime CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DefenseTime).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5wmk56k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		buffTime = (GTextField)((GComponent)this).GetChild("buffTime");
		string id = "ui://82mo10n5wmk56k".Replace("ui://", "") + "-" + ((GObject)buffTime).id;
		((GObject)buffTime).text = LanguagesManager.GetDesc(id);
	}

	public void UpdateText()
	{
		int num = RankDataHelper.PvpRankProgress.DefenseBuffExpiredAt - (int)GameController.Instance.GetServerTime();
		if (num <= 0)
		{
			num = 0;
		}
		((GObject)buffTime).text = UiHelper.ParseTime(num) ?? "";
	}
}
