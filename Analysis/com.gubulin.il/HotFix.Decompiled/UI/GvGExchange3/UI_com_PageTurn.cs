using System;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.GvGExchange3;

public class UI_com_PageTurn : GComponent
{
	public GImage n5;

	public GTextField Pages;

	public UI_btn_TurnPageLeftBtn Previous;

	public UI_btn_TurnPageRightBtn Next;

	public const string URL = "ui://tt2iq07oj1h830";

	public static string Name = "UI_com_PageTurn";

	private int _selectingPageNumber;

	private int _totalPageCount;

	private Action<int> _onPageNumberChange;

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h830";
	}

	public static UI_com_PageTurn CreateInstance()
	{
		return (UI_com_PageTurn)(object)UIPackage.CreateObject("GvGExchange3", "com_PageTurn");
	}

	public static UI_com_PageTurn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PageTurn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h830", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Pages = (GTextField)((GComponent)this).GetChild("Pages");
		Previous = (UI_btn_TurnPageLeftBtn)(object)((GComponent)this).GetChild("Previous");
		Next = (UI_btn_TurnPageRightBtn)(object)((GComponent)this).GetChild("Next");
	}

	public void Init(Action<int> action, int initialPage, int totalPageCount)
	{
		_onPageNumberChange = action;
		_selectingPageNumber = initialPage;
		_totalPageCount = totalPageCount;
	}

	public void RegisterEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Previous).onClick.Set(new EventCallback0(TurnLastPage));
		((GObject)Next).onClick.Set(new EventCallback0(TurnNextPage));
	}

	public void UnregisterEvent()
	{
		((GObject)Previous).onClick.Clear();
		((GObject)Next).onClick.Clear();
	}

	public void Destroy()
	{
		_onPageNumberChange = null;
	}

	public void RenderPageNumber(int pageNumber, int totalPageCount)
	{
		_selectingPageNumber = pageNumber;
		_totalPageCount = totalPageCount;
		((GObject)Pages).text = $"{_selectingPageNumber}/{_totalPageCount}";
		UpdateBtnEnabled();
	}

	private void UpdateBtnEnabled()
	{
		((GObject)Previous).enabled = _selectingPageNumber > 1;
		((GObject)Next).enabled = _selectingPageNumber < _totalPageCount;
	}

	private void TurnLastPage()
	{
		if (_selectingPageNumber > 1)
		{
			_selectingPageNumber = Mathf.Max(1, _selectingPageNumber - 1);
			_onPageNumberChange?.Invoke(_selectingPageNumber);
		}
	}

	private void TurnNextPage()
	{
		if (_selectingPageNumber < _totalPageCount)
		{
			_selectingPageNumber = Mathf.Min(_totalPageCount, _selectingPageNumber + 1);
			_onPageNumberChange?.Invoke(_selectingPageNumber);
		}
	}
}
