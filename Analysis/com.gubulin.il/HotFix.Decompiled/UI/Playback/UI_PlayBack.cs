using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Battle;
using UI.EnemyIntroduction;
using UI.LegendItemInfo;
using UnityEngine;

namespace UI.Playback;

public class UI_PlayBack : GComponent, IUiController
{
	public GGraph Mask;

	public UI_Dialog Dialog;

	public UI_ReplayDetials DetailsDialog;

	public const string URL = "ui://9u6qpm6pt6gc3";

	public static string Name = "UI_PlayBack";

	private Coroutine _CoroutineRefreshCountDown;

	private const int RefreshInterval = 5;

	private List<GTweener> videoItemGTweeners = new List<GTweener>();

	private Coroutine _Coroutine_RenderVideoList;

	private List<string> shaderList = new List<string>();

	private const int LegendItemsLimit = 2;

	private List<UI_SoldierFormation> ourFormations = new List<UI_SoldierFormation>();

	private const int MaxFormationsNum = 9;

	private const int maxRenderFormationCount = 5;

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private int _retryTimes = 0;

	private Coroutine downloadReplayDataCoroutine;

	private List<string> textureList = new List<string>();

	private List<LevelBattleReplay> replays = new List<LevelBattleReplay>();

	private List<LevelBattleReplay> recentReplays = new List<LevelBattleReplay>();

	private List<LevelBattleReplay> levelReplays = new List<LevelBattleReplay>();

	private const float HeadIconLoadDelay = 0.2f;

	private int avatarLoadedCount;

	private string levelId;

	private Coroutine getReplayAvatarCoroutine = null;

	private Coroutine getReplayNicknameCoroutine = null;

	public static string GetURL()
	{
		return "ui://9u6qpm6pt6gc3";
	}

	public static UI_PlayBack CreateInstance()
	{
		return (UI_PlayBack)(object)UIPackage.CreateObject("Playback", "PlayBack");
	}

