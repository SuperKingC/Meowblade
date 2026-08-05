using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.Common.Services;
using UI.PublicResources;
using UnityEngine;

namespace UI.Tips;

public class UI_UniversalConfirmPopup : GComponent, IUiController
{
	public Controller Type;

	public GGraph back;

	public UI_UniversalConfirmDialogI ConfirmDialog;

	public UI_UniversalConfirmDialogV DialogV;

	public Transition showTip;

	public Transition ShowTipV;

	public const string URL = "ui://47lbpgx9a7wq1p";

	public static string Name = "UI_UniversalConfirmPopup";

	public const string OnShowCallbackParam = "OnShowCallback_Action";

	private Dictionary<string, Action> Buttons;

	private bool _closeAfterClick;

	private bool mirror;

	private bool Set_FGUI_TouchEnable;

	private Action _onShowCallback;

	private readonly List<string> textureList = new List<string>();

	private GButton targetBtn;

	public static string GetURL()
	{
		return "ui://47lbpgx9a7wq1p";
	}

	public static UI_UniversalConfirmPopup CreateInstance()
	{
		return (UI_UniversalConfirmPopup)(object)UIPackage.CreateObject("Tips", "UniversalConfirmPopup");
	}

	public static UI_UniversalConfirmPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UniversalConfirmPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9a7wq1p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GGraph)((GComponent)this).GetChild("back");
		ConfirmDialog = (UI_UniversalConfirmDialogI)(object)((GComponent)this).GetChild("ConfirmDialog");
		DialogV = (UI_UniversalConfirmDialogV)(object)((GComponent)this).GetChild("DialogV");
		showTip = ((GComponent)this).GetTransition("showTip");
		ShowTipV = ((GComponent)this).GetTransition("ShowTipV");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Expected O, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = (parameters.TryGetValue("Order", out var value) ? ((int)value) : 200);
		UI_UniversalConfirmDialogI confirmDialog = ConfirmDialog;
		((GObject)confirmDialog.yesBtn).visible = false;
		((GObject)confirmDialog.noBtn).visible = false;
		if (!(HotUpdateProcess.LanguageKey == "eng") && parameters.TryGetValue("TipTextAlign", out var value2))
		{
			confirmDialog.tip.align = (AlignType)value2;
		}
		if (parameters.TryGetValue("PageIndex", out var value3))
		{
			int num = (int)value3;
			Type.selectedIndex = num;
			if (num < 5)
			{
				ConfirmDialog.PageController.selectedIndex = num;
			}
		}
		else
		{
			ConfirmDialog.PageController.selectedIndex = 0;
		}
		ConfirmDialog.SetControllerPageText();
		if (parameters.TryGetValue("FGUI_TouchEnable", out var value4))
		{
			Set_FGUI_TouchEnable = (bool)value4;
		}
		_closeAfterClick = true;
		if (parameters.TryGetValue("CloseAfterClick", out var value5) && value5 is bool closeAfterClick)
		{
			_closeAfterClick = closeAfterClick;
		}
		if (parameters.TryGetValue("Buttons", out var value6) && (Buttons = (Dictionary<string, Action>)Convert.ChangeType(value6, typeof(Dictionary<string, Action>))).Count > 0)
		{
			if (parameters.TryGetValue("Mirror", out var value7))
			{
				mirror = (bool)value7;
			}
			foreach (KeyValuePair<string, Action> btnKv in Buttons)
			{
				targetBtn = null;
				if (btnKv.Key == "Confirm")
				{
					targetBtn = (GButton)(object)((Type.selectedIndex < 5) ? ((UI_boundBtn)(object)confirmDialog.yesBtn) : DialogV.inviteBtn);
					if (mirror)
					{
						targetBtn = confirmDialog.noBtn;
					}
					if (parameters.TryGetValue("ClickSound", out var _clickSound))
					{
						((GObject)targetBtn).onClick.Add((EventCallback0)delegate
						{
							UiAudioManager.Instance.PlaySoundEffect(_clickSound.ToString());
						});
					}
				}
				else if (btnKv.Key == "Cancel")
				{
					targetBtn = (GButton)(object)((Type.selectedIndex < 5) ? ((UI_boundBtn)(object)confirmDialog.noBtn) : DialogV.inviteBtn);
					if (mirror)
					{
						targetBtn = confirmDialog.yesBtn;
					}
				}
				if (targetBtn == null)
				{
					continue;
				}
				((GObject)targetBtn).visible = true;
				if (btnKv.Value == null)
				{
					((GObject)targetBtn).onClick.Add(new EventCallback0(End));
					continue;
				}
				((GObject)targetBtn).onClick.Add((EventCallback0)delegate
				{
					btnKv.Value();
				});
			}
		}
		bool flag = false;
		((GObject)ConfirmDialog.tip).text = "";
		if (parameters.ContainsKey("CanNotClick"))
		{
			flag = true;
		}
		if (parameters.TryGetValue("Content", out var value8))
		{
			if (Type.selectedIndex < 5)
			{
				((GObject)ConfirmDialog.tip).text = value8.ToString();
				if (!((GObject)confirmDialog.yesBtn).visible && !((GObject)confirmDialog.noBtn).visible && !flag)
				{
					((GObject)this).onClick.Add(new EventCallback0(End));
				}
				if (parameters.TryGetValue("ConfirmTitle", out var value9))
				{
					((GObject)ConfirmDialog.yesBtn).data = value9.ToString();
				}
				if (parameters.TryGetValue("FontSize", out var value10))
				{
					TextFormat textFormat = ConfirmDialog.tip.textFormat;
					textFormat.size = (int)value10;
					ConfirmDialog.tip.textFormat = textFormat;
				}
				if (parameters.TryGetValue("Title", out var value11))
				{
					((GObject)ConfirmDialog.title).text = value11.ToString();
				}
			}
			else if (Type.selectedIndex == 5)
			{
				((GObject)DialogV.num).text = value8.ToString();
				((GObject)back).onClick.Set(new EventCallback0(End));
			}
		}
		if (parameters.TryGetValue("Content_Page2", out var value12))
		{
			((GObject)ConfirmDialog.tip1).text = value12.ToString();
			((GObject)ConfirmDialog.tip2).visible = false;
			((GObject)ConfirmDialog.tip3).visible = false;
			((GObject)ConfirmDialog.tip4).visible = false;
			((GObject)ConfirmDialog.tip5).visible = false;
			if (parameters.TryGetValue("FontSize", out var value13))
			{
				TextFormat textFormat2 = ConfirmDialog.tip1.textFormat;
				textFormat2.size = (int)value13;
				ConfirmDialog.tip1.textFormat = textFormat2;
			}
			if (parameters.TryGetValue("Title", out var value14))
			{
				((GObject)ConfirmDialog.title).text = value14.ToString();
			}
		}
		if (parameters.TryGetValue("OnShowCallback_Action", out var value15) && value15 is Action onShowCallback)
		{
			_onShowCallback = onShowCallback;
		}
	}

	public void Change_ConfirmDialog_Tip(string str)
	{
		((GObject)ConfirmDialog.tip).text = str;
	}

	public void OnShow()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		UI_general_green_t uI_general_green_t = ConfirmDialog.yesBtn as UI_general_green_t;
		UI_general_red_t uI_general_red_t = ConfirmDialog.noBtn as UI_general_red_t;
		if (ConfirmDialog.PageController.selectedIndex == 2)
		{
			((GObject)uI_general_red_t).xy = new Vector2(263f, 282f);
			((GObject)uI_general_green_t).xy = new Vector2(610f, 282f);
		}
		else if (ConfirmDialog.PageController.selectedIndex == 3)
		{
			((GObject)uI_general_red_t).xy = new Vector2(263f, 282f);
			((GObject)uI_general_green_t).xy = new Vector2(610f, 282f);
		}
		else if (ConfirmDialog.PageController.selectedIndex == 0)
		{
			((GObject)uI_general_green_t).x = 510f;
		}
		else if (ConfirmDialog.PageController.selectedIndex == 4)
		{
			((GObject)uI_general_green_t).x = 311f;
		}
		if (((GObject)uI_general_green_t).data != null)
		{
			((GObject)uI_general_green_t.title).text = ((GObject)uI_general_green_t).data.ToString();
		}
		if (mirror)
		{
			((GObject)uI_general_green_t.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText614");
			((GObject)uI_general_red_t.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText212");
		}
		if (Type.selectedIndex == 5)
		{
			ShowTipV.Play();
		}
		if (Set_FGUI_TouchEnable)
		{
			GameController.Contexts.Service<IUiService>().ClearUiTouchable();
		}
		_onShowCallback?.Invoke();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)ConfirmDialog.yesBtn).onClick.Add(new EventCallback0(End));
		((GObject)ConfirmDialog.noBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)ConfirmDialog.yesBtn).onClick.Remove(new EventCallback0(End));
		((GObject)ConfirmDialog.noBtn).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		if (_closeAfterClick)
		{
			UnityUiService.Instance.ClosePanel(Name);
			for (int i = 0; i < textureList.Count; i++)
			{
				AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
			}
		}
	}
}
