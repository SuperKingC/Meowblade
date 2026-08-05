using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.Common.Services;

namespace UI.GvG3MainStorylineQuest;

public class UI_main_MainMissionCampBonus : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_CampProgressBonus PopUp;

	public const string URL = "ui://249h3k3dvihg27";

	public static string Name = "UI_main_MainMissionCampBonus";

	public static string GetURL()
	{
		return "ui://249h3k3dvihg27";
	}

	public static UI_main_MainMissionCampBonus CreateInstance()
	{
		return (UI_main_MainMissionCampBonus)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "main_MainMissionCampBonus");
	}

	public static UI_main_MainMissionCampBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_MainMissionCampBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dvihg27", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_CampProgressBonus)(object)((GComponent)this).GetChild("PopUp");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		object value;
		int progress = (parameters.TryGetValue("CampProgress", out value) ? ((int)value) : 0);
		Render(progress);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Render(int progress)
	{
		string key = progress.ToString();
		if (!GvG3FlagShipMissionsConfigHelper.MainMissionBonusByRank.TryGetValue(key, out var value))
		{
			return;
		}
		PopUp.Progress.selectedIndex = progress - 1;
		foreach (KeyValuePair<string, Dictionary<string, int>> item2 in value)
		{
			GObject val = PopUp.RewardsConfig.AddItemFromPool();
			if (val is UI_com_CampBonus uI_com_CampBonus)
			{
				uI_com_CampBonus.RankPage.selectedIndex = int.Parse(item2.Key) - 1;
				RankingBonusRenderer(item2.Value, uI_com_CampBonus);
			}
		}
		void RankingBonusRenderer(Dictionary<string, int> bonus, UI_com_CampBonus campBonusUi)
		{
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			foreach (KeyValuePair<string, int> item in bonus)
			{
				GObject val2 = campBonusUi.Bonus.AddItemFromPool();
				if (val2 is UI_com_Bonus uI_com_Bonus)
				{
					((GObject)uI_com_Bonus.Count).text = item.Value.ToString();
					FGUIManager.Instance.SetItemIconAndFrame(uI_com_Bonus.ItemIcon, item.Key);
					((GObject)uI_com_Bonus).onClick.Set((EventCallback0)delegate
					{
						FGUIManager.Instance.ItemTip(item.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
					});
				}
			}
		}
	}
}
