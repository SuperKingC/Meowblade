using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.LegendItemCultivation;
using UI.Tips;
using UnityEngine;

namespace UI.GvG3SplitBluePrint;

public class UI_com_InfoDialog : GComponent
{
	public Controller isLocked;

	public GImage back;

	public GImage n45;

	public GImage n47;

	public GImage n46;

	public GTextField BlueprintName;

	public GLoader BlueprintIcon;

	public GButton EvoLegendItem;

	public GTextField n42;

	public GTextField Desc;

	public UI_com_Content Content;

	public UI_com_Scroll ScrollTip;

	public UI_btn_Lock bpLock;

	public const string URL = "ui://7uylntmmkq2dv";

	public static string Name = "UI_com_InfoDialog";

	private Blueprint _blueprint;

	private UI_main_BlueprintToBeSplit _parent;

	private Vector3 _lockOriginPos;

	private List<BlueprintFxText> _fxTexts = new List<BlueprintFxText>();

	public static string GetURL()
	{
		return "ui://7uylntmmkq2dv";
	}

	public static UI_com_InfoDialog CreateInstance()
	{
		return (UI_com_InfoDialog)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "com_InfoDialog");
	}

	public static UI_com_InfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_InfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmkq2dv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isLocked = ((GComponent)this).GetController("isLocked");
		back = (GImage)((GComponent)this).GetChild("back");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		BlueprintName = (GTextField)((GComponent)this).GetChild("BlueprintName");
		BlueprintIcon = (GLoader)((GComponent)this).GetChild("BlueprintIcon");
		EvoLegendItem = (GButton)((GComponent)this).GetChild("EvoLegendItem");
		n42 = (GTextField)((GComponent)this).GetChild("n42");
		string id = "ui://7uylntmmkq2dv".Replace("ui://", "") + "-" + ((GObject)n42).id;
		((GObject)n42).text = LanguagesManager.GetDesc(id);
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		Content = (UI_com_Content)(object)((GComponent)this).GetChild("Content");
		ScrollTip = (UI_com_Scroll)(object)((GComponent)this).GetChild("ScrollTip");
		bpLock = (UI_btn_Lock)(object)((GComponent)this).GetChild("bpLock");
	}

	public void Init(Blueprint blueprint, UI_main_BlueprintToBeSplit parent)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		_blueprint = blueprint;
		_parent = parent;
		_lockOriginPos = ((GObject)bpLock).position;
		RenderBlueprintMainInfo();
		RenderContent();
		RefreshLockState();
		RegisterUiEventListeners();
		OnShow();
	}

	private void OnShow()
	{
		((GComponent)Content).scrollPane.ScrollDown(1f, false);
		((GComponent)Content).scrollPane.ScrollTop(false);
	}

	private void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)Content).scrollPane.onScroll.Add(new EventCallback0(ShowScrollTip));
		((GObject)Content).onClick.Add(new EventCallback0(ShowScrollTip));
		((GObject)bpLock).onClick.Set(new EventCallback0(OnClickSetLockState));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GComponent)Content).scrollPane.onScroll.Remove(new EventCallback0(ShowScrollTip));
		((GObject)Content).onClick.Remove(new EventCallback0(ShowScrollTip));
		((GObject)bpLock).onClick.Clear();
		_blueprint = null;
	}

	private void ShowScrollTip()
	{
		((GObject)ScrollTip).visible = !((GComponent)Content).scrollPane.IsChildInView((GObject)(object)Content.ContentBottom);
	}

	private void RenderBlueprintMainInfo()
	{
		if (_blueprint != null)
		{
			((GObject)BlueprintName).text = _blueprint.GetName();
			BlueprintIcon.LoadBlueprintIcon(_blueprint.GetIconName());
			((GObject)Desc).text = _blueprint.GetDesc();
			if (LegendItemManager.LegendItemTemplates.TryGetValue(_blueprint.EvoId, out var value))
			{
				LegendItemsHelper.RenderLegendItem(EvoLegendItem, value);
			}
		}
	}

	private void RenderContent()
	{
		if (_blueprint != null)
		{
			RenderPreviewContent();
		}
	}

	private void RenderPreviewContent()
	{
		RenderEntries();
		RenderFx();
	}

	private void RenderEntries()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		float num = 165f;
		Content.PreviewContent.Entries.Type.selectedIndex = 0;
		Content.PreviewContent.Entries.Entries.ResizeToFit(0);
		if (_blueprint.NewSubEntryUnlockLevels != null)
		{
			Content.PreviewContent.Entries.Entries.itemRenderer = new ListItemRenderer(RenderEntry);
			Content.PreviewContent.Entries.Entries.numItems = _blueprint.NewSubEntryUnlockLevels.Count;
			Content.PreviewContent.Entries.Entries.ResizeToFit(_blueprint.NewSubEntryUnlockLevels.Count);
			num += 40f * (float)_blueprint.NewSubEntryUnlockLevels.Count;
		}
		if (string.IsNullOrEmpty(_blueprint.EnhanceFxEntryId))
		{
			Content.PreviewContent.Entries.Type.selectedIndex = 1;
			num += 160f;
		}
		((GObject)Content.PreviewContent.Entries).height = num;
	}

	private void RenderEntry(int index, GObject obj)
	{
		if (obj is UI_com_Entry uI_com_Entry)
		{
			((GObject)uI_com_Entry.UnlockTip).text = string.Format("({0}{1}{2})", LanguagesManager.GetDesc("CsharpCodeZhTcText319"), _blueprint.NewSubEntryUnlockLevels[index], LanguagesManager.GetDesc("CsharpCodeZhTcText320"));
		}
	}

	private void RenderFx()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		_fxTexts = _blueprint.GetBlueprintFxTexts();
		Content.PreviewContent.AllFx.Fx.itemRenderer = new ListItemRenderer(RenderFxItem);
		Content.PreviewContent.AllFx.Fx.numItems = _fxTexts.Count;
		Content.PreviewContent.AllFx.Fx.ResizeToFit(_fxTexts.Count);
	}

	private void RenderFxItem(int index, GObject obj)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		if (obj is UI_com_Propetry uI_com_Propetry)
		{
			BlueprintFxText blueprintFxText = _fxTexts[index];
			uI_com_Propetry.Type.selectedIndex = ((index != _fxTexts.Count - 1) ? 1 : 0);
			uI_com_Propetry.State.selectedIndex = blueprintFxText.FxTextType;
			((GObject)uI_com_Propetry.content).text = blueprintFxText.Text;
			((GObject)uI_com_Propetry.content).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		}
	}

	private static void OnClickEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}

	private void OnClickSetLockState()
	{
		bool isBpLock = GameManagers.Instance.BpLockManager.GetIsLocked(_blueprint);
		GameManagers.Instance.BpLockManager.SetIsLocked(_blueprint, !isBpLock, delegate
		{
			UI_LegendItemCultivationPanel.lockSizeChange((GObject)(object)bpLock);
			isBpLock = GameManagers.Instance.BpLockManager.GetIsLocked(_blueprint);
			if (isBpLock)
			{
				_parent.DequeueCallback();
			}
			else
			{
				_parent.RenderBlueprint();
			}
			RefreshLockState();
		});
	}

	private void RefreshLockState()
	{
		bool flag = GameManagers.Instance.BpLockManager.GetIsLocked(_blueprint);
		isLocked.SetSelectedIndex(flag ? 1 : 0);
	}

	public void ShakeLock()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		GTween.Shake(_lockOriginPos, 16f, 0.4f).SetTarget((object)bpLock).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			((GObject)bpLock).xy = new Vector2(tweener.value.x, tweener.value.y);
		});
	}
}
