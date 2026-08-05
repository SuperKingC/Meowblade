using System;
using UnityEngine;

namespace FairyGUI.Utils;

public class FairyGuiPageTurner
{
	private const int _MIN_PAGE_INDEX = 0;

	private readonly IFairyGuiPageTurner _pageTurner;

	private readonly int _maxPageIndex;

	private readonly Func<int, string> _onPageNumberChange;

	private int _selectingPageIndex;

	public FairyGuiPageTurner(FairyGuiPageTurnerCreateParams createParams)
	{
		_pageTurner = createParams.PageTurner;
		_onPageNumberChange = createParams.OnPageIndexChange;
		_maxPageIndex = createParams.PageCount - 1;
		_selectingPageIndex = createParams.SelectingPageIndex;
		RegisterClickEvents();
		UpdatePageTurner();
	}

	public void SetSelectingPageIndex(int pageIndex)
	{
		if (pageIndex > 0 && pageIndex < _maxPageIndex)
		{
			_selectingPageIndex = pageIndex;
			UpdatePageTurner();
		}
	}

	private void RegisterClickEvents()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)_pageTurner.ToLast).onClick.Set(new EventCallback0(TurnLastPage));
		((GObject)_pageTurner.ToNext).onClick.Set(new EventCallback0(TurnNextPage));
	}

	private void TurnLastPage()
	{
		if (_selectingPageIndex > 0)
		{
			_selectingPageIndex = Mathf.Max(0, _selectingPageIndex - 1);
			UpdatePageTurner();
		}
	}

	private void TurnNextPage()
	{
		if (_selectingPageIndex < _maxPageIndex)
		{
			_selectingPageIndex = Mathf.Min(_maxPageIndex, _selectingPageIndex + 1);
			UpdatePageTurner();
		}
	}

	private void UpdatePageTurner()
	{
		ChangePageIndex();
		UpdateBtnEnabled();
	}

	private void ChangePageIndex()
	{
		string title = _onPageNumberChange?.Invoke(_selectingPageIndex);
		_pageTurner.RenderTitle(title);
	}

	private void UpdateBtnEnabled()
	{
		((GObject)_pageTurner.ToLast).enabled = _selectingPageIndex > 0;
		((GObject)_pageTurner.ToNext).enabled = _selectingPageIndex < _maxPageIndex;
	}
}
