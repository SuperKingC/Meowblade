using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace UI.GvGOEMResult3;

public class UI_main_GvG3OemResult : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_ForgeResult PopUp;

	public Transition t0;

	public const string URL = "ui://5k1s1pjxpg605q";

	public static string Name = "UI_main_GvG3OemResult";

	private OEMGiverClaimBonus _claimBonus;

	private readonly List<object> _other = new List<object>();

	private int _titanAmpCnt;

	public static string GetURL()
	{
		return "ui://5k1s1pjxpg605q";
	}

	public static UI_main_GvG3OemResult CreateInstance()
	{
		return (UI_main_GvG3OemResult)(object)UIPackage.CreateObject("GvGOEMResult3", "main_GvG3OemResult");
	}

	public static UI_main_GvG3OemResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3OemResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5k1s1pjxpg605q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		_claimBonus = (parameters.TryGetValue("ClaimBonus", out var value) ? (value as OEMGiverClaimBonus) : null);
		Renderer();
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

	private void Renderer()
	{
		SplitData();
		RendererAmps();
		RenderOtherBonus();
		void SplitData()
		{
			for (int num = _claimBonus.Amps.Count - 1; num >= 0; num--)
			{
				if (_claimBonus.Amps[num].TalentSrc == eTalentSrc.泰坦造物)
				{
					_other.Add(_claimBonus.Amps[num]);
					_claimBonus.Amps.RemoveAt(num);
				}
			}
			_other.AddRange(_claimBonus.ReturnCost_ToProtocol);
			_titanAmpCnt = _other.Count - _claimBonus.ReturnCost_ToProtocol.Count;
		}
	}

	private void RendererAmps()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		PopUp.Amps.itemRenderer = new ListItemRenderer(RendererAmplifier);
		PopUp.Amps.numItems = _claimBonus.Amps.Count;
		PopUp.HasAmps.selectedIndex = ((_claimBonus.Amps.Count > 0) ? 1 : 0);
	}

	private void RendererAmplifier(int index, GObject obj)
	{
		if (obj is UI_com_Amplifier uI_com_Amplifier)
		{
			ForgedExtraAmplifier forgedExtraAmplifier = _claimBonus.Amps[index];
			RenderHelper_AmplifierIcon.RenderAmplifier(uI_com_Amplifier.AmplifierIcon, forgedExtraAmplifier.Idx);
			RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(uI_com_Amplifier.AffectedRange, forgedExtraAmplifier.Idx);
			uI_com_Amplifier.IsCriticalStrike.selectedIndex = (forgedExtraAmplifier.IsCritical ? 1 : 0);
			if (forgedExtraAmplifier.IsCritical)
			{
				uI_com_Amplifier.Quatity.selectedIndex = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(forgedExtraAmplifier.Idx).AmplifierModel.Quality;
			}
			uI_com_Amplifier.Count.selectedIndex = 1;
			((GObject)uI_com_Amplifier.AmpCount).text = forgedExtraAmplifier.Count.ToString();
		}
	}

	private void RenderOtherBonus()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		PopUp.Other.SetVirtual();
		PopUp.Other.itemProvider = new ListItemProvider(GetListItemResource);
		PopUp.Other.itemRenderer = new ListItemRenderer(OtherItemRenderer);
		PopUp.Other.numItems = _other.Count;
		PopUp.HasExtraBonus.selectedIndex = ((_other.Count > 0) ? 1 : 0);
	}

	private string GetListItemResource(int index)
	{
		return (index < _titanAmpCnt) ? "ui://GvGOEMResult3/com_Amplifier" : "ui://GvGOEMResult3/com_OemBonus";
	}

	private void OtherItemRenderer(int index, GObject obj)
	{
		object bonus = _other[index];
		if (index < _titanAmpCnt)
		{
			AmpRenderer(bonus, obj);
		}
		else
		{
			RItemRenderer(bonus, obj);
		}
		static void AmpRenderer(object obj2, GObject ampObj)
		{
			if (ampObj is UI_com_Amplifier uI_com_Amplifier && obj2 is ForgedExtraAmplifier forgedExtraAmplifier)
			{
				RenderHelper_AmplifierIcon.RenderAmplifier(uI_com_Amplifier.AmplifierIcon, forgedExtraAmplifier.Idx);
				RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(uI_com_Amplifier.AffectedRange, forgedExtraAmplifier.Idx);
				uI_com_Amplifier.IsCriticalStrike.selectedIndex = (forgedExtraAmplifier.IsCritical ? 1 : 0);
				if (forgedExtraAmplifier.IsCritical)
				{
					uI_com_Amplifier.Quatity.selectedIndex = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(forgedExtraAmplifier.Idx).AmplifierModel.Quality - 1;
				}
				uI_com_Amplifier.TalentSrc.selectedIndex = 1;
				uI_com_Amplifier.TalentSrcIcon.url = "GvGTalent_36".ToPublicResourcesRgbIcon();
				uI_com_Amplifier.Count.selectedIndex = 1;
				((GObject)uI_com_Amplifier.AmpCount).text = forgedExtraAmplifier.Count.ToString();
			}
		}
		static void RItemRenderer(object obj2, GObject itemObj)
		{
			if (itemObj is UI_com_OemBonus uI_com_OemBonus && obj2 is RItem rItem)
			{
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_OemBonus.ItemIcon, rItem.ItemId);
				((GObject)uI_com_OemBonus.Count).text = rItem.cnt.ToString();
			}
		}
	}
}
