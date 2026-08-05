using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.Talent;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UI.GvGWorldMap3;
using UnityEngine;

namespace UI.GvGPlayerCommand3;

public class UI_main_PlayerCommand : GComponent, IUiController
{
	private class MessageCarousel
	{
		private readonly float _interval;

		public readonly GTextField TextField;

		private float MinX => 0f - ((GObject)TextField).width;

		private float MaxX => _interval + ((GObject)TextField).width;

		public MessageCarousel(GTextField textField, float interval)
		{
			TextField = textField;
			_interval = interval;
		}

		public void Move(float multiple)
		{
			if (((GObject)TextField).x <= MinX)
			{
				((GObject)TextField).x = MaxX;
				return;
			}
			GTextField textField = TextField;
			((GObject)textField).x = ((GObject)textField).x - 1f * multiple;
		}
	}

	public Controller Status;

	public GGraph Mask;

	public UI_com_CommandMessage Message;

	public UI_com_IssueCommand IssueCommand;

	public Transition ShowMessageDialog0;

	public const string URL = "ui://vheg8vabeai31";

	public static string Name = "UI_main_PlayerCommand";

	private int _islandId;

	private eIslandEvent _commandType;

	private string _message;

	private string _contributionPointAdd;

	private string _timerAdd;

	private SubTypeModel_PlayerCommand _commandConfig;

	private Coroutine _updateMessageX;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(0.03f);

	private MessageCarousel _firstMessage;

	private MessageCarousel _secondMessage;

	private float MessageInterval => ((GObject)IssueCommand.SelectedMessage).width / 2f;

	public static string GetURL()
	{
		return "ui://vheg8vabeai31";
	}

	public static UI_main_PlayerCommand CreateInstance()
	{
		return (UI_main_PlayerCommand)(object)UIPackage.CreateObject("GvGPlayerCommand3", "main_PlayerCommand");
	}

