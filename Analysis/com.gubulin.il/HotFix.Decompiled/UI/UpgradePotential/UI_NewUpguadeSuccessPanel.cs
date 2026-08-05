using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UnityEngine;

namespace UI.UpgradePotential;

public class UI_NewUpguadeSuccessPanel : GComponent, IUiController
{
	public Controller PageSwitch;

	public GLoader background;

	public UI_dec_Background n82;

	public UI_dec_01 n83;

	public UI_dec_02 n84;

	public GImage n85;

	public GImage n90;

	public UI_dec_light02 n88;

	public UI_PageTitle Victory;

	public UI_dec_light01 n87;

	public UI_BaseSpine BaseSpine;

	public GImage n93;

	public UI_com_SoldierSpine SoldierSpineLoader;

	public UI_dec_light04 n94;

	public UI_BaseMaskSpine BaseMaskSpine;

	public GGraph ToEndMask;

	public UI_UpgradeCard CardCur;

	public UI_UpgradeCard CardNext;

	public UI_SkillHelp ShowSkill;

	public UI_confirmBtn ConfirmBtn;

	public UI_Arrowhead n99;

	public Transition TransitionUpgrade2;

	public Transition TransitionUpgrade1;

	public const string URL = "ui://l5ik1uclpanqt9q";

	public static string Name = "UI_NewUpguadeSuccessPanel";

	private string soldierId;

	private FakeSoldier fakeSoldier;

	private FakeSoldier soldier;

	private readonly List<string> _skillList = new List<string>();

	private bool MythAvailable => Define.SoldierMythUnderDevelopment();

	public static string GetURL()
	{
		return "ui://l5ik1uclpanqt9q";
	}

	public static UI_NewUpguadeSuccessPanel CreateInstance()
	{
		return (UI_NewUpguadeSuccessPanel)(object)UIPackage.CreateObject("UpgradePotential", "NewUpguadeSuccessPanel");
	}

