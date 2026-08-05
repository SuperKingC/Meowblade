using System;
using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlEvent;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Helpers;
using UI.GvGAmpIntroduction;
using UI.Tips;

namespace Shift.Legion.Common.Models;

public class ItemTipViewer
{
	private readonly string _itemId;

	private readonly bool _hideCheckBtn;

	private const string ABILITY_ID = "AbilityId";

	public ItemTipViewer(string itemId, bool hideCheckBtn = true)
	{
		CheckItemId(itemId);
		_itemId = itemId;
		_hideCheckBtn = hideCheckBtn;
	}

	private void CheckItemId(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			throw new ArgumentNullException("Item.DisplayItemTip itemId=" + itemId);
		}
	}

	public void DisplayItemTip(ItemTipParams parameters)
	{
		if (IsGvGAmp())
		{
			DisplayGvGAmp();
		}
		else if (IsGvGMultiBattleBuff())
		{
			DisplayBrawlBuff(parameters);
		}
		else
		{
			DisplayCommonItem();
		}
	}

	private bool IsGvGAmp()
	{
		return _itemId.Contains("GvGAmp");
	}

	private void DisplayGvGAmp()
	{
		AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetAmplifier(_itemId);
		AmplifierModel amplifierModel2 = AmpConfigHelper.Configs.TryGetNormalAmplifier(amplifierModel.Idx);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_mian_GvGAmpIntroductionPopup.Name, new Dictionary<string, object> { { "AmpIdx", amplifierModel2.Idx } });
	}

	private bool IsGvGMultiBattleBuff()
	{
		return Item.ItemType(_itemId) == 51;
	}

	private void DisplayBrawlBuff(ItemTipParams parameters)
	{
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		GDEItemData gDEItemData = GDMgr.TryGetWithErrorHandling<GDEItemData>(_itemId);
		BrawlBuffEffectData brawlBuffEffectData = JsonHelper.ToObject<BrawlBuffEffectData>(gDEItemData.Effect);
		bool isGroup = gDEItemData.GetMultiBattleBuffType() == eMultiBattleBuffType.AbilityOnCampBonus;
		UI_SkillDetailPopup.BrawlFightBuff brawlFightBuff = new UI_SkillDetailPopup.BrawlFightBuff
		{
			SkillName = gDEItemData.Name,
			ItemId = _itemId,
			Limit = brawlBuffEffectData.Limit,
			IsGroup = isGroup,
			Count = parameters.ItemCount
		};
		switch (brawlBuffEffectData.GetEffectType())
		{
		case BrawlBuffEffectData.EffectType.Ability:
		{
			string abilityId = brawlBuffEffectData.Effect.AbilityId;
			if (string.IsNullOrWhiteSpace(abilityId))
			{
				return;
			}
			GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(abilityId.ToString());
			string description = Singleton<AbilityDataManager>.Instance.GetDescription(gDEAbilityData.Key);
			Dictionary<string, float> parameters2 = new Dictionary<string, float> { { "Level", parameters.ItemCount } };
			description = UI_SkillDetailPopup.ParseDescriptionStatic(description, parameters2);
			brawlFightBuff.Desc = description;
			break;
		}
		case BrawlBuffEffectData.EffectType.Score:
		{
			float num = brawlBuffEffectData.Effect.ExtraScore * (float)parameters.ItemCount * 100f;
			string desc = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(("BrawlFightBuff_" + gDEItemData.Key).ToLanguage(), $"{num:N0}");
			brawlFightBuff.Desc = desc;
			break;
		}
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, new Dictionary<string, object>
		{
			{ "Pos", parameters.SkillPopupPos },
			{ "BrawlFightBuff", brawlFightBuff }
		});
	}

	private void DisplayCommonItem()
	{
		FGUIManager.Instance.ItemTip(_itemId, 1, _hideCheckBtn);
	}
}
