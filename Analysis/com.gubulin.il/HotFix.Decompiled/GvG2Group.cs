using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FairyGUI;
using GameDataEditor;
using GvG2;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.GvGMode2Island;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvG.Scripts;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using Spine.Unity;
using UI.GvGWorldMap2;
using UnityEngine;

public class GvG2Group : MonoBehaviour
{
	private class AnimMaterial
	{
		public string skinName;

		public Material material;
	}

	public const int templateTargetCount = 15;

	public const int templateLastColumnCount = 5;

	private const float _NormalScale = 0.9f;

	public List<Transform> BossSoldierBlocksTransform;

	public int EntityId;

	public int ZoneId;

	public int UserId;

	public long LastUpdateServerTime;

	public long LastUpdateDetailServerTime;

	public bool IsCurUser = false;

	public List<GvG2Unit> MatrixUnits;

	public Transform GroupCollider;

	private Dictionary<string, List<MeshRenderer>> SoldiersMeshRenderer_Dict;

	private GameObject go_Units;

	private GameObject go_UnitGroups;

	private GameObject go_UnitGroupWrapper;

	private GameObject SpwanSfx;

	public GameObject GroupIcon;

	private GameObject GroupIconWrapper;

	public GameObject AvatarIcon;

	private GameObject AttackIcon;

	private GameObject CamTarget;

	public Transform Target0Trasnform;

	public string FormationId;

	public bool IsCreating;

	public bool IsDestroyed;

	public bool IsDead;

	public bool IsCurUserTarget;

	public GvG2Group MyTarget;

	public GvG2GroupBlock blockInfo;

	private Vector3 BornPos;

	private MeshRenderer[] AllMeshRenderers;

	public List<UnitInfo_Protocol> UnitsInfo;

	private int SoldierNumOnInit;

	private Coroutine CommandCoroutine;

	public SkeletonAnimation BossAnimation;

	private UIPanel AvatarUIPanel;

	private UI_GvGAvatarWrapper AvatarWrapper;

	private GvG2GroupSoldiers groupSoldiers;

	public int CampId;

	public int RoleFace;

	private float UIScale;

	private eGvGRole Role = eGvGRole.NotInit;

	private eAnimName CurAnimName;

	public List<Transform> AllUnitsTransform;

	private CoroutineQueue CoroutineQueue;

	private CoroutineQueue LoadingCoroutineQueue;

	private Vector3 TargetPos;

	private float Speed;

	private float MarchingSpeed;

	private float RushSpeed;

	private const float AVATAR_RATIO = 0.00389846f;

	private bool IsMoving = false;

	private Action OnReachTarget;

	public bool HasAniMapSoldier => AllMeshRenderers != null;

	private void Awake()
	{
		go_UnitGroups = ((Component)((Component)this).transform.Find("UnitGroups")).gameObject;
		go_UnitGroupWrapper = ((Component)go_UnitGroups.transform.Find("UnitGroupWrapper")).gameObject;
		SpwanSfx = ((Component)go_UnitGroups.transform.Find("skill_gvg_rune_appear")).gameObject;
		go_Units = ((Component)go_UnitGroupWrapper.transform.Find("Units")).gameObject;
		GroupIcon = ((Component)((Component)this).transform.Find("GroupIcon")).gameObject;
		GroupIconWrapper = ((Component)((Component)this).transform.Find("GroupIcon/GroupIconWrapper")).gameObject;
		AvatarIcon = ((Component)((Component)this).transform.Find("GroupIcon/GroupIconWrapper/AvatarIcon")).gameObject;
		AttackIcon = ((Component)((Component)this).transform.Find("GroupIcon/GroupIconWrapper/AttackIcon")).gameObject;
		CamTarget = ((Component)((Component)this).transform.Find("GroupCollider/CamTarget")).gameObject;
		Target0Trasnform = ((Component)((Component)this).transform.Find("GroupCollider/target0")).transform;
		AttackIcon.SetActive(false);
		MatrixUnits = new List<GvG2Unit>();
		LastUpdateServerTime = -1L;
		CurAnimName = eAnimName.idle;
		RoleFace = 1;
		UIScale = 1f;
		IsDestroyed = false;
		IsDead = false;
		IsCurUserTarget = false;
		MyTarget = null;
		LastUpdateDetailServerTime = 0L;
		GroupCollider = ((Component)this).gameObject.transform.Find("GroupCollider");
		CommandCoroutine = null;
		groupSoldiers = new GvG2GroupSoldiers(this);
		AllUnitsTransform = null;
		blockInfo = new GvG2GroupBlock();
		CoroutineQueue = new CoroutineQueue();
		LoadingCoroutineQueue = new CoroutineQueue();
		AllMeshRenderers = null;
	}

