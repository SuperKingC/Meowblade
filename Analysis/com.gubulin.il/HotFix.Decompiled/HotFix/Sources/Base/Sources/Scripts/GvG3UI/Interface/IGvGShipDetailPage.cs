using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using UI.GvGShipDetail;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;

public interface IGvGShipDetailPage
{
	int PageIndex { get; set; }

	bool PageActivated { get; set; }

	void Init(GvGShipDetailModel data, UI_GvGShipDetailPanel parentPanel);

	void RegisterUiEventListeners();

	void UnregisterUiEventListeners();

	void OnActivate();

	void OnInactivate();

	void OnShipStateChange();

	bool ConfigModified();

	void ConfirmOperationOnChangePage(Action changePage, Action revert);

	void ConfirmOperationOnClose(Action endAction);

	void OnDestroy();
}
