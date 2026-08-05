using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace UI.GvGOuterTech;

public class UI_main_TechUpgradePanel : GComponent, IUiController
{
	public GGraph back;

	public UI_com_TechUpgradeDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://th385mtt87xr2f";

	public static string Name = "UI_main_TechUpgradePanel";

	private TechData TechData;

	private int ConsumeStatePage;

	private RarityData RarityData;

	public static string GetURL()
	{
		return "ui://th385mtt87xr2f";
	}

	public static UI_main_TechUpgradePanel CreateInstance()
	{
		return (UI_main_TechUpgradePanel)(object)UIPackage.CreateObject("GvGOuterTech", "main_TechUpgradePanel");
	}

	public static UI_main_TechUpgradePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_TechUpgradePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtt87xr2f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_TechUpgradeDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		TechData = (parameters.TryGetValue("TechData", out var value) ? ((TechData)value) : null);
		ConsumeStatePage = (parameters.TryGetValue("ConsumeStatePage", out var value2) ? ((int)value2) : (-1));
		RarityData = new RarityData(TechData.Rarity);
		Dialog.t0.invalidateBatchingEveryFrame = true;
		Dialog.UpgradePane.HasEnterIZ.selectedIndex = ((Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.HasEnterIZ || Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.LastIZId != -1) ? 1 : 0);
		Update();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.UpgradePane.UnlockBtn).onClick.Set(new EventCallback0(OnClickUpgradeBtn));
		((GObject)Dialog.UpgradePane.UpgradeBtn).onClick.Set(new EventCallback0(OnClickUpgradeBtn));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.UpgradePane.UnlockBtn).onClick.Clear();
		((GObject)Dialog.UpgradePane.UpgradeBtn).onClick.Clear();
	}

	private void Update()
	{
		Dialog.Rarity.selectedIndex = TechData.Rarity;
		if (TechData.Level == 0)
		{
			Dialog.State.selectedIndex = 0;
		}
		else if (TechData.IsMaxLevel)
		{
			Dialog.State.selectedIndex = 2;
		}
		else
		{
			Dialog.State.selectedIndex = 1;
		}
		if (!TechData.Unlocked)
		{
			Dialog.ConsumeState.SetSelectedIndex(0);
		}
		else if (ConsumeStatePage != -1)
		{
			Dialog.ConsumeState.selectedIndex = ConsumeStatePage;
		}
		else
		{
			Dialog.ConsumeState.selectedIndex = ((RarityData.PieceCount != 0) ? 1 : 0);
		}
		Dialog.TechIcon.url = TechData.TechIconUrl;
		((GObject)Dialog.TechName).text = TechData.Name;
		((GObject)Dialog.Level).text = $"Lv. {TechData.Level}";
		((GObject)Dialog.Desc).text = TechData.Desc;
		((GObject)Dialog.CurEffect).text = TechData.CurLevelEffectDesc;
		((GObject)Dialog.NextEffect).text = TechData.NextLevelEffectDesc;
		((GObject)Dialog.UnlockEffect).text = ((GObject)Dialog.CurEffect).text;
		((GObject)Dialog.MaxEffect).text = ((GObject)Dialog.CurEffect).text;
		bool flag = RarityData.PieceCount >= RarityData.PieceUpgradeConsume;
		string richText = (flag ? "[color=#00ff00]{0}[/color]" : "[color=#ff0000]{0}[/color]");
		((GObject)Dialog.UpgradePane.PieceCost).text = $"{richText.Format(RarityData.PieceCount)}/{RarityData.PieceUpgradeConsume}";
		Dialog.UpgradePane.PieceIcon.url = RarityData.PieceItemIconUrl;
		Dialog.UpgradePane.CanUpgrade.selectedIndex = (flag ? 1 : 0);
	}

	private void OnClickUpgradeBtn()
	{
		if (TechData.Level == 0)
		{
			"GvG3UnlockOuterTechTip".ToLanguage().Format(RarityData.PieceUpgradeConsume, TechData.Name).ToConfirmPopup(OnConfirm, null, (AlignType)0);
		}
		else
		{
			"GvG3UpgradeOuterTechTip".ToLanguage().Format(RarityData.PieceUpgradeConsume, TechData.Name).ToConfirmPopup(OnConfirm2, null, (AlignType)0);
		}
		void OnConfirm()
		{
			Singleton<GvGOuterTechManager>.Instance.UpgradeTech(TechData.ItemId, OnUnlockSuccess);
		}
		void OnConfirm2()
		{
			Singleton<GvGOuterTechManager>.Instance.UpgradeTech(TechData.ItemId, OnUpgradeSuccess);
		}
		void OnUnlockSuccess()
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			Dialog.UnlockTrans.SetHook("OnChange", (TransitionHook)delegate
			{
				Update();
			});
			Dialog.UnlockTrans.Play();
		}
		void OnUpgradeSuccess()
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			Dialog.UpgradeTrans.SetHook("OnChange", (TransitionHook)delegate
			{
				Update();
			});
			Dialog.UpgradeTrans.Play();
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		Update();
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
