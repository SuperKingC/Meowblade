using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.EdgeMask;

public class UI_EdgeMaskPanel : GComponent, IUiController
{
	public GLoader maskLeft;

	public GLoader maskRight;

	public GLoader maskTop;

	public GLoader maskBottom;

	public Transition ShowPanel;

	public const string URL = "ui://z5m3m3whroni0";

	public static string Name = "UI_EdgeMaskPanel";

	private const float InitRatio = 1.7777778f;

	public float ratio;

	public static string GetURL()
	{
		return "ui://z5m3m3whroni0";
	}

	public static UI_EdgeMaskPanel CreateInstance()
	{
		return (UI_EdgeMaskPanel)(object)UIPackage.CreateObject("EdgeMask", "EdgeMaskPanel");
	}

	public static UI_EdgeMaskPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EdgeMaskPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://z5m3m3whroni0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		maskLeft = (GLoader)((GComponent)this).GetChild("maskLeft");
		maskRight = (GLoader)((GComponent)this).GetChild("maskRight");
		maskTop = (GLoader)((GComponent)this).GetChild("maskTop");
		maskBottom = (GLoader)((GComponent)this).GetChild("maskBottom");
		ShowPanel = ((GComponent)this).GetTransition("ShowPanel");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		((GObject)this).Dispose();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		((GObject)this).SetSize(Math.Min(2560f, ((GObject)GRoot.inst).width), ((GObject)GRoot.inst).height);
		((GObject)this).sortingOrder = 4001;
		SetMaskSize();
		SetMaskVisible(value: false);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
	}

	public void UnregisterUiEventListeners()
	{
	}

	private void SetMaskSize()
	{
		float num = (float)Screen.width / (float)Screen.height;
		ratio = num / 1.7777778f;
		if (ratio > 1f)
		{
			((GObject)maskTop).height = 0f;
			((GObject)maskBottom).height = 0f;
			return;
		}
		float num2 = (1920f / (float)Screen.width * (float)Screen.height - 1080f) / 2f;
		int num3 = Mathf.CeilToInt(num2);
		((GObject)maskTop).height = num3;
		((GObject)maskBottom).height = num3;
	}

	public void SetMaskVisible(bool value)
	{
		((GObject)maskTop).visible = value;
		((GObject)maskBottom).visible = value;
	}
}
