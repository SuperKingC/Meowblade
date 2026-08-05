using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.OuterTech;
using UI.Tips;
using UnityEngine;

namespace UI.GvGAmplifierForge;

public class UI_com_02 : GComponent
{
	public GImage n181;

	public GImage n184;

	public GImage n198;

	public GImage n195;

	public GImage n196;

	public GImage n191;

	public GImage n183;

	public GTextField n182;

	public GTextField n185;

	public UI_NormalItemSmall sourceIcon;

	public GTextField n187;

	public UI_btn_04 leftArrow;

	public UI_btn_04 rightArrow;

	public GTextField sourceCount;

	public GTextField exchangeCount;

	public GTextField exchangeRateText;

	public GTextField n199;

	public UI_btn__100 add100;

	public UI_btn__100 minus100;

	public UI_NormalItemSmall outComeIcon1;

	public UI_NormalItemSmall outComeIcon2;

	public UI_com_03 splitSlider;

	public GTextField targetCount1;

	public GTextField targetCount2;

	public GTextField outComeCount1;

	public GTextField outComeCount2;

	public GButton confirmBtn;

	public const string URL = "ui://fpjheycbslenv4gd";

	public static string Name = "UI_com_02";

	private static Dictionary<int, List<string>> _levelItems;

	private int _currentRarity;

	private List<string> _currentItems;

	private int _selectedItemIndex;

	private string _selectedItem;

	private int _currentExchangeItemCount;

	private int _splitRate;

	private List<RItem> _outputItems = new List<RItem>();

	public Action ClosePage;

	public static string GetURL()
	{
		return "ui://fpjheycbslenv4gd";
	}

	public static UI_com_02 CreateInstance()
	{
		return (UI_com_02)(object)UIPackage.CreateObject("GvGAmplifierForge", "com_02");
	}

