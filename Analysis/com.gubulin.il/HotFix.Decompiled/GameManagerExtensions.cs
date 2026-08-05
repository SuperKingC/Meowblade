using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotFix;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Mailing;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

public static class GameManagerExtensions
{
	public static void InitClientMethods(this GameManagers managers)
	{
		ActivityManager.RemoveActivityNewMsgIncoming = delegate(string activityId)
		{
			if (Contexts.sharedInstance.ui.hasNewMsgIncoming)
			{
				Contexts.sharedInstance.ui.newMsgIncoming.ActivitiesWithNewMsg.Remove(activityId);
			}
		};
		ActivityManager.AddActivityNewMsgIncoming = delegate(string activityId)
		{
			if (Contexts.sharedInstance.ui.hasNewMsgIncoming && !Contexts.sharedInstance.ui.newMsgIncoming.ActivitiesWithNewMsg.Contains(activityId))
			{
				Contexts.sharedInstance.ui.newMsgIncoming.ActivitiesWithNewMsg.Add(activityId);
			}
		};
		ActivityManager.SendCheckActivitiesOverPeriodRequest = (List<string> activityIds, List<ActivityType> activityTypes) => Contexts.sharedInstance.Service<INetworkService>().CheckActivitiesOverPeriod(activityIds, activityTypes);
		ActivityManager.SendActivitiesReviewRequest = (List<string> activityIds) => Contexts.sharedInstance.Service<INetworkService>().ActivitiesReview(activityIds);
		FormationUnitsManager.ChangeFormationUnits = delegate(string context, string subContext, List<string> units)
		{
			Dictionary<string, Dictionary<string, List<string>>> value = Contexts.sharedInstance.config.formationUnits.value;
			if (!value.TryGetValue(context, out var value2))
			{
				value2 = new Dictionary<string, List<string>>();
				value.Add(context, value2);
			}
			if (value2.ContainsKey(subContext))
			{
				value2[subContext] = new List<string>(units);
			}
			else
			{
				value2.Add(subContext, new List<string>(units));
			}
			Contexts.sharedInstance.config.ReplaceFormationUnits(value);
		};
		FriendsManager.SendGetInvitedWorkersRequest = () => Contexts.sharedInstance.Service<INetworkService>().GetInvitedWorkers();
		FriendsManager.SendGetFriendsRequest = (bool getNew) => Contexts.sharedInstance.Service<INetworkService>().GetFriends(getNew);
		RecycleManager.SendGetRecycleProductsRequest = (int userId) => Contexts.sharedInstance.Service<INetworkService>().GetRecycleProducts(userId);
		SoldierManager.CreateUnlockSoldierCommand = delegate(string soldierId, List<string> newUnlockList)
		{
			CommandFactory.CreateUnlockSoldierCommand(soldierId, newUnlockList);
		};
		StoryManager.SendPlayStoryRequest = (string storyId) => Contexts.sharedInstance.Service<INetworkService>().PlayStory(0L, storyId);
		TriggerManager.GetCurrentLevel = () => Contexts.sharedInstance.Service<IBattleFieldService>().Level;
		LotteryActivityPayload.SendDrawCardRequest = (string activityId, string drawOption) => Contexts.sharedInstance.Service<INetworkService>().DrawCard(activityId, drawOption);
		LotteryActivityPayload.SendDrawDynamicCardPoolRequest = (string activityId, string drawOption) => Contexts.sharedInstance.Service<INetworkService>().DrawCardFromDynamicPool(activityId, drawOption);
		DungeonExpData.CreateChangeCurrentFormationUnitCommand = delegate(int portalId, string unitId, string context, string subContext)
		{
			CommandFactory.CreateChangeCurrentFormationUnitCommand(portalId, unitId, context, subContext);
		};
		UserExpData.CreateChangeCurrentFormationUnitCommand = delegate(int portalId, string unitId, string context, string subContext)
		{
			CommandFactory.CreateChangeCurrentFormationUnitCommand(portalId, unitId, context, subContext);
		};
		MailManager.SendMarkMailAsReadRequest = delegate(int mailId)
		{
			Contexts.sharedInstance.Service<INetworkService>().MarkMailAsRead(mailId);
		};
		MailManager.SendMarkAllMailsAsReadRequest = delegate
		{
			Contexts.sharedInstance.Service<INetworkService>().MarkAllMailsAsRead();
		};
		MailManager.SendDeleteMailRequest = delegate(int mailId)
		{
			Contexts.sharedInstance.Service<INetworkService>().DeleteMail(mailId);
		};
		MailManager.SendDeleteAllMailsRequest = delegate
		{
			Contexts.sharedInstance.Service<INetworkService>().DeleteAllMails();
		};
		CustomScript.ScriptRunner = delegate(CustomTaskCompletionSource<bool> taskCompletionSource, GameManagers gameManagers, Dictionary<string, object> line, int timeout)
		{
			if (line != null && line.Count != 0)
			{
				string actionName = line["ActionName"].ToString();
				string actionPayload = line["ActionPayload"].ToString();
				string nextTrigger = line["NextTrigger"].ToString();
				line.TryGetValue("Key", out var value);
				if (value != null)
				{
					string lineKey = value.ToString();
					if (StoryManager.LineOfStory.TryGetValue(lineKey, out var storyId))
					{
						if (taskCompletionSource != null)
						{
							taskCompletionSource.IsAsync = true;
						}
						ILRequestHelper<TriggerStoryResponse>.Request(null, () => Contexts.sharedInstance.Service<INetworkService>().TriggerStory(0L, lineKey), async delegate(TriggerStoryResponse response)
						{
							if (response != null && !response.Result)
							{
								ILRequestHelper.ShowErrorCode(response.ErrorCode);
								taskCompletionSource?.TrySetResult(result: true);
							}
							else
							{
								CustomTaskCompletionSource<bool> lineCompletionSource = new CustomTaskCompletionSource<bool>
								{
									IsAsync = false
								};
								managers.CustomScriptManager.AddPendingAction(lineCompletionSource);
								int changeId = Contexts.sharedInstance.Service<IUiService>().SetUiNotTouchable(null);
								if (actionName == "OpenUI" && GameController.Contexts.gameState.hasLoadingPanelStatus && GameController.Contexts.gameState.loadingPanelStatus.value != LoadingPanelStatus.Closed)
								{
									await Task.Delay(35);
								}
								Action callback = CustomScript.DoAction(managers, actionName, actionPayload, lineCompletionSource, nextTrigger);
								if (callback == null)
								{
									managers.StoryManager.SetPlayingStoryLine(storyId, lineKey);
								}
								if (actionName != "StoryBegin" && actionName != "StoryEnd" && actionName != "Bonus" && actionName != "ActivateStoryOnNodeVersion" && actionName != "Timeout")
								{
									await Task.Delay(300);
								}
								if (nextTrigger == "Waiting")
								{
									if (actionName != "Timeout")
									{
										Contexts.sharedInstance.Service<IUiService>().SetUiTouchable(changeId);
									}
								}
								else if (!lineCompletionSource.IsAsync)
								{
									lineCompletionSource.TrySetResult(result: true);
									taskCompletionSource?.TrySetResult(result: true);
								}
								if (!(await lineCompletionSource.Task))
								{
									Contexts.sharedInstance.Service<IUiService>().SetUiTouchable(changeId);
									taskCompletionSource?.TrySetResult(result: false);
								}
								else
								{
									if (callback != null)
									{
										callback();
										managers.StoryManager.SetPlayingStoryLine(storyId, lineKey);
									}
									taskCompletionSource?.TrySetResult(result: true);
									Contexts.sharedInstance.Service<IUiService>().SetUiTouchable(changeId);
								}
							}
						}, 1f);
					}
				}
			}
		};
		CustomScript.AddActionHandler(new CloseUIActionHandler());
		CustomScript.AddActionHandler(new FireClickActionHandler());
		CustomScript.AddActionHandler(new MoveCameraActionHandler());
		CustomScript.AddActionHandler(new OpenUIActionHandler());
		CustomScript.AddActionHandler(new PlayAnimationActionHandler());
		CustomScript.AddActionHandler(new PlayBattleReplayActionHandler());
		CustomScript.AddActionHandler(new ScrollToViewActionHandler());
		CustomScript.AddActionHandler(new TimeoutActionHandler());
	}

