using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;
using UI.GvGBrawlFight;
using UnityEngine;

namespace UI.GvGOnIsland3;

public class UI_main_GvG3Tip : GComponent, IUiController
{
	public Controller Type;

	public UI_com_GVGTip_Damageinfo Damage;

	public UI_com_GVGTip_ArmyInfoReduce SoldierCost;

	public UI_com_GVGTip_ArmyIncrease 机械降神Increase;

	public UI_com_GVGTip_ScoreInfo ScoreInfo;

	public Transition S1;

	public Transition SoldierCostWeak;

	public Transition SoldierCosrStrong;

	public Transition 机械降神IncreaseWeak;

	public Transition 机械降神IncreaseStrong;

	public Transition ScoreInfoShow;

	public const string URL = "ui://ebc4ciwrpwqhq5r";

	public static string Name = "UI_main_GvG3Tip";

	public static string GetURL()
	{
		return "ui://ebc4ciwrpwqhq5r";
	}

	public static UI_main_GvG3Tip CreateInstance()
	{
		return (UI_main_GvG3Tip)(object)UIPackage.CreateObject("GvGOnIsland3", "main_GvG3Tip");
	}

	public static UI_main_GvG3Tip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3Tip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrpwqhq5r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Damage = (UI_com_GVGTip_Damageinfo)(object)((GComponent)this).GetChild("Damage");
		SoldierCost = (UI_com_GVGTip_ArmyInfoReduce)(object)((GComponent)this).GetChild("SoldierCost");
		机械降神Increase = (UI_com_GVGTip_ArmyIncrease)(object)((GComponent)this).GetChild("机械降神Increase");
		ScoreInfo = (UI_com_GVGTip_ScoreInfo)(object)((GComponent)this).GetChild("ScoreInfo");
		S1 = ((GComponent)this).GetTransition("S1");
		SoldierCostWeak = ((GComponent)this).GetTransition("SoldierCostWeak");
		SoldierCosrStrong = ((GComponent)this).GetTransition("SoldierCosrStrong");
		机械降神IncreaseWeak = ((GComponent)this).GetTransition("机械降神IncreaseWeak");
		机械降神IncreaseStrong = ((GComponent)this).GetTransition("机械降神IncreaseStrong");
		ScoreInfoShow = ((GComponent)this).GetTransition("ScoreInfoShow");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		object value;
		string contentText = (parameters.TryGetValue("Content", out value) ? value.ToString() : string.Empty);
		if (parameters.TryGetValue("Pos", out var value2))
		{
			Vector2 val = (Vector2)value2;
			((GObject)this).SetXY(val.x, val.y);
		}
		if (parameters.TryGetValue("Scale", out var value3))
		{
			((GObject)this).scaleX = (float)value3;
			((GObject)this).scaleY = (float)value3;
		}
		if (parameters.TryGetValue("Type", out var value4))
		{
			Type.selectedIndex = (int)value4;
			PlayTransition();
			SetContent();
		}
		else
		{
			End();
		}
		void PlaySoldierCost()
		{
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			object value5;
			int selectedIndex = (parameters.TryGetValue("CostUiType", out value5) ? ((int)value5) : 0);
			SoldierCost.Type.SetSelectedIndex(selectedIndex);
			((GComponent)SoldierCost).EnsureBoundsCorrect();
			if (parameters.TryGetValue("UseStrong", out var value6) && (bool)value6)
			{
				SoldierCosrStrong.Play(new PlayCompleteCallback(End));
			}
			else
			{
				SoldierCostWeak.Play(new PlayCompleteCallback(End));
			}
		}
		void PlayTransition()
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			switch (Type.selectedIndex)
			{
			case 1:
				S1.Play(new PlayCompleteCallback(End));
				break;
			case 2:
				PlaySoldierCost();
				break;
			case 3:
				Play机械降神Increase();
				break;
			case 4:
				ScoreInfoShow.Play(new PlayCompleteCallback(End));
				break;
			default:
				End();
				break;
			}
		}
		void Play机械降神Increase()
		{
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			object value5;
			int selectedIndex = (parameters.TryGetValue("机械降神IncreaseUiType", out value5) ? ((int)value5) : 0);
			机械降神Increase.Type.SetSelectedIndex(selectedIndex);
			((GComponent)机械降神Increase).EnsureBoundsCorrect();
			if (parameters.TryGetValue("UseStrong", out var value6) && (bool)value6)
			{
				机械降神IncreaseStrong.Play(new PlayCompleteCallback(End));
			}
			else
			{
				机械降神IncreaseWeak.Play(new PlayCompleteCallback(End));
			}
		}
		void SetContent()
		{
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			switch (Type.selectedIndex)
			{
			case 1:
				((GObject)Damage.Content).text = contentText;
				break;
			case 2:
				SoldierCost.SetContent(contentText);
				break;
			case 3:
				机械降神Increase.SetContent(contentText);
				break;
			case 4:
			{
				object value5;
				ScoreChangeInfo scoreChangeInfo = (parameters.TryGetValue("ScoreChangeParam", out value5) ? ((ScoreChangeInfo)value5) : null);
				if (scoreChangeInfo != null)
				{
					bool flag = UI_main_BrawlFightEnroll.IsFinalStep(scoreChangeInfo.StepIndex);
					ScoreInfo.ScoreType.SetSelectedIndex(flag ? 1 : 0);
					((GObject)ScoreInfo.Content).text = $"{scoreChangeInfo.ChangedScore:N0}";
					((GObject)ScoreInfo.par).visible = scoreChangeInfo.Par > 0f;
					((GObject)ScoreInfo.par).text = $"x{scoreChangeInfo.Par:N1}";
					ScoreInfo.Type.SetSelectedIndex((scoreChangeInfo.Par > 1.01f) ? 1 : 0);
					((GObject)this).scale = scoreChangeInfo.TipScale * Vector2.one;
				}
				break;
			}
			}
		}
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener("ON_GVG_TIP_CLEAR", End);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener("ON_GVG_TIP_CLEAR", End);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}

	public void End()
	{
		if (!((GObject)this).isDisposed)
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)this, true);
		}
	}
}
