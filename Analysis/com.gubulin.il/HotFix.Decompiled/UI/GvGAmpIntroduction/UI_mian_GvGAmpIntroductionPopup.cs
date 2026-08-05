using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;

namespace UI.GvGAmpIntroduction;

public class UI_mian_GvGAmpIntroductionPopup : GComponent, IUiController
{
	public GLoader background;

	public UI_com_GvGAmpIntroductionDialog Dialog;

	public Transition t0;

	public const string URL = "ui://vt1dz12wkz6b0";

	public static string Name = "UI_mian_GvGAmpIntroductionPopup";

	private int Idx;

	private AmplifierModel AmplifierModel;

	public static string GetURL()
	{
		return "ui://vt1dz12wkz6b0";
	}

	public static UI_mian_GvGAmpIntroductionPopup CreateInstance()
	{
		return (UI_mian_GvGAmpIntroductionPopup)(object)UIPackage.CreateObject("GvGAmpIntroduction", "mian_GvGAmpIntroductionPopup");
	}

	public static UI_mian_GvGAmpIntroductionPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mian_GvGAmpIntroductionPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vt1dz12wkz6b0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		Dialog = (UI_com_GvGAmpIntroductionDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("AmpIdx", out var value))
		{
			Idx = (int)value;
			AmplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(Idx);
			Render();
		}
	}

	private void Render()
	{
		RenderHelper_AmplifierIcon.RenderAmplifier(Dialog.AmplifierIcon, AmplifierModel);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedRange(Dialog.AffectedRange, AmplifierModel);
		((GObject)Dialog.Count).text = Singleton<GvGAmplifierManager>.Instance.GetAmplifierOwnedCount(Idx).ToString();
		((GObject)Dialog.AmpName).text = AmplifierModel.Name;
		((GObject)Dialog.AmpAffectedRangeText).text = AmplifierModel.EffectRangeDesc;
		Dialog.Quality.selectedIndex = AmplifierModel.Quality;
		((GObject)Dialog.Property).text = "";
		List<KeyValuePair<string, float>> desc = AmplifierModel.Desc;
		for (int i = 0; i < desc.Count; i++)
		{
			KeyValuePair<string, float> keyValuePair = desc[i];
			GTextField property = Dialog.Property;
			((GObject)property).text = ((GObject)property).text + string.Format(keyValuePair.Key, keyValuePair.Value);
			if (i < desc.Count - 1)
			{
				GTextField property2 = Dialog.Property;
				((GObject)property2).text = ((GObject)property2).text + "\n";
			}
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)background).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)background).onClick.Clear();
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

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
