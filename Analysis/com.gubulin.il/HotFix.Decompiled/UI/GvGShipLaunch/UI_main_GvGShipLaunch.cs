using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.GvGChat;
using UI.GvGShipDetail;
using UI.GvGShipOverview;
using UI.GvGWorldMap3;

namespace UI.GvGShipLaunch;

public class UI_main_GvGShipLaunch : GComponent, IUiController
{
	public GGraph back;

	public GImage n4;

	public UI_com_IslandList Islands;

	public UI_btn_SelectLaunchIslandCancel BackBtn;

	public GRichTextField n3;

	public Transition ShowInfo;

	public const string URL = "ui://tc205cu3fgyl0";

	public static string Name = "UI_main_GvGShipLaunch";

	private List<int> _islands = new List<int>();

	private GvGShipDetailModel _shipDetailModel;

	private readonly List<string> _hiddenUis = new List<string>
	{
		UI_main_GvGWorldMap3.Name,
		UI_GvGShipOverviewPanel.Name,
		UI_GvGShipDetailPanel.Name,
		UI_main_GvG3Chat.Name
	};

	public static string GetURL()
	{
		return "ui://tc205cu3fgyl0";
	}

	public static UI_main_GvGShipLaunch CreateInstance()
	{
		return (UI_main_GvGShipLaunch)(object)UIPackage.CreateObject("GvGShipLaunch", "main_GvGShipLaunch");
	}

	public static UI_main_GvGShipLaunch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGShipLaunch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tc205cu3fgyl0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Islands = (UI_com_IslandList)(object)((GComponent)this).GetChild("Islands");
		BackBtn = (UI_btn_SelectLaunchIslandCancel)(object)((GComponent)this).GetChild("BackBtn");
		n3 = (GRichTextField)((GComponent)this).GetChild("n3");
		string id = "ui://tc205cu3fgyl0".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		ShowInfo = ((GComponent)this).GetTransition("ShowInfo");
	}

	public void BeforeDestroy()
	{
		GvGWorldMapController.Instance.LaunchModeDestroy();
	}

	public void Destroy()
	{
		Singleton<GvGMode3RoomManager>.Instance.TryDelayDisconnectRoom();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		GameController.Contexts.Service<IUiService>().HideUis(_hiddenUis);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_islands = new List<int>(Singleton<GvGShipUiInfoManager>.Instance.LaunchableIslands);
		_shipDetailModel = (parameters.TryGetValue("ShipDetail", out var value) ? ((GvGShipDetailModel)value) : null);
		RenderIslandsList();
		Singleton<GvGMode3RoomManager>.Instance.TryConnectToRoom(delegate
		{
			GvGWorldMapController.Instance.LaunchModeInit(_islands[0]);
		});
	}

	public void OnShow()
	{
		((GComponent)Islands.IslandList).EnsureBoundsCorrect();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)Islands.Confirm).onClick.Add(new EventCallback0(SelectIslandLaunch));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Remove(new EventCallback0(End));
		((GObject)Islands.Confirm).onClick.Remove(new EventCallback0(SelectIslandLaunch));
	}

	private void RenderIslandsList()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		if (_islands.Count > 0)
		{
			Islands.IslandList.itemRenderer = new ListItemRenderer(RenderIslandInfo);
			Islands.IslandList.numItems = _islands.Count;
			Islands.IslandList.selectedIndex = 0;
		}
	}

	private void RenderIslandInfo(int index, GObject obj)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		if (obj is UI_btn_IslandInfo uI_btn_IslandInfo)
		{
			int islandId = _islands[index];
			IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(islandId);
			((GObject)uI_btn_IslandInfo.IslandName).text = islandConfigData.Name;
			((GObject)uI_btn_IslandInfo).data = index;
			((GObject)uI_btn_IslandInfo).onClick.Set(new EventCallback1(OnSelectIsland));
		}
	}

	private void OnSelectIsland(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)((GObject)context.sender).data;
		Islands.IslandList.selectedIndex = num;
		GvGWorldMapController.Instance.LaunchModeUpdateIslandId(_islands[num]);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		GameController.Contexts.Service<IUiService>().HideUis(_hiddenUis, uiVisible: true);
	}

	private IEnumerator DelayRecover()
	{
		yield return null;
		GameController.Contexts.Service<IUiService>().RecoverLastBackup();
	}

	private void SelectIslandLaunch()
	{
		int islandId = _islands[Islands.IslandList.selectedIndex];
		_shipDetailModel?.SyncShipLaunch(islandId, End);
	}
}
