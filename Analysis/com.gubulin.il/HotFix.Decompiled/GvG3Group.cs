using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FairyGUI;
using GameDataEditor;
using GvG3;
using GvG3OnIsland;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.ClientApi;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.GvGMode3Island;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvG.Common.Models;
using Spine.Unity;
using UI.GvGOnIsland3;
using UnityEngine;

public class GvG3Group : MonoBehaviour
{
	public const int templateTargetCount = 15;

	public const int templateLastColumnCount = 5;

	private const float _NormalScale = 0.9f;

	public List<Transform> BossSoldierBlocksTransform;

	public int EntityId;

	public int ZoneId;

	public int UserId;

	public eGvG3Role GvGRole;

	public long LastUpdateServerTime;

	public long LastUpdateDetailServerTime;

	public bool IsCurUser = false;

	public List<GvG3Unit> MatrixUnits;

	public Transform GroupCollider;

	private GameObject TeamContainer;

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

	public GvG3Group MyTarget;

	public GvG3GroupBlock blockInfo;

	private Vector3 BornPos;

	public List<UnitInfo_Protocol> UnitsInfo;

	public bool IsBossGroup;

	protected int SoldierNumOnInit;

	private Coroutine CommandCoroutine;

	public SkeletonAnimation BossAnimation;

	private UIPanel AvatarUIPanel;

	public UI_com_GvGAvatarWrapper AvatarWrapper;

	private eGvGMode3FightingState _CurState;

	public bool _IsSpwaned = false;

	public bool _IsVisibleByPriority = false;

	public bool _IsVisibleByMapViewLevel = false;

	public int CampId;

	public int RoleFace;

	private float UIScale;

	public eAnimName CurAnimName;

	public List<Transform> TeamWrapperTransform_List;

	protected CoroutineQueue CoroutineQueue;

	private CoroutineQueue LoadingCoroutineQueue;

	public IEnumerator LoadingCoroutine;

	private Vector3 TargetPos;

	private float Speed;

	private float MarchingSpeed;

	private float RushSpeed;

	protected bool IsMoving = false;

	private Action OnReachTarget;

	private MeshRenderer[] AllMeshRenderers;

	protected Dictionary<string, List<MeshRenderer>> SoldiersMeshRenderer_Dict;

	private const float AVATAR_RATIO = 0.00389846f;

	public bool IsGone => IsDead;

	public bool IsVisibleByPriority
	{
		get
		{
			return _IsVisibleByPriority;
		}
		set
		{
			_IsVisibleByPriority = value;
			TeamContainer.SetActive(IsTeamVisible);
		}
	}

	public bool IsVisibleByMapViewLevel
	{
		get
		{
			return _IsVisibleByMapViewLevel;
		}
		set
		{
			_IsVisibleByMapViewLevel = value;
			TeamContainer.SetActive(IsTeamVisible);
		}
	}

	public bool IsSpwaned
	{
		get
		{
			return _IsSpwaned;
		}
		set
		{
			_IsSpwaned = value;
			TeamContainer.SetActive(IsTeamVisible);
		}
	}

	public eGvGMode3FightingState CurState
	{
		get
		{
			return _CurState;
		}
		set
		{
			_CurState = value;
			TeamContainer.SetActive(IsTeamVisible);
		}
	}

	public bool IsTeamVisible => _IsVisibleByPriority && _IsVisibleByMapViewLevel && _CurState != eGvGMode3FightingState.Invulnerable && _IsSpwaned;

	public bool HasAniMapSoldier => AllMeshRenderers != null;

	public bool IsAlly(int obCampId)
	{
		return CampId == obCampId && !IsCurUser;
	}

	public bool OtherEnemy(int obCampId)
	{
		return CampId != obCampId;
	}

