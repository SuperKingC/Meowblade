using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.PvpSelectSoldiers;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion.Common.Services;
using UI.Battle;
using UI.QuickBattle;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PvPBattleResultAnimationEffect : GComponent, IUiController, IAnyTeamHealthPointsTotalListener
{
	public Controller Status;

	public UI_UserBattleInfo OurBattleInfo;

	public UI_EnemyBattleInfo EnemyBattleInfo;

	public GImage n11;

	public GImage n12;

	public UI_EnemyAvatarInfo EnemyAvatarInfo;

	public UI_OurAvatarInfo OurAvatarInfo;

	public GGraph PunchSfxBack;

	public Transition Enlarge;

	public Transition Win;

	public Transition SlideOut;

	public const string URL = "ui://82mo10n5jh34dbb";

	public static string Name = "UI_PvPBattleResultAnimationEffect";

	public static Coroutine PvPBattleResultAnimationCoroutine;

	public static UI_PvPBattleResultAnimationEffect PvPBattleResultAnimationEffectPanel;

	private static Vector2 redKingToHitPos;

	private static Vector2 blueKingToHitPos;

	private KingHealthPointsTotalRecord KingsHealth;

	private Action EndOfEffectCallback;

	private GameStateEntity _gameStateEntity;

	private int pvp_Index;

	private bool needExtend;

	private List<string> skeletonList = new List<string>();

	private const double MaxHpValue = 10000.0;

	private const double HpUpdateAccuracy = 50.0;

	private const float HpUpdateInterval = 0.02f;

	private const float BallSpawnDelay = 0.2f;

	private const float BallFlightDuration = 1.2f;

	private const float HealthAniMaxDuration = 2.5f;

	private Dictionary<string, object> _parameters;

	public static string GetURL()
	{
		return "ui://82mo10n5jh34dbb";
	}

	public static UI_PvPBattleResultAnimationEffect CreateInstance()
	{
		return (UI_PvPBattleResultAnimationEffect)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvPBattleResultAnimationEffect");
	}

	public static UI_PvPBattleResultAnimationEffect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvPBattleResultAnimationEffect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5jh34dbb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		OurBattleInfo = (UI_UserBattleInfo)(object)((GComponent)this).GetChild("OurBattleInfo");
		EnemyBattleInfo = (UI_EnemyBattleInfo)(object)((GComponent)this).GetChild("EnemyBattleInfo");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		EnemyAvatarInfo = (UI_EnemyAvatarInfo)(object)((GComponent)this).GetChild("EnemyAvatarInfo");
		OurAvatarInfo = (UI_OurAvatarInfo)(object)((GComponent)this).GetChild("OurAvatarInfo");
		PunchSfxBack = (GGraph)((GComponent)this).GetChild("PunchSfxBack");
		Enlarge = ((GComponent)this).GetTransition("Enlarge");
		Win = ((GComponent)this).GetTransition("Win");
		SlideOut = ((GComponent)this).GetTransition("SlideOut");
	}

	public void BeforeDestroy()
	{
		PvPBattleResultAnimationEffectPanel = null;
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		PvPBattleResultAnimationEffectPanel = this;
		if (parameters != null && parameters.TryGetValue("isQuickBattle", out var value) && (bool)value)
		{
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
			needExtend = false;
		}
		else
		{
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
			needExtend = true;
		}
		redKingToHitPos = new Vector2(((GObject)this).width - 210f, 80f);
		blueKingToHitPos = new Vector2(210f, 80f);
	}

	public void OnShow()
	{
		SetBattleUiUserInfo();
		SetCurLevelEnemyIcon();
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<Dictionary<string, object>>("ON_PVP_RESULT_ANIM", StartPvpResltEffect);
		SharedMessenger.AddListener<Dictionary<string, object>>("ON_PVP_QUICK_BATTLE_TEAMHEALTH_CHANGE", OnAnyTeamHealthPointsTotalQuickBattle);
		SharedMessenger.AddListener<int>("ON_PVP_QUICK_BATTLE_WAVE_START_CHANGE_LEGION_INDEX", ResetLegionHp);
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyTeamHealthPointsTotalListener(this);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<Dictionary<string, object>>("ON_PVP_RESULT_ANIM", StartPvpResltEffect);
		SharedMessenger.RemoveListener<Dictionary<string, object>>("ON_PVP_QUICK_BATTLE_TEAMHEALTH_CHANGE", OnAnyTeamHealthPointsTotalQuickBattle);
		SharedMessenger.RemoveListener<int>("ON_PVP_QUICK_BATTLE_WAVE_START_CHANGE_LEGION_INDEX", ResetLegionHp);
		_gameStateEntity.RemoveAnyTeamHealthPointsTotalListener(this);
	}

	private void StartPvpResltEffect(Dictionary<string, object> parameters)
	{
		ref KingHealthPointsTotalRecord kingsHealth = ref KingsHealth;
		object obj = parameters["kingsHealth"];
		kingsHealth = (KingHealthPointsTotalRecord)((obj is KingHealthPointsTotalRecord) ? obj : null);
		if (KingsHealth.RedCurrent < 0)
		{
			KingsHealth.RedCurrent = 0;
		}
		if (KingsHealth.BlueCurrent < 0)
		{
			KingsHealth.BlueCurrent = 0;
		}
		EndOfEffectCallback = parameters["onFinished"] as Action;
		pvp_Index = (int)parameters["PvP_Idx"];
		List<Vector2> redAttackerSpawnPos = null;
		List<Vector2> blueAttackerSpawnPos = null;
		if (parameters.TryGetValue("redAttackerSpawnPos", out var value))
		{
			redAttackerSpawnPos = value as List<Vector2>;
		}
		if (parameters.TryGetValue("blueAttackerSpawnPos", out var value2))
		{
			blueAttackerSpawnPos = value2 as List<Vector2>;
		}
		PlayBallSpawnAnimation(redAttackerSpawnPos, blueAttackerSpawnPos);
	}

	private void PlayBallSpawnAnimation(List<Vector2> redAttackerSpawnPos, List<Vector2> blueAttackerSpawnPos)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		List<LightBall_Fusion> fusions = new List<LightBall_Fusion>();
		List<LightBall> list = new List<LightBall>();
		if (redAttackerSpawnPos != null)
		{
			foreach (Vector2 redAttackerSpawnPo in redAttackerSpawnPos)
			{
				LightBall lightBall = new LightBall(redAttackerSpawnPo, 100f);
				((GComponent)this).AddChild((GObject)(object)lightBall.Container);
				list.Add(lightBall);
				LightBall_Fusion item = new LightBall_Fusion(redAttackerSpawnPo, 100f);
				fusions.Add(item);
			}
		}
		List<LightBall> list2 = new List<LightBall>();
		if (blueAttackerSpawnPos != null)
		{
			foreach (Vector2 blueAttackerSpawnPo in blueAttackerSpawnPos)
			{
				LightBall lightBall2 = new LightBall(blueAttackerSpawnPo, 100f);
				((GComponent)this).AddChild((GObject)(object)lightBall2.Container);
				list2.Add(lightBall2);
				LightBall_Fusion item2 = new LightBall_Fusion(blueAttackerSpawnPo, 100f);
				fusions.Add(item2);
			}
		}
		PlayBallAttackAnimation(list, list2);
		EffectHelper.CoroutineDelay(0.2f, delegate
		{
			foreach (LightBall_Fusion item3 in fusions)
			{
				((GComponent)this).AddChild((GObject)(object)item3.Container);
			}
			EffectHelper.CoroutineDelay(1f, delegate
			{
				foreach (LightBall_Fusion item4 in fusions)
				{
					item4.Destroy();
				}
				fusions.Clear();
			});
		});
	}

	private void PlayBallAttackAnimation(List<LightBall> redAttackers, List<LightBall> blueAttackers)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		Vector2[] redAttackersDisp = (Vector2[])(object)new Vector2[redAttackers.Count];
		for (int i = 0; i < redAttackersDisp.Length; i++)
		{
			redAttackersDisp[i] = ((GObject)redAttackers[i].Container).xy - redKingToHitPos;
		}
		Vector2[] blueAttackersDisp = (Vector2[])(object)new Vector2[blueAttackers.Count];
		for (int j = 0; j < blueAttackersDisp.Length; j++)
		{
			blueAttackersDisp[j] = ((GObject)blueAttackers[j].Container).xy - blueKingToHitPos;
		}
		GTweenCallback val = default(GTweenCallback);
		GTweenCallback val4 = default(GTweenCallback);
		EffectHelper.PlayCoroutineEffect(1.2f, delegate(float effectTime, float totalEffectTime)
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			if (!((GObject)this).isDisposed)
			{
				float num = effectTime / totalEffectTime;
				num = 1f - (float)Math.Pow(num, 6.0);
				for (int k = 0; k < redAttackers.Count; k++)
				{
					redAttackers[k].Scale = num * 0.6f + 0.4f;
					redAttackers[k].Position = redAttackersDisp[k] * num + redKingToHitPos;
				}
				for (int l = 0; l < blueAttackers.Count; l++)
				{
					blueAttackers[l].Scale = num * 0.6f + 0.4f;
					blueAttackers[l].Position = blueAttackersDisp[l] * num + blueKingToHitPos;
				}
			}
		}, delegate
		{
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Expected O, but got Unknown
			//IL_027c: Expected O, but got Unknown
			if (!((GObject)this).isDisposed)
			{
				double num = 10000f * (float)KingsHealth.RedCurrent / (float)KingsHealth.RedTotal;
				double num2 = 10000f * (float)KingsHealth.BlueCurrent / (float)KingsHealth.BlueTotal;
				bool flag = false;
				if (Math.Abs(((GProgressBar)OurBattleInfo.UserHp).value - num) > 1.401298464324817E-45)
				{
					flag = true;
					FGUIManager.Instance.AddTextSpecialEffects(OurBattleInfo.SfxBack, "ui_explosion_player_avatar_hit", new Vector3(150f, 150f, 150f));
					PlayHitKingAnimation((GComponent)(object)OurBattleInfo, (GProgressBar)(object)OurBattleInfo.UserHp, num, redAttackers);
				}
				else
				{
					foreach (LightBall redAttacker in redAttackers)
					{
						redAttacker.Destroy();
					}
					redAttackers.Clear();
				}
				if (Math.Abs(((GProgressBar)EnemyBattleInfo.UserHp).value - num2) > 1.401298464324817E-45)
				{
					flag = true;
					FGUIManager.Instance.AddTextSpecialEffects(EnemyBattleInfo.SfxBack, "ui_explosion_player_avatar_hit", new Vector3(150f, 150f, 150f));
					PlayHitKingAnimation((GComponent)(object)EnemyBattleInfo, (GProgressBar)(object)EnemyBattleInfo.UserHp, num2, blueAttackers);
				}
				else
				{
					foreach (LightBall blueAttacker in blueAttackers)
					{
						blueAttacker.Destroy();
					}
					blueAttackers.Clear();
				}
				GTweener obj = ((GComponent)(object)this).SetTimeout(flag ? 0.7f : 0.2f);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						//IL_0076: Unknown result type (might be due to invalid IL or missing references)
						//IL_007b: Unknown result type (might be due to invalid IL or missing references)
						//IL_007d: Expected O, but got Unknown
						//IL_0082: Expected O, but got Unknown
						if (pvp_Index < RankDataHelper.info.NeedLegionSize - 1 && KingsHealth.RedCurrent > 0 && KingsHealth.BlueCurrent > 0)
						{
							SharedMessenger.Broadcast("ON_PVP_PLAY_WAVE_START_TRANSITION");
						}
						GTweener obj3 = ((GComponent)(object)this).SetTimeout(1f);
						GTweenCallback obj4 = val4;
						if (obj4 == null)
						{
							GTweenCallback val5 = delegate
							{
								EndOfEffectCallback?.Invoke();
							};
							GTweenCallback val6 = val5;
							val4 = val5;
							obj4 = val6;
						}
						obj3.OnComplete(obj4);
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				obj.OnComplete(obj2);
			}
		});
	}

	private void PlayHitKingAnimation(GComponent hpBar, GProgressBar progressBar, double targetHpValue, List<LightBall> balls)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		Vector3 defaultPos = ((GObject)hpBar).position;
		double lastHpValue = progressBar.value;
		double delta = targetHpValue - lastHpValue;
		float totalEffecTime = 0.5f;
		EffectHelper.PlayCoroutineEffect(totalEffecTime, delegate(float effectTime, float num2)
		{
			float num = effectTime / num2;
			float num3 = 1f - num;
			float num4 = 6f * (float)Math.Sin(num * 150f);
			if (progressBar.value != targetHpValue)
			{
				((GObject)hpBar).SetXY(num4 + defaultPos.x, num4 + defaultPos.y);
				progressBar.value = delta * (double)num + lastHpValue;
				if (progressBar.value < 2.0 && targetHpValue > 0.0)
				{
					progressBar.value = 2.0;
				}
			}
			foreach (LightBall ball in balls)
			{
				ball.Scale = num3 * 0.4f;
			}
		}, delegate
		{
			((GObject)hpBar).SetXY(defaultPos.x, defaultPos.y);
			foreach (LightBall ball2 in balls)
			{
				ball2.Destroy();
			}
			balls.Clear();
		}, 0f, 0.2f);
	}

	private void SetCurLevelEnemyIcon()
	{
		if (UI_Battle.pvpEnemyInfo != null)
		{
			if (UI_Battle.pvpEnemyInfo.IsUser)
			{
				int userId = UI_Battle.pvpEnemyInfo.UserId;
				EnemyBattleInfo.Avatar.HeadPortrait.Type.selectedIndex = 0;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, EnemyBattleInfo.Avatar.HeadPortrait.icon, EnemyBattleInfo.ArmyGroupName, 14, is_big: true));
				FGUIManager.Instance.GetUserMedal(userId, EnemyBattleInfo.EnemyMedalList);
				EnemyAvatarInfo.Avatar.HeadPortrait.Type.selectedIndex = 0;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, EnemyAvatarInfo.Avatar.HeadPortrait.icon, EnemyAvatarInfo.UserName, 14, is_big: true));
				FGUIManager.Instance.GetUserMedal(userId, EnemyAvatarInfo.EnemyMedalList);
			}
			else
			{
				EnemyBattleInfo.Avatar.HeadPortrait.Type.selectedIndex = 1;
				EnemyAvatarInfo.Avatar.HeadPortrait.Type.selectedIndex = 1;
				EnemyBattleInfo.Avatar.HeadPortrait.icon.url = UI_Battle.pvpEnemyInfo.NpcUrl;
				((GObject)EnemyBattleInfo.ArmyGroupName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText51");
				EnemyAvatarInfo.Avatar.HeadPortrait.icon.url = UI_Battle.pvpEnemyInfo.NpcUrl;
				((GObject)EnemyAvatarInfo.UserName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText51");
			}
		}
		((GProgressBar)EnemyBattleInfo.LegionHp).value = 10000.0;
		((GProgressBar)EnemyBattleInfo.UserHp).value = 10000.0;
		((GProgressBar)EnemyAvatarInfo.Hp).value = 10000.0;
	}

	private void SetBattleUiUserInfo()
	{
		if (UI_Battle.pvpRedInfo != null)
		{
			if (UI_Battle.pvpRedInfo.IsUser)
			{
				int userId = UI_Battle.pvpRedInfo.UserId;
				OurBattleInfo.Avatar.HeadPortrait.Type.selectedIndex = 0;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, OurBattleInfo.Avatar.HeadPortrait.icon, OurBattleInfo.ArmyGroupName, 14, is_big: true));
				FGUIManager.Instance.GetUserMedal(userId, OurBattleInfo.OurMedalList);
				OurAvatarInfo.Avatar.HeadPortrait.Type.selectedIndex = 0;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, OurAvatarInfo.Avatar.HeadPortrait.icon, OurAvatarInfo.UserName, 14, is_big: true));
				FGUIManager.Instance.GetUserMedal(userId, OurAvatarInfo.OurMedalList);
			}
			else
			{
				OurBattleInfo.Avatar.HeadPortrait.Type.selectedIndex = 1;
				OurAvatarInfo.Avatar.HeadPortrait.Type.selectedIndex = 1;
				OurBattleInfo.Avatar.HeadPortrait.icon.url = "ui://PublicResources/Boss3";
				((GObject)OurBattleInfo.ArmyGroupName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText395");
				OurAvatarInfo.Avatar.HeadPortrait.icon.url = "ui://PublicResources/Boss3";
				((GObject)OurAvatarInfo.UserName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText395");
			}
		}
		((GProgressBar)OurBattleInfo.LegionHp).value = 10000.0;
		((GProgressBar)OurBattleInfo.UserHp).value = 10000.0;
		((GProgressBar)OurAvatarInfo.Hp).value = 10000.0;
	}

	private void SetRankUiType()
	{
		((GObject)OurBattleInfo).visible = true;
		((GObject)EnemyBattleInfo).visible = true;
	}

	public IEnumerator PlayEndEffect(Dictionary<string, object> parameters)
	{
		if (parameters == null || !parameters.TryGetValue("Winner", out var _value))
		{
			yield break;
		}
		if (UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel != null)
		{
			((GObject)UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel.QuickBattleStage).alpha = 0f;
			((GObject)UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel.QuickBattleBackground).visible = true;
			((GObject)UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel.gradientEdges).visible = false;
		}
		if (UI_QuickBattlePanel.QuickBattlePanel != null)
		{
			((GObject)UI_QuickBattlePanel.QuickBattlePanel).alpha = 0f;
		}
		int _result = (int)_value;
		_parameters = parameters;
		((GProgressBar)OurAvatarInfo.Hp).value = ((GProgressBar)OurBattleInfo.UserHp).value;
		((GProgressBar)EnemyAvatarInfo.Hp).value = ((GProgressBar)EnemyBattleInfo.UserHp).value;
		((GObject)OurAvatarInfo.Hp.Health).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint((((GProgressBar)OurAvatarInfo.Hp).value / 100.0).ToString("N1")) + "%";
		((GObject)EnemyAvatarInfo.Hp.Health).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint((((GProgressBar)EnemyAvatarInfo.Hp).value / 100.0).ToString("N1")) + "%";
		MoveAvatarInfoFrame();
		Enlarge.Play();
		GTweenCallback val = default(GTweenCallback);
		GTweenCallback val4 = default(GTweenCallback);
		GTweenCallback val6 = default(GTweenCallback);
		((GComponent)(object)this).SetTimeout(2.1667f).OnComplete((GTweenCallback)delegate
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Expected O, but got Unknown
			//IL_017b: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Expected O, but got Unknown
			//IL_00ec: Expected O, but got Unknown
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Expected O, but got Unknown
			//IL_01b0: Expected O, but got Unknown
			FGUIManager.Instance.AddTextSpecialEffects(PunchSfxBack, "ui_explosion_pvp_player_punch", new Vector3(150f, 150f, 150f), "UI", 0.5f, delegate(GameObject punchSfx)
			{
				UiHelper.DestoryUiSfx(PunchSfxBack, punchSfx, 0.75f);
			});
			if (_result == 100)
			{
				OurAvatarInfo.Status.selectedIndex = 1;
				UiHelper.SpineLoad(OurAvatarInfo.BreakSpineBack, "ui_pvp_player_break", 200f, "skin2", "break", skeletonList, isMask: false, aniLoop: false, -1f);
				GTweener obj = ((GComponent)(object)this).SetTimeout(1.5f);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						((GObject)OurAvatarInfo.BreakSpineBack).visible = false;
						EnemyAvatarInfo.Status.selectedIndex = 1;
						OpenBattleEndPanel(_result);
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				obj.OnComplete(obj2);
			}
			else
			{
				EnemyAvatarInfo.Status.selectedIndex = 1;
				UiHelper.SpineLoad(EnemyAvatarInfo.BreakSpineBack, "ui_pvp_player_break", 200f, "skin1", "break", skeletonList, isMask: false, aniLoop: false);
				GTweener obj3 = ((GComponent)(object)this).SetTimeout(0.5f);
				GTweenCallback obj4 = val4;
				if (obj4 == null)
				{
					GTweenCallback val5 = delegate
					{
						((GObject)EnemyAvatarInfo.BreakSpineBack).visible = false;
						MoveOurAvatarInfoWin();
						OpenBattleEndPanel(_result);
					};
					GTweenCallback val3 = val5;
					val4 = val5;
					obj4 = val3;
				}
				obj3.OnComplete(obj4);
				GTweener obj5 = ((GComponent)(object)this).SetTimeout(1f);
				GTweenCallback obj6 = val6;
				if (obj6 == null)
				{
					GTweenCallback val7 = delegate
					{
						//IL_0025: Unknown result type (might be due to invalid IL or missing references)
						FGUIManager.Instance.AddTextSpecialEffects(PunchSfxBack, "ui_explosion_playercard_victory", new Vector3(150f, 150f, 150f), "UI", 0.5f, delegate(GameObject victorySfx)
						{
							UiHelper.DestoryUiSfx(PunchSfxBack, victorySfx, 1f);
						});
						OurAvatarInfo.Status.selectedIndex = 2;
					};
					GTweenCallback val3 = val7;
					val6 = val7;
					obj6 = val3;
				}
				obj5.OnComplete(obj6);
			}
		});
		if (KingsHealth == null)
		{
			yield break;
		}
		if (KingsHealth.RedCurrent < 0)
		{
			KingsHealth.RedCurrent = 0;
		}
		if (KingsHealth.BlueCurrent < 0)
		{
			KingsHealth.BlueCurrent = 0;
		}
		double ourTargetHp = 10000f * (float)KingsHealth.RedCurrent / (float)KingsHealth.RedTotal;
		double enemyTargetHp = 10000f * (float)KingsHealth.BlueCurrent / (float)KingsHealth.BlueTotal;
		double minHp = Math.Min(ourTargetHp, enemyTargetHp);
		ourTargetHp -= minHp;
		enemyTargetHp -= minHp;
		yield return PlayChangePageEffect();
		yield return (object)new WaitForSeconds(2.1667f);
		float multiple = 10f;
		while (((GProgressBar)OurAvatarInfo.Hp).value != ourTargetHp || ((GProgressBar)EnemyAvatarInfo.Hp).value != enemyTargetHp)
		{
			if (_result == 100)
			{
				double enemyHp = ((((GProgressBar)EnemyAvatarInfo.Hp).value > enemyTargetHp) ? (((GProgressBar)EnemyAvatarInfo.Hp).value - 50.0 * (double)multiple) : enemyTargetHp);
				if (enemyHp < 0.0)
				{
					enemyHp = 0.0;
				}
				if (enemyHp > 10000.0)
				{
					enemyHp = 10000.0;
				}
				((GProgressBar)EnemyAvatarInfo.Hp).value = enemyHp;
				if (((GProgressBar)EnemyAvatarInfo.Hp).value < 0.0)
				{
					((GProgressBar)EnemyAvatarInfo.Hp).value = 0.0;
				}
				if (((GProgressBar)EnemyAvatarInfo.Hp).value > 10000.0)
				{
					((GProgressBar)EnemyAvatarInfo.Hp).value = 10000.0;
				}
				((GObject)EnemyAvatarInfo.Hp.Health).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint((enemyHp / 100.0).ToString("N1")) + "%";
			}
			else
			{
				double ourHp = ((((GProgressBar)OurAvatarInfo.Hp).value > ourTargetHp) ? (((GProgressBar)OurAvatarInfo.Hp).value - 50.0 * (double)multiple) : ourTargetHp);
				if (ourHp < 0.0)
				{
					ourHp = 0.0;
				}
				if (ourHp > 10000.0)
				{
					ourHp = 10000.0;
				}
				((GProgressBar)OurAvatarInfo.Hp).value = ourHp;
				if (((GProgressBar)OurAvatarInfo.Hp).value < 0.0)
				{
					((GProgressBar)OurAvatarInfo.Hp).value = 0.0;
				}
				if (((GProgressBar)OurAvatarInfo.Hp).value > 10000.0)
				{
					((GProgressBar)OurAvatarInfo.Hp).value = 10000.0;
				}
				((GObject)OurAvatarInfo.Hp.Health).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint((ourHp / 100.0).ToString("N1")) + "%";
			}
			yield return (object)new WaitForSeconds(0.02f);
		}
	}

	private void MoveOurAvatarInfoWin()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		float num = ((UnityUiService.AspectRatio > 1f && needExtend) ? UnityUiService.AspectRatio : 1f);
		((GObject)OurAvatarInfo).TweenMove(new Vector2(960f * num, 469f), 0.4167f);
	}

	private void MoveAvatarInfoFrame()
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		((GObject)OurAvatarInfo).SetPivot(0.5f, 0.5f, true);
		((GObject)EnemyAvatarInfo).SetPivot(0.5f, 0.5f, true);
		float xRatio = ((UnityUiService.AspectRatio > 1f && needExtend) ? UnityUiService.AspectRatio : 1f);
		((GObject)OurAvatarInfo).SetXY(210f * xRatio, 80f);
		((GObject)EnemyAvatarInfo).SetXY(1710f * xRatio, 80f);
		((GObject)OurAvatarInfo).TweenMove(new Vector2(537f * xRatio, 540f), 0.5f);
		((GObject)EnemyAvatarInfo).TweenMove(new Vector2(1383f * xRatio, 540f), 0.5f);
		((GComponent)(object)this).SetTimeout(1.5f).OnComplete((GTweenCallback)delegate
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			((GObject)OurAvatarInfo).TweenMove(new Vector2(237f * xRatio, 540f), 0.5f);
			((GObject)EnemyAvatarInfo).TweenMove(new Vector2(1683f * xRatio, 540f), 0.5f);
		});
		((GComponent)(object)this).SetTimeout(2f).OnComplete((GTweenCallback)delegate
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			((GObject)OurAvatarInfo).TweenMove(new Vector2(877f * xRatio, 540f), 0.1667f).SetEase((EaseType)20);
			((GObject)EnemyAvatarInfo).TweenMove(new Vector2(1043f * xRatio, 540f), 0.1667f).SetEase((EaseType)20);
		});
	}

	private IEnumerator PlayChangePageEffect()
	{
		Status.selectedIndex = 1;
		yield return (object)new WaitForSeconds(0.333f);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OpenBattleEndPanel(int _result)
	{
		if (!needExtend)
		{
			_parameters.Add("isQuickBattle", true);
		}
		switch (_result)
		{
		case 100:
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleFail.Name, _parameters);
			break;
		case 200:
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleVictory.Name, _parameters);
			break;
		}
		for (int i = 0; i < skeletonList.Count; i++)
		{
			SpawnManager.Instance.UnloadAnimation(skeletonList[i]);
		}
	}

	private void ResetLegionHp(int _index)
	{
		((GProgressBar)OurBattleInfo.LegionHp).value = 10000.0;
		((GProgressBar)EnemyBattleInfo.LegionHp).value = 10000.0;
	}

	public void OnAnyTeamHealthPointsTotal(GameStateEntity entity, float redCurrent, float redTotal, float blueCurrent, float blueTotal)
	{
		OnAnyTeamHealthPointsTotal(redCurrent, redTotal, blueCurrent, blueTotal);
	}

	private void OnAnyTeamHealthPointsTotalQuickBattle(Dictionary<string, object> parameters)
	{
		List<float> list = parameters["HealthData"] as List<float>;
		if (list.Count >= 4)
		{
			float redCurrent = list[0];
			float redTotal = list[1];
			float blueCurrent = list[2];
			float blueTotal = list[3];
			OnAnyTeamHealthPointsTotal(redCurrent, redTotal, blueCurrent, blueTotal);
		}
	}

	private void OnAnyTeamHealthPointsTotal(float redCurrent, float redTotal, float blueCurrent, float blueTotal)
	{
		float num = ((redTotal > 0f) ? (redCurrent / redTotal * 100f) : 0f);
		float num2 = ((blueTotal > 0f) ? (blueCurrent / blueTotal * 100f) : 0f);
		((GProgressBar)OurBattleInfo.LegionHp).TweenValue((double)num, 0.1f);
		((GProgressBar)EnemyBattleInfo.LegionHp).TweenValue((double)num2, 0.1f);
		FGUIManager.Instance.BothHealthBarValues["RedHealthBarValue"] = num;
		FGUIManager.Instance.BothHealthBarValues["BlueHealthBarValue"] = num2;
		((GObject)OurBattleInfo.LegionHp.bar).visible = !(((GProgressBar)OurBattleInfo.LegionHp).value <= 0.0);
		((GObject)EnemyBattleInfo.LegionHp.bar).visible = !(((GProgressBar)EnemyBattleInfo.LegionHp).value <= 0.0);
	}
}
