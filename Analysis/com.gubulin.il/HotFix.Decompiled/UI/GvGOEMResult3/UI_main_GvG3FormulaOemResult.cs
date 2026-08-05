using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGOEMResult3;

public class UI_main_GvG3FormulaOemResult : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_FormulaResult PopUp;

	public Transition t0;

	public const string URL = "ui://5k1s1pjxt0zv5v";

	public static string Name = "UI_main_GvG3FormulaOemResult";

	public const string RecordParam = "Record";

	private bool _isClickClaim;

	private int _muid;

	public static string GetURL()
	{
		return "ui://5k1s1pjxt0zv5v";
	}

	public static UI_main_GvG3FormulaOemResult CreateInstance()
	{
		return (UI_main_GvG3FormulaOemResult)(object)UIPackage.CreateObject("GvGOEMResult3", "main_GvG3FormulaOemResult");
	}

	public static UI_main_GvG3FormulaOemResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3FormulaOemResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5k1s1pjxt0zv5v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_FormulaResult)(object)((GComponent)this).GetChild("PopUp");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)PopUp.Confirm).onClick.Set(new EventCallback0(OnClickConfirm));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)PopUp.Confirm).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		C2S_GetSelfFormulaOEMMissions.Response response = (C2S_GetSelfFormulaOEMMissions.Response)parameters["Record"];
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ClaimCoroutine(response.Records));
	}

	private IEnumerator ClaimCoroutine(List<FormulaOEMMissionsSelfRecord> list)
	{
		WaitForSeconds wait = new WaitForSeconds(0.1f);
		FormulaOEMMissionsSelfRecord[] array = list.ToArray();
		FormulaOEMMissionsSelfRecord[] array2 = array;
		foreach (FormulaOEMMissionsSelfRecord detail in array2)
		{
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			if (detail.UiState != 0 || detail.UnclaimedCount > 0)
			{
				_isClickClaim = false;
				RefreshWithData(detail);
				while (!_isClickClaim)
				{
					yield return wait;
				}
			}
		}
		End();
	}

	private void RefreshWithData(FormulaOEMMissionsSelfRecord detail)
	{
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		_muid = detail.MUID;
		UI_com_FormulaOem uI_com_FormulaOem = (UI_com_FormulaOem)(object)PopUp.formulaIcon;
		uI_com_FormulaOem.Render(detail.AmpIdx);
		OemMissionAmplifier ampModel = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(detail.AmpIdx);
		string reelItemId = ampModel.AmplifierFormulaModel.ReelItemId;
		((GObject)PopUp.formulaName).text = Item.Name(GameManagers.Instance, reelItemId);
		int num = detail.TotalCount - detail.FinishCount;
		((GObject)PopUp.remainUseTimes).text = $"{num}/{detail.TotalCount}";
		((GObject)PopUp.hasReturn).visible = num > 0 && detail.UiState != 0;
		List<FormulaOEMBonus> detailBonus = new List<FormulaOEMBonus>();
		int num2 = 0;
		if (detail.Bonus != null)
		{
			foreach (FormulaOEMBonus bonu in detail.Bonus)
			{
				if (!bonu.IsClaimed)
				{
					detailBonus.Add(bonu);
				}
			}
		}
		foreach (FormulaOEMBonus item in detailBonus)
		{
			num2 += item.Bonus.GetBonusContributionPoint(detail.AmpIdx);
		}
		PopUp.TotalIcon.url = "ui://PublicResources/I65001";
		((GObject)PopUp.TotalCount).text = num2.ToString();
		PopUp.resultDetail.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Expected O, but got Unknown
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Expected O, but got Unknown
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Expected O, but got Unknown
			UI_com_FormulaResultItem child = (UI_com_FormulaResultItem)(object)item;
			FormulaOEMBonus bonus = detailBonus[index];
			child.ProfileDisplay.RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayLeft>
			{
				CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
				UserId = bonus.UserId,
				CampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId,
				OnProfileLoaded = delegate(UI_com_ProfileDisplayLeft displayUi)
				{
					displayUi.Style.SetSelectedIndex((((GComponent)displayUi.Medals).numChildren <= 0) ? 1 : 0);
				}
			}, bonus.UserId);
			string desc = LanguagesManager.GetDesc("GvG3FormulaOemResult");
			((GObject)child.completeTime).text = string.Format(desc, UiHelper.ParseFullTime(bonus.FinishTimestamp));
			bool hasDebuff = bonus.IsDebuffed();
			child.hasDebuff.SetSelectedIndex(hasDebuff ? 1 : 0);
			int quality = ampModel.AmplifierModel.Quality;
			int debuffValue = bonus.GetOEMBonuseDebuffRate();
			string levelName = AmplifierModel.GetQualityName(quality);
			((GObject)child.debuffBtn).onClick.Set((EventCallback0)delegate
			{
				//IL_002e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0034: Unknown result type (might be due to invalid IL or missing references)
				FairyGUITip.ShowTip((GObject)(object)child.debuffBtn, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
				{
					((GObject)popup.title).text = "FormulaOemResultDebuffTip".ToLanguage().Format(bonus.TotalFinishCount, levelName, debuffValue);
				});
			});
			List<ForgedExtraAmplifier> materialResult = bonus.Bonus.OEMResult_Material.AmpsList;
			child.amplifiers.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				UI_com_Amplifier uI_com_Amplifier = (UI_com_Amplifier)(object)o;
				ForgedExtraAmplifier forgedExtraAmplifier = materialResult[i];
				RenderHelper_AmplifierIcon.RenderAmplifier(uI_com_Amplifier.AmplifierIcon, forgedExtraAmplifier.Idx);
				RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(uI_com_Amplifier.AffectedRange, forgedExtraAmplifier.Idx);
				uI_com_Amplifier.IsCriticalStrike.selectedIndex = (forgedExtraAmplifier.IsCritical ? 1 : 0);
			};
			child.amplifiers.numItems = materialResult.Count;
			OEMResult oEMResult_Formula2 = bonus.Bonus.OEMResult_Formula;
			RenderExtraBonus(child.extraRewards, oEMResult_Formula2.AmpsList, oEMResult_Formula2.ItemsList);
			List<OEMTakerBonusItem> contribution = bonus.Bonus.BonusItems(detail.AmpIdx);
			int index2 = contribution.FindIndex((OEMTakerBonusItem cItem) => cItem.Type == eOEMTakeBonusType.Extra);
			contribution.RemoveAt(index2);
			child.Bonus.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				if (o is UI_com_FormulaBonusDes uI_com_FormulaBonusDes)
				{
					OEMTakerBonusItem oEMTakerBonusItem = contribution[i];
					int num3 = oEMTakerBonusItem.Item.cnt;
					if (hasDebuff && !oEMTakerBonusItem.Obtained)
					{
						num3 = bonus.GetOEMBonuseDebuffRateFloat(num3);
					}
					((GObject)uI_com_FormulaBonusDes.Count).text = $"{num3}";
					uI_com_FormulaBonusDes.Type.selectedIndex = (int)oEMTakerBonusItem.Type;
					uI_com_FormulaBonusDes.Get.selectedIndex = (oEMTakerBonusItem.Obtained ? 1 : 0);
					uI_com_FormulaBonusDes.hasDebuff.SetSelectedIndex(hasDebuff ? 1 : 0);
				}
			};
			child.Bonus.numItems = contribution.Count;
		};
		PopUp.resultDetail.numItems = detailBonus.Count;
		List<ForgedExtraAmplifier> list = new List<ForgedExtraAmplifier>();
		List<ForgedExtraItem> list2 = new List<ForgedExtraItem>();
		foreach (FormulaOEMBonus item2 in detailBonus)
		{
			OEMResult oEMResult_Formula = item2.Bonus.OEMResult_Formula;
			list2.AddRange(oEMResult_Formula.ItemsList);
			list.AddRange(oEMResult_Formula.AmpsList);
		}
		MergeSameReward(list);
		MergeSameReward(list2);
		bool flag = list2.Count > 0;
		PopUp.HasExtraBonus.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			RenderExtraBonus(PopUp.extraReward, list, list2);
		}
		else
		{
			PopUp.extraReward.numItems = 0;
		}
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

	private void OnClickConfirm()
	{
		CloseFormula(_muid, delegate
		{
			_isClickClaim = true;
		});
	}

	private static void CloseFormula(int muid, Action onComplete)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ClaimSelfFormulaOEMMissions
		{
			Req = new C2S_ClaimSelfFormulaOEMMissions.Request
			{
				MUID = muid
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ClaimSelfFormulaOEMMissions.Response response = (C2S_ClaimSelfFormulaOEMMissions.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				End();
			}
			else
			{
				onComplete?.Invoke();
			}
		});
	}

	public static void RenderExtraBonus(GList list, List<ForgedExtraAmplifier> ampsList, List<ForgedExtraItem> itemsList)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		list.itemProvider = new ListItemProvider(GetListItemResource);
		list.itemRenderer = new ListItemRenderer(OtherItemRenderer);
		int numItems = ampsList.Count + itemsList.Count;
		list.numItems = numItems;
		string GetListItemResource(int index)
		{
			return (index < ampsList.Count) ? "ui://5k1s1pjxpzxd3" : "ui://kt6rg65oj1h8v4sm";
		}
		void OtherItemRenderer(int index, GObject obj)
		{
			if (index < ampsList.Count)
			{
				ForgedExtraAmplifier amplifier = ampsList[index];
				AmpRenderer(amplifier, obj);
			}
			else
			{
				ForgedExtraItem bonus = itemsList[index - ampsList.Count];
				RItemRenderer(bonus, obj);
			}
		}
	}

	private static void AmpRenderer(ForgedExtraAmplifier amplifier, GObject ampObj)
	{
		if (ampObj is UI_com_Amplifier uI_com_Amplifier)
		{
			RenderHelper_AmplifierIcon.RenderAmplifier(uI_com_Amplifier.AmplifierIcon, amplifier.Idx);
			RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(uI_com_Amplifier.AffectedRange, amplifier.Idx);
			uI_com_Amplifier.IsCriticalStrike.selectedIndex = (amplifier.IsCritical ? 1 : 0);
			if (amplifier.IsCritical)
			{
				uI_com_Amplifier.Quatity.selectedIndex = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(amplifier.Idx).AmplifierModel.Quality - 1;
			}
			uI_com_Amplifier.TalentSrc.selectedIndex = 1;
			uI_com_Amplifier.TalentSrcIcon.url = "GvGTalent_36".ToPublicResourcesRgbIcon();
			uI_com_Amplifier.Count.selectedIndex = 1;
			((GObject)uI_com_Amplifier.AmpCount).text = amplifier.Count.ToString();
		}
	}

	private static void RItemRenderer(ForgedExtraItem bonus, GObject itemObj)
	{
		if (itemObj is UI_com_FormulaOem uI_com_FormulaOem)
		{
			uI_com_FormulaOem.RenderWithItemId(bonus.ItemId, bonus.Count);
		}
	}

	public static void MergeSameReward(List<ForgedExtraAmplifier> list)
	{
		for (int num = list.Count - 1; num >= 0; num--)
		{
			ForgedExtraAmplifier forgedExtraAmplifier = list[num];
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				ForgedExtraAmplifier forgedExtraAmplifier2 = list[num2];
				if (forgedExtraAmplifier2.Idx == forgedExtraAmplifier.Idx)
				{
					forgedExtraAmplifier2.Count += forgedExtraAmplifier.Count;
					list.RemoveAt(num);
					break;
				}
			}
		}
	}

	public static void MergeSameReward(List<ForgedExtraItem> list)
	{
		for (int num = list.Count - 1; num >= 0; num--)
		{
			ForgedExtraItem forgedExtraItem = list[num];
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				ForgedExtraItem forgedExtraItem2 = list[num2];
				if (forgedExtraItem2.ItemId == forgedExtraItem.ItemId)
				{
					forgedExtraItem2.Count += forgedExtraItem.Count;
					list.RemoveAt(num);
					break;
				}
			}
		}
	}

	private static void End()
	{
		Singleton<GvGAmplifierManager>.Instance.NeedSyncStorage = true;
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
