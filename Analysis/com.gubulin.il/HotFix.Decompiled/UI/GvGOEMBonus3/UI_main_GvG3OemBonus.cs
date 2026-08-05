using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGOEMBonus3;

public class UI_main_GvG3OemBonus : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_ForgeResult PopUp;

	public Transition t0;

	public const string URL = "ui://h3bpjkt7pg605p";

	public static string Name = "UI_main_GvG3OemBonus";

	private readonly List<ForgedExtraAmplifier> _amps = new List<ForgedExtraAmplifier>(2);

	private readonly List<OEMTakerBonusItem> _rItem = new List<OEMTakerBonusItem>(5);

	private OEMResult _extraReward;

	public static string GetURL()
	{
		return "ui://h3bpjkt7pg605p";
	}

	public static UI_main_GvG3OemBonus CreateInstance()
	{
		return (UI_main_GvG3OemBonus)(object)UIPackage.CreateObject("GvGOEMBonus3", "main_GvG3OemBonus");
	}

	public static UI_main_GvG3OemBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3OemBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7pg605p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_ForgeResult)(object)((GComponent)this).GetChild("PopUp");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		if (parameters.TryGetValue("GiverBonus", out var value))
		{
			_amps.AddRange((value as List<ForgedExtraAmplifier>) ?? new List<ForgedExtraAmplifier>());
		}
		if (parameters.TryGetValue("TakerBonus", out var value2))
		{
			_rItem.AddRange((value2 as List<OEMTakerBonusItem>) ?? new List<OEMTakerBonusItem>());
		}
		if (parameters.TryGetValue("ExtraReward", out var value3))
		{
			_extraReward = (OEMResult)value3;
		}
		Render();
		int num = _rItem.Sum((OEMTakerBonusItem item) => item.Obtained ? item.Item.cnt : 0);
		if (num > 0)
		{
			string.Format("{0}+{1}", Item.Name(GameManagers.Instance, "I65001"), Mathf.RoundToInt((float)num)).ToTip();
		}
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)PopUp.Confirm).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)PopUp.Confirm).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void Render()
	{
		RenderAmps();
		RenderBonus();
		RenderExtraReward();
		void AmplifierRenderer(int index, GObject obj)
		{
			if (obj is UI_com_Amplifier uI_com_Amplifier)
			{
				ForgedExtraAmplifier forgedExtraAmplifier = _amps[index];
				RenderHelper_AmplifierIcon.RenderAmplifier(uI_com_Amplifier.AmplifierIcon, forgedExtraAmplifier.Idx);
				RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(uI_com_Amplifier.AffectedRange, forgedExtraAmplifier.Idx);
				uI_com_Amplifier.IsCriticalStrike.selectedIndex = (forgedExtraAmplifier.IsCritical ? 1 : 0);
				if (forgedExtraAmplifier.IsCritical)
				{
					uI_com_Amplifier.Quatity.selectedIndex = AmpConfigHelper.Configs.TryGetNormalAmplifier(forgedExtraAmplifier.Idx).Quality - 1;
				}
				uI_com_Amplifier.TalentSrc.selectedIndex = ((forgedExtraAmplifier.TalentSrc == eTalentSrc.泰坦造物) ? 1 : 0);
				if (uI_com_Amplifier.TalentSrc.selectedIndex == 1)
				{
					uI_com_Amplifier.TalentSrcIcon.url = "GvGTalent_36".ToPublicResourcesRgbIcon();
				}
			}
		}
		void BonusItemRenderer(int index, GObject obj)
		{
			if (obj is UI_com_OemBonus uI_com_OemBonus)
			{
				OEMTakerBonusItem oEMTakerBonusItem = _rItem[index];
				((GObject)uI_com_OemBonus.Count).text = oEMTakerBonusItem.Item.cnt.ToString();
				uI_com_OemBonus.Type.selectedIndex = (int)oEMTakerBonusItem.Type;
				uI_com_OemBonus.Get.selectedIndex = (oEMTakerBonusItem.Obtained ? 1 : 0);
			}
		}
		void RenderAmps()
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Expected O, but got Unknown
			PopUp.Amps.itemRenderer = new ListItemRenderer(AmplifierRenderer);
			PopUp.Amps.numItems = _amps.Count;
		}
		void RenderBonus()
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Expected O, but got Unknown
			PopUp.Bonus.itemRenderer = new ListItemRenderer(BonusItemRenderer);
			PopUp.Bonus.numItems = _rItem.Count;
			string itemId = _rItem[0].Item.ItemId;
			FGUIManager.Instance.SetItemIconAndFrame(PopUp.Icon, itemId, null, "", frameVisible: false);
			FGUIManager.Instance.SetItemIconAndFrame(PopUp.TotalIcon, itemId, null, "", frameVisible: false);
			((GObject)PopUp.TotalCount).text = _rItem.Sum((OEMTakerBonusItem item) => item.Obtained ? item.Item.cnt : 0).ToString();
		}
		void RenderExtraReward()
		{
			bool flag = _extraReward.TotalCount > 0;
			PopUp.hasExtraReward.SetSelectedIndex(flag ? 1 : 0);
			if (flag)
			{
				RenderExtraBonus(PopUp.ExtraReward, _extraReward);
			}
		}
	}

	public static void RenderExtraBonus(GList list, OEMResult result)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		list.itemProvider = new ListItemProvider(GetListItemResource);
		list.itemRenderer = new ListItemRenderer(OtherItemRenderer);
		int numItems = result.AmpsList.Count + result.ItemsList.Count;
		list.numItems = numItems;
		static void AmpRenderer(ForgedExtraAmplifier amplifier, GObject ampObj)
		{
			if (ampObj is UI_com_Amplifier uI_com_Amplifier)
			{
				RenderHelper_AmplifierIcon.RenderAmplifier(uI_com_Amplifier.AmplifierIcon, amplifier.Idx);
				RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(uI_com_Amplifier.AffectedRange, amplifier.Idx);
				uI_com_Amplifier.IsCriticalStrike.selectedIndex = (amplifier.IsCritical ? 1 : 0);
				if (amplifier.IsCritical)
				{
					uI_com_Amplifier.Quatity.selectedIndex = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(amplifier.Idx).AmplifierModel.Quality - 1;
				}
				uI_com_Amplifier.TalentSrc.selectedIndex = 1;
				uI_com_Amplifier.TalentSrcIcon.url = "GvGTalent_36".ToPublicResourcesRgbIcon();
				uI_com_Amplifier.Count.selectedIndex = 1;
				((GObject)uI_com_Amplifier.AmpCount).text = $"x{amplifier.Count}";
			}
		}
		string GetListItemResource(int index)
		{
			return (index < result.AmpsList.Count) ? "ui://h3bpjkt7pzxd5q" : "ui://kt6rg65oj1h8v4sm";
		}
		void OtherItemRenderer(int index, GObject obj)
		{
			if (index < result.AmpsList.Count)
			{
				ForgedExtraAmplifier amplifier = result.AmpsList[index];
				AmpRenderer(amplifier, obj);
			}
			else
			{
				ForgedExtraItem bonus = result.ItemsList[index - result.AmpsList.Count];
				RItemRenderer(bonus, obj);
			}
		}
		static void RItemRenderer(ForgedExtraItem bonus, GObject itemObj)
		{
			if (itemObj is UI_com_FormulaOem uI_com_FormulaOem)
			{
				uI_com_FormulaOem.RenderWithItemId(bonus.ItemId, bonus.Count);
			}
		}
	}
}