	public static UI_main_PlayerCommand CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_PlayerCommand).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Message = (UI_com_CommandMessage)(object)((GComponent)this).GetChild("Message");
		IssueCommand = (UI_com_IssueCommand)(object)((GComponent)this).GetChild("IssueCommand");
		ShowMessageDialog0 = ((GComponent)this).GetTransition("ShowMessageDialog0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		Message.Destroy();
		_commandConfig = null;
		if (_updateMessageX != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateMessageX);
		}
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_islandId = (parameters.TryGetValue("IslandId", out var value) ? ((int)value) : 0);
		Message.Init();
		Render();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)IssueCommand.NewMessage).onClick.Set(new EventCallback0(OpenCommandMessageMenu));
		((GObject)IssueCommand.Issue).onClick.Set(new EventCallback0(CreatePlayerCommand));
		IssueCommand.Commands.onClickItem.Set(new EventCallback1(OnCommandSelect));
		IssueCommand.ContributionPointsAdd.onClickItem.Set(new EventCallback1(OnContributionPointAddSelect));
		IssueCommand.TimeAdd.onClickItem.Set(new EventCallback1(OnTimerAddSelect));
		Message.RegisterUiEvent();
		UI_com_CommandMessage message = Message;
		message.CloseMessageMenu = (Action<bool>)Delegate.Combine(message.CloseMessageMenu, new Action<bool>(ChangeStatus));
		UI_com_CommandMessage message2 = Message;
		message2.ConfirmCommandMessage = (Action<string>)Delegate.Combine(message2.ConfirmCommandMessage, new Action<string>(ShowMessage));
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdatePlayerCommand = (Action<IEvent_PlayerCommand>)Delegate.Combine(instance.UpdatePlayerCommand, new Action<IEvent_PlayerCommand>(CloseUi));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)IssueCommand.NewMessage).onClick.Clear();
		((GObject)IssueCommand.Issue).onClick.Clear();
		IssueCommand.Commands.onClickItem.Clear();
		IssueCommand.ContributionPointsAdd.onClickItem.Clear();
		IssueCommand.TimeAdd.onClickItem.Clear();
		Message.UnregisterUiEvent();
		UI_com_CommandMessage message = Message;
		message.CloseMessageMenu = (Action<bool>)Delegate.Remove(message.CloseMessageMenu, new Action<bool>(ChangeStatus));
		UI_com_CommandMessage message2 = Message;
		message2.ConfirmCommandMessage = (Action<string>)Delegate.Remove(message2.ConfirmCommandMessage, new Action<string>(ShowMessage));
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdatePlayerCommand = (Action<IEvent_PlayerCommand>)Delegate.Remove(instance.UpdatePlayerCommand, new Action<IEvent_PlayerCommand>(CloseUi));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void ChangeStatus(bool twoMenus)
	{
		Status.selectedIndex = (twoMenus ? 1 : 0);
		if (twoMenus)
		{
			Message.Render(_commandType);
		}
	}

	private void OpenCommandMessageMenu()
	{
		if (Status.selectedIndex != 1)
		{
			ChangeStatus(twoMenus: true);
		}
	}

	private void Render()
	{
		_firstMessage = new MessageCarousel(IssueCommand.SelectedMessage.Text1, ((GObject)IssueCommand.SelectedMessage).width);
		_secondMessage = new MessageCarousel(IssueCommand.SelectedMessage.Text2, ((GObject)IssueCommand.SelectedMessage).width);
		((GObject)IssueCommand.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(_islandId).Name;
		AllCommandsInit();
		LoadPlayerCommandConfig();
		CalculateCost();
		ShowCommandEffect();
	}

	private void CreatePlayerCommand()
	{
		string text = ShowIssueCommandTip();
		if (string.IsNullOrEmpty(text))
		{
			IssueNewCommand();
		}
		else
		{
			text.ToLanguage().ToConfirmPopup(IssueNewCommand, null, (AlignType)0);
		}
	}

	private void IssueNewCommand()
	{
		if (string.IsNullOrEmpty(_message))
		{
			_message = "vheg8vabeai36-n4_eai3-prompt".ToLanguage();
		}
		Singleton<GvG3EventMissionManager>.Instance.CreatePlayerCommand((int)_commandType, int.Parse(_contributionPointAdd), int.Parse(_timerAdd), _message, _islandId, End);
	}

	private string ShowIssueCommandTip()
	{
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(_islandId);
		eGvGMode3IslandBelongStatus belongStatus = islandStateModel.GetBelongStatus();
		if ((_commandType == eIslandEvent.PlayerCommand_Defense || _commandType == eIslandEvent.PlayerCommand_Search) && belongStatus != eGvGMode3IslandBelongStatus.OwnSide)
		{
			return $"GvG3_{_commandType}_BelongingTip".ToLanguage();
		}
		if (islandStateModel.DetailInfo.CollectingGroup.Count <= 0 && _commandType == eIslandEvent.PlayerCommand_Search)
		{
			return $"GvG3_{_commandType}_NoResourcesTip".ToLanguage();
		}
		if (belongStatus == eGvGMode3IslandBelongStatus.OwnSide && _commandType == eIslandEvent.PlayerCommand_Attack)
		{
			return $"GvG3_{_commandType}_CanNotTip".ToLanguage();
		}
		return string.Empty;
	}

	private void CloseUi(IEvent_PlayerCommand command)
	{
		if (command == null)
		{
			End();
		}
		else if (command.UserId != GameController.Contexts.gameState.user.value.UserId)
		{
			ILRequestHelper.ShowMessage("GvG3_PlayerCommand_Issue_Tip1".ToLanguage());
			End();
		}
	}

	private void AllCommandsInit()
	{
		for (int i = 0; i < ((GComponent)IssueCommand.Commands).numChildren; i++)
		{
			if (((GComponent)IssueCommand.Commands).GetChildAt(i) is UI_btn_Command uI_btn_Command)
			{
				switch (i)
				{
				case 0:
					((GObject)uI_btn_Command).data = eIslandEvent.PlayerCommand_Defense;
					break;
				case 1:
					((GObject)uI_btn_Command).data = eIslandEvent.PlayerCommand_Attack;
					break;
				case 2:
					((GObject)uI_btn_Command).data = eIslandEvent.PlayerCommand_Search;
					break;
				}
			}
		}
		_commandType = eIslandEvent.PlayerCommand_Attack;
		IssueCommand.Commands.selectedIndex = 1;
		IssueCommand.CommandType.selectedIndex = 1;
		OnCommandChange();
	}

	private void OnCommandChange()
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		if (_commandType != eIslandEvent.PlayerCommand_Attack)
		{
			IssueCommand.buffIcon.selectedIndex = 0;
			return;
		}
		TalentEvent talents = Singleton<WorldStateManager>.Instance.Data.Talents;
		bool flag = talents.HasTalent<组织冒险1>() || talents.HasTalent<组织冒险2>();
		IssueCommand.buffIcon.selectedIndex = (flag ? 1 : 0);
		if (flag)
		{
			((GObject)IssueCommand.n35).onClick.Set(new EventCallback1(OnTalentBuffClick));
		}
	}

	private void OnTalentBuffClick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = ((GObject)context.sender).LocalToGlobal(Vector2.zero);
		val = ((GObject)this).GlobalToLocal(val);
		val += Vector2.down * 40f;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_ShowEfficiencyBuff.Name, new Dictionary<string, object>
		{
			{
				"Text",
				GetEfficiencyText()
			},
			{ "Pos", val }
		});
		context.StopPropagation();
	}

	private string GetEfficiencyText()
	{
		string text = "GvGModel3AttackCommandEfficiencyTitle".ToLanguage();
		TalentEvent talents = Singleton<WorldStateManager>.Instance.Data.Talents;
		if (talents.HasTalent<组织冒险1>())
		{
			text = text + Environment.NewLine + string.Format("GvGModel3AttackCommandEfficiency1".ToLanguage(), new object[1] { Convert.ToInt32(Mathf.Abs(TalentEvent.GetConfig<组织冒险1>().val * 100f)) });
		}
		if (talents.HasTalent<组织冒险2>())
		{
			text = text + Environment.NewLine + string.Format("GvGModel3AttackCommandEfficiency2".ToLanguage(), new object[1] { Convert.ToInt32(Mathf.Abs(TalentEvent.GetConfig<组织冒险2>().val * 100f)) });
		}
		return text;
	}

	private void ShowCommandEffect()
	{
		float num = _commandConfig.ContributionPointAdd[_contributionPointAdd];
		int num2 = _commandConfig.TimerAdd[_timerAdd];
		((GObject)IssueCommand.CommandEffect).text = string.Format("GvG3_PlayerCommand_Effect1".ToLanguage(), $"GvG3_{_commandType}".ToLanguage(), $"+{Mathf.RoundToInt(num * 100f)}", $"{num2 / 3600}");
	}

	private void CalculateCost()
	{
		int num = _commandConfig.TimerAdd[_timerAdd] / 3600;
		int multiple = int.Parse(_contributionPointAdd) * num;
		List<RItem> list = _commandConfig.BaseCost.ToRItemList(multiple);
		float num2 = 1f;
		if (_commandType == eIslandEvent.PlayerCommand_Attack)
		{
			TalentEvent talents = Singleton<WorldStateManager>.Instance.Data.Talents;
			if (talents.HasTalent<组织冒险1>())
			{
				num2 += TalentEvent.GetConfig<组织冒险1>().val;
			}
			if (talents.HasTalent<组织冒险2>())
			{
				num2 += TalentEvent.GetConfig<组织冒险2>().val;
			}
		}
		string itemId = string.Empty;
		int num3 = 0;
		using (List<RItem>.Enumerator enumerator = list.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				RItem current = enumerator.Current;
				itemId = current.ItemId;
				num3 += Mathf.RoundToInt((float)current.cnt * num2);
			}
		}
		if (string.IsNullOrEmpty(IssueCommand.CostIcon.url))
		{
			FGUIManager.Instance.SetItemIconAndFrame(IssueCommand.CostIcon, itemId, null, "", frameVisible: false);
		}
		((GObject)IssueCommand.CostNumber).text = num3.ToString();
		((GObject)IssueCommand.CurStock).text = $"{GameManagers.Instance.StockController.GetStock(itemId)}/";
	}

	private void OnCommandSelect(EventContext context)
	{
		int selectedIndex = IssueCommand.Commands.selectedIndex;
		IssueCommand.CommandType.selectedIndex = selectedIndex;
		GObject childAt = ((GComponent)IssueCommand.Commands).GetChildAt(selectedIndex);
		_commandType = (eIslandEvent)childAt.data;
		OnCommandChange();
		ClearMessage();
		CalculateCost();
		ShowCommandEffect();
	}

	private void LoadPlayerCommandConfig()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		_commandConfig = WorldMapConfigHelper.Configs.PlayerCommandConfig;
		List<KeyValuePair<string, float>> contributionPointsAddList = _commandConfig.ContributionPointAdd.ToList();
		IssueCommand.ContributionPointsAdd.itemRenderer = new ListItemRenderer(RenderContribution);
		IssueCommand.ContributionPointsAdd.numItems = _commandConfig.ContributionPointAdd.Count;
		List<KeyValuePair<string, int>> timeAddList = _commandConfig.TimerAdd.ToList();
		IssueCommand.TimeAdd.itemRenderer = new ListItemRenderer(RenderTime);
		IssueCommand.TimeAdd.numItems = timeAddList.Count;
		SetDefaultSelect();
		void RenderContribution(int index, GObject obj)
		{
			if (obj is UI_btn_ContributionPointAdd uI_btn_ContributionPointAdd)
			{
				KeyValuePair<string, float> keyValuePair = contributionPointsAddList[index];
				((GObject)uI_btn_ContributionPointAdd.ContributionPointsAdd).text = $"+{Mathf.RoundToInt(keyValuePair.Value * 100f)}%";
				uI_btn_ContributionPointAdd.ConfigIndex.selectedIndex = index;
				((GObject)uI_btn_ContributionPointAdd).data = keyValuePair.Key;
			}
		}
		void RenderTime(int index, GObject obj)
		{
			if (obj is UI_btn_TimeAdd uI_btn_TimeAdd)
			{
				KeyValuePair<string, int> keyValuePair = timeAddList[index];
				((GObject)uI_btn_TimeAdd.Time).text = $"{keyValuePair.Value / 3600}";
				uI_btn_TimeAdd.ConfigIndex.selectedIndex = index;
				((GObject)uI_btn_TimeAdd).data = keyValuePair.Key;
			}
		}
		void SetDefaultSelect()
		{
			_contributionPointAdd = contributionPointsAddList[0].Key;
			_timerAdd = timeAddList[0].Key;
			IssueCommand.ContributionPointsAdd.selectedIndex = 0;
			IssueCommand.TimeAdd.selectedIndex = 0;
		}
	}

	private void OnContributionPointAddSelect(EventContext context)
	{
		int selectedIndex = IssueCommand.ContributionPointsAdd.selectedIndex;
		GObject childAt = ((GComponent)IssueCommand.ContributionPointsAdd).GetChildAt(selectedIndex);
		string contributionPointAdd = childAt.data.ToString();
		_contributionPointAdd = contributionPointAdd;
		CalculateCost();
		ShowCommandEffect();
	}

	private void OnTimerAddSelect(EventContext context)
	{
		int selectedIndex = IssueCommand.TimeAdd.selectedIndex;
		GObject childAt = ((GComponent)IssueCommand.TimeAdd).GetChildAt(selectedIndex);
		string timerAdd = childAt.data.ToString();
		_timerAdd = timerAdd;
		CalculateCost();
		ShowCommandEffect();
	}

	private void ShowMessage(string newMessage)
	{
		_message = newMessage;
		IssueCommand.SelectedMessage.Type.selectedIndex = 1;
		((GObject)_firstMessage.TextField).text = newMessage;
		((GObject)_firstMessage.TextField).x = ((GObject)IssueCommand.SelectedMessage).width;
		((GObject)_secondMessage.TextField).text = newMessage;
		((GObject)_secondMessage.TextField).x = ((GObject)_firstMessage.TextField).x + ((GObject)_firstMessage.TextField).width + MessageInterval;
		if (_updateMessageX != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateMessageX);
		}
		_updateMessageX = FGUIManager.Instance.OpenIEnumerator(RefreshMessageX());
	}

	private void ClearMessage()
	{
		if (_updateMessageX != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateMessageX);
		}
		IssueCommand.SelectedMessage.Type.selectedIndex = 0;
	}

	private IEnumerator RefreshMessageX()
	{
		while (!((GObject)this).isDisposed)
		{
			_firstMessage.Move(3f);
			_secondMessage.Move(3f);
			yield return _perSecond;
		}
	}
}
