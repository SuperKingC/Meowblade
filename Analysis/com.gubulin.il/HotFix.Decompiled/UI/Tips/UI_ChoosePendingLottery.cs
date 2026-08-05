using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UnityEngine;

namespace UI.Tips;

public class UI_ChoosePendingLottery : GComponent, IUiController
{
	public GGraph TitleBg;

	public GRichTextField TitleText;

	public GGroup TitleGroup;

	public GList ChoiceList;

	public GButton ConfirmButton;

	public const string URL = "ui://47lbpgx9hvjt3j";

	public static string Name = "UI_ChoosePendingLottery";

	private Shift.Legion.Common.Models.LotteryPendingResult lastestPendingLotteryResult;

	private readonly List<string> textureList = new List<string>();

	private List<int> chosenIndex = new List<int>();

	public static string GetURL()
	{
		return "ui://47lbpgx9hvjt3j";
	}

	public static UI_ChoosePendingLottery CreateInstance()
	{
		return (UI_ChoosePendingLottery)(object)UIPackage.CreateObject("Tips", "ChoosePendingLottery");
	}

	public static UI_ChoosePendingLottery CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChoosePendingLottery).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9hvjt3j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TitleBg = (GGraph)((GComponent)this).GetChild("TitleBg");
		TitleText = (GRichTextField)((GComponent)this).GetChild("TitleText");
		string id = "ui://47lbpgx9hvjt3j".Replace("ui://", "") + "-" + ((GObject)TitleText).id;
		((GObject)TitleText).text = LanguagesManager.GetDesc(id);
		TitleGroup = (GGroup)((GComponent)this).GetChild("TitleGroup");
		ChoiceList = (GList)((GComponent)this).GetChild("ChoiceList");
		ConfirmButton = (GButton)((GComponent)this).GetChild("ConfirmButton");
	}

	public void RegisterUiEventListeners()
	{
	}

	public void UnregisterUiEventListeners()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 100;
		((GObject)ConfirmButton).alpha = 0f;
		((GObject)ConfirmButton).touchable = false;
		((GObject)ConfirmButton).onClick.Set(new EventCallback0(ConfirmLottery));
		ShowPendingLottery();
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void ShowPendingLottery()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		List<Shift.Legion.Common.Models.LotteryPendingResult> value = GameManagers.Instance.LotteryManager.PendingLotteryResult.GetValue();
		if (value.Count < 1)
		{
			End();
			return;
		}
		lastestPendingLotteryResult = value.Last();
		ChoiceList.itemRenderer = new ListItemRenderer(RenderLotteryItem);
		ChoiceList.numItems = lastestPendingLotteryResult.BonusList.Count;
	}

	private void RenderLotteryItem(int index, GObject listItem)
	{
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f2: Expected O, but got Unknown
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0652: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_0679: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Expected O, but got Unknown
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		GButton button = listItem.asButton;
		GLoader asLoader = ((GComponent)button).GetChild("icon").asLoader;
		GRichTextField asRichTextField = ((GComponent)button).GetChild("introduction").asRichTextField;
		GTextField asTextField = ((GComponent)button).GetChild("stockNum").asTextField;
		((GObject)button).name = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText250"), index);
		BonusConfig bonusConfig = lastestPendingLotteryResult.BonusList[index];
		Bonus bonus = Bonus.Get(bonusConfig.ItemId, bonusConfig.Qty, bonusConfig.Type, bonusConfig.IsShining);
		string itemId = bonusConfig.ItemId;
		asLoader.fill = (FillType)1;
		asLoader.verticalAlign = (VertAlignType)0;
		if (bonus.IsShining == 2 || bonus.Category == 2)
		{
			((GObject)((GComponent)button).GetChild("commonGroup").asGroup).visible = false;
			((GObject)((GComponent)button).GetChild("rareGroup").asGroup).visible = true;
			((GObject)((GComponent)button).GetChild("sliverGroup").asGroup).visible = false;
			((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)button).GetChild("fxBack").asGraph, "activated_fx", new Vector3(125f, 125f, 125f));
		}
		else if (bonus.IsShining == 1)
		{
			((GObject)((GComponent)button).GetChild("commonGroup").asGroup).visible = false;
			((GObject)((GComponent)button).GetChild("rareGroup").asGroup).visible = false;
			((GObject)((GComponent)button).GetChild("sliverGroup").asGroup).visible = true;
		}
		else
		{
			((GObject)((GComponent)button).GetChild("commonGroup").asGroup).visible = true;
			((GObject)((GComponent)button).GetChild("rareGroup").asGroup).visible = false;
			((GObject)((GComponent)button).GetChild("sliverGroup").asGroup).visible = false;
		}
		switch (Shift.Legion.Common.Models.Item.ItemType(itemId))
		{
		case 8:
			asLoader.url = "ui://kt6rg65os0m4tbx";
			if (asLoader.component != null)
			{
				GButton asButton2 = ((GObject)asLoader.component).asButton;
				GObject child = ((GComponent)asButton2).GetChild("icon");
				string iconPath = UiHelper.GetIconPath(itemId);
				child.asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath;
				string text = "kuang_square_lv1";
				((GComponent)asButton2).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + text;
				((GComponent)asButton2).GetChild("num").text = "";
				((GComponent)asButton2).GetChild("numNote").visible = false;
				((GComponent)asButton2).GetChild("title").text = "";
				((GComponent)asButton2).GetChild("title_Max").text = "";
			}
			((GComponent)button).GetChild("numNote").asLoader.url = "ui://kt6rg65ovv0ue9";
			break;
		case 3:
			asLoader.url = "ui://kt6rg65obunlt85";
			if (asLoader.component != null)
			{
				GButton asButton = ((GObject)asLoader.component).asButton;
				FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton, itemId, textureList);
			}
			((GComponent)button).GetChild("numNote").asLoader.url = "";
			break;
		case 10:
		{
			((GObject)((GComponent)button).GetChild("content").asGroup).visible = false;
			((GObject)((GComponent)button).GetChild("soldierGroup").asGroup).visible = true;
			((GComponent)button).GetChild("curLevel").visible = true;
			Soldier soldier = GameManagers.Instance.SoldierManager.Get("S" + bonus.ItemId.Substring(3));
			((GComponent)button).GetChild("soldierName").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
			((GComponent)button).GetChild("soldierName").text = soldier.Name ?? "";
			Object obj = Object.Instantiate(Resources.Load("SpineTest"));
			GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
			SkeletonAnimation animation = val.GetComponent<SkeletonAnimation>();
			SpawnManager.Instance.LoadAnimation(soldier.Id).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				if (!((GObject)this).isDisposed)
				{
					((SkeletonRenderer)animation).skeletonDataAsset = asset;
					((SkeletonRenderer)animation).Initialize(true);
					int num3 = (soldier.PotentialLevel + 2) / 2;
					SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, $"skin{num3}");
					animation.AnimationState.AddAnimation(1, "idle", true, 0f);
				}
			});
			if (soldier.Id == "S001" || soldier.Id == "S002" || soldier.Id == "S003" || soldier.Id == "S004" || soldier.Id == "S035" || soldier.Id == "S038")
			{
				val.transform.localScale = new Vector3(55f, 55f, 55f);
			}
			else
			{
				val.transform.localScale = new Vector3(40f, 40f, 40f);
			}
			val.transform.localPosition = -new Vector3(0f, 0f, 0f);
			val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val2 = new GoWrapper(val);
			((DisplayObject)val2).SetXY(0f, 0f);
			((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
			((GComponent)button).GetChild("soldier").asGraph.SetNativeObject((DisplayObject)(object)val2);
			float num2 = 176f;
			if (soldier.Id == "S003")
			{
				num2 = 196f;
			}
			((GObject)((GComponent)button).GetChild("soldier").asGraph).SetXY(num2, 412f);
			((GComponent)button).GetChild("num").visible = false;
			break;
		}
		default:
			asLoader.url = "ui://kt6rg65ot1tzf9";
			if (asLoader.component != null)
			{
				GComponent component = asLoader.component;
				string itemId2 = bonus.ItemId;
				int num = ((Shift.Legion.Common.Models.Item.ItemType(itemId2) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId2) : Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemId2));
				num = ((num > 0) ? num : Shift.Legion.Common.Models.Item.Rarity(itemId2));
				component.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(bonus.ItemId);
				component.GetChild("frame").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, num);
			}
			((GComponent)button).GetChild("numNote").asLoader.url = "";
			break;
		}
		((GObject)((GComponent)button).GetChild("num").asTextField).text = $"{bonus.Qty}";
		button.title = SchemaIndexHelper.GetNameById(GameManagers.Instance, bonus.ItemId);
		((GObject)asRichTextField).text = bonus.Desc(GameManagers.Instance);
		((GObject)asTextField).text = FGUIManager.Instance.GetStockString(itemId);
		((GObject)button).onClick.Set((EventCallback0)delegate
		{
			OnChoiceListItemClick(button, index);
		});
	}

	private void OnChoiceListItemClick(GButton button, int index)
	{
		chosenIndex.Clear();
		chosenIndex.Add(index);
		((GObject)ConfirmButton).alpha = 1f;
		((GObject)ConfirmButton).touchable = true;
	}

	private void ConfirmLottery()
	{
		((GObject)ConfirmButton).alpha = 0f;
		((GObject)ConfirmButton).touchable = false;
		((GObject)ChoiceList).touchable = false;
		((GObject)TitleText).text = LanguagesManager.GetDesc("CsharpCodeZhTcText848");
		UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
		ILRequestHelper<PendingLotteryResultClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().ClaimPendingLottery(chosenIndex), delegate(PendingLotteryResultClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.BonusList != null && response.BonusList.Count > 0)
				{
					foreach (ModelsBonus bonus2 in response.BonusList)
					{
						Bonus bonus = Bonus.Get(bonus2.ItemId, bonus2.Qty, bonus2.Type, bonus2.IsShining);
						bonus.Claim(GameManagers.Instance);
					}
				}
				List<Shift.Legion.Common.Models.LotteryPendingResult> list = new List<Shift.Legion.Common.Models.LotteryPendingResult>();
				if (response.PendingLotteryResultList != null)
				{
					foreach (Shift.Legion.ClientApi.Models.LotteryPendingResult pendingLotteryResult in response.PendingLotteryResultList)
					{
						Shift.Legion.Common.Models.LotteryPendingResult lotteryPendingResult = new Shift.Legion.Common.Models.LotteryPendingResult
						{
							From = pendingLotteryResult.From,
							CreatedAt = pendingLotteryResult.CreatedAt,
							TotalPick = pendingLotteryResult.TotalPick,
							BonusList = new List<BonusConfig>()
						};
						foreach (ModelsBonus bonus3 in pendingLotteryResult.BonusList)
						{
							lotteryPendingResult.BonusList.Add(new BonusConfig
							{
								ItemId = bonus3.ItemId,
								Qty = bonus3.Qty,
								Type = bonus3.Type,
								IsShining = bonus3.IsShining
							});
						}
						list.Add(lotteryPendingResult);
					}
				}
				GameManagers.Instance.LotteryManager.PendingLotteryResult.SetValue(list);
				End();
			}
		}, 1f);
	}
}
