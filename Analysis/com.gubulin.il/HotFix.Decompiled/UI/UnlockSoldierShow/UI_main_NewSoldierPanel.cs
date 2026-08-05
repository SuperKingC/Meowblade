using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.UnlockSoldierShow;

public class UI_main_NewSoldierPanel : GComponent, IUiController
{
	public class SkillData
	{
		public string AbilityId;

		public GDEAbilityData GDEData;

		public int LimitPotentialLevel;

		public bool IsUnlock;
	}

	public GLoader background;

	public UI_dec_Background n82;

	public UI_dec_01 n83;

	public UI_dec_02 n84;

	public GImage n85;

	public GImage n90;

	public UI_dec_light02 n88;

	public GImage Victory;

	public UI_dec_light01 n87;

	public UI_com_LeftInfo LeftInfo;

	public UI_com_RightInfo RightInfo;

	public UI_BaseSpine BaseSpine;

	public GImage n93;

	public UI_com_SoldierSpine SoldierSpineLoader;

	public UI_dec_light04 n94;

	public UI_BaseMaskSpine BaseMaskSpine;

	public GGraph ToEndMask;

	public Transition Transition;

	public const string URL = "ui://ia1am3ehgnnrt1z";

	public static string Name = "UI_main_NewSoldierPanel";

	private bool IsRookieBonus = false;

	private string _soldierId;

	private Soldier _soldier;

	private GameObject _canvasObject;

	private readonly List<SkillData> _skillList = new List<SkillData>();

	private List<string> _unlockedProductList = new List<string>();

	private bool _canSkip = false;

	public static string GetURL()
	{
		return "ui://ia1am3ehgnnrt1z";
	}

	public static UI_main_NewSoldierPanel CreateInstance()
	{
		return (UI_main_NewSoldierPanel)(object)UIPackage.CreateObject("UnlockSoldierShow", "main_NewSoldierPanel");
	}