	public static UI_PlayBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://9u6qpm6pt6gc3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_Dialog)(object)((GComponent)this).GetChild("Dialog");
		DetailsDialog = (UI_ReplayDetials)(object)((GComponent)this).GetChild("DetailsDialog");
	}

	public void BeforeDestroy()
	{
		if (_Coroutine_RenderVideoList != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_RenderVideoList);
		}
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("PlayBack.First");
		instance.Unregister("PlayBack.PlayBtn");
		UiHelper.ReleaseUnityWebRequestImage();
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.ContainsKey("Order"))
		{
			((GObject)this).sortingOrder = (int)parameters["Order"];
		}
		if (parameters.ContainsKey("LevelId"))
		{
			levelId = (string)parameters["LevelId"];
		}
		if (parameters.TryGetValue("RecentReplays", out var value))
		{
			recentReplays = (List<LevelBattleReplay>)value;
			if (recentReplays == null)
			{
				recentReplays = new List<LevelBattleReplay>();
			}
		}
		if (parameters.TryGetValue("LevelReplays", out var value2))
		{
			levelReplays = (List<LevelBattleReplay>)value2;
			if (levelReplays == null)
			{
				levelReplays = new List<LevelBattleReplay>();
			}
		}
		if (parameters.ContainsKey("Type"))
		{
			Dialog.Type.selectedIndex = (int)parameters["Type"];
		}
		Dialog.Refresh.Type.selectedIndex = 0;
		PageChange();
		if (Dialog.Type.selectedIndex == 2)
		{
			PlayZBossStory();
		}
		else
		{
			RenderDialog();
		}
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("PlayBack.PlayBtn", DetailsDialog.playBtn);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.PageBtnFoo).onClick.Add(new EventCallback0(PageBtnFooClick));
		((GObject)Dialog.PageBtnBar).onClick.Add(new EventCallback0(PageBtnBarClick));
		((GObject)Dialog.Refresh).onClick.Add(new EventCallback1(RefreshLevelReplays));
		((GObject)DetailsDialog.playBtn).onClick.Add(new EventCallback1(PlayVideo));
		((GObject)DetailsDialog.exitBtn).onClick.Add(new EventCallback0(CloseReplayDetail));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.PageBtnFoo).onClick.Remove(new EventCallback0(PageBtnFooClick));
		((GObject)Dialog.PageBtnBar).onClick.Remove(new EventCallback0(PageBtnBarClick));
		((GObject)Dialog.Refresh).onClick.Remove(new EventCallback1(RefreshLevelReplays));
		((GObject)DetailsDialog.playBtn).onClick.Remove(new EventCallback1(PlayVideo));
		((GObject)DetailsDialog.exitBtn).onClick.Remove(new EventCallback0(CloseReplayDetail));
	}

	public void End()
	{
		if (_CoroutineRefreshCountDown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_CoroutineRefreshCountDown);
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		for (int j = 0; j < shaderList.Count; j++)
		{
			AssetsManager.Instance.UnloadAsset<Shader>(shaderList[j]);
		}
		if (replays != null)
		{
			replays.Clear();
		}
	}

	private void RefreshLevelReplays(EventContext context)
	{
		if (Dialog.Refresh.Type.selectedIndex == 1)
		{
			return;
		}
		ILRequestHelper<GetLevelReplaysResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().GetLevelReplays(levelId, random: true, string.Empty), delegate(GetLevelReplaysResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_CoroutineRefreshCountDown = FGUIManager.Instance.OpenIEnumerator(RefreshCountDown());
				List<LevelBattleReplay> list = response.Replays;
				if (list == null)
				{
					list = new List<LevelBattleReplay>();
				}
				UI_Battle.curStrategyGuide = list;
				ReplayDownloadManager.OnLevelReplaysResponse(response);
				levelReplays = ListExtensions.DeepCopy<LevelBattleReplay>(UI_Battle.curStrategyGuide);
				replays = levelReplays;
				RenderDialog();
			}
		});
	}

	private IEnumerator RefreshCountDown()
	{
		Dialog.Refresh.Type.selectedIndex = 1;
		int time = 5;
		while (time > 0)
		{
			((GObject)Dialog.Refresh.countDown).text = $"{time}";
			time--;
			yield return (object)new WaitForSeconds(1f);
			if (time <= 0)
			{
				Dialog.Refresh.Type.selectedIndex = 0;
			}
		}
	}

	private void PageChange()
	{
		if (Dialog.Type.selectedIndex == 0)
		{
			replays = ListExtensions.DeepCopy<LevelBattleReplay>(recentReplays);
			Dialog.PageBtnFoo.Type.selectedIndex = 1;
			Dialog.PageBtnBar.Type.selectedIndex = 0;
		}
		else
		{
			replays = ListExtensions.DeepCopy<LevelBattleReplay>(levelReplays);
			Dialog.PageBtnFoo.Type.selectedIndex = 0;
			Dialog.PageBtnBar.Type.selectedIndex = 1;
		}
	}

	private void PageBtnFooClick()
	{
		if (Dialog.Type.selectedIndex != 0)
		{
			Dialog.Type.selectedIndex = 0;
			PageChange();
			RenderDialog();
		}
	}

	private void PageBtnBarClick()
	{
		if (Dialog.Type.selectedIndex != 1)
		{
			Dialog.Type.selectedIndex = 1;
			PageChange();
			RenderDialog();
		}
	}

	private void PlayZBossStory()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		((GObject)Mask).touchable = false;
		((GObject)Dialog).touchable = false;
		Dialog.ZBOSSExtraScene.SetHook("ui_ZBOSS_slash", new TransitionHook(ShowZBossSlash));
		Dialog.ZBOSSExtraScene.Play((PlayCompleteCallback)delegate
		{
			string story_id = (GameManagers.Instance.UserArchiveManager.GetPlayZBossExtraSceneRecord() ? "Story_11202" : "Story_11201");
			ILRequestHelper<ActivateStoryResponse>.Request((EventContext)null, (Func<Task<ActivateStoryResponse>>)(() => GameController.Contexts.Service<INetworkService>().ActivateStory(-1L, story_id, playZBossExtraScene: true)), (Action<ActivateStoryResponse>)delegate(ActivateStoryResponse responseActivate)
			{
				if (responseActivate.Result)
				{
					GameManagers.Instance.UserArchiveManager.SetPlayZBossExtraSceneRecord();
					GameManagers.Instance.StoryManager.ActivateStory(story_id);
					StoryManager.PlayStory(GameManagers.Instance, story_id);
					End();
				}
			});
		});
		void ShowZBossSlash()
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			FGUIManager.Instance.AddTextSpecialEffects(Dialog.SfxBack, "ui_ZBOSS_slash", Vector3.one * 100f);
		}
	}

	private void RenderDialog()
	{
		if (replays == null || replays.Count <= 0)
		{
			Dialog.TipController.selectedIndex = 2;
			Dialog.SetControllerPageText();
			Dialog.ContentController.selectedIndex = 0;
			if (Dialog.Type.selectedIndex == 1)
			{
				((GObject)Dialog.Tip1).text = LanguagesManager.GetDesc("CsharpCodeZhTcText443");
				((GObject)Dialog.Tip).text = "";
			}
			else
			{
				((GObject)Dialog.Tip1).text = LanguagesManager.GetDesc("CsharpCodeZhTcText444") + "！";
				((GObject)Dialog.Tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText443");
			}
			return;
		}
		Dialog.ContentController.selectedIndex = 1;
		if (replays.Count >= 5)
		{
			Dialog.TipController.selectedIndex = 1;
			Dialog.SetControllerPageText();
		}
		else
		{
			Dialog.TipController.selectedIndex = 0;
			Dialog.SetControllerPageText();
		}
		if (_Coroutine_RenderVideoList != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_RenderVideoList);
		}
		_Coroutine_RenderVideoList = FGUIManager.Instance.OpenIEnumerator(Real_RenderVideoList());
	}

	private IEnumerator Real_RenderVideoList()
	{
		float delay = 0.15f;
		Dialog.Video.RemoveChildrenToPool();
		for (int i = videoItemGTweeners.Count - 1; i >= 0; i--)
		{
			videoItemGTweeners[i].Kill(false);
		}
		videoItemGTweeners.Clear();
		for (int j = 0; j < replays.Count; j++)
		{
			if (replays[j] == null)
			{
				continue;
			}
			GObject item = Dialog.Video.AddItemFromPool();
			item.touchable = false;
			item.alpha = 0f;
			item.scale = new Vector2(0.25f, 0.25f);
			RenderVideoItem(j, item);
			GTweenCallback val = default(GTweenCallback);
			GTweener _delayTweenr = ((GComponent)(object)Dialog.Video).SetTimeout(delay).OnComplete((GTweenCallback)delegate
			{
				//IL_0041: Unknown result type (might be due to invalid IL or missing references)
				//IL_0028: Unknown result type (might be due to invalid IL or missing references)
				//IL_002d: Unknown result type (might be due to invalid IL or missing references)
				//IL_002f: Expected O, but got Unknown
				//IL_0034: Expected O, but got Unknown
				GTweener obj = item.TweenFade(1f, 0.1f);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						item.touchable = true;
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				GTweener item2 = obj.OnComplete(obj2);
				GTweener item3 = item.TweenScale(Vector2.one, 0.1f);
				videoItemGTweeners.Add(item2);
				videoItemGTweeners.Add(item3);
			});
			videoItemGTweeners.Add(_delayTweenr);
			delay += 0.15f;
			yield return null;
		}
		UiTagManager uiTagManager = UiTagManager.Instance;
		uiTagManager.Unregister("PlayBack.First");
		uiTagManager.Register("PlayBack.First", ((GComponent)Dialog.Video).GetChildAt(0));
	}

	private void RenderVideoItem(int index, GObject obj)
	{
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Expected O, but got Unknown
		UI_VideoItem button = (UI_VideoItem)(object)obj;
		LevelBattleReplay replay = replays[index];
		switch (GetBattleResult(replay.HpPercent))
		{
		case 0:
			button.TipController.selectedIndex = 0;
			break;
		case 1:
			button.TipController.selectedIndex = 1;
			break;
		case 2:
			button.TipController.selectedIndex = 2;
			break;
		default:
			button.TipController.selectedIndex = 0;
			break;
		}
		button.HeadPortrait.HeadPortrait.icon.url = "ui://kt6rg65op8apur3";
		button.isShowMedal.SetSelectedIndex(0);
		if (Dialog.Type.selectedIndex == 0)
		{
			GDELevelData data = GDMgr.Get<GDELevelData>(replay.LevelId);
			((GObject)button.title).text = new Level(data).Name;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.SetSelfImageByWebRequestAndStorage(Name, button.HeadPortrait.HeadPortrait.icon));
		}
		else if (Dialog.Type.selectedIndex == 1)
		{
			FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, replay.UserId, button.HeadPortrait.HeadPortrait.icon, button.title));
			FGUIManager.Instance.GetUserMedal(replay.UserId, button.medalList, button.isShowMedal);
		}
		((GObject)button.Back).data = replay.BattleId;
		if (replay.Detail != null && replay.Detail.Soldiers != null && replay.Detail.Techs != null)
		{
			((GObject)button.title).data = replay.Detail.Techs;
			DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp(replay.DateAdded);
			List<SoldierDetail> soldiers = replay.Detail.Soldiers;
			((GObject)button.Time).data = 0;
			((GObject)button.HeadPortrait).data = new List<UiHelper.ReplaySoldierDetail>();
			((GObject)button.Soldiers).data = soldiers;
			button.Soldiers.itemRenderer = new ListItemRenderer(RenderSoldierItem);
			button.Soldiers.numItems = soldiers.Count;
			((GObject)button.Time).text = ((int)((GObject)button.Time).data).ToString();
			((GObject)button).onClick.Set((EventCallback0)delegate
			{
				ShowReplayDetail(replay, (int)((GObject)button.Time).data, dateTimeOffset.DateTime.ToShortDateString(), button.TipController.selectedIndex, (List<UiHelper.ReplaySoldierDetail>)((GObject)button.HeadPortrait).data);
			});
			return;
		}
		DateTimeOffset dateTimeOffset2 = DateTimeHelper.ParseTimeStamp(replay.DateAdded);
		List<string> list = new List<string> { replay.Soldier1, replay.Soldier2, replay.Soldier3, replay.Soldier4, replay.Soldier5 };
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (string.IsNullOrEmpty(list[num]))
			{
				list.RemoveAt(num);
			}
		}
		((GObject)button.Time).data = 0;
		((GObject)button.HeadPortrait).data = new List<FakeSoldier>();
		((GObject)button.Soldiers).data = list;
		button.Soldiers.itemRenderer = new ListItemRenderer(RenderOldSoldierItem);
		button.Soldiers.numItems = list.Count;
		((GObject)button.Time).text = "----";
		((GObject)button).onClick.Set((EventCallback0)delegate
		{
			ShowReplayFakeDetail(replay, dateTimeOffset2.DateTime.ToShortDateString(), button.TipController.selectedIndex, (List<FakeSoldier>)((GObject)button.HeadPortrait).data);
		});
	}

	private void RenderFakeSoldier(UiHelper.ReplaySoldierDetail soldier, UI_soliderItem btn)
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		((GObject)btn.lv).text = soldier.Level.ToString();
		int itemLevel = (soldier.PotentialLevel + 2) / 2;
		string iconPath = UiHelper.GetIconPath(soldier.Id, itemLevel);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		btn.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, soldier.PotentialLevel, shaderList);
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, soldier.PotentialLevel, new List<int>());
		FakeSoldier fakeSoldierData = new FakeSoldier(soldier.Id, soldier.Level, soldier.EvoLevel, soldier.PotentialLevel);
		((GObject)btn).onClick.Set((EventCallback0)delegate
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, new Dictionary<string, object>
			{
				{ "SoldierId", soldier.Id },
				{ "FakeSoldierData", fakeSoldierData },
				{ "Num", soldier.Num },
				{ "CombatPower", soldier.CombatPower },
				{ "ATK", soldier.Attack },
				{ "DEF", soldier.Defense },
				{ "HP", soldier.Health },
				{ "LegendItemBrief", soldier.LegendItems }
			});
		});
		RenderLegendItems(soldier, (GButton)(object)btn);
		((GObject)btn).touchable = true;
	}

	private void RenderLegendItems(UiHelper.ReplaySoldierDetail soldier, GButton button)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		((GComponent)button).GetChild("LegendItems").visible = false;
		if (soldier.LegendItems == null || soldier.LegendItems.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			((GComponent)button).GetChild($"legendItem{i}").visible = false;
		}
		int num = 0;
		for (int j = 0; j < soldier.LegendItems.Count; j++)
		{
			if (num >= 2)
			{
				break;
			}
			GButton asButton = ((GComponent)button).GetChild($"legendItem{num}").asButton;
			((GObject)asButton).visible = true;
			UiHelper.RenderLegendItem(asButton, soldier.LegendItems[j], UiHelper.TextColorType.Light, null, 2);
			((GObject)asButton).data = soldier.LegendItems[j];
			((GObject)asButton).onClick.Set(new EventCallback1(OpenLegendItemInfoDialog));
			num++;
		}
		bool flag = false;
		for (int k = 0; k < 2; k++)
		{
			GButton asButton2 = ((GComponent)button).GetChild($"legendItem{k}").asButton;
			if (((GObject)asButton2).visible)
			{
				break;
			}
			if (k == 1)
			{
				flag = true;
			}
		}
		((GComponent)button).GetChild("LegendItems").visible = !flag;
	}

	private void OpenLegendItemInfoDialog(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		LegendItemBrief itemBrief = (LegendItemBrief)((GObject)context.sender).data;
		UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(null, "", -1, 3, null, itemBrief);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
	}

	private int GetBattleResult(int hpPercent)
	{
		if (hpPercent <= 30)
		{
			return 0;
		}
		if (hpPercent <= 80)
		{
			return 1;
		}
		return 2;
	}

	private void formationsInit()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		float num = 0.05f;
		ourFormations.Clear();
		for (int i = 0; i < 9; i++)
		{
			UI_SoldierFormation _redBtn = (UI_SoldierFormation)(object)((GComponent)DetailsDialog).GetChild($"OurFormation{i}");
			ourVector2s.Add(((GObject)_redBtn).xy);
			ourFormations.Add(_redBtn);
			((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				((GObject)_redBtn).TweenFade(1f, 0.1f);
			});
			num += 0.05f;
		}
	}

	private void ShowOurIcons()
	{
		float num = 0.05f;
		for (int i = 0; i < ourFormations.Count; i++)
		{
			UI_SoldierFormation uI_SoldierFormation = ourFormations[i];
			uI_SoldierFormation.ShowInfo.Play();
		}
	}

	private void RenderSoldierItem(int index, GObject obj)
	{
		if (((GObject)obj.parent).data != null)
		{
			GButton asButton = ((GComponent)obj.asButton).GetChild("icon").asButton;
			GObject child = ((GObject)obj.parent).parent.GetChild("Time");
			GObject child2 = ((GObject)obj.parent).parent.GetChild("HeadPortrait");
			List<UiHelper.ReplaySoldierDetail> list = (List<UiHelper.ReplaySoldierDetail>)child2.data;
			int num = (int)child.data;
			SoldierDetail soldierDetail = ((List<SoldierDetail>)((GObject)obj.parent).data)[index];
			string battleId = ((GObject)obj.parent).parent.GetChild("Back").data.ToString();
			List<TechLevel> techs = (List<TechLevel>)((GObject)obj.parent).parent.GetChild("title").data;
			string soldierId = soldierDetail.SoldierId;
			int potentialLevel = soldierDetail.PotentialLevel;
			int evoLevel = soldierDetail.EvoLevel;
			int level = soldierDetail.Level;
			UiHelper.ReplaySoldierDetail replaySoldierDetail = UiHelper.GetReplaySoldierDetail(battleId, soldierId, level, potentialLevel, evoLevel, soldierDetail.Num, soldierDetail.Weapons, soldierDetail.LegendItems, techs);
			num += replaySoldierDetail.CombatPower;
			child.data = num;
			list.Add(replaySoldierDetail);
			child2.data = list;
			GRichTextField asRichTextField = ((GComponent)asButton).GetChild("lv").asRichTextField;
			((GObject)asRichTextField).SetPivot(0.5f, 0.5f);
			TextFormat textFormat = ((GTextField)asRichTextField).textFormat;
			textFormat.size = 40;
			((GTextField)asRichTextField).textFormat = textFormat;
			((GTextField)asRichTextField).autoSize = (AutoSizeType)1;
			((GObject)asRichTextField).text = level.ToString();
			((GComponent)asButton).GetChild("lvFrame").asLoader.url = UiHelper.GetLevelFrameBorderSoldier(potentialLevel);
			((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldierId);
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(potentialLevel);
			((GComponent)asButton).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			FGUIManager.Instance.ClearCache_SoliderSoulStone();
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton).GetChild("SoulStoneLevel").asCom, potentialLevel, new List<int>());
		}
	}

	private void RenderOldSoldierItem(int index, GObject obj)
	{
		if (((GObject)obj.parent).data != null)
		{
			GButton asButton = ((GComponent)obj.asButton).GetChild("icon").asButton;
			GObject child = ((GObject)obj.parent).parent.GetChild("HeadPortrait");
			List<FakeSoldier> list = (List<FakeSoldier>)child.data;
			string text = ((List<string>)((GObject)obj.parent).data)[index];
			string[] array = text.Split('|');
			if (array.Length >= 4)
			{
				string soldierId = array[0];
				int num = int.Parse(array[1]);
				int evoLevel = int.Parse(array[2]);
				int level = int.Parse(array[3]);
				FakeSoldier fakeSoldier = new FakeSoldier(soldierId, level, evoLevel, num);
				list.Add(fakeSoldier);
				child.data = list;
				GRichTextField asRichTextField = ((GComponent)asButton).GetChild("lv").asRichTextField;
				((GObject)asRichTextField).SetPivot(0.5f, 0.5f);
				TextFormat textFormat = ((GTextField)asRichTextField).textFormat;
				textFormat.size = 40;
				((GTextField)asRichTextField).textFormat = textFormat;
				((GTextField)asRichTextField).autoSize = (AutoSizeType)1;
				((GObject)asRichTextField).text = fakeSoldier.Level.ToString();
				((GComponent)asButton).GetChild("lvFrame").asLoader.url = UiHelper.GetLevelFrameBorderSoldier(num);
				((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(fakeSoldier.Id);
				string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(fakeSoldier.PotentialLevel);
				((GComponent)asButton).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
				FGUIManager.Instance.ClearCache_SoliderSoulStone();
				FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton).GetChild("SoulStoneLevel").asCom, fakeSoldier.PotentialLevel, new List<int>());
			}
		}
	}

	private void PlayVideo(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		_retryTimes = 0;
		LevelBattleReplay replay = (LevelBattleReplay)((GObject)context.sender).data;
		if (downloadReplayDataCoroutine == null)
		{
			downloadReplayDataCoroutine = FGUIManager.Instance.OpenIEnumerator(DownloadReplayData(replay, 0));
		}
	}

	private void SetOurPos(string fid)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		Formation formation = FormationManager.Formations[fid];
		Dictionary<string, Vector2> dictionary = new Dictionary<string, Vector2>
		{
			{
				"8.3_3.4",
				ourVector2s[7]
			},
			{
				"8.3_0",
				ourVector2s[0]
			},
			{
				"8.3_-3.4",
				ourVector2s[5]
			},
			{
				"4.9_3.4",
				ourVector2s[1]
			},
			{
				"4.9_0",
				ourVector2s[3]
			},
			{
				"4.9_-3.4",
				ourVector2s[2]
			},
			{
				"1.5_3.4",
				ourVector2s[8]
			},
			{
				"1.5_0",
				ourVector2s[4]
			},
			{
				"1.5_-3.4",
				ourVector2s[6]
			}
		};
		for (int i = 0; i < 5; i++)
		{
			if (formation.SlotPosition.ContainsKey(i))
			{
				string key = $"{formation.SlotPosition[i].x}_{formation.SlotPosition[i].y}";
				if (dictionary.ContainsKey(key))
				{
					((GObject)ourFormations[i]).xy = dictionary[key];
					dictionary.Remove(key);
				}
			}
		}
		List<Vector2> list = new List<Vector2>();
		foreach (KeyValuePair<string, Vector2> item in dictionary)
		{
			list.Add(item.Value);
		}
		for (int j = 5; j < ourFormations.Count; j++)
		{
			((GObject)ourFormations[j]).xy = list[j - 5];
		}
	}

	private void ShowReplayDetail(LevelBattleReplay replay, int totalPower, string timeText, int result, List<UiHelper.ReplaySoldierDetail> fakeSoldiers)
	{
		((GObject)DetailsDialog).visible = true;
		formationsInit();
		SetOurPos(replay.Detail.FormationId);
		for (int i = 0; i < ourFormations.Count && i <= fakeSoldiers.Count - 1; i++)
		{
			string id = fakeSoldiers[i].Id;
			if (!string.IsNullOrWhiteSpace(id) && id != "Unlock" && id != "Lock")
			{
				ourFormations[i].Type.selectedIndex = 0;
				int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(fakeSoldiers[i].Id, fakeSoldiers[i].Level);
				((GObject)ourFormations[i].num).text = $"{fakeSoldiers[i].Num}/{soldierFormationNumber}";
				RenderFakeSoldier(fakeSoldiers[i], ourFormations[i].Icon);
			}
			else
			{
				ourFormations[i].Type.selectedIndex = 1;
			}
		}
		ShowOurIcons();
		((GObject)DetailsDialog.CombatPower).text = totalPower.ToString();
		DetailsDialog.Result.selectedIndex = result;
		GDELevelData gDELevelData = GDMgr.Get<GDELevelData>(replay.LevelId);
		((GObject)DetailsDialog.LevelName).text = gDELevelData.Name ?? "";
		((GObject)DetailsDialog.Time).text = timeText;
		if (Dialog.Type.selectedIndex == 0)
		{
			getReplayAvatarCoroutine = FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.SetSelfImageByWebRequestAndStorage(Name, DetailsDialog.Icon.HeadPortrait.icon));
			getReplayNicknameCoroutine = FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetUserNickName(replay.UserId, DetailsDialog.userName));
		}
		else if (Dialog.Type.selectedIndex == 1)
		{
			getReplayAvatarCoroutine = FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, replay.UserId, DetailsDialog.Icon.HeadPortrait.icon, DetailsDialog.userName));
		}
		((GObject)DetailsDialog.playBtn).data = replay;
	}

	private void ShowReplayFakeDetail(LevelBattleReplay replay, string timeText, int result, List<FakeSoldier> fakeSoldiers)
	{
		((GObject)DetailsDialog).visible = true;
		formationsInit();
		for (int i = 0; i < ourFormations.Count && i <= fakeSoldiers.Count - 1; i++)
		{
			ourFormations[i].Type.selectedIndex = 1;
		}
		((GObject)DetailsDialog.Tip).visible = true;
		ShowOurIcons();
		((GObject)DetailsDialog.CombatPower).text = "----";
		((GObject)DetailsDialog.userName).text = replay.Nickname;
		DetailsDialog.Result.selectedIndex = result;
		GDELevelData gDELevelData = GDMgr.Get<GDELevelData>(replay.LevelId);
		((GObject)DetailsDialog.LevelName).text = gDELevelData.Name ?? "";
		((GObject)DetailsDialog.Time).text = timeText;
		UiHelper.GetImageByUnityWebRequest(DetailsDialog.Icon.HeadPortrait.icon, replay.Avatar);
		((GObject)DetailsDialog.playBtn).data = replay;
	}

	private void CloseReplayDetail()
	{
		if (getReplayAvatarCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(getReplayAvatarCoroutine);
		}
		if (getReplayNicknameCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(getReplayNicknameCoroutine);
		}
		((GObject)DetailsDialog).visible = false;
		((GObject)DetailsDialog.CombatPower).text = "";
		((GObject)DetailsDialog.userName).text = "";
		DetailsDialog.Result.selectedIndex = 0;
		((GObject)DetailsDialog.LevelName).text = "";
		((GObject)DetailsDialog.Time).text = "";
		DetailsDialog.Icon.HeadPortrait.icon.url = "";
		for (int i = 0; i < ourFormations.Count; i++)
		{
			((GObject)ourFormations[i]).alpha = 0f;
			((GObject)ourFormations[i].Icon).alpha = 0f;
			ourFormations[i].Type.selectedIndex = 1;
		}
		((GObject)DetailsDialog.Tip).visible = false;
	}

	public IEnumerator DownloadReplayData(LevelBattleReplay replay, int downloadedSegments, float waitTime = -1f)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		UnityUiService.Instance.SetWaitingPanelType(1);
		UnityUiService.Instance.SetWaitingPanelDownloadProgress(0f, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		yield return ReplayDownloadManager.DownloadReplayZip(replay.BattleId, delegate(bool isSuccess)
		{
			if (!isSuccess)
			{
			}
		}, delegate(float progress)
		{
			float barValue = progress * 65f;
			UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		});
		yield return PlayBattleReplay(replay, downloadedSegments, waitTime);
		downloadReplayDataCoroutine = null;
	}

	public IEnumerator PlayBattleReplay(LevelBattleReplay replay, int downloadedSegments, float wait_tm = -1f)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		UnityUiService.Instance.SetWaitingPanelType(1);
		if (wait_tm > 0f)
		{
			yield return (object)new WaitForSeconds(0.2f);
		}
		else
		{
			yield return null;
		}
		if (downloadedSegments == 0)
		{
			GameController.Contexts.Service<INetworkService>().InformWatchingStoryMainReplay(replay.BattleId);
			GameManagers.Instance.Messenger.Broadcast("WATCHING_STORY_MAIN_REPLAY");
		}
		ReplayDownloadManager.DownloadReplay(replay.BattleId, replay.ReplaySegments, downloadedSegments, delegate(bool isSucess)
		{
			if (!isSucess)
			{
				if (_retryTimes > 10)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText53") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText54") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					_retryTimes++;
					FGUIManager.Instance.OpenIEnumerator(PlayBattleReplay(replay, downloadedSegments, 0.2f));
				}
			}
			else
			{
				_retryTimes = 0;
				downloadedSegments++;
				float barValue = 1f * (float)downloadedSegments / (float)(replay.ReplaySegments + 1) * 100f;
				UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue);
				if (downloadedSegments == replay.ReplaySegments + 1)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					PlayBattleReplayData playBattleReplayData = new PlayBattleReplayData
					{
						BattleId = replay.BattleId,
						TargetFrame = replay.ReplayFrames - 1,
						LevelId = replay.LevelId,
						LocalSource = true,
						ReplayMode = 3,
						MaskDuration = 0
					};
					GameLocalDataManager.SetLastReplayUserId(replay.UserId);
					GameLocalDataManager.SetLastReplayUserInfo(replay.Nickname, replay.Avatar);
					GameLocalDataManager.SetLastReplay(playBattleReplayData);
					GameLocalDataManager.SetLastOpenReplayList(Dialog.Type.selectedIndex + 1);
					GameManagers.Instance.Messenger.Broadcast<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", playBattleReplayData, null);
				}
				else
				{
					FGUIManager.Instance.OpenIEnumerator(PlayBattleReplay(replay, downloadedSegments));
				}
			}
		});
	}
}
