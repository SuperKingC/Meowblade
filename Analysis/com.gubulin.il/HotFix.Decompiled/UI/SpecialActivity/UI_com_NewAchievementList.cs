using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.Helpers;
using UI.LegendItemBlueprintTemplate;
using UnityEngine;

namespace UI.SpecialActivity;

public class UI_com_NewAchievementList : GComponent
{
	public class RechargeMission
	{
		public LimitedTimeTotalRechargeInfo SrcData;

		public List<BonusLine> BonusLine = new List<BonusLine>();

		public int RechargeRequirement => SrcData.RMB;

		public RechargeMission(LimitedTimeTotalRechargeInfo srcData)
		{
			SrcData = srcData;
		}
	}

	public class BonusLine
	{
		public List<RItem> Bonuses = new List<RItem>();

		public List<RItem> ChildBonuses = new List<RItem>();
	}

	public GList List;

	public const string URL = "ui://kozswd8hidx8f31";

	public static string Name = "UI_com_NewAchievementList";

	private UI_SpecialActivityPanel PatentUI;

	private List<RechargeMission> MissionData_List;

	private string ChildBonusListTitle;

	private string RechargeMissionSlotTitle;

	private HashSet<UI_com_MissionSlot> TransPlayingSlots;

	private List<UI_com_MissionSlot> WaitToRemoveSlot;

	private Coroutine WaitToUpdateCoroutine;

	private Dictionary<string, List<GGraph>> SlotsWithGlowEffect;

	private LimitedTimeTotalRechargeActivity RechargeActivity => PatentUI.RechargeActivity;

	public static string GetURL()
	{
		return "ui://kozswd8hidx8f31";
	}

	public static UI_com_NewAchievementList CreateInstance()
	{
		return (UI_com_NewAchievementList)(object)UIPackage.CreateObject("SpecialActivity", "com_NewAchievementList");
	}