	public static async void PullData(this GameManagers managers)
	{
		PullDataResponse pullDataResponse = await Contexts.sharedInstance.Service<INetworkService>().PullData();
		if (pullDataResponse == null || !pullDataResponse.Result)
		{
			return;
		}
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			Dictionary<string, NewsTickerMultiLanguageContent> newsTickerMultiLanguageContent = JsonHelper.ToObject<Dictionary<string, NewsTickerMultiLanguageContent>>(pullDataResponse.NewsTicker.Content);
			if (newsTickerMultiLanguageContent.TryGetValue(HotUpdateProcess.LanguageKey, out var translatedNewsTicker))
			{
				pullDataResponse.NewsTicker.Content = translatedNewsTicker.Content;
			}
			if (pullDataResponse.Mails == null || pullDataResponse.Mails.Count == 0)
			{
				return;
			}
			for (int i = 0; i < pullDataResponse.Mails.Count; i++)
			{
				Shift.Legion.ClientApi.Protocol.Mailing.Mail mail = pullDataResponse.Mails[i];
				if (!mail.Title.StartsWith("##"))
				{
					Dictionary<string, MailMultiLanguageContent> mailMultiLanguageContent = JsonHelper.ToObject<Dictionary<string, MailMultiLanguageContent>>(mail.Content);
					if (mailMultiLanguageContent.TryGetValue(HotUpdateProcess.LanguageKey, out var translatedMail))
					{
						mail.Title = translatedMail.Title;
						mail.Content = translatedMail.Content;
					}
					translatedMail = null;
				}
			}
		}
		managers.MailManager.HandlePulledMails(pullDataResponse.Mails);
		managers.Messenger.Broadcast("NEWS_TICKER_PULLED", pullDataResponse.NewsTicker);
		managers.Messenger.Broadcast("NEWS_MARQUEE_CONTENT_PULLED", pullDataResponse.MarqueeContent);
	}
}
