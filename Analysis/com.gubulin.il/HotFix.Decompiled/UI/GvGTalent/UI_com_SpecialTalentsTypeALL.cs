using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGTalent.OuterTechStatic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.GvGTalent;

public class UI_com_SpecialTalentsTypeALL : GComponent
{
	public GImage n11;

	public GImage n13;

	public GImage n12;

	public UI_btn_GvGResetTalents Reset;

	public GList Specials;

	public const string URL = "ui://4r1llhd8jrfh55";

	public static string Name = "UI_com_SpecialTalentsTypeALL";

	private 深层共鸣TalentEffect _深层共鸣;

	private 十六加八TalentEffect _十六加八;

	private readonly WaitForSeconds _perSeconds = new WaitForSeconds(1f);

	private Coroutine _resetTimeCoroutine;

	private int _lastSelectType = -1;

	private int NextAvailableResetTime => Singleton<GvGTalentsManager>.Instance.NextAvailableResetTime - (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://4r1llhd8jrfh55";
	}

	public static UI_com_SpecialTalentsTypeALL CreateInstance()
	{
		return (UI_com_SpecialTalentsTypeALL)(object)UIPackage.CreateObject("GvGTalent", "com_SpecialTalentsTypeALL");
	}

	public static UI_com_SpecialTalentsTypeALL CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialTalentsTypeALL).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8jrfh55", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		Reset = (UI_btn_GvGResetTalents)(object)((GComponent)this).GetChild("Reset");
		Specials = (GList)((GComponent)this).GetChild("Specials");
	}

	public void OnInit(深层共鸣TalentEffect 深层共鸣, 十六加八TalentEffect 十六加八)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		_深层共鸣 = 深层共鸣;
		_十六加八 = 十六加八;
		Specials.onClickItem.Add(new EventCallback1(OnSpecialsItemChanged));
		bool flag = Singleton<GvGStoreHouseManager>.Instance.GetItemCount("I32018", includingGSStock: true) > 0;
		bool flag2 = "I67501".IsActive();
		((GObject)Reset).visible = flag2 || flag;
	}

	public void Render()
	{
		if (_resetTimeCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_resetTimeCoroutine);
		}
		_resetTimeCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateResetTime());
		RenderSpecials();
	}

	public void OnDestroy()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		_深层共鸣 = null;
		_十六加八 = null;
		if (_resetTimeCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_resetTimeCoroutine);
		}
		Specials.onClickItem.Remove(new EventCallback1(OnSpecialsItemChanged));
	}

	public void RegisterEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Reset).onClick.Add(new EventCallback0(OnOpenResetPanel));
	}

	public void UnregisterEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Reset).onClick.Remove(new EventCallback0(OnOpenResetPanel));
	}

	private void OnOpenResetPanel()
	{
		if (NextAvailableResetTime > 0)
		{
			ILRequestHelper.ShowErrorCode(813108042);
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGResetTalents.Name, new Dictionary<string, object> { { "OuterTechI67301Data", _十六加八 } });
	}

	private IEnumerator UpdateResetTime()
	{
		if (NextAvailableResetTime > 0)
		{
			Reset.State.selectedIndex = 1;
			while (NextAvailableResetTime > 0)
			{
				((GObject)Reset.Time).text = UiHelper.ParseTime(NextAvailableResetTime);
				yield return _perSeconds;
			}
			Reset.State.selectedIndex = 0;
		}
	}

	public void RenderSpecials()
	{
		for (int i = 0; i < ((GComponent)Specials).numChildren; i++)
		{
			GButton asButton = ((GComponent)Specials).GetChildAt(i).asButton;
			if (asButton != null)
			{
				int specialType = -Convert.ToInt32(Mathf.Pow(2f, (float)i));
				if (((GComponent)asButton).GetChild("Desc") is UI_com_SpecialTalentsDialog dialog)
				{
					RenderSpecialTalentDesc(specialType, dialog);
				}
				RenderWholeSpecialTalent(specialType, asButton);
			}
		}
	}

	private void RenderSpecialTalentDesc(int specialType, UI_com_SpecialTalentsDialog dialog)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		if (!Singleton<GvGTalentsManager>.Instance.SpecialTalents.TryGetValue(specialType, out var specialTalentsData))
		{
			return;
		}
		dialog.Type.selectedIndex = Mathf.Abs(specialType);
		((GObject)dialog.SpecialTalentName).text = $"GvGTalentTypeName_{dialog.Type.selectedIndex}".ToLanguage();
		dialog.Info.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			if (item is UI_com_SpecilaTalentDialogInfo uI_com_SpecilaTalentDialogInfo)
			{
				GDEGvGTalentConfigData gDEGvGTalentConfigData = specialTalentsData[index];
				((GObject)uI_com_SpecilaTalentDialogInfo.Desc).text = gDEGvGTalentConfigData.Desc;
				((GObject)uI_com_SpecilaTalentDialogInfo.Point).text = _深层共鸣.GetSpecialParentTalent(gDEGvGTalentConfigData);
				uI_com_SpecilaTalentDialogInfo.Status.selectedIndex = (Singleton<GvGTalentsManager>.Instance.SpecialTalentEffective(gDEGvGTalentConfigData.Idx) ? 1 : 0);
				uI_com_SpecilaTalentDialogInfo.OuterTechIsActive.SetSelectedIndex(_深层共鸣.深层共鸣IsActive ? 1 : 0);
			}
		};
		dialog.Info.numItems = specialTalentsData.Count;
		dialog.Info.ResizeToFit(specialTalentsData.Count);
		dialog.OuterTechIsActive.SetSelectedIndex(_深层共鸣.深层共鸣IsActive ? 1 : 0);
	}

	private void RenderWholeSpecialTalent(int specialType, GButton btn)
	{
		int currentSpecialTalentCount = Singleton<GvGTalentsManager>.Instance.GetCurrentSpecialTalentCount(specialType);
		GTextField asTextField = ((GComponent)btn).GetChild("Point").asTextField;
		int nextSpecialCount = Singleton<GvGTalentsManager>.Instance.GetNextSpecialCount(specialType, currentSpecialTalentCount, _深层共鸣.深层共鸣Value);
		((GObject)asTextField).text = ((currentSpecialTalentCount >= nextSpecialCount) ? $"{currentSpecialTalentCount}" : $"{currentSpecialTalentCount}/{nextSpecialCount}");
		Controller controller = ((GComponent)btn).GetController("Invested");
		controller.selectedIndex = ((currentSpecialTalentCount > 0) ? 1 : 0);
		int curSpecialTalentLevel = Singleton<GvGTalentsManager>.Instance.GetCurSpecialTalentLevel(specialType, currentSpecialTalentCount);
		((GComponent)btn).GetController("Lv").SetSelectedIndex(curSpecialTalentLevel);
	}

	private void OnSpecialsItemChanged(EventContext context)
	{
		if (Specials.selectedIndex == _lastSelectType)
		{
			Specials.selectedIndex = (_lastSelectType = -1);
			((GComponent)Specials).EnsureBoundsCorrect();
		}
		else
		{
			_lastSelectType = Specials.selectedIndex;
		}
	}
}