	public static UI_com_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbslenv4gd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n181 = (GImage)((GComponent)this).GetChild("n181");
		n184 = (GImage)((GComponent)this).GetChild("n184");
		n198 = (GImage)((GComponent)this).GetChild("n198");
		n195 = (GImage)((GComponent)this).GetChild("n195");
		n196 = (GImage)((GComponent)this).GetChild("n196");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n183 = (GImage)((GComponent)this).GetChild("n183");
		n182 = (GTextField)((GComponent)this).GetChild("n182");
		string id = "ui://fpjheycbslenv4gd".Replace("ui://", "") + "-" + ((GObject)n182).id;
		((GObject)n182).text = LanguagesManager.GetDesc(id);
		n185 = (GTextField)((GComponent)this).GetChild("n185");
		string id2 = "ui://fpjheycbslenv4gd".Replace("ui://", "") + "-" + ((GObject)n185).id;
		((GObject)n185).text = LanguagesManager.GetDesc(id2);
		sourceIcon = (UI_NormalItemSmall)(object)((GComponent)this).GetChild("sourceIcon");
		n187 = (GTextField)((GComponent)this).GetChild("n187");
		string id3 = "ui://fpjheycbslenv4gd".Replace("ui://", "") + "-" + ((GObject)n187).id;
		((GObject)n187).text = LanguagesManager.GetDesc(id3);
		leftArrow = (UI_btn_04)(object)((GComponent)this).GetChild("leftArrow");
		rightArrow = (UI_btn_04)(object)((GComponent)this).GetChild("rightArrow");
		sourceCount = (GTextField)((GComponent)this).GetChild("sourceCount");
		exchangeCount = (GTextField)((GComponent)this).GetChild("exchangeCount");
		exchangeRateText = (GTextField)((GComponent)this).GetChild("exchangeRateText");
		n199 = (GTextField)((GComponent)this).GetChild("n199");
		string id4 = "ui://fpjheycbslenv4gd".Replace("ui://", "") + "-" + ((GObject)n199).id;
		((GObject)n199).text = LanguagesManager.GetDesc(id4);
		add100 = (UI_btn__100)(object)((GComponent)this).GetChild("add100");
		minus100 = (UI_btn__100)(object)((GComponent)this).GetChild("minus100");
		outComeIcon1 = (UI_NormalItemSmall)(object)((GComponent)this).GetChild("outComeIcon1");
		outComeIcon2 = (UI_NormalItemSmall)(object)((GComponent)this).GetChild("outComeIcon2");
		splitSlider = (UI_com_03)(object)((GComponent)this).GetChild("splitSlider");
		targetCount1 = (GTextField)((GComponent)this).GetChild("targetCount1");
		targetCount2 = (GTextField)((GComponent)this).GetChild("targetCount2");
		outComeCount1 = (GTextField)((GComponent)this).GetChild("outComeCount1");
		outComeCount2 = (GTextField)((GComponent)this).GetChild("outComeCount2");
		confirmBtn = (GButton)((GComponent)this).GetChild("confirmBtn");
	}

	public void Init(Action closePage)
	{
		ClosePage = closePage;
		_currentExchangeItemCount = 0;
		_splitRate = 40;
		int exchangeRate = GetExchangeRate();
		((GObject)exchangeRateText).text = "SkyForgeOpPanelExchangeRateTip".ToLanguage().Format(exchangeRate);
	}

	public void RegisterUiListener()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		((GObject)add100).onClick.Set(new EventCallback0(OnClickAdd100));
		((GObject)minus100).onClick.Set(new EventCallback0(OnClickMinus100));
		((GObject)leftArrow).onClick.Set(new EventCallback0(OnClickLeftArrow));
		((GObject)rightArrow).onClick.Set(new EventCallback0(OnClickRightArrow));
		splitSlider.OnChange = OnSliderValueChange;
		((GObject)confirmBtn).onClick.Set(new EventCallback0(OnClickConfirmForge));
		splitSlider.RegisterUiEventListeners();
	}

	public void UnRegisterUiListener()
	{
		((GObject)add100).onClick.Clear();
		((GObject)minus100).onClick.Clear();
		((GObject)leftArrow).onClick.Clear();
		((GObject)rightArrow).onClick.Clear();
		splitSlider.OnChange = null;
		((GObject)confirmBtn).onClick.Clear();
		splitSlider.UnregisterUiEventListeners();
	}

	public void RefreshWithLevel(int rarity)
	{
		if (_levelItems == null)
		{
			Dictionary<string, List<string>> dictionary = "OuterTechAmpFormula".ToConfiguration<Dictionary<string, List<string>>>();
			_levelItems = new Dictionary<int, List<string>>();
			foreach (KeyValuePair<string, List<string>> item in dictionary)
			{
				if (int.TryParse(item.Key, out var result))
				{
					_levelItems[result] = item.Value;
				}
			}
		}
		_currentRarity = rarity;
		_currentItems = _levelItems[rarity];
		_selectedItemIndex = 0;
		_selectedItem = _currentItems[_selectedItemIndex];
		_currentExchangeItemCount = 0;
		ChangeSourceItemCount(100, showTip: false);
		splitSlider.Init(0, 100, 40);
		RefreshPage();
	}

	private void OnClickAdd100()
	{
		ChangeSourceItemCount(100, showTip: true);
	}

	private void OnClickMinus100()
	{
		ChangeSourceItemCount(-100, showTip: true);
	}

	private void ChangeSourceItemCount(int offset, bool showTip)
	{
		if (_currentItems == null || _currentItems.Count == 0 || _selectedItemIndex < 0 || _selectedItemIndex >= _currentItems.Count)
		{
			return;
		}
		string itemId = _currentItems[_selectedItemIndex];
		int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(itemId);
		int num = _currentExchangeItemCount + offset;
		if (num > itemCount)
		{
			if (showTip)
			{
				"SkyForgeOpPanelAddFailedTip".ToShowLanguageTip();
			}
		}
		else
		{
			_currentExchangeItemCount = num;
		}
		_currentExchangeItemCount = Mathf.Max(0, _currentExchangeItemCount);
		RefreshOutComeCount();
	}

	private void OnClickLeftArrow()
	{
		if (_currentItems != null && _currentItems.Count != 0 && _selectedItemIndex != 0)
		{
			_selectedItemIndex--;
			OnSelectItemChange();
			RefreshPage();
		}
	}

	private void OnClickRightArrow()
	{
		if (_currentItems != null && _currentItems.Count != 0 && _selectedItemIndex != _currentItems.Count - 1)
		{
			_selectedItemIndex++;
			OnSelectItemChange();
			RefreshPage();
		}
	}

	private void OnSelectItemChange()
	{
		_selectedItem = _currentItems[_selectedItemIndex];
		_currentExchangeItemCount = 0;
		ChangeSourceItemCount(100, showTip: false);
	}

	private void OnSliderValueChange()
	{
		_splitRate = splitSlider.Value / 20 * 20;
		RefreshOutComeCount();
	}

	private void RefreshPage()
	{
		if (_currentItems != null && _currentItems.Count != 0)
		{
			((GObject)leftArrow).enabled = _selectedItemIndex > 0;
			((GObject)rightArrow).enabled = _selectedItemIndex < _currentItems.Count - 1;
			RefreshSelectItem();
			RefreshOutComeCount();
		}
	}

	private void RefreshSelectItem()
	{
		List<string> list = new List<string>();
		foreach (string currentItem in _currentItems)
		{
			if (currentItem != _selectedItem)
			{
				list.Add(currentItem);
			}
		}
		_outputItems.Clear();
		_outputItems.Add(new RItem
		{
			ItemId = list[0],
			cnt = 0
		});
		_outputItems.Add(new RItem
		{
			ItemId = list[1],
			cnt = 0
		});
		FGUIManager.Instance.SetItemIconAndFrame(sourceIcon.icon, _selectedItem);
		sourceIcon.icon.InitMaterialIntroductionBtn(_selectedItem);
		((GObject)sourceCount).text = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(_selectedItem).ToString();
		string itemId = list[0];
		FGUIManager.Instance.SetItemIconAndFrame(outComeIcon1.icon, itemId);
		outComeIcon1.icon.InitMaterialIntroductionBtn(itemId);
		((GObject)targetCount1).text = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(itemId).ToString();
		string itemId2 = list[1];
		FGUIManager.Instance.SetItemIconAndFrame(outComeIcon2.icon, itemId2);
		outComeIcon2.icon.InitMaterialIntroductionBtn(itemId2);
		((GObject)targetCount2).text = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(itemId2).ToString();
	}

	private void RefreshOutComeCount()
	{
		if (_outputItems != null && _outputItems.Count != 0)
		{
			int num = _currentExchangeItemCount / 100 * (100 - _splitRate);
			int num2 = _currentExchangeItemCount - num;
			_outputItems[0].cnt = num;
			_outputItems[1].cnt = num2;
			float num3 = (float)GetExchangeRate() / 100f;
			((GObject)exchangeCount).text = $"{_currentExchangeItemCount}";
			((GObject)outComeCount1).text = $"+{(float)num * num3:N0}";
			((GObject)outComeCount2).text = $"+{(float)num2 * num3:N0}";
			((GObject)confirmBtn).enabled = _currentExchangeItemCount > 0;
		}
	}

	private int GetExchangeRate()
	{
		TechData techData = "I67509".GetTechData();
		return Mathf.RoundToInt(techData.EffectValue);
	}

	private void OnClickConfirmForge()
	{
		List<RItem> list = _outputItems.Clone();
		list[0].cnt = (100 - _splitRate) / 10;
		list[1].cnt = _splitRate / 10;
		int cnt = _currentExchangeItemCount / 100;
		Dictionary<string, int> dict = new Dictionary<string, int> { 
		{
			_selectedItem,
			-_currentExchangeItemCount
		} };
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_OuterTechAmpTransform
		{
			Req = new C2S_OuterTechAmpTransform.Request
			{
				Rarity = _currentRarity.ToString(),
				InputAmp = new RItem
				{
					ItemId = _selectedItem,
					cnt = cnt
				},
				OutputItems = list
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_OuterTechAmpTransform.Response response = (C2S_OuterTechAmpTransform.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouseWithOffsetChanges(dict);
				ClosePage?.Invoke();
			}
		});
	}
}
