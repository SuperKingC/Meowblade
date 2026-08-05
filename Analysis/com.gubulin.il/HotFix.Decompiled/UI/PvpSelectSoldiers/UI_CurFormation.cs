using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace UI.PvpSelectSoldiers;

public class UI_CurFormation : GComponent
{
	public Controller Status;

	public GGraph n1;

	public GImage n7;

	public UI_FormationBtn MainFormation;

	public GList Formations;

	public GGraph n8;

	public GImage arrowUp;

	public GImage arrowDown;

	public const string URL = "ui://82mo10n5gox2j";

	public static string Name = "UI_CurFormation";

	public string curFid;

	public List<Formation> unlockFormations = new List<Formation>();

	public static string GetURL()
	{
		return "ui://82mo10n5gox2j";
	}

	public static UI_CurFormation CreateInstance()
	{
		return (UI_CurFormation)(object)UIPackage.CreateObject("PvpSelectSoldiers", "CurFormation");
	}

	public static UI_CurFormation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CurFormation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5gox2j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		MainFormation = (UI_FormationBtn)(object)((GComponent)this).GetChild("MainFormation");
		Formations = (GList)((GComponent)this).GetChild("Formations");
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		arrowUp = (GImage)((GComponent)this).GetChild("arrowUp");
		arrowDown = (GImage)((GComponent)this).GetChild("arrowDown");
	}

	public void CurFormationInit(string _fid)
	{
		Status.selectedIndex = 0;
		curFid = _fid;
		RenderCurFormation(MainFormation, _fid);
	}

	public void GetAllUnlockFormations(List<Formation> _formations = null)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback1(CurFormationClick));
		if (_formations != null && _formations.Count > 0)
		{
			unlockFormations = _formations;
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
		_curFormationBtn.formationIcon.url = "ui://PvpSelectSoldiers/" + formation.Icon;
		((GObject)_curFormationBtn.Level).text = "1" + LanguagesManager.GetDesc("CsharpCodeZhTcText124");
	}

	private void CurFormationClick(EventContext context)
	{
		if (Status.selectedIndex == 0)
		{
			Status.selectedIndex = 1;
			RenderUnlockFormations();
		}
		else if (Status.selectedIndex == 1)
		{
			Status.selectedIndex = 0;
			CurFormationInit(curFid);
		}
		context.StopPropagation();
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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string text = ((GObject)context.sender).data.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			curFid = text;
			UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel.UpdateCurSelectFormation(text);
		}
	}
}
