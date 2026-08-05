using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.UnlockSoldierInfo;
using UnityEngine;

namespace UI.Contract;

public class UI_RookiePoolContent : GComponent
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__35_0;

		internal void _003CRenderResultCards_003Eb__35_0()
		{
			UnityUiService.Instance.OpenPanel(UI_HelpPanel2.Name, new Dictionary<string, object>());
		}
	}

	public Controller Type;

	public GGraph ContentMask;

	public GImage tip_foo;

	public GImage tip_bar;

	public GList DrawResultList;

	public GButton Help;

	public const string URL = "ui://avplaivdnle7tkk";

	public static string Name = "UI_RookiePoolContent";

	private const string refreshSfxName = "card_explosion_gold";

	private List<List<ModelsBonus>> NewbieGACHADrawResult = new List<List<ModelsBonus>>();

	private UI_ContractPanel parentPanel { get; set; }

	private bool skip { get; set; }

	private bool isLoaded { get; set; }

	private bool fliped { get; set; }

	private SwipeGesture swipeGesture { get; set; }

	public static string GetURL()
	{
		return "ui://avplaivdnle7tkk";
	}

	public static UI_RookiePoolContent CreateInstance()
	{
		return (UI_RookiePoolContent)(object)UIPackage.CreateObject("Contract", "RookiePoolContent");
	}

	public static UI_RookiePoolContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RookiePoolContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdnle7tkk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		ContentMask = (GGraph)((GComponent)this).GetChild("ContentMask");
		tip_foo = (GImage)((GComponent)this).GetChild("tip_foo");
		tip_bar = (GImage)((GComponent)this).GetChild("tip_bar");
		DrawResultList = (GList)((GComponent)this).GetChild("DrawResultList");
		Help = (GButton)((GComponent)this).GetChild("Help");
	}

	public async void Init(List<List<ModelsBonus>> results, UI_ContractPanel _contractPanel)
	{
		if (!((GObject)this).isDisposed)
		{
			parentPanel = _contractPanel;
			await Task.Delay(1527);
			if (!((GObject)this).isDisposed && !skip)
			{
				NewbieGACHADrawResult = results;
				((GObject)parentPanel.InterruptBack).touchable = false;
				((GObject)this).visible = true;
				Type.selectedIndex = 0;
				((GObject)ContentMask).onClick.Set(new EventCallback0(FlipAllSoulStoneAndSoldierCards));
				swipeGesture = new SwipeGesture((GObject)(object)ContentMask);
				swipeGesture.onMove.Set(new EventCallback0(FlipAllSoulStoneAndSoldierCards));
				RenderResultCards();
				ShowSoulStoneAndSoldierCard();
			}
		}
	}

	public void RenderResultCards()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		if (isLoaded || ((GObject)this).isDisposed)
		{
			return;
		}
		((GObject)DrawResultList).touchable = false;
		DrawResultList.itemRenderer = new ListItemRenderer(RenderResultCard);
		DrawResultList.numItems = NewbieGACHADrawResult.Count;
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("LotteryPanel.NewbieCard");
		GObject childAt = ((GComponent)DrawResultList).GetChildAt(1);
		instance.Register("LotteryPanel.NewbieCard", childAt);
		isLoaded = true;
		bool flag = GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6();
		bool flag2 = GameManagers.Instance.UserArchiveManager.IsNewGuideMode7();
		((GObject)Help).visible = flag || flag2;
		EventListener onClick = ((GObject)Help).onClick;
		object obj = _003C_003Ec._003C_003E9__35_0;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				UnityUiService.Instance.OpenPanel(UI_HelpPanel2.Name, new Dictionary<string, object>());
			};
			_003C_003Ec._003C_003E9__35_0 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback0)obj);
	}

	private void RenderResultCard(int index, GObject obj)
	{
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		if (((GObject)this).isDisposed || !(obj is UI_RookieDrawCard uI_RookieDrawCard) || ((GObject)uI_RookieDrawCard).isDisposed)
		{
			return;
		}
		uI_RookieDrawCard.Type.selectedIndex = 0;
		uI_RookieDrawCard.State.selectedIndex = 0;
		List<ModelsBonus> list = NewbieGACHADrawResult[index];
		uI_RookieDrawCard.NewSoldier.SoldierLoaderInit(list[0]);
		for (int i = 0; i < list.Count; i++)
		{
			if (i != 0 && uI_RookieDrawCard.SoulStoneList.AddItemFromPool() is UI_RookieSoulStoneLoader uI_RookieSoulStoneLoader)
			{
				uI_RookieSoulStoneLoader.SoulLoaderInit(list[i]);
			}
		}
		if (index == 1)
		{
			UiTagManager instance = UiTagManager.Instance;
			instance.Unregister("LotteryPanel.NewbieCardSoldier");
			instance.Register("LotteryPanel.NewbieCardSoldier", uI_RookieDrawCard.NewSoldier);
		}
		((GObject)uI_RookieDrawCard.FreeToReceive).alpha = 1f;
		((GObject)uI_RookieDrawCard).onClick.Set(new EventCallback1(SelectResultCard));
		((GObject)uI_RookieDrawCard.FreeToReceive).data = index;
		((GObject)uI_RookieDrawCard.FreeToReceive).onClick.Set(new EventCallback1(GetResultBonus));
		((GObject)uI_RookieDrawCard.NewSoldier).onClick.Set(new EventCallback1(ShowSoldierInfo));
	}

	private void ShowSoulStoneAndSoldierCard()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		if (!isLoaded || ((GObject)this).isDisposed || skip)
		{
			return;
		}
		float num = 0f;
		for (int i = 0; i < DrawResultList.numItems; i++)
		{
			UI_RookieDrawCard btn = ((GComponent)DrawResultList).GetChildAt(i) as UI_RookieDrawCard;
			if (btn == null)
			{
				continue;
			}
			num = 0.35f * (float)(i + 1);
			((GObject)btn.SfxBack).SetPivot(0.5f, 0.5f, true);
			((GComponent)(object)btn).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				//IL_0053: Unknown result type (might be due to invalid IL or missing references)
				if (!((GObject)this).isDisposed && !((GObject)btn).isDisposed && !skip)
				{
					FGUIManager.Instance.AddTextSpecialEffects(btn.SfxBack, "card_explosion_gold", new Vector3(200f, 200f, 200f));
					btn.State.selectedIndex = 1;
				}
			});
			float num2 = num;
			for (int num3 = btn.SoulStoneList.numItems - 1; num3 >= 0; num3--)
			{
				UI_RookieSoulStoneLoader soulStone = ((GComponent)btn.SoulStoneList).GetChildAt(num3) as UI_RookieSoulStoneLoader;
				if (soulStone != null)
				{
					num2 += 0.1f;
					((GComponent)(object)soulStone).SetTimeout(num2).OnComplete((GTweenCallback)delegate
					{
						if (!((GObject)this).isDisposed && !((GObject)soulStone).isDisposed && !skip)
						{
							FGUIManager.Instance.OpenIEnumerator(soulStone.ShowSoulStone());
						}
					});
				}
			}
			float num4 = num2 + 0.1f;
			((GComponent)(object)btn.NewSoldier).SetTimeout(num4).OnComplete((GTweenCallback)delegate
			{
				if (!((GObject)this).isDisposed && !((GObject)btn.NewSoldier).isDisposed && !skip)
				{
					FGUIManager.Instance.OpenIEnumerator(btn.NewSoldier.ShowSoldierCard());
				}
			});
			((GComponent)(object)this).SetTimeout(num4 + 0.1f).OnComplete((GTweenCallback)delegate
			{
				((GObject)parentPanel.InterruptBack).touchable = false;
				((GObject)tip_foo).alpha = 1f;
			});
		}
	}

	public void End()
	{
		if (!((GObject)this).isDisposed)
		{
			((GObject)this).visible = false;
			SharedMessenger.Broadcast("ROOKIE_POOL_CONTENT_CLOSED");
		}
	}

	public void SkipAndShowImmediately(List<List<ModelsBonus>> results, UI_ContractPanel _contractPanel)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		if (((GObject)this).isDisposed || results == null)
		{
			return;
		}
		parentPanel = _contractPanel;
		NewbieGACHADrawResult = results;
		((GObject)this).visible = true;
		skip = true;
		((GObject)parentPanel.InterruptBack).touchable = false;
		Type.selectedIndex = 0;
		((GObject)tip_foo).alpha = 1f;
		RenderResultCards();
		((GObject)ContentMask).onClick.Set(new EventCallback0(FlipAllSoulStoneAndSoldierCards));
		swipeGesture = new SwipeGesture((GObject)(object)ContentMask);
		swipeGesture.onMove.Set(new EventCallback0(FlipAllSoulStoneAndSoldierCards));
		for (int i = 0; i < DrawResultList.numItems; i++)
		{
			if (!(((GComponent)DrawResultList).GetChildAt(i) is UI_RookieDrawCard uI_RookieDrawCard))
			{
				continue;
			}
			uI_RookieDrawCard.State.selectedIndex = 1;
			((GObject)uI_RookieDrawCard.NewSoldier).alpha = 1f;
			uI_RookieDrawCard.NewSoldier.StopPlayAnimation();
			for (int j = 0; j < uI_RookieDrawCard.SoulStoneList.numItems; j++)
			{
				if (((GComponent)uI_RookieDrawCard.SoulStoneList).GetChildAt(j) is UI_RookieSoulStoneLoader uI_RookieSoulStoneLoader)
				{
					uI_RookieSoulStoneLoader.StopPlayAnimation();
				}
			}
		}
	}

	private void SelectResultCard(EventContext context)
	{
		if (((GObject)this).isDisposed || Type.selectedIndex != 1)
		{
			return;
		}
		UI_RookieDrawCard uI_RookieDrawCard = (UI_RookieDrawCard)(object)context.sender;
		if (uI_RookieDrawCard == null)
		{
			return;
		}
		for (int i = 0; i < DrawResultList.numItems; i++)
		{
			if (((GComponent)DrawResultList).GetChildAt(i) is UI_RookieDrawCard uI_RookieDrawCard2)
			{
				uI_RookieDrawCard2.Type.selectedIndex = 0;
				((GObject)uI_RookieDrawCard2.NewSoldier).scaleX = -0.68f;
				((GObject)uI_RookieDrawCard.NewSoldier).touchable = false;
			}
		}
		uI_RookieDrawCard.Type.selectedIndex = 1;
		((GObject)uI_RookieDrawCard.NewSoldier).touchable = true;
	}

	private void ShowSoldierInfo(EventContext context)
	{
		if (!((GObject)this).isDisposed && Type.selectedIndex == 1 && parentPanel != null && !((GObject)parentPanel).isDisposed)
		{
			UI_RookieSoldierLoader uI_RookieSoldierLoader = (UI_RookieSoldierLoader)(object)context.sender;
			if (uI_RookieSoldierLoader != null)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UnlockSoldierInfoPanel.Name, new Dictionary<string, object> { 
				{
					"UnlockSoldierId",
					"S" + uI_RookieSoldierLoader.itemId.Substring(3)
				} });
			}
		}
	}

	private async void GetResultBonus(EventContext context)
	{
		if (((GObject)this).isDisposed || Type.selectedIndex != 1 || parentPanel == null || ((GObject)parentPanel).isDisposed)
		{
			return;
		}
		GObject _btn = (GObject)context.sender;
		object _data = _btn.data;
		if (_data == null)
		{
			return;
		}
		int select = (int)_data;
		_btn.touchable = false;
		int _uiNotTouchableIndex = GameController.Contexts.Service<IUiService>().SetUiNotTouchable(Name);
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		if (!(await parentPanel.newbieGACHAActivityPayload.UpdateNewbieGACHAActivityProgress(select)))
		{
			_btn.touchable = true;
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			GameController.Contexts.Service<IUiService>().SetUiTouchable(_uiNotTouchableIndex);
		}
		else
		{
			if (((GObject)this).isDisposed || ((GObject)parentPanel).isDisposed)
			{
				return;
			}
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			GameController.Contexts.Service<IUiService>().SetUiTouchable(_uiNotTouchableIndex);
			for (int i = 0; i < DrawResultList.numItems; i++)
			{
				if (!(((GComponent)DrawResultList).GetChildAt(i) is UI_RookieDrawCard btn))
				{
					continue;
				}
				if (select != i)
				{
					btn.State.selectedIndex = 0;
					((GObject)btn.FreeToReceive).alpha = 0f;
					continue;
				}
				for (int j = 0; j < btn.SoulStoneList.numItems; j++)
				{
					UI_RookieSoulStoneLoader soulStone = ((GComponent)btn.SoulStoneList).GetChildAt(j) as UI_RookieSoulStoneLoader;
					float delayTime = (float)j * 0.02f;
					((GComponent)(object)soulStone).SetTimeout(delayTime).OnComplete((GTweenCallback)delegate
					{
						if (!((GObject)this).isDisposed && soulStone != null && !((GObject)soulStone).isDisposed)
						{
							soulStone.SoulStoneDisAppear();
						}
					});
				}
				btn.NewSoldier.SoldierBtnDisAppear();
			}
			parentPanel.newSoldierIdList = null;
			parentPanel.needShowNewbieContent = false;
			((GComponent)(object)this).SetTimeout(0.3f).OnComplete((GTweenCallback)delegate
			{
				End();
				parentPanel.End();
			});
		}
	}

	private async void FlipAllSoulStoneAndSoldierCards()
	{
		if (((GObject)this).isDisposed || parentPanel == null || ((GObject)parentPanel).isDisposed || fliped)
		{
			return;
		}
		fliped = true;
		if (!(await parentPanel.newbieGACHAActivityPayload.UpdateNewbieGACHAActivityProgress()) || ((GObject)this).isDisposed || ((GObject)parentPanel).isDisposed)
		{
			return;
		}
		float delayTime = 0f;
		for (int i = 0; i < DrawResultList.numItems; i++)
		{
			UI_RookieDrawCard btn = ((GComponent)DrawResultList).GetChildAt(i) as UI_RookieDrawCard;
			if (btn == null)
			{
				continue;
			}
			for (int j = 0; j < btn.SoulStoneList.numItems; j++)
			{
				float showStoneDelayTime = (float)j * 0.05f + delayTime;
				UI_RookieSoulStoneLoader soulStone = ((GComponent)btn.SoulStoneList).GetChildAt(j) as UI_RookieSoulStoneLoader;
				((GComponent)(object)soulStone).SetTimeout(showStoneDelayTime).OnComplete((GTweenCallback)delegate
				{
					if (!((GObject)this).isDisposed && !((GObject)parentPanel).isDisposed && soulStone != null && !((GObject)soulStone).isDisposed)
					{
						soulStone.FlipSoulStone();
					}
				});
			}
			delayTime += 0.15f;
			((GComponent)(object)btn.NewSoldier).SetTimeout(0.9f + 0.15f * (float)i).OnComplete((GTweenCallback)delegate
			{
				if (!((GObject)this).isDisposed && !((GObject)parentPanel).isDisposed && !((GObject)btn.NewSoldier).isDisposed)
				{
					btn.NewSoldier.FlipSoulStone();
				}
			});
		}
		await Task.Delay(1500);
		if (!((GObject)this).isDisposed && !((GObject)parentPanel).isDisposed)
		{
			Type.selectedIndex = 1;
			((GObject)tip_bar).alpha = 1f;
			((GObject)DrawResultList).touchable = true;
			SharedMessenger.Broadcast("NEW_BIE_CARDS_SHOW");
		}
	}

	public void FlipAllSoulStoneAndSoldierCardsShowImmediately()
	{
		if (((GObject)this).isDisposed || parentPanel == null || ((GObject)parentPanel).isDisposed || fliped)
		{
			return;
		}
		fliped = true;
		((GObject)parentPanel.InterruptBack).touchable = false;
		((GObject)parentPanel.slideFloor).touchable = false;
		for (int i = 0; i < DrawResultList.numItems; i++)
		{
			if (!(((GComponent)DrawResultList).GetChildAt(i) is UI_RookieDrawCard uI_RookieDrawCard))
			{
				continue;
			}
			for (int j = 0; j < uI_RookieDrawCard.SoulStoneList.numItems; j++)
			{
				if (((GComponent)uI_RookieDrawCard.SoulStoneList).GetChildAt(j) is UI_RookieSoulStoneLoader uI_RookieSoulStoneLoader)
				{
					uI_RookieSoulStoneLoader.FlipSoulStone(isSlow: true);
				}
			}
			uI_RookieDrawCard.NewSoldier.FlipSoulStone(isSlow: true);
		}
		Type.selectedIndex = 1;
		((GObject)tip_bar).alpha = 1f;
		((GObject)DrawResultList).touchable = true;
		SharedMessenger.Broadcast("NEW_BIE_CARDS_SHOW");
	}
}
