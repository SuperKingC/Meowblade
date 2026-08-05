using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;

namespace UI.GvGBrawlFight;

public class UI_com_BrawlSettleBonusTalentSrc : GComponent
{
	public GImage n4;

	public GTextField n44;

	public GList TalentSrcList;

	public const string URL = "ui://hozu168rbbek76";

	public static string Name = "UI_com_BrawlSettleBonusTalentSrc";

	public static string GetURL()
	{
		return "ui://hozu168rbbek76";
	}

	public static UI_com_BrawlSettleBonusTalentSrc CreateInstance()
	{
		return (UI_com_BrawlSettleBonusTalentSrc)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawlSettleBonusTalentSrc");
	}

	public static UI_com_BrawlSettleBonusTalentSrc CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlSettleBonusTalentSrc).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rbbek76", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n44 = (GTextField)((GComponent)this).GetChild("n44");
		string id = "ui://hozu168rbbek76".Replace("ui://", "") + "-" + ((GObject)n44).id;
		((GObject)n44).text = LanguagesManager.GetDesc(id);
		TalentSrcList = (GList)((GComponent)this).GetChild("TalentSrcList");
	}

	public void RenderTalents(List<int> talentSrc)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		TalentSrcList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			TalentSrcListItemRenderer(index, (UI_com_TalentSrc)(object)item, talentSrc);
		};
		TalentSrcList.numItems = talentSrc.Count;
	}

	private static void TalentSrcListItemRenderer(int index, UI_com_TalentSrc slot, List<int> talentSrc)
	{
		int idx = talentSrc[index];
		slot.Icon.url = Singleton<GvGTalentsManager>.Instance.GetTalentUrl(idx);
		((GObject)slot.TalentName).text = Singleton<GvGTalentsManager>.Instance.GetTalentName(idx);
	}
}
