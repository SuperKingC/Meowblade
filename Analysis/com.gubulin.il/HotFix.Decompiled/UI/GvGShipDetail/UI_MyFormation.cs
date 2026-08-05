using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace UI.GvGShipDetail;

public class UI_MyFormation : GComponent
{
	public Controller Status;

	public GImage n10;

	public GImage background;

	public GList Formations;

	public UI_SelectedFormationBtn MainFormation;

	public GImage arrowDown;

	public GImage n11;

	public const string URL = "ui://u6x0b1gnfdara";

	public static string Name = "UI_MyFormation";

	public string curFid;

	public List<Formation> unlockFormations = new List<Formation>();

	private Action<string> OnChange = delegate
	{
	};

	public static string GetURL()
	{
		return "ui://u6x0b1gnfdara";
	}

	public static UI_MyFormation CreateInstance()
	{
		return (UI_MyFormation)(object)UIPackage.CreateObject("GvGShipDetail", "MyFormation");
	}

	public static UI_MyFormation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyFormation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnfdara", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		background = (GImage)((GComponent)this).GetChild("background");
		Formations = (GList)((GComponent)this).GetChild("Formations");
		MainFormation = (UI_SelectedFormationBtn)(object)((GComponent)this).GetChild("MainFormation");
		arrowDown = (GImage)((GComponent)this).GetChild("arrowDown");
		n11 = (GImage)((GComponent)this).GetChild("n11");
	}

	public void SetOnChange(Action<string> onChange)
	{
		if (onChange != null)
		{
			OnChange = onChange;
		}
	}

	public void ClearOnChange()
	{
		OnChange = delegate
		{
		};
	}

	public void CurFormationInit(string _fid)
	{
		Status.selectedIndex = 0;
		curFid = _fid;
		RenderCurFormation((GComponent)(object)MainFormation, _fid);
	}

	public void Init()
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
		GetAllUnlockFormations(unlockFormations);
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

	private void RenderCurFormation(GComponent _curFormationBtn, string _formationId)
	{
		if (string.IsNullOrEmpty(_formationId))
		{
			((GObject)_curFormationBtn.GetChild("name").asTextField).text = "";
			_curFormationBtn.GetChild("formationIcon").asLoader.url = "";
			return;
		}
		Formation formation = FormationManager.Formations[_formationId];
		((GObject)_curFormationBtn.GetChild("name").asTextField).text = formation.Name;
		_curFormationBtn.GetChild("formationIcon").asLoader.url = "ui://GvGShipDetail/" + formation.Icon;
		((GObject)_curFormationBtn.GetChild("Level").asTextField).text = "1" + LanguagesManager.GetDesc("CsharpCodeZhTcText124");
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

	private void RenderFormation(int index, GObject _btn)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		RenderCurFormation(_btn.asCom, unlockFormations[index].Id);
		_btn.data = unlockFormations[index].Id;
		_btn.onClick.Set(new EventCallback1(SelectArrayFormation));
	}

	private void SelectArrayFormation(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string value = ((GObject)context.sender).data.ToString();
		if (!string.IsNullOrEmpty(value))
		{
			curFid = value;
			OnChange(curFid);
		}
	}
}
