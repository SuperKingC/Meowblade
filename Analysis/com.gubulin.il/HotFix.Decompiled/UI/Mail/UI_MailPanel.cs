using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using UI.PublicResources;
using UnityEngine;

namespace UI.Mail;

public class UI_MailPanel : GComponent, IUiController
{
	private enum ChatViewType
	{
		Friends,
		Self,
		Line
	}

	private class ChatViewModel
	{
		public ChatViewType Type;

		public ChatLog Log;

		public bool IsNew;
	}

	public Controller Status;

	public Controller tabType;

	public Controller MailEmpty;

	public GGraph mask;

	public GList TabListBack;

	public GImage back;

	public UI_exit exit;

	public GList TabListFront;

	public GImage n111;

	public GImage n112;

	public GImage n90;

	public GImage n114;

	public GTextField n115;

	public GImage n113;

	public GGroup n116;

	public GGraph EmptySlot;

	public GGraph n92;

	public GGraph n91;

	public GTextField Title;

	public GList mailList;

	public GList annexList;

	public UI_DetailCom DetailCom;

	public GRichTextField mailTitle;

	public GRichTextField annexTitle;

	public UI_allReceive allReceive;

	public UI_remove allDelete;

	public UI_delete delete;

	public UI_receive receive;

	public GRichTextField tip;

	public GList getTips;

	public GGroup mailGroup;

	public UI_com_MailPanelMessageGroup messageGroup;

	public UI_Tip Tip;

	public Transition t0;

	public Transition t1;

	public Transition t3;

	public Transition t4;

	public const string URL = "ui://edr57v33oipit";

	public static string Name = "UI_MailPanel";

	private EventCallback0 _callback;

	public const string DefaultTab = "DefaultTab";

	public const string StartChatFriendId = "ChatWithFriend";

	private FriendsChatSession _currentSession;

	private Dictionary<int, List<ChatViewModel>> _viewModels;

	private bool _needRefresh;

	private Coroutine _longPressCoroutine;

	private UI_com_Message _longPressItem;

	private UI_com_Message _copyProcessItem;

	public static string GetURL()
	{
		return "ui://edr57v33oipit";
	}

	public static UI_MailPanel CreateInstance()
	{
		return (UI_MailPanel)(object)UIPackage.CreateObject("Mail", "MailPanel");
	}

