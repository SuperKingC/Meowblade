using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;

namespace UI.PvpSelectSoldiers;

public class UI_PVPSeasonMatchResultPanel : GComponent, IUiController
{
	public Controller IsFinished;

	public GGraph mask;

	public UI_PVPSeasonMatchResultDialog Dialog;

	public Transition popup;

	public const string URL = "ui://82mo10n5o6jgjdqd";

	public static string Name = "UI_PVPSeasonMatchResultPanel";

	private int _rank;

	private List<RItem> _rItems;

	private bool _claimed;

	private bool _approval;

	public static string GetURL()
	{
		return "ui://82mo10n5o6jgjdqd";
	}

	public static UI_PVPSeasonMatchResultPanel CreateInstance()
	{
		return (UI_PVPSeasonMatchResultPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PVPSeasonMatchResultPanel");
	}

	public static UI_PVPSeasonMatchResultPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PVPSeasonMatchResultPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5o6jgjdqd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsFinished = ((GComponent)this).GetController("IsFinished");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_PVPSeasonMatchResultDialog)(object)((GComponent)this).GetChild("Dialog");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("Rank", out var value))
		{
			_rank = (int)value;
		}
		if (parameters.TryGetValue("RItems", out var value2))
		{
			_rItems = value2 as List<RItem>;
		}
		if (parameters.TryGetValue("Claimed", out var value3))
		{
			_claimed = (bool)value3;
		}
		if (parameters.TryGetValue("Approval", out var value4))
		{
			_approval = (bool)value4;
		}
		RenderRankAndBonus();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)mask).onClick.Clear();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void RenderRankAndBonus()
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		((GObject)Dialog.RankNumber).text = $"{_rank}";
		if (_rItems != null && _rItems.Count > 0)
		{
			IsFinished.selectedIndex = 1;
			if (_claimed || !_approval)
			{
				((GObject)Dialog.ConfirmButton).grayed = true;
				((GObject)Dialog.ConfirmButton).touchable = true;
			}
			((GObject)Dialog.ConfirmButton).onClick.Set(new EventCallback0(RankDataHelper.ClaimAllServerChampionshipRankBonus));
			Dialog.ResultRewardList.itemRenderer = new ListItemRenderer(_renderRItems);
			Dialog.ResultRewardList.numItems = _rItems.Count;
		}
		else
		{
			IsFinished.selectedIndex = 0;
			((GObject)Dialog.ConfirmButton).onClick.Set(new EventCallback0(RankDataHelper.GoSetFormationForAllServerChampionship));
		}
	}

	private void _renderRItems(int index, GObject gObject)
	{
		UI_ResultRewardItem uI_ResultRewardItem = gObject.asCom as UI_ResultRewardItem;
		RItem rItem = _rItems[index];
		((GObject)uI_ResultRewardItem.title).text = $"{rItem.cnt}";
		uI_ResultRewardItem.icon.url = UiHelper.GetItemIconPath(rItem.ItemId);
	}
}
