using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.Common.Services;

namespace UI.PvpSelectSoldiers;

public class UI_PvpTotalRankListPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_PvpTotalRankingListDialog Dialog;

	public const string URL = "ui://82mo10n5lt7m9q";

	public static string Name = "UI_PvpTotalRankListPanel";

	public LoadWebImageTaskQueue loadAvatarQueue;

	public static UI_PvpTotalRankListPanel PvpTotalRankListPanel;

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m9q";
	}

	public static UI_PvpTotalRankListPanel CreateInstance()
	{
		return (UI_PvpTotalRankListPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpTotalRankListPanel");
	}

	public static UI_PvpTotalRankListPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpTotalRankListPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m9q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_PvpTotalRankingListDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
		PvpTotalRankListPanel = null;
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		PvpTotalRankListPanel = this;
		Dialog.GetPvpTotalRank();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void ClearLoadAvatarQueue()
	{
		loadAvatarQueue?.Clear();
	}

	public void CreateLoadAvatarQueue()
	{
		if (loadAvatarQueue == null)
		{
			loadAvatarQueue = new LoadWebImageTaskQueue();
		}
	}
}