	private void Awake()
	{
		TeamContainer = ((Component)((Component)this).transform.Find("TeamContainer")).gameObject;
		SpwanSfx = ((Component)((Component)this).transform.Find("TeamContainer/skill_gvg_rune_appear")).gameObject;
		GroupIcon = ((Component)((Component)this).transform.Find("GroupIcon")).gameObject;
		GroupIconWrapper = ((Component)((Component)this).transform.Find("GroupIcon/GroupIconWrapper")).gameObject;
		AvatarIcon = ((Component)((Component)this).transform.Find("GroupIcon/GroupIconWrapper/AvatarIcon")).gameObject;
		AttackIcon = ((Component)((Component)this).transform.Find("GroupIcon/GroupIconWrapper/AttackIcon")).gameObject;
		CamTarget = ((Component)((Component)this).transform.Find("GroupCollider/CamTarget")).gameObject;
		Target0Trasnform = ((Component)((Component)this).transform.Find("GroupCollider/target0")).transform;
		AttackIcon.SetActive(false);
		MatrixUnits = new List<GvG3Unit>();
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
		TeamWrapperTransform_List = null;
		blockInfo = new GvG3GroupBlock();
		CoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)this);
		LoadingCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)this);
		LoadingCoroutine = GenerateGroupModels();
	}

	private void OnDestroy()
	{
		IsDestroyed = true;
		CoroutineQueue.Clear();
		LoadingCoroutineQueue.Clear();
		if (CommandCoroutine != null)
		{
			((MonoBehaviour)this).StopCoroutine(CommandCoroutine);
		}
		if (MatrixUnits.Count > 0)
		{
			foreach (GvG3Unit matrixUnit in MatrixUnits)
			{
				matrixUnit.OnDestroy();
			}
		}
		MyTarget = null;
	}

	internal void SetGroupDataToUI(EntityInfo group_data, int islandId)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		UIPanel component = AvatarIcon.GetComponent<UIPanel>();
		BoxCollider[] components = ((Component)component).GetComponents<BoxCollider>();
		component.packageName = "GvGOnIsland3";
		component.componentName = "com_GvGAvatarWrapper";
		if (IsCurUser)
		{
			component.SetSortingOrder(2, true);
		}
		component.CreateUI();
		AvatarUIPanel = component;
		AvatarWrapper = (UI_com_GvGAvatarWrapper)(object)component.ui;
		AvatarWrapper.Init(group_data, islandId);
		((GObject)AvatarWrapper).data = group_data;
		float groupIconSize = group_data.GroupIconSize;
		float groupIconSize2 = group_data.GroupIconSize;
		((GObject)AvatarWrapper).scale = new Vector2(groupIconSize, groupIconSize2);
		BoxCollider[] array = components;
		foreach (BoxCollider val in array)
		{
			val.size = new Vector3(groupIconSize * val.size.x, groupIconSize2 * val.size.y, 0f);
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
		IsBossGroup = UnitsInfo.FindIndex((UnitInfo_Protocol u) => u.IsBossUnit) > -1;
		SoldierNumOnInit = UnitsInfo.Sum((UnitInfo_Protocol unit) => unit.Total);
		blockInfo.InitPlayerBlock(GetMaxRealCnt(_UnitsInfo));
		InitTeamWrappers(blockInfo);
		float num = blockInfo.groupRect.maxZ - blockInfo.unitWidthZ / 2f;
		float rightMostUnitX = blockInfo.groupRect.maxX - blockInfo.unitWidthX / 2f;
		AdjustUnitsMarchingTarget(rightMostUnitX, blockInfo.unitWidthX);
	}

	public void InitTeamWrappers(GvG3GroupBlock blockInfo)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		TeamWrapperTransform_List = new List<Transform>();
		TeamWrapperTransform_List.Add(TeamContainer.transform.Find("TeamWrapper0"));
		for (int i = 1; i < blockInfo.teamCount; i++)
		{
			Transform transform = new GameObject($"TeamWrapper{i}").transform;
			transform.SetParent(TeamContainer.transform, false);
			TeamWrapperTransform_List.Add(transform);
		}
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

	public void UpdateMapViewLevel(HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.eMapViewLevel viewLevel)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		switch (viewLevel)
		{
		case HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.eMapViewLevel.BattleField:
			GroupIconWrapper.transform.localPosition = Vector3.zero;
			IsVisibleByMapViewLevel = true;
			AvatarWrapper.OnLODChange_Player(0);
			break;
		case HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.eMapViewLevel.Island:
			AvatarWrapper.OnLODChange_Player(1);
			IsVisibleByMapViewLevel = false;
			break;
		}
	}

	public IEnumerator GenerateGroupModels()
	{
		Transform firstTeamTrans = GenerateSingleTeamModel(UnitsInfo);
		yield return null;
		SetTeamPos();
		yield return DuplicateTeams(firstTeamTrans);
		yield return GetAllMeshRenderers();
	}

	private Transform GenerateSingleTeamModel(List<UnitInfo_Protocol> SoldierInfos)
	{
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		Transform val = ((Component)this).transform.Find("TeamContainer/TeamWrapper0/Team");
		for (int i = 0; i < SoldierInfos.Count; i++)
		{
			UnitInfo_Protocol unitInfo_Protocol = SoldierInfos[i];
			Transform val2 = val.Find("Square" + unitInfo_Protocol.PosId);
			((Component)val2).gameObject.SetActive(true);
			AdjustFormationSize(val2);
			string finalSoldierID = GetFinalSoldierID(unitInfo_Protocol.SoldierId);
			string soldierSkin = GetSoldierSkin(unitInfo_Protocol.SoldierId, unitInfo_Protocol.PotentialLevel);
			GameObject model = Singleton<AnimMapCacheManager>.Instance.GetModel(finalSoldierID, soldierSkin, CurAnimName);
			float num = GDMgr.Get<GDESoldierData>(finalSoldierID).Radius * 0.9f;
			int num2 = Mathf.CeilToInt((float)unitInfo_Protocol.PerTeamMemberCnt / 5f);
			int num3 = Mathf.CeilToInt(Mathf.Sqrt((float)num2));
			int num4 = Mathf.CeilToInt(1f * (float)num2 / (float)num3);
			float num5 = 1.3333334f / (float)num3 + num;
			float num6 = 1.3333334f / (float)num4 + num;
			float num7 = 2f / 3f - num5 / 2f;
			float num8 = 2f / 3f - num6 / 2f;
			Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
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
					Transform transform = Object.Instantiate<GameObject>(model).transform;
					((Object)transform).name = ((Object)model).name;
					transform.SetParent(val2, false);
					((Component)transform).gameObject.SetActive(true);
					transform.localPosition = new Vector3(num8 - (float)j * num6, 0f, num7 - (float)k * num5);
					float num10 = (unitInfo_Protocol.IsBossUnit ? 1.8f : 0.9f);
					transform.localScale = new Vector3(1f, 1.414f, 1.414f) * num10;
					transform.rotation = rotation;
					num9++;
					if (num9 >= num2)
					{
						break;
					}
				}
			}
		}
		return val;
	}

	private void SetTeamPos()
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		GvG3GroupBlock gvG3GroupBlock = blockInfo;
		float num = gvG3GroupBlock.groupRect.maxZ - gvG3GroupBlock.unitWidthZ / 2f;
		float num2 = gvG3GroupBlock.groupRect.maxX - gvG3GroupBlock.unitWidthX / 2f;
		int num3 = 0;
		for (int i = 0; i < gvG3GroupBlock._x_cnt; i++)
		{
			if (i == gvG3GroupBlock._x_cnt - 1)
			{
				gvG3GroupBlock.unitWidthZ = 1f * gvG3GroupBlock.groupWidthZ / (float)(gvG3GroupBlock.real_cnt - num3);
				num = (float)(gvG3GroupBlock.real_cnt - num3) * gvG3GroupBlock.unitWidthZ / 2f - gvG3GroupBlock.unitWidthZ / 2f;
			}
			for (int j = 0; j < gvG3GroupBlock._z_cnt; j++)
			{
				Transform val = TeamWrapperTransform_List[num3];
				val.localPosition = new Vector3(num2 - (float)i * gvG3GroupBlock.unitWidthX, 0f, num - (float)j * gvG3GroupBlock.unitWidthZ);
				DetachTeamScript(val);
				num3++;
				if (num3 >= gvG3GroupBlock.real_cnt)
				{
					break;
				}
			}
			if (num3 >= gvG3GroupBlock.real_cnt)
			{
				break;
			}
		}
	}

	private IEnumerator GetAllMeshRenderers()
	{
		MeshRenderer[] renderers = TeamContainer.GetComponentsInChildren<MeshRenderer>();
		yield return null;
		int count = 0;
		Dictionary<string, List<MeshRenderer>> renderer_Dict = new Dictionary<string, List<MeshRenderer>>();
		MeshRenderer[] array = renderers;
		foreach (MeshRenderer mr in array)
		{
			Transform transform = ((Component)mr).transform;
			transform.localPosition += RandomSolfierDeltaPos();
			if (!renderer_Dict.TryGetValue(((Object)mr).name, out var list))
			{
				list = new List<MeshRenderer>();
				renderer_Dict.Add(((Object)mr).name, list);
			}
			list.Add(mr);
			int num = count + 1;
			count = num;
			if (num > 1000)
			{
				count = 0;
				yield return null;
			}
			list = null;
		}
		ShuffleMeshRendererList(renderers);
		AllMeshRenderers = renderers;
		SoldiersMeshRenderer_Dict = renderer_Dict;
		yield return null;
	}

	private IEnumerator DuplicateTeams(Transform firstTeamTrans)
	{
		for (int i = 1; i < TeamWrapperTransform_List.Count; i++)
		{
			Transform teamTrans = Object.Instantiate<GameObject>(((Component)firstTeamTrans).gameObject).transform;
			((Object)teamTrans).name = "Team";
			teamTrans.SetParent(TeamWrapperTransform_List[i], false);
			yield return null;
		}
	}

	private Vector3 RandomSolfierDeltaPos()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		return new Vector3(Random.Range(-0.2f, 0.2f), 0f, Random.Range(-0.2f, 0.2f));
	}

	private void AdjustFormationSize(Transform square, float BlockWidth = 1.3333334f, float diff_size = 0f)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		float num = diff_size / 195f * 2f * 2f;
		Vector3 localPosition = ((Component)square).transform.localPosition;
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
		((Component)square).transform.localPosition = localPosition;
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

	private void DetachTeamScript(Transform teamTrans)
	{
		int index = MatrixUnits.Count();
		MatrixUnits.Add(new GvG3Unit(((Component)teamTrans).gameObject, index, this));
	}

	internal void SetUIScale(float curCamSize)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		UIScale = 1f;
		GroupIcon.transform.localScale = new Vector3((float)RoleFace * UIScale, UIScale, UIScale);
	}

	public virtual void SetAnim(eAnimName animName)
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
			foreach (GvG3Unit matrixUnit in MatrixUnits)
			{
				matrixUnit.PlaySfx();
			}
			return;
		}
		foreach (GvG3Unit matrixUnit2 in MatrixUnits)
		{
			matrixUnit2.StopSfx();
		}
	}

	public void SetRoleFace(int direction)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		RoleFace = direction;
		Vector3 position = TeamContainer.transform.position;
		TeamContainer.transform.position = new Vector3(position.x, (float)RoleFace * -0.01f, position.z);
		TeamContainer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		GroupIcon.transform.localScale = new Vector3(UIScale, UIScale, UIScale);
		if (AllMeshRenderers != null)
		{
			Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
			MeshRenderer[] allMeshRenderers = AllMeshRenderers;
			foreach (MeshRenderer val in allMeshRenderers)
			{
				((Component)val).transform.rotation = rotation;
			}
		}
	}

	public void SetSpawning()
	{
		CoroutineQueue.AddCoroutine(StartSpwaning());
	}

	public void SetAppear()
	{
		IsSpwaned = true;
		Object.Destroy((Object)(object)SpwanSfx);
	}

	public virtual void SetDead()
	{
		IsDead = true;
		AvatarWrapper.FadeOut(delegate
		{
			IsDestroyed = true;
			Object.Destroy((Object)(object)((Component)this).gameObject);
		});
		if (IsCurUser)
		{
			NoticeMyLeavingToMyTarget();
			SharedMessenger.Broadcast("ON_GVG_USER_GROUP_DEAD");
		}
	}

	protected void NoticeMyLeavingToMyTarget()
	{
		if ((Object)(object)MyTarget != (Object)null && !MyTarget.IsGone)
		{
			MyTarget.IsCurUserTarget = false;
			MyTarget.SetToBeGeneral();
		}
	}

	public virtual void SetState(eGvGMode3FightingState state, float x, float y, int role, byte[] bin, int holdingSpeed)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		CurState = state;
		SetLocation(new Vector3(x / 1000f, 0f, y / 1000f));
		SetRoleFace(role);
		AvatarWrapper.SetState(state);
		IsMoving = false;
		OnReachTarget = null;
		MyTarget = null;
		switch (state)
		{
		case eGvGMode3FightingState.Born:
			SetToBeGeneral();
			SetAnim(eAnimName.idle);
			break;
		case eGvGMode3FightingState.Idle:
			SetToBeGeneral();
			SetAnim(eAnimName.idle);
			break;
		case eGvGMode3FightingState.Fighting:
		{
			GvGStateChange_Fighting gvGStateChange_Fighting = bin.Deserialize<GvGStateChange_Fighting>();
			if (gvGStateChange_Fighting.AttackTarget != -1)
			{
				int attackTarget = gvGStateChange_Fighting.AttackTarget;
				SetFightingTarget(attackTarget);
			}
			if (gvGStateChange_Fighting.hasGvGChargeCommand)
			{
				TargetPos = new Vector3(gvGStateChange_Fighting.X / 1000f, 0f, gvGStateChange_Fighting.Y / 1000f);
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
		}
		case eGvGMode3FightingState.PeaceMarching:
		case eGvGMode3FightingState.InFightingZone:
		case eGvGMode3FightingState.MovingHoldPos:
		{
			SetToBeGeneral();
			GvGStateChange_ForcePos gvGStateChange_ForcePos = bin.Deserialize<GvGStateChange_ForcePos>();
			if (gvGStateChange_ForcePos.hasForcePosition)
			{
				SetAnim(eAnimName.run);
				TargetPos = new Vector3(gvGStateChange_ForcePos.X / 1000f, 0f, gvGStateChange_ForcePos.Y / 1000f);
				Speed = MarchingSpeed;
				IsMoving = true;
			}
			break;
		}
		case eGvGMode3FightingState.Holding:
			SetToBeGeneral();
			SetAnim(eAnimName.idle);
			AvatarWrapper.SetHoldingScorePerSecond(holdingSpeed);
			break;
		case eGvGMode3FightingState.Invulnerable:
			break;
		}
	}

	protected virtual void SetFightingTarget(int targetId)
	{
		CoroutineQueue.AddCoroutine(SetFightingTargetCoroutine(targetId));
	}

	private IEnumerator SetFightingTargetCoroutine(int attackTargetId)
	{
		GvG3Group curUserGroup = null;
		GvG3Group userTargetGroup = null;
		if (IsCurUser)
		{
			curUserGroup = this;
			yield return GvG3IslandController.Instance.GetGroupById_WaitUntilSpwan(attackTargetId, delegate(GvG3Group g)
			{
				userTargetGroup = g;
			});
		}
		else
		{
			userTargetGroup = this;
			yield return GvG3IslandController.Instance.GetGroupById_WaitUntilSpwan(attackTargetId, delegate(GvG3Group g)
			{
				curUserGroup = g;
			});
			if ((Object)(object)curUserGroup == (Object)null || !curUserGroup.IsCurUser)
			{
				yield break;
			}
		}
		curUserGroup.SetToBeMe();
		MyTarget = userTargetGroup;
		userTargetGroup.IsCurUserTarget = true;
		userTargetGroup.SetToBeTarget();
	}

	public void SetToBeGeneral()
	{
		AvatarWrapper.SetToBeGeneral();
		AvatarUIPanel.SetSortingOrder(1, true);
	}

	public void SetToBeMe()
	{
		AvatarWrapper.SetToBeMeVfx();
		AvatarUIPanel.SetSortingOrder(3, true);
	}

	public void SetToBeTarget()
	{
		AvatarWrapper.SetToBeTargetVfx();
		AvatarUIPanel.SetSortingOrder(2, true);
	}

	public void SetSoldierNum(int soldierRemaining)
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
		foreach (GvG3Unit matrixUnit in MatrixUnits)
		{
			matrixUnit.CheckSoldierCount();
		}
	}

	private IEnumerator StartSpwaning()
	{
		yield return (object)new WaitForSeconds(0.1f);
		SpwanSfx.SetActive(true);
		yield return (object)new WaitForSeconds(0.2f);
		IsSpwaned = true;
		yield return (object)new WaitForSeconds(1.3f);
		Object.Destroy((Object)(object)SpwanSfx);
	}

	private void Update()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (IsMoving)
		{
			if (Vector3.Distance(((Component)this).transform.localPosition, TargetPos) < 0.001f)
			{
				SetLocation(TargetPos);
				IsMoving = false;
				OnReachTarget?.Invoke();
				OnReachTarget = null;
			}
			else
			{
				float num = Speed * Time.deltaTime;
				SetLocation(Vector3.MoveTowards(((Component)this).transform.localPosition, TargetPos, num));
			}
		}
	}

	protected void SetLocation(Vector3 position)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.localPosition = position;
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