	public static UI_MailPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MailPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33oipit", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		tabType = ((GComponent)this).GetController("tabType");
		MailEmpty = ((GComponent)this).GetController("MailEmpty");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		TabListBack = (GList)((GComponent)this).GetChild("TabListBack");
		back = (GImage)((GComponent)this).GetChild("back");
		exit = (UI_exit)(object)((GComponent)this).GetChild("exit");
		TabListFront = (GList)((GComponent)this).GetChild("TabListFront");
		n111 = (GImage)((GComponent)this).GetChild("n111");
		n112 = (GImage)((GComponent)this).GetChild("n112");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		n114 = (GImage)((GComponent)this).GetChild("n114");
		n115 = (GTextField)((GComponent)this).GetChild("n115");
		string id = "ui://edr57v33oipit".Replace("ui://", "") + "-" + ((GObject)n115).id;
		((GObject)n115).text = LanguagesManager.GetDesc(id);
		n113 = (GImage)((GComponent)this).GetChild("n113");
		n116 = (GGroup)((GComponent)this).GetChild("n116");
		EmptySlot = (GGraph)((GComponent)this).GetChild("EmptySlot");
		n92 = (GGraph)((GComponent)this).GetChild("n92");
		n91 = (GGraph)((GComponent)this).GetChild("n91");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id2 = "ui://edr57v33oipit".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id2);
		mailList = (GList)((GComponent)this).GetChild("mailList");
		annexList = (GList)((GComponent)this).GetChild("annexList");
		DetailCom = (UI_DetailCom)(object)((GComponent)this).GetChild("DetailCom");
		mailTitle = (GRichTextField)((GComponent)this).GetChild("mailTitle");
		string id3 = "ui://edr57v33oipit".Replace("ui://", "") + "-" + ((GObject)mailTitle).id;
		((GObject)mailTitle).text = LanguagesManager.GetDesc(id3);
		annexTitle = (GRichTextField)((GComponent)this).GetChild("annexTitle");
		string id4 = "ui://edr57v33oipit".Replace("ui://", "") + "-" + ((GObject)annexTitle).id;
		((GObject)annexTitle).text = LanguagesManager.GetDesc(id4);
		allReceive = (UI_allReceive)(object)((GComponent)this).GetChild("allReceive");
		allDelete = (UI_remove)(object)((GComponent)this).GetChild("allDelete");
		delete = (UI_delete)(object)((GComponent)this).GetChild("delete");
		receive = (UI_receive)(object)((GComponent)this).GetChild("receive");
		tip = (GRichTextField)((GComponent)this).GetChild("tip");
		string id5 = "ui://edr57v33oipit".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id5);
		getTips = (GList)((GComponent)this).GetChild("getTips");
		mailGroup = (GGroup)((GComponent)this).GetChild("mailGroup");
		messageGroup = (UI_com_MailPanelMessageGroup)(object)((GComponent)this).GetChild("messageGroup");
		Tip = (UI_Tip)(object)((GComponent)this).GetChild("Tip");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t3 = ((GComponent)this).GetTransition("t3");
		t4 = ((GComponent)this).GetTransition("t4");
	}

	private void RenderMailListItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		ClientMail clientMail = FGUIManager.Instance.MailsList[index];
		SetMailType(asButton, clientMail);
		((GComponent)asButton).GetChild("title").visible = true;
		((GComponent)asButton).GetChild("time").visible = true;
		((GComponent)asButton).GetChild("validity").visible = true;
		if (clientMail.Status == MailStatus.Unread)
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 0;
			ChangeLable(asButton, index);
		}
		else
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 1;
			ChangeLable(asButton, index);
			((GObject)((GComponent)asButton).GetChild("icon2").asLoader).grayed = !clientMail.HasPayloads;
		}
		GLoader asLoader = ((GComponent)asButton).GetChild("icon2").asLoader;
		if (clientMail.HasPayloads)
		{
			string text = "icon_main_gift";
			if (clientMail.Status == MailStatus.Claimed)
			{
				((GObject)asLoader).grayed = true;
				text = "icon_main_mails";
				((GComponent)asButton).GetChild("redNote").visible = false;
			}
			else
			{
				((GObject)asLoader).grayed = false;
				((GComponent)asButton).GetChild("redNote").visible = true;
			}
			asLoader.url = "ui://Mail/" + text;
		}
		else
		{
			((GComponent)asButton).GetChild("redNote").visible = false;
			((GObject)asLoader).grayed = clientMail.Status != MailStatus.Unread;
			asLoader.url = "ui://Mail/icon_main_mails";
		}
		((GObject)asButton).onClick.Add(_callback);
	}

	private void MailListUpdate(int num)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		FGUIManager.Instance.GetMails();
		mailList.SetVirtual();
		mailList.itemRenderer = new ListItemRenderer(RenderMailListItem);
		mailList.numItems = num;
		bool grayed = true;
		foreach (ClientMail mails in FGUIManager.Instance.MailsList)
		{
			if (mails.Payloads.Count > 0 && mails.Status != MailStatus.Claimed)
			{
				grayed = false;
				break;
			}
		}
		((GObject)allReceive).grayed = grayed;
		RefreshTabRedNote();
	}

	private void GoodListUpdate(int num)
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		for (int i = 0; i < num; i++)
		{
			annexList.AddItemFromPool("ui://edr57v33oipip");
			GButton asButton = ((GComponent)annexList).GetChildAt(i).asButton;
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, FGUIManager.Instance.MailsList[mailList.selectedIndex].Payloads[i].ItemId, null, "", frameVisible: false);
			((GComponent)asButton).GetChild("title").text = $"+{FGUIManager.Instance.MailsList[mailList.selectedIndex].Payloads[i].Qty}";
			int index = i;
			((GObject)((GComponent)asButton).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(FGUIManager.Instance.MailsList[mailList.selectedIndex].Payloads[index].ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		}
		((GObject)annexList).grayed = FGUIManager.Instance.MailsList[mailList.selectedIndex].Status == MailStatus.Claimed;
	}

	private void DetailUpdate()
	{
		if (mailList.selectedIndex < 0)
		{
			((GObject)receive).visible = false;
			((GObject)delete).visible = false;
			return;
		}
		ClientMail clientMail = FGUIManager.Instance.MailsList[mailList.selectedIndex];
		if (MailIsInInternal(clientMail))
		{
			((GObject)receive).visible = false;
			((GObject)delete).visible = false;
			return;
		}
		MailEmpty.selectedIndex = 0;
		((GObject)mailTitle).text = TranslateMailTemplate(clientMail.Title);
		((GObject)DetailCom.detail).text = TranslateMailTemplate(clientMail.Content);
		annexList.RemoveChildrenToPool();
		if (clientMail.HasPayloads)
		{
			Status.selectedIndex = 1;
			if (clientMail.Status != MailStatus.Claimed)
			{
				GoodListUpdate(clientMail.Payloads.Count);
				((GObject)receive).visible = true;
				((GObject)delete).visible = false;
			}
			else
			{
				GoodListUpdate(clientMail.Payloads.Count);
				((GObject)receive).visible = false;
				((GObject)delete).visible = true;
			}
		}
		else
		{
			Status.selectedIndex = 0;
			((GObject)receive).visible = false;
			((GObject)delete).visible = true;
		}
	}

	private static string TranslateMailTemplate(string content)
	{
		if (content.Contains("##"))
		{
			string[] array = content.Split(new string[1] { "##" }, StringSplitOptions.None);
			string text = "";
			string text2 = "";
			string id = "";
			List<string> list = new List<string>();
			if (array.Length > 1 && array[1] == "AutoShipOrderMail_Content")
			{
				string desc = LanguagesManager.GetDesc(array[1]);
				string arg = array[2];
				string raw = array[3];
				raw = ((!HotUpdateProcess.Instance.IsRegionOutCN) ? $"￥{NumericParser.Float(raw) / 100f:F2}" : $"${NumericParser.Float(raw) / 100f:F2}");
				string text3 = array[4];
				if (string.IsNullOrEmpty(text3))
				{
					return string.Format(desc, arg, raw, "");
				}
				return string.Format(desc, arg, raw, LanguagesManager.ParseItemDictionary(JsonHelper.ToObject<Dictionary<string, int>>(text3)));
			}
			for (int i = 0; i < array.Length; i++)
			{
				string text4 = array[i];
				switch (i)
				{
				case 0:
					text = text4;
					continue;
				case 1:
					id = text4;
					continue;
				}
				if (i == array.Length - 1)
				{
					text2 = text4;
				}
				else
				{
					list.Add(LanguagesManager.GetDesc(text4));
				}
			}
			if (list.Count > 0)
			{
				string text5 = text;
				string desc2 = LanguagesManager.GetDesc(id);
				object[] args = list.ToArray();
				return text5 + string.Format(desc2, args) + text2;
			}
			return text + LanguagesManager.GetDesc(id) + text2;
		}
		return content;
	}

	private void SetMailType(GButton mailBtn, ClientMail mail)
	{
		Controller controller = ((GComponent)mailBtn).GetController("Type");
		if (MailIsInInternal(mail))
		{
			controller.SetSelectedIndex(1);
			((GObject)mailBtn).touchable = false;
		}
		else
		{
			controller.SetSelectedIndex(0);
			((GObject)mailBtn).touchable = true;
		}
	}

	private static bool MailIsInInternal(Shift.Legion.Common.Models.Mail mail)
	{
		return mail.Title == "###";
	}

	private void AllGet()
	{
		GameManagers.Instance.MailManager.ClaimAllMailsPayloads(delegate
		{
			MailListUpdate(FGUIManager.Instance.MailsList.Count);
			FGUIManager.Instance.UpdateMailBtnNote();
			RefreshTabRedNote();
			DetailUpdate();
		});
	}

	private void Get()
	{
		GameManagers.Instance.MailManager.ClaimMailPayloads(FGUIManager.Instance.MailsList[mailList.selectedIndex].Id, delegate
		{
			MailListUpdate(FGUIManager.Instance.MailsList.Count);
			DetailUpdate();
			if (mailList.selectedIndex < mailList.numItems - 1)
			{
				GList obj = mailList;
				int selectedIndex = obj.selectedIndex;
				obj.selectedIndex = selectedIndex + 1;
				if (!((GComponent)mailList).scrollPane.IsChildInView(((GComponent)mailList).GetChildAt(mailList.ItemIndexToChildIndex(mailList.selectedIndex))))
				{
					mailList.ScrollToView(mailList.selectedIndex, true);
				}
			}
			else
			{
				for (int i = 0; i < FGUIManager.Instance.MailsList.Count; i++)
				{
					if (FGUIManager.Instance.MailsList[i].Status != MailStatus.Claimed)
					{
						mailList.selectedIndex = i;
						break;
					}
					if (i == FGUIManager.Instance.MailsList.Count - 1)
					{
						mailList.selectedIndex = i;
					}
				}
				mailList.ScrollToView(mailList.selectedIndex, true);
			}
			if (FGUIManager.Instance.MailsList[mailList.selectedIndex].Status == MailStatus.Unread)
			{
				GameManagers.Instance.MailManager.MarkMailAsRead(FGUIManager.Instance.MailsList[mailList.selectedIndex].Id);
			}
			MailListUpdate(FGUIManager.Instance.MailsList.Count);
			FGUIManager.Instance.UpdateMailBtnNote();
			RefreshTabRedNote();
			DetailUpdate();
		});
	}

	private void Delete()
	{
		int selectedIndex = mailList.selectedIndex;
		GameManagers.Instance.MailManager.DeleteMail(FGUIManager.Instance.MailsList[mailList.selectedIndex].Id);
		FGUIManager.Instance.GetMails();
		if (FGUIManager.Instance.MailsList.Count != 0)
		{
			if (selectedIndex <= FGUIManager.Instance.MailsList.Count - 1)
			{
				mailList.selectedIndex = selectedIndex;
			}
			else
			{
				mailList.selectedIndex = FGUIManager.Instance.MailsList.Count - 1;
			}
			if (FGUIManager.Instance.MailsList[mailList.selectedIndex].Status == MailStatus.Unread)
			{
				GameManagers.Instance.MailManager.MarkMailAsRead(FGUIManager.Instance.MailsList[mailList.selectedIndex].Id);
			}
			DetailUpdate();
		}
		else
		{
			ClearRight();
		}
		MailListUpdate(FGUIManager.Instance.MailsList.Count);
		mailList.ScrollToView(mailList.selectedIndex);
	}

	private void AllDelete()
	{
		((GObject)Tip).visible = true;
	}

	private void CloseMail()
	{
		End();
	}

	private void CloseTtp()
	{
		((GObject)Tip).visible = false;
	}

	private void No()
	{
		((GObject)Tip).visible = false;
	}

	private void Yes()
	{
		if (FGUIManager.Instance.MailsList.Count <= 0)
		{
			return;
		}
		if (mailList.selectedIndex < 0 || mailList.selectedIndex > FGUIManager.Instance.MailsList.Count - 1)
		{
			mailList.selectedIndex = 0;
		}
		if (mailList.numItems != 0)
		{
			int num = -1;
			if (FGUIManager.Instance.MailsList[mailList.selectedIndex].Status != MailStatus.Claimed)
			{
				num = FGUIManager.Instance.MailsList[mailList.selectedIndex].Id;
			}
			GameManagers.Instance.MailManager.DeleteAllMails();
			FGUIManager.Instance.GetMails();
			MailListUpdate(FGUIManager.Instance.MailsList.Count);
			if (FGUIManager.Instance.MailsList.Count > 0)
			{
				if (num != -1)
				{
					for (int i = 0; i < FGUIManager.Instance.MailsList.Count; i++)
					{
						if (FGUIManager.Instance.MailsList[i].Id == num)
						{
							mailList.selectedIndex = i;
						}
					}
				}
				else
				{
					mailList.selectedIndex = 0;
				}
				DetailUpdate();
			}
			else
			{
				ClearRight();
			}
		}
		((GObject)Tip).visible = false;
	}

	private void SelectMail()
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		if (FGUIManager.Instance.MailsList[mailList.selectedIndex].Status == MailStatus.Unread)
		{
			GameManagers.Instance.MailManager.MarkMailAsRead(FGUIManager.Instance.MailsList[mailList.selectedIndex].Id);
		}
		mailList.itemRenderer = new ListItemRenderer(RenderMailListItem);
		mailList.numItems = FGUIManager.Instance.MailsList.Count;
		DetailUpdate();
		FGUIManager.Instance.UpdateMailBtnNote();
		RefreshTabRedNote();
	}

	private void ClearRight()
	{
		((GObject)DetailCom.detail).text = "";
		annexList.RemoveChildrenToPool();
		Status.selectedIndex = 2;
		MailEmpty.selectedIndex = 1;
	}

	private void ChangeLable(GButton button, int index)
	{
		TimeSpan timeSpan = FGUIManager.Instance.MailsList[index].ExpireTime - DateTimeHelper.Now;
		ClientMail clientMail = FGUIManager.Instance.MailsList[index];
		((GObject)((GComponent)button).GetChild("title").asRichTextField).text = TranslateMailTemplate(FGUIManager.Instance.MailsList[index].Title);
		((GObject)((GComponent)button).GetChild("time").asRichTextField).text = FGUIManager.Instance.MailsList[index].CreatedTime.ToString("d");
		((GObject)((GComponent)button).GetChild("validity").asRichTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText423") + " " + timeSpan.Days + LanguagesManager.GetDesc("CsharpCodeZhTcText228");
	}

	private void End()
	{
		TryDeleteEmptySessions();
		annexList.RemoveChildrenToPool();
		mailList.numItems = 0;
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		((GObject)exit).onClick.Add(new EventCallback0(CloseMail));
		((GObject)receive).onClick.Add(new EventCallback0(Get));
		((GObject)delete).onClick.Add(new EventCallback0(Delete));
		((GObject)allReceive).onClick.Add(new EventCallback0(AllGet));
		((GObject)allDelete).onClick.Add(new EventCallback0(AllDelete));
		((GObject)Tip.close).onClick.Add(new EventCallback0(CloseTtp));
		((GObject)Tip.no).onClick.Add(new EventCallback0(No));
		((GObject)Tip.yes).onClick.Add(new EventCallback0(Yes));
		((GObject)messageGroup.newChat).onClick.Set(new EventCallback0(OnClickOpenMailFriendsPanel));
		tabType.onChanged.Set(new EventCallback0(OnTabTypeChange));
		((GObject)messageGroup.MessageContent.send).onClick.Set(new EventCallback0(OnClickSendMessage));
		GameManagers.Instance.Messenger.AddListener<FriendsChatSession>("FRIENDS_CHAT_SESSION_UPDATE", OnFriendsChatSessionUpdate);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		((GObject)exit).onClick.Remove(new EventCallback0(CloseMail));
		((GObject)receive).onClick.Remove(new EventCallback0(Get));
		((GObject)delete).onClick.Remove(new EventCallback0(Delete));
		((GObject)allReceive).onClick.Remove(new EventCallback0(AllGet));
		((GObject)allDelete).onClick.Remove(new EventCallback0(AllDelete));
		((GObject)Tip.close).onClick.Remove(new EventCallback0(CloseTtp));
		((GObject)Tip.no).onClick.Remove(new EventCallback0(No));
		((GObject)Tip.yes).onClick.Remove(new EventCallback0(Yes));
		((GObject)messageGroup.newChat).onClick.Clear();
		tabType.onChanged.Clear();
		((GObject)messageGroup.MessageContent.send).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<FriendsChatSession>("FRIENDS_CHAT_SESSION_UPDATE", OnFriendsChatSessionUpdate);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_callback = new EventCallback0(SelectMail);
		((GObject)Tip).visible = false;
		((GObject)EmptySlot).visible = false;
		FGUIManager.Instance.GetMails();
		MailListUpdate(FGUIManager.Instance.MailsList.Count);
		if (FGUIManager.Instance.MailsList.Count != 0)
		{
			mailList.selectedIndex = 0;
			SelectMail();
		}
		else
		{
			ClearRight();
		}
		int defaultFriendsSession = -1;
		if (parameters.TryGetValue("ChatWithFriend", out var value))
		{
			defaultFriendsSession = (int)value;
		}
		InitFriendsChat(defaultFriendsSession);
		if (parameters.TryGetValue("DefaultTab", out value))
		{
			int selectedIndex = (int)value;
			tabType.SetSelectedIndex(selectedIndex);
		}
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

	private void InitFriendsChat(int defaultFriendsSession)
	{
		_viewModels = new Dictionary<int, List<ChatViewModel>>();
		_needRefresh = false;
		if (defaultFriendsSession > 0)
		{
			OnChooseFriends(defaultFriendsSession);
		}
		else
		{
			RefreshFriendsChatSessionList();
		}
	}

	private void RefreshFriendsChatSessionList()
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		GameManagers.Instance.FriendsChatManager.ResortSessions();
		List<FriendsChatSession> allSessions = GameManagers.Instance.FriendsChatManager.GetAll();
		bool flag = allSessions.Count <= 0;
		bool flag2 = _currentSession == null;
		List<UserInfo> friendsInfos = GameManagers.Instance.FriendsManager.FriendsList;
		messageGroup.MessageEmpty.SetSelectedIndex(flag ? 1 : 0);
		messageGroup.MessageContent.Type.SetSelectedIndex(flag ? 2 : (flag2 ? 1 : 0));
		messageGroup.SessionList.SetVirtual();
		messageGroup.SessionList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Expected O, but got Unknown
			UI_com_UserMessage uI_com_UserMessage = (UI_com_UserMessage)(object)item;
			FriendsChatSession session = allSessions[index];
			bool flag3 = _currentSession == session;
			uI_com_UserMessage.state.SetSelectedIndex(flag3 ? 2 : (session.HasUnreadMessage ? 1 : 0));
			if (((GObject)uI_com_UserMessage).data == null || (int)((GObject)uI_com_UserMessage).data != session.FriendsId)
			{
				((GObject)uI_com_UserMessage).data = session.FriendsId;
				UI_com_ShipAvatar uI_com_ShipAvatar = (UI_com_ShipAvatar)(object)uI_com_UserMessage.Avatar;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, session.FriendsId, uI_com_ShipAvatar.HeadPortrait.icon, uI_com_UserMessage.name));
				FGUIManager.Instance.GetUserMedal(session.FriendsId, uI_com_UserMessage.MedalList);
				UserInfo userInfo = friendsInfos.Find((UserInfo x) => x.UserId == session.FriendsId);
				if (userInfo != null)
				{
					((GObject)uI_com_UserMessage.level).text = userInfo.UserLevel.ToString();
				}
				else
				{
					((GObject)uI_com_UserMessage.level).text = "??";
				}
			}
			((GObject)uI_com_UserMessage).onClick.Set((EventCallback0)delegate
			{
				_currentSession = session;
				RefreshFriendsChatSessionList();
				RefreshFriendsChatContent();
				session.ReadMessage();
			});
		};
		messageGroup.SessionList.numItems = allSessions.Count;
	}

	private void RefreshFriendsChatContent()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		if (_currentSession == null)
		{
			return;
		}
		List<ChatViewModel> models = GetChatViewModels(_currentSession);
		messageGroup.MessageContent.MessageView.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Expected O, but got Unknown
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Expected O, but got Unknown
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Expected O, but got Unknown
			//IL_0296: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a0: Expected O, but got Unknown
			UI_com_Message btn = (UI_com_Message)(object)item;
			ChatViewModel chatViewModel = models[index];
			btn.type.SetSelectedIndex((int)chatViewModel.Type);
			if (chatViewModel.Type == ChatViewType.Friends)
			{
				((GObject)btn.ChatPlayer.MessageFriends).text = ProcessChatLogContent(chatViewModel.Log.Content);
				FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetUserNickName(chatViewModel.Log.Sender, btn.NameFriends));
				DateTime localDateTime = DateTimeHelper.ParseMillisecondsTimeStamp(chatViewModel.Log.Timestamp).LocalDateTime;
				((GObject)btn.timeFriends).text = localDateTime.ToString("MM-dd HH:mm");
				((GObject)btn.bg).height = ((GObject)btn.ChatPlayer.MessageFriends).height + 62f;
				btn.ChatPlayer.isNew.SetSelectedIndex(chatViewModel.IsNew ? 1 : 0);
				((GObject)btn.ChatPlayer).onTouchBegin.Set((EventCallback0)delegate
				{
					OnTouchBegin(btn);
				});
				((GObject)btn.ChatPlayer).onTouchEnd.Set((EventCallback0)delegate
				{
					OnTouchEnd(btn);
				});
			}
			else if (chatViewModel.Type == ChatViewType.Self)
			{
				((GObject)btn.ChatSelf.MessageSelf).text = ProcessChatLogContent(chatViewModel.Log.Content);
				FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetUserNickName(chatViewModel.Log.Sender, btn.NameSelf));
				DateTime localDateTime2 = DateTimeHelper.ParseMillisecondsTimeStamp(chatViewModel.Log.Timestamp).LocalDateTime;
				((GObject)btn.timeSelf).text = localDateTime2.ToString("MM-dd HH:mm");
				((GObject)btn.bg).height = ((GObject)btn.ChatSelf.MessageSelf).height + 62f;
				btn.ChatSelf.isNew.SetSelectedIndex(chatViewModel.IsNew ? 1 : 0);
				((GObject)btn.ChatSelf).onTouchBegin.Set((EventCallback0)delegate
				{
					OnTouchBegin(btn);
				});
				((GObject)btn.ChatSelf).onTouchEnd.Set((EventCallback0)delegate
				{
					OnTouchEnd(btn);
				});
			}
		};
		messageGroup.MessageContent.MessageView.numItems = models.Count;
		((GComponent)messageGroup.MessageContent.MessageView).scrollPane.SetPercY(1f, false);
	}

	private void OnFriendsChatSessionUpdate(FriendsChatSession session)
	{
		if (_currentSession == session)
		{
			session.ReadMessage();
		}
		RefreshFriendsChatSessionList();
		RefreshFriendsChatContent();
		RefreshTabRedNote();
	}

	private List<ChatViewModel> GetChatViewModels(FriendsChatSession session)
	{
		int friendsId = session.FriendsId;
		if (!_viewModels.ContainsKey(friendsId))
		{
			List<ChatViewModel> list = new List<ChatViewModel>();
			_viewModels[friendsId] = list;
			int userId = GameController.Contexts.gameState.user.value.UserId;
			bool flag = false;
			bool flag2 = false;
			foreach (ChatLog chatLog2 in session.ChatLogs)
			{
				bool flag3 = chatLog2.Status == eMsgStatus.Read || chatLog2.Sender == userId;
				if (!flag && flag2 && !flag3)
				{
					list.Add(new ChatViewModel
					{
						Type = ChatViewType.Line
					});
					flag = true;
				}
				list.Add(new ChatViewModel
				{
					Type = ((chatLog2.Sender != session.FriendsId) ? ChatViewType.Self : ChatViewType.Friends),
					Log = chatLog2,
					IsNew = !flag3
				});
				flag2 = flag3;
			}
		}
		List<ChatViewModel> list2 = _viewModels[friendsId];
		int num = -1;
		if (list2.Count > 0)
		{
			ChatViewModel lastChatModel = list2[list2.Count - 1];
			num = session.ChatLogs.FindIndex((ChatLog x) => x.Guid == lastChatModel.Log.Guid);
			if (num < 0)
			{
				ILRuntimeDebug.LogError("Unable to found logs, reload all");
				_viewModels.Clear();
				num = -1;
			}
		}
		for (int num2 = num + 1; num2 < session.ChatLogs.Count; num2++)
		{
			ChatLog chatLog = session.ChatLogs[num2];
			list2.Add(new ChatViewModel
			{
				Type = ((chatLog.Sender != session.FriendsId) ? ChatViewType.Self : ChatViewType.Friends),
				Log = chatLog,
				IsNew = false
			});
		}
		return _viewModels[friendsId];
	}

	private void OnClickOpenMailFriendsPanel()
	{
		UnityUiService.Instance.OpenPanel(UI_MailFriendsPanel.Name, new Dictionary<string, object> { 
		{
			"ChooseChatCallback",
			new Action<int>(OnChooseFriends)
		} });
	}

	private void OnChooseFriends(int friendsId)
	{
		List<FriendsChatSession> all = GameManagers.Instance.FriendsChatManager.GetAll();
		FriendsChatSession friendsChatSession = all.Find((FriendsChatSession x) => x.FriendsId == friendsId);
		if (friendsChatSession == null)
		{
			friendsChatSession = GameManagers.Instance.FriendsChatManager.GetChatSession(friendsId);
		}
		_currentSession = friendsChatSession;
		RefreshFriendsChatSessionList();
		RefreshFriendsChatContent();
	}

	private void OnClickSendMessage()
	{
		string text = ((GObject)messageGroup.MessageContent.InputText).text;
		if (!string.IsNullOrEmpty(text))
		{
			((GObject)messageGroup.MessageContent.InputText).text = string.Empty;
			_currentSession.SendMessage(text);
		}
	}

	private bool TryDeleteEmptySessions()
	{
		List<FriendsChatSession> all = GameManagers.Instance.FriendsChatManager.GetAll();
		if (_currentSession != null && _currentSession.IsEmpty())
		{
			_currentSession = null;
		}
		bool result = false;
		foreach (FriendsChatSession item in all)
		{
			if (item.IsEmpty())
			{
				GameManagers.Instance.FriendsChatManager.DeleteFriendsChat(item.FriendsId);
				result = true;
			}
		}
		return result;
	}

	private void OnTabTypeChange()
	{
		if (tabType.selectedIndex == 0)
		{
			if (TryDeleteEmptySessions())
			{
				_needRefresh = true;
			}
		}
		else if (tabType.selectedIndex == 1 && _needRefresh)
		{
			_needRefresh = false;
			RefreshFriendsChatSessionList();
		}
	}

	private void RefreshTabRedNote()
	{
		List<ClientMail> mailsList = FGUIManager.Instance.MailsList;
		bool visible = mailsList.Any((ClientMail x) => x.Status == MailStatus.Unread);
		bool hasAnyUnreadMessage = GameManagers.Instance.FriendsChatManager.HasAnyUnreadMessage;
		((GObject)((UI_messageTabBtnBack)(object)((GComponent)TabListBack).GetChildAt(0)).note).visible = visible;
		((GObject)((UI_messageTabBtn)(object)((GComponent)TabListFront).GetChildAt(0)).note).visible = visible;
		((GObject)((UI_messageTabBtnBack)(object)((GComponent)TabListBack).GetChildAt(1)).note).visible = hasAnyUnreadMessage;
		((GObject)((UI_messageTabBtn)(object)((GComponent)TabListFront).GetChildAt(1)).note).visible = hasAnyUnreadMessage;
	}

	private void OnTouchBegin(UI_com_Message item)
	{
		_longPressItem = item;
		_longPressCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(StartLongPressDetect(item));
	}

	private void OnTouchEnd(UI_com_Message item)
	{
		if (item == _longPressItem)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_longPressCoroutine);
			_longPressCoroutine = null;
		}
		_longPressItem = null;
	}

	private IEnumerator StartLongPressDetect(UI_com_Message item)
	{
		yield return (object)new WaitForSeconds(0.5f);
		if (!((GObject)this).isDisposed)
		{
			_longPressItem = null;
			StartCopyProcess(item);
		}
	}

	private void StartCopyProcess(UI_com_Message item)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		_copyProcessItem = item;
		GetCopyInfos(item, out var textField, out var isCopy);
		_copyProcessItem.isCopy.SetSelectedIndex(1);
		isCopy.SetSelectedIndex(1);
		((GObject)_copyProcessItem.Copy).onClick.Set((EventCallback0)delegate
		{
			GUIUtility.systemCopyBuffer = ((GObject)textField).text;
			"CsharpCodeZhTcText83".ToLanguage().ToTip();
			EndCopyProcess();
		});
	}

	private static void GetCopyInfos(UI_com_Message item, out GTextField textField, out Controller isCopy)
	{
		textField = null;
		isCopy = null;
		switch ((ChatViewType)item.type.selectedIndex)
		{
		case ChatViewType.Self:
			textField = item.ChatSelf.MessageSelf;
			isCopy = item.ChatSelf.isCopy;
			break;
		case ChatViewType.Friends:
			textField = item.ChatPlayer.MessageFriends;
			isCopy = item.ChatPlayer.isCopy;
			break;
		}
	}

	private void EndCopyProcess()
	{
		if (_copyProcessItem != null)
		{
			((GObject)_copyProcessItem.Copy).onClick.Clear();
			GetCopyInfos(_copyProcessItem, out var _, out var isCopy);
			_copyProcessItem.isCopy.SetSelectedIndex(0);
			isCopy.SetSelectedIndex(0);
			_copyProcessItem = null;
		}
	}

	private static string ProcessChatLogContent(string content)
	{
		if (content == "##CsharpCodeZhTcFriendGreeting##")
		{
			return "CsharpCodeZhTcFriendGreeting".ToLanguage();
		}
		return content;
	}

	public static string ParseServerSpecialStringKey(string content)
	{
		Match match = Regex.Match(content, "##(/\\w+)##");
		if (match.Success)
		{
			string value = match.Groups[1].Value;
			return value.ToLanguage();
		}
		return content;
	}
}
