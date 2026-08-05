using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using UI.Tips;
using UnityEngine;

namespace UI.PaymentOptions;

public class UI_PaymentOptionsDialog : GComponent, IUiController
{
	public GGraph Mask;

	public UI_Dialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://jy8z3hj6gpwa0";

	public static string Name = "UI_PaymentOptionsDialog";

	private Action _callback = null;

	private bool _NeedDoubleCheck = false;

	private string _StoreItemId = string.Empty;

	private int _Quantity = 1;

	private string UseCurrency;

	public static string GetURL()
	{
		return "ui://jy8z3hj6gpwa0";
	}

	public static UI_PaymentOptionsDialog CreateInstance()
	{
		return (UI_PaymentOptionsDialog)(object)UIPackage.CreateObject("PaymentOptions", "PaymentOptionsDialog");
	}

	public static UI_PaymentOptionsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PaymentOptionsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jy8z3hj6gpwa0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_Dialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void SetUICallBack(Action cb)
	{
		_callback = cb;
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (!parameters.TryGetValue("StoreItemId", out var value))
		{
			_StoreItemId = string.Empty;
		}
		else
		{
			_StoreItemId = (string)value;
		}
		if (!parameters.TryGetValue("Quantity", out var value2))
		{
			_Quantity = 1;
		}
		else
		{
			_Quantity = (int)value2;
		}
		if (parameters.TryGetValue("DoubleCheck", out var value3))
		{
			_NeedDoubleCheck = (bool)value3;
		}
		if (parameters.TryGetValue("UseCurrency", out var value4))
		{
			UseCurrency = (string)value4;
		}
		else
		{
			UseCurrency = null;
		}
	}

	public void OnShow()
	{
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Invalid comparison between Unknown and I4
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Invalid comparison between Unknown and I4
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Invalid comparison between Unknown and I4
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Invalid comparison between Unknown and I4
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Invalid comparison between Unknown and I4
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Invalid comparison between Unknown and I4
		if (string.IsNullOrEmpty(_StoreItemId))
		{
			List<string> list = new List<string>();
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText440") + "ID" + LanguagesManager.GetDesc("CsharpCodeZhTcText441") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText442") + "！！！");
			List<string> arg = list;
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 999, arg3: false);
			End();
			return;
		}
		ShowDialog.Play();
		StoreItem storeItem = StoreItem.Get(GameManagers.Instance, _StoreItemId);
		bool flag = true;
		foreach (Dictionary<string, float> item in storeItem.Price)
		{
			string text = item.Keys.First();
			float num = item.Values.First();
			if (!text.Equals("RMB"))
			{
				float num2 = GameManagers.Instance.StockController.GetStock(text);
				if (num <= num2)
				{
					flag = false;
				}
			}
			else if (num == 0f)
			{
				flag = false;
			}
		}
		if (!string.IsNullOrEmpty(UseCurrency))
		{
			flag = false;
		}
		if (!flag)
		{
			End();
			List<string> costItems = new List<string>();
			if (string.IsNullOrEmpty(UseCurrency))
			{
				costItems = null;
			}
			else
			{
				costItems = new List<string> { UseCurrency };
			}
			if (_NeedDoubleCheck)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
				{
					{
						"TipTextAlign",
						(object)(AlignType)1
					},
					{
						"Content",
						LanguagesManager.GetDesc("CsharpCodeZhTcText98") + "？"
					},
					{
						"Buttons",
						new Dictionary<string, Action>
						{
							{
								"Confirm",
								delegate
								{
									PurchaseManager.Instance.PlaceOrder(_StoreItemId, "Default", costItems, _Quantity)?.GetAwaiter().OnCompleted(delegate
									{
										_callback?.Invoke();
									});
								}
							},
							{ "Cancel", null }
						}
					},
					{ "PageIndex", 0 },
					{ "FontSize", 44 },
					{ "Order", 999999 }
				}, multiMode: false, ignoreQueue: true);
			}
			else
			{
				PurchaseManager.Instance.PlaceOrder(_StoreItemId, "Default", _quantity: _Quantity, costItems: costItems)?.GetAwaiter().OnCompleted(delegate
				{
					_callback?.Invoke();
				});
			}
		}
		else if ((int)Application.platform == 8)
		{
			End();
			PurchaseManager.Instance.PlaceOrder(_StoreItemId, "iosiap", null, _Quantity)?.GetAwaiter().OnCompleted(delegate
			{
				_callback?.Invoke();
			});
		}
		else if ((int)Application.platform == 7 || (int)Application.platform == 0)
		{
			End();
			PurchaseManager.Instance.PlaceOrder(_StoreItemId, "test", null, _Quantity)?.GetAwaiter().OnCompleted(delegate
			{
				_callback?.Invoke();
			});
		}
		else
		{
			if ((int)Application.platform == 2 || (int)Application.platform == 1 || (int)Application.platform != 11)
			{
				return;
			}
			if (HotUpdateProcess.ChannelCode == "tapplay")
			{
				AliPay();
				return;
			}
			switch (SDKHelper.GetSdkType())
			{
			case SDKManager.eSDKName.YYTX:
				End();
				PurchaseManager.Instance.PlaceOrder(_StoreItemId, "yytx", null, _Quantity)?.GetAwaiter().OnCompleted(delegate
				{
					_callback?.Invoke();
				});
				break;
			case SDKManager.eSDKName.BiliBiliSDK:
				End();
				PurchaseManager.Instance.PlaceOrder(_StoreItemId, "bilibili", null, _Quantity)?.GetAwaiter().OnCompleted(delegate
				{
					_callback?.Invoke();
				});
				break;
			case SDKManager.eSDKName.XiPuSDK:
				End();
				PurchaseManager.Instance.PlaceOrder(_StoreItemId, "xipu", null, _Quantity)?.GetAwaiter().OnCompleted(delegate
				{
					_callback?.Invoke();
				});
				break;
			}
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(UserCancelPay));
		((GObject)Dialog.alipayBtn).onClick.Add(new EventCallback0(AliPay));
		((GObject)Dialog.weChatPayBtn).onClick.Add(new EventCallback0(WeChatPay));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(UserCancelPay));
		((GObject)Dialog.alipayBtn).onClick.Remove(new EventCallback0(AliPay));
		((GObject)Dialog.weChatPayBtn).onClick.Remove(new EventCallback0(WeChatPay));
	}

	public void UserCancelPay()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(UI_TakeItems.Name);
		End();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void AliPay()
	{
		PurchaseManager.Instance.PlaceOrder(_StoreItemId, "alipay", null, _Quantity)?.GetAwaiter().OnCompleted(delegate
		{
			_callback?.Invoke();
		});
		End();
	}

	private void WeChatPay()
	{
		PurchaseManager.Instance.PlaceOrder(_StoreItemId, "wechat", null, _Quantity)?.GetAwaiter().OnCompleted(delegate
		{
			_callback?.Invoke();
		});
		End();
	}
}
