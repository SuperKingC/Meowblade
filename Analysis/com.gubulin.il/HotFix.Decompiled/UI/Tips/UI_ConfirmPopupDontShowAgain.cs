using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ConfirmPopupDontShowAgain : GComponent, IUiController
{
	public GGraph back;

	public UI_ConfirmDialogDontShowAgain ConfirmDialog;

	public Transition showTip;

	public const string URL = "ui://47lbpgx9w1r55l";

	public static string Name = "UI_ConfirmPopupDontShowAgain";

	private GButton targetBtn;

	private Dictionary<string, Action> Buttons;

	private string TipKey;

	private string TipValue;

	public static string GetURL()
	{
		return "ui://47lbpgx9w1r55l";
	}

	public static UI_ConfirmPopupDontShowAgain CreateInstance()
	{
		return (UI_ConfirmPopupDontShowAgain)(object)UIPackage.CreateObject("Tips", "ConfirmPopupDontShowAgain");
	}

	public static UI_ConfirmPopupDontShowAgain CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmPopupDontShowAgain).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9w1r55l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		ConfirmDialog = (UI_ConfirmDialogDontShowAgain)(object)((GComponent)this).GetChild("ConfirmDialog");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public static bool IsDontShowAgain(string _TipKey)
	{
		string key = Name + "_" + _TipKey;
		if (GameLocalDataManager.HasKey(key))
		{
			return GameLocalDataManager.GetBool(key);
		}
		return false;
	}

	public static void SetDontShowAgain(string _TipKey, bool val)
	{
		string key = Name + "_" + _TipKey;
		GameLocalDataManager.SetBool(key, val);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Invalid comparison between Unknown and I4
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Invalid comparison between Unknown and I4
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Invalid comparison between Unknown and I4
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		if (parameters.TryGetValue("TipKey", out var value))
		{
			TipKey = value.ToString();
		}
		if (string.IsNullOrEmpty(TipKey))
		{
			ILRuntimeDebug.LogError("Popping UI_ConfirmDialogDontShowAgain Without TipKey");
		}
		if (parameters.TryGetValue("TipContent", out var value2))
		{
			((GObject)ConfirmDialog.switchBtn.tip).text = value2.ToString();
		}
		if (parameters.TryGetValue("TipValue", out var value3))
		{
			TipValue = value3.ToString();
		}
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = (parameters.TryGetValue("Order", out var value4) ? ((int)value4) : 200);
		((GObject)ConfirmDialog.yesBtn).visible = false;
		if (parameters.TryGetValue("Buttons", out var value5) && (Buttons = (Dictionary<string, Action>)Convert.ChangeType(value5, typeof(Dictionary<string, Action>))).Count > 0)
		{
			bool flag = false;
			if (parameters.TryGetValue("Mirror", out var value6))
			{
				flag = (bool)value6;
			}
			int num = 0;
			foreach (KeyValuePair<string, Action> btnKv in Buttons)
			{
				targetBtn = null;
				if (btnKv.Key == "Confirm")
				{
					targetBtn = (flag ? ConfirmDialog.noBtn : ConfirmDialog.yesBtn);
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
					targetBtn = (flag ? ConfirmDialog.noBtn : ConfirmDialog.yesBtn);
				}
				if (targetBtn == null)
				{
					continue;
				}
				num++;
				((GObject)targetBtn).visible = true;
				if (btnKv.Value != null)
				{
					((GObject)targetBtn).onClick.Add((EventCallback0)delegate
					{
						btnKv.Value();
					});
				}
			}
			switch (num)
			{
			case 1:
				ConfirmDialog.ButtonStyle.selectedIndex = 0;
				break;
			case 2:
				ConfirmDialog.ButtonStyle.selectedIndex = 1;
				break;
			}
		}
		((GObject)ConfirmDialog.tip).text = "";
		if (!parameters.TryGetValue("Content", out var value7))
		{
			return;
		}
		((GObject)ConfirmDialog.tip).text = value7.ToString();
		if (parameters.TryGetValue("FontSize", out var value8))
		{
			TextFormat textFormat = ConfirmDialog.tip.textFormat;
			textFormat.size = (int)value8;
			ConfirmDialog.tip.textFormat = textFormat;
		}
		if (parameters.TryGetValue("TipTextAlign", out var value9))
		{
			AlignType val = (AlignType)value9;
			ConfirmDialog.tip.align = val;
			if ((int)val == 0)
			{
				((GObject)ConfirmDialog.switchBtn).x = 96f;
			}
			else if ((int)val == 1)
			{
				((GObject)ConfirmDialog.switchBtn).x = ((GObject)ConfirmDialog).width - ((GObject)ConfirmDialog.switchBtn).width - 96f;
			}
			else if ((int)val == 2)
			{
				((GObject)ConfirmDialog.switchBtn).x = (((GObject)ConfirmDialog).width - ((GObject)ConfirmDialog.switchBtn).width) / 2f;
			}
		}
	}

	public void OnShow()
	{
		if (((GObject)ConfirmDialog.yesBtn).data != null)
		{
			ConfirmDialog.yesBtn.title = ((GObject)ConfirmDialog.yesBtn).data.ToString();
		}
		ConfirmDialog.SetButtonTitle();
	}

	private void OnClickSwitch()
	{
		if (string.IsNullOrEmpty(TipValue))
		{
			SetDontShowAgain(TipKey, ((GButton)ConfirmDialog.switchBtn).selected);
		}
		else
		{
			GameLocalDataManager.SetString(TipKey, TipValue);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)ConfirmDialog.yesBtn).onClick.Add(new EventCallback0(OnConfirm));
		((GObject)ConfirmDialog.noBtn).onClick.Add(new EventCallback0(OnCancel));
	}

	private void OnConfirm()
	{
		if (((GButton)ConfirmDialog.switchBtn).selected)
		{
			OnClickSwitch();
		}
		End();
	}

	private void OnCancel()
	{
		End();
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)ConfirmDialog.yesBtn).onClick.Clear();
		((GObject)ConfirmDialog.switchBtn).onClick.Clear();
	}

	public void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
