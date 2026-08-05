using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace UI.GvGWorldMap3;

public class UI_com_IslandCardLoader : GComponent
{
	private enum IslandCardType
	{
		Star,
		Moon,
		Flagship,
		BigBoss
	}

	public GLoader IslandCardLoader;

	public const string URL = "ui://4eq8fgd2jxsodm";

	public static string Name = "UI_com_IslandCardLoader";

	public Action<eIslandAction> OnIslandAction = delegate
	{
	};

	public static Action OnClickSweep = delegate
	{
	};

	public static Action OnClickRepeatedAttack = delegate
	{
	};

	private IIslandCard _curIslandCard;

	private IslandStateModel _islandState;

	private readonly Dictionary<IslandCardType, string> _islandCardsPool = new Dictionary<IslandCardType, string>
	{
		{
			IslandCardType.Star,
			"ui://4eq8fgd2jxsodu"
		},
		{
			IslandCardType.Moon,
			"ui://4eq8fgd2h4tpe3"
		},
		{
			IslandCardType.Flagship,
			"ui://4eq8fgd2h4tpef"
		},
		{
			IslandCardType.BigBoss,
			"ui://4eq8fgd2h4tpee"
		}
	};

	private List<int> _bossIslandId;

	private List<int> BigBossIslandId
	{
		get
		{
			if (WorldMapConfigHelper.Configs.IsBrawlEvent())
			{
				return _bossIslandId ?? (_bossIslandId = new List<int>());
			}
			return _bossIslandId ?? (_bossIslandId = "GvGMode3FinalProgressIsland".ToConfiguration<Dictionary<string, List<int>>>()[Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId]);
		}
	}

	public static string GetURL()
	{
		return "ui://4eq8fgd2jxsodm";
	}

	public static UI_com_IslandCardLoader CreateInstance()
	{
		return (UI_com_IslandCardLoader)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandCardLoader");
	}

	public static UI_com_IslandCardLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandCardLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2jxsodm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IslandCardLoader = (GLoader)((GComponent)this).GetChild("IslandCardLoader");
	}

	public void RegisterEvent()
	{
		SharedMessenger.AddListener<int>("ON_ISLAND_ACTION_EXECUTE", OnIslandActionExecute);
	}

	public void OnDestroy()
	{
		SharedMessenger.RemoveListener<int>("ON_ISLAND_ACTION_EXECUTE", OnIslandActionExecute);
	}

	public void RenderIslandCard(IslandStateModel islandState)
	{
		IslandCardType key = GetCardType();
		IslandCardLoader.url = _islandCardsPool[key];
		_curIslandCard = LoadCard();
		_islandState = islandState;
		IslandCardType GetCardType()
		{
			if (BigBossIslandId.Contains(islandState.IslandId))
			{
				return IslandCardType.BigBoss;
			}
			eGvGMode3IslandBelongStatus belongStatus = islandState.GetBelongStatus();
			if (islandState.IslandId == Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId && belongStatus == eGvGMode3IslandBelongStatus.OwnSide)
			{
				return IslandCardType.Flagship;
			}
			eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(islandState.IslandId).Props.Type;
			return (type != eIslandType.Star) ? IslandCardType.Moon : IslandCardType.Star;
		}
		IIslandCard LoadCard()
		{
			IIslandCard islandCard = IslandCardLoader.component as IIslandCard;
			islandCard?.OnLoad(islandState);
			islandCard?.Render(islandState);
			return islandCard;
		}
	}

	public void Update(IslandStateModel islandState)
	{
		_curIslandCard?.Update(islandState);
	}

	public void OnClose(IslandStateModel islandState)
	{
		_curIslandCard?.OnClose(islandState);
		_curIslandCard = null;
	}

	private void OnIslandActionExecute(int actionType)
	{
		eIslandAction action = (eIslandAction)actionType;
		if (!IslandStateModelExtension.IslandAttackActionCheck(action))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_com_Armistice.Name, null);
			return;
		}
		if (action == eIslandAction.SuppressRebellion)
		{
			DailySuppressBonusModel dailySuppressBonusModel = Singleton<WorldStateManager>.Instance.Data.DailySuppressBonusModel;
			string zone = WorldMapConfigHelper.Configs.TryGetIsland(_islandState.IslandId).Props.GDEData.Zone;
			DailySuppressBonusTimesPerZone zoneData = dailySuppressBonusModel.GetZoneData(zone);
			bool flag = dailySuppressBonusModel.GetRemainCount() <= 0 || zoneData.GetRemainCount() <= 0;
			int num = GameLocalDataManager.GetInt("TipKey_GvgRebellionConfirmOperation");
			bool flag2 = num <= GameController.Instance.GetServerTime();
			if (flag && flag2)
			{
				Action value = delegate
				{
					OnIslandAction?.Invoke(action);
				};
				UnityUiService.Instance.OpenPanel(UI_main_OpertionRebellionLimitPanel.Name, new Dictionary<string, object> { { "ConfirmCallback", value } });
				return;
			}
		}
		OnIslandAction?.Invoke(action);
	}
}