	public static UI_com_NewAchievementList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NewAchievementList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hidx8f31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		List = (GList)((GComponent)this).GetChild("List");
	}

	public void Init(UI_SpecialActivityPanel parent)
	{
		PatentUI = parent;
		RechargeMissionSlotTitle = "CsharpCodeZhTcTotalRechargeCN".ToLanguage();
		ChildBonusListTitle = "RechargeChildBonusListTitle".ToLanguage();
		TransPlayingSlots = new HashSet<UI_com_MissionSlot>();
		WaitToRemoveSlot = new List<UI_com_MissionSlot>();
		SlotsWithGlowEffect = new Dictionary<string, List<GGraph>>();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GComponent)List).scrollPane.onScroll.Set((EventCallback0)delegate
		{
			HideEffect();
		});
	}

	public void UnregisterUiEventListeners()
	{
		((GComponent)List).scrollPane.onScroll.Clear();
	}

	public void Update()
	{
		if (WaitToUpdateCoroutine == null)
		{
			ConvertData();
			UpdateMissionList();
		}
	}

	public void Destroy()
	{
		PatentUI = null;
		if (WaitToUpdateCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(WaitToUpdateCoroutine);
		}
	}

	private bool CheckIsSpecialBox(string itemId)
	{
		return UI_SpecialActivityPanel.useBubbleItemID.Contains(itemId);
	}

	private void ConvertData()
	{
		MissionData_List = (from m in RechargeActivity.BonusInfos.Select(delegate(LimitedTimeTotalRechargeInfo srcData)
			{
				RechargeMission rechargeMission = new RechargeMission(srcData);
				SplitMissionBonusesIntoLines(rechargeMission);
				return rechargeMission;
			})
			orderby ArchiveExtension_DynamicActivity_LTTR.GetOneBonusState(RechargeActivity.ActivityId, m.RechargeRequirement) switch
			{
				ArchiveExtension_DynamicActivity_LTTR.BonusState.Pending => 1, 
				ArchiveExtension_DynamicActivity_LTTR.BonusState.Undergoing => 2, 
				ArchiveExtension_DynamicActivity_LTTR.BonusState.Claimed => 3, 
				_ => 999, 
			}
			select m).ToList();
	}

	private void SplitMissionBonusesIntoLines(RechargeMission mission)
	{
		bool flag = false;
		LimitedTimeTotalRechargeInfo srcData = mission.SrcData;
		List<string> list = srcData.Rewards.Keys.OrderBy((string itemId) => CheckIsSpecialBox(itemId) ? 1 : 0).ToList();
		if (list.Count == 2)
		{
			flag = CheckIsSpecialBox(list.First()) != CheckIsSpecialBox(list.Last());
		}
		foreach (string item in list)
		{
			bool flag2 = CheckIsSpecialBox(item);
			bool flag3 = mission.BonusLine.Count == 0 || (flag2 && !flag);
			BonusLine bonusLine = null;
			if (flag3)
			{
				bonusLine = new BonusLine();
				mission.BonusLine.Add(bonusLine);
			}
			else
			{
				bonusLine = mission.BonusLine.Last();
			}
			bonusLine.Bonuses.Add(new RItem
			{
				ItemId = item,
				cnt = srcData.Rewards[item]
			});
			if (flag2)
			{
				ExtractSpecialItemBoxChildBonuses(bonusLine);
			}
		}
	}

	private void ExtractSpecialItemBoxChildBonuses(BonusLine line)
	{
		string itemId = line.Bonuses.Last().ItemId;
		List<Modifier> list = Item.Effect(GameManagers.Instance, itemId);
		foreach (Modifier item in list)
		{
			if (!(item.ModifierId == "Items"))
			{
				continue;
			}
			foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
			{
				line.ChildBonuses.Add(new RItem
				{
					ItemId = item2.Key,
					cnt = Convert.ToInt32(item2.Value)
				});
			}
		}
	}

	public void OnPageActive()
	{
		TimerHelper.CallNextFrame(delegate
		{
			HideEffect(isInit: true);
		});
	}

	private void OnClaimBonus(RechargeMission mission, UI_com_MissionSlot slot)
	{
		ArchiveExtension_DynamicActivity_LTTR.ClaimedBonus(RechargeActivity.ActivityId, mission.SrcData, delegate
		{
			if (!((GObject)this).isDisposed)
			{
				PlaySlotRemoveTransition(slot);
			}
		});
	}

	private void OnClickBonus(string itemId)
	{
		if (Item.ItemType(itemId) == 27)
		{
			ArchiveExtension_Formulas.GvGStoreItemInfo value = JsonHelper.ToObject<ArchiveExtension_Formulas.GvGStoreItemInfo>(Item.PostScript(itemId));
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintTemplatePanel.Name, new Dictionary<string, object> { { "Info", value } });
		}
		else
		{
			FGUIManager.Instance.ItemTip(itemId, 2);
		}
	}

	private void UpdateMissionList()
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		foreach (UI_com_MissionSlot item in WaitToRemoveSlot)
		{
			((GComponent)List).RemoveChild((GObject)(object)item);
		}
		WaitToRemoveSlot.Clear();
		SlotsWithGlowEffect.Clear();
		List.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderMissionSlot(i, (UI_com_MissionSlot)(object)o);
		};
		List.numItems = MissionData_List.Count;
		HideEffect(isInit: true);
	}

	private void RenderMissionSlot(int i, UI_com_MissionSlot slot)
	{
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		RechargeMission data = MissionData_List[i];
		UI_com_MissionSlotContent content = slot.Content;
		float currentTotalRecharge = ArchiveExtension_DynamicActivity_LTTR.GetCurrentTotalRecharge(RechargeActivity.ActivityId);
		float num = data.RechargeRequirement;
		string text = $"{Convert.ToInt32(currentTotalRecharge)}";
		string text2 = $"{Convert.ToInt32(num)}";
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			text = $"{currentTotalRecharge / 100f:F2}";
			text2 = $"{num / 100f:F2}";
		}
		((GObject)content.Title).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(RechargeMissionSlotTitle, text2);
		((GObject)content.Requirement).text = "(" + text + "/" + text2 + ")";
		switch (ArchiveExtension_DynamicActivity_LTTR.GetOneBonusState(RechargeActivity.ActivityId, data.RechargeRequirement))
		{
		case ArchiveExtension_DynamicActivity_LTTR.BonusState.Undergoing:
			content.ReceiveStatus.selectedIndex = 0;
			break;
		case ArchiveExtension_DynamicActivity_LTTR.BonusState.Pending:
			content.ReceiveStatus.selectedIndex = 1;
			break;
		case ArchiveExtension_DynamicActivity_LTTR.BonusState.Claimed:
			content.ReceiveStatus.selectedIndex = 2;
			break;
		}
		((GObject)content.ClaimBtn).onClick.Set((EventCallback0)delegate
		{
			OnClaimBonus(data, slot);
		});
		content.BonusLineList.itemRenderer = (ListItemRenderer)delegate(int j, GObject o)
		{
			RenderBonusLineSlot(i, j, (UI_com_MBonusLineSlot)(object)o);
		};
		content.BonusLineList.numItems = data.BonusLine.Count;
		content.BonusLineList.ResizeToFit(data.BonusLine.Count);
	}

	private void RenderBonusLineSlot(int i, int j, UI_com_MBonusLineSlot slot)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		BonusLine bonusLine = MissionData_List[i].BonusLine[j];
		((GObject)slot.ChildBonusListTitle).text = ChildBonusListTitle.Format(bonusLine.ChildBonuses.Count);
		slot.NoChildBonus.selectedIndex = ((bonusLine.ChildBonuses.Count == 0) ? 1 : 0);
		slot.BonusList.itemRenderer = (ListItemRenderer)delegate(int k, GObject o)
		{
			RenderBonusSlot(i, j, k, (UI_com_MBonusSlot)(object)o);
		};
		slot.BonusList.numItems = bonusLine.Bonuses.Count;
		slot.BonusList.ResizeToFit(bonusLine.Bonuses.Count);
		slot.ChildBonusList.itemRenderer = (ListItemRenderer)delegate(int k, GObject o)
		{
			RenderChildBonusSlot(i, j, k, (UI_com_MChildBonusSlot)(object)o);
		};
		slot.ChildBonusList.numItems = bonusLine.ChildBonuses.Count;
		slot.ChildBonusList.ResizeToFit(bonusLine.ChildBonuses.Count);
		float num = ((GObject)slot.BonusList).x + ((GObject)slot.BonusList).actualWidth;
		float num2 = ((GObject)slot.ChildBonusList).x + ((GObject)slot.ChildBonusList).actualWidth;
		if (num > ((GObject)slot).width)
		{
			GList bonusList = slot.BonusList;
			((GObject)bonusList).width = ((GObject)bonusList).width - (num - ((GObject)slot).width);
		}
		else if (num2 > ((GObject)slot).width)
		{
			GList childBonusList = slot.ChildBonusList;
			((GObject)childBonusList).width = ((GObject)childBonusList).width - (num2 - ((GObject)slot).width);
		}
	}

	private void RenderBonusSlot(int i, int j, int k, UI_com_MBonusSlot slot)
	{
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		RItem rItem = MissionData_List[i].BonusLine[j].Bonuses[k];
		string itemId = rItem.ItemId;
		int cnt = rItem.cnt;
		bool flag = CheckIsSpecialBox(itemId);
		slot.Type.selectedIndex = (flag ? 1 : 0);
		((GObject)slot.Count).text = "x" + cnt.ShortNumberFormat();
		FGUIManager.Instance.SetItemIconAndFrame(slot.Icon, itemId, null, "", frameVisible: false);
		if (Item.ItemType(itemId) == 10 || Item.ItemType(itemId) == 3)
		{
			GLoader icon = slot.Icon;
			((GObject)icon).y = 5f;
			icon.fill = (FillType)1;
			icon.verticalAlign = (VertAlignType)1;
			icon.align = (AlignType)1;
		}
		((GObject)slot.Icon).onClick.Set((EventCallback0)delegate
		{
			OnClickBonus(itemId);
		});
		if (i >= 3)
		{
			FGUIManager.Instance.AddTextSpecialEffects(slot.fxBack, "activated_fx", new Vector3(75f, 75f, 75f));
			string key = $"{i}_{j}";
			if (!SlotsWithGlowEffect.ContainsKey(key))
			{
				SlotsWithGlowEffect.Add(key, new List<GGraph>());
			}
			SlotsWithGlowEffect[key].Add(slot.fxBack);
			((GObject)slot.fxBack).visible = false;
		}
		else
		{
			((GObject)slot.fxBack).displayObject.Dispose();
		}
	}

	private void RenderChildBonusSlot(int i, int j, int k, UI_com_MChildBonusSlot slot)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		RItem rItem = MissionData_List[i].BonusLine[j].ChildBonuses[k];
		string itemId = rItem.ItemId;
		int cnt = rItem.cnt;
		((GObject)slot.Count).text = "x" + cnt.ShortNumberFormat();
		FGUIManager.Instance.SetItemIconAndFrame(slot.Icon, itemId, null, "", frameVisible: false);
		((GObject)slot.Icon).onClick.Set((EventCallback0)delegate
		{
			OnClickBonus(itemId);
		});
	}

	private void PlaySlotRemoveTransition(UI_com_MissionSlot slot)
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		GObject[] children = ((GComponent)slot.Content.BonusLineList).GetChildren();
		foreach (GObject val in children)
		{
			UI_com_MBonusLineSlot uI_com_MBonusLineSlot = (UI_com_MBonusLineSlot)(object)val;
			GObject[] children2 = ((GComponent)uI_com_MBonusLineSlot.BonusList).GetChildren();
			foreach (GObject val2 in children2)
			{
				UI_com_MBonusSlot uI_com_MBonusSlot = (UI_com_MBonusSlot)(object)val2;
				if (!((GObject)uI_com_MBonusSlot.fxBack).displayObject.isDisposed)
				{
					((GObject)uI_com_MBonusSlot.fxBack).displayObject.Dispose();
				}
			}
		}
		TransPlayingSlots.Add(slot);
		GTweenCallback val3 = default(GTweenCallback);
		slot.RemoveTrans.Play((PlayCompleteCallback)delegate
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			if (!((GObject)this).isDisposed)
			{
				GTweener obj = ((GObject)slot.Content).TweenMoveY(0f - ((GObject)slot.Content).height, 0.5f);
				GTweenCallback obj2 = val3;
				if (obj2 == null)
				{
					GTweenCallback val4 = delegate
					{
						if (!((GObject)this).isDisposed)
						{
							TransPlayingSlots.Remove(slot);
							WaitToRemoveSlot.Add(slot);
						}
					};
					GTweenCallback val5 = val4;
					val3 = val4;
					obj2 = val5;
				}
				obj.OnComplete(obj2);
			}
		});
		StartWaitToUpdate();
	}

	private void StartWaitToUpdate()
	{
		if (WaitToUpdateCoroutine == null)
		{
			WaitToUpdateCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(Wait());
		}
		IEnumerator Wait()
		{
			yield return null;
			while (TransPlayingSlots.Count > 0)
			{
				if (((GObject)this).isDisposed)
				{
					yield break;
				}
				yield return null;
			}
			if (!((GObject)this).isDisposed)
			{
				WaitToUpdateCoroutine = null;
				Update();
			}
		}
	}

	private void HideEffect(bool isInit = false)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		float y = ((GObject)this).LocalToRoot(((GObject)List).xy, GRoot.inst).y;
		float y2 = ((GObject)this).LocalToRoot(((GObject)List).xy.Add(((GObject)List).size), GRoot.inst).y;
		foreach (List<GGraph> value in SlotsWithGlowEffect.Values)
		{
			GGraph val = value.First();
			Vector2 val2 = ((GObject)val).LocalToRoot(Vector2.zero, GRoot.inst);
			bool flag = y < val2.y - ((GObject)val).height && val2.y < y2;
			if (!(((GObject)val).displayObject.visible != flag || isInit))
			{
				continue;
			}
			foreach (GGraph item in value)
			{
				((GObject)item).displayObject.visible = flag;
			}
		}
	}
}
