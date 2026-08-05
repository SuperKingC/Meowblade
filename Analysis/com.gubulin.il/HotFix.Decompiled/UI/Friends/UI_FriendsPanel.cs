using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Friends;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Mail;
using UI.Screenshots;
using UI.Tips;
using UnityEngine;

namespace UI.Friends;

public class UI_FriendsPanel : GComponent, IUiController
{
	private class NewUser : UserInfo
	{
		public int RequestId { get; set; }
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Task<GetFriendsApplyInfoResponse>> _003C_003E9__25_0;

		public static Func<Task<RecycleExportToResponse>> _003C_003E9__36_0;

		public static GTweenCallback _003C_003E9__39_0;

		internal Task<GetFriendsApplyInfoResponse> _003CGetRequest_003Eb__25_0()
		{
			return Contexts.sharedInstance.Service<INetworkService>().GetFriendsApplyInfo();
		}

		internal Task<RecycleExportToResponse> _003CClearUserRecycleLink_003Eb__36_0()
		{
			return GameController.Contexts.Service<INetworkService>().RecycleExportTo(GameController.Contexts.gameState.user.value.UserId);
		}

		internal void _003COnClickInvitingCode_003Eb__39_0()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ScreenshotsPanel.Name, null);
		}
	}

	public GGraph Mask;

	public UI_FriendsDialog Dialog;

	public const string URL = "ui://3rz8gv6cc3w30";

	public static string Name = "UI_FriendsPanel";

	private readonly List<UserInfo> friendsInfo = new List<UserInfo>();

	private readonly List<NewUser> requestInfo = new List<NewUser>();

	private UI_AddFriendPanel addFriendPanel;

	private UI_FriendRequestPanel friendRequestPanel = null;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	private bool isSendingRequest = false;

	private bool needRefreshFriendList = false;

	public static string GetURL()
	{
		return "ui://3rz8gv6cc3w30";
	}

	public static UI_FriendsPanel CreateInstance()
	{
		return (UI_FriendsPanel)(object)UIPackage.CreateObject("Friends", "FriendsPanel");
	}

	public static UI_FriendsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FriendsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_FriendsDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GObject)Dialog.close).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.AddFriendBtn).onClick.Add(new EventCallback0(OpenAddFriendPanel));
		((GObject)Dialog.FriendRequestBtn).onClick.Add(new EventCallback0(OpenFriendRequestPanel));
		((GObject)Dialog.InvitationCode).onClick.Set(new EventCallback0(OnClickInvitingCode));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.close).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.AddFriendBtn).onClick.Clear();
		((GObject)Dialog.FriendRequestBtn).onClick.Clear();
		((GObject)Dialog.InvitationCode).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		bool flag = false;
		bool flag2 = false;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.ContainsKey("Order"))
		{
			((GObject)this).sortingOrder = (int)parameters["Order"];
		}
		GetFriends();
		GetRequest();
	}

	private void OpenAddFriendPanel()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		addFriendPanel = UI_AddFriendPanel.CreateInstance();
		((GObject)addFriendPanel.Mask).onClick.Add(new EventCallback0(CloseAddFriendPanel));
		((GComponent)GRoot.inst).AddChild((GObject)(object)addFriendPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)addFriendPanel);
		addFriendPanel.ShowSelf.Play();
		UI_AddFriendDialog dialog = addFriendPanel.Dialog;
		((GObject)dialog.SendBtn).onClick.Set((EventCallback0)delegate
		{
			OnAddFriend();
		});
		addFriendPanel.Dialog.Input.onChanged.Set(new EventCallback0(OnInputChange));
		((GObject)addFriendPanel.Dialog.Input).onFocusOut.Set(new EventCallback0(OnInputChange));
	}

	private void CloseAddFriendPanel()
	{
		((GObject)addFriendPanel.Mask).onClick.Clear();
		((GObject)addFriendPanel.Dialog.SendBtn).onClick.Clear();
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)addFriendPanel, true);
	}

	private void OnInputChange()
	{
		if (((GObject)addFriendPanel.Dialog.Input).text == string.Empty)
		{
			((GObject)addFriendPanel.Dialog.Input).text = "";
		}
	}

	private void OnAddFriend()
	{
		string invitingCode = ((GObject)addFriendPanel.Dialog.Input).text;
		if (invitingCode == string.Empty)
		{
			((GObject)addFriendPanel.Dialog.Input).text = string.Empty;
			string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText205");
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { desc }, 1, arg3: false);
			return;
		}
		ILRequestHelper<SendFriendsApplyResponse>.Request((EventContext)null, (Func<Task<SendFriendsApplyResponse>>)(() => Contexts.sharedInstance.Service<INetworkService>().SendFriendsApply(invitingCode)), (Action<SendFriendsApplyResponse>)delegate(SendFriendsApplyResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				string desc2 = LanguagesManager.GetDesc("CsharpCodeZhTcText206");
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { desc2 }, 1, arg3: false);
				CloseAddFriendPanel();
			}
		});
	}

	private void OpenFriendRequestPanel()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		friendRequestPanel = UI_FriendRequestPanel.CreateInstance();
		((GObject)friendRequestPanel.Mask).onClick.Set(new EventCallback0(CloseFriendRequestPanel));
		((GComponent)GRoot.inst).AddChild((GObject)(object)friendRequestPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)friendRequestPanel);
		friendRequestPanel.ShowSelf.Play();
		RefreshRequestList();
	}

	private void CloseFriendRequestPanel()
	{
		if (friendRequestPanel != null)
		{
			((GObject)friendRequestPanel.Mask).onClick.Clear();
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)friendRequestPanel, true);
			friendRequestPanel = null;
			if (needRefreshFriendList)
			{
				GetFriends();
			}
			GetRequest();
		}
	}

	private void GetRequest()
	{
		Dialog.FriendRequestBtn.hasMsg.selectedIndex = 0;
		SharedMessenger.Broadcast("UPDATE_FRIEND_REQUEST_NOTE", arg1: false);
		ILRequestHelper<GetFriendsApplyInfoResponse>.Request((EventContext)null, (Func<Task<GetFriendsApplyInfoResponse>>)(() => Contexts.sharedInstance.Service<INetworkService>().GetFriendsApplyInfo()), (Action<GetFriendsApplyInfoResponse>)delegate(GetFriendsApplyInfoResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				requestInfo.Clear();
				List<FriendsApplyProto> data = response.Data;
				if (data != null)
				{
					foreach (FriendsApplyProto item2 in data)
					{
						NewUser item = new NewUser
						{
							RequestId = item2.Id,
							UserId = item2.FromUserId,
							UserLevel = item2.FromLevel,
							LegionPower = item2.FromMaxCombatPower
						};
						requestInfo.Add(item);
					}
					if (requestInfo.Count > 0)
					{
						Dialog.FriendRequestBtn.hasMsg.selectedIndex = 1;
						SharedMessenger.Broadcast("UPDATE_FRIEND_REQUEST_NOTE", arg1: true);
					}
					if (friendRequestPanel != null)
					{
						RefreshRequestList();
					}
				}
			}
		});
	}

	private void RefreshRequestList()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		friendRequestPanel.Dialog.List.itemRenderer = new ListItemRenderer(RenderRequestItem);
		friendRequestPanel.Dialog.List.numItems = requestInfo.Count;
		friendRequestPanel.Dialog.Status.selectedIndex = ((requestInfo.Count > 0) ? 1 : 0);
	}

	private void RenderRequestItem(int index, GObject gObj)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		UI_FriendItemConfirm uI_FriendItemConfirm = (UI_FriendItemConfirm)(object)gObj;
		NewUser friendInfo = requestInfo[index];
		GLoader icon = uI_FriendItemConfirm.IconBtn.HeadPortrait.icon;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, friendInfo.UserId, icon, uI_FriendItemConfirm.name));
		((GObject)uI_FriendItemConfirm.level).text = friendInfo.UserLevel.ToString();
		((GObject)uI_FriendItemConfirm.BattlePower).text = friendInfo.LegionPower.ShortNumberFormat() ?? "";
		((GObject)uI_FriendItemConfirm.ConfirmBtn).onClick.Set((EventCallback0)delegate
		{
			OnAcceptFriend(friendInfo.RequestId, index);
		});
		((GObject)uI_FriendItemConfirm.CancelBtn).onClick.Set((EventCallback0)delegate
		{
			OnRejectFriend(friendInfo.RequestId, index);
		});
	}

	private void OnAcceptFriend(int requestId, int index)
	{
		if (isSendingRequest)
		{
			return;
		}
		isSendingRequest = true;
		ILRequestHelper<ModifyFriendsApplyResponse>.Request((EventContext)null, (Func<Task<ModifyFriendsApplyResponse>>)(() => Contexts.sharedInstance.Service<INetworkService>().ModifyFriendsApply(requestId, isAgree: true)), (Action<ModifyFriendsApplyResponse>)delegate(ModifyFriendsApplyResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				isSendingRequest = false;
			}
			else
			{
				requestInfo.RemoveAt(index);
				RefreshRequestList();
				isSendingRequest = false;
				needRefreshFriendList = true;
			}
		});
	}

	private void OnRejectFriend(int requestId, int index)
	{
		if (isSendingRequest)
		{
			return;
		}
		isSendingRequest = true;
		ILRequestHelper<ModifyFriendsApplyResponse>.Request((EventContext)null, (Func<Task<ModifyFriendsApplyResponse>>)(() => Contexts.sharedInstance.Service<INetworkService>().ModifyFriendsApply(requestId, isAgree: false)), (Action<ModifyFriendsApplyResponse>)delegate(ModifyFriendsApplyResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				isSendingRequest = false;
			}
			else
			{
				requestInfo.RemoveAt(index);
				RefreshRequestList();
				isSendingRequest = false;
			}
		});
	}

	private async void GetFriends()
	{
		FriendsManager friendsManager = GameManagers.Instance.FriendsManager;
		List<UserInfo> friendsList = await friendsManager.GetFriends(getNew: true);
		friendsInfo.Clear();
		if (friendsList != null && friendsList.Count > 0)
		{
			friendsInfo.AddRange(friendsList);
		}
		RefreshFriendsList();
	}

	private void RefreshFriendsList()
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		if (friendsInfo.Count > 0)
		{
			Dialog.Status.selectedIndex = 1;
		}
		else
		{
			Dialog.Status.selectedIndex = 0;
		}
		((GObject)Dialog.tip).text = string.Format("{0}\n{1}/30", LanguagesManager.GetDesc("CsharpCodeZhTcText207"), friendsInfo.Count);
		Dialog.FriendsList.itemRenderer = new ListItemRenderer(RenderFriendItem);
		Dialog.FriendsList.numItems = friendsInfo.Count;
		loadWebImageTaskQueue.Start();
	}

	private void RenderFriendItem(int index, GObject gObj)
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		UI_FriendItem uI_FriendItem = (UI_FriendItem)(object)gObj;
		UserInfo friendInfo = friendsInfo[index];
		((GComponent)uI_FriendItem).GetChild("name").text = friendInfo.Nickname;
		((GComponent)uI_FriendItem).GetChild("level").text = friendInfo.UserLevel.ToString();
		uI_FriendItem.RecycleCenterStatus.selectedIndex = (friendInfo.Valid ? 1 : 0);
		((GComponent)uI_FriendItem).GetChild("BattlePower").text = friendInfo.LegionPower.ShortNumberFormat() ?? "";
		((GObject)((GComponent)uI_FriendItem).GetChild("DeleteBtn").asButton).data = friendInfo;
		((GObject)((GComponent)uI_FriendItem).GetChild("DeleteBtn").asButton).onClick.Set(new EventCallback1(DeleteFriend));
		((GObject)uI_FriendItem.IconBtn.isNew).visible = friendInfo.IsNew;
		((GObject)uI_FriendItem.StartMessage).onClick.Set((EventCallback0)delegate
		{
			ChatWithFriend(friendInfo.UserId);
		});
		((GComponent)uI_FriendItem).GetChild("DeleteBtn").visible = GameController.Configs.TryGetValue("SDFB", out var value) && value == "1";
		IEnumerator imageByWebRequestAndStorage = FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, friendInfo.UserId, ((GComponent)((GComponent)uI_FriendItem).GetChild("IconBtn").asButton).GetChild("HeadPortrait").asCom.GetChild("icon").asLoader, ((GComponent)uI_FriendItem).GetChild("name").asTextField);
		loadWebImageTaskQueue?.AddTask(imageByWebRequestAndStorage);
		FGUIManager.Instance.GetUserMedal(friendInfo.UserId, uI_FriendItem.Medals);
	}

	private static void ChatWithFriend(int userId)
	{
		UnityUiService.Instance.OpenPanel(UI_MailPanel.Name, new Dictionary<string, object>
		{
			{ "DefaultTab", 1 },
			{ "ChatWithFriend", userId }
		});
	}

	private void DeleteFriend(EventContext eventContext)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		UserInfo friendInfo = (UserInfo)((GObject)eventContext.sender).data;
		ArchiveExtension_Friends.Model info = GameManagers.Instance.UserArchiveManager.GetFriendsInfo();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				string.Format("[color=#D5BA7A][size=47]{0}[color=#FF1919]{1}[/color]？[/size]\n[size=33]（{2} {3}/3）[/size][/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText144"), LanguagesManager.GetDesc("CsharpCodeZhTcText208"), LanguagesManager.GetDesc("CsharpCodeZhTcText209"), 3 - info.DeleteFriendsLimit)
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							ILRequestHelper<DeleteFriendResponse>.Request(null, () => Contexts.sharedInstance.Service<INetworkService>().DeleteFriend(friendInfo.UserId), delegate(DeleteFriendResponse response)
							{
								if (!response.Result)
								{
									ILRequestHelper.ShowErrorCode(response.ErrorCode);
								}
								else
								{
									for (int i = 0; i < friendsInfo.Count; i++)
									{
										UserInfo userInfo = friendsInfo[i];
										if (userInfo.UserId == friendInfo.UserId)
										{
											friendsInfo.RemoveAt(i);
											break;
										}
									}
									ManagersDeleteFriend(info, friendInfo);
									RefreshFriendsList();
									ClearUserRecycleLink(friendInfo.UserId, eventContext);
								}
							}, 1f);
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 0 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	public static void ManagersDeleteFriend(ArchiveExtension_Friends.Model info, UserInfo friendInfo)
	{
		info.DeleteFriendsLimit--;
		GameManagers.Instance.UserArchiveManager.SetFriendsInfo(info);
		GameManagers.Instance.FriendsManager.DeleteFriends(friendInfo.UserId);
		GameManagers.Instance.FriendsChatManager.DeleteFriendsChat(friendInfo.UserId);
	}

	private void ClearUserRecycleLink(int userId, EventContext eventContext)
	{
		int curCheckId = GameManagers.Instance.RecycleManager.RecycleExportTo.GetValue();
		if (curCheckId != userId)
		{
			return;
		}
		ILRequestHelper<RecycleExportToResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().RecycleExportTo(GameController.Contexts.gameState.user.value.UserId), async delegate(RecycleExportToResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				curCheckId = response.ExportTo;
				ClearCurProductConfig(eventContext);
				GameManagers.Instance.RecycleManager.RecycleExportTo.SetValue(response.ExportTo);
				await GameManagers.Instance.RecycleManager.GetCurrentRecyclingProducts();
			}
		});
	}

	private void ClearCurProductConfig(EventContext eventContext)
	{
		CustomTaskCompletionSource<bool> customTaskCompletionSource = eventContext.data as CustomTaskCompletionSource<bool>;
		if (customTaskCompletionSource != null)
		{
			customTaskCompletionSource.IsAsync = true;
		}
		ApplyAssignationAsync(customTaskCompletionSource, isLink: true);
	}

	private void ApplyAssignationAsync(CustomTaskCompletionSource<bool> taskCompletionSource = null, bool isLink = false)
	{
		Dictionary<string, ProductionConfig> NewProductConfig = new Dictionary<string, ProductionConfig> { 
		{
			"0",
			new ProductionConfig
			{
				Workers = 0
			}
		} };
		ILRequestHelper<ChangeWorkshopProduceConfigResponse>.Request(taskCompletionSource, delegate
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			Dictionary<int, List<string>> dictionary2 = new Dictionary<int, List<string>>();
			foreach (KeyValuePair<string, ProductionConfig> item in NewProductConfig)
			{
				dictionary.Add(int.Parse(item.Key), item.Value.Workers);
				dictionary2.Add(int.Parse(item.Key), item.Value.ProductList);
			}
			return GameController.Contexts.Service<INetworkService>().ChangeWorkshopProduceConfig(1L, "17", dictionary, dictionary2);
		}, delegate(ChangeWorkshopProduceConfigResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers.Instance.StockController.NeedSyncProduce = true;
				MoltenCore arg = GameManagers.Instance.BuildingManager.GetBuildingByType("17") as MoltenCore;
				SharedMessenger.Broadcast("PRODUCTION_CONFIG_CHANGED", (Building)arg, DictionaryExtensions.DeepCopy<string, ProductionConfig>(NewProductConfig));
				SharedMessenger.Broadcast("WORKERS_ALLOCATION_DISPLAY_CHANGED", (Building)arg);
			}
		});
	}

	private void OnClickInvitingCode()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		if (FriendsManager.ShouldShowCopyInvitingCodeWindow())
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_CopyInvitingCodeWindow.Name, null);
			return;
		}
		Screen.orientation = (ScreenOrientation)1;
		GTweener obj = ((GComponent)(object)this).SetTimeout(2f);
		object obj2 = _003C_003Ec._003C_003E9__39_0;
		if (obj2 == null)
		{
			GTweenCallback val = delegate
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ScreenshotsPanel.Name, null);
			};
			_003C_003Ec._003C_003E9__39_0 = val;
			obj2 = (object)val;
		}
		obj.OnComplete((GTweenCallback)obj2);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}
}
