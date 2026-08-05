using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.UnlockSoldierShow;

public class UI_SoldierShowPanel : GComponent, IUiController
{
	public Controller pageSwitch;

	public Controller Rarity;

	public GLoader background;

	public GImage n71;

	public GImage n72;

	public GImage n70;

	public GGraph mask;

	public GComponent victoryLight;

	public GGraph VictorySfx;

	public GImage n58;

	public GImage n59;

	public GLoader Victory;

	public GGroup TIpGroup;

	public UI_confirmBtn confirmBtn;

	public GList equipList;

	public GGroup RightGroup;

	public GGraph textBack;

	public GLoader infoBack;

	public GTextField identification;

	public GGraph TextLine;

	public GRichTextField introduction;

	public GGroup introductionGroup;

	public UI_PotentialBack PotentialBack;

	public GRichTextField title;

	public GGroup nameGroup;

	public GComponent SoldierCardRarityIcon;

	public GGroup LeftGroup;

	public GGraph baseSpine;

	public GGraph spine;

	public GGraph maskSpine;

	public GGroup MiddleGroup;

	public GGraph toEndMask;

	public Transition showpage0;

	public Transition showLeft;

	public Transition showBtn;

	public Transition showRight;

	public const string URL = "ui://ia1am3ehgf0n0";

	public static string Name = "UI_SoldierShowPanel";

	private string uiTitleAnimName = "ui_title_lightray_rotate";

	private readonly List<Transition> equipsTran = new List<Transition>();

	private int playEquipsNum;

	private Soldier soldier;

	private string soldierId;

	private List<string> unlockedProductList = new List<string>();

	private readonly Color32[] soldierColor = (Color32[])(object)new Color32[3]
	{
		new Color32((byte)65, (byte)68, (byte)85, byte.MaxValue),
		new Color32((byte)77, (byte)65, (byte)85, byte.MaxValue),
		new Color32((byte)83, (byte)49, (byte)32, byte.MaxValue)
	};

	private List<string> textureList = new List<string>();

	private bool toUnloadAni;

	private bool openByContract;

	private readonly List<KeyValuePair<string, bool>> _skillList = new List<KeyValuePair<string, bool>>();

	private Dictionary<string, int> skillState = new Dictionary<string, int>();

	private int skillNameMaxLength;

	public static string GetURL()
	{
		return "ui://ia1am3ehgf0n0";
	}

	public static UI_SoldierShowPanel CreateInstance()
	{
		return (UI_SoldierShowPanel)(object)UIPackage.CreateObject("UnlockSoldierShow", "SoldierShowPanel");
	}

