using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.PushGiftBag;
using UnityEngine;

namespace UI.GvGOuterTech;

public class UI_btn_PushGiftBag : GButton
{
	public Controller button;

	public GImage n3;

	public GRichTextField Content;

	public GTextField countdown;

	public GGraph SpineBack;

	public GGraph SfxBack;

	public const string URL = "ui://th385mtto4f4o5k";

	public static string Name = "UI_btn_PushGiftBag";

	private GameObject ui_explosion_smoke_white;

	private SkeletonAnimation MerchantAnimation;

	private Coroutine TimeLimitRemainingCoroutine;

	private float Hourglass;

	private bool IsAnimationLoaded;

	private bool ShowCountDown;

	private StoreItem CurStoreItem;

	public static string GetURL()
	{
		return "ui://th385mtto4f4o5k";
	}

	public static UI_btn_PushGiftBag CreateInstance()
	{
		return (UI_btn_PushGiftBag)(object)UIPackage.CreateObject("GvGOuterTech", "btn_PushGiftBag");
	}

	public static UI_btn_PushGiftBag CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PushGiftBag).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtto4f4o5k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Content = (GRichTextField)((GComponent)this).GetChild("Content");
		countdown = (GTextField)((GComponent)this).GetChild("countdown");
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}

	public void Init()
	{
		IsAnimationLoaded = false;
		ShowCountDown = false;
	}

	public void Destroy()
	{
		if ((Object)(object)MerchantAnimation != (Object)null && (Object)(object)((Component)MerchantAnimation).gameObject != (Object)null)
		{
			Object.Destroy((Object)(object)((Component)MerchantAnimation).gameObject);
		}
		if ((Object)(object)ui_explosion_smoke_white != (Object)null)
		{
			Object.Destroy((Object)(object)ui_explosion_smoke_white);
		}
		if (TimeLimitRemainingCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(TimeLimitRemainingCoroutine);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OpenPushBagPanel));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)this).onClick.Clear();
	}

	private void OpenPushBagPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PushGiftBagPanel.Name, new Dictionary<string, object>
		{
			{
				"SortingOrder",
				((GObject)this).sortingOrder
			},
			{ "Parent", this },
			{
				"CustomStoreItems",
				Singleton<GvGOuterTechManager>.Instance.StoreItems
			},
			{
				"NoCountdownText",
				"GvGPushGiftBagTip".ToLanguage()
			},
			{ "RefreshAfterPurchase", false }
		});
	}

	public void Update()
	{
		CurStoreItem = Singleton<GvGOuterTechManager>.Instance.StoreItems.First();
		((GObject)Content).text = CurStoreItem.Name ?? "";
		((GObject)countdown).text = "";
		SetAnimation("skin1", 0, "idle", loop: false, 0f, RefreshPushGiftRemainingTime());
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
							TimeLimitRemainingCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(func);
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
				((MonoBehaviour)FGUIManager.Instance).StopCoroutine(TimeLimitRemainingCoroutine);
				TimeLimitRemainingCoroutine = null;
			}
			TimeLimitRemainingCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(func);
		}
	}

	private IEnumerator RefreshPushGiftRemainingTime()
	{
		while (!((GObject)this).isDisposed)
		{
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
				ui_explosion_smoke_white = FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_explosion_smoke_white", new Vector3(100f, 100f, 100f));
				if ((Object)(object)ui_explosion_smoke_white != (Object)null)
				{
					ui_explosion_smoke_white.transform.localPosition = new Vector3(0f, 0f, -0.5f);
					ui_explosion_smoke_white.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
				}
			}
			if (Hourglass >= 10f && (Object)(object)MerchantAnimation != (Object)null && MerchantAnimation.AnimationName != "work")
			{
				MerchantAnimation.AnimationName = "work";
			}
			if (Hourglass >= 11f)
			{
				if ((Object)(object)MerchantAnimation != (Object)null && (Object)(object)ui_explosion_smoke_white == (Object)null)
				{
					ui_explosion_smoke_white = FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_explosion_smoke_white", new Vector3(100f, 100f, 100f));
					if ((Object)(object)ui_explosion_smoke_white != (Object)null)
					{
						ui_explosion_smoke_white.transform.localPosition = new Vector3(0f, 0f, -0.5f);
						ui_explosion_smoke_white.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
					}
				}
				else
				{
					ui_explosion_smoke_white.GetComponent<ParticleSystem>().Play();
				}
			}
			if (CurStoreItem == null)
			{
				continue;
			}
			bool limitTime = false;
			int remainingTime = 0;
			if (CurStoreItem.ExpireTimestamp > 0)
			{
				limitTime = true;
				remainingTime = CurStoreItem.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
			}
			if (limitTime && ShowCountDown)
			{
				if (remainingTime >= 0)
				{
					((GObject)countdown).text = GetRemainTimeDes(remainingTime);
				}
				else
				{
					((GObject)countdown).text = "CsharpCodeZhTcText425".ToLanguage();
				}
			}
			else
			{
				((GObject)countdown).text = "";
			}
			Hourglass += 0.1f;
			yield return (object)new WaitForSeconds(0.1f);
		}
	}

	public static string GetRemainTimeDes(int timeStamp)
	{
		string text = "CsharpCodeZhTcText428".ToLanguage();
		string text2 = UiHelper.ParseTimeChinsesDH(timeStamp);
		if (text.Contains("{0}"))
		{
			return HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(text, text2);
		}
		return text2 + text;
	}
}
