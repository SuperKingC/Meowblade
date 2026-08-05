using System;
using System.Collections;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Spine.Unity;
using UnityEngine;
using UnityEngine.Rendering;

public class CampSlotController : MonoBehaviour
{
	public class ProduceInfo
	{
		public string SoldierId;

		public int CompleteTime;

		public override bool Equals(object obj)
		{
			if (!(obj is ProduceInfo produceInfo))
			{
				return false;
			}
			return SoldierId == produceInfo.SoldierId && CompleteTime == produceInfo.CompleteTime;
		}
	}

	private const string CampSlotFinish = "camp_slot_finish";

	private const int RefreshRate = 10;

	private int _controllerIndex;

	private ProduceInfo _currentProduceInfo;

	private CampController _campController;

	private List<CampSlot> _slots;

	private Dictionary<string, List<GameObject>> _soldiersPool;

	private Transform[] _portalToBattleFieldPath;

	private GameObject _treasureChestGlowRays;

	private Dictionary<string, GameObject> _soldierSilhouette;

	private bool _producingIsOver;

	private string _soldierId => CurrentSoldierId();

	private void Awake()
	{
		_soldiersPool = new Dictionary<string, List<GameObject>>();
		_soldierSilhouette = new Dictionary<string, GameObject>();
		_treasureChestGlowRays = ((Component)((Component)this).transform.Find("MagicCircleBlue/TreasureChestGlowRays")).gameObject;
		_treasureChestGlowRays.SetActive(false);
		_producingIsOver = true;
	}

	private void Update()
	{
		if (Time.frameCount % 10 == _controllerIndex)
		{
			UpdateState();
		}
	}

