using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Tips;

public class UI_RaceInfoPanel : GComponent, IUiController
{
	public Controller Type;

	public GGraph Mask;

	public UI_RaceDialog DialogFoo;

	public UI_RaceSimplificationDialog DialogBar;

	public Transition ShowDialog;

	public Transition ShowDialog1;

	public const string URL = "ui://47lbpgx9o21u4o";

	public static string Name = "UI_RaceInfoPanel";

	private List<string> soldierList = new List<string>();

	private readonly List<string> textureList = new List<string>();

	public static string GetURL()
	{
		return "ui://47lbpgx9o21u4o";
	}

	public static UI_RaceInfoPanel CreateInstance()
	{
		return (UI_RaceInfoPanel)(object)UIPackage.CreateObject("Tips", "RaceInfoPanel");
	}

	public static UI_RaceInfoPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RaceInfoPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9o21u4o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		DialogFoo = (UI_RaceDialog)(object)((GComponent)this).GetChild("DialogFoo");
		DialogBar = (UI_RaceSimplificationDialog)(object)((GComponent)this).GetChild("DialogBar");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
		ShowDialog1 = ((GComponent)this).GetTransition("ShowDialog1");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = (parameters.TryGetValue("Order", out var value) ? ((int)value) : 200);
		Type.selectedIndex = (parameters.TryGetValue("Type", out var value2) ? ((int)value2) : 0);
		object value3;
		string race = (parameters.TryGetValue("Race", out value3) ? ((string)value3) : LanguagesManager.GetDesc("CsharpCodeZhTcText173"));
		soldierList = (parameters.TryGetValue("List", out var value4) ? ((List<string>)value4) : new List<string>());
		if (Type.selectedIndex == 0)
		{
			DialogFoo.Status.selectedIndex = FGUIManager.Instance.GetRaceIcon(race);
			((GComponent)DialogFoo.racePicture).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(race);
			RenderSoldierList();
		}
		else if (Type.selectedIndex == 1)
		{
			DialogBar.Status.selectedIndex = FGUIManager.Instance.GetRaceIcon(race);
			((GComponent)DialogBar.racePicture).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(race);
		}
		else if (Type.selectedIndex == 2)
		{
			DialogFoo.Status.selectedIndex = FGUIManager.Instance.GetRaceIcon(race);
			((GComponent)DialogFoo.racePicture).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(race);
			RenderSoldierList();
		}
		DialogFoo.SetControllerPageText();
	}

	public void OnShow()
	{
		if (Type.selectedIndex == 0)
		{
			ShowDialog.Play();
		}
		else if (Type.selectedIndex == 1)
		{
			ShowDialog1.Play();
		}
		else if (Type.selectedIndex == 2)
		{
			ShowDialog.Play();
		}
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

	private void RenderSoldierList()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		if (DialogFoo.Status.selectedIndex != 5)
		{
			DialogFoo.soldierList.itemRenderer = new ListItemRenderer(SoldierRender);
			DialogFoo.soldierList.numItems = soldierList.Count;
			DialogFoo.soldierList.ResizeToFit(soldierList.Count);
		}
	}

	private void SoldierRender(int index, GObject obj)
	{
		Soldier curSoldier = GameManagers.Instance.SoldierManager.Get(soldierList[index]);
		RenderSoldierIconBtn(obj, curSoldier);
	}

	public static void RenderSoldierIconBtn(GObject obj, Soldier curSoldier)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		GButton asButton = obj.asButton;
		((GComponent)asButton).GetChild("name").text = curSoldier.Name ?? "";
		((GComponent)asButton).GetChild("name").asTextField.color = Color32.op_Implicit(UiHelper.GetColorByLevel(curSoldier.PotentialLevel));
		GButton asButton2 = ((GComponent)asButton).GetChild("icon").asButton;
		((GComponent)asButton2).GetChild("removeBack").visible = false;
		((GComponent)asButton2).GetChild("lvFrame").visible = false;
		((GComponent)asButton2).GetChild("assemblyNote").visible = false;
		((GComponent)asButton2).GetChild("numNote").visible = false;
		((GComponent)asButton2).GetChild("NumBack").visible = false;
		((GComponent)asButton2).GetChild("removeNote").visible = false;
		((GComponent)asButton2).GetChild("lv").visible = false;
		((GComponent)asButton2).GetChild("num").visible = false;
		((GComponent)asButton2).GetChild("title").visible = false;
		((GComponent)asButton2).GetChild("title_Max").visible = false;
		((GComponent)asButton2).GetChild("removeText").visible = false;
		((GComponent)asButton2).GetChild("racePicture").visible = false;
		((GComponent)asButton2).GetChild("occupation").visible = false;
		((GComponent)asButton2).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(curSoldier.Id);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(curSoldier.PotentialLevel);
		((GComponent)asButton2).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(((GComponent)asButton2).GetChild("iconFrame").asLoader, curSoldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton2).GetChild("SoulStoneLevel").asCom, curSoldier.PotentialLevel, curSoldier.PotentialProgress);
		if (GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true).Keys.Contains(curSoldier.Id))
		{
			((GObject)asButton).grayed = false;
		}
		else
		{
			((GObject)asButton).grayed = true;
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}
}
