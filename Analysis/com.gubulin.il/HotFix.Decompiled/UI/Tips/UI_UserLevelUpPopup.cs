using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using Spine.Unity;
using UnityEngine;

namespace UI.Tips;

public class UI_UserLevelUpPopup : GComponent, IUiController
{
	public GGraph back;

	public UI_UserLevelUpDialog UserLevelUpDialog;

	public Transition showTip;

	public const string URL = "ui://47lbpgx9f3r62v";

	public static string Name = "UI_UserLevelUpPopup";

	private readonly List<string> textureList = new List<string>();

	private const string ui_devil_level_up_light = "ui_devil_level_up_light";

	private const string devil_level_up_fx = "devil_level_up_fx";

	private const string ui_title_spark_stars_explosion = "ui_title_spark_stars_explosion";

	private const string ui_title_spark_stars_loop = "ui_title_spark_stars_loop";

	private List<string> spineList = new List<string>();

	public static string GetURL()
	{
		return "ui://47lbpgx9f3r62v";
	}

	public static UI_UserLevelUpPopup CreateInstance()
	{
		return (UI_UserLevelUpPopup)(object)UIPackage.CreateObject("Tips", "UserLevelUpPopup");
	}

	public static UI_UserLevelUpPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UserLevelUpPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9f3r62v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		UserLevelUpDialog = (UI_UserLevelUpDialog)(object)((GComponent)this).GetChild("UserLevelUpDialog");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiAudioManager.Instance.StopBackgroundSound(UiAudioManager.BgmType.LevelUp);
		UiAudioManager.Instance.StopBackgroundMusic();
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 104;
	}

	private void LoadDecilSpine()
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		GameObject canvasObject1 = default(GameObject);
		ref GameObject reference = ref canvasObject1;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		SpawnManager.Instance.LoadAnimation("devil_level_up").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			if (!((GObject)this).isDisposed)
			{
				spineList.Add("devil_level_up");
				GameObject obj2 = canvasObject1;
				SkeletonAnimation val2 = ((obj2 != null) ? obj2.GetComponent<SkeletonAnimation>() : null);
				if ((Object)(object)val2 != (Object)null && (Object)(object)asset != (Object)null)
				{
					((SkeletonRenderer)val2).skeletonDataAsset = asset;
					((SkeletonRenderer)val2).Initialize(true);
					SpineHelper.SetSkin((ISkeletonAnimation)(object)val2, "default");
					val2.AnimationState.AddAnimation(0, "open", false, 0f);
					val2.AnimationState.AddAnimation(0, "idle", true, 0f);
					FGUIManager.Instance.AddTextSpecialEffects(UserLevelUpDialog.LightSfxBack, "ui_devil_level_up_light", new Vector3(140f, 140f, 140f));
				}
			}
		});
		if ((Object)(object)canvasObject1 != (Object)null)
		{
			canvasObject1.transform.localScale = new Vector3(100f, 100f, 100f);
			canvasObject1.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject1.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(canvasObject1);
			((DisplayObject)val).SetXY(0.5f, 0.5f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			UserLevelUpDialog.SpineBack.SetNativeObject((DisplayObject)(object)val);
		}
	}

	public void OnShow()
	{
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		int userLevel = GameManagers.Instance.UserArchiveManager.GetUserLevel();
		if (!GameManagers.Instance.ConfigDataManager.UserExpData.TryGetValue(userLevel, out var value))
		{
			End();
			return;
		}
		((GObject)UserLevelUpDialog.levelNum).text = string.Format(LanguagesManager.GetDesc("UserLevelUp-LevelText"), new object[1] { userLevel });
		UserLevelUpDialog.bonusList.numItems = 0;
		if (value.BonusList.Count < 1)
		{
			((GObject)UserLevelUpDialog.bonusList).visible = false;
		}
		foreach (Bonus bonus in value.BonusList)
		{
			GButton asButton = UserLevelUpDialog.bonusList.AddItemFromPool().asButton;
			string itemId = bonus.ItemId;
			((GComponent)asButton).GetChild("Content").asCom.GetChild("title").text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId);
			GObject child = ((GComponent)asButton).GetChild("Content").asCom.GetChild("title");
			child.text += $"+{bonus.Qty}";
			GLoader asLoader = ((GComponent)asButton).GetChild("Content").asCom.GetChild("bonusIcon").asLoader;
			int level = ((Shift.Legion.Common.Models.Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemId));
			FGUIManager.Instance.SetItemIconAndFrame(asLoader, itemId, textureList, UiHelper.GetIconFrameBorder(2, level));
			((GObject)asButton).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true, reserveRes: true);
			});
		}
		UserLevelUpDialog.descList.numItems = 0;
		UserLevelUpDialog.Type.selectedIndex = 0;
		List<string> list = new List<string>();
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			string text = $"NewGuideLevelUpText_{userLevel}";
			string desc = LanguagesManager.GetDesc(text);
			if (desc != text)
			{
				list = JsonHelper.ToObject<List<string>>(desc);
			}
		}
		else
		{
			list.AddRange(value.DescList);
		}
		foreach (string item in list)
		{
			GButton asButton2 = UserLevelUpDialog.descList.AddItemFromPool().asButton;
			asButton2.title = item;
		}
		if (UserLevelUpDialog.descList.numItems < 1)
		{
			UserLevelUpDialog.Type.selectedIndex = 1;
			((GObject)UserLevelUpDialog.descTitle).visible = false;
		}
		PlayDevilLevelUp();
	}

	private void PlayDevilLevelUp()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		UserLevelUpDialog.DevilLevelUp.SetHook("step1", new TransitionHook(LoadDecilSpine));
		UserLevelUpDialog.DevilLevelUp.SetHook("step2", new TransitionHook(PlayDevilLevelUpStep2));
		UserLevelUpDialog.DevilLevelUp.SetHook("step3", new TransitionHook(PlayDevilLevelUpStep3));
		UserLevelUpDialog.DevilLevelUp.SetHook("step4", new TransitionHook(PlayDevilLevelUpStep4));
		UserLevelUpDialog.DevilLevelUp.SetHook("step5", new TransitionHook(PlayDevilLevelUpStep5));
		UserLevelUpDialog.DevilLevelUp.SetHook("step6", new TransitionHook(PlayDevilLevelUpStep6));
		UiAudioManager.Instance.PlayBackgroundMusic(UiAudioManager.BgmType.LevelUp, playLoop: false);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		UserLevelUpDialog.DevilLevelUp.Play();
	}

	private void PlayDevilLevelUpStep2()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.AddTextSpecialEffects(UserLevelUpDialog.SfxBack, "devil_level_up_fx", new Vector3(180f, 180f, 180f));
		UiAudioManager.Instance.PlaySoundEffect("BalloonBlast");
		FGUIManager.Instance.AddTextSpecialEffects(UserLevelUpDialog.TitleExplosionSfxBack, "ui_title_spark_stars_explosion", new Vector3(120f, 120f, 120f));
		FGUIManager.Instance.AddTextSpecialEffects(UserLevelUpDialog.TitleLoopSfxBack, "ui_title_spark_stars_loop", new Vector3(120f, 120f, 120f));
		((GObject)UserLevelUpDialog.levelNum).TweenFade(1f, 0.2f);
	}

	private void PlayDevilLevelUpStep3()
	{
		UserLevelUpDialog.ShowDialog.Play();
	}

	private void PlayDevilLevelUpStep4()
	{
		UserLevelUpDialog.ShowBonusIcon.Play();
		int numChildren = ((GComponent)UserLevelUpDialog.bonusList).numChildren;
		for (int i = 0; i < numChildren; i++)
		{
			UI_userLevelUpBonusItem uI_userLevelUpBonusItem = (UI_userLevelUpBonusItem)(object)((GComponent)UserLevelUpDialog.bonusList).GetChildAt(i);
			uI_userLevelUpBonusItem.ShowContent.Play(1, 0.2f * (float)i, (PlayCompleteCallback)null);
		}
	}

	private void PlayDevilLevelUpStep5()
	{
		UserLevelUpDialog.ShowDesc.Play();
		int numChildren = ((GComponent)UserLevelUpDialog.descList).numChildren;
		for (int i = 0; i < numChildren; i++)
		{
			UI_userLevelUpDescItem uI_userLevelUpDescItem = (UI_userLevelUpDescItem)(object)((GComponent)UserLevelUpDialog.descList).GetChildAt(i);
			uI_userLevelUpDescItem.t0.Play(1, 0.2f * (float)i, (PlayCompleteCallback)null);
			uI_userLevelUpDescItem.LevelUpEffect.t0.Play(1, 0.2f * (float)i, (PlayCompleteCallback)null);
		}
	}

	private void PlayDevilLevelUpStep6()
	{
		UserLevelUpDialog.showConfirmBtn.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)UserLevelUpDialog.confirmBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)UserLevelUpDialog.confirmBtn).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		for (int j = 0; j < spineList.Count; j++)
		{
			SpawnManager.Instance.UnloadAnimation(spineList[j]);
		}
		if (GameController.Configs.TryGetValue("EnableCheckReview", out var value) && value == "1")
		{
			CheckReviewPointOnUserLevelUp();
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void CheckReviewPointOnUserLevelUp()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if (((int)Application.platform != 8 && "taptap" != HotUpdateProcess.ChannelCode && "tapplay" != HotUpdateProcess.ChannelCode) || ((HotUpdateProcess.ChannelCode == "taptap" || HotUpdateProcess.ChannelCode == "tapplay") && UiHelper.LoginTypeStr != UserLoginCredentialsType.TapTap.ToString()) || (GameManagers.Instance.UserArchiveManager.TryGetConfigValue<bool>("UserHasReviewed", out var val) && val) || !GameManagers.Instance.UserArchiveManager.CheckUserLevelUpReviewPointEnabled() || !(GameManagers.Instance.UserArchiveManager.TryGetConfigValue<bool>("IsFirstArchive", out var val2) && val2))
		{
			return;
		}
		Task<CheckReviewPointResponse> task = GameController.Contexts.Service<INetworkService>().CheckReviewPoint();
		task.GetAwaiter().OnCompleted(delegate
		{
			CheckReviewPointResponse result = task.Result;
			if (result.Result)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_GoToReviewPopup.Name, null);
			}
		});
	}
}
