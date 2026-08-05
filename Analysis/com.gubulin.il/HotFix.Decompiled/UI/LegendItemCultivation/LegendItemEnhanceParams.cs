using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Scripts.Helper;

namespace UI.LegendItemCultivation;

public class LegendItemEnhanceParams
{
	private readonly EnhanceFoodsMode _enhanceFoodsMode;

	public Dictionary<int, LegendItemUi> RareFoods { get; }

	public List<long> FoodIds { get; }

	public List<LegendItemUi> Foods { get; }

	public LegendItemEnhanceParams(Dictionary<int, LegendItemUi> rareFoods, List<LegendItemUi> foods)
	{
		RareFoods = rareFoods;
		Foods = foods;
		FoodIds = GetFoodIds(foods);
		_enhanceFoodsMode = GetEnhanceFoodsMode(rareFoods);
	}

	public string GetEnhanceTip()
	{
		return (_enhanceFoodsMode != EnhanceFoodsMode.None) ? ("CsharpCodeZhTcText326".ToLanguage() + _enhanceFoodsMode.ToString().ToLanguage() + LanguagesManager.Comma + "CsharpCodeZhTcText328".ToLanguage() + "？") : string.Empty;
	}

	private EnhanceFoodsMode GetEnhanceFoodsMode(Dictionary<int, LegendItemUi> rareFoods)
	{
		int num = rareFoods.Values.Sum((LegendItemUi legendItem) => (legendItem.LegendItemData.Data.Rarity == 5) ? 1 : 0);
		int num2 = rareFoods.Values.Sum((LegendItemUi legendItem) => (legendItem.LegendItemData.Data.Rarity == 6) ? 1 : 0);
		if (num > 0 && num2 > 0)
		{
			return EnhanceFoodsMode.EnhanceFoodsContainsRarity5And6;
		}
		if (num2 > 0)
		{
			return EnhanceFoodsMode.EnhanceFoodsContainsRarity6;
		}
		if (num > 0)
		{
			return EnhanceFoodsMode.EnhanceFoodsContainsRarity5;
		}
		return EnhanceFoodsMode.None;
	}

	private List<long> GetFoodIds(List<LegendItemUi> foods)
	{
		List<long> list = new List<long>();
		foreach (LegendItemUi food in foods)
		{
			list.Add(food.InstanceId);
		}
		return list;
	}
}
