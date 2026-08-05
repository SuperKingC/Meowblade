using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion.Common.Services;
using UI.Tips;
using UnityEngine;

namespace UI.LegendItemInfo;

public class UI_LegendItemInfoDialog2 : GComponent, IUiController
{
	public GGraph Mask;

	public UI_InfoDialog2 Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://lzvt5p2vnadok";

	public static string Name = "UI_LegendItemInfoDialog2";

	public const string ParamKeyLegendItem = "LegendItem";

	public const string ParamKeyCallback = "Callback";

	private const int LockedErrorCode = 81311514;

	private List<string> textureList = new List<string>();

	private LegendItemUi curItemData;

	private List<EntryText> EntriesTexts = new List<EntryText>();

	private Action _callback;

	public static string GetURL()
	{
		return "ui://lzvt5p2vnadok";
	}

	public static UI_LegendItemInfoDialog2 CreateInstance()
	{
		return (UI_LegendItemInfoDialog2)(object)UIPackage.CreateObject("LegendItemInfo", "LegendItemInfoDialog2");
	}

	public static UI_LegendItemInfoDialog2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemInfoDialog2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vnadok", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_InfoDialog2)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		curItemData = (parameters.TryGetValue("LegendItem", out var value) ? (value as LegendItemUi) : null);
		if (curItemData == null)
		{
			End();
			return;
		}
		_callback = (parameters.TryGetValue("Callback", out var value2) ? (value2 as Action) : null);
		Dialog.Type.selectedIndex = 0;
		DialogRender();
	}

	public void OnShow()
	{
		ShowDialog.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.ConfirmCostItem).onClick.Add(new EventCallback1(OnConfirmClick));
		((GObject)Dialog.Lock).onClick.Add(new EventCallback1(OnToggleLock));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.ConfirmCostItem).onClick.Remove(new EventCallback1(OnConfirmClick));
		((GObject)Dialog.Lock).onClick.Remove(new EventCallback1(OnToggleLock));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void OnConfirmClick(EventContext context)
	{
		if (curItemData.LegendItemData.Locked)
		{
			ILRequestHelper.ShowErrorCode(81311514);
			return;
		}
		_callback?.Invoke();
		End();
	}

	private void OnToggleLock(EventContext context)
	{
		((GObject)Dialog.Lock.n6).SetPivot(0.5f, 0.5f);
		((GObject)Dialog.Lock.n7).SetPivot(0.5f, 0.5f);
		PlayLockAnimation(Dialog.Lock.n6);
		PlayLockAnimation(Dialog.Lock.n7);
		LegendItemsHelper.LockLegendItem(curItemData, UpdateLockState);
	}

	private static void PlayLockAnimation(GImage target)
	{
		EffectHelper.PlayCoroutineEffect(1f, delegate(float t, float total)
		{
			float num = ((float)Math.Sin(t / total * 5f) * 0.5f + 0.5f) * 0.4f + 1f;
			((GObject)target).scaleX = num;
			((GObject)target).scaleY = num;
		}, delegate
		{
			((GObject)target).scaleX = 1f;
			((GObject)target).scaleY = 1f;
		});
	}

	private void UpdateLockState()
	{
		Dialog.Lock.Status.selectedIndex = (curItemData.LegendItemData.Locked ? 1 : 0);
	}

	private void DialogRender()
	{
		((GObject)Dialog.title0).text = LegendItemsHelper.GetLegendItemNameTitle(curItemData.LegendItemData.Data.Name, curItemData.LegendItemData.EnhanceLevel);
		Dialog.ClassController.selectedIndex = curItemData.LegendItemData.Data.Rarity - 1;
		((GObject)Dialog.primeAttribute).text = LegendItemsHelper.GetLegendItemMainPropetryKeyText(curItemData) + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(curItemData);
		SecondaryAspectsRender();
		((GObject)Dialog.score).text = $"{curItemData.LegendItemData.Score}";
		UiHelper.RenderLegendItem(Dialog.Icon, curItemData, UiHelper.TextColorType.Dark, textureList, 0);
		((GComponent)Dialog.Icon).GetController("ClassController").selectedIndex = Dialog.ClassController.selectedIndex;
		((GComponent)Dialog.Icon).GetChild("name").visible = false;
		((GComponent)Dialog.Icon).GetChild("LvFrame").visible = false;
		((GComponent)Dialog.Icon).GetChild("Level").visible = false;
		((GComponent)Dialog.Icon).GetChild("ClassList").visible = false;
		UpdateLockState();
	}

	private void SecondaryAspectsRender()
	{
		if (curItemData.LegendItemData.SubEntries != null && curItemData.LegendItemData.SubEntries.Count != 0)
		{
			RenderAllEntries();
		}
	}

	private void RenderAllEntries()
	{
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		EntriesTexts.Clear();
		((GObject)Dialog.Entries).visible = true;
		string text = LegendItemsHelper.GetSubEntries(curItemData).Replace("%[/color] ", "%[/color]  ");
		List<string> fxEntries = LegendItemsHelper.GetFxEntries(curItemData.LegendItemData);
		string suitDesc = LegendItemsHelper.GetSuitDesc(curItemData.LegendItemData);
		EntriesTexts.Add(new EntryText
		{
			TextType = 0,
			Text = text
		});
		for (int i = 0; i < fxEntries.Count; i++)
		{
			EntriesTexts.Add(new EntryText
			{
				TextType = 1,
				Text = fxEntries[i]
			});
		}
		if (!string.IsNullOrEmpty(suitDesc))
		{
			EntriesTexts.Add(new EntryText
			{
				TextType = 2,
				Text = suitDesc
			});
		}
		Dialog.Entries.itemRenderer = new ListItemRenderer(RenderEntry);
		Dialog.Entries.numItems = EntriesTexts.Count;
	}

	private void RenderEntry(int index, GObject obj)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		if (obj is UI_com_Propetry uI_com_Propetry)
		{
			EntryText entryText = EntriesTexts[index];
			uI_com_Propetry.State.selectedIndex = entryText.TextType;
			uI_com_Propetry.SetControllerPageText();
			uI_com_Propetry.GetControllerText(entryText.TextType);
			((GObject)uI_com_Propetry.content).text = entryText.Text;
			uI_com_Propetry.Type.selectedIndex = ((index != EntriesTexts.Count - 1) ? 1 : 0);
			((GObject)uI_com_Propetry.content).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		}
	}

	private void OnClickEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}
}
