using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace UI.ReturningRewards;

public class UI_main_ReturningRewardsPreview : GComponent, IUiController
{
	public Controller IsFirstTime;

	public GGraph Mask;

	public UI_com_RewardPreview Rewards;

	public Transition ShowDialog;

	public const string URL = "ui://rx5ntv98win20";

	public static string Name = "UI_main_ReturningRewardsPreview";

	private const string PREVIEW_REWARDS = "PreviewRewards";

	private const string IS_FIRST = "IsFirst";

	private const string ON_FIRST_CHECKED = "ON_FIRST_CHECKED";

	private List<IRecallWelfarePreviewReward> _rewards;

	private bool _isFirst;

	private Action _onFirstChecked;

	public static string GetURL()
	{
		return "ui://rx5ntv98win20";
	}

	public static UI_main_ReturningRewardsPreview CreateInstance()
	{
		return (UI_main_ReturningRewardsPreview)(object)UIPackage.CreateObject("ReturningRewards", "main_ReturningRewardsPreview");
	}

	public static UI_main_ReturningRewardsPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ReturningRewardsPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsFirstTime = ((GComponent)this).GetController("IsFirstTime");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Rewards = (UI_com_RewardPreview)(object)((GComponent)this).GetChild("Rewards");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public static void Open(RecallWelfarePreviewParams previewParams)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object>
		{
			{ "PreviewRewards", previewParams.Rewards },
			{ "IsFirst", previewParams.IsFirst },
			{ "ON_FIRST_CHECKED", previewParams.OnFirstChecked }
		});
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_rewards = (parameters.TryGetValue("PreviewRewards", out var value) ? ((List<IRecallWelfarePreviewReward>)value) : new List<IRecallWelfarePreviewReward>());
		_isFirst = parameters.TryGetValue("IsFirst", out var value2) && (bool)value2;
		_onFirstChecked = (parameters.TryGetValue("ON_FIRST_CHECKED", out var value3) ? ((Action)value3) : null);
	}

	public void OnShow()
	{
		IsFirstTime.SetSelectedIndex(_isFirst ? 1 : 0);
		RenderRewards();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Rewards.Confirm).onClick.Set(new EventCallback0(OnConfirmClick));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Rewards.Confirm).onClick.Clear();
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OnConfirmClick()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		if (_isFirst)
		{
			_onFirstChecked?.Invoke();
			((GComponent)(object)this).SetTimeout(0.4f).OnComplete(new GTweenCallback(End));
		}
		else
		{
			End();
		}
	}

	private void RenderRewards()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		_rewards.Sort((IRecallWelfarePreviewReward a, IRecallWelfarePreviewReward b) => a.Rarity - b.Rarity);
		Rewards.Rewards.itemRenderer = new ListItemRenderer(RewardRenderer);
		Rewards.Rewards.numItems = _rewards.Count;
	}

	private void RewardRenderer(int index, GObject obj)
	{
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		if (!(obj is UI_btn_Reward uI_btn_Reward))
		{
			throw new Exception("UI_main_ReturningRewardsPreview RewardRenderer obj is not UI_btn_Reward");
		}
		IRecallWelfarePreviewReward reward = _rewards[index];
		((GObject)uI_btn_Reward.Num).text = $"x{reward.NotObtainNum}";
		((GObject)uI_btn_Reward.ItemName).text = Regex.Replace(reward.Name, "\\r?\\n", string.Empty);
		uI_btn_Reward.IsClaimed.SetSelectedIndex((reward.NotObtainNum <= 0) ? 1 : 0);
		uI_btn_Reward.Item.icon.url = reward.ItemId;
		uI_btn_Reward.Item.Rarity.SetSelectedIndex(reward.Rarity);
		((GObject)uI_btn_Reward.Item.Qty).text = $"x{reward.Qty}";
		FGUIManager.Instance.SetItemIconAndFrame(uI_btn_Reward.Item.icon, reward.ItemId, null, "", frameVisible: false);
		((GObject)uI_btn_Reward).onClick.Set((EventCallback0)delegate
		{
			reward.ItemId.DisplayItemTip();
		});
	}
}