	public static UI_SoldierShowPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierShowPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehgf0n0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		pageSwitch = ((GComponent)this).GetController("pageSwitch");
		Rarity = ((GComponent)this).GetController("Rarity");
		background = (GLoader)((GComponent)this).GetChild("background");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		n72 = (GImage)((GComponent)this).GetChild("n72");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		victoryLight = (GComponent)((GComponent)this).GetChild("victoryLight");
		VictorySfx = (GGraph)((GComponent)this).GetChild("VictorySfx");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		Victory = (GLoader)((GComponent)this).GetChild("Victory");
		TIpGroup = (GGroup)((GComponent)this).GetChild("TIpGroup");
		confirmBtn = (UI_confirmBtn)(object)((GComponent)this).GetChild("confirmBtn");
		equipList = (GList)((GComponent)this).GetChild("equipList");
		RightGroup = (GGroup)((GComponent)this).GetChild("RightGroup");
		textBack = (GGraph)((GComponent)this).GetChild("textBack");
		infoBack = (GLoader)((GComponent)this).GetChild("infoBack");
		identification = (GTextField)((GComponent)this).GetChild("identification");
		TextLine = (GGraph)((GComponent)this).GetChild("TextLine");
		introduction = (GRichTextField)((GComponent)this).GetChild("introduction");
		introductionGroup = (GGroup)((GComponent)this).GetChild("introductionGroup");
		PotentialBack = (UI_PotentialBack)(object)((GComponent)this).GetChild("PotentialBack");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://ia1am3ehgf0n0".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		nameGroup = (GGroup)((GComponent)this).GetChild("nameGroup");
		SoldierCardRarityIcon = (GComponent)((GComponent)this).GetChild("SoldierCardRarityIcon");
		LeftGroup = (GGroup)((GComponent)this).GetChild("LeftGroup");
		baseSpine = (GGraph)((GComponent)this).GetChild("baseSpine");
		spine = (GGraph)((GComponent)this).GetChild("spine");
		maskSpine = (GGraph)((GComponent)this).GetChild("maskSpine");
		MiddleGroup = (GGroup)((GComponent)this).GetChild("MiddleGroup");
		toEndMask = (GGraph)((GComponent)this).GetChild("toEndMask");
		showpage0 = ((GComponent)this).GetTransition("showpage0");
		showLeft = ((GComponent)this).GetTransition("showLeft");
		showBtn = ((GComponent)this).GetTransition("showBtn");
		showRight = ((GComponent)this).GetTransition("showRight");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 110;
		UiHelper.LoadSpine_AB(VictorySfx, uiTitleAnimName, 100f, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "ui_title_lightray_rotate_yellow", true);
		});
		soldierId = (string)parameters["SoldierId"];
		unlockedProductList = (List<string>)parameters["UnlockedProductList"];
		GetSoldierInfo(soldierId);
		pageSwitch.selectedIndex = 0;
		SetItemShow();
		RenderEquipList();
		ShowSoldierImage(soldierId);
		((GComponent)this).GetChild("MiddleGroup").SetXY(((GComponent)this).GetChild("MiddleGroup").x, 605f);
		((GObject)((GComponent)this).GetChild("LeftGroup").asGroup).alpha = 0f;
		((GObject)((GObject)confirmBtn).asButton).alpha = 0f;
		((GObject)equipList).alpha = 0f;
		((GObject)((GObject)confirmBtn).asButton).touchable = false;
		((GObject)toEndMask).touchable = true;
		PlayTrans();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)confirmBtn).onClick.Add(new EventCallback0(End));
		((GObject)toEndMask).onClick.Add(new EventCallback0(DirectlyToEnd));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)confirmBtn).onClick.Remove(new EventCallback0(End));
		((GObject)toEndMask).onClick.Remove(new EventCallback0(DirectlyToEnd));
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		SpawnManager.Instance.UnloadAnimation(uiTitleAnimName);
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierShowPanel", this);
		instance.Unregister("SoldierShowPanel.ConfirmBtn", confirmBtn);
		if (FGUIManager.Instance.DebrisCompoundPanel != null)
		{
			((GObject)FGUIManager.Instance.DebrisCompoundPanel).visible = true;
		}
		UiAudioManager.Instance.StopBackgroundSound("SoldierUp");
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("SoldierShowPanel", this);
		instance.Register("SoldierShowPanel.ConfirmBtn", confirmBtn);
		if (FGUIManager.Instance.DebrisCompoundPanel != null)
		{
			((GObject)FGUIManager.Instance.DebrisCompoundPanel).visible = false;
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(0f);
		UiAudioManager.Instance.PlayBackgroundSound("SoldierUp");
	}

	private void End()
	{
		playEquipsNum = 0;
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void SkillListItemRender(int index, GObject obj)
	{
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		GDEAbilityData abilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(_skillList[index].Key);
		((GComponent)asButton).GetChild("SkillIconLoader").asLoader.LoadAbilityIcon(abilityData.Icon);
		if (_skillList[index].Value)
		{
			((GComponent)asButton).GetChild("SkillIconLoader").grayed = false;
			((GComponent)asButton).GetChild("frameImage").grayed = false;
			((GComponent)asButton).GetChild("tip").text = LanguagesManager.GetDesc("CsharpCodeZhTcText615");
		}
		else
		{
			((GComponent)asButton).GetChild("SkillIconLoader").grayed = true;
			((GComponent)asButton).GetChild("frameImage").grayed = true;
			((GComponent)asButton).GetChild("tip").text = LanguagesManager.GetDesc("CsharpCodeZhTcText616");
		}
		asButton.title = abilityData.Name ?? "";
		if (asButton.title.Length < skillNameMaxLength)
		{
			int num = skillNameMaxLength - asButton.title.Length;
			for (int i = 0; i < num; i++)
			{
				asButton.title += "  ";
			}
		}
		((GObject)asButton).data = new KeyValuePair<GDEAbilityData, bool>(abilityData, value: true);
		bool isShow = !GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers().Contains(soldier.Id);
		int limit = skillState[_skillList[index].Key];
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			SkillDetailPopup(abilityData, limit, _skillList[index].Value, isShow);
		});
	}

	private void EquipListItemRender(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		string itemId = BuildingManager.Products[unlockedProductList[index]].ItemId;
		((GComponent)asButton).GetChild("IconLoader").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		int level = ((Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : Item.Level(GameManagers.Instance, itemId));
		((GComponent)asButton).GetChild("FrameLoader").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, level);
		asButton.title = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId);
		((GComponent)asButton).GetChild("IconLoader").alpha = 1f;
		((GComponent)asButton).GetChild("FrameLoader").alpha = 1f;
		((GObject)((GComponent)asButton).GetChild("title").asTextField).alpha = 1f;
		((GComponent)asButton).GetChild("Select").alpha = 1f;
		((GComponent)asButton).GetChild("tip").alpha = 1f;
		((GComponent)asButton).GetChild("tip").text = LanguagesManager.GetDesc("CsharpCodeZhTcText615");
		((GObject)asButton).touchable = false;
		((GComponent)asButton).GetChild("SkillGroup").visible = false;
		playEquipsNum = 0;
		((GObject)asButton).alpha = 0f;
		equipsTran.Add(((GComponent)asButton).GetTransition("rising"));
	}

	private void GetSoldierInfo(string soldierId)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		((GObject)title).text = soldier.Name;
		Match match = Regex.Match(soldier.Desc, "(?<=Title:).*(?=#Desc)");
		Match match2 = Regex.Match(soldier.Desc, "(?<=#Desc:).*");
		((GObject)introduction).text = match2.Value;
		((GObject)identification).text = match.Value;
		if (soldier.PotentialLevel > 3)
		{
			textBack.color = Color32.op_Implicit(soldierColor[2]);
		}
		else if (soldier.PotentialLevel > 3)
		{
			textBack.color = Color32.op_Implicit(soldierColor[1]);
		}
		else
		{
			textBack.color = Color32.op_Implicit(soldierColor[0]);
		}
	}

	private void ShowSoldierImage(string sid)
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		soldier = GameManagers.Instance.SoldierManager.Get(sid);
		GameObject canvasObject1 = default(GameObject);
		ref GameObject reference = ref canvasObject1;
		Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		canvasObject1.GetComponent<Canvas>().sortingLayerName = "Default";
		int potentialLevel = (soldier.PotentialLevel + 2) / 2;
		SpawnManager.Instance.LoadSoldierSpine(canvasObject1, $"{soldier.Id}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				toUnloadAni = true;
				SkeletonGraphic component = ((Component)canvasObject1.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
				component.skeletonDataAsset = asset;
				component.initialSkinName = $"skin{potentialLevel}";
				component.Initialize(true);
				component.AnimationState.AddAnimation(0, "idle", false, 0.1f);
				component.AnimationState.AddAnimation(0, "attack", false, 0f);
				component.AnimationState.AddAnimation(0, "idle", true, 0f);
				((Component)canvasObject1.transform.GetChild(0)).gameObject.SetActive(true);
			}
		});
		canvasObject1.transform.localPosition = -new Vector3(0f, 0f, 0f);
		canvasObject1.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper val = new GoWrapper(canvasObject1);
		((DisplayObject)val).SetXY(0f, 0f);
		((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
		spine.SetNativeObject((DisplayObject)(object)val);
		PotentialBack.PageController.selectedIndex = soldier.PotentialLevel;
		SoldierCardRarityIcon.GetController("Level").selectedIndex = soldier.PotentialLevel;
		Rarity.selectedIndex = soldier.PotentialLevel;
		FGUIManager.Instance.AddTextSpecialEffects(baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f));
		FGUIManager.Instance.AddTextSpecialEffects(maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f));
	}

	private void DirectlyToEnd()
	{
		if (pageSwitch.selectedIndex != 1)
		{
			pageSwitch.selectedIndex = 1;
		}
		if (showpage0.playing)
		{
			showpage0.Stop();
		}
		if (showLeft.playing)
		{
			showLeft.Stop();
		}
		if (showBtn.playing)
		{
			showBtn.Stop();
		}
		if (showRight.playing)
		{
			showRight.Stop();
		}
		((GObject)equipList).alpha = 1f;
		((GObject)LeftGroup).alpha = 1f;
		((GObject)confirmBtn).alpha = 1f;
		((GObject)((GObject)confirmBtn).asButton).touchable = true;
		((GObject)toEndMask).touchable = false;
	}

	public void SkillDetailPopup(GDEAbilityData abilityData, int limit, bool isUnlock, bool isShow)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(((GObject)equipList).x + ((GObject)equipList).width / 2f - 40f, ((GObject)equipList).y + 360f);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val);
		dictionary.Add("Data", abilityData);
		dictionary.Add("Limit", limit);
		dictionary.Add("State", isUnlock);
		dictionary.Add("GList", equipList);
		dictionary.Add("IsShow", isShow);
		dictionary.Add("SortingOrder", 110);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary);
	}

	private void RenderEquipList()
	{
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		skillState.Clear();
		skillState = soldier.AbilitiesUnlockState();
		_skillList.Clear();
		for (int i = 0; i < soldier.AbilityList.Count; i++)
		{
			if (i == soldier.AbilityList.Count - 1)
			{
				continue;
			}
			GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(soldier.AbilityList[i]);
			if (gDEAbilityData.Visible)
			{
				bool value = skillState[soldier.AbilityList[i]] <= soldier.PotentialLevel;
				_skillList.Add(new KeyValuePair<string, bool>(soldier.AbilityList[i], value));
				if (gDEAbilityData.Name.Length > skillNameMaxLength)
				{
					skillNameMaxLength = gDEAbilityData.Name.Length;
				}
			}
		}
		equipList.itemRenderer = new ListItemRenderer(SkillListItemRender);
		equipList.numItems = _skillList.Count;
	}

	private void PlayEquipItemTrans()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		if (equipsTran.Count > 0)
		{
			equipsTran[playEquipsNum].Play();
			UiAudioManager.Instance.PlaySoundEffect("CardsShow");
			((GComponent)(object)this).SetTimeout(0.5f).OnComplete(new GTweenCallback(ContinuePlay));
		}
	}

	private void ContinuePlay()
	{
		if (playEquipsNum < equipsTran.Count - 1)
		{
			playEquipsNum++;
			PlayEquipItemTrans();
		}
	}

	private void SetItemShow()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		equipsTran.Clear();
		Vector2 val = default(Vector2);
		for (int i = 0; i < unlockedProductList.Count; i++)
		{
			UI_equipItem uI_equipItem = UI_equipItem.CreateInstance();
			((GComponent)this).AddChild((GObject)(object)uI_equipItem);
			((Vector2)(ref val))._002Ector(800f, 500f);
			((GObject)uI_equipItem).SetXY(val.x, val.y);
			((GObject)uI_equipItem).touchable = false;
			EquipListItemRender(i, (GObject)(object)uI_equipItem);
		}
	}

	private void PlayTrans()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		showpage0.Play((PlayCompleteCallback)delegate
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			pageSwitch.selectedIndex = 1;
			showLeft.Play((PlayCompleteCallback)delegate
			{
				//IL_000e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0018: Expected O, but got Unknown
				showRight.Play((PlayCompleteCallback)delegate
				{
					//IL_0015: Unknown result type (might be due to invalid IL or missing references)
					//IL_001f: Expected O, but got Unknown
					PlayEquipItemTrans();
					showBtn.Play((PlayCompleteCallback)delegate
					{
						((GObject)((GObject)confirmBtn).asButton).touchable = true;
						((GObject)toEndMask).touchable = false;
					});
				});
			});
		});
	}
}
