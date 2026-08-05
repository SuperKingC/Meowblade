using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGVideos;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.UiParam;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvG3Video;

public class UI_main_GvG3Video : GComponent, IUiController
{
	public GLoader background;

	public GImage n10;

	public GImage n9;

	public GImage n7;

	public GImage n6;

	public UI_com_VideoPlayer VideoPlayer;

	public UI_com_VideoReward VideoRewards;

	public UI_com_Videos Videos;

	public GImage n13;

	public GButton Back;

	public GComponent ResourcePane;

	public GGraph SpineWrapper;

	public UI_com_Title n16;

	public const string URL = "ui://2itu6489oztu0";

	public static string Name = "UI_main_GvG3Video";

	private UI_ProductionNumFloating _numFloating;

	private GvG3VideosController _controller;

	private SkeletonAnimationUiWrapper _director;

	private string _curVideoId;

	public static string GetURL()
	{
		return "ui://2itu6489oztu0";
	}

	public static UI_main_GvG3Video CreateInstance()
	{
		return (UI_main_GvG3Video)(object)UIPackage.CreateObject("GvG3Video", "main_GvG3Video");
	}

	public static UI_main_GvG3Video CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3Video).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489oztu0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		VideoPlayer = (UI_com_VideoPlayer)(object)((GComponent)this).GetChild("VideoPlayer");
		VideoRewards = (UI_com_VideoReward)(object)((GComponent)this).GetChild("VideoRewards");
		Videos = (UI_com_Videos)(object)((GComponent)this).GetChild("Videos");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		Back = (GButton)((GComponent)this).GetChild("Back");
		ResourcePane = (GComponent)((GComponent)this).GetChild("ResourcePane");
		SpineWrapper = (GGraph)((GComponent)this).GetChild("SpineWrapper");
		n16 = (UI_com_Title)(object)((GComponent)this).GetChild("n16");
	}

	public void BeforeDestroy()
	{
		_director.RemoveSpine();
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_006c: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_controller = new GvG3VideosController(VideoPlayer.VideoLoader);
		_director = new SkeletonAnimationUiWrapper(new SkeletonAnimationLoadParams(SpineWrapper, "daoyan", "skin1", "daiji"));
		VideoRewards.Init(new EventCallback1(ClaimReward), new EventCallback1(ShowItemDesc));
		RenderVideos();
		UpdateRewardItemStock();
	}

	public void OnShow()
	{
		Videos.Videos.selectedIndex = 0;
		((GComponent)Videos.Videos).GetChildAt(0).onClick.Call();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Back).onClick.Set(new EventCallback0(End));
		((GObject)VideoPlayer.Play).onClick.Set(new EventCallback0(PlayVideo));
		Videos.Videos.onClickItem.Set(new EventCallback0(SelectVideo));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Back).onClick.Clear();
		((GObject)VideoPlayer.Play).onClick.Clear();
		Videos.Videos.onClickItem.Clear();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	private void End()
	{
		_controller.RemovePlayer();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void PlayVideo()
	{
		CheckVideoId();
		VideoPlayer.StartPlay();
		_director.PlayAnimation("bofang");
		_controller.PlayVideo(_curVideoId, VideoPlayer.Prepared, UpdateUi);
	}

	private void SelectVideo()
	{
		_curVideoId = _controller.Videos[Videos.Videos.selectedIndex].Meta.Id;
		CheckVideoId();
		_controller.StopVideo();
		_director.PlayAnimation("daiji");
		HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo.GvG3Video video = _controller.FindVideo(_curVideoId);
		VideoPlayer.Reset(video);
		VideoRewards.UpdateVideoReward(video);
	}

	private void ClaimReward(EventContext context)
	{
		CheckVideoId();
		_controller.ClaimReward(_curVideoId, VideoRewards.UpdateVideoReward);
	}

	private void ShowItemDesc(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string itemId = ((GObject)context.sender).data.ToString();
		FGUIManager.Instance.ItemTip(itemId, 1, noCheckBtn: true);
	}

	private void UpdateUi(HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo.GvG3Video video)
	{
		VideoPlayer.Reset(video);
		VideoRewards.UpdateVideoReward(video);
		_director.PlayAnimation("daiji");
		for (int i = 0; i < ((GComponent)Videos.Videos).numChildren; i++)
		{
			if (((GComponent)Videos.Videos).GetChildAt(i) is UI_btn_VideoPreview uI_btn_VideoPreview)
			{
				string text = ((GObject)uI_btn_VideoPreview).data.ToString();
				if (!(text != video.Meta.NextVideoId))
				{
					RenderVideo(i, (GObject)(object)uI_btn_VideoPreview);
					break;
				}
			}
		}
	}

	private void RenderVideos()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Videos.Videos.itemRenderer = new ListItemRenderer(RenderVideo);
		Videos.Videos.numItems = _controller.Videos.Count;
		Videos.Videos.ResizeToFit(_controller.Videos.Count);
	}

	private void RenderVideo(int index, GObject obj)
	{
		if (!(obj is UI_btn_VideoPreview uI_btn_VideoPreview))
		{
			throw new Exception("UI_main_GvG3Video.RenderVideo：vpUi is not UI_btn_VideoPreview");
		}
		uI_btn_VideoPreview.Render(_controller.Videos[index]);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		if (!(itemId == _controller.GetRewardItemId()))
		{
			return;
		}
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		((GObject)ResourcePane.GetChild("num").asTextField).text = $"{stock}";
		int num = ((ResourcePane.GetChild("num").data != null) ? ((int)ResourcePane.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (_numFloating == null)
			{
				_numFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)_numFloating).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(_numFloating, ResourcePane, stock - num);
			}
			else
			{
				((GObject)_numFloating.Title).text = $"+{(int)((GObject)_numFloating.Title).data + num2}";
				((GObject)_numFloating.Title).data = (int)((GObject)_numFloating.Title).data + num2;
			}
		}
		ResourcePane.GetChild("num").data = stock;
		ResourcePane.GetChild("textSFXBack").displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(ResourcePane.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
	}

	private void UpdateRewardItemStock()
	{
		ResourcePane.GetChild("addButton").visible = false;
		ResourcePane.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(_controller.GetRewardItemId());
		int stock = GameManagers.Instance.StockController.GetStock(_controller.GetRewardItemId());
		((GObject)ResourcePane.GetChild("num").asTextField).text = stock.ToString();
		ResourcePane.GetChild("num").data = stock;
	}

	private void CheckVideoId()
	{
		if (string.IsNullOrEmpty(_curVideoId))
		{
			throw new Exception("UI_main_GvG3Video：CurVideoId is null or empty");
		}
	}
}
