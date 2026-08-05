using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace UI.IslandComeAgain;

public class UI_IslandComeAgainCheckRewardPanel : GComponent, IUiController
{
	public Controller Type;

	public GGraph Mask;

	public UI_btn_Page01 LastPool;

	public UI_btn_Page02 NextPool;

	public UI_CheckRewardDialog Content;

	public const string URL = "ui://k2sprg26gj7i42";

	public static string Name = "UI_IslandComeAgainCheckRewardPanel";

	private int CurrentPoolIndex;

	private List<IslandComeAgainPrizePool> IslandComeAgainPrizePools = new List<IslandComeAgainPrizePool>();

	private DynamicIslandComeAgainActivity activity;

	private List<string> prizesInfo = new List<string>();

	public static string GetURL()
	{
		return "ui://k2sprg26gj7i42";
	}

	public static UI_IslandComeAgainCheckRewardPanel CreateInstance()
	{
		return (UI_IslandComeAgainCheckRewardPanel)(object)UIPackage.CreateObject("IslandComeAgain", "IslandComeAgainCheckRewardPanel");
	}

	public static UI_IslandComeAgainCheckRewardPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandComeAgainCheckRewardPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26gj7i42", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		LastPool = (UI_btn_Page01)(object)((GComponent)this).GetChild("LastPool");
		NextPool = (UI_btn_Page02)(object)((GComponent)this).GetChild("NextPool");
		Content = (UI_CheckRewardDialog)(object)((GComponent)this).GetChild("Content");
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
		if (parameters.TryGetValue("CurrentPoolIndex", out var value))
		{
			CurrentPoolIndex = (int)value;
		}
		activity = FGUIManager.Instance.IslandComeAgainActivities?[0];
		IslandComeAgainPrizePools = activity?.GetAllPrizePool();
		RenderRewardInfo();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)LastPool).onClick.Add(new EventCallback0(ToLastPool));
		((GObject)NextPool).onClick.Add(new EventCallback0(ToNextPool));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)LastPool).onClick.Remove(new EventCallback0(ToLastPool));
		((GObject)NextPool).onClick.Remove(new EventCallback0(ToNextPool));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void SetPrizePoolType()
	{
		if (!((GObject)this).isDisposed)
		{
			int count = IslandComeAgainPrizePools.Count;
			if (CurrentPoolIndex == 0)
			{
				Type.selectedIndex = 0;
			}
			else if (CurrentPoolIndex == count - 1)
			{
				Type.selectedIndex = 2;
			}
			else
			{
				Type.selectedIndex = 1;
			}
		}
	}

	private void ToLastPool()
	{
		CurrentPoolIndex--;
		if (CurrentPoolIndex < 0)
		{
			CurrentPoolIndex = 0;
		}
		SharedMessenger.Broadcast("ISLAND_COME_AGAIN_UPDATE_CURRNET_PRIZE_POOL", CurrentPoolIndex);
		RenderRewardInfo();
	}

	private void ToNextPool()
	{
		CurrentPoolIndex++;
		if (CurrentPoolIndex > IslandComeAgainPrizePools.Count - 1)
		{
			CurrentPoolIndex = IslandComeAgainPrizePools.Count - 1;
		}
		SharedMessenger.Broadcast("ISLAND_COME_AGAIN_UPDATE_CURRNET_PRIZE_POOL", CurrentPoolIndex);
		RenderRewardInfo();
	}

	private void RenderRewardInfo()
	{
		Content.Type.selectedIndex = CurrentPoolIndex;
		Content.SetControllerPageText();
		SetPrizePoolType();
		RenderBigPrize();
		RenderPrizes();
	}

	private void RenderBigPrize()
	{
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		IslandComeAgainPrizePool islandComeAgainPrizePool = IslandComeAgainPrizePools[CurrentPoolIndex];
		Content.State.selectedIndex = (islandComeAgainPrizePool.BigPrizeReceived() ? 1 : 0);
		IslandComeAgainPrizePool.ItemInfo bigPrize = islandComeAgainPrizePool.GetBigPrize();
		if (Item.ItemType(bigPrize.ItemId) == 10)
		{
			Content.BigPrize.IconScale.selectedIndex = 1;
		}
		else if (Item.ItemType(bigPrize.ItemId) == 3)
		{
			Content.BigPrize.IconScale.selectedIndex = 2;
		}
		else
		{
			Content.BigPrize.IconScale.selectedIndex = 0;
		}
		FGUIManager.Instance.SetItemIconAndFrame(Content.BigPrize.icon, bigPrize.ItemId, null, "", frameVisible: false);
		((GObject)Content.BigPrizeName).text = Item.Name(GameManagers.Instance, bigPrize.ItemId);
		((GObject)Content.BigPrize).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(bigPrize.ItemId, 1, noCheckBtn: true);
		});
	}

	private void RenderPrizes()
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		IslandComeAgainPrizePool islandComeAgainPrizePool = IslandComeAgainPrizePools[CurrentPoolIndex];
		prizesInfo.Clear();
		for (int i = 0; i < islandComeAgainPrizePool.Reward.Count; i++)
		{
			IslandComeAgainPrizePool.ItemInfo itemInfo = islandComeAgainPrizePool.Reward[i];
			if (itemInfo.Rarity <= 1 && !prizesInfo.Contains(itemInfo.ItemId))
			{
				prizesInfo.Add(itemInfo.ItemId);
			}
		}
		Content.PrizesList.itemRenderer = new ListItemRenderer(RenderPrizeItem);
		Content.PrizesList.numItems = prizesInfo.Count;
	}

	private void RenderPrizeItem(int index, GObject obj)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		if (obj is UI_mc_SlotRewardInfo uI_mc_SlotRewardInfo)
		{
			string itemId = prizesInfo[index];
			if (Item.ItemType(itemId) == 10)
			{
				uI_mc_SlotRewardInfo.Item.IconScale.selectedIndex = 1;
			}
			else if (Item.ItemType(itemId) == 3)
			{
				uI_mc_SlotRewardInfo.Item.IconScale.selectedIndex = 2;
			}
			else
			{
				uI_mc_SlotRewardInfo.Item.IconScale.selectedIndex = 0;
			}
			FGUIManager.Instance.SetItemIconAndFrame(uI_mc_SlotRewardInfo.Item.icon, itemId, null, "", frameVisible: false);
			((GObject)uI_mc_SlotRewardInfo.PrizeName).text = Item.Name(GameManagers.Instance, itemId);
			((GObject)uI_mc_SlotRewardInfo).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, 1, noCheckBtn: true);
			});
		}
	}
}
