using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion.Common.Models.LegendItem;
using UI.PublicResources;
using UI.SoldierCultivate;
using UnityEngine;

namespace UI.LegendItemCultivation;

public class LegendItemEnhancer
{
	private readonly UI_LegendItemCultivationPanel _cultivationPanel;

	private readonly List<tKeyValue<int, int>> _foodListItemsPos = new List<tKeyValue<int, int>>
	{
		new tKeyValue<int, int>(1180, 454),
		new tKeyValue<int, int>(1300, 454),
		new tKeyValue<int, int>(1420, 454),
		new tKeyValue<int, int>(1540, 454),
		new tKeyValue<int, int>(1180, 559),
		new tKeyValue<int, int>(1300, 559),
		new tKeyValue<int, int>(1420, 559),
		new tKeyValue<int, int>(1540, 559)
	};

	public LegendItemEnhancer(UI_LegendItemCultivationPanel cultivationPanel)
	{
		_cultivationPanel = cultivationPanel;
	}

	public void EnhanceLegendItem()
	{
		LegendItemEnhanceParams enhanceParams = CreateEnhanceParams();
		string enhanceTip = enhanceParams.GetEnhanceTip();
		if (string.IsNullOrEmpty(enhanceTip))
		{
			ExecuteEnhanceOperation();
		}
		else
		{
			enhanceTip.ToConfirmPopup(ExecuteEnhanceOperation, CancelEnhanceOperation, (AlignType)0);
		}
		void CancelEnhanceOperation()
		{
			foreach (int key in enhanceParams.RareFoods.Keys)
			{
				GComponent val = CreateReminder(key);
				LegendItem legendItemData = enhanceParams.RareFoods[key].LegendItemData;
				RenderLegendItemUi(legendItemData, val);
				SizeChange(val);
				SetSizeChangeCallback(val);
			}
		}
		void ExecuteEnhanceOperation()
		{
			LegendItemsHelper.LegendItemEnhance(UI_LegendItemCultivationPanel.CurLegendItemData, enhanceParams.Foods, enhanceParams.FoodIds, InvokeEnhanceCallback, InvokeEnhanceErrorCode);
		}
		void InvokeEnhanceCallback()
		{
			_cultivationPanel.UpdateIntensifyAfterLegendItemEnhance(enhanceParams.Foods);
			UI_SoldierCultivate.SoldierCultivatePanel?.LegendItemButtonsInit();
			UI_SoldierCultivate.legendItemsChanged = true;
		}
		void InvokeEnhanceErrorCode(int errorCode)
		{
			if (errorCode != 22001011)
			{
				ILRequestHelper.ShowErrorCode(errorCode);
			}
			else
			{
				List<long> foodIds = enhanceParams.FoodIds;
				long instanceId = 0L;
				foreach (long item in foodIds)
				{
					if (LegendItemsHelper.LegendItemsEquiped(item))
					{
						instanceId = item;
						break;
					}
				}
				string legendItemName = LegendItemsHelper.GetLegendItemUi(instanceId)?.LegendItemData?.Data?.Name;
				LegendItemsHelper.TopTournamentLegendItemReminder.RemindGoToUnEquip(legendItemName);
			}
		}
	}

	private LegendItemEnhanceParams CreateEnhanceParams()
	{
		Dictionary<int, LegendItemUi> dictionary = new Dictionary<int, LegendItemUi>();
		List<LegendItemUi> list = new List<LegendItemUi>();
		for (int i = 0; i < _cultivationPanel.Intensify.SelectList.numItems; i++)
		{
			if (((GComponent)_cultivationPanel.Intensify.SelectList).GetChildAt(i)?.data is LegendItemUi legendItemUi)
			{
				if (legendItemUi.LegendItemData.Data.Rarity >= 5)
				{
					dictionary.Add(i, legendItemUi);
				}
				list.Add(legendItemUi);
			}
		}
		return new LegendItemEnhanceParams(dictionary, list);
	}

	private GComponent CreateReminder(int index)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		GComponent asCom = UIPackage.CreateObject("LegendItemCultivation", "SpecialLegendItemC").asCom;
		((GComponent)_cultivationPanel.Intensify).AddChild((GObject)(object)asCom);
		((GObject)asCom).scale = ((GObject)asCom).scale * 0.75f;
		((GObject)asCom).xy = new Vector2((float)_foodListItemsPos[index].Key, (float)_foodListItemsPos[index].Value);
		return asCom;
	}

	private void RenderLegendItemUi(LegendItem legendItem, GComponent reminderComponent)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		UI_LegendItem uI_LegendItem = (UI_LegendItem)(object)reminderComponent.GetChild("Content");
		uI_LegendItem.Icon.LoadArmsIcon(legendItem.Data.Icon);
		uI_LegendItem.FrameIcon.url = $"ui://PublicResources/frame_treasure_square_{legendItem.Data.Rarity}";
		uI_LegendItem.LvFrame.url = $"ui://PublicResources/board_corner_treasureframe_{legendItem.Data.Rarity}";
		((GTextField)uI_LegendItem.Level).strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)204));
		((GObject)uI_LegendItem.Level).text = $"{legendItem.EnhanceLevel}";
		RenderLegendItemRarity(legendItem, uI_LegendItem);
	}

	private void RenderLegendItemRarity(LegendItem legendItem, UI_LegendItem itemUi)
	{
		int rarity = legendItem.Data.Rarity;
		Controller controller = ((GComponent)itemUi).GetController("ClassController");
		if (controller != null)
		{
			controller.selectedIndex = rarity - 1;
		}
		else
		{
			ClassListRender(itemUi.ClassList, rarity);
		}
	}

	private void ClassListRender(GList classList, int rarity)
	{
		((GObject)classList).visible = true;
		for (int i = 0; i < 5; i++)
		{
			GComponent asCom = ((GComponent)classList).GetChildAt(i).asCom;
			asCom.GetChild("icon").asLoader.url = ((i > rarity - 1) ? string.Empty : "ui://PublicResources/icon_star_1");
		}
	}

	private void SizeChange(GComponent reminderComponent)
	{
		float defaultScale = ((GObject)reminderComponent).scaleX;
		EffectHelper.PlayCoroutineEffect(2f, delegate(float effectTime, float totalEffectTime)
		{
			float num = effectTime / totalEffectTime;
			float num2 = ((float)Math.Sin(num * 10f) * 0.5f + 0.5f) * 0.6f * (1f - num) + defaultScale;
			((GObject)reminderComponent).scaleX = num2;
			((GObject)reminderComponent).scaleY = num2;
		}, delegate
		{
			((GObject)reminderComponent).scaleX = defaultScale;
			((GObject)reminderComponent).scaleY = defaultScale;
		});
	}

	private void SetSizeChangeCallback(GComponent reminderComponent)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		((GComponent)(object)_cultivationPanel).SetTimeout(2f).OnComplete((GTweenCallback)delegate
		{
			((GComponent)_cultivationPanel.Intensify).RemoveChild((GObject)(object)reminderComponent, true);
		});
	}
}
