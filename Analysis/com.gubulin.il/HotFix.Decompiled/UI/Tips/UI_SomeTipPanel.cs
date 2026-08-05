using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.Tips;

public class UI_SomeTipPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_com_TextContent TextContent;

	public Transition showTipText;

	public const string URL = "ui://47lbpgx9p3h011";

	public static string Name = "UI_SomeTipPanel";

	private List<string> _tipList = new List<string>();

	public static string GetURL()
	{
		return "ui://47lbpgx9p3h011";
	}

	public static UI_SomeTipPanel CreateInstance()
	{
		return (UI_SomeTipPanel)(object)UIPackage.CreateObject("Tips", "SomeTipPanel");
	}

	public static UI_SomeTipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SomeTipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9p3h011", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		TextContent = (UI_com_TextContent)(object)((GComponent)this).GetChild("TextContent");
		showTipText = ((GComponent)this).GetTransition("showTipText");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (!parameters.ContainsKey("TipText"))
		{
			Debug.LogWarning((object)"未包含文本提示");
			End();
		}
		else
		{
			_tipList.Clear();
			_tipList = (List<string>)parameters["TipText"];
			SetTipText();
			int num = 3002;
			if (parameters.ContainsKey("Order"))
			{
				int num2 = (int)parameters["Order"];
				if (num2 > num)
				{
					((GObject)this).sortingOrder = num2;
				}
				else
				{
					((GObject)this).sortingOrder = num;
				}
			}
			else
			{
				((GObject)this).sortingOrder = num;
			}
			if (parameters.ContainsKey("ShowMask"))
			{
				((GObject)mask).visible = (bool)parameters["ShowMask"];
				((GObject)mask).touchable = (bool)parameters["ShowMask"];
			}
			else
			{
				((GObject)mask).visible = true;
				((GObject)mask).touchable = true;
			}
			if (parameters.ContainsKey("Left"))
			{
				TextContent.tipText.align = (AlignType)0;
			}
			else
			{
				TextContent.tipText.align = (AlignType)1;
			}
		}
		showTipText.Play((PlayCompleteCallback)delegate
		{
			if (!((GObject)this).isDisposed)
			{
				End();
			}
		});
		((GObject)this).displayObject.gameObject.AddComponent<HotFix_DestroySelf>().destroyTime = 5f;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(MaskClick));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Remove(new EventCallback0(MaskClick));
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}

	public void End()
	{
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)this, true);
	}

	private void MaskClick()
	{
		End();
	}

	private void SetTipText()
	{
		if (_tipList.Count == 0)
		{
			return;
		}
		((GObject)TextContent.tipText).text = "";
		for (int i = 0; i < _tipList.Count; i++)
		{
			if (i < _tipList.Count - 1)
			{
				GTextField tipText = TextContent.tipText;
				((GObject)tipText).text = ((GObject)tipText).text + _tipList[i] + Environment.NewLine;
			}
			else
			{
				GTextField tipText2 = TextContent.tipText;
				((GObject)tipText2).text = ((GObject)tipText2).text + _tipList[i];
			}
		}
	}
}
