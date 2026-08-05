using System;
using System.Collections.Generic;
using FairyGUI;

namespace Shift.Legion.Common.Services;

public interface IUiService : IService
{
	void OpenPanel(string identifier, Dictionary<string, object> parameters, bool multiMode = false, bool ignoreQueue = false, Action<Exception> errorCallback = null, Action ui_callback = null);

	void ClosePanel(string identifier, bool reservePackageRes = false);

	void OpenDialog(string identifier, Dictionary<string, object> parameters);

	void CloseDialog(string identifier);

	void CloseAllDialog();

	void ShowNewbieMissionPanel(bool isBattleField = false);

	void HideNewbieMissionPanel();

	void CloseAll(bool ignoreLoading = true, List<string> ignoreUI = null);

	bool HasShowingUi();

	bool IsRecoveringBackupUis();

	void StartRecoverBackup();

	GObject GetShowingUi(string panelsName);

	bool HasShowingUi(string panelsName);

	int SetUiNotTouchable(string identifier);

	void SetUiTouchable(int changeId);

	void ClearUiTouchable();

	void ShowWaitingAnimation(bool show);

	void ShowPaymentWaitingAnimation(bool show);

	void CloseSomePanels(List<string> panelsName, bool reservePackageRes = false, bool ignoreLoading = true, bool edgeMaskVisible = false);

	void PushBackupAndCloseAllUIs(List<string> ignoreList = null, bool toBackupStack = true, bool closeHidden = false);

	void PushBackupAndHideAllUIs(List<string> ignoreList = null);

	void RecoverLastBackup(int skipBackupCount = 0);

	void RecoverLastHiddenUIs(int skipBackupCount = 0);

	void HideUis(List<string> uiList, bool uiVisible = false);

	void AddDontCloseUisOnCloseAll(List<string> uis);

	void ClearDontCloseUisOnCloseAll();

	void SetUiVisible(string uiName, bool visible);
}
