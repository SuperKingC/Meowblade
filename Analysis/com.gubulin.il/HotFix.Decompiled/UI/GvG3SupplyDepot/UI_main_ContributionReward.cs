using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UI.Tips;

namespace UI.GvG3SupplyDepot;

public class UI_main_ContributionReward : GComponent, IFairyComponent
{
	public GGraph Mask;

	public UI_com_ContributionReward PopUp;

	public Transition Show;

	public const string URL = "ui://pobej4q7mo53o";

	public static string Name = "UI_main_ContributionReward";

	public static string GetURL()
	{
		return "ui://pobej4q7mo53o";
	}

	public static UI_main_ContributionReward CreateInstance()
	{
		return (UI_main_ContributionReward)(object)UIPackage.CreateObject("GvG3SupplyDepot", "main_ContributionReward");
	}

	public static UI_main_ContributionReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ContributionReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7mo53o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_ContributionReward)(object)((GComponent)this).GetChild("PopUp");
		Show = ((GComponent)this).GetTransition("Show");
	}

	public void Destroy()
	{
	}

	public void Init()
	{
		Render();
		((GObject)this).visible = true;
		Show.Play();
	}

	public void RegisterUiEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(Hide));
	}

	public void UnregisterUiEvent()
	{
		((GObject)Mask).onClick.Clear();
	}

	private void Render()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		List<ContributionBoxConfig> configs = Singleton<GvG3SupplyDepotManager>.Instance.ContributionItemInfo.ContributionBoxConfigData.Clone();
		configs.Reverse();
		PopUp.Reward.itemRenderer = new ListItemRenderer(RenderReward);
		PopUp.Reward.numItems = configs.Count;
		void RenderReward(int index, GObject obj)
		{
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			List<KeyValuePair<string, int>> bonusItems;
			if (obj is UI_com_ContributionRewardDetail uI_com_ContributionRewardDetail)
			{
				ContributionBoxConfig contributionBoxConfig = configs[index];
				bonusItems = contributionBoxConfig.Items.ToList();
				uI_com_ContributionRewardDetail.Bonus.itemRenderer = new ListItemRenderer(BonusRenderer);
				uI_com_ContributionRewardDetail.Bonus.numItems = bonusItems.Count;
				uI_com_ContributionRewardDetail.Type.selectedIndex = index;
				((GObject)uI_com_ContributionRewardDetail.ContributionScore).text = ((index == 0) ? $"{(int)contributionBoxConfig.Min}" : $"{(int)contributionBoxConfig.Min}-{(int)contributionBoxConfig.Max - 1}");
			}
			void BonusRenderer(int itemIndex, GObject itemGObject)
			{
				if (itemGObject is UI_com_ContributionBonus uI_com_ContributionBonus)
				{
					KeyValuePair<string, int> keyValuePair = bonusItems[itemIndex];
					((GObject)uI_com_ContributionBonus.Count).text = keyValuePair.Value.ToString();
					FGUIManager.Instance.SetItemIconAndFrame(uI_com_ContributionBonus.ItemIcon, keyValuePair.Key);
					uI_com_ContributionBonus.ItemIcon.InitMaterialIntroductionBtn(keyValuePair.Key);
				}
			}
		}
	}

	private void Hide()
	{
		((GObject)this).visible = false;
	}
}
