using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.PushGiftBag;
using UI.WarOrder;
using UnityEngine;

namespace UI.MainCity;

public class UI_PushGiftBtn : GButton, IUiController
{
	public Controller button;

	public GImage n3;

	public GRichTextField Content;

	public GTextField countdown;

	public GGraph SpineBack;

	public GGraph SfxBack;

	public const string URL = "ui://j611zmymdecwv43c";

	public static string Name = "UI_PushGiftBtn";

	private GameObject ui_explosion_smoke_white;

	private SkeletonAnimation MerchantAnimation;

	private Coroutine TimeLimitRemainingCoroutine;

	private Coroutine UpdateEntryStateCoroutine;

	private float Hourglass;

	private bool IsAnimationLoaded;

	private bool _ignoreActivityMessage;

	public static string GetURL()
	{
		return "ui://j611zmymdecwv43c";
	}

	public static UI_PushGiftBtn CreateInstance()
	{
		return (UI_PushGiftBtn)(object)UIPackage.CreateObject("MainCity", "PushGiftBtn");
	}

	public static UI_PushGiftBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PushGiftBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymdecwv43c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Content = (GRichTextField)((GComponent)this).GetChild("Content");
		string id = "ui://j611zmymdecwv43c".Replace("ui://", "") + "-" + ((GObject)Content).id;
		((GObject)Content).text = LanguagesManager.GetDesc(id);
		countdown = (GTextField)((GComponent)this).GetChild("countdown");
		string id2 = "ui://j611zmymdecwv43c".Replace("ui://", "") + "-" + ((GObject)countdown).id;
		((GObject)countdown).text = LanguagesManager.GetDesc(id2);
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
		SharedMessenger.AddListener<Cache_WarOrderState>(Cache_WarOrderState.ON_CERT_CHANGE, OnChangeWarOrderCert);
		SharedMessenger.AddListener("ON_PUSH_GIFT_BAG_REFRESH", UpdateEntryState);
		SharedMessenger.AddListener<bool>("ON_PUSH_GIFT_BAG_REFRESH_EXT", OnPushGiftBagExt);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)this).onClick.Clear();
		SharedMessenger.RemoveListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
		SharedMessenger.RemoveListener<Cache_WarOrderState>(Cache_WarOrderState.ON_CERT_CHANGE, OnChangeWarOrderCert);
		SharedMessenger.RemoveListener("ON_PUSH_GIFT_BAG_REFRESH", UpdateEntryState);
		SharedMessenger.RemoveListener<bool>("ON_PUSH_GIFT_BAG_REFRESH_EXT", OnPushGiftBagExt);
	}

	public void Init(Dictionary<string, object> parameters = null)
	{
		((GObject)this).visible = false;
		IsAnimationLoaded = false;
		UpdateEntryState();
	}

	private IEnumerator SetupPushBag()
	{
		SetAnimation("skin1", 0, "idle", loop: false, 0f, RefreshPushGiftRemainingTime());
		if (!((GObject)this).isDisposed)
		{
			((GObject)this).onClick.Set(new EventCallback0(OpenPushBagPanel));
			((GObject)Content).text = FGUIManager.Instance.NewPushStoreItem.Name ?? "";
			((GObject)countdown).text = "";
			if (FGUIManager.Instance.curPushGiftBagActivity != null && FGUIManager.Instance.curPushGiftBagActivity.HasAnyNewMsg(GameManagers.Instance))
			{
				yield return (object)new WaitForSeconds(1f);
				OpenPushBagPanel();
			}
			else if (_ignoreActivityMessage)
			{
				yield return (object)new WaitForSeconds(0.3f);
				OpenPushBagPanel();
			}
			_ignoreActivityMessage = false;
		}
	}

	private void SetupWarOrder()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		SetAnimation("skin1", 0, "idle-ordergift", loop: true, 0f, RefreshWarOrderRemainingTime());
		if (!((GObject)this).isDisposed)
		{
			((GObject)this).onClick.Set(new EventCallback0(OpenWarOrderPanel));
			((GObject)Content).text = " [color=#7d18a4][size=44]" + LanguagesManager.GetDesc("CsharpCodeZhTcText426") + "[/size][/color] " + LanguagesManager.GetDesc("CsharpCodeZhTcText427") + "！";
			((GObject)countdown).text = "";
		}
	}

	private void SetAnimation(string skin, int trackIndex, string animationName, bool loop, float delay, IEnumerator func)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)this).isDisposed)
		{
			return;
		}
		if (!IsAnimationLoaded)
		{
			IsAnimationLoaded = true;
			GameObject merchantSpineObject = default(GameObject);
			ref GameObject reference = ref merchantSpineObject;
			Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
			reference = (GameObject)(object)((obj is GameObject) ? obj : null);
			SpawnManager.Instance.LoadAnimation("merchant_UI").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				if (!((GObject)this).isDisposed)
				{
					GameObject obj2 = merchantSpineObject;
					SkeletonAnimation val2 = ((obj2 != null) ? obj2.GetComponent<SkeletonAnimation>() : null);
					if ((Object)(object)val2 != (Object)null && (Object)(object)asset != (Object)null)
					{
						MerchantAnimation = val2;
						((SkeletonRenderer)MerchantAnimation).skeletonDataAsset = asset;
						((SkeletonRenderer)MerchantAnimation).Initialize(true);
						SpineHelper.SetSkin((ISkeletonAnimation)(object)MerchantAnimation, skin);
						MerchantAnimation.AnimationState.AddAnimation(trackIndex, animationName, loop, delay);
						if (TimeLimitRemainingCoroutine == null)
						{
							TimeLimitRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(func);
						}
					}
				}
			});
			if ((Object)(object)merchantSpineObject != (Object)null)
			{
				merchantSpineObject.transform.localScale = new Vector3(35f, 35f, 35f);
				merchantSpineObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
				merchantSpineObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
				GoWrapper val = new GoWrapper(merchantSpineObject);
				((DisplayObject)val).SetXY(0f, 0f);
				((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
				((DisplayObject)val).scaleX = 1f;
				SpineBack.SetNativeObject((DisplayObject)(object)val);
			}
		}
		else if ((Object)(object)MerchantAnimation != (Object)null)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)MerchantAnimation, skin);
			MerchantAnimation.AnimationState.SetAnimation(trackIndex, animationName, loop);
			if (TimeLimitRemainingCoroutine != null)
			{
				FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
				TimeLimitRemainingCoroutine = null;
			}
			TimeLimitRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(func);
		}
	}

	public void UpdateEntryState()
	{
		if (UpdateEntryStateCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UpdateEntryStateCoroutine);
			UpdateEntryStateCoroutine = null;
		}
		UpdateEntryStateCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(CoroutineUpdateEntryState());
	}

	private void OnPushGiftBagExt(bool forceShowBag)
	{
		if (forceShowBag)
		{
			_ignoreActivityMessage = true;
		}
		UpdateEntryState();
	}

	private IEnumerator CoroutineUpdateEntryState()
	{
		Task<bool> task = FGUIManager.Instance.GetPushGiftBagAndSort();
		while (!task.IsCompleted)
		{
			yield return null;
		}
		if (task.Result && FGUIManager.Instance.NewPushStoreItem != null && FGUIManager.Instance.NewPushStoreItem.ExpireTimestamp - (int)GameController.Instance.GetServerTime() > 0)
		{
			yield return SetupPushBag();
			if (!((GObject)this).isDisposed)
			{
				((GObject)this).visible = true;
			}
		}
		else if (!((GObject)this).isDisposed)
		{
			((GObject)this).visible = false;
		}
	}

	private IEnumerator RefreshPushGiftRemainingTime()
	{
		while (true)
		{
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			if (Hourglass >= 11.3f)
			{
				Hourglass = 0f;
			}
			if (Hourglass == 0f && (Object)(object)MerchantAnimation != (Object)null)
			{
				MerchantAnimation.AnimationName = "idle";
			}
			if (Hourglass >= 9.8f && (Object)(object)MerchantAnimation != (Object)null && (Object)(object)ui_explosion_smoke_white == (Object)null)
			{
				FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_explosion_smoke_white", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject obj)
				{
					//IL_0022: Unknown result type (might be due to invalid IL or missing references)
					ui_explosion_smoke_white = obj;
					ui_explosion_smoke_white.transform.localPosition = new Vector3(0f, 0f, -0.5f);
					ui_explosion_smoke_white.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
				});
			}
			if (Hourglass >= 10f && (Object)(object)MerchantAnimation != (Object)null && MerchantAnimation.AnimationName != "work")
			{
				MerchantAnimation.AnimationName = "work";
			}
			if (Hourglass >= 11f)
			{
				if ((Object)(object)MerchantAnimation != (Object)null && (Object)(object)ui_explosion_smoke_white == (Object)null)
				{
					FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_explosion_smoke_white", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject obj)
					{
						//IL_0022: Unknown result type (might be due to invalid IL or missing references)
						ui_explosion_smoke_white = obj;
						ui_explosion_smoke_white.transform.localPosition = new Vector3(0f, 0f, -0.5f);
						ui_explosion_smoke_white.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
					});
				}
				else
				{
					ui_explosion_smoke_white.GetComponent<ParticleSystem>().Play();
				}
			}
			if (FGUIManager.Instance.NewPushStoreItem == null)
			{
				break;
			}
			bool limitTime = false;
			int remainingTime = 0;
			if (FGUIManager.Instance.NewPushStoreItem.ExpireTimestamp > 0)
			{
				limitTime = true;
				remainingTime = FGUIManager.Instance.NewPushStoreItem.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
			}
			else if (FGUIManager.Instance.NewPushStoreItem.ValidTime > 0)
			{
				remainingTime = GameManagers.Instance.StoreManager.GetLimitTimeMerchandiseRemainingTime(FGUIManager.Instance.curPushGiftBagActivity.ActivityId, FGUIManager.Instance.NewPushStoreItem.StoreItemId);
			}
			if (limitTime)
			{
				if (remainingTime >= 0)
				{
					((GObject)countdown).text = GetRemainTimeDes(remainingTime);
				}
				else
				{
					((GObject)countdown).text = LanguagesManager.GetDesc("CsharpCodeZhTcText425");
				}
			}
			else
			{
				((GObject)countdown).text = "";
			}
			Hourglass += 0.1f;
			yield return (object)new WaitForSeconds(0.1f);
		}
		TimeLimitRemainingCoroutine = null;
	}

	public static string GetRemainTimeDes(int timeStamp)
	{
		string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText428");
		string text = UiHelper.ParseTimeChinsesDH(timeStamp);
		if (desc.Contains("{0}"))
		{
			return string.Format(desc, text);
		}
		return text + desc;
	}

	private IEnumerator RefreshWarOrderRemainingTime()
	{
		while (true)
		{
			int remainingTime = CacheManager.Instance.Get<Cache_WarOrderState>().RemainingTime;
			((GObject)countdown).text = UiHelper.ParseTimeChinsesDH(remainingTime) + LanguagesManager.GetDesc("CsharpCodeZhTcText176");
			yield return (object)new WaitForSeconds(1f);
		}
	}

	private void OpenPushBagPanel()
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PushGiftBagPanel.Name, new Dictionary<string, object>
			{
				{ "Parent", this },
				{ "SortingOrder", 998 }
			});
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
		}
	}

	private void OpenWarOrderPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_WarOrderPanel.Name, null);
	}

	private void OnLimitTimeMerchandiseExpired(string storeItemId)
	{
		UpdateEntryState();
	}

	private void OnChangeWarOrderCert(Cache_WarOrderState cache)
	{
		UpdateEntryState();
	}

	public void Destroy()
	{
	}

	public void BeforeDestroy()
	{
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
	}

	public void OnShow()
	{
	}
}
