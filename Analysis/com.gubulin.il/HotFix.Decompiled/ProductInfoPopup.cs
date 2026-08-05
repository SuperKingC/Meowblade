using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using UnityEngine;
using UnityEngine.UI;

public class ProductInfoPopup : MonoBehaviour
{
	[SerializeField]
	private Text ProductName;

	[SerializeField]
	private Text ProductGradeLevel;

	[SerializeField]
	private Text ProductStock;

	[SerializeField]
	private Text ProductDescription;

	public void OpenProductInfoPopup(string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		ProductName.text = gDEItemData.Name;
		ProductGradeLevel.text = string.Format("{0}:{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText371"), GameManagers.Instance.UserArchiveManager.GetItemLevel(itemId), LanguagesManager.GetDesc("CsharpCodeZhTcText372"));
		ProductStock.text = LanguagesManager.GetDesc("CsharpCodeZhTcText373") + ":" + stock.ShortNumberFormat();
		ProductDescription.text = LanguagesManager.GetDesc("CsharpCodeZhTcText374") + ":" + gDEItemData.PostScript;
	}

	public void ClosePanel()
	{
		Object.Destroy((Object)(object)((Component)this).gameObject);
	}
}
