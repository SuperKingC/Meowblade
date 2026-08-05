using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

namespace UI.AccountInfo;

public class UI_ChangeNamePanel : GComponent, IUiController
{
	public GGraph Mask;

	public GImage n1;

	public GGraph n10;

	public GTextInput nameInput;

	public GTextField stageNum;

	public GImage n9;

	public GImage n8;

	public UI_changeNameBtn changeNameBtn;

	public GLoader icon;

	public const string URL = "ui://b9yxt7u0gw2m25";

	public static string Name = "UI_ChangeNamePanel";

	public static string GetURL()
	{
		return "ui://b9yxt7u0gw2m25";
	}

	public static UI_ChangeNamePanel CreateInstance()
	{
		return (UI_ChangeNamePanel)(object)UIPackage.CreateObject("AccountInfo", "ChangeNamePanel");
	}

	public static UI_ChangeNamePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChangeNamePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0gw2m25", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n10 = (GGraph)((GComponent)this).GetChild("n10");
		nameInput = (GTextInput)((GComponent)this).GetChild("nameInput");
		string id = "ui://b9yxt7u0gw2m25".Replace("ui://", "") + "-" + ((GObject)nameInput).id + "-prompt";
		nameInput.promptText = LanguagesManager.GetDesc(id);
		stageNum = (GTextField)((GComponent)this).GetChild("stageNum");
		string id2 = "ui://b9yxt7u0gw2m25".Replace("ui://", "") + "-" + ((GObject)stageNum).id;
		((GObject)stageNum).text = LanguagesManager.GetDesc(id2);
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		changeNameBtn = (UI_changeNameBtn)(object)((GComponent)this).GetChild("changeNameBtn");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)changeNameBtn).onClick.Add(new EventCallback0(ConfirmAndChange));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)changeNameBtn).onClick.Remove(new EventCallback0(ConfirmAndChange));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
	}

	public void OnShow()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		GDEConfigurationData gDEConfigurationData = GDMgr.Get<GDEConfigurationData>("Profile_ChangeNicknameCost");
		Dictionary<string, int> source = JsonHelper.ToObject<Dictionary<string, int>>(gDEConfigurationData.Config);
		string itemid = source.First().Key;
		((GObject)icon).onClick.Set((EventCallback0)delegate
		{
			ItemTip(itemid);
		});
		FGUIManager.Instance.SetItemIconAndFrame(((GObject)icon).asLoader, itemid, null, "", frameVisible: false);
		int stock = GameManagers.Instance.StockController.GetStock(itemid);
		((GObject)stageNum).text = stock + "/" + source.First().Value;
		if (stock <= 0)
		{
			stageNum.color = Color.red;
			((GObject)changeNameBtn).enabled = false;
		}
		else
		{
			stageNum.color = Color.white;
			((GObject)changeNameBtn).enabled = true;
		}
	}

	private void ItemTip(string itemId)
	{
		FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private async void GetProfileChangeNickname()
	{
		((GObject)changeNameBtn).enabled = false;
		ProfileChangeNicknameResponse dic = await GameController.Contexts.Service<INetworkService>().GetProfileChangeNickname(((GObject)nameInput).text);
		((GObject)changeNameBtn).enabled = true;
		if (dic.Result)
		{
			Dictionary<string, int> cost = JsonHelper.ToObject<Dictionary<string, int>>(dic.CostItems);
			StockChangeRecord[] stockChangeRecords = new StockChangeRecord[cost.Count];
			int _changeRecordIndex = 0;
			foreach (KeyValuePair<string, int> bonus in cost)
			{
				stockChangeRecords[_changeRecordIndex++] = new StockChangeRecord
				{
					ItemId = bonus.Key,
					Offset = bonus.Value * -1,
					Context = 46,
					Type = 1
				};
			}
			List<string> tipList = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText94") };
			SharedMessenger.Broadcast("SHOW_TIPS", tipList, 1, arg3: false);
			GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
			User user = GameController.Contexts.gameState.user.value;
			user.Nickname = ((GObject)nameInput).text;
			GameLocalDataManager.SetSomeUserLocalData(_userLocalData: new GameLocalDataManager.UserLocalData
			{
				UserId = user.UserId,
				NickName = ((GObject)nameInput).text,
				ModifiedDate = GameController.Instance.GetServerTime()
			}, userId: user.UserId);
			SharedMessenger.Broadcast("REFRESH_USERNAME");
			SharedMessenger.Broadcast("USER_PROFILE_CHANGE");
			End();
		}
		else
		{
			ILRequestHelper.ShowErrorCode(dic.ErrorCode);
			if (81100004 == dic.ErrorCode)
			{
				((GObject)nameInput).text = dic.ValidNewNickName;
			}
		}
	}

	private void ConfirmAndChange()
	{
		GetProfileChangeNickname();
	}
}
