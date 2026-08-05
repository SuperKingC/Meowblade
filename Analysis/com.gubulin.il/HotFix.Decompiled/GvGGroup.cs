using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FairyGUI;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvG.Scripts;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using Spine;
using Spine.Unity;
using UI.LordOfDreams;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class GvGGroup : MonoBehaviour
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

	public bool IsBoss = false;

	public bool IsCurUser = false;

	public List<GvGUnit> MatrixUnits;

	public Transform GroupCollider;

	private Dictionary<string, List<MeshRenderer>> Cache_GvGMR;

	private Dictionary<string, Texture2D> Cache_AnimMap;

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

	public GvGGroupBlock blockInfo;

	private Vector3 BornPos;

	public List<UnitInfo_Protocol> UnitsInfo;

	private Coroutine CommandCoroutine;

	private List<AnimMaterial> SharedAnimMaterials;

	public SkeletonAnimation BossAnimation;

	private GvGBossUnit BossUnit;

	private UI_GvGAvatarWrapper AvatarWrapper;

	private GvGGroupSoldiers groupSoldiers;

	public int RoleFace;

	private float UIScale;

	private eGvGRole Role = eGvGRole.NotInit;

	private eAnimName CurAnimName;

	public List<Transform> AllUnitsTransform;

	private Vector3 FirstUnitFigthingPos;

	private Vector3 IslandIconTarget;

	private Vector3 IslandIconPos;

	private CoroutineQueue CoroutineQueue;

	private CoroutineQueue LoadingCoroutineQueue;

	private bool IsStartFighting;

	private long LastCommandFrame;

	public bool HasAniMapSoldier()
	{
		if (Cache_GvGMR != null)
		{
			return true;
		}
		return false;
	}

	private void Awake()
	{
		Cache_GvGMR = null;
		Cache_AnimMap = new Dictionary<string, Texture2D>();
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
		MatrixUnits = new List<GvGUnit>();
		SharedAnimMaterials = new List<AnimMaterial>();
		LastUpdateServerTime = -1L;
		CurAnimName = eAnimName.idle;
		RoleFace = 1;
		UIScale = 1f;
		IsDestroyed = false;
		IsDead = false;
		LastUpdateDetailServerTime = 0L;
		GroupCollider = ((Component)this).gameObject.transform.Find("GroupCollider");
		CommandCoroutine = null;
		groupSoldiers = new GvGGroupSoldiers(this);
		AllUnitsTransform = null;
		blockInfo = new GvGGroupBlock();
		CoroutineQueue = new CoroutineQueue();
		LoadingCoroutineQueue = new CoroutineQueue();
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
		if (IsBoss)
		{
			BossUnit?.Destroy();
		}
		if (MatrixUnits.Count > 0)
		{
			foreach (GvGUnit matrixUnit in MatrixUnits)
			{
				matrixUnit.OnDestroy();
			}
		}
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_GvGAvatarWrapper.Name);
	}

	internal void SetGroupDataToUI(BroadcastGroupInitInfo group_data)
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		UIPanel component = AvatarIcon.GetComponent<UIPanel>();
		BoxCollider[] components = ((Component)component).GetComponents<BoxCollider>();
		component.packageName = "LordOfDreams";
		component.componentName = "GvGAvatarWrapper";
		if (IsCurUser)
		{
			component.SetSortingOrder(2, true);
		}
		if (IsBoss)
		{
			component.SetSortingOrder(-1, true);
		}
		component.CreateUI();
		AvatarWrapper = (UI_GvGAvatarWrapper)(object)component.ui;
		AvatarWrapper.Init(group_data);
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

	public void SetIsBoss(bool b)
	{
		IsBoss = b;
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
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		UnitsInfo = _UnitsInfo;
		string wBId = GvGWorldController.Instance.ProcessInfo.BossInfo.WBId;
		GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(wBId);
		if (IsBoss)
		{
			go_UnitGroupWrapper.SetActive(true);
			blockInfo.InitBossBlock(gvGWorldBossInfoByWBId.teamCount);
			AdjustFormationSize(go_Units.transform);
			GroupIcon.transform.localPosition = Vector3.zero;
		}
		else
		{
			blockInfo.InitPlayerBlock(GetMaxRealCnt(_UnitsInfo));
			AdjustFormationSize(go_Units.transform);
			float num = blockInfo.groupRect.maxZ - blockInfo.unitWidthZ / 2f;
			float num2 = blockInfo.groupRect.maxX - blockInfo.unitWidthX / 2f;
			AdjustUnitsMarchingTarget(num2, blockInfo.unitWidthX);
			GroupIcon.transform.localPosition = new Vector3(num2, 0f, num);
		}
		IslandIconPos = GroupIconWrapper.transform.position;
	}

	public void SetFormation(string formationId)
	{
		FormationId = formationId;
	}

	public void UpdateMapViewLevel(eMapViewLevel viewLevel)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		switch (viewLevel)
		{
		case eMapViewLevel.BattleField:
			if (!IsBoss)
			{
				GroupIconWrapper.transform.localPosition = Vector3.zero;
			}
			go_UnitGroups.SetActive(true);
			if (!HasAniMapSoldier())
			{
				Cache_GvGMR = new Dictionary<string, List<MeshRenderer>>();
				if (IsBoss)
				{
					generateBoss(UnitsInfo);
					break;
				}
				AvatarWrapper.OnLODChange_Player(0);
				generateUnits(UnitsInfo);
			}
			break;
		case eMapViewLevel.Island:
			if (!IsBoss)
			{
				GroupIconWrapper.transform.position = IslandIconTarget;
				AvatarWrapper.OnLODChange_Player(1);
			}
			go_UnitGroups.SetActive(false);
			break;
		}
	}

	private void generateUnits(List<UnitInfo_Protocol> _UnitsInfo)
	{
		List<Transform> list = new List<Transform>();
		foreach (UnitInfo_Protocol item in _UnitsInfo)
		{
			GameObject gameObject = ((Component)go_Units.transform.Find("Unit" + item.PosId)).gameObject;
			gameObject.SetActive(true);
			list.Add(gameObject.transform);
		}
		_generateMinSizeSoldiers(list, _UnitsInfo);
		_generateAllSoldiers(go_Units.transform);
	}

	private void _generateMinSizeSoldiers(List<Transform> activeUnits, List<UnitInfo_Protocol> SoldierInfos, float randPosAmplitude = 0f)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < SoldierInfos.Count; i++)
		{
			UnitInfo_Protocol unitInfo_Protocol = SoldierInfos[i];
			if (!Cache_GvGMR.ContainsKey(unitInfo_Protocol.SoldierId))
			{
				Cache_GvGMR.Add(unitInfo_Protocol.SoldierId, new List<MeshRenderer>());
			}
			string finalSoldierID = GetFinalSoldierID(unitInfo_Protocol.SoldierId);
			string soldierSkin = GetSoldierSkin(unitInfo_Protocol.SoldierId, unitInfo_Protocol.PotentialLevel);
			string text = "GvGAniMapSoldier/" + finalSoldierID + "_" + soldierSkin + "_";
			string text2 = $"{text}{CurAnimName}";
			unitInfo_Protocol.AnimMapPrefix = text;
			float num = GDMgr.Get<GDESoldierData>(finalSoldierID).Radius * 0.9f;
			GameObject val = Addressables.LoadAssetAsync<GameObject>((object)text2).WaitForCompletion();
			Texture2D val2 = Addressables.LoadAssetAsync<Texture2D>((object)$"{text}{CurAnimName}_AnimMap").WaitForCompletion();
			MeshRenderer component = val.GetComponent<MeshRenderer>();
			Material material = ((Renderer)component).material;
			material.shader = GvGWorldController.Instance.AnimMapShader;
			material.SetTexture("_AnimMap", (Texture)(object)val2);
			material.SetTexture("_NoiseMap", (Texture)(object)GvGWorldController.Instance.NoiseTexture);
			material.SetFloat("_RandPosAmplitude", randPosAmplitude);
			SharedAnimMaterials.Add(new AnimMaterial
			{
				skinName = text,
				material = ((Renderer)component).material
			});
			Cache_GvGMR[SoldierInfos[i].SoldierId].Add(component);
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
					GameObject val3 = Object.Instantiate<GameObject>(val, activeUnits[i]);
					num9++;
					((Object)val3).name = $"{SoldierInfos[i].SoldierId}_{num9}";
					val3.transform.localPosition = new Vector3(num8 - (float)j * num6, 0f, num7 - (float)k * num5);
					float num10 = 0.9f;
					if (unitInfo_Protocol.IsBossUnit)
					{
						num10 *= 2f;
					}
					val3.transform.localScale = new Vector3(-1f, 1.414f, 1.414f) * num10;
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
		GvGGroupBlock gvGGroupBlock = blockInfo;
		float num = gvGGroupBlock.groupRect.maxZ - gvGGroupBlock.unitWidthZ / 2f;
		float num2 = gvGGroupBlock.groupRect.maxX - gvGGroupBlock.unitWidthX / 2f;
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
		for (int i = 1; i < gvGGroupBlock.teamCount; i++)
		{
			GameObject val2 = new GameObject($"units_wrap_{i}");
			val2.transform.SetParent(parent);
			list.Add(val2.transform);
		}
		LoadingCoroutineQueue.AddCoroutine(CloneFromTemplateUnits(new List<Transform> { _units }, list, 1));
		for (int j = 0; j < gvGGroupBlock._x_cnt; j++)
		{
			if (j == gvGGroupBlock._x_cnt - 1)
			{
				gvGGroupBlock.unitWidthZ = 1f * gvGGroupBlock.groupWidthZ / (float)(gvGGroupBlock.real_cnt - num3);
				num = (float)(gvGGroupBlock.real_cnt - num3) * gvGGroupBlock.unitWidthZ / 2f - gvGGroupBlock.unitWidthZ / 2f;
			}
			for (int k = 0; k < gvGGroupBlock._z_cnt; k++)
			{
				GameObject gameObject = ((Component)list[num3]).gameObject;
				num3++;
				gameObject.transform.localPosition = new Vector3(num2 - (float)j * gvGGroupBlock.unitWidthX, 0f, num - (float)k * gvGGroupBlock.unitWidthZ);
				AddMatrixUnits(gameObject);
				if (num3 >= gvGGroupBlock.real_cnt)
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
		if (!IsBoss)
		{
			groupSoldiers.InitSoldierPosIdMap(allUnitsTransform);
		}
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
		GvGUnit item = new GvGUnit(_go, index, this);
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
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		CurAnimName = animName;
		foreach (AnimMaterial sharedAnimMaterial in SharedAnimMaterials)
		{
			string text = $"{sharedAnimMaterial.skinName}{CurAnimName}_AnimMap";
			if (!Cache_AnimMap.TryGetValue(text, out var value))
			{
				value = Addressables.LoadAssetAsync<Texture2D>((object)text).WaitForCompletion();
				Cache_AnimMap.Add(text, value);
			}
			sharedAnimMaterial.material.SetTexture("_AnimMap", (Texture)(object)value);
		}
		if (IsBoss)
		{
			SetBossAnim();
		}
		else
		{
			if (animName != eAnimName.attack || MatrixUnits.Count <= 0)
			{
				return;
			}
			foreach (GvGUnit matrixUnit in MatrixUnits)
			{
				matrixUnit.PlaySfx();
			}
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

	public void SetMarching(MarchingCommandInfo cmd, long curServerTime)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		if (cmd.Frame > LastCommandFrame)
		{
			LastCommandFrame = cmd.Frame;
			if (GvGWorldController.Instance.Dict_GvGGroup.TryGetValue(cmd.TargetId.ToString(), out var value))
			{
				Transform transform = ((Component)GvGWorldController.Instance.WorldMapSize).transform;
				float x = Target0Trasnform.localPosition.x;
				Vector3 val = default(Vector3);
				((Vector3)(ref val))._002Ector(cmd.StartPosX, 0f, cmd.StartPosY);
				Vector3 val2 = default(Vector3);
				((Vector3)(ref val2))._002Ector(cmd.EndX, 0f, cmd.EndY);
				FirstUnitFigthingPos = ((Component)GvGWorldController.Instance.WorldMapSize).transform.TransformPoint(val2);
				float z = ((Component)value).transform.localPosition.z;
				IslandIconTarget = transform.TransformPoint(new Vector3(cmd.NoR_EndX, 0f, (cmd.NoR_EndY - z) * 1.414f + z));
				Vector3 val3 = val2 - val;
				float x2 = val3.x;
				float num = value.blockInfo.groupWidthX / 2f + 2f + x;
				float num2 = ((Component)value).transform.localPosition.x - num;
				float num3 = num2 - val.x;
				Vector3 val4 = val3 * (num3 / x2);
				Vector3 targetPos = val + val4;
				float speed = cmd.Speed;
				speed = GvGConfigHelper.GvGConfig.speed;
				CoroutineQueue.AddCoroutine(MoveToTarget(val, targetPos, speed));
				CoroutineQueue.AddCoroutine(MoveToPreFightingPos(speed));
				CoroutineQueue.AddCoroutine(MoveToFightingPos(speed, value));
			}
		}
	}

	public void SetFighting(FightingCommandInfo cmd, long curServerTime)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		if (cmd.Frame > LastCommandFrame)
		{
			LastCommandFrame = cmd.Frame;
			GvGGroup value;
			if (IsBoss)
			{
				SetAnim(eAnimName.attack);
			}
			else if (GvGWorldController.Instance.Dict_GvGZone.TryGetValue(cmd.ZoneId, out value))
			{
				Transform transform = ((Component)GvGWorldController.Instance.WorldMapSize).transform;
				float z = ((Component)value).transform.localPosition.z;
				FirstUnitFigthingPos = transform.TransformPoint(new Vector3(cmd.R_X, 0f, cmd.R_Y));
				IslandIconTarget = transform.TransformPoint(new Vector3(cmd.NoR_X, 0f, (cmd.NoR_Y - z) * 1.414f + z));
				CoroutineQueue.AddCoroutine(MoveToFightingPos(0f, value, isImmediate: true));
			}
		}
	}

	public void SetMarchingToFighting(MarchingCommandInfo cmd, long curServerTime)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		if (cmd.Frame > LastCommandFrame)
		{
			LastCommandFrame = cmd.Frame;
			if (GvGWorldController.Instance.Dict_GvGGroup.TryGetValue(cmd.TargetId.ToString(), out var value))
			{
				Transform transform = ((Component)GvGWorldController.Instance.WorldMapSize).transform;
				float z = ((Component)value).transform.localPosition.z;
				FirstUnitFigthingPos = transform.TransformPoint(new Vector3(cmd.EndX, 0f, cmd.EndY));
				IslandIconTarget = transform.TransformPoint(new Vector3(cmd.NoR_EndX, 0f, (cmd.NoR_EndY - z) * 1.414f + z));
				CoroutineQueue.AddCoroutine(MoveToFightingPos(0f, value, isImmediate: true));
			}
		}
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
			SharedMessenger.Broadcast("ON_GVG_USER_GROUP_DEAD");
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

	private IEnumerator MoveToTarget(Vector3 startPos, Vector3 targetPos, float speed)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (speed == 0f)
		{
			yield break;
		}
		SetAnim(eAnimName.run);
		IsStartFighting = false;
		Vector3 delta = targetPos - startPos;
		float totalMovingTime = ((Vector3)(ref delta)).magnitude / speed;
		float curMovingTime = 0f;
		float unitsTotalMovingTime = GvGConfigHelper.GvGConfig.phase1_queeze_time;
		Vector3 iconStart = GroupIcon.transform.position;
		Vector3 iconDelta = IslandIconTarget - iconStart;
		for (; curMovingTime < totalMovingTime; curMovingTime += Time.deltaTime)
		{
			((Component)this).transform.localPosition = startPos + delta * (curMovingTime / totalMovingTime);
			if (MatrixUnits.Count > 0)
			{
				GroupLocalMoveToTarget(curMovingTime, unitsTotalMovingTime);
				Transform frontUnitTrans = MatrixUnits[0].GO.transform;
				GroupIconWrapper.transform.localPosition = Vector3.zero;
				GroupIcon.transform.localPosition = Vector3.Lerp(GroupIcon.transform.localPosition, frontUnitTrans.localPosition, 15f * Time.deltaTime);
			}
			else
			{
				float percent = curMovingTime / totalMovingTime;
				if (percent > 1f)
				{
					percent = 1f;
				}
				IslandIconPos = iconStart + iconDelta * percent;
				GroupIconWrapper.transform.position = IslandIconPos;
			}
			CamFollow(GroupIcon.transform.localPosition);
			yield return null;
		}
		((Component)this).transform.localPosition = targetPos;
	}

	private void GroupLocalMoveToTarget(float curMovingTime, float unitsTotalMovingTime)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		foreach (GvGUnit matrixUnit in MatrixUnits)
		{
			if (curMovingTime < unitsTotalMovingTime)
			{
				float num = curMovingTime / unitsTotalMovingTime;
				float num2 = num;
				matrixUnit.GO.transform.localPosition = matrixUnit.MarchingDelta * num2 + matrixUnit.StartPos;
			}
			else
			{
				matrixUnit.GO.transform.localPosition = matrixUnit.MarchingPos;
			}
		}
	}

	private IEnumerator MoveToPreFightingPos(float speed)
	{
		speed *= GvGConfigHelper.GvGConfig.phase2_speed_power;
		float curMovingTime = 0f;
		bool isUnitMovingInit = false;
		while (true)
		{
			bool allReachPreFighting;
			if (MatrixUnits.Count > 0)
			{
				if (!isUnitMovingInit)
				{
					isUnitMovingInit = true;
					foreach (GvGUnit _unit in MatrixUnits)
					{
						_unit.MarchingPos = _unit.GO.transform.localPosition;
						_unit.PreFightingDelta = _unit.PreFightingPos - _unit.MarchingPos;
						_unit.TotalPreFightingMoveTime = ((Vector3)(ref _unit.PreFightingDelta)).magnitude / speed;
					}
				}
				allReachPreFighting = true;
				foreach (GvGUnit _unit2 in MatrixUnits)
				{
					if (curMovingTime < _unit2.TotalPreFightingMoveTime)
					{
						allReachPreFighting = false;
						_unit2.GO.transform.localPosition = _unit2.MarchingPos + _unit2.PreFightingDelta * (curMovingTime / _unit2.TotalPreFightingMoveTime);
					}
					else
					{
						_unit2.GO.transform.localPosition = _unit2.PreFightingPos;
					}
				}
				Transform frontUnitTrans = MatrixUnits[0].GO.transform;
				GroupIconWrapper.transform.localPosition = Vector3.zero;
				GroupIcon.transform.localPosition = Vector3.Lerp(GroupIcon.transform.localPosition, frontUnitTrans.localPosition, 10f * Time.deltaTime);
			}
			else
			{
				IslandIconPos = IslandIconTarget;
				GroupIconWrapper.transform.position = IslandIconPos;
				allReachPreFighting = curMovingTime > 1.5f;
			}
			CamFollow(GroupIcon.transform.localPosition);
			if (allReachPreFighting)
			{
				break;
			}
			yield return null;
			curMovingTime += Time.deltaTime;
		}
		yield return (object)new WaitForSeconds(GvGConfigHelper.GvGConfig.phase2_3_waiting_time);
	}

	private IEnumerator MoveToFightingPos(float speed, GvGGroup targetGroup, bool isImmediate = false)
	{
		if (IsStartFighting || targetGroup.IsDead)
		{
			yield break;
		}
		speed *= GvGConfigHelper.GvGConfig.phase3_speed_power;
		IsStartFighting = true;
		go_UnitGroupWrapper.SetActive(true);
		AvatarWrapper.OnStartFighting(!isImmediate);
		if (IsCurUser)
		{
			SharedMessenger.Broadcast("ON_GVG_USER_GROUP_FIGHTING", isImmediate);
		}
		GroupIconWrapper.transform.position = IslandIconTarget;
		Vector3 camTargetPos = (FirstUnitFigthingPos + ((Component)targetGroup).transform.position) * 0.5f;
		if (isImmediate)
		{
			CamTarget.transform.position = camTargetPos;
		}
		float curMovingTime = 0f;
		while (MatrixUnits.Count == 0 || targetGroup.MatrixUnits.Count == 0)
		{
			if (targetGroup.IsDead)
			{
				yield break;
			}
			yield return null;
			curMovingTime += Time.deltaTime;
		}
		MatrixUnits[0].SetFightingPos(FirstUnitFigthingPos);
		int i = 0;
		while (i < MatrixUnits.Count)
		{
			MatrixUnits[i].SetFightingTargetGroup(targetGroup);
			int num = i + 1;
			i = num;
		}
		((Component)this).transform.position = FirstUnitFigthingPos;
		while (true)
		{
			if (targetGroup.IsDead)
			{
				yield break;
			}
			if (MatrixUnits.Count > 0 && targetGroup.MatrixUnits.Count > 0)
			{
				int reachedCount = 0;
				int i2 = 0;
				while (i2 < MatrixUnits.Count)
				{
					int num;
					if (MatrixUnits[i2].Move(curMovingTime, speed, isImmediate))
					{
						num = reachedCount + 1;
						reachedCount = num;
					}
					num = i2 + 1;
					i2 = num;
				}
				Transform frontUnitTrans = MatrixUnits[0].GO.transform;
				GroupIconWrapper.transform.localPosition = Vector3.zero;
				GroupIcon.transform.position = frontUnitTrans.position;
				if (isImmediate)
				{
					CamTarget.transform.position = camTargetPos;
				}
				else
				{
					CamTarget.transform.position = Vector3.Lerp(CamTarget.transform.position, camTargetPos, 5f * Time.deltaTime);
				}
				if (reachedCount == MatrixUnits.Count)
				{
					break;
				}
			}
			yield return null;
			curMovingTime += Time.deltaTime;
		}
		CamTarget.transform.position = camTargetPos;
		SetAnim(eAnimName.attack);
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

	private void generateBoss(List<UnitInfo_Protocol> _UnitsInfo)
	{
		((Object)((Component)this).gameObject).name = "GvGGroup_Boss";
		_generateBossSpineAnimation(go_UnitGroups.transform, _UnitsInfo.First((UnitInfo_Protocol _info) => _info.IsBossUnit));
		List<Transform> list = new List<Transform>();
		foreach (UnitInfo_Protocol item in _UnitsInfo)
		{
			GameObject gameObject = ((Component)go_Units.transform.Find("Unit" + item.PosId)).gameObject;
			gameObject.SetActive(true);
			list.Add(gameObject.transform);
		}
		_generateMinSizeSoldiers(list, _UnitsInfo, 0.7f);
		List<Transform> templateUnits = new List<Transform> { go_Units.transform };
		_generateBoss(templateUnits);
	}

	public void _generateBoss(List<Transform> templateUnits)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		GvGGroupBlock gvGGroupBlock = blockInfo;
		GvGRect bossRect = blockInfo.bossRect;
		GvGRect groupRect = blockInfo.groupRect;
		float num = groupRect.maxZ - gvGGroupBlock.unitWidthZ / 2f;
		float num2 = groupRect.maxX - gvGGroupBlock.unitWidthX / 2f;
		int num3 = 0;
		Transform val = templateUnits[0];
		GameObject val2 = new GameObject($"units_wrap_{0}");
		Transform parent = val.parent;
		val2.transform.SetParent(parent);
		val2.transform.localScale = Vector3.one;
		((Object)((Component)val).gameObject).name = "units";
		val.SetParent(val2.transform);
		val.localPosition = Vector3.zero;
		List<Transform> list = new List<Transform> { val2.transform };
		for (int i = templateUnits.Count; i < gvGGroupBlock.teamCount; i++)
		{
			GameObject val3 = new GameObject($"units_wrap_{i}");
			val3.transform.SetParent(parent);
			val3.transform.localScale = Vector3.one;
			list.Add(val3.transform);
		}
		LoadingCoroutineQueue.AddCoroutine(CloneFromTemplateUnits(templateUnits, list, 10, useRandom: true));
		string wBId = GvGWorldController.Instance.ProcessInfo.BossInfo.WBId;
		GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(wBId);
		int num4 = Mathf.CeilToInt((float)(gvGGroupBlock._x_cnt / 2 - gvGWorldBossInfoByWBId.bossBlockSizeX / 2));
		int num5 = num4 + gvGWorldBossInfoByWBId.bossBlockSizeX;
		int num6 = Mathf.CeilToInt((float)(gvGGroupBlock._z_cnt / 2 - gvGWorldBossInfoByWBId.bossBlockSizeZ / 2)) + 1;
		int num7 = num6 + gvGWorldBossInfoByWBId.bossBlockSizeZ;
		for (int j = 0; j < gvGGroupBlock._x_cnt; j++)
		{
			if (j == gvGGroupBlock._x_cnt - 1)
			{
				gvGGroupBlock.unitWidthZ = 1f * gvGGroupBlock.groupWidthZ / (float)(gvGGroupBlock.real_cnt - num3);
				num = (float)(gvGGroupBlock.real_cnt - num3) * gvGGroupBlock.unitWidthZ / 2f - gvGGroupBlock.unitWidthZ / 2f;
			}
			for (int k = 0; k < gvGGroupBlock._z_cnt; k++)
			{
				if (num3 >= list.Count)
				{
					break;
				}
				GameObject gameObject = ((Component)list[num3]).gameObject;
				num3++;
				if (j < num4 || j >= num5 || k < num6 || k >= num7)
				{
					gameObject.transform.localPosition = new Vector3(num2 - (float)j * gvGGroupBlock.unitWidthX, 0f, num - (float)k * gvGGroupBlock.unitWidthZ);
					AddMatrixUnits(gameObject);
				}
			}
		}
	}

	private void _generateBossSpineAnimation(Transform untis, UnitInfo_Protocol info)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		string skin = GetSoldierSkin(info.SoldierId, info.PotentialLevel);
		string finalSoldierID = GetFinalSoldierID(info.SoldierId);
		GameObject unitModel = Addressables.InstantiateAsync((object)"ModelAnimation", untis, false, true).WaitForCompletion();
		((Object)unitModel).name = "ModelAnimation_" + info.SoldierId;
		SkeletonAnimation _animation = unitModel.GetComponent<SkeletonAnimation>();
		AddMatrixUnits(unitModel);
		NotHotFixSpawnManager.Instance.LoadAnimation(finalSoldierID, false).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			((SkeletonRenderer)_animation).skeletonDataAsset = asset;
			if ((Object)(object)((SkeletonRenderer)_animation).skeletonDataAsset != (Object)null)
			{
				AtlasAsset[] atlasAssets = ((SkeletonRenderer)_animation).skeletonDataAsset.atlasAssets;
				foreach (AtlasAsset val in atlasAssets)
				{
					if ((Object)(object)val != (Object)null)
					{
						val.Clear();
					}
				}
			}
			AnimationStateData animationStateData = ((SkeletonRenderer)_animation).SkeletonDataAsset.GetAnimationStateData();
			if (animationStateData.SkeletonData.Skins.Count > 0)
			{
				((SkeletonRenderer)_animation).initialSkinName = animationStateData.SkeletonData.Skins.Items[0].Name;
			}
			((SkeletonRenderer)_animation).Initialize(true);
			if (_animation.AnimationState != null)
			{
				SpineHelper.SetSkin((ISkeletonAnimation)(object)_animation, skin);
			}
			string wBId = GvGWorldController.Instance.ProcessInfo.BossInfo.WBId;
			GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(wBId);
			float scale = gvGWorldBossInfoByWBId.battlefield.scale;
			float modelOffsetX = gvGWorldBossInfoByWBId.battlefield.modelOffsetX;
			float modelOffsetZ = gvGWorldBossInfoByWBId.battlefield.modelOffsetZ;
			unitModel.transform.localPosition = new Vector3(modelOffsetX, 1f, modelOffsetZ);
			unitModel.transform.localScale = new Vector3(1f, 1.4141f, 1.414f) * scale;
			BossAnimation = _animation;
			BossUnit = new GvGBossUnit(wBId, this, BossAnimation);
			SetBossAnim();
		}, (Action<Exception>)delegate
		{
		});
	}

	private void SetBossAnim()
	{
		BossUnit?.StartAnimation(CurAnimName);
	}
}