	public static UI_NewUpguadeSuccessPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NewUpguadeSuccessPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l5ik1uclpanqt9q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageSwitch = ((GComponent)this).GetController("PageSwitch");
		background = (GLoader)((GComponent)this).GetChild("background");
		n82 = (UI_dec_Background)(object)((GComponent)this).GetChild("n82");
		n83 = (UI_dec_01)(object)((GComponent)this).GetChild("n83");
		n84 = (UI_dec_02)(object)((GComponent)this).GetChild("n84");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		n88 = (UI_dec_light02)(object)((GComponent)this).GetChild("n88");
		Victory = (UI_PageTitle)(object)((GComponent)this).GetChild("Victory");
		n87 = (UI_dec_light01)(object)((GComponent)this).GetChild("n87");
		BaseSpine = (UI_BaseSpine)(object)((GComponent)this).GetChild("BaseSpine");
		n93 = (GImage)((GComponent)this).GetChild("n93");
		SoldierSpineLoader = (UI_com_SoldierSpine)(object)((GComponent)this).GetChild("SoldierSpineLoader");
		n94 = (UI_dec_light04)(object)((GComponent)this).GetChild("n94");
		BaseMaskSpine = (UI_BaseMaskSpine)(object)((GComponent)this).GetChild("BaseMaskSpine");
		ToEndMask = (GGraph)((GComponent)this).GetChild("ToEndMask");
		CardCur = (UI_UpgradeCard)(object)((GComponent)this).GetChild("CardCur");
		CardNext = (UI_UpgradeCard)(object)((GComponent)this).GetChild("CardNext");
		ShowSkill = (UI_SkillHelp)(object)((GComponent)this).GetChild("ShowSkill");
		ConfirmBtn = (UI_confirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
		n99 = (UI_Arrowhead)(object)((GComponent)this).GetChild("n99");
		TransitionUpgrade2 = ((GComponent)this).GetTransition("TransitionUpgrade2");
		TransitionUpgrade1 = ((GComponent)this).GetTransition("TransitionUpgrade1");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierPotentialUpgradeSuccess.ConfirmBtn", ConfirmBtn);
		instance.Unregister("UpgradeSuccessPanel.FrameLoader", ShowSkill);
		FGUIManager.Instance.UpdateParent(soldierId);
		if (FGUIManager.Instance.DebrisCompoundPanel != null)
		{
			((GObject)FGUIManager.Instance.DebrisCompoundPanel).visible = true;
		}
		if (FGUIManager.Instance.SoldierCultivatePanel != null)
		{
			((GObject)FGUIManager.Instance.SoldierCultivatePanel.backMask).alpha = 0f;
		}
		UiAudioManager.Instance.StopBackgroundSound("SoldierUp");
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		soldier = (FakeSoldier)parameters["Soldier"];
		fakeSoldier = (FakeSoldier)parameters["FakeSoldier"];
		soldierId = soldier.Id;
		((GObject)this).sortingOrder = 106;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)ToEndMask).touchable = true;
		SetLeftDetial();
		SetRightDetial();
		if (fakeSoldier.EvoLevel != soldier.EvoLevel)
		{
			PageSwitch.selectedIndex = 1;
			Victory.PageSwitch.selectedIndex = 1;
			CardCur.PageSwitch.selectedIndex = 1;
			CardNext.PageSwitch.selectedIndex = 1;
			LoadSoldierSpine();
			TransitionUpgrade2.Play((PlayCompleteCallback)delegate
			{
				((GObject)ToEndMask).touchable = false;
				if (!CardNext.ShowProperty1.playing)
				{
					CardNext.ShowProperty1.Play();
				}
				CardNext.ShowProperty1.Stop();
			});
		}
		else
		{
			if (fakeSoldier.PotentialLevel == soldier.PotentialLevel)
			{
				return;
			}
			PageSwitch.selectedIndex = 3;
			Victory.PageSwitch.selectedIndex = 3;
			CardCur.PageSwitch.selectedIndex = 3;
			CardNext.PageSwitch.selectedIndex = 3;
			SetSkill();
			LoadSoldierSpine();
			TransitionUpgrade2.Play((PlayCompleteCallback)delegate
			{
				((GObject)ToEndMask).touchable = false;
				if (!CardNext.ShowProperty2.playing)
				{
					CardNext.ShowProperty2.Play();
				}
				CardNext.ShowProperty2.Stop();
			});
		}
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("SoldierPotentialUpgradeSuccess.ConfirmBtn", ConfirmBtn);
		instance.Register("UpgradeSuccessPanel.FrameLoader", ShowSkill);
		UiAudioManager.Instance.SetMainCityBgmVolume(0f);
		UiAudioManager.Instance.PlayBackgroundSound("SoldierUp");
		ScriptApi.CreateTimer(1f, delegate
		{
			FGUIManager.Instance.OnSoldierChanged(soldier, fakeSoldier);
		});
		if (FGUIManager.Instance.DebrisCompoundPanel != null)
		{
			((GObject)FGUIManager.Instance.DebrisCompoundPanel).visible = false;
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)ToEndMask).onClick.Add(new EventCallback0(DirectlyToPotentialEnd));
		((GObject)ConfirmBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)ToEndMask).onClick.Remove(new EventCallback0(DirectlyToPotentialEnd));
		((GObject)ConfirmBtn).onClick.Remove(new EventCallback0(End));
	}

	private void DirectlyToPotentialEnd()
	{
		if (TransitionUpgrade1.playing)
		{
			TransitionUpgrade1.Stop(true, true);
		}
		if (TransitionUpgrade2.playing)
		{
			TransitionUpgrade2.Stop(true, true);
		}
	}

	private void SetLeftDetial()
	{
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		FakeSoldier fakeSoldier = this.fakeSoldier;
		string text = fakeSoldier.CombatPower.ToString();
		((GObject)CardCur.curFight1).text = text;
		((GObject)CardCur.curFight2).text = text;
		string text2 = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(fakeSoldier.Attack).ToString());
		((GObject)CardCur.curAttack1).text = text2;
		((GObject)CardCur.curAttack2).text = text2;
		string text3 = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(fakeSoldier.Defense).ToString());
		((GObject)CardCur.curDeffense1).text = text3;
		((GObject)CardCur.curDeffense2).text = text3;
		string text4 = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(fakeSoldier.Health).ToString());
		((GObject)CardCur.curHealth1).text = text4;
		((GObject)CardCur.curHealth2).text = text4;
		string text5 = fakeSoldier.MaxLevel.ToString();
		((GObject)CardCur.curLevel1).text = text5;
		CardCur.Type.selectedIndex = fakeSoldier.PotentialLevel;
		UI_armItem soldierIcon = CardCur.SoldierIcon;
		soldierIcon.level.Level.selectedIndex = fakeSoldier.PotentialLevel;
		if (fakeSoldier.PotentialLevel == 8)
		{
			((GObject)soldierIcon.level.n24).visible = MythAvailable;
			((GObject)soldierIcon.level.n11).visible = !MythAvailable;
		}
		Color32 colorByLevel = UiHelper.GetColorByLevel(fakeSoldier.PotentialLevel);
		if (fakeSoldier.PotentialLevel >= 8)
		{
			soldierIcon.Level.selectedIndex = 1;
			((GObject)soldierIcon.title_Max).text = fakeSoldier.Name;
			((GTextField)soldierIcon.title_Max).color = Color32.op_Implicit(colorByLevel);
		}
		else
		{
			soldierIcon.Level.selectedIndex = 0;
			((GObject)soldierIcon.title).text = fakeSoldier.Name;
			((GTextField)soldierIcon.title).color = Color32.op_Implicit(colorByLevel);
		}
		int itemLevel = (fakeSoldier.PotentialLevel + 2) / 2;
		((GObject)soldierIcon.icon).asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(fakeSoldier.Id, itemLevel);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(fakeSoldier.PotentialLevel);
		((GObject)soldierIcon.iconFrame).asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)soldierIcon.iconFrame).asLoader, fakeSoldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(soldierIcon.SoulStoneLevel, fakeSoldier.PotentialLevel, fakeSoldier.PotentialProgress);
	}

	private void SetRightDetial()
	{
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		FakeSoldier fakeSoldier = soldier;
		string text = fakeSoldier.CombatPower.ToString();
		((GObject)CardNext.nextFight1).text = text;
		((GObject)CardNext.nextFight2).text = text;
		string text2 = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(fakeSoldier.Attack).ToString());
		((GObject)CardNext.nextAttack1).text = text2;
		((GObject)CardNext.nextAttack2).text = text2;
		string text3 = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(fakeSoldier.Defense).ToString());
		((GObject)CardNext.nextDeffense1).text = text3;
		((GObject)CardNext.nextDeffense2).text = text3;
		string text4 = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(fakeSoldier.Health).ToString());
		((GObject)CardNext.nextHealth1).text = text4;
		((GObject)CardNext.nextHealth2).text = text4;
		string text5 = fakeSoldier.MaxLevel.ToString();
		((GObject)CardNext.nextLevel1).text = text5;
		CardNext.Type.selectedIndex = fakeSoldier.PotentialLevel;
		UI_armItem soldierIcon = CardNext.SoldierIcon;
		soldierIcon.level.Level.selectedIndex = fakeSoldier.PotentialLevel;
		if (fakeSoldier.PotentialLevel == 8)
		{
			((GObject)soldierIcon.level.n24).visible = MythAvailable;
			((GObject)soldierIcon.level.n11).visible = !MythAvailable;
		}
		Color32 colorByLevel = UiHelper.GetColorByLevel(fakeSoldier.PotentialLevel);
		if (fakeSoldier.PotentialLevel >= 8)
		{
			soldierIcon.Level.selectedIndex = 1;
			((GObject)soldierIcon.title_Max).text = fakeSoldier.Name;
			((GTextField)soldierIcon.title_Max).color = Color32.op_Implicit(colorByLevel);
		}
		else
		{
			soldierIcon.Level.selectedIndex = 0;
			((GObject)soldierIcon.title).text = fakeSoldier.Name;
			((GTextField)soldierIcon.title).color = Color32.op_Implicit(colorByLevel);
		}
		int itemLevel = (fakeSoldier.PotentialLevel + 2) / 2;
		((GObject)soldierIcon.icon).asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(fakeSoldier.Id, itemLevel);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(fakeSoldier.PotentialLevel);
		((GObject)soldierIcon.iconFrame).asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)soldierIcon.iconFrame).asLoader, fakeSoldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(soldierIcon.SoulStoneLevel, fakeSoldier.PotentialLevel, fakeSoldier.PotentialProgress);
	}

	private void SetSkill()
	{
		Dictionary<string, int> dictionary = soldier.AbilitiesUnlockState();
		_skillList.Clear();
		for (int i = 0; i < soldier.AbilityList.Count; i++)
		{
			if (GDMgr.TryGetWithErrorHandling<GDEAbilityData>(soldier.AbilityList[i]).Visible)
			{
				_skillList.Add(soldier.AbilityList[i]);
			}
		}
		((GObject)ShowSkill).visible = false;
		for (int j = 0; j < _skillList.Count; j++)
		{
			if (dictionary[_skillList[j]] == soldier.PotentialLevel)
			{
				GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(_skillList[j]);
				ShowSkill.skillIcon.LoadAbilityIcon(gDEAbilityData.Icon);
				((GObject)ShowSkill.skillIntorduction.skillIntorduction).text = Singleton<AbilityDataManager>.Instance.GetDescription(gDEAbilityData.Key);
				((GObject)ShowSkill).visible = true;
				break;
			}
		}
	}

	private void LoadSoldierSpine()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		GameObject canvasObject = default(GameObject);
		ref GameObject reference = ref canvasObject;
		Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		canvasObject.GetComponent<Canvas>().sortingLayerName = "Default";
		SpawnManager.Instance.LoadSoldierSpine(canvasObject, $"{soldier.Id}_skin{soldier.CurrentSpineSkinId}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				SkeletonGraphic component = ((Component)canvasObject.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
				component.skeletonDataAsset = asset;
				component.initialSkinName = $"skin{soldier.CurrentSpineSkinId}";
				component.Initialize(true);
				component.AnimationState.AddAnimation(0, "idle", false, 0.1f);
				component.AnimationState.AddAnimation(0, "attack", false, 0f);
				component.AnimationState.AddAnimation(0, "idle", true, 0f);
				((Component)canvasObject.transform.GetChild(0)).gameObject.SetActive(true);
			}
		});
		canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
		canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper val = new GoWrapper(canvasObject);
		((DisplayObject)val).SetXY(0f, 0f);
		((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
		SoldierSpineLoader.Spine.SetNativeObject((DisplayObject)(object)val);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
