using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UI.Battle;

namespace UI.PvpSelectSoldiers;

public class UI_StartRankBattleCountdown : GComponent, IUiController, IAnyNextLevelComingListener
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static PlayCompleteCallback _003C_003E9__26_1;

		internal void _003CStartBattle_003Eb__26_1()
		{
			SharedMessenger.Broadcast("SET_RANK_UI_MODE");
			if (UI_Battle.BattlePanel != null)
			{
				((GObject)UI_Battle.BattlePanel).alpha = 1f;
			}
		}
	}

	public GGraph BlackGround;

	public UI_CountdownBtn Time;

	public GImage n125;

	public GImage n126;

	public GImage n127;

	public GImage n128;

	public GImage n129;

	public Transition Rotate;

	public Transition Drop;

	public Transition ShowRewardAndChoose;

	public Transition CountDown;

	public Transition SecondWaveStart;

	public Transition ThirdWaveStart;

	public const string URL = "ui://82mo10n5qxbi7n";

	public static string Name = "UI_StartRankBattleCountdown";

	private string battleid;

	private bool isQuickBattle;

	private GameStateEntity _gameStateEntity;

	private List<Transition> battleWaveStarTransitions = new List<Transition>();

	private int waveIndex;

	public static string GetURL()
	{
		return "ui://82mo10n5qxbi7n";
	}

	public static UI_StartRankBattleCountdown CreateInstance()
	{
		return (UI_StartRankBattleCountdown)(object)UIPackage.CreateObject("PvpSelectSoldiers", "StartRankBattleCountdown");
	}

	public static UI_StartRankBattleCountdown CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StartRankBattleCountdown).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5qxbi7n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BlackGround = (GGraph)((GComponent)this).GetChild("BlackGround");
		Time = (UI_CountdownBtn)(object)((GComponent)this).GetChild("Time");
		n125 = (GImage)((GComponent)this).GetChild("n125");
		n126 = (GImage)((GComponent)this).GetChild("n126");
		n127 = (GImage)((GComponent)this).GetChild("n127");
		n128 = (GImage)((GComponent)this).GetChild("n128");
		n129 = (GImage)((GComponent)this).GetChild("n129");
		Rotate = ((GComponent)this).GetTransition("Rotate");
		Drop = ((GComponent)this).GetTransition("Drop");
		ShowRewardAndChoose = ((GComponent)this).GetTransition("ShowRewardAndChoose");
		CountDown = ((GComponent)this).GetTransition("CountDown");
		SecondWaveStart = ((GComponent)this).GetTransition("SecondWaveStart");
		ThirdWaveStart = ((GComponent)this).GetTransition("ThirdWaveStart");
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
		if (parameters.TryGetValue("BattleId", out var value))
		{
			battleid = value.ToString();
		}
		if (parameters.TryGetValue("isQuickBattle", out var value2) && (bool)value2)
		{
			isQuickBattle = true;
		}
		battleWaveStarTransitions.Add(SecondWaveStart);
		battleWaveStarTransitions.Add(ThirdWaveStart);
		StartBattle();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyNextLevelComingListener(this);
		SharedMessenger.AddListener("ON_PVP_PLAY_WAVE_START_TRANSITION", StartPvpResltEffect);
	}

	public void UnregisterUiEventListeners()
	{
		_gameStateEntity.RemoveAnyNextLevelComingListener(this);
		SharedMessenger.RemoveListener("ON_PVP_PLAY_WAVE_START_TRANSITION", StartPvpResltEffect);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void StartBattle()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		if (isQuickBattle)
		{
			return;
		}
		ClientBattleFieldLogic.StartBattle(GameController.Contexts, battleid);
		((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			Transition countDown = CountDown;
			object obj = _003C_003Ec._003C_003E9__26_1;
			if (obj == null)
			{
				PlayCompleteCallback val = delegate
				{
					SharedMessenger.Broadcast("SET_RANK_UI_MODE");
					if (UI_Battle.BattlePanel != null)
					{
						((GObject)UI_Battle.BattlePanel).alpha = 1f;
					}
				};
				_003C_003Ec._003C_003E9__26_1 = val;
				obj = (object)val;
			}
			countDown.Play((PlayCompleteCallback)obj);
		});
	}

	public void OnAnyNextLevelComing(GameStateEntity entity)
	{
	}

	private void StartPvpResltEffect()
	{
		List<Transition> list = battleWaveStarTransitions;
		if (list != null)
		{
			list[waveIndex].Play();
		}
		waveIndex++;
	}
}
