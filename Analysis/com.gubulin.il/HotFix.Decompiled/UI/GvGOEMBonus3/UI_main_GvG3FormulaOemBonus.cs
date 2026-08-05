using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

namespace UI.GvGOEMBonus3;

public class UI_main_GvG3FormulaOemBonus : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__10_0;

		internal void _003CRegisterUiEventListeners_003Eb__10_0()
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		}
	}

	public GGraph Mask;

	public UI_com_FormulaForgeResult PopUp;

	public Transition t0;

	public const string URL = "ui://h3bpjkt7t0zv62";

	public static string Name = "UI_main_GvG3FormulaOemBonus";

	public const string ResultParam = "Result";

	public static string GetURL()
	{
		return "ui://h3bpjkt7t0zv62";
	}

	public static UI_main_GvG3FormulaOemBonus CreateInstance()
	{
		return (UI_main_GvG3FormulaOemBonus)(object)UIPackage.CreateObject("GvGOEMBonus3", "main_GvG3FormulaOemBonus");
	}

	public static UI_main_GvG3FormulaOemBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3FormulaOemBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7t0zv62", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_FormulaForgeResult)(object)((GComponent)this).GetChild("PopUp");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		EventListener onClick = ((GObject)PopUp.Confirm).onClick;
		object obj = _003C_003Ec._003C_003E9__10_0;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				GameController.Contexts.Service<IUiService>().ClosePanel(Name);
			};
			_003C_003Ec._003C_003E9__10_0 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback0)obj);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)PopUp.Confirm).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		C2S_SubmitFormulaOEMMission.Response response = (C2S_SubmitFormulaOEMMission.Response)parameters["Result"];
		List<ForgedExtraAmplifier> ampList = response.OEMResultTaker.AmpsList;
		PopUp.Amps.itemRenderer = new ListItemRenderer(AmplifierRenderer);
		PopUp.Amps.numItems = ampList.Count;
		void AmplifierRenderer(int index, GObject obj)
		{
			if (obj is UI_com_Amplifier uI_com_Amplifier)
			{
				ForgedExtraAmplifier forgedExtraAmplifier = ampList[index];
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
				uI_com_Amplifier.Count.SetSelectedIndex(1);
				((GObject)uI_com_Amplifier.AmpCount).text = $"x{forgedExtraAmplifier.Count}";
			}
		}
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}
}
