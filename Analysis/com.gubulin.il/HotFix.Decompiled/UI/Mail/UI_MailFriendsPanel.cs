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
using UI.Friends;
using UI.PublicResources;
using UI.Screenshots;
using UI.Tips;
using UnityEngine;

namespace UI.Mail;

public class UI_MailFriendsPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Task<RecycleExportToResponse>> _003C_003E9__20_0;

		public static GTweenCallback _003C_003E9__23_0;

		internal Task<RecycleExportToResponse> _003CClearUserRecycleLink_003Eb__20_0()
		{
			return GameController.Contexts.Service<INetworkService>().RecycleExportTo(GameController.Contexts.gameState.user.value.UserId);
		}

		internal void _003COnClickInvitingCode_003Eb__23_0()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ScreenshotsPanel.Name, null);
		}
	}

	public GGraph Mask;

	public UI_FriendsDialog Dialog;

	public const string URL = "ui://edr57v33gx8u3y";

	public static string Name = "UI_MailFriendsPanel";

	public const string ChooseChatCallback = "ChooseChatCallback";

	private readonly List<UserInfo> friendsInfo = new List<UserInfo>();

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	private Action<int> _onStartChatWithFriend;

	public static string GetURL()
	{
		return "ui://edr57v33gx8u3y";
	}

	public static UI_MailFriendsPanel CreateInstance()
	{
		return (UI_MailFriendsPanel)(object)UIPackage.CreateObject("Mail", "MailFriendsPanel");
	}

	public static UI_MailFriendsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MailFriendsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33gx8u3y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GObject)Dialog.close).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.InvitationCode).onClick.Set(new EventCallback0(OnClickInvitingCode));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.close).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.InvitationCode).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.ContainsKey("Order"))
		{
			((GObject)this).sortingOrder = (int)parameters["Order"];
		}
		if (parameters.TryGetValue("ChooseChatCallback", out var value))
		{
			_onStartChatWithFriend = (Action<int>)value;
		}
		GetFriends();
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
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		UI_FriendItem uI_FriendItem = (UI_FriendItem)(object)gObj;
		UserInfo friendInfo = friendsInfo[index];
		((GObject)uI_FriendItem.name).text = friendInfo.Nickname;
		((GObject)uI_FriendItem.level).text = friendInfo.UserLevel.ToString();
		uI_FriendItem.RecycleCenterStatus.selectedIndex = (friendInfo.Valid ? 1 : 0);
		((GObject)uI_FriendItem.BattlePower).text = friendInfo.LegionPower.ShortNumberFormat() ?? "";
		((GObject)uI_FriendItem.DeleteBtn).data = friendInfo;
		((GObject)uI_FriendItem.DeleteBtn).onClick.Set(new EventCallback1(DeleteFriend));
		((GObject)uI_FriendItem.StartMessage).onClick.Set((EventCallback0)delegate
		{
			StartChatWithFriends(friendInfo.UserId);
		});
		((GObject)uI_FriendItem.DeleteBtn).visible = GameController.Configs.TryGetValue("SDFB", out var value) && value == "1";
		IEnumerator imageByWebRequestAndStorage = FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, friendInfo.UserId, ((UI_com_ShipAvatar)(object)uI_FriendItem.IconBtn).HeadPortrait.icon, uI_FriendItem.name);
		loadWebImageTaskQueue?.AddTask(imageByWebRequestAndStorage);
		FGUIManager.Instance.GetUserMedal(friendInfo.UserId, uI_FriendItem.Medals);
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
									UI_FriendsPanel.ManagersDeleteFriend(info, friendInfo);
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

	private void StartChatWithFriends(int friendsId)
	{
		End();
		_onStartChatWithFriend?.Invoke(friendsId);
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
		object obj2 = _003C_003Ec._003C_003E9__23_0;
		if (obj2 == null)
		{
			GTweenCallback val = delegate
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ScreenshotsPanel.Name, null);
			};
			_003C_003Ec._003C_003E9__23_0 = val;
			obj2 = (object)val;
		}
		obj.OnComplete((GTweenCallback)obj2);
	}

	public static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
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
