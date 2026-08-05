using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.Common.Services;
using UI.LoginAndName;
using UnityEngine;

namespace UI.UpdateResources;

public class UI_UpdateResources : GComponent, IUiController
{
	public Controller pageSwitch;

	public GLoader background;

	public UI_LogoIcon title;

	public GGraph workerBack;

	public GGraph soldierBack1;

	public GGraph soldierBack2;

	public GGraph tiipMask;

	public GTextField tip1;

	public GTextField tip2;

	public GGroup bottomTip;

	public GTextField legoinOrLoadTip;

	public GImage n14;

	public GGroup legionTip;

	public UI_UpdateProgressBar updateProgressBar;

	public UI_UniversalConfirmDialog RestartDialog;

	public Transition loading;

	public Transition ShowDialog;

	public const string URL = "ui://sui7dihfk1jj0";

	public static string Name = "UI_UpdateResources";

	private UpdateController _updateController;

	public int AllDataNum = 0;

	public int AllDataSize = 0;

	public int curDataNum = 0;

	public int curDataSize = 0;

	public float curBarValue = 0f;

	public bool needUpdate;

	public static string GetURL()
	{
		return "ui://sui7dihfk1jj0";
	}

	public static UI_UpdateResources CreateInstance()
	{
		return (UI_UpdateResources)(object)UIPackage.CreateObject("UpdateResources", "UpdateResources");
	}

	public static UI_UpdateResources CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UpdateResources).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://sui7dihfk1jj0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		pageSwitch = ((GComponent)this).GetController("pageSwitch");
		background = (GLoader)((GComponent)this).GetChild("background");
		title = (UI_LogoIcon)(object)((GComponent)this).GetChild("title");
		workerBack = (GGraph)((GComponent)this).GetChild("workerBack");
		soldierBack1 = (GGraph)((GComponent)this).GetChild("soldierBack1");
		soldierBack2 = (GGraph)((GComponent)this).GetChild("soldierBack2");
		tiipMask = (GGraph)((GComponent)this).GetChild("tiipMask");
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id = "ui://sui7dihfk1jj0".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id);
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id2 = "ui://sui7dihfk1jj0".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id2);
		bottomTip = (GGroup)((GComponent)this).GetChild("bottomTip");
		legoinOrLoadTip = (GTextField)((GComponent)this).GetChild("legoinOrLoadTip");
		string id3 = "ui://sui7dihfk1jj0".Replace("ui://", "") + "-" + ((GObject)legoinOrLoadTip).id;
		((GObject)legoinOrLoadTip).text = LanguagesManager.GetDesc(id3);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		legionTip = (GGroup)((GComponent)this).GetChild("legionTip");
		updateProgressBar = (UI_UpdateProgressBar)(object)((GComponent)this).GetChild("updateProgressBar");
		RestartDialog = (UI_UniversalConfirmDialog)(object)((GComponent)this).GetChild("RestartDialog");
		loading = ((GComponent)this).GetTransition("loading");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GComponent)this).GetChild("legionTip").visible = true;
		((GObject)updateProgressBar).visible = false;
		if (parameters.TryGetValue("UpdateController", out var value))
		{
			UpdateController.Instance.UpdateResourcesPanel = this;
			((GObject)this).sortingOrder = 1000;
			_updateController = (UpdateController)value;
			pageSwitch.selectedIndex = 2;
			UnityUiService.Instance.PreLoadPackage("Tips", delegate
			{
				UpdateVersion();
			});
		}
		else
		{
			End();
		}
		GetLoadingTips();
	}

	public void RegisterUiEventListeners()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", CloseSelf);
		((GObject)RestartDialog.ClearBtn).onClick.Add(new EventCallback0(LoadController.ClearCacheAndRestart));
		((GObject)RestartDialog.RestartBtn).onClick.Add(new EventCallback0(HotFix_Utils.Restart));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", CloseSelf);
		((GObject)RestartDialog.ClearBtn).onClick.Remove(new EventCallback0(LoadController.ClearCacheAndRestart));
		((GObject)RestartDialog.RestartBtn).onClick.Remove(new EventCallback0(HotFix_Utils.Restart));
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End(bool unloadResource = false)
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		UpdateController.Instance.UpdateResourcesPanel = null;
	}

	private void GetLoadingTips()
	{
		UiHelper.LoadTips = ((GObject)legoinOrLoadTip).data.ToString().Split(',').ToList();
		if (((GObject)legoinOrLoadTip).data != null)
		{
			((MonoBehaviour)_updateController).StartCoroutine(UpdateLoadingTips());
		}
	}

	public void Restart()
	{
		UpdateController.Instance.CloseUpdateResources();
		((GObject)updateProgressBar.progress).text = $"{100}%";
		((GObject)updateProgressBar.info).text = "更新完成";
		HotFix_Utils.Restart();
	}

	public void ShowRestartTips(string tip = "检测到更新失败，是否要重新载入游戏？")
	{
		((GObject)RestartDialog.tip).text = tip;
		pageSwitch.selectedIndex = 1;
	}

	private void UpdateVersion()
	{
		VersionManager.Instance.UpdateVersion().Then((Action<bool>)delegate(bool result)
		{
			if (result)
			{
				_updateController.OnResourcesReady();
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			VersionManager.Instance.OpenRestartPanel(VersionManager.Instance.TIPS_6);
			Debug.LogException(ex);
		});
	}

	private void CloseSelf(string uiId, Dictionary<string, object> parameter)
	{
		if (uiId == UI_WechatLogin.Name)
		{
			End();
		}
	}

	private IEnumerator UpdateLoadingTips()
	{
		while (true)
		{
			int tipIndex = Random.Range(0, UiHelper.LoadTips.Count);
			((GObject)legoinOrLoadTip).text = UiHelper.LoadTips[tipIndex];
			if (UiHelper.LoadTips.Count > 1)
			{
				UiHelper.LoadTips.RemoveAt(tipIndex);
			}
			yield return (object)new WaitForSecondsRealtime(Random.Range(-0.25f, 0.25f) + 1.55f);
		}
	}
}
