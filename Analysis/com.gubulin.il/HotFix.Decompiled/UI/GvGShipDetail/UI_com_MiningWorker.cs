using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Spine;
using Spine.Unity;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGShipDetail;

public class UI_com_MiningWorker : GComponent
{
	public enum AnimState
	{
		idle,
		run,
		carry,
		mining_2,
		sleep
	}

	public Controller State;

	public GGraph SpineLoader;

	public GProgressBar ProgressBar;

	public GLoader ProductIcon;

	public GButton n168;

	public GTextField RemainingTime;

	public const string URL = "ui://u6x0b1gnnomv74";

	public static string Name = "UI_com_MiningWorker";

	private int Index;

	private Vector2 WorkbenchPos;

	private CoroutineQueue AnimCoroutineQueue;

	private Transform SpineTrans;

	private SkeletonAnimation Animation;

	private List<Vector2> FixedRoute;

	private List<List<Vector2>> RandomRoutes;

	private AnimState CurState;

	private int CurAnimDir;

	private long CurEndTimestamp;

	private UI_com_MiningCave UIRoot;

	private const int CollectingDir = -1;

	private const float AnimScale = 15f;

	private const float MoveSpeed = 75f;

	public static string GetURL()
	{
		return "ui://u6x0b1gnnomv74";
	}

	public static UI_com_MiningWorker CreateInstance()
	{
		return (UI_com_MiningWorker)(object)UIPackage.CreateObject("GvGShipDetail", "com_MiningWorker");
	}

