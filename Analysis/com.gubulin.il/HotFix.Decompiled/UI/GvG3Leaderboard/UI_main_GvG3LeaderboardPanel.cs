using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UI.GvG3SupplyDepot;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvG3Leaderboard;

public class UI_main_GvG3LeaderboardPanel : GComponent, IUiController
{
	public enum UIType
	{
		Expedition,
		EternalNight,
		BrawlFight
	}

	public Controller UITypeController;

	public Controller RankingType;

	public Controller CampId;

	public Controller HasMedal;

	public Controller IsFinalized;

	public Controller EternalNightSubPage;

	public Controller IsShowInfoPop;

	public Controller DetailDisplaying;

	public GLoader background;

	public GButton BackBtn;

	public GImage n218;

	public GImage n204;

	public GImage n148;

	public UI_com_Title Title;

	public GImage n149;

	public GImage n150;

	public GImage n151;

	public GImage n205;

	public GImage n152;

	public GImage n219;

	public GImage n206;

	public GImage n153;

	public GTextField n177;

	public GTextField IZId;

	public GGroup n179;

	public GTextField n171;

	public GTextField n172;

	public GTextField n173;

	public GTextField n174;

	public GTextField n175;

	public GTextField n176;

	public GTextField n170;

	public GTextField n208;

	public GTextField n220;

	public GTextField n221;

	public GList PagesType0;

	public GList PagesType1;

	public GList PagesType2;

	public GList EternalNightSubPages;

	public GImage n160;

	public GLoader n161;

	public GTextField n162;

	public GTextField n163;

	public GTextField n164;

	public GTextField n165;

	public GTextField n166;

	public GTextField n167;

	public GTextField n209;

	public GTextField n223;

	public GTextField n224;

	public GList RankList;

	public GImage n180;

	public GLoader MedalIcon;

	public GImage n185;

	public GImage n184;

	public GTextField n186;

	public GMovieClip n182;

	public GMovieClip n183;

	public UI_com_MyRankingInfo MyRankingInfo;

	public UI_btn_BonusDetail BonusDetailBtn;

	public GTextField n189;

	public GGroup n241;

	public GImage n240;

	public GTextField n239;

	public GImage n190;

	public GGroup n193;

	public GTextField n191;

	public GTextField NextUpdateTime;

	public GTextField n187;

	public GTextField n212;

	public GTextField n213;

	public GTextField n214;

	public GTextField n243;

	public GGroup n215;

	public UI_com_info01 ContributionsDetail;

	public UI_com_info03 BrawlFightScore;

	public UI_com_info01 MyContributionDetail;

	public UI_com_info02 DamagesDetail;

	public GGraph BonusInfoDialogMask;

	public UI_com_BonusInfoDialog BonusInfoDialog;

	public Transition t0;

	public const string URL = "ui://ylvfgf90uku34p";

	public static string Name = "UI_main_GvG3LeaderboardPanel";

	public const string IZConfigId = "IzConfigId";

	private UIType CurUIType;

	private eLeaderboardType CurLeaderboardType;

	private eLeaderboardSubType CurLeaderboardSubType;

	private GvG3LeaderboardModel Data;

	private GvGMode3LeaderboardData CurLeaderboardData;

	private string CurCacheId;

	private int CurUserId;

	private int CurUserCampId;

	private string CurIZShowName;

	private UICallbackParam<Action> OnClose;

	private string _izConfigId;

	private bool IsBrawlEvent
	{
		get
		{
			if (string.IsNullOrEmpty(_izConfigId))
			{
				return WorldMapConfigHelper.Configs.IsBrawlEvent();
			}
			return WorldMapConfigHelper.IsBrawlFightEvent(_izConfigId);
		}
	}

	public static string GetURL()
	{
		return "ui://ylvfgf90uku34p";
	}

	public static UI_main_GvG3LeaderboardPanel CreateInstance()
	{
		return (UI_main_GvG3LeaderboardPanel)(object)UIPackage.CreateObject("GvG3Leaderboard", "main_GvG3LeaderboardPanel");
	}

