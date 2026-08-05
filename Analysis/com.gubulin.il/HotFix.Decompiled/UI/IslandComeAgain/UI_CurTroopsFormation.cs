using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using GvG2;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace UI.IslandComeAgain;

public class UI_CurTroopsFormation : GComponent
{
	public Controller Status;

	public GGraph n1;

	public UI_FormationBtn MainFormation;

	public GList Formations;

	public GImage arrowUp;

	public GImage arrowDown;

	public GTextField n10;

	public GGraph n11;

	public UI_ChangeFormationBtn ChangeFormation;

	public const string URL = "ui://k2sprg26in7b1w";

	public static string Name = "UI_CurTroopsFormation";

	public string curFid;

	private int ShipId;

	public List<Formation> unlockFormations = new List<Formation>();

	public static string GetURL()
	{
		return "ui://k2sprg26in7b1w";
	}

	public static UI_CurTroopsFormation CreateInstance()
	{
		return (UI_CurTroopsFormation)(object)UIPackage.CreateObject("IslandComeAgain", "CurTroopsFormation");
	}

	public static UI_CurTroopsFormation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CurTroopsFormation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b1w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		MainFormation = (UI_FormationBtn)(object)((GComponent)this).GetChild("MainFormation");
		Formations = (GList)((GComponent)this).GetChild("Formations");
		arrowUp = (GImage)((GComponent)this).GetChild("arrowUp");
		arrowDown = (GImage)((GComponent)this).GetChild("arrowDown");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://k2sprg26in7b1w".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
		n11 = (GGraph)((GComponent)this).GetChild("n11");
		ChangeFormation = (UI_ChangeFormationBtn)(object)((GComponent)this).GetChild("ChangeFormation");
	}

	public void CurFormationInit(string _fid, int _shipId)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		Status.selectedIndex = 0;
		ShipId = _shipId;
		curFid = _fid;
		GetAllUnlockFormations();
		RenderCurFormation(MainFormation, _fid);
		Formations.selectedIndex = -1;
		((GButton)MainFormation).selected = false;
		((GObject)ChangeFormation).onClick.Set(new EventCallback0(Confirm));
	}

	public void GetAllUnlockFormations()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		((GObject)MainFormation).onClick.Set(new EventCallback1(CurFormationClick));
		if (unlockFormations != null && unlockFormations.Count > 0)
		{
			return;
		}
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

	private void RenderCurFormation(UI_FormationBtn _curFormationBtn, string _formationId)
	{
		if (string.IsNullOrEmpty(_formationId))
		{
			((GObject)_curFormationBtn.name).text = "";
			_curFormationBtn.formationIcon.url = "";
			return;
		}
		Formation formation = FormationManager.Formations[_formationId];
		((GObject)_curFormationBtn.name).text = formation.Name;
		_curFormationBtn.formationIcon.url = "ui://IslandComeAgain/" + formation.Icon;
		((GObject)_curFormationBtn.Level).text = "1" + LanguagesManager.GetDesc("CsharpCodeZhTcText124");
	}

	private void CurFormationClick(EventContext context)
	{
		context.StopPropagation();
		if (Status.selectedIndex == 0)
		{
			Status.selectedIndex = 1;
			RenderUnlockFormations();
		}
	}

	private void RenderUnlockFormations()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		Formations.itemRenderer = new ListItemRenderer(RenderFormation);
		Formations.numItems = unlockFormations.Count;
	}

	private void RenderFormation(int index, GObject obj)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		UI_FormationBtn uI_FormationBtn = obj as UI_FormationBtn;
		RenderCurFormation(uI_FormationBtn, unlockFormations[index].Id);
		((GObject)uI_FormationBtn).data = unlockFormations[index].Id;
		((GObject)uI_FormationBtn).onClick.Set(new EventCallback1(SelectArrayFormation));
	}

	private void SelectArrayFormation(EventContext context)
	{
		UI_FormationBtn uI_FormationBtn = context.sender as UI_FormationBtn;
		string value = ((GObject)(uI_FormationBtn?)).data.ToString();
		if (!string.IsNullOrEmpty(value))
		{
			curFid = value;
			Formations.selectedIndex = ((GComponent)Formations).GetChildIndex((GObject)(object)uI_FormationBtn);
		}
	}

	private void Confirm()
	{
		if (string.Equals(Singleton<GvGInstanceZone>.Instance.FormationId, curFid))
		{
			Status.selectedIndex = 0;
			return;
		}
		Singleton<GvGInstanceZone>.Instance.FormationId = curFid;
		SharedMessenger.Broadcast("ISLAND_COME_AGAIN_UPDATE_FORMATION", curFid);
		CurFormationInit(curFid, ShipId);
	}
}
