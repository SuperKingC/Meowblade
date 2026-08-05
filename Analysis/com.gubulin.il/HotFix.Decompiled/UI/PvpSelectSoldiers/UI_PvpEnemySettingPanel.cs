using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace UI.PvpSelectSoldiers;

public class UI_PvpEnemySettingPanel : GComponent, IUiController
{
	private class SelectFormations
	{
		public Dictionary<string, SelectFormation> Data = new Dictionary<string, SelectFormation>();

		public bool CheckValid()
		{
			bool flag = true;
			if (Data == null)
			{
				Data = new Dictionary<string, SelectFormation>();
				for (int i = 0; i < 3; i++)
				{
					Data.Add(i.ToString(), new SelectFormation(i));
				}
			}
			Dictionary<string, int> ownedSoldiers = GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true);
			List<KeyValuePair<string, SelectFormation>> list = Data.ToList();
			for (int j = 0; j < list.Count; j++)
			{
				flag &= list[j].Value.CheckValid();
				for (int num = list[j].Value.SoldiersId.Count - 1; num >= 0; num--)
				{
					string text = list[j].Value.SoldiersId[num];
					if (!(text == ""))
					{
						if (ownedSoldiers.ContainsKey(text))
						{
							ownedSoldiers.Remove(text);
						}
						else
						{
							list[j].Value.SoldiersId[num] = "";
						}
					}
				}
			}
			return flag;
		}
	}

	private class SelectFormation
	{
		public int ArrayId { get; set; }

		public List<string> SoldiersId { get; set; } = null;

		public string FormationId { get; set; } = string.Empty;

		public SelectFormation(int ArrayId)
		{
			this.ArrayId = ArrayId;
			CheckValid();
		}

		public void ClearData()
		{
			SoldiersId = null;
			FormationId = string.Empty;
			CheckValid();
		}

		public bool CheckValid()
		{
			if (SoldiersId == null)
			{
				SoldiersId = new List<string> { "", "", "", "", "" };
			}
			if (SoldiersId.Count > 5)
			{
				SoldiersId = SoldiersId.GetRange(0, 5);
			}
			if (FormationId == string.Empty)
			{
				return false;
			}
			return true;
		}
	}

	public GGraph blackMask;

	public GLoader background;

	public UI_SettingBtn SettingBtn;

	public GButton backBtn;

	public GList EnemyFormationsList;

	public GImage flashImage;

	public GTextField EnemyCombat;

	public GTextField n21;

	public GGroup PowerEnemy;

	public GList EnemyFormations;

	public UI_EnemyFormationSketchMap EnemyFormationSketchMap;

	public const string URL = "ui://82mo10n5iirg6i";

	public static string Name = "UI_PvpEnemySettingPanel";

	public static UI_PvpEnemySettingPanel PvpEnemySettingPanel;

	private const int ArrayNum = 3;

	public List<string> selectedEnemySoldierId = new List<string>();

	private SelectFormations selectEnemyFormations = new SelectFormations();

	private string curSelectEnemyFormationArrayId;

	private List<Formation> unlockFormations = new List<Formation>();

	public static string GetURL()
	{
		return "ui://82mo10n5iirg6i";
	}

	public static UI_PvpEnemySettingPanel CreateInstance()
	{
		return (UI_PvpEnemySettingPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpEnemySettingPanel");
	}

	public static UI_PvpEnemySettingPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpEnemySettingPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5iirg6i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		blackMask = (GGraph)((GComponent)this).GetChild("blackMask");
		background = (GLoader)((GComponent)this).GetChild("background");
		SettingBtn = (UI_SettingBtn)(object)((GComponent)this).GetChild("SettingBtn");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		EnemyFormationsList = (GList)((GComponent)this).GetChild("EnemyFormationsList");
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		EnemyCombat = (GTextField)((GComponent)this).GetChild("EnemyCombat");
		string id = "ui://82mo10n5iirg6i".Replace("ui://", "") + "-" + ((GObject)EnemyCombat).id;
		((GObject)EnemyCombat).text = LanguagesManager.GetDesc(id);
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id2 = "ui://82mo10n5iirg6i".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id2);
		PowerEnemy = (GGroup)((GComponent)this).GetChild("PowerEnemy");
		EnemyFormations = (GList)((GComponent)this).GetChild("EnemyFormations");
		EnemyFormationSketchMap = (UI_EnemyFormationSketchMap)(object)((GComponent)this).GetChild("EnemyFormationSketchMap");
	}

	public void BeforeDestroy()
	{
		PvpEnemySettingPanel = null;
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		((GObject)blackMask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		PvpEnemySettingPanel = this;
		LoadEnemyDataLocal();
		GetAllUnlockFormations();
		RenderEnemyArrayIndex();
		ShowCurEnemyFormation();
		RenderEnemyAllSelectedFormations();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)SettingBtn.ConfirmBtn).onClick.Add(new EventCallback0(SettingLevel));
		SharedMessenger.AddListener<EventContext, string, int>("ON_SOLDIER_SELECTED", EnemyFormationSketchMap.OnCampClose);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)SettingBtn.ConfirmBtn).onClick.Remove(new EventCallback0(SettingLevel));
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", EnemyFormationSketchMap.OnCampClose);
	}

	private void LoadEnemyDataLocal()
	{
		selectEnemyFormations.Data = null;
		string text = GameLocalDataManager.GetString("PVP_Rank_EnemyConfig");
		if (!string.IsNullOrEmpty(text))
		{
			selectEnemyFormations.Data = JsonHelper.ToObject<Dictionary<string, SelectFormation>>(text);
		}
		selectEnemyFormations.CheckValid();
		foreach (KeyValuePair<string, SelectFormation> datum in selectEnemyFormations.Data)
		{
			for (int i = 0; i < datum.Value.SoldiersId.Count; i++)
			{
				string text2 = datum.Value.SoldiersId[i];
				if (!string.IsNullOrEmpty(text2) && text2 != "Lock" && text2 != "Unlock")
				{
					selectedEnemySoldierId.Add(text2);
				}
			}
		}
	}

	private bool SaveEnemyDataLocal()
	{
		bool result = selectEnemyFormations.CheckValid();
		GameLocalDataManager.SetString("PVP_Rank_EnemyConfig", JsonHelper.ToJson(selectEnemyFormations.Data));
		return result;
	}

	private void RenderEnemyArrayIndex()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		EnemyFormationsList.itemRenderer = new ListItemRenderer(RenderEnemyIndex);
		EnemyFormationsList.numItems = 3;
	}

	private void RenderEnemyIndex(int index, GObject obj)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		UI_ArrayIndex uI_ArrayIndex = obj as UI_ArrayIndex;
		List<KeyValuePair<string, SelectFormation>> list = selectEnemyFormations.Data.ToList();
		string key = list[index].Key;
		((GObject)uI_ArrayIndex.indexText).text = $"{index + 1}";
		((GObject)uI_ArrayIndex).data = key;
		((GObject)uI_ArrayIndex).onClick.Set(new EventCallback1(CheckSomeEnemyArray));
	}

	private void CheckSomeEnemyArray(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string arrayId = ((GObject)context.sender).data.ToString();
		ShowCurEnemyFormation(arrayId);
	}

	private void ShowCurEnemyFormation(string _arrayId = "")
	{
		curSelectEnemyFormationArrayId = (string.IsNullOrEmpty(_arrayId) ? selectEnemyFormations.Data.ToList().First().Key : _arrayId);
		EnemyFormationSketchMap.SetOurPos(selectEnemyFormations.Data[curSelectEnemyFormationArrayId].FormationId, selectEnemyFormations.Data[curSelectEnemyFormationArrayId].SoldiersId, selectedEnemySoldierId);
	}

	private void RenderEnemyAllSelectedFormations()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		EnemyFormations.itemRenderer = new ListItemRenderer(RenderEnemyFormation);
		EnemyFormations.numItems = unlockFormations.Count;
	}

	private void RenderEnemyFormation(int index, GObject obj)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		((GComponent)asButton).GetChild("FormationName").text = unlockFormations[index].Name;
		((GObject)asButton).data = unlockFormations[index].Id;
		((GObject)asButton).onClick.Set(new EventCallback1(SelectEnemyFormation));
	}

	private void SelectEnemyFormation(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string formationId = ((GObject)context.sender).data.ToString();
		selectEnemyFormations.Data[curSelectEnemyFormationArrayId].FormationId = formationId;
		ShowCurEnemyFormation(curSelectEnemyFormationArrayId);
	}

	private void SettingLevel()
	{
		if (!SaveEnemyDataLocal())
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText479") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText480") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		if (string.IsNullOrWhiteSpace(((GObject)SettingBtn.level).text))
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText477") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			return;
		}
		List<string> list = new List<string>();
		if (int.TryParse(((GObject)SettingBtn.level).text, out var result))
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText481") + ((GObject)SettingBtn.level).text + LanguagesManager.GetDesc("CsharpCodeZhTcText482"));
			SetFormationUnitsOfRank(result);
		}
		else
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText483") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText484") + " " + ((GObject)SettingBtn.level).text);
		}
		SharedMessenger.Broadcast("SHOW_TIPS", list, 1, arg3: false);
	}

	public void UpdateSomeEnemyBtn(int _index, string _sid)
	{
		List<string> soldiersId = selectEnemyFormations.Data[curSelectEnemyFormationArrayId].SoldiersId;
		soldiersId[_index] = _sid;
	}

	public void UpdateSelectedEnemySoldierId(string _sid, bool isAdd)
	{
		if (isAdd)
		{
			if (!selectedEnemySoldierId.Contains(_sid))
			{
				selectedEnemySoldierId.Add(_sid);
			}
		}
		else if (selectedEnemySoldierId.Contains(_sid))
		{
			selectedEnemySoldierId.Remove(_sid);
		}
	}

	private void SetFormationUnitsOfRank(int rank)
	{
		List<string> formationsId = new List<string>();
		List<List<string>> unitsId = new List<List<string>>();
		foreach (SelectFormation value in selectEnemyFormations.Data.Values)
		{
			formationsId.Add(value.FormationId);
			unitsId.Add(value.SoldiersId.ToList());
		}
		ILRequestHelper<SetFormationUnitsOfRankResponse>.Request((EventContext)null, (Func<Task<SetFormationUnitsOfRankResponse>>)(() => GameController.Contexts.Service<INetworkService>().SetFormationUnitsOfRank(rank, formationsId, unitsId)), (Action<SetFormationUnitsOfRankResponse>)delegate(SetFormationUnitsOfRankResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText478") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		});
	}

	private void GetAllUnlockFormations()
	{
		Dictionary<string, GDEFormationData> unlockedFormations = GameManagers.Instance.FormationManager.GetUnlockedFormations();
		List<string> unlockFormationsId = new List<string>();
		foreach (KeyValuePair<string, GDEFormationData> item in unlockedFormations)
		{
			unlockFormationsId.Add(item.Value.Key);
		}
		List<Formation> source = FormationManager.PlayerUsableFormations.Values.ToList();
		unlockFormations.Clear();
		unlockFormations.AddRange(source.OrderByDescending((Formation formation) => unlockFormationsId.Contains(formation.Id)));
		for (int num = unlockFormations.Count - 1; num >= 0; num--)
		{
			if (!unlockFormationsId.Contains(unlockFormations[num].Id))
			{
				unlockFormations.RemoveAt(num);
			}
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