	public static UI_main_GvG3LeaderboardPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3LeaderboardPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90uku34p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Expected O, but got Unknown
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Expected O, but got Unknown
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Expected O, but got Unknown
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Expected O, but got Unknown
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected O, but got Unknown
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Expected O, but got Unknown
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Expected O, but got Unknown
		//IL_0675: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected O, but got Unknown
		//IL_06ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Expected O, but got Unknown
		//IL_071f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0729: Expected O, but got Unknown
		//IL_0774: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Expected O, but got Unknown
		//IL_07c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d3: Expected O, but got Unknown
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0828: Expected O, but got Unknown
		//IL_0873: Unknown result type (might be due to invalid IL or missing references)
		//IL_087d: Expected O, but got Unknown
		//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d2: Expected O, but got Unknown
		//IL_091d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0927: Expected O, but got Unknown
		//IL_0933: Unknown result type (might be due to invalid IL or missing references)
		//IL_093d: Expected O, but got Unknown
		//IL_0949: Unknown result type (might be due to invalid IL or missing references)
		//IL_0953: Expected O, but got Unknown
		//IL_095f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0969: Expected O, but got Unknown
		//IL_0975: Unknown result type (might be due to invalid IL or missing references)
		//IL_097f: Expected O, but got Unknown
		//IL_098b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0995: Expected O, but got Unknown
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ea: Expected O, but got Unknown
		//IL_09f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Expected O, but got Unknown
		//IL_0a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a42: Expected O, but got Unknown
		//IL_0a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a97: Expected O, but got Unknown
		//IL_0aa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aad: Expected O, but got Unknown
		//IL_0ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac3: Expected O, but got Unknown
		//IL_0b0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b18: Expected O, but got Unknown
		//IL_0b24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2e: Expected O, but got Unknown
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b44: Expected O, but got Unknown
		//IL_0b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b99: Expected O, but got Unknown
		//IL_0ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Expected O, but got Unknown
		//IL_0bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c04: Expected O, but got Unknown
		//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c59: Expected O, but got Unknown
		//IL_0ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cae: Expected O, but got Unknown
		//IL_0cf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d03: Expected O, but got Unknown
		//IL_0d4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d58: Expected O, but got Unknown
		//IL_0dbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		UITypeController = ((GComponent)this).GetController("UITypeController");
		RankingType = ((GComponent)this).GetController("RankingType");
		CampId = ((GComponent)this).GetController("CampId");
		HasMedal = ((GComponent)this).GetController("HasMedal");
		IsFinalized = ((GComponent)this).GetController("IsFinalized");
		EternalNightSubPage = ((GComponent)this).GetController("EternalNightSubPage");
		IsShowInfoPop = ((GComponent)this).GetController("IsShowInfoPop");
		DetailDisplaying = ((GComponent)this).GetController("DetailDisplaying");
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		n218 = (GImage)((GComponent)this).GetChild("n218");
		n204 = (GImage)((GComponent)this).GetChild("n204");
		n148 = (GImage)((GComponent)this).GetChild("n148");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		n149 = (GImage)((GComponent)this).GetChild("n149");
		n150 = (GImage)((GComponent)this).GetChild("n150");
		n151 = (GImage)((GComponent)this).GetChild("n151");
		n205 = (GImage)((GComponent)this).GetChild("n205");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		n219 = (GImage)((GComponent)this).GetChild("n219");
		n206 = (GImage)((GComponent)this).GetChild("n206");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		n177 = (GTextField)((GComponent)this).GetChild("n177");
		string id = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n177).id;
		((GObject)n177).text = LanguagesManager.GetDesc(id);
		IZId = (GTextField)((GComponent)this).GetChild("IZId");
		n179 = (GGroup)((GComponent)this).GetChild("n179");
		n171 = (GTextField)((GComponent)this).GetChild("n171");
		string id2 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n171).id;
		((GObject)n171).text = LanguagesManager.GetDesc(id2);
		n172 = (GTextField)((GComponent)this).GetChild("n172");
		string id3 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n172).id;
		((GObject)n172).text = LanguagesManager.GetDesc(id3);
		n173 = (GTextField)((GComponent)this).GetChild("n173");
		string id4 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n173).id;
		((GObject)n173).text = LanguagesManager.GetDesc(id4);
		n174 = (GTextField)((GComponent)this).GetChild("n174");
		string id5 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n174).id;
		((GObject)n174).text = LanguagesManager.GetDesc(id5);
		n175 = (GTextField)((GComponent)this).GetChild("n175");
		string id6 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n175).id;
		((GObject)n175).text = LanguagesManager.GetDesc(id6);
		n176 = (GTextField)((GComponent)this).GetChild("n176");
		string id7 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n176).id;
		((GObject)n176).text = LanguagesManager.GetDesc(id7);
		n170 = (GTextField)((GComponent)this).GetChild("n170");
		string id8 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n170).id;
		((GObject)n170).text = LanguagesManager.GetDesc(id8);
		n208 = (GTextField)((GComponent)this).GetChild("n208");
		string id9 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n208).id;
		((GObject)n208).text = LanguagesManager.GetDesc(id9);
		n220 = (GTextField)((GComponent)this).GetChild("n220");
		string id10 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n220).id;
		((GObject)n220).text = LanguagesManager.GetDesc(id10);
		n221 = (GTextField)((GComponent)this).GetChild("n221");
		string id11 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n221).id;
		((GObject)n221).text = LanguagesManager.GetDesc(id11);
		PagesType0 = (GList)((GComponent)this).GetChild("PagesType0");
		PagesType1 = (GList)((GComponent)this).GetChild("PagesType1");
		PagesType2 = (GList)((GComponent)this).GetChild("PagesType2");
		EternalNightSubPages = (GList)((GComponent)this).GetChild("EternalNightSubPages");
		n160 = (GImage)((GComponent)this).GetChild("n160");
		n161 = (GLoader)((GComponent)this).GetChild("n161");
		n162 = (GTextField)((GComponent)this).GetChild("n162");
		string id12 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n162).id;
		((GObject)n162).text = LanguagesManager.GetDesc(id12);
		n163 = (GTextField)((GComponent)this).GetChild("n163");
		string id13 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n163).id;
		((GObject)n163).text = LanguagesManager.GetDesc(id13);
		n164 = (GTextField)((GComponent)this).GetChild("n164");
		string id14 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n164).id;
		((GObject)n164).text = LanguagesManager.GetDesc(id14);
		n165 = (GTextField)((GComponent)this).GetChild("n165");
		string id15 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n165).id;
		((GObject)n165).text = LanguagesManager.GetDesc(id15);
		n166 = (GTextField)((GComponent)this).GetChild("n166");
		string id16 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n166).id;
		((GObject)n166).text = LanguagesManager.GetDesc(id16);
		n167 = (GTextField)((GComponent)this).GetChild("n167");
		string id17 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n167).id;
		((GObject)n167).text = LanguagesManager.GetDesc(id17);
		n209 = (GTextField)((GComponent)this).GetChild("n209");
		string id18 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n209).id;
		((GObject)n209).text = LanguagesManager.GetDesc(id18);
		n223 = (GTextField)((GComponent)this).GetChild("n223");
		string id19 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n223).id;
		((GObject)n223).text = LanguagesManager.GetDesc(id19);
		n224 = (GTextField)((GComponent)this).GetChild("n224");
		string id20 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n224).id;
		((GObject)n224).text = LanguagesManager.GetDesc(id20);
		RankList = (GList)((GComponent)this).GetChild("RankList");
		n180 = (GImage)((GComponent)this).GetChild("n180");
		MedalIcon = (GLoader)((GComponent)this).GetChild("MedalIcon");
		n185 = (GImage)((GComponent)this).GetChild("n185");
		n184 = (GImage)((GComponent)this).GetChild("n184");
		n186 = (GTextField)((GComponent)this).GetChild("n186");
		string id21 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n186).id;
		((GObject)n186).text = LanguagesManager.GetDesc(id21);
		n182 = (GMovieClip)((GComponent)this).GetChild("n182");
		n183 = (GMovieClip)((GComponent)this).GetChild("n183");
		MyRankingInfo = (UI_com_MyRankingInfo)(object)((GComponent)this).GetChild("MyRankingInfo");
		BonusDetailBtn = (UI_btn_BonusDetail)(object)((GComponent)this).GetChild("BonusDetailBtn");
		n189 = (GTextField)((GComponent)this).GetChild("n189");
		string id22 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n189).id;
		((GObject)n189).text = LanguagesManager.GetDesc(id22);
		n241 = (GGroup)((GComponent)this).GetChild("n241");
		n240 = (GImage)((GComponent)this).GetChild("n240");
		n239 = (GTextField)((GComponent)this).GetChild("n239");
		string id23 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n239).id;
		((GObject)n239).text = LanguagesManager.GetDesc(id23);
		n190 = (GImage)((GComponent)this).GetChild("n190");
		n193 = (GGroup)((GComponent)this).GetChild("n193");
		n191 = (GTextField)((GComponent)this).GetChild("n191");
		string id24 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n191).id;
		((GObject)n191).text = LanguagesManager.GetDesc(id24);
		NextUpdateTime = (GTextField)((GComponent)this).GetChild("NextUpdateTime");
		n187 = (GTextField)((GComponent)this).GetChild("n187");
		string id25 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n187).id;
		((GObject)n187).text = LanguagesManager.GetDesc(id25);
		n212 = (GTextField)((GComponent)this).GetChild("n212");
		string id26 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n212).id;
		((GObject)n212).text = LanguagesManager.GetDesc(id26);
		n213 = (GTextField)((GComponent)this).GetChild("n213");
		string id27 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n213).id;
		((GObject)n213).text = LanguagesManager.GetDesc(id27);
		n214 = (GTextField)((GComponent)this).GetChild("n214");
		string id28 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n214).id;
		((GObject)n214).text = LanguagesManager.GetDesc(id28);
		n243 = (GTextField)((GComponent)this).GetChild("n243");
		string id29 = "ui://ylvfgf90uku34p".Replace("ui://", "") + "-" + ((GObject)n243).id;
		((GObject)n243).text = LanguagesManager.GetDesc(id29);
		n215 = (GGroup)((GComponent)this).GetChild("n215");
		ContributionsDetail = (UI_com_info01)(object)((GComponent)this).GetChild("ContributionsDetail");
		BrawlFightScore = (UI_com_info03)(object)((GComponent)this).GetChild("BrawlFightScore");
		MyContributionDetail = (UI_com_info01)(object)((GComponent)this).GetChild("MyContributionDetail");
		DamagesDetail = (UI_com_info02)(object)((GComponent)this).GetChild("DamagesDetail");
		BonusInfoDialogMask = (GGraph)((GComponent)this).GetChild("BonusInfoDialogMask");
		BonusInfoDialog = (UI_com_BonusInfoDialog)(object)((GComponent)this).GetChild("BonusInfoDialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("IzConfigId", out var value))
		{
			_izConfigId = (string)value;
		}
		if (parameters.TryGetValue("UIType", out var value2))
		{
			CurUIType = (UIType)value2;
			if (CurUIType == UIType.EternalNight && IsBrawlEvent)
			{
				CurUIType = UIType.BrawlFight;
			}
			UITypeController.selectedIndex = (int)CurUIType;
		}
		if (parameters.TryGetValue("OnClose", out var value3))
		{
			OnClose = (UICallbackParam<Action>)value3;
		}
		Data = new GvG3LeaderboardModel();
		CurUserId = GameController.Contexts.gameState.user.value.UserId;
		if (Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement)
		{
			CurUserCampId = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.CampId;
			CurIZShowName = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.IZShowName;
			CurCacheId = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.LastIZId}";
		}
		else
		{
			CurUserCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			CurIZShowName = Singleton<GvGMode3RoomManager>.Instance.CurIzName;
			CurCacheId = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}";
		}
		if (CurUIType == UIType.Expedition)
		{
			PagesType0.selectedIndex = 0;
			OnChangePagesType(PagesType0);
		}
		else if (CurUIType == UIType.EternalNight)
		{
			PagesType1.selectedIndex = 0;
			EternalNightSubPage.selectedIndex = 0;
			OnChangePagesType(PagesType1);
		}
		else
		{
			if (CurUIType != UIType.BrawlFight)
			{
				throw new Exception("错误的排行榜类型");
			}
			PagesType2.selectedIndex = 0;
			OnChangePagesType(PagesType2);
		}
		OnRefresh();
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
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		PagesType0.onClickItem.Add((EventCallback0)delegate
		{
			OnChangePagesType(PagesType0);
		});
		PagesType1.onClickItem.Add((EventCallback0)delegate
		{
			OnChangePagesType(PagesType1);
		});
		PagesType2.onClickItem.Add((EventCallback0)delegate
		{
			OnChangePagesType(PagesType2);
		});
		EternalNightSubPage.onChanged.Add(new EventCallback0(OnChangeEternalNightSubPage));
		RankingType.onChanged.Add(new EventCallback0(OnChangeRankingType));
		((GObject)MyRankingInfo.myContributionBtn).onClick.Add(new EventCallback0(OpenMyContributionDialog));
		((GObject)MyRankingInfo.showDetailBtn).onClick.Add(new EventCallback0(OnClickBrawlEventShowMyDetail));
		((GObject)BonusDetailBtn).onClick.Set(new EventCallback0(OnOpenBonusDetailDialog));
		((GObject)MyRankingInfo.BonusItem).onClick.Add(new EventCallback0(OnClickBonusItem));
		((GObject)BonusInfoDialogMask).onClick.Add(new EventCallback0(OnCloseBonusDetailDialog));
		((GObject)ContributionsDetail.Close).onClick.Set(new EventCallback0(HideContributionsDetail));
		((GObject)MyContributionDetail.Close).onClick.Set(new EventCallback0(HideMyContributionDetail));
		((GObject)BrawlFightScore.Close).onClick.Set(new EventCallback0(HideMyContributionDetail));
		((GObject)DamagesDetail.Close).onClick.Set(new EventCallback0(HideContributionsDetail));
		if (!Singleton<GvGMode3RoomManager>.Instance.IsRoomClosed)
		{
			WorldStateManager instance = Singleton<WorldStateManager>.Instance;
			instance.OnCampProgressChange = (Action)Delegate.Combine(instance.OnCampProgressChange, new Action(OnRefresh));
		}
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		PagesType0.onClickItem.Clear();
		PagesType1.onClickItem.Clear();
		PagesType2.onClickItem.Clear();
		EternalNightSubPage.onChanged.Clear();
		RankingType.onChanged.Clear();
		((GObject)MyRankingInfo.myContributionBtn).onClick.Clear();
		((GObject)MyRankingInfo.showDetailBtn).onClick.Clear();
		((GObject)BonusDetailBtn).onClick.Clear();
		((GObject)MyRankingInfo.BonusItem).onClick.Clear();
		((GObject)BonusInfoDialogMask).onClick.Clear();
		((GObject)ContributionsDetail.Close).onClick.Clear();
		((GObject)MyContributionDetail.Close).onClick.Clear();
		((GObject)BrawlFightScore.Close).onClick.Clear();
		((GObject)DamagesDetail.Close).onClick.Clear();
		if (!Singleton<GvGMode3RoomManager>.Instance.IsRoomClosed)
		{
			WorldStateManager instance = Singleton<WorldStateManager>.Instance;
			instance.OnCampProgressChange = (Action)Delegate.Remove(instance.OnCampProgressChange, new Action(OnRefresh));
		}
	}

	private void OnClickBonusItem()
	{
		if (!CurLeaderboardData.IsBonusClaimed)
		{
			((GObject)MyRankingInfo.BonusItem).touchable = false;
			Singleton<GvGMode3RoomManager>.Instance.ClaimSingleSettlementLeaderboardBonus(CurLeaderboardType, delegate
			{
				((GObject)MyRankingInfo.BonusItem).touchable = true;
				CurLeaderboardData.IsBonusClaimed = true;
				RenderMyRandInfo();
			}, delegate
			{
				((GObject)MyRankingInfo.BonusItem).touchable = true;
			});
		}
		else
		{
			FGUIManager.Instance.ItemTip(CurLeaderboardData.BonusItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
	}

	private void OnChangePagesType(GList tabList)
	{
		int selectedIndex = ((UI_btn_PageTabType)(object)((GComponent)tabList).GetChildAt(tabList.selectedIndex)).RankingType.selectedIndex;
		RankingType.selectedIndex = selectedIndex;
	}

	private void OnChangeRankingType()
	{
		CurLeaderboardType = (eLeaderboardType)RankingType.selectedIndex;
		OnRefresh();
		HideContributionsDetail();
	}

	private void OnChangeEternalNightSubPage()
	{
		CurLeaderboardSubType = (eLeaderboardSubType)EternalNightSubPage.selectedIndex;
		OnRefresh();
	}

	private void OnRefresh()
	{
		RankList.numItems = 0;
		Data.GetData(CurLeaderboardType, CurLeaderboardSubType, delegate(GvGMode3LeaderboardData leaderboardData)
		{
			if (CurLeaderboardSubType == eLeaderboardSubType.Today && (Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement || (Singleton<WorldStateManager>.Instance.Data.ProgressData.HasSettlement && leaderboardData.RankList.Count == 0)))
			{
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ResetNextFrame());
				List<string> arg = new List<string> { "GvG3LeaderboardTips".ToLanguage() };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
			else
			{
				CurLeaderboardData = leaderboardData;
				UpdateRender();
			}
		});
	}

	private void OpenMyContributionDialog()
	{
		DetailDisplaying.SetSelectedIndex(3);
		Singleton<WorldStateManager>.Instance.GetAllContributionExcludingBuy(UpdateLoadingStatus);
		void UpdateLoadingStatus(List<Contribution> contributions)
		{
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			contributions.Sort(UI_com_DailyReward.ContributionInfoSort);
			MyContributionDetail.Contributions.itemRenderer = new ListItemRenderer(RenderContributionsDetail);
			MyContributionDetail.Contributions.numItems = contributions.Count;
			void RenderContributionsDetail(int index, GObject obj)
			{
				if (!(obj is UI_com_infoSlot1 uI_com_infoSlot))
				{
					ILRuntimeDebug.LogError("RenderContributionsDetail:obj is not UI_com_infoSlot1");
				}
				else
				{
					Contribution contribution = contributions[index];
					((GObject)uI_com_infoSlot.Title).text = contribution.Key;
					((GObject)uI_com_infoSlot.LevelText).text = contribution.Value.ToString();
				}
			}
		}
	}

	private void OnClickBrawlEventShowMyDetail()
	{
		if (CurUIType == UIType.Expedition)
		{
			OpenMyContributionDialog();
		}
		else
		{
			ShowMyBrawlFightScore();
		}
	}

	private void ShowMyBrawlFightScore()
	{
		DetailDisplaying.SetSelectedIndex(5);
		Data.GetData(CurLeaderboardType, CurLeaderboardSubType, delegate(GvGMode3LeaderboardData leaderboardData)
		{
			if (CurLeaderboardSubType == eLeaderboardSubType.Today && (Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement || (Singleton<WorldStateManager>.Instance.Data.ProgressData.HasSettlement && leaderboardData.RankList.Count == 0)))
			{
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ResetNextFrame());
				List<string> arg = new List<string> { "GvG3LeaderboardTips".ToLanguage() };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
			else
			{
				CurLeaderboardData = leaderboardData;
				List<GvGMode3PlayerRankDataDetail> detailList = CurLeaderboardData.MyBrawlEventRankData?.RankDataDetail;
				RefreshBrawlFightInfoDetail(detailList, isSelf: true);
			}
		});
	}

	private void OnOpenBonusDetailDialog()
	{
		IsShowInfoPop.selectedIndex = 1;
		BonusInfoDialog.Open(CurLeaderboardType, Data.IZConfigId);
	}

	private void OnCloseBonusDetailDialog()
	{
		IsShowInfoPop.selectedIndex = 0;
	}

	private void HideMyContributionDetail()
	{
		DetailDisplaying.SetSelectedIndex(0);
	}

	private void UpdateRender()
	{
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		int num = (int)GameController.Instance.GetServerTime();
		((GObject)IZId).text = CurIZShowName ?? "";
		CampId.selectedIndex = CurUserCampId;
		UI_btn_SubPageTab1 uI_btn_SubPageTab = ((GComponent)EternalNightSubPages).GetChildAt(1) as UI_btn_SubPageTab1;
		if (Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement)
		{
			((GObject)uI_btn_SubPageTab.Date).text = "GvG3LeaderboardTab".ToLanguage();
		}
		else
		{
			((GObject)uI_btn_SubPageTab.Date).text = DateTimeHelper.ParseTimeStamp(num).ToString("(MM/dd)");
		}
		IsFinalized.selectedIndex = (Data.IsAllRankingFinalized ? 1 : 0);
		HasMedal.selectedIndex = ((Data.IsAllRankingFinalized && CurLeaderboardData.MyRanking == 0) ? 1 : 0);
		if (Data.NextUpdateTimestamp > num && !Timers.inst.Exists(new TimerCallback(RefreshNextUpdateTime)))
		{
			Timers.inst.Add(1f, 0, new TimerCallback(RefreshNextUpdateTime));
		}
		RankList.SetVirtual();
		RankList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderRankSlot(i, o as UI_com_RankSlot);
		};
		RankList.numItems = CurLeaderboardData.ListMaxCount;
		RenderMyRandInfo();
	}

	private void RefreshNextUpdateTime(object param)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		int num = (int)GameController.Instance.GetServerTime();
		int num2 = Math.Max(0, Data.NextUpdateTimestamp - num);
		((GObject)NextUpdateTime).text = UiHelper.ParseTime(num2) ?? "";
		if (num2 == 0)
		{
			Timers.inst.Remove(new TimerCallback(RefreshNextUpdateTime));
			Data.ClearCache();
			OnRefresh();
		}
	}

	private void RenderRankSlot(int i, UI_com_RankSlot slot)
	{
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		int num = i + 1;
		slot.RankingTopThree.selectedIndex = Math.Min(num, 4);
		((GObject)slot.Ranking).text = $"{num}";
		if (i >= CurLeaderboardData.RankList.Count)
		{
			slot.IsEmpty.selectedIndex = 1;
			return;
		}
		slot.IsEmpty.selectedIndex = 0;
		GvGMode3PlayerRankInfo gvGMode3PlayerRankInfo = CurLeaderboardData.RankList[i];
		if (IsBrawlEvent && gvGMode3PlayerRankInfo.Rank > 0)
		{
			((GObject)slot.Ranking).text = $"{gvGMode3PlayerRankInfo.Rank}";
			slot.RankingTopThree.selectedIndex = Math.Min(num, 4);
		}
		((GObject)slot.RankingData).text = gvGMode3PlayerRankInfo.RankData.ShortNumberFormat() ?? "";
		slot.RankingType.selectedIndex = RankingType.selectedIndex;
		((GObject)slot).data = gvGMode3PlayerRankInfo.UserId;
		slot.IsMe.selectedIndex = ((CurUserId == gvGMode3PlayerRankInfo.UserId) ? 1 : 0);
		slot.ProfileDisplay.RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayLeft>
		{
			CacheVersion = CurCacheId,
			UserId = gvGMode3PlayerRankInfo.UserId,
			CampId = gvGMode3PlayerRankInfo.CampId,
			OnProfileLoaded = delegate(UI_com_ProfileDisplayLeft displayUi)
			{
				displayUi.Style.SetSelectedIndex((((GComponent)displayUi.Medals).numChildren <= 0) ? 1 : 0);
			}
		}, gvGMode3PlayerRankInfo.UserId);
		((GButton)slot.DetailInfo).onChanged.Clear();
		if (IsShowDetailBtn())
		{
			((GObject)slot.DetailInfo).data = i;
			((GButton)slot.DetailInfo).onChanged.Set(new EventCallback1(OnRankListItemDetailChanged));
		}
		slot.button.onChanged.Add((EventCallback1)delegate
		{
			if (slot.button.selectedIndex == 0)
			{
				HideContributionsDetail();
			}
		});
	}

	private bool IsShowDetailBtn()
	{
		List<eLeaderboardType> list = new List<eLeaderboardType>
		{
			eLeaderboardType.远征总贡献榜_阵营,
			eLeaderboardType.采集贡献榜_全副本,
			eLeaderboardType.BOSS单日最高输出榜_全副本,
			eLeaderboardType.乱斗永夜个人积分榜,
			eLeaderboardType.乱斗永夜个人获胜榜
		};
		return list.Contains(CurLeaderboardType);
	}

	private void RenderMyRandInfo()
	{
		UI_com_MyRankingInfo slot = MyRankingInfo;
		if (CurLeaderboardData.MyRanking == -1)
		{
			slot.IsEmpty.selectedIndex = 1;
			((GObject)slot.Ranking).text = "0";
			((GObject)slot.EmptyTip).text = "~";
		}
		else
		{
			slot.IsEmpty.selectedIndex = 0;
			int myRanking = CurLeaderboardData.MyRanking;
			slot.RankingTopThree.selectedIndex = Math.Min(myRanking, 4);
			((GObject)slot.Ranking).text = $"{myRanking}";
		}
		((GObject)slot.RankingData).text = $"{CurLeaderboardData.MyRankData}";
		slot.RankingType.selectedIndex = RankingType.selectedIndex;
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(CurCacheId, CurUserId, delegate(UserProfile profile)
		{
			((GObject)slot.PlayerName).text = profile.Name;
		}));
		slot.BonusState.selectedIndex = (IsBrawlEvent ? 4 : 0);
	}

	private IEnumerator ResetNextFrame()
	{
		yield return null;
		EternalNightSubPage.selectedIndex = 0;
	}

	private void OnRankListItemDetailChanged(EventContext context)
	{
		EventDispatcher sender = context.sender;
		GButton val = (GButton)(object)((sender is GButton) ? sender : null);
		if (val == null)
		{
			ILRuntimeDebug.LogError("OnRankListItemDetailChanged:context.sender is not GButton");
			return;
		}
		HideContributionsDetail();
		if (!val.selected)
		{
			((GObject)val).parent.GetController("button").SetSelectedIndex(0);
			return;
		}
		int selectedIndex = (int)((GObject)val).data;
		RankList.selectedIndex = selectedIndex;
		((GObject)val).parent.GetController("button").SetSelectedIndex(1);
		RefreshDetail();
	}

	private void RefreshDetail()
	{
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		GvGMode3PlayerRankInfo gvGMode3PlayerRankInfo = CurLeaderboardData.RankList[RankList.selectedIndex];
		List<GvGMode3PlayerRankDataDetail> rankDataDetail = gvGMode3PlayerRankInfo.RankDataDetail;
		List<FinalProgressBossDamageRecord> finalProgressDetail;
		List<GvGMode3PlayerRankDataDetail> disPlayList;
		if (CurLeaderboardType == eLeaderboardType.乱斗永夜个人积分榜 || CurLeaderboardType == eLeaderboardType.乱斗永夜个人获胜榜)
		{
			RenderOtherBrawlFightDetailInfo();
		}
		else if (rankDataDetail != null && rankDataDetail.Count > 0 && !string.IsNullOrEmpty(rankDataDetail[0].Other))
		{
			DetailDisplaying.SetSelectedIndex(2);
			finalProgressDetail = rankDataDetail[0].FinalProgressDetail;
			if (finalProgressDetail == null || finalProgressDetail.Count == 0)
			{
				DamagesDetail.HasLogs.selectedIndex = 0;
				return;
			}
			DamagesDetail.HasLogs.selectedIndex = 1;
			FinalProgressBossDamageRecord finalProgressBossDamageRecord = finalProgressDetail[0];
			DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp(finalProgressBossDamageRecord.Timestamp);
			((GObject)DamagesDetail.Time).text = UiHelper.GetDateStringMMdd(dateTimeOffset);
			DamagesDetail.BattleLog.itemRenderer = new ListItemRenderer(RenderDamageDetail);
			DamagesDetail.BattleLog.numItems = finalProgressDetail.Count;
		}
		else if (rankDataDetail != null)
		{
			disPlayList = new List<GvGMode3PlayerRankDataDetail>();
			disPlayList.AddRange(rankDataDetail);
			disPlayList.Sort((GvGMode3PlayerRankDataDetail a, GvGMode3PlayerRankDataDetail b) => (int)(b.Value - a.Value));
			DetailDisplaying.SetSelectedIndex(1);
			ContributionsDetail.Contributions.itemRenderer = new ListItemRenderer(RenderContributionsDetail);
			ContributionsDetail.Contributions.numItems = disPlayList.Count;
		}
		void RenderContributionsDetail(int index, GObject obj)
		{
			if (!(obj is UI_com_infoSlot1 uI_com_infoSlot))
			{
				ILRuntimeDebug.LogError("RenderContributionsDetail:obj is not UI_com_infoSlot1");
			}
			else
			{
				GvGMode3PlayerRankDataDetail gvGMode3PlayerRankDataDetail = disPlayList[index];
				((GObject)uI_com_infoSlot.Title).text = gvGMode3PlayerRankDataDetail.ContributionSource;
				((GObject)uI_com_infoSlot.LevelText).text = gvGMode3PlayerRankDataDetail.ContributionValue;
			}
		}
		void RenderDamageDetail(int index, GObject obj)
		{
			if (!(obj is UI_com_infoSlot2 uI_com_infoSlot))
			{
				ILRuntimeDebug.LogError("RenderDamageDetail:obj is not UI_com_infoSlot2");
			}
			else
			{
				FinalProgressBossDamageRecord finalProgressBossDamageRecord2 = finalProgressDetail[index];
				if (finalProgressBossDamageRecord2 == null)
				{
					uI_com_infoSlot.IsNotEmpty.selectedIndex = 0;
				}
				else
				{
					ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(finalProgressBossDamageRecord2.SipRace);
					string iconUrl = ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).IconUrl;
					uI_com_infoSlot.IsNotEmpty.selectedIndex = 1;
					uI_com_infoSlot.Rank.Rank.selectedIndex = index;
					uI_com_infoSlot.ShipIcon.Icon.url = iconUrl;
					((GObject)uI_com_infoSlot.Damage).text = finalProgressBossDamageRecord2.TotalDamage.ShortNumberFormat();
				}
			}
		}
	}

	private void RenderOtherBrawlFightDetailInfo()
	{
		GvGMode3PlayerRankInfo gvGMode3PlayerRankInfo = CurLeaderboardData.RankList[RankList.selectedIndex];
		List<GvGMode3PlayerRankDataDetail> rankDataDetail = gvGMode3PlayerRankInfo.RankDataDetail;
		DetailDisplaying.SetSelectedIndex(4);
		RefreshBrawlFightInfoDetail(rankDataDetail, isSelf: false);
	}

	private void RefreshBrawlFightInfoDetail(List<GvGMode3PlayerRankDataDetail> detailList, bool isSelf)
	{
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		BrawlFightScore.isSelf.SetSelectedIndex(isSelf ? 1 : 0);
		if (detailList == null || detailList.Count == 0)
		{
			BrawlFightScore.Contributions.numItems = 0;
			return;
		}
		bool flag = CurLeaderboardType == eLeaderboardType.乱斗永夜个人积分榜;
		BrawlFightScore.RankType.SetSelectedIndex((!flag) ? 1 : 0);
		if (flag)
		{
			BrawlFightScore.Contributions.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
			{
				//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
				//IL_00bc: Expected O, but got Unknown
				//IL_011f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0129: Expected O, but got Unknown
				UI_com_infoSlot3 btn = (UI_com_infoSlot3)(object)item;
				BrawlEventIZRankDetailInfo brawlEventIZRankDetail = detailList[index].BrawlEventIZRankDetail;
				((GObject)btn.mainScore).text = brawlEventIZRankDetail.Score.ToString();
				int num = DayRelatedToFinalStep(brawlEventIZRankDetail.Day);
				bool flag2 = num > 0;
				btn.isNormalScore.SetSelectedIndex(flag2 ? 1 : 0);
				((GObject)btn.Title).text = "CsharpNewArrivalRewardName".ToLanguage().Format(num);
				((GObject)btn.OtherSource).onClickLink.Set(new EventCallback1(OnClickOtherScoreSource));
				bool flag3 = brawlEventIZRankDetail.SubScore > 0;
				btn.hideAddition.SetSelectedIndex((!flag3) ? 1 : 0);
				if (flag3)
				{
					((GObject)btn.additionScore).text = brawlEventIZRankDetail.SubScore.ToString();
				}
				((GObject)btn.additionScoreBg).onClick.Set((EventCallback1)delegate
				{
					//IL_002e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0034: Unknown result type (might be due to invalid IL or missing references)
					FairyGUITip.ShowTip((GObject)(object)btn.additionScoreBg, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
					{
						((GObject)popup.title).text = "GvG3BrawlEventExtraScore".ToLanguage();
					});
				});
			};
			BrawlFightScore.Contributions.numItems = detailList.Count;
		}
		else
		{
			BrawlFightScore.winCount.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
			{
				UI_com_infoSlot4 uI_com_infoSlot = (UI_com_infoSlot4)(object)item;
				BrawlEventIZRankDetailInfo brawlEventIZRankDetail = detailList[index].BrawlEventIZRankDetail;
				((GObject)uI_com_infoSlot.winCount).text = brawlEventIZRankDetail.WinnerCount.ToString();
				int num = DayRelatedToFinalStep(brawlEventIZRankDetail.Day);
				((GObject)uI_com_infoSlot.Title).text = "CsharpNewArrivalRewardName".ToLanguage().Format(num);
				bool flag2 = brawlEventIZRankDetail.Score > 0;
				uI_com_infoSlot.isShowScore.SetSelectedIndex(flag2 ? 1 : 0);
				((GObject)uI_com_infoSlot.mainScore).text = brawlEventIZRankDetail.Score.ToString();
			};
			BrawlFightScore.winCount.numItems = detailList.Count;
		}
	}

	private void OnClickOtherScoreSource(EventContext context)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		EventDispatcher sender = context.sender;
		GTextField target = (GTextField)(object)((sender is GTextField) ? sender : null);
		FairyGUITip.ShowTip((GObject)(object)target, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "LeaderBoardOtherScoreSourceTip".ToLanguage();
		});
	}

	private int DayRelatedToFinalStep(int day)
	{
		int brawlEventFinalStartDay = WorldMapConfigHelper.Configs.BrawlEventFinalStartDay;
		return day - brawlEventFinalStartDay + 1;
	}

	private void HideContributionsDetail()
	{
		if (DetailDisplaying.selectedIndex == 0)
		{
			return;
		}
		int selectedIndex = RankList.selectedIndex;
		if (selectedIndex >= 0)
		{
			int num = RankList.ItemIndexToChildIndex(selectedIndex);
			if (num < 0 || num >= ((GComponent)RankList).numChildren)
			{
				RankList.selectedIndex = -1;
				((GComponent)RankList).EnsureBoundsCorrect();
				HideContributionsDetail();
			}
			else if (!(((GComponent)RankList).GetChildAt(num) is UI_com_RankSlot uI_com_RankSlot))
			{
				ILRuntimeDebug.LogError("HideContributionsDetail:rankSlot is not UI_com_RankSlot");
			}
			else
			{
				uI_com_RankSlot.button.SetSelectedIndex(0);
				RankList.selectedIndex = -1;
				((GComponent)RankList).EnsureBoundsCorrect();
				HideContributionsDetail();
			}
		}
		else
		{
			DetailDisplaying.SetSelectedIndex(0);
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
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if (Timers.inst.Exists(new TimerCallback(RefreshNextUpdateTime)))
		{
			Timers.inst.Remove(new TimerCallback(RefreshNextUpdateTime));
		}
	}

	public void End()
	{
		OnClose?.Callback?.Invoke();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
