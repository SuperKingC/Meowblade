using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Archive;
using Shift.Legion.ClientApi.Protocol.Mailing;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class MailManager : Manager
{
	public static Action<int> SendMarkMailAsReadRequest;

	public static Action SendMarkAllMailsAsReadRequest;

	public static Action<int> SendDeleteMailRequest;

	public static Action SendDeleteAllMailsRequest;

	public Dictionary<int, ClientMail> Mails { get; set; } = new Dictionary<int, ClientMail>();

	public MailManager(GameManagers managers)
		: base(managers)
	{
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<List<ClientMail>>("MAILS_DATA_PROCESSED", OnMailsReceived);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<List<ClientMail>>("MAILS_DATA_PROCESSED", OnMailsReceived);
	}

	public override Task Init()
	{
		return null;
	}

	public void HandlePulledMails(List<Shift.Legion.ClientApi.Protocol.Mailing.Mail> mails)
	{
		if (mails == null || mails.Count == 0)
		{
			return;
		}
		List<ClientMail> list = new List<ClientMail>();
		foreach (Shift.Legion.ClientApi.Protocol.Mailing.Mail mail in mails)
		{
			ClientMail clientMail = new ClientMail
			{
				Id = mail.Id,
				Status = (MailStatus)mail.Status,
				Title = mail.Title,
				Content = mail.Content,
				CreatedTime = DateTimeHelper.Parse(mail.CreatedTime),
				ExpireTime = DateTimeHelper.Parse(mail.ExpireTime),
				HasPayloads = mail.HasPayloads,
				Payloads = new List<Bonus>()
			};
			foreach (ProtocolBonus payload in mail.Payloads)
			{
				clientMail.Payloads.Add(Bonus.Get(payload.ItemId, payload.Qty));
			}
			list.Add(clientMail);
		}
		GameManagers.Instance.Messenger.Broadcast("MAILS_DATA_PROCESSED", list);
	}

	public void MarkMailAsRead(int mailId)
	{
		SendMarkMailAsReadRequest(mailId);
		if (Mails.TryGetValue(mailId, out var value))
		{
			value.Status = MailStatus.Read;
		}
	}

	public void MarkAllMailsAsRead()
	{
		SendMarkAllMailsAsReadRequest();
		int[] array = Mails.Keys.ToArray();
		foreach (int key in array)
		{
			ClientMail clientMail = Mails[key];
			if (clientMail.Status == MailStatus.Unread)
			{
				clientMail.Status = MailStatus.Read;
			}
		}
	}

	public void DeleteMail(int mailId)
	{
		if (Mails.TryGetValue(mailId, out var value) && ((value.Status != MailStatus.Read && value.Status != MailStatus.Unread) || !value.HasPayloads || value.Payloads.Count <= 0))
		{
			SendDeleteMailRequest(mailId);
			Mails.Remove(mailId);
		}
	}

	public void DeleteAllMails()
	{
		SendDeleteAllMailsRequest();
		List<int> list = new List<int>();
		foreach (ClientMail value in Mails.Values)
		{
			if (value.Status != MailStatus.Unread && (!value.HasPayloads || value.Status != MailStatus.Read))
			{
				list.Add(value.Id);
			}
		}
		foreach (int item in list)
		{
			Mails.Remove(item);
		}
	}

	public void ClaimMailPayloads(int mailId, Action uiCallback = null)
	{
		ILRequestHelper<MailOperateResponse>.Request((EventContext)null, (Func<Task<MailOperateResponse>>)(() => GameController.Contexts.Service<INetworkService>().ClaimMailPayload(mailId)), (Action<MailOperateResponse>)delegate(MailOperateResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (Mails.TryGetValue(mailId, out var value) && value.HasPayloads && (value.Status == MailStatus.Unread || value.Status == MailStatus.Read))
				{
					value.Status = MailStatus.Claimed;
					foreach (Bonus payload in value.Payloads)
					{
						BroadcastClaimBonus(payload);
					}
				}
				List<StockChangeRecord> list = new List<StockChangeRecord>();
				foreach (StockChangeRecord stockChangeRecord in response.StockChangeRecords)
				{
					if (Shift.Legion.Common.Models.Item.ItemType(stockChangeRecord.ItemId) == 12)
					{
						Bonus.Get(stockChangeRecord.ItemId, stockChangeRecord.Offset).Claim(GameManagers.Instance, null, null, forceClaim: true, broadcastInform: false);
					}
					else
					{
						list.Add(stockChangeRecord);
					}
				}
				GameManagers.Instance.StockController.ReadStockChangeRecords(list);
				uiCallback?.Invoke();
			}
		});
	}

	public void ClaimAllMailsPayloads(Action uiCallback = null)
	{
		ILRequestHelper<MailOperateResponse>.Request((EventContext)null, (Func<Task<MailOperateResponse>>)(() => GameController.Contexts.Service<INetworkService>().ClaimAllMailsPayload()), (Action<MailOperateResponse>)delegate(MailOperateResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				int[] array = Mails.Keys.ToArray();
				foreach (int key in array)
				{
					ClientMail clientMail = Mails[key];
					if (clientMail.HasPayloads && (clientMail.Status == MailStatus.Unread || clientMail.Status == MailStatus.Read))
					{
						clientMail.Status = MailStatus.Claimed;
						foreach (Bonus payload in clientMail.Payloads)
						{
							BroadcastClaimBonus(payload);
						}
					}
				}
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				uiCallback?.Invoke();
			}
		});
	}

	private static void BroadcastClaimBonus(Bonus bonus)
	{
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}{1}{2}", SchemaIndexHelper.GetNameById(GameManagers.Instance, bonus.ItemId), (bonus.Qty >= 0) ? "+" : "", bonus.Qty) }, 999, arg3: false);
	}

	public ClientMail GetNextMail(ClientMail mail)
	{
		ClientMail result = null;
		foreach (int key in Mails.Keys)
		{
			result = Mails[key];
			if (key < mail.Id)
			{
				break;
			}
		}
		return result;
	}

	public ClientMail GetNextMailWithPayloads(ClientMail mail)
	{
		foreach (ClientMail value in Mails.Values)
		{
			if (value.HasPayloads && (value.Status == MailStatus.Read || value.Status == MailStatus.Unread))
			{
				return value;
			}
		}
		return GetNextMail(mail);
	}

	private void OnMailsReceived(List<ClientMail> mails)
	{
		foreach (ClientMail mail in mails)
		{
			if (Mails.ContainsKey(mail.Id))
			{
				Mails[mail.Id] = mail;
			}
			else
			{
				Mails.Add(mail.Id, mail);
			}
		}
		SortMails();
		Managers.Messenger.Broadcast("MAILS_RECEIVED", mails);
	}

	private void SortMails()
	{
		Mails = Mails.OrderByDescending((KeyValuePair<int, ClientMail> mailKv) => mailKv.Key).ToDictionary((KeyValuePair<int, ClientMail> mailKv) => mailKv.Key, (KeyValuePair<int, ClientMail> mailKv) => mailKv.Value);
	}
}
