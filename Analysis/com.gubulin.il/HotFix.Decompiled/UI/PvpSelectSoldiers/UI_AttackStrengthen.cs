using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;

namespace UI.PvpSelectSoldiers;

public class UI_AttackStrengthen : GButton
{
	public Controller button;

	public GImage n5;

	public GTextField buffNum;

	public const string URL = "ui://82mo10n5wmk56m";

	public static string Name = "UI_AttackStrengthen";

	public static string GetURL()
	{
		return "ui://82mo10n5wmk56m";
	}

	public static UI_AttackStrengthen CreateInstance()
	{
		return (UI_AttackStrengthen)(object)UIPackage.CreateObject("PvpSelectSoldiers", "AttackStrengthen");
	}

	public static UI_AttackStrengthen CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AttackStrengthen).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5wmk56m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		buffNum = (GTextField)((GComponent)this).GetChild("buffNum");
		string id = "ui://82mo10n5wmk56m".Replace("ui://", "") + "-" + ((GObject)buffNum).id;
		((GObject)buffNum).text = LanguagesManager.GetDesc(id);
	}

	public void UpdateBuffNum()
	{
		if (!((GObject)this).isDisposed)
		{
			((GObject)buffNum).text = $"{RankDataHelper.PvpRankProgress.AttackBuffCnt}/{RankDataHelper.PvPMaxAttackBuff}";
		}
	}
}
