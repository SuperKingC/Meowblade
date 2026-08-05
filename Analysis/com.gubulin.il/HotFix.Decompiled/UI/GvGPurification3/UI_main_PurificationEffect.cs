using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Services;
using UI.GvGPurificationResult3;

namespace UI.GvGPurification3;

public class UI_main_PurificationEffect : GComponent, IUiController
{
	public GGraph Mask;

	public GImage n15;

	public UI_dec_02 n1;

	public UI_dec_01 n14;

	public UI_dec_01 n16;

	public UI_dec_01 n17;

	public UI_dec_01 n18;

	public UI_dec_01 n19;

	public GMovieClip n20;

	public GMovieClip n21;

	public GMovieClip n22;

	public GMovieClip n23;

	public GMovieClip n24;

	public GImage n25;

	public GMovieClip n27;

	public Transition Purification;

	public const string URL = "ui://v7vqvgvmzs6gm2";

	public static string Name = "UI_main_PurificationEffect";

	private const string _END_HOOK = "End";

	private Action _onEffectPlayComplete;

	public static bool WaitToForcedClose { get; set; }

	public static string GetURL()
	{
		return "ui://v7vqvgvmzs6gm2";
	}

	public static UI_main_PurificationEffect CreateInstance()
	{
		return (UI_main_PurificationEffect)(object)UIPackage.CreateObject("GvGPurification3", "main_PurificationEffect");
	}

	public static UI_main_PurificationEffect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_PurificationEffect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmzs6gm2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n1 = (UI_dec_02)(object)((GComponent)this).GetChild("n1");
		n14 = (UI_dec_01)(object)((GComponent)this).GetChild("n14");
		n16 = (UI_dec_01)(object)((GComponent)this).GetChild("n16");
		n17 = (UI_dec_01)(object)((GComponent)this).GetChild("n17");
		n18 = (UI_dec_01)(object)((GComponent)this).GetChild("n18");
		n19 = (UI_dec_01)(object)((GComponent)this).GetChild("n19");
		n20 = (GMovieClip)((GComponent)this).GetChild("n20");
		n21 = (GMovieClip)((GComponent)this).GetChild("n21");
		n22 = (GMovieClip)((GComponent)this).GetChild("n22");
		n23 = (GMovieClip)((GComponent)this).GetChild("n23");
		n24 = (GMovieClip)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n27 = (GMovieClip)((GComponent)this).GetChild("n27");
		Purification = ((GComponent)this).GetTransition("Purification");
	}

	public void BeforeDestroy()
	{
		WaitToForcedClose = false;
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_onEffectPlayComplete = parameters.ReadParamTalentFromParameters<Action>("PurificationResult");
	}

	public void OnShow()
	{
		TryPlayEffect();
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<string>("CLOSE_UI", OnPurificationResultPanelClose);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnPurificationResultPanelClose);
	}

	public static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private static void OnPurificationResultPanelClose(string uiName)
	{
		if (!(uiName != UI_main_GvG3PurificationResult.Name))
		{
			End();
		}
	}

	private void TryPlayEffect()
	{
		if (CanPlayEffect())
		{
			PlayEffect();
		}
	}

	private static bool CanPlayEffect()
	{
		if (WaitToForcedClose)
		{
			End();
			return false;
		}
		return true;
	}

	private void PlayEffect()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Purification.SetHook("End", (TransitionHook)delegate
		{
			_onEffectPlayComplete?.Invoke();
		});
		Purification.Play();
	}
}