	public static UI_com_MiningWorker CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MiningWorker).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnnomv74", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		ProgressBar = (GProgressBar)((GComponent)this).GetChild("ProgressBar");
		ProductIcon = (GLoader)((GComponent)this).GetChild("ProductIcon");
		n168 = (GButton)((GComponent)this).GetChild("n168");
		RemainingTime = (GTextField)((GComponent)this).GetChild("RemainingTime");
	}

	public void Init(int index, List<List<Vector2>> routes, List<List<Vector2>> randomRoutes, UI_com_MiningCave uiRoot)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		UIRoot = uiRoot;
		((GObject)this).visible = false;
		Index = index;
		WorkbenchPos = ((GObject)this).xy;
		AnimCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
		SpineTrans = UiHelper.LoadSpine_AB(SpineLoader, "Goblinworker_001", 15f, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin_portal");
			Animation = animation;
			SetAnimState(CurState);
			SetAnimDir(CurAnimDir);
		}).transform;
		SetAnimState(AnimState.idle);
		SetAnimDir(-1);
		string text = ((GObject)this).data.ToString();
		string[] array = text.Replace("r", "").Split('_');
		int index2 = int.Parse(array[0]);
		int num = int.Parse(array[1]);
		List<Vector2> list = routes[index2];
		FixedRoute = new List<Vector2> { WorkbenchPos };
		FixedRoute.AddRange(list.GetRange(num, list.Count - num));
		RandomRoutes = randomRoutes;
		((GObject)this).sortingOrder = (int)((GObject)this).y;
	}

	public void Deactivate()
	{
		((GObject)this).visible = false;
		CurEndTimestamp = 0L;
		AnimCoroutineQueue.Clear();
	}

	public void Destroy()
	{
		Deactivate();
		if ((Object)(object)SpineTrans != (Object)null)
		{
			Object.Destroy((Object)(object)((Component)SpineTrans).gameObject);
		}
	}

	public void SetProduceState(ProduceState produceState)
	{
		if (produceState.ProduceEndAt > CurEndTimestamp)
		{
			((GObject)this).visible = true;
			CurEndTimestamp = produceState.ProduceEndAt;
			if (produceState.CurProduceRecords != null && produceState.CurProduceRecords.Length != 0)
			{
				StockChangeRecord stockChangeRecord = produceState.CurProduceRecords[0];
				AnimCoroutineQueue.AddCoroutine(UpdateCollectingProgress(stockChangeRecord.ItemId, produceState.ProduceStartAt, produceState.ProduceEndAt));
				AnimCoroutineQueue.AddCoroutine(UpdateCarryToPort(stockChangeRecord.ItemId));
				AnimCoroutineQueue.AddCoroutine(PopItem(stockChangeRecord.ItemId, stockChangeRecord.Offset));
				AnimCoroutineQueue.AddCoroutine(UpdateToIdle(1));
				AnimCoroutineQueue.AddCoroutine(WaitForSeconds(0.5f));
				AnimCoroutineQueue.AddCoroutine(UpdateRunFromPortToWorkbench());
				AnimCoroutineQueue.AddCoroutine(UpdateToIdle(-1));
			}
			else
			{
				AnimCoroutineQueue.AddCoroutine(UpdateToIdle(-1));
				AnimCoroutineQueue.AddCoroutine(WaitForSeconds(0.5f));
				AnimCoroutineQueue.AddCoroutine(UpdateToSleep(-1));
			}
		}
	}

	private IEnumerator UpdateCollectingProgress(string itemId, long produceStartAt, long produceEndAt)
	{
		SetAnimDir(-1);
		SetAnimState(AnimState.mining_2);
		ProgressBar.value = 0.0;
		double end = (double)produceEndAt / 1000.0;
		double start = (double)produceStartAt / 1000.0;
		double totalCollectingTime = end - start;
		while (true)
		{
			double now = GameController.Instance.GetServerRealtimeSeconds() - 0.5;
			if (now > end)
			{
				break;
			}
			ProgressBar.max = totalCollectingTime;
			ProgressBar.value = now - start;
			((GObject)RemainingTime).text = UiHelper.ParseTimeShort((int)(end - now));
			yield return null;
		}
		ProgressBar.value = 1.0;
	}

	private IEnumerator UpdateCarryToPort(string itemId)
	{
		SetAnimDir(1);
		SetAnimState(AnimState.carry);
		string iconName = UiHelper.GetIconPath(itemId);
		string url = "ui://PublicResources/" + iconName;
		ProductIcon.url = url;
		List<Vector2> route = new List<Vector2>(FixedRoute);
		route.AddRange(ListExtensions.Random<List<Vector2>>(RandomRoutes));
		yield return null;
		yield return MoveAlongRoute(route);
	}

	private IEnumerator UpdateRunFromPortToWorkbench()
	{
		SetAnimDir(-1);
		SetAnimState(AnimState.run);
		List<Vector2> route = new List<Vector2>(FixedRoute);
		route.AddRange(ListExtensions.Random<List<Vector2>>(RandomRoutes));
		route.Reverse();
		yield return null;
		yield return MoveAlongRoute(route);
	}

	private IEnumerator PopItem(string itemId, int num)
	{
		UI_com_ProductIconWithText com = UI_com_ProductIconWithText.CreateInstance_ILRuntime();
		string iconName = UiHelper.GetIconPath(itemId);
		string url = "ui://PublicResources/" + iconName;
		Vector2 popPos = ((GObject)UIRoot.SpineLoader_Port).xy;
		popPos = popPos.Add(new Vector2(Random.Range(-23f, 23f), Random.Range(-15f, 5f)));
		((GComponent)UIRoot).AddChild((GObject)(object)com);
		((GObject)com).xy = popPos;
		com.Icon.url = url;
		((GObject)com.Num).text = $"+{num}";
		com.DisAppear.SetHook("Finished", (TransitionHook)delegate
		{
			((GComponent)UIRoot).RemoveChild((GObject)(object)com, true);
		});
		com.DisAppear.Play();
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouseWithOffsetChanges(new Dictionary<string, int> { { itemId, num } });
		yield break;
	}

	private IEnumerator MoveAlongRoute(List<Vector2> route)
	{
		int curTargetIndex = 0;
		while (curTargetIndex < route.Count)
		{
			Vector2 targetPos = route[curTargetIndex];
			Vector2 direction = targetPos.Subtract(((GObject)this).xy);
			float moveDist = 75f * Time.deltaTime;
			if (moveDist == 0f)
			{
				ILRuntimeDebug.LogError($"[UI_com_MiningWorker] MoveAlongRoute moveDist={moveDist} MoveSpeed={75f} Time.deltaTime={Time.deltaTime}");
				continue;
			}
			float mag = direction.Magnitude();
			if (mag > moveDist)
			{
				((GObject)this).xy = ((GObject)this).xy + direction.Div(mag) * moveDist;
			}
			else
			{
				((GObject)this).xy = targetPos;
				int num = curTargetIndex + 1;
				curTargetIndex = num;
			}
			((GObject)this).sortingOrder = (int)((GObject)this).y;
			yield return null;
		}
	}

	private IEnumerator WaitForSeconds(float seconds)
	{
		yield return (object)new WaitForSeconds(seconds);
	}

	private IEnumerator UpdateToIdle(int dir)
	{
		SetAnimState(AnimState.idle);
		SetAnimDir(dir);
		yield break;
	}

	private IEnumerator UpdateToSleep(int dir)
	{
		SetAnimState(AnimState.sleep);
		SetAnimDir(dir);
		yield break;
	}

	private void SetAnimState(AnimState state)
	{
		CurState = state;
		if (!((Object)(object)Animation == (Object)null))
		{
			string text = state.ToString();
			TrackEntry val = Animation.AnimationState.SetAnimation(0, text, true);
			float duration = ((SkeletonRenderer)Animation).Skeleton.Data.FindAnimation(text).Duration;
			val.TrackTime = Random.Range(0f, duration);
			val.MixDuration = 0.15f;
			State.selectedIndex = (int)state;
		}
	}

	private void SetAnimDir(int dir)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		CurAnimDir = dir;
		if (!((Object)(object)SpineTrans == (Object)null))
		{
			Vector3 localScale = SpineTrans.localScale;
			localScale.x = 15f * (float)(-dir);
			SpineTrans.localScale = localScale;
		}
	}
}