	private void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		ClearGameObjectCache();
	}

	public void Init(List<CampSlot> slots, CampController controller, int index)
	{
		_slots = slots;
		_campController = controller;
		_controllerIndex = index;
		List<int> list = _campController.Path[_controllerIndex];
		Transform val = ((Component)this).transform.parent.Find("PathPoint");
		List<Transform> list2 = new List<Transform>();
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(val.Find(list[i].ToString()));
		}
		_portalToBattleFieldPath = list2.ToArray();
	}

	private void UpdateState()
	{
		bool allSlotsIdle;
		ProduceInfo produceInfo = GetProduceInfo(out allSlotsIdle);
		if (allSlotsIdle)
		{
			ClearGameObjectCache();
			ClearState();
			_currentProduceInfo = produceInfo;
		}
		else if (produceInfo == null)
		{
			if (_producingIsOver)
			{
				ClearState();
				_currentProduceInfo = null;
			}
		}
		else if (!produceInfo.Equals(_currentProduceInfo) && (!(produceInfo.SoldierId == _currentProduceInfo?.SoldierId) || _producingIsOver))
		{
			ClearState();
			_currentProduceInfo = produceInfo;
			long produceTime = _currentProduceInfo.CompleteTime - GameController.Instance.GetServerTime();
			StartProduce(produceTime);
		}
	}

	private void ClearGameObjectCache()
	{
		foreach (KeyValuePair<string, List<GameObject>> item in _soldiersPool)
		{
			foreach (GameObject item2 in item.Value)
			{
				Object.Destroy((Object)(object)item2);
			}
		}
		_soldiersPool.Clear();
		foreach (KeyValuePair<string, GameObject> item3 in _soldierSilhouette)
		{
			Object.Destroy((Object)(object)item3.Value);
		}
		_soldierSilhouette.Clear();
	}

	private void ClearState()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		_producingIsOver = true;
		Hide_DarkSoldier();
		_treasureChestGlowRays.SetActive(false);
	}

	private ProduceInfo GetProduceInfo(out bool allSlotsIdle)
	{
		if (_slots == null || _slots.Count < 3)
		{
			ILRuntimeDebug.LogError("[CampSlotController]:_slots is null or count error");
			allSlotsIdle = true;
			return null;
		}
		allSlotsIdle = true;
		foreach (CampSlot slot in _slots)
		{
			if (!string.IsNullOrEmpty(slot.SoldierId) && slot.SlotState != CampSlot.CampSlotState.Ready && slot.SlotState != CampSlot.CampSlotState.Constructing)
			{
				allSlotsIdle = false;
				break;
			}
		}
		if (allSlotsIdle)
		{
			return null;
		}
		ProduceInfo produceInfo = null;
		for (int i = 0; i < _slots.Count; i++)
		{
			CampSlot campSlot = _slots[i];
			if (campSlot.SlotState != CampSlot.CampSlotState.Running)
			{
				continue;
			}
			int num = GameManagers.Instance.RecruitingCampDataManager.ProducingEndTime[campSlot.ProduceIndex];
			if (num > 0)
			{
				string soldierId = campSlot.SoldierId;
				if (produceInfo == null)
				{
					produceInfo = new ProduceInfo
					{
						SoldierId = soldierId,
						CompleteTime = num
					};
				}
				else if (produceInfo.CompleteTime > num)
				{
					produceInfo.SoldierId = soldierId;
					produceInfo.CompleteTime = num;
				}
			}
		}
		return produceInfo;
	}

	private string CurrentSoldierId()
	{
		if (_currentProduceInfo == null)
		{
			return string.Empty;
		}
		return _currentProduceInfo.SoldierId;
	}

	private void StartProduce(long produceTime)
	{
		((MonoBehaviour)this).StartCoroutine(StartProduceIEnumerator(produceTime));
	}

	private void Hide_DarkSoldier()
	{
		foreach (GameObject value in _soldierSilhouette.Values)
		{
			value.SetActive(false);
		}
	}

	private void ShowProduceComplete()
	{
		((MonoBehaviour)this).StartCoroutine(UI_ProduceComplete());
	}

	private void SoldierToBattleField()
	{
		string toBattleId = _soldierId;
		int soldierPotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(toBattleId);
		int num = (soldierPotentialLevel + 2) / 2;
		GameObject soldier = GetSoldier(toBattleId);
		if (Object.op_Implicit((Object)(object)soldier))
		{
			Hide_DarkSoldier();
			soldier.GetComponent<CampSlotSoldierAnimation>().SetSoldierAnimationInfoOnProducting(0f, _portalToBattleFieldPath, _soldiersPool[toBattleId]);
			return;
		}
		soldier = CreateSoldier();
		SpawnManager.Instance.LoadSoldierSpine(soldier, $"{toBattleId}_skin{num}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			Hide_DarkSoldier();
			CampSlotSoldierAnimation component = soldier.GetComponent<CampSlotSoldierAnimation>();
			component.InitAnimation(asset, toBattleId, ((Component)this).transform.position.x);
			component.SetSoldierAnimationInfoOnProducting(0f, _portalToBattleFieldPath, _soldiersPool[toBattleId]);
		});
	}

	private GameObject GetSoldier(string soldierId)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		if (_soldiersPool == null)
		{
			_soldiersPool = new Dictionary<string, List<GameObject>>();
		}
		if (!_soldiersPool.TryGetValue(soldierId, out var value))
		{
			_soldiersPool.Add(soldierId, new List<GameObject>());
			return null;
		}
		if (value.Count == 0)
		{
			return null;
		}
		GameObject val = value[0];
		value.RemoveAt(0);
		val.transform.localPosition = new Vector3(-0.06f, 0f, 0f);
		val.SetActive(false);
		return val;
	}

	private GameObject CreateSoldier()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = Object.Instantiate<GameObject>(Resources.Load<GameObject>("CampSlotSoldier"), ((Component)this).transform);
		val.AddComponent<CampSlotSoldierAnimation>();
		val.transform.localPosition = new Vector3(-0.06f, 0f, 0f);
		return val;
	}

	private IEnumerator StartProduceIEnumerator(float delay)
	{
		_producingIsOver = false;
		Hide_DarkSoldier();
		_treasureChestGlowRays.SetActive(true);
		string produceId = _soldierId;
		int index = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(produceId);
		int potentialLevel = (index + 2) / 2;
		if (_soldierSilhouette.TryGetValue(produceId, out var soldier))
		{
			soldier.GetComponent<CampSlotSoldierAnimation>().SetSoldierAnimationInfoOnWaitProduct(4);
		}
		else
		{
			GameObject soldierNew = CreateSoldier();
			_soldierSilhouette.Add(produceId, soldierNew);
			SpawnManager.Instance.LoadSoldierSpine(soldierNew, $"{produceId}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				//IL_002a: Unknown result type (might be due to invalid IL or missing references)
				CampSlotSoldierAnimation component = soldierNew.GetComponent<CampSlotSoldierAnimation>();
				component.InitAnimation(asset, produceId, ((Component)this).transform.position.x);
				component.SetSoldierAnimationInfoOnWaitProduct(4);
			});
		}
		yield return (object)new WaitForSeconds(delay);
		ShowProduceComplete();
		SoldierToBattleField();
		GameManagers.Instance.RecruitingCampDataManager.TryMakeOneRecruiting_WhenFinish(0);
		_producingIsOver = true;
	}

	private IEnumerator UI_ProduceComplete()
	{
		_treasureChestGlowRays.SetActive(false);
		Transform obj = ((Component)this).transform.Find("camp_slot_finish");
		GameObject campSlotFinish = ((obj != null) ? ((Component)obj).gameObject : null);
		if ((Object)(object)campSlotFinish != (Object)null)
		{
			campSlotFinish.GetComponent<ParticleSystem>().Play();
			yield break;
		}
		yield return SpawnManager.Instance.InstantiatePoolCoroutine("camp_slot_finish", Vector3.one * 20000f, delegate(GameObject go)
		{
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			campSlotFinish = go;
			UiAudioManager.Instance.LoadSoundsForSfx(campSlotFinish, "BlastForPack", playLoop: false, 1f, limitForScene: true);
			campSlotFinish.GetComponent<Renderer>().sortingLayerName = "Default";
			campSlotFinish.AddComponent<SortingGroup>().sortingOrder = 5;
			((Object)campSlotFinish).name = "camp_slot_finish";
			campSlotFinish.transform.parent = ((Component)this).transform;
			campSlotFinish.transform.localPosition = new Vector3(0f, 0.05f, 0.5f);
			campSlotFinish.transform.localEulerAngles = new Vector3(-55f, 0f, 0f);
		});
	}
}
