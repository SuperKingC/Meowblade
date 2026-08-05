using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.MedalUi;
using Shift.Legion.Common.Services;

namespace UI.GvG3Medal;

public class UI_main_GvG3Medal : GComponent, IUiController
{
	public Controller RecordsDisplay;

	public GLoader background;

	public GImage n5;

	public GButton Back;

	public UI_com_Title Title;

	public GButton Help;

	public UI_com_AcquiredMedals AcquiredMedals;

	public UI_com_PublishedMedals PublishedMedals;

	public GList Medals;

	public UI_com_MedalRecords MedalRecords;

	public const string URL = "ui://g5hi1peogwf80";

	public static string Name = "UI_main_GvG3Medal";

	private MedalUiController _controller;

	public const string I66000 = "I66000";

	public static string GetURL()
	{
		return "ui://g5hi1peogwf80";
	}

	public static UI_main_GvG3Medal CreateInstance()
	{
		return (UI_main_GvG3Medal)(object)UIPackage.CreateObject("GvG3Medal", "main_GvG3Medal");
	}

	public static UI_main_GvG3Medal CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3Medal).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peogwf80", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RecordsDisplay = ((GComponent)this).GetController("RecordsDisplay");
		background = (GLoader)((GComponent)this).GetChild("background");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Back = (GButton)((GComponent)this).GetChild("Back");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		Help = (GButton)((GComponent)this).GetChild("Help");
		AcquiredMedals = (UI_com_AcquiredMedals)(object)((GComponent)this).GetChild("AcquiredMedals");
		PublishedMedals = (UI_com_PublishedMedals)(object)((GComponent)this).GetChild("PublishedMedals");
		Medals = (GList)((GComponent)this).GetChild("Medals");
		MedalRecords = (UI_com_MedalRecords)(object)((GComponent)this).GetChild("MedalRecords");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_com_PublishedMedals.Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)PublishedMedals.Publish).enabled = false;
		_controller = new MedalUiController();
		_controller.GetMedalRecords(InitialRender);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Back).onClick.Set(new EventCallback0(End));
		((GObject)Help).onClick.Set(new EventCallback0(OnHelpClick));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Back).onClick.Clear();
		((GObject)Help).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OnHelpClick()
	{
		"GvG3HelpButtonClick".ToShowLanguageTip();
	}

	private void ChangeMedals()
	{
		_controller.ChangeMedals(UpdateMedals);
	}

	private void ChangeMedal(EventContext context)
	{
		EventDispatcher sender = context.sender;
		GObject val = (GObject)(object)((sender is GObject) ? sender : null);
		if (val == null)
		{
			throw new Exception("UI_main_GvG3Medal.ChangeMedal context.sender is not GObject");
		}
		context.StopPropagation();
		bool enabled = _controller.ChangeMedalDisplay(val.data.ToString(), UpdateMedal);
		((GObject)PublishedMedals.Publish).enabled = enabled;
	}

	private void CloseMedalRecords()
	{
		RecordsDisplay.SetSelectedIndex(0);
	}

	private void ShowMedalRecords(EventContext context)
	{
		if (!(context.sender is UI_com_MedalBig { DisplayMedalId: var displayMedalId }))
		{
			throw new Exception("UI_main_GvG3Medal.ShowMedalRecords context.sender is not UI_com_MedalBig");
		}
		if (!("I66000" == displayMedalId))
		{
			_controller.GetMedalRank(displayMedalId, ShowRecords);
		}
		void ShowRecords(GvGMedalRecord medal)
		{
			RecordsDisplay.SetSelectedIndex(1);
			MedalRecords.Show(medal);
		}
	}

	private void InitialRender(List<GvGMedalRecord> records)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0072: Expected O, but got Unknown
		RenderMedals(records);
		AcquiredMedals.OnRender(_controller.Summary);
		PublishedMedals.Init(new EventCallback0(ChangeMedals));
		PublishedMedals.Update(_controller.SimplifiedMedals);
		MedalRecords.Init(new EventCallback0(CloseMedalRecords), new EventCallback1(ChangeMedal));
	}

	private void RenderMedals(List<GvGMedalRecord> medals)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		List<GvGMedalRecord> displays = medals.Where((GvGMedalRecord m) => m.Activated || !(m.MedalId == "I66000")).ToList();
		Medals.itemRenderer = new ListItemRenderer(Render);
		Medals.numItems = displays.Count;
		void Render(int index, GObject obj)
		{
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			if (!(obj is UI_com_MedalBig uI_com_MedalBig))
			{
				throw new Exception("UI_main_GvG3Medal.UpdateMedals medalUi is not UI_com_MedalBig");
			}
			uI_com_MedalBig.OnRender(displays[index], new EventCallback1(ChangeMedal));
			((GObject)uI_com_MedalBig).onClick.Set(new EventCallback1(ShowMedalRecords));
		}
	}

	private void UpdateMedals(List<GvGMedalRecord> medals)
	{
		((GObject)PublishedMedals.Publish).enabled = false;
		RenderMedals(medals);
		PublishedMedals.Update(_controller.SimplifiedMedals);
	}

	private void UpdateMedal(GvGMedalRecord medal)
	{
		if (RecordsDisplay.selectedIndex == 1)
		{
			MedalRecords.Update(medal);
		}
		for (int i = 0; i < ((GComponent)Medals).numChildren; i++)
		{
			if (!(((GComponent)Medals).GetChildAt(i) is UI_com_MedalBig uI_com_MedalBig))
			{
				throw new Exception("UI_main_GvG3Medal.UpdateMedal Medals child is not UI_com_MedalBig");
			}
			if (!(uI_com_MedalBig.DisplayMedalId != medal.MedalId))
			{
				uI_com_MedalBig.ActivatedMedal.Update(medal);
			}
		}
		PublishedMedals.Update(_controller.SimplifiedMedals);
	}
}