	public static UI_main_NewSoldierPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_NewSoldierPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehgnnrt1z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		n82 = (UI_dec_Background)(object)((GComponent)this).GetChild("n82");
		n83 = (UI_dec_01)(object)((GComponent)this).GetChild("n83");
		n84 = (UI_dec_02)(object)((GComponent)this).GetChild("n84");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		n88 = (UI_dec_light02)(object)((GComponent)this).GetChild("n88");
		Victory = (GImage)((GComponent)this).GetChild("Victory");
		n87 = (UI_dec_light01)(object)((GComponent)this).GetChild("n87");
		LeftInfo = (UI_com_LeftInfo)(object)((GComponent)this).GetChild("LeftInfo");
		RightInfo = (UI_com_RightInfo)(object)((GComponent)this).GetChild("RightInfo");
		BaseSpine = (UI_BaseSpine)(object)((GComponent)this).GetChild("BaseSpine");
		n93 = (GImage)((GComponent)this).GetChild("n93");
		SoldierSpineLoader = (UI_com_SoldierSpine)(object)((GComponent)this).GetChild("SoldierSpineLoader");
		n94 = (UI_dec_light04)(object)((GComponent)this).GetChild("n94");
		BaseMaskSpine = (UI_BaseMaskSpine)(object)((GComponent)this).GetChild("BaseMaskSpine");
		ToEndMask = (GGraph)((GComponent)this).GetChild("ToEndMask");
		Transition = ((GComponent)this).GetTransition("Transition");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 110;
		_soldierId = (string)parameters["SoldierId"];
		_soldier = GameManagers.Instance.SoldierManager.Get(_soldierId);
		_unlockedProductList = (List<string>)parameters["UnlockedProductList"];
		RenderSoldierInfo();
		RenderSoldierAnimation();
		RenderSkillList();
		Transition.invalidateBatchingEveryFrame = true;
		RightInfo.t0.invalidateBatchingEveryFrame = true;
		LeftInfo.t0.invalidateBatchingEveryFrame = true;
		Transition.Play(new PlayCompleteCallback(OnTransitionComplete));
	}

	public void RegisterUiEventListeners()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		SharedMessenger.AddListener("ROOKIE_POOL_CONTENT_CLOSED", OnRookiePoolContentClosed);
		((GObject)RightInfo.ConfirmBtn).onClick.Add(new EventCallback0(End));
		((GObject)RightInfo.Race).onClick.Set(new EventCallback0(OnShowRaceInfo));
		((GObject)ToEndMask).onClick.Add(new EventCallback0(OnSkipToEnd));
		Transition.SetHook("CanSkip", new TransitionHook(OnCanSkip));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		SharedMessenger.RemoveListener("ROOKIE_POOL_CONTENT_CLOSED", OnRookiePoolContentClosed);
		((GObject)RightInfo.ConfirmBtn).onClick.Remove(new EventCallback0(End));
		((GObject)RightInfo.Race).onClick.Remove(new EventCallback0(OnShowRaceInfo));
		((GObject)ToEndMask).onClick.Remove(new EventCallback0(OnSkipToEnd));
		Transition.ClearHooks();
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("SoldierShowPanel", this);
		instance.Register("SoldierShowPanel.ConfirmBtn", RightInfo.ConfirmBtn);
		if (FGUIManager.Instance.DebrisCompoundPanel != null)
		{
			((GObject)FGUIManager.Instance.DebrisCompoundPanel).visible = false;
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(0f);
		UiAudioManager.Instance.PlayBackgroundSound("SoldierUp");
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierShowPanel", this);
		instance.Unregister("SoldierShowPanel.ConfirmBtn", RightInfo.ConfirmBtn);
		if (FGUIManager.Instance.DebrisCompoundPanel != null)
		{
			((GObject)FGUIManager.Instance.DebrisCompoundPanel).visible = true;
		}
		UiAudioManager.Instance.StopBackgroundSound("SoldierUp");
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		if ((Object)(object)_canvasObject != (Object)null)
		{
			Object.Destroy((Object)(object)_canvasObject);
		}
	}

	private void OnRookiePoolContentClosed()
	{
		IsRookieBonus = true;
	}

	private void OnCanSkip()
	{
		_canSkip = true;
	}

	private void OnSkipToEnd()
	{
		if (!_canSkip)
		{
			return;
		}
		Transition.Stop(true, true);
		List<Transition> list = new List<Transition> { RightInfo.t0, LeftInfo.t0 };
		foreach (Transition item in list)
		{
			if (!item.playing)
			{
				item.Play();
			}
			item.Stop(true, false);
		}
	}

	private void OnTransitionComplete()
	{
		((GObject)ToEndMask).touchable = false;
		PopUnlockedProducts();
	}

	private void OnOpenSkillDetail(GDEAbilityData abilityData, int limit, bool isUnlock)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(((GObject)RightInfo.SkillList).x + ((GObject)RightInfo.SkillList).width / 2f - 40f, ((GObject)RightInfo.SkillList).y + 360f);
		val = ((GObject)RightInfo).LocalToRoot(val, GRoot.inst);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val);
		dictionary.Add("Data", abilityData);
		dictionary.Add("Limit", limit);
		dictionary.Add("State", isUnlock);
		dictionary.Add("GList", RightInfo.SkillList);
		dictionary.Add("IsShow", !GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers().Contains(_soldier.Id));
		dictionary.Add("SortingOrder", 110);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary);
	}

	private void OnShowRaceInfo()
	{
		FGUIManager.Instance.ShowRaceInfo(_soldier.Faction, 2, ((GObject)this).sortingOrder);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		if (HotUpdateProcess.ChannelCode == "tapplay" && IsRookieBonus)
		{
			((TapTapSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapTapSDK]).CreateShortcut();
		}
	}

	private void RenderSoldierInfo()
	{
		Match match = Regex.Match(_soldier.Desc, "(?<=Title:).*(?=#Desc)");
		Match match2 = Regex.Match(_soldier.Desc, "(?<=#Desc:).*");
		((GObject)LeftInfo.Introduction).text = match2.Value;
		((GObject)LeftInfo.Identification).text = match.Value;
		LeftInfo.Rarity.selectedIndex = _soldier.PotentialLevel;
		((GObject)RightInfo.SoldierName).text = _soldier.Name;
		eRace race = RaceHelper.FactionToRaceEnum(_soldier.Faction);
		RenderHelper_RaceTypeIcon.RenderRaceType(RightInfo.Race, race);
	}

	private void RenderSoldierAnimation()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		ref GameObject canvasObject = ref _canvasObject;
		Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
		canvasObject = (GameObject)(object)((obj is GameObject) ? obj : null);
		_canvasObject.GetComponent<Canvas>().sortingLayerName = "Default";
		int potentialLevel = (_soldier.PotentialLevel + 2) / 2;
		SpawnManager.Instance.LoadSoldierSpine(_canvasObject, $"{_soldier.Id}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				SkeletonGraphic component = ((Component)_canvasObject.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
				component.skeletonDataAsset = asset;
				component.initialSkinName = $"skin{potentialLevel}";
				component.Initialize(true);
				component.AnimationState.AddAnimation(0, "idle", false, 0.1f);
				component.AnimationState.AddAnimation(0, "attack", false, 0f);
				component.AnimationState.AddAnimation(0, "idle", true, 0f);
				((Component)_canvasObject.transform.GetChild(0)).gameObject.SetActive(true);
			}
		});
		_canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
		_canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper val = new GoWrapper(_canvasObject);
		((DisplayObject)val).SetXY(0f, 0f);
		((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
		SoldierSpineLoader.Spine.SetNativeObject((DisplayObject)(object)val);
	}

	private void RenderSkillList()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		Dictionary<string, int> dictionary = _soldier.AbilitiesUnlockState();
		List<string> abilityList = _soldier.AbilityList;
		for (int i = 0; i < abilityList.Count; i++)
		{
			if (i != abilityList.Count - 1)
			{
				string text = abilityList[i];
				GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(text);
				if (gDEAbilityData.Visible)
				{
					_skillList.Add(new SkillData
					{
						AbilityId = text,
						GDEData = gDEAbilityData,
						LimitPotentialLevel = dictionary[text],
						IsUnlock = (dictionary[text] <= _soldier.PotentialLevel)
					});
				}
			}
		}
		RightInfo.SkillList.itemRenderer = (ListItemRenderer)delegate(int index, GObject o)
		{
			SkillListItemRender(index, (UI_com_SkillSlot)(object)o);
		};
		RightInfo.SkillList.numItems = _skillList.Count;
	}

	private void SkillListItemRender(int index, UI_com_SkillSlot slot)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		SkillData data = _skillList[index];
		slot.SkillIconLoader.LoadAbilityIcon(data.GDEData.Icon);
		slot.IsUnlock.selectedIndex = (data.IsUnlock ? 1 : 0);
		((GObject)slot.SkillName).text = data.GDEData.Name;
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnOpenSkillDetail(data.GDEData, data.LimitPotentialLevel, data.IsUnlock);
		});
	}

	private void PopUnlockedProducts()
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		for (int i = 0; i < _unlockedProductList.Count; i++)
		{
			UiAudioManager.Instance.PlaySoundEffect("CardsShow");
			UI_equipItem itemBtn = UI_equipItem.CreateInstance();
			((GComponent)this).AddChild((GObject)(object)itemBtn);
			EquipListItemRender(i, itemBtn);
			((GComponent)(object)itemBtn).SetTimeout(0.5f * (float)i).OnComplete((GTweenCallback)delegate
			{
				itemBtn.rising.Play();
			});
		}
	}

	private void EquipListItemRender(int index, UI_equipItem slot)
	{
		string itemId = BuildingManager.Products[_unlockedProductList[index]].ItemId;
		int level = ((Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : Item.Level(GameManagers.Instance, itemId));
		((GObject)slot).SetXY(800f, 500f);
		slot.IconLoader.url = UiHelper.GetIcon(itemId).ToPublicResourceIcon();
		slot.FrameLoader.url = UiHelper.GetIconFrameBorder(2, level).ToPublicResourceIcon();
		((GObject)slot.title).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId);
		((GObject)slot.tip).text = "CsharpCodeZhTcText615".ToLanguage();
		((GObject)slot.IconLoader).alpha = 1f;
		((GObject)slot.FrameLoader).alpha = 1f;
		((GObject)slot.title).alpha = 1f;
		((GObject)slot.tip).alpha = 1f;
		((GObject)slot.SkillGroup).visible = false;
		((GObject)slot).touchable = false;
		((GObject)slot).alpha = 0f;
	}

	public void BeforeDestroy()
	{
	}
}
