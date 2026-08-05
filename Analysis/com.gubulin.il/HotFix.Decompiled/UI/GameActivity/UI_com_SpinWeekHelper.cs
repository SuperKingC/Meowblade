using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using FairyGUI;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UI.WeekActivity;
using UnityEngine;

namespace UI.GameActivity;

public class UI_com_SpinWeekHelper
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static TweenCallback _003C_003E9__7_0;

		internal void _003CShowFlyAnim_003Eb__7_0()
		{
		}
	}

	public static int MaxMultiLotteryCount => HotUpdateProcess.Instance.IsRegionOutCN ? 50 : 500;

	public static async void ShowSpinResult(ISpinWheelPage page, DrawSpinWeeklyResponse response, GetWeeklyActivityResponse config, Action onClose)
	{
		UnityUiService.Instance.OpenPanel(UI_popup_SpinActivityResult.Name, new Dictionary<string, object>
		{
			{ "Parent", page },
			{ "Config", config },
			{ "DrawResult", response },
			{ "OnClose", onClose }
		});
		foreach (int resultIndex in response.DrawResult)
		{
			SpinWeekActivityPayload.ExhibitPrize itemConfig = config.ActivityConfig.ExhibitPrizes[resultIndex];
			if (itemConfig.IsNotice)
			{
				await ActivityEntranceStatic.GetSpinWeekActivity();
				GameManagers.Instance.Messenger.Broadcast("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", ActivityManager.SpinWeekActivity);
				return;
			}
		}
	}

	public static void InitExchangeRateText(GRichTextField exchangeRateText, int exchangeRate, string item1, string item2)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)exchangeRateText).text = "SpinWeekSpinExchangeRateTip".ToLanguage().Format(exchangeRate, item1, UiHelper.GetItemIconPath(item1), item2, UiHelper.GetItemIconPath(item2));
		((GObject)exchangeRateText).onClickLink.Set((EventCallback1)delegate(EventContext x)
		{
			FGUIManager.Instance.ItemTip(x.data.ToString(), ((GObject)exchangeRateText).sortingOrder);
			x.StopPropagation();
		});
	}

	private static int GetNewAnnouncementCount(GetWeeklyActivityResponse last, GetWeeklyActivityResponse current)
	{
		int num = 0;
		List<GetWeeklyActivityResponse.Announcement> list = last?.GetLotteryAnnouncement();
		if (list == null || list.Count <= 0)
		{
			num = ((list != null) ? current.GetLotteryAnnouncement().Count : 0);
		}
		else
		{
			long timeStamp = list.First().TimeStamp;
			foreach (GetWeeklyActivityResponse.Announcement item in current.GetLotteryAnnouncement())
			{
				if (item.TimeStamp > timeStamp)
				{
					num++;
					continue;
				}
				break;
			}
		}
		return num;
	}

	public static void RenderAnnouncement(GComponent self, GetWeeklyActivityResponse lastResponse, GetWeeklyActivityResponse response, GList giftRecordList)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		List<int> list = new List<int>();
		int newAnnouncementCount = GetNewAnnouncementCount(lastResponse, response);
		List<GetWeeklyActivityResponse.Announcement> announcements = response.GetLotteryAnnouncement();
		foreach (GetWeeklyActivityResponse.Announcement item in announcements)
		{
			list.Add(item.UserId);
		}
		Dictionary<int, string> userNameLut = new Dictionary<int, string>();
		giftRecordList.itemRenderer = new ListItemRenderer(RenderGiftRecord);
		giftRecordList.numItems = announcements.Count;
		ScrollPane target = ((GComponent)giftRecordList).scrollPane;
		target.percY = (float)newAnnouncementCount / (float)giftRecordList.numItems;
		TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => target.percY), (DOSetter<float>)delegate(float x)
		{
			target.percY = x;
		}, 0f, 1f), (Ease)1);
		GetUserNickNames(self, list.ToArray(), delegate(Dictionary<int, string> infos)
		{
			if (!((GObject)self).isDisposed)
			{
				userNameLut = infos;
				giftRecordList.numItems = announcements.Count;
			}
		});
		void RenderGiftRecord(int index, GObject item)
		{
			UI_com_SpinWeekInfoItem uI_com_SpinWeekInfoItem = (UI_com_SpinWeekInfoItem)(object)item;
			GetWeeklyActivityResponse.Announcement announcement = announcements[index];
			int userId = announcement.UserId;
			string value;
			string arg = (userNameLut.TryGetValue(userId, out value) ? value : RankDataHelper.UserId_Obfuscating(userId));
			KeyValuePair<string, int> keyValuePair = announcement.Prize.PrizeContent.First();
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(keyValuePair.Key);
			((GObject)uI_com_SpinWeekInfoItem.n0).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(announcement.LanguageKey.ToLanguage(), arg, gDEItemData.Name, keyValuePair.Value).RemoveLineBreak();
		}
	}

	private static void GetUserNickNames(GComponent self, int[] userIds, Action<Dictionary<int, string>> onProgress)
	{
		HashSet<int> source = new HashSet<int>(userIds);
		userIds = source.ToArray();
		Dictionary<int, string> userNameDic = new Dictionary<int, string>();
		int[] array = userIds;
		foreach (int num in array)
		{
			int uid = num;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetUserNickName((GObject)(object)self, num, delegate(string userName)
			{
				userNameDic[uid] = userName;
				onProgress?.Invoke(userNameDic);
			}));
		}
	}

	public static void ShowFlyAnim(ISpinWheelPage page, GLoader source)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		GGraph flyAnim = page.FlyAnim;
		GLoader ticketIcon = page.StoreBtn.ticketIcon;
		((GObject)flyAnim).visible = true;
		Vector2 val = ((GObject)source).LocalToGlobal(Vector2.zero);
		Vector2 val2 = ((GObject)((GObject)flyAnim).parent).GlobalToLocal(val);
		((GObject)flyAnim).position = Vector2.op_Implicit(val2);
		FGUIManager.Instance.AddTextSpecialEffects(flyAnim, "exp_missile_yellow", Vector3.one * 75f);
		Vector3 zero = Vector3.zero;
		Tween obj = TweenSettingsExtensions.SetEase<Tween>(((GObject)(object)flyAnim).TweenToTarget((GObject)(object)ticketIcon, Vector2.op_Implicit(zero), 0.6f), (Ease)8);
		object obj2 = _003C_003Ec._003C_003E9__7_0;
		if (obj2 == null)
		{
			TweenCallback val3 = delegate
			{
			};
			_003C_003Ec._003C_003E9__7_0 = val3;
			obj2 = (object)val3;
		}
		TweenSettingsExtensions.OnComplete<Tween>(obj, (TweenCallback)obj2);
	}
}