	private void OnDestroy()
	{
		IsDestroyed = true;
		groupSoldiers.OnDestroy();
		CoroutineQueue.Clear();
		LoadingCoroutineQueue.Clear();
		if (CommandCoroutine != null)
		{
			((MonoBehaviour)this).StopCoroutine(CommandCoroutine);
		}
		if (MatrixUnits.Count <= 0)
		{
			return;
		}
		foreach (GvG2Unit matrixUnit in MatrixUnits)
		{
			matrixUnit.OnDestroy();
		}
	}

	internal void SetGroupDataToUI(EntityInfo group_data)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		UIPanel component = AvatarIcon.GetComponent<UIPanel>();
		BoxCollider[] components = ((Component)component).GetComponents<BoxCollider>();
		component.packageName = "GvGWorldMap2";
		component.componentName = "GvGAvatarWrapper";
		if (IsCurUser)
		{
			component.SetSortingOrder(2, true);
		}
		component.CreateUI();
		AvatarUIPanel = component;
		AvatarWrapper = (UI_GvGAvatarWrapper)(object)component.ui;
		AvatarWrapper.Init(group_data);
		((GObject)AvatarWrapper).data = group_data;
		float num = 2.8f;
		float num2 = 2.8f;
		((GObject)AvatarWrapper).scale = new Vector2(num, num2);
		BoxCollider[] array = components;
		foreach (BoxCollider val in array)
		{
			val.size = new Vector3(num * val.size.x, num2 * val.size.y, 0f);
		}
		if (IsCurUser)
		{
			SharedMessenger.Broadcast("ON_GVG_USER_GROUP_CREATE", group_data);
		}
	}

	public void SetDebugMatrixWidth(float width)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = GameObject.CreatePrimitive((PrimitiveType)5);
		((Object)val).name = "DebugMatrixRect";
		val.transform.SetParent(((Component)this).transform, false);
		val.transform.localPosition = new Vector3(0f, 0.01f, 0f);
		val.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
		val.transform.localScale = Vector3.one * width;
	}

	public void SetIsCurUser(bool isCurUser)
	{
		IsCurUser = isCurUser;
	}

	public void SetBornPos(Vector3 v)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		BornPos = v;
		((Component)this).transform.localPosition = v;
	}

	private int GetMaxRealCnt(List<UnitInfo_Protocol> _UnitsInfo)
	{
		int num = 0;
		foreach (UnitInfo_Protocol item in _UnitsInfo)
		{
			int num2 = item.Total / item.PerTeamMemberCnt;
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	public void SetUnitInfo(List<UnitInfo_Protocol> _UnitsInfo)
	{
		UnitsInfo = _UnitsInfo;
		SoldierNumOnInit = UnitsInfo.Sum((UnitInfo_Protocol unit) => unit.Total);
		blockInfo.InitPlayerBlock(GetMaxRealCnt(_UnitsInfo));
		AdjustFormationSize(go_Units.transform);
		float num = blockInfo.groupRect.maxZ - blockInfo.unitWidthZ / 2f;
		float rightMostUnitX = blockInfo.groupRect.maxX - blockInfo.unitWidthX / 2f;
		AdjustUnitsMarchingTarget(rightMostUnitX, blockInfo.unitWidthX);
	}

	public void SetFormation(string formationId)
	{
		FormationId = formationId;
	}

	public void SetSpeed(float speed)
	{
		MarchingSpeed = speed;
		RushSpeed = speed * 2f;
		Speed = MarchingSpeed;
	}

	public void SetCampId(int campId)
	{
		CampId = campId;
	}

	public void UpdateMapViewLevel(eMapViewLevel viewLevel)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		switch (viewLevel)
		{
		case eMapViewLevel.BattleField:
			GroupIconWrapper.transform.localPosition = Vector3.zero;
			go_UnitGroups.SetActive(true);
			AvatarWrapper.OnLODChange_Player(0);
			generateUnits(UnitsInfo);
			break;
		case eMapViewLevel.Island:
			AvatarWrapper.OnLODChange_Player(1);
			go_UnitGroups.SetActive(false);
			break;
		}
	}

	private void generateUnits(List<UnitInfo_Protocol> _UnitsInfo)
	{
		if (HasAniMapSoldier)
		{
			return;
		}
		List<Transform> list = new List<Transform>();
		foreach (UnitInfo_Protocol item in _UnitsInfo)
		{
			GameObject gameObject = ((Component)go_Units.transform.Find("Unit" + item.PosId)).gameObject;
			gameObject.SetActive(true);
			list.Add(gameObject.transform);
		}
		_generateMinSizeSoldiers(list, _UnitsInfo);
		_generateAllSoldiers(go_Units.transform);
		GetAllMeshRenderers();
	}

	private void _generateMinSizeSoldiers(List<Transform> activeUnits, List<UnitInfo_Protocol> SoldierInfos, float randPosAmplitude = 0f)
	{
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < SoldierInfos.Count; i++)
		{
			UnitInfo_Protocol unitInfo_Protocol = SoldierInfos[i];
			string finalSoldierID = GetFinalSoldierID(unitInfo_Protocol.SoldierId);
			string soldierSkin = GetSoldierSkin(unitInfo_Protocol.SoldierId, unitInfo_Protocol.PotentialLevel);
			string text = "GvGAniMapSoldier/" + finalSoldierID + "_" + soldierSkin + "_";
			string text2 = $"{text}{CurAnimName}";
			unitInfo_Protocol.AnimMapPrefix = text;
			float num = GDMgr.Get<GDESoldierData>(finalSoldierID).Radius * 0.9f;
			GameObject model = Singleton<AnimMapCacheManager>.Instance.GetModel(finalSoldierID, soldierSkin, CurAnimName);
			int num2 = Mathf.CeilToInt((float)unitInfo_Protocol.PerTeamMemberCnt / 5f);
			int num3 = Mathf.CeilToInt(Mathf.Sqrt((float)num2));
			int num4 = Mathf.CeilToInt(1f * (float)num2 / (float)num3);
			float num5 = 1.3333334f / (float)num3 + num;
			float num6 = 1.3333334f / (float)num4 + num;
			float num7 = 2f / 3f - num5 / 2f;
			float num8 = 2f / 3f - num6 / 2f;
			groupSoldiers.AddPosId(unitInfo_Protocol.PosId.ToString(), unitInfo_Protocol.Total, text);
			int num9 = 0;
			for (int j = 0; j < num4; j++)
			{
				if (j == num4 - 1)
				{
					num5 = 1.3333334f / (float)(num2 - num9);
					num7 = 0.5f * ((float)(num2 - num9) * num5) - num5 / 2f;
				}
				for (int k = 0; k < num3; k++)
				{
					GameObject val = Object.Instantiate<GameObject>(model, activeUnits[i]);
					num9++;
					((Object)val).name = ((Object)model).name;
					val.SetActive(true);
					val.transform.localPosition = new Vector3(num8 - (float)j * num6, 0f, num7 - (float)k * num5);
					float num10 = 0.9f;
					if (unitInfo_Protocol.IsBossUnit)
					{
						num10 *= 2f;
					}
					val.transform.localScale = new Vector3(-1f, 1.414f, 1.414f) * num10;
					if (num9 >= num2)
					{
						break;
					}
				}
			}
		}
	}

	private void _generateAllSoldiers(Transform _units)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		GvG2GroupBlock gvG2GroupBlock = blockInfo;
		float num = gvG2GroupBlock.groupRect.maxZ - gvG2GroupBlock.unitWidthZ / 2f;
		float num2 = gvG2GroupBlock.groupRect.maxX - gvG2GroupBlock.unitWidthX / 2f;
		int num3 = 0;
		((Object)((Component)_units).gameObject).name = "units";
		GameObject val = new GameObject($"units_wrap_{0}");
		Transform parent = _units.parent;
		val.transform.SetParent(parent);
		val.transform.localScale = Vector3.one;
		_units.SetParent(val.transform);
		_units.localPosition = Vector3.zero;
		List<Transform> list = new List<Transform>();
		list.Add(val.transform);
		for (int i = 1; i < gvG2GroupBlock.teamCount; i++)
		{
			GameObject val2 = new GameObject($"units_wrap_{i}");
			val2.transform.SetParent(parent);
			list.Add(val2.transform);
		}
		LoadingCoroutineQueue.AddCoroutine(CloneFromTemplateUnits(new List<Transform> { _units }, list, 1));
		for (int j = 0; j < gvG2GroupBlock._x_cnt; j++)
		{
			if (j == gvG2GroupBlock._x_cnt - 1)
			{
				gvG2GroupBlock.unitWidthZ = 1f * gvG2GroupBlock.groupWidthZ / (float)(gvG2GroupBlock.real_cnt - num3);
				num = (float)(gvG2GroupBlock.real_cnt - num3) * gvG2GroupBlock.unitWidthZ / 2f - gvG2GroupBlock.unitWidthZ / 2f;
			}
			for (int k = 0; k < gvG2GroupBlock._z_cnt; k++)
			{
				GameObject gameObject = ((Component)list[num3]).gameObject;
				num3++;
				gameObject.transform.localPosition = new Vector3(num2 - (float)j * gvG2GroupBlock.unitWidthX, 0f, num - (float)k * gvG2GroupBlock.unitWidthZ);
				AddMatrixUnits(gameObject);
				if (num3 >= gvG2GroupBlock.real_cnt)
				{
					break;
				}
			}
		}
		AllUnitsTransform = list;
	}

	private IEnumerator CloneFromTemplateUnits(List<Transform> templateUnits, List<Transform> allUnitsTransform, int loadingCountPerFrame, bool useRandom = false)
	{
		List<int> indexes = new List<int>();
		for (int i = templateUnits.Count; i < allUnitsTransform.Count; i++)
		{
			indexes.Add(i);
		}
		if (useRandom)
		{
			int i2 = 0;
			while (i2 < indexes.Count)
			{
				int r = Random.Range(i2, indexes.Count);
				int tmp = indexes[i2];
				indexes[i2] = indexes[r];
				indexes[r] = tmp;
				int num = i2 + 1;
				i2 = num;
			}
			yield return null;
		}
		for (int j = 0; j < indexes.Count; j++)
		{
			int randIndex = indexes[j];
			if (j % loadingCountPerFrame == 0)
			{
				yield return null;
			}
			Transform _units = templateUnits[Random.Range(0, templateUnits.Count)];
			GameObject units_clone = Object.Instantiate<GameObject>(((Component)_units).gameObject);
			((Object)units_clone).name = "units";
			units_clone.transform.SetParent(((Component)allUnitsTransform[randIndex]).transform);
			units_clone.transform.localScale = ((Component)_units).transform.localScale;
			units_clone.transform.localPosition = Vector3.zero;
		}
		yield return null;
		groupSoldiers.InitSoldierPosIdMap(allUnitsTransform);
	}

	private void AdjustFormationSize(Transform Units, float BlockWidth = 1.3333334f, float diff_size = 0f)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		float num = diff_size / 195f * 2f * 2f;
		for (int i = 0; i < Units.childCount; i++)
		{
			GameObject gameObject = ((Component)Units.GetChild(i)).gameObject;
			Vector3 localPosition = gameObject.transform.localPosition;
			if (localPosition.x != 0f)
			{
				float num2 = Mathf.Abs(localPosition.x);
				float num3 = localPosition.x / num2;
				localPosition.x = BlockWidth * num3 + num * num3;
			}
			if (localPosition.y != 0f)
			{
				float num4 = Mathf.Abs(localPosition.y);
				float num5 = localPosition.y / num4;
				localPosition.y = BlockWidth * num5 + num * num5;
			}
			if (localPosition.z != 0f)
			{
				float num6 = Mathf.Abs(localPosition.z);
				float num7 = localPosition.z / num6;
				localPosition.z = BlockWidth * num7 + num * num7;
			}
			gameObject.transform.localPosition = localPosition;
		}
	}

	private void AdjustUnitsMarchingTarget(float rightMostUnitX, float extraOffset)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		float num = rightMostUnitX - ((Component)GroupCollider.Find($"target{14}")).transform.localPosition.x;
		num += extraOffset;
		for (int i = 0; i < 15; i++)
		{
			Transform val = GroupCollider.Find($"target{i}");
			Transform transform = ((Component)val).transform;
			transform.localPosition += new Vector3(num, 0f, 0f);
		}
	}

	public void AddMatrixUnits(GameObject _go)
	{
		int index = MatrixUnits.Count();
		GvG2Unit item = new GvG2Unit(_go, index, this);
		MatrixUnits.Add(item);
	}

	internal void SetUIScale(float curCamSize)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		UIScale = 1f;
		GroupIcon.transform.localScale = new Vector3((float)RoleFace * UIScale, UIScale, UIScale);
	}

	public void SetAnim(eAnimName animName)
	{
		CurAnimName = animName;
		if (SoldiersMeshRenderer_Dict != null)
		{
			foreach (KeyValuePair<string, List<MeshRenderer>> item in SoldiersMeshRenderer_Dict)
			{
				Material animMat = Singleton<AnimMapCacheManager>.Instance.GetAnimMat(item.Key, CurAnimName);
				foreach (MeshRenderer item2 in item.Value)
				{
					((Renderer)item2).material = animMat;
				}
			}
		}
		if (animName == eAnimName.attack)
		{
			foreach (GvG2Unit matrixUnit in MatrixUnits)
			{
				matrixUnit.PlaySfx();
			}
			return;
		}
		foreach (GvG2Unit matrixUnit2 in MatrixUnits)
		{
			matrixUnit2.StopSfx();
		}
	}

	public void SetRoleFace(int direction)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		RoleFace = direction;
		((Component)this).transform.localScale = new Vector3((float)RoleFace, 1f, 1f);
		GroupIcon.transform.localScale = new Vector3((float)RoleFace * UIScale, UIScale, UIScale);
	}

	public void SetSpawning()
	{
		CoroutineQueue.AddCoroutine(StartSpwaning());
	}

	public void SetAppear()
	{
		go_UnitGroupWrapper.SetActive(true);
		Object.Destroy((Object)(object)SpwanSfx);
	}

	internal void UpdateSoldiersDetail(BroadcastGroupDetailInfo detail_data)
	{
		int num = 0;
		foreach (KeyValuePair<string, int> item in detail_data.SoldierDetail)
		{
			int value = item.Value;
			num += value;
			groupSoldiers.ChangePosIdSoldierCount(item.Key, value);
		}
		groupSoldiers.StartCheckDeath();
		AvatarWrapper.OnSoldierNumChange(num);
	}

	public void SetDead()
	{
		IsDead = true;
		AvatarWrapper.OnDying(delegate
		{
			IsDestroyed = true;
			Object.Destroy((Object)(object)((Component)this).gameObject);
		});
		if (IsCurUser)
		{
			if ((Object)(object)MyTarget != (Object)null && !MyTarget.IsDead)
			{
				MyTarget.IsCurUserTarget = false;
				MyTarget.SetToBeGeneral();
			}
			SharedMessenger.Broadcast("ON_GVG_USER_GROUP_DEAD");
		}
	}

	public void SetState(eGvGMode2State state, Dictionary<string, object> data)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		if (data.ContainsKey("X"))
		{
			((Component)this).transform.localPosition = new Vector3((float)data["X"] / 1000f, 0f, (float)data["Y"] / 1000f);
		}
		if (data.ContainsKey("Role"))
		{
			SetRoleFace((int)data["Role"]);
		}
		AvatarWrapper.SetState(state);
		IsMoving = false;
		OnReachTarget = null;
		MyTarget = null;
		switch (state)
		{
		case eGvGMode2State.Born:
			SetAnim(eAnimName.idle);
			break;
		case eGvGMode2State.Idle:
			SetToBeGeneral();
			SetAnim(eAnimName.idle);
			break;
		case eGvGMode2State.Fighting:
			if (data.ContainsKey("AttackTarget"))
			{
				int fightingTarget = (int)data["AttackTarget"];
				SetFightingTarget(fightingTarget);
			}
			if (data.ContainsKey("FX"))
			{
				TargetPos = new Vector3((float)data["FX"] / 1000f, 0f, (float)data["FY"] / 1000f);
				Speed = RushSpeed;
				IsMoving = true;
				OnReachTarget = delegate
				{
					SetAnim(eAnimName.attack);
				};
			}
			else
			{
				SetAnim(eAnimName.attack);
			}
			break;
		case eGvGMode2State.PeaceMarching:
			SetToBeGeneral();
			if (data.ContainsKey("FX"))
			{
				SetAnim(eAnimName.run);
				TargetPos = new Vector3((float)data["FX"] / 1000f, 0f, (float)data["FY"] / 1000f);
				Speed = MarchingSpeed;
				IsMoving = true;
			}
			break;
		case eGvGMode2State.MovingHoldPos:
			SetToBeGeneral();
			if (data.ContainsKey("FX"))
			{
				SetAnim(eAnimName.run);
				TargetPos = new Vector3((float)data["FX"] / 1000f, 0f, (float)data["FY"] / 1000f);
				Speed = MarchingSpeed;
				IsMoving = true;
			}
			break;
		case eGvGMode2State.InFightingZone:
			SetToBeGeneral();
			if (data.ContainsKey("FX"))
			{
				SetAnim(eAnimName.run);
				TargetPos = new Vector3((float)data["FX"] / 1000f, 0f, (float)data["FY"] / 1000f);
				Speed = MarchingSpeed;
				IsMoving = true;
			}
			break;
		case eGvGMode2State.Holding:
			SetToBeGeneral();
			SetAnim(eAnimName.idle);
			AvatarWrapper.SetHoldingScorePerSecond(GvGIslandController.Instance.HoldingScorePerSecond);
			break;
		}
	}

	private void SetFightingTarget(int targetId)
	{
		CoroutineQueue.AddCoroutine(SetFightingTargetCoroutine(targetId));
	}

	private IEnumerator SetFightingTargetCoroutine(int targetId)
	{
		GvG2Group targetGroup = GvGIslandController.Instance.GetGroupById(targetId);
		int maxWaitCount = 20;
		while ((Object)(object)targetGroup == (Object)null)
		{
			yield return (object)new WaitForSeconds(0.1f);
			int num = maxWaitCount - 1;
			maxWaitCount = num;
			if (num < 0)
			{
				yield break;
			}
			targetGroup = GvGIslandController.Instance.GetGroupById(targetId);
		}
		if (IsCurUser)
		{
			targetGroup.IsCurUserTarget = true;
			MyTarget = targetGroup;
		}
		targetGroup.SetToBeDefender(IsCurUser);
		SetToBeAttacker(targetGroup, IsCurUser);
	}

	private void SetToBeGeneral()
	{
		AvatarWrapper.SetToBeGeneral();
		AvatarUIPanel.SetSortingOrder(1, true);
	}

	private void SetToBeAttacker(GvG2Group targetGroup, bool isShowVfx)
	{
		if (isShowVfx)
		{
			AvatarWrapper.SetToBeMeVfx();
			AvatarUIPanel.SetSortingOrder(3, true);
		}
	}

	private void SetToBeDefender(bool isShowVfx)
	{
		if (isShowVfx)
		{
			AvatarWrapper.SetToBeTargetVfx();
			AvatarUIPanel.SetSortingOrder(2, true);
		}
	}

	public void SetSoldierNum(int soldierCost, int soldierRemaining)
	{
		AvatarWrapper.OnSoldierNumChange(soldierRemaining);
		if (AllMeshRenderers == null)
		{
			return;
		}
		int num = (int)Mathf.Ceil((float)AllMeshRenderers.Length * (float)soldierRemaining / (float)SoldierNumOnInit);
		for (int i = 0; i < AllMeshRenderers.Length; i++)
		{
			((Renderer)AllMeshRenderers[i]).enabled = i < num;
		}
		foreach (GvG2Unit matrixUnit in MatrixUnits)
		{
			matrixUnit.CheckSoldierCount();
		}
	}

	private IEnumerator StartSpwaning()
	{
		yield return (object)new WaitForSeconds(0.1f);
		SpwanSfx.SetActive(true);
		yield return (object)new WaitForSeconds(0.2f);
		go_UnitGroupWrapper.SetActive(true);
		yield return (object)new WaitForSeconds(1.3f);
		Object.Destroy((Object)(object)SpwanSfx);
	}

	private void Update()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (IsMoving)
		{
			if (Vector3.Distance(((Component)this).transform.localPosition, TargetPos) < 0.001f)
			{
				((Component)this).transform.localPosition = TargetPos;
				IsMoving = false;
				OnReachTarget?.Invoke();
				OnReachTarget = null;
			}
			else
			{
				float num = Speed * Time.deltaTime;
				((Component)this).transform.localPosition = Vector3.MoveTowards(((Component)this).transform.localPosition, TargetPos, num);
			}
		}
	}

	private void GetAllMeshRenderers()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		MeshRenderer[] componentsInChildren = ((Component)((Component)this).transform.Find("UnitGroups")).GetComponentsInChildren<MeshRenderer>();
		int num = 0;
		Dictionary<string, List<MeshRenderer>> dictionary = new Dictionary<string, List<MeshRenderer>>();
		MeshRenderer[] array = componentsInChildren;
		foreach (MeshRenderer val in array)
		{
			Transform transform = ((Component)val).transform;
			transform.localPosition += RandomSolfierDeltaPos();
			if (!dictionary.TryGetValue(((Object)val).name, out var value))
			{
				value = new List<MeshRenderer>();
				dictionary.Add(((Object)val).name, value);
			}
			value.Add(val);
			if (++num > 1000)
			{
				num = 0;
			}
		}
		ShuffleMeshRendererList(componentsInChildren);
		AllMeshRenderers = componentsInChildren;
		SoldiersMeshRenderer_Dict = dictionary;
	}

	private Vector3 RandomSolfierDeltaPos()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		return new Vector3(Random.Range(-0.2f, 0.2f), 0f, Random.Range(-0.2f, 0.2f));
	}

	private void CamFollow(Vector3 localPosition)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		CamTarget.transform.localPosition = localPosition;
	}

	public string GetFinalSoldierID(string soldierId)
	{
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(soldierId);
		string text = gDESoldierData.ParentSoldierId;
		if (string.IsNullOrEmpty(text))
		{
			text = soldierId;
		}
		return text;
	}

	private string GetSoldierSkin(string soldierId, int potentialLevel)
	{
		string text = GDMgr.Get<GDESoldierData>(soldierId)?.Skin;
		if (!Regex.IsMatch(soldierId, "^S\\d{3}$") && text != "UsePotentialLevel")
		{
			return text ?? "skin1";
		}
		return $"skin{(potentialLevel + 2) / 2}";
	}

	private void ShuffleMeshRendererList(MeshRenderer[] list)
	{
		for (int i = 0; i < list.Length; i++)
		{
			MeshRenderer val = list[i];
			int num = Random.Range(i, list.Length);
			list[i] = list[num];
			list[num] = val;
		}
	}
}
