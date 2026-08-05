using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using HotFix.Sources.Base.Sources.Services.UiService;
using UI.FullScreenAnimation;
using UI.GameEndPanels;
using UI.MilitaryAFKAssistant;
using UI.NewbieMission;
using UI.RollingMarquee;
using UI.Tips;
using UI.Waiting;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class ClickSimulatorHelper
{
	private const string UiNamePrefix = "UI_";

	private static List<string> ignoreUis = new List<string>
	{
		UI_RollingMarqueePanel.Name.Replace("UI_", ""),
		UI_SomeTipPanel.Name.Replace("UI_", ""),
		UI_FullScreenAnimationPanel.Name.Replace("UI_", ""),
		UI_ShowOfflineEarnings.Name.Replace("UI_", ""),
		UI_main_MilitaryAFKAssistant.Name.Replace("UI_", ""),
		UI_NewbieMissionPanel.Name.Replace("UI_", "")
	};

	private static Dictionary<string, List<string>> subUisMap = new Dictionary<string, List<string>>
	{
		{
			UI_GameEndPanelVictory.Name.Replace("UI_", ""),
			new List<string> { UI_DamageMeter.Name.Replace("UI_", "") }
		},
		{
			UI_GameEndPanelFail.Name.Replace("UI_", ""),
			new List<string> { UI_DamageMeter.Name.Replace("UI_", "") }
		}
	};

	private static TipConstants _tipConstants = new TipConstants();

	public static IEnumerator WaitLoadingAnimationDone(float timeout = 5f, float delay = 1f)
	{
		if (delay > 0f)
		{
			yield return (object)new WaitForSeconds(delay);
		}
		float waitingTime = 0f;
		float waitingGap = 0.5f;
		while (HasUiShownOnTop(UI_LoadingPanel.Name))
		{
			if (waitingTime > timeout)
			{
				ILRuntimeDebug.LogError($"[ClickSimulator]WaitLoadingAnimationDone {timeout}s Timeout");
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsCannotEnterBattleField"));
				yield return (object)new WaitForSeconds(waitingGap);
				break;
			}
			yield return (object)new WaitForSeconds(waitingGap);
			waitingTime += waitingGap;
		}
	}

	public static IEnumerator WaitBattleEndPanelShowUp(float timeout = 5f)
	{
		float waitingTime = 0f;
		float waitingGap = 0.5f;
		while (!HasUiShownOnTop(UI_GameEndPanelVictory.Name) && !HasUiShownOnTop(UI_GameEndPanelFail.Name))
		{
			if (waitingTime > timeout)
			{
				ILRuntimeDebug.LogError($"[ClickSimulator]WaitBattleEndPanelShowUp {timeout}s Timeout");
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsBattleTimeout"));
				yield return (object)new WaitForSeconds(waitingGap);
				break;
			}
			yield return (object)new WaitForSeconds(waitingGap);
			waitingTime += waitingGap;
		}
	}

	public static IEnumerator WaitWaitingAnimationDone(float timeout = 5f)
	{
		UI_WaitingPanel waitingPanel = GetWaitingPanel();
		float waitingGap = 0.5f;
		float waitingTime = 0f;
		while (waitingPanel != null && ((GObject)waitingPanel).visible)
		{
			if (waitingTime > timeout)
			{
				ILRuntimeDebug.LogError($"[ClickSimulator]WaitWaitingAnimationDone {timeout}s Timeout");
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsWaitingTimeout"));
				yield return (object)new WaitForSeconds(waitingGap);
				break;
			}
			yield return (object)new WaitForSeconds(waitingGap);
			waitingTime += waitingGap;
		}
	}

	public static IEnumerator WaitForState<T>(Func<T> curStateAction, T targetState, float timeout = 5f, string timeoutErrMsg = null) where T : IComparable
	{
		float waitingGap = 0.5f;
		float waitingTime = 0f;
		T curState = curStateAction();
		while (true)
		{
			object obj = targetState;
			if (curState.Equals(obj))
			{
				break;
			}
			if (waitingTime > timeout)
			{
				ILRuntimeDebug.LogError($"[ClickSimulator]WaitForState {timeout}s Timeout");
				if (string.IsNullOrEmpty(timeoutErrMsg))
				{
					timeoutErrMsg = LanguagesManager.GetDesc("TipsWaitingStateChangeTimeout");
				}
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", timeoutErrMsg);
				yield return (object)new WaitForSeconds(waitingGap);
				break;
			}
			yield return (object)new WaitForSeconds(waitingGap);
			waitingTime += waitingGap;
			curState = curStateAction();
		}
	}

	public static IEnumerator WaitUisClose(float timeout = 5f, params string[] uiNames)
	{
		float waitingTime = 0f;
		float waitingGap = 0.5f;
		while (uiNames.Any((string uiName) => GetUiInst(uiName) != null))
		{
			if (waitingTime > timeout)
			{
				ILRuntimeDebug.LogError(string.Format("[ClickSimulator]WaitUisClose {0} {1}s Timeout, CurrentUis: {2}", string.Join(",", uiNames), timeout, string.Join(",", UnityUiService.Instance.DictUI.Keys)));
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsCloseUiFailed"));
				yield return (object)new WaitForSeconds(waitingGap);
				break;
			}
			yield return (object)new WaitForSeconds(waitingGap);
			waitingTime += waitingGap;
		}
	}

	public static IEnumerator WaitUisShowOnTop(float timeout = 5f, params string[] uiNames)
	{
		float waitingTime = 0f;
		float waitingGap = 0.5f;
		while (uiNames.All((string uiName) => !HasUiShownOnTop(uiName)))
		{
			if (waitingTime > timeout)
			{
				ILRuntimeDebug.LogError(string.Format("[ClickSimulator]WaitUisShowOnTop {0} {1}s Timeout, CurrentUis: {2}", string.Join(",", uiNames), timeout, string.Join(",", UnityUiService.Instance.DictUI.Keys)));
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsOpenUiFailed"));
				yield return (object)new WaitForSeconds(waitingGap);
				break;
			}
			yield return (object)new WaitForSeconds(waitingGap);
			waitingTime += waitingGap;
		}
	}

	public static IEnumerator WaitTryingGetUiInstOnTop(string uiName, float timeout = 5f)
	{
		GComponent uiInst = null;
		float waitingGap = 0.5f;
		float waitingTime = 0f;
		while (!TryGetUiInstOnTop(uiName, out uiInst))
		{
			if (waitingTime > timeout)
			{
				ILRuntimeDebug.LogError(string.Format("[ClickSimulator]WaitTryingGetUiInstOnTop {0} {1}s Timeout, CurrentUis: {2}", uiName, timeout, string.Join(",", UnityUiService.Instance.DictUI.Keys)));
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsOpenUiFailed"));
				yield return (object)new WaitForSeconds(waitingGap);
				yield break;
			}
			yield return (object)new WaitForSeconds(waitingGap);
			waitingTime += waitingGap;
		}
		yield return uiInst;
	}

	private static string FairyGuiNameToGameObjectName(string fairyGuiName)
	{
		return fairyGuiName.Replace("UI_", "");
	}

	private static string GameObjectNameToFairyGuiName(string gameObjectName)
	{
		return "UI_" + gameObjectName;
	}

	private static bool CheckUiIgnore(string checkGameObjectName, string inputGameObjectName)
	{
		if (ignoreUis.Contains(checkGameObjectName))
		{
			return true;
		}
		if (subUisMap.TryGetValue(inputGameObjectName, out var value) && value.Contains(checkGameObjectName))
		{
			return true;
		}
		return false;
	}

	public static bool HasUiShownOnTop(string uiName)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		int numChildren = ((GComponent)GRoot.inst).numChildren;
		string text = "HasUiShownOnTop(" + uiName + ")" + Environment.NewLine;
		for (int num = numChildren - 1; num >= 0; num--)
		{
			int numChildren2 = ((GComponent)GRoot.inst).numChildren;
			if (numChildren2 <= num)
			{
				ILRuntimeDebug.LogError($"[ClickSimulator]HasUiShownOnTop numChildren Changed {num}/{numChildren2}({numChildren})");
			}
			else
			{
				GObject childAt = ((GComponent)GRoot.inst).GetChildAt(num);
				text = text + $"HasUiShownOnTop, WindowLoader@{num} is {childAt.gameObjectName}" + Environment.NewLine;
				if (!_tipConstants.IsTipUi(GameObjectNameToFairyGuiName(childAt.gameObjectName)) && !childAt.gameObjectName.StartsWith("UI_") && childAt is Window)
				{
					Window val = (Window)childAt;
					GComponent contentPane = val.contentPane;
					if (contentPane == null)
					{
						SentrySdk.AddBreadcrumb(text);
						ILRuntimeDebug.LogError("[ClickSimulator]HasUiShownOnTop, Exceptional WindowLoader " + ((GObject)val).gameObjectName + " Has No contentPane");
					}
					else
					{
						GObject childAt2 = contentPane.GetChildAt(contentPane.numChildren - 1);
						string gameObjectName = childAt2.gameObjectName;
						text = text + gameObjectName + Environment.NewLine;
						SentrySdk.AddBreadcrumb($"[ClickSimulator]HasUiShownOnTop, WindowLoader@{num} is {((GObject)val).gameObjectName}, {gameObjectName}");
						string text2 = FairyGuiNameToGameObjectName(uiName);
						if (gameObjectName == text2)
						{
							return true;
						}
						if (!CheckUiIgnore(gameObjectName, text2))
						{
							return false;
						}
					}
				}
			}
		}
		return false;
	}

	public static bool TryGetUiInstOnTop(string uiName, out GComponent uiInst)
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		uiInst = null;
		int numChildren = ((GComponent)GRoot.inst).numChildren;
		string text = "TryGetUiInstOnTop(" + uiName + ")" + Environment.NewLine;
		for (int num = numChildren - 1; num >= 0; num--)
		{
			int numChildren2 = ((GComponent)GRoot.inst).numChildren;
			if (numChildren2 <= num)
			{
				ILRuntimeDebug.LogError($"[ClickSimulator]TryGetUiInstOnTop numChildren Changed {num}/{numChildren2}({numChildren})");
			}
			else
			{
				GObject childAt = ((GComponent)GRoot.inst).GetChildAt(num);
				text = text + $"TryGetUiInstOnTop, WindowLoader@{num} is {childAt.gameObjectName}" + Environment.NewLine;
				if (!_tipConstants.IsTipUi(GameObjectNameToFairyGuiName(childAt.gameObjectName)) && !childAt.gameObjectName.StartsWith("UI_") && childAt is Window)
				{
					Window val = (Window)childAt;
					GComponent contentPane = val.contentPane;
					if (contentPane == null)
					{
						SentrySdk.AddBreadcrumb(text);
						ILRuntimeDebug.LogError("[ClickSimulator]TryGetUiInstOnTop, Exceptional WindowLoader " + ((GObject)val).gameObjectName + " Has No contentPane");
					}
					else
					{
						GObject childAt2 = contentPane.GetChildAt(contentPane.numChildren - 1);
						string gameObjectName = childAt2.gameObjectName;
						text = text + gameObjectName + Environment.NewLine;
						string text2 = FairyGuiNameToGameObjectName(uiName);
						if (gameObjectName == text2)
						{
							uiInst = childAt2.asCom;
							return true;
						}
						if (!CheckUiIgnore(gameObjectName, text2))
						{
							return false;
						}
					}
				}
			}
		}
		return false;
	}

	public static GComponent GetUiInst(string uiName)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		int numChildren = ((GComponent)GRoot.inst).numChildren;
		string text = "GetUiInst(" + uiName + ")" + Environment.NewLine;
		for (int num = numChildren - 1; num >= 0; num--)
		{
			int numChildren2 = ((GComponent)GRoot.inst).numChildren;
			if (numChildren2 <= num)
			{
				ILRuntimeDebug.LogError($"[ClickSimulator]GetUiInst numChildren Changed {num}/{numChildren2}({numChildren})");
			}
			else
			{
				GObject childAt = ((GComponent)GRoot.inst).GetChildAt(num);
				text = text + $"GetUiInst, WindowLoader@{num} is {childAt.gameObjectName}" + Environment.NewLine;
				if (!_tipConstants.IsTipUi(GameObjectNameToFairyGuiName(childAt.gameObjectName)) && !childAt.gameObjectName.StartsWith("UI_") && childAt is Window)
				{
					Window val = (Window)childAt;
					GComponent contentPane = val.contentPane;
					if (contentPane == null)
					{
						SentrySdk.AddBreadcrumb(text);
						ILRuntimeDebug.LogError("[ClickSimulator]GetUiInst, Exceptional WindowLoader " + ((GObject)val).gameObjectName + " Has No contentPane");
					}
					else
					{
						GObject childAt2 = contentPane.GetChildAt(contentPane.numChildren - 1);
						string gameObjectName = childAt2.gameObjectName;
						text = text + gameObjectName + Environment.NewLine;
						if (GameObjectNameToFairyGuiName(gameObjectName) == uiName)
						{
							return childAt2.asCom;
						}
					}
				}
			}
		}
		return null;
	}

	public static UI_WaitingPanel GetWaitingPanel()
	{
		int numChildren = ((GComponent)GRoot.inst).numChildren;
		for (int num = numChildren - 1; num >= 0; num--)
		{
			int numChildren2 = ((GComponent)GRoot.inst).numChildren;
			if (numChildren2 <= num)
			{
				ILRuntimeDebug.LogError($"[ClickSimulator]GetWaitingPanel numChildren Changed {num}/{numChildren2}({numChildren})");
			}
			else
			{
				GObject childAt = ((GComponent)GRoot.inst).GetChildAt(num);
				if (GameObjectNameToFairyGuiName(childAt.gameObjectName) == UI_WaitingPanel.Name)
				{
					return childAt as UI_WaitingPanel;
				}
			}
		}
		return null;
	}
}
