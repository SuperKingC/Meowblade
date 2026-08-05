using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_main_BrawlBuffInfo : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_BrawlBuffInfo Popup;

	public Transition t0;

	public const string URL = "ui://hozu168rxig17z";

	public static string Name = "UI_main_BrawlBuffInfo";

	public const string LevelUpBuffs = "LevelUpBuffs";

	private List<UI_main_BrawlFightSelectIsland.BuffViewModel> _selfBuffs = new List<UI_main_BrawlFightSelectIsland.BuffViewModel>();

	private List<UI_main_BrawlFightSelectIsland.BuffViewModel> _campBuffs = new List<UI_main_BrawlFightSelectIsland.BuffViewModel>();

	private Coroutine _animCoroutine;

	public static string GetURL()
	{
		return "ui://hozu168rxig17z";
	}

	public static UI_main_BrawlBuffInfo CreateInstance()
	{
		return (UI_main_BrawlBuffInfo)(object)UIPackage.CreateObject("GvGBrawlFight", "main_BrawlBuffInfo");
	}

	public static UI_main_BrawlBuffInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BrawlBuffInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rxig17z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Popup = (UI_com_BrawlBuffInfo)(object)((GComponent)this).GetChild("Popup");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(OnClickClosePanel));
		((GObject)Popup.ConfirmBtn).onClick.Set(new EventCallback0(OnClickClosePanel));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)Popup.ConfirmBtn).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		foreach (string item3 in ConfigDataManager.ItemsByType[ItemType.GvGMultiBattleBuff])
		{
			int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(item3);
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(item3);
			UI_main_BrawlFightSelectIsland.BuffViewModel item = new UI_main_BrawlFightSelectIsland.BuffViewModel
			{
				Item = gDEItemData,
				Count = itemCount
			};
			eMultiBattleBuffType multiBattleBuffType = gDEItemData.GetMultiBattleBuffType();
			if (multiBattleBuffType.IsPlayerBuff())
			{
				_selfBuffs.Add(item);
			}
			else if (multiBattleBuffType.IsCampBuff())
			{
				_campBuffs.Add(item);
			}
		}
		Popup.listSelf.itemRenderer = (ListItemRenderer)delegate(int index, GObject val)
		{
			UI_main_BrawlFightSelectIsland.BuffViewModel buffData = _selfBuffs[index];
			UI_com_buff item2 = (UI_com_buff)(object)val;
			UI_main_BrawlFightSelectIsland.RenderBuffItem(item2, buffData);
		};
		Popup.listCamp.itemRenderer = (ListItemRenderer)delegate(int index, GObject val)
		{
			UI_main_BrawlFightSelectIsland.BuffViewModel buffData = _campBuffs[index];
			UI_com_buff item2 = (UI_com_buff)(object)val;
			UI_main_BrawlFightSelectIsland.RenderBuffItem(item2, buffData);
		};
		Popup.listSelf.numItems = _selfBuffs.Count;
		Popup.listCamp.numItems = _campBuffs.Count;
		((GComponent)Popup.listCamp).childrenRenderOrder = (ChildrenRenderOrder)2;
		((GComponent)Popup.listSelf).childrenRenderOrder = (ChildrenRenderOrder)2;
		object value;
		List<RItem> list = (parameters.TryGetValue("LevelUpBuffs", out value) ? ((List<RItem>)value) : new List<RItem>());
		if (list.Count > 0)
		{
			_animCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ShowLevelUpBuffAnims(list));
		}
	}

	private IEnumerator ShowLevelUpBuffAnims(List<RItem> levelUpBuffs)
	{
		((GObject)Popup.ConfirmBtn).visible = false;
		yield return ShowLevelUpBuffAnimsList(levelUpBuffs, Popup.listSelf, _selfBuffs);
		yield return ShowLevelUpBuffAnimsList(levelUpBuffs, Popup.listCamp, _campBuffs);
		((GObject)Popup.ConfirmBtn).visible = true;
		_animCoroutine = null;
	}

	private static IEnumerator ShowLevelUpBuffAnimsList(List<RItem> levelUpBuffs, GList parent, List<UI_main_BrawlFightSelectIsland.BuffViewModel> targetList)
	{
		foreach (UI_main_BrawlFightSelectIsland.BuffViewModel item in targetList)
		{
			string idId = item.Item.Key;
			int increaseCount = (item.IncreaseCount = levelUpBuffs.Find((RItem x) => x.ItemId == idId)?.cnt ?? 0);
			if (increaseCount > 0)
			{
				UI_main_BrawlFightSelectIsland.RenderBuffItem(buffData: new UI_main_BrawlFightSelectIsland.BuffViewModel
				{
					Item = item.Item,
					Count = item.Count - increaseCount
				}, item: item.BuffObj);
			}
		}
		int index = 0;
		foreach (UI_main_BrawlFightSelectIsland.BuffViewModel item2 in targetList)
		{
			if (item2.IncreaseCount > 0)
			{
				int increaseCount2 = item2.IncreaseCount;
				if (increaseCount2 == item2.Count)
				{
					item2.BuffObj.Unlock.SetHook("change", (TransitionHook)delegate
					{
						UI_main_BrawlFightSelectIsland.RenderBuffItem(item2.BuffObj, item2);
					});
					item2.BuffObj.Unlock.Play();
				}
				else
				{
					item2.BuffObj.Levelup.SetHook("change", (TransitionHook)delegate
					{
						UI_main_BrawlFightSelectIsland.RenderBuffItem(item2.BuffObj, item2);
					});
					item2.BuffObj.Levelup.Play();
				}
				((GComponent)parent).apexIndex = index;
				yield return (object)new WaitForSeconds(0.6f);
			}
			index++;
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

	private void OnClickClosePanel()
	{
		if (_animCoroutine == null)
		{
			UnityUiService.Instance.ClosePanel(Name);
		}
	}
}
