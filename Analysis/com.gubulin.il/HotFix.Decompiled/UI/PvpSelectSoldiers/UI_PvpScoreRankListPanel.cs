using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;

namespace UI.PvpSelectSoldiers;

public class UI_PvpScoreRankListPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_PvpScoreRankingListDialog Dialog;

	public const string URL = "ui://82mo10n5lt7m9d";

	public static string Name = "UI_PvpScoreRankListPanel";

	private List<ScoreRankSummary> _scoreRankList = new List<ScoreRankSummary>();

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m9d";
	}

	public static UI_PvpScoreRankListPanel CreateInstance()
	{
		return (UI_PvpScoreRankListPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpScoreRankListPanel");
	}

	public static UI_PvpScoreRankListPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpScoreRankListPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m9d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_PvpScoreRankingListDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_PvpScoreRankingListDialog.Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		DataInit(parameters);
		Dialog.RenderScoreRankingList(_scoreRankList);
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

	private void DataInit(Dictionary<string, object> parameters)
	{
		if (parameters.TryGetValue("ScoreRankingListData", out var value))
		{
			_scoreRankList = (List<ScoreRankSummary>)value;
		}
	}
}
