using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.Talent;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UnityEngine;

namespace GvG3;

public class GvGTalent勘探强化Manager : Singleton<GvGTalent勘探强化Manager>
{
	public enum eResourceState
	{
		Init,
		Blink,
		Destroy
	}

	[ProtoContract]
	public class SaveData
	{
		public const string SaveDataKey = "GvGTalent勘探强化Manager.SaveDataKey";

		[ProtoMember(1)]
		public int IZId = -1;

		[ProtoMember(2)]
		public string IZConfigId = "";

		[ProtoMember(3)]
		public bool HasReadNotice = false;

		[ProtoMember(4, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.IslandResource_勘探强化")]
		public List<IslandResource_勘探强化> IslandResources_List = new List<IslandResource_勘探强化>();
	}

	private bool HasReadNotice;

	private float ResourceBlinkTimePercent;

	private Dictionary<string, ShipCountDown_勘探强化> ShipCountDown_Dict;

	private Dictionary<int, IslandResource_勘探强化> IslandResource_Dict;

	private List<IslandResource_勘探强化> ResourceCountDown_List;

	public Action OnChangeShipCountDown = delegate
	{
	};

	public override void InitInstance()
	{
		GvGMode3ObserverRecord observerRecord = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;
		SaveData typeFromProtoBase = GameLocalDataManager.GetTypeFromProtoBase64("GvGTalent勘探强化Manager.SaveDataKey", () => new SaveData());
		ResourceCountDown_List = new List<IslandResource_勘探强化>();
		IslandResource_Dict = new Dictionary<int, IslandResource_勘探强化>();
		HasReadNotice = false;
		ResourceBlinkTimePercent = TalentEvent.GetConfig<勘探强化>().ResourceBlinkTimePercent;
		if (observerRecord.IZConfigId == typeFromProtoBase.IZConfigId && observerRecord.CurIZId == typeFromProtoBase.IZId)
		{
			HasReadNotice = typeFromProtoBase.HasReadNotice;
			List<IslandResource_勘探强化> islandResources_List = typeFromProtoBase.IslandResources_List;
			if (islandResources_List.Count > 0)
			{
				HashSet<int> hashSet = new HashSet<int>();
				foreach (IslandResource_勘探强化 item in islandResources_List)
				{
					IslandResource_Dict[item.IslandId] = item;
					if (!hashSet.Contains(item.EndTimestamp))
					{
						hashSet.Add(item.EndTimestamp);
						ResourceCountDown_List.Add(item);
					}
				}
			}
			StartTimeCounting();
		}
		SharedMessenger.AddListener<int>("GVG3_TALENT_ACTIVATED", OnTalentsChange);
	}

	private void OnTalentsChange(int talentIdx)
	{
		if (talentIdx == 424)
		{
			SyncShipCountDown();
		}
	}

	private void Save()
	{
		GvGMode3ObserverRecord observerRecord = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;
		SaveData value = new SaveData
		{
			IZConfigId = observerRecord.IZConfigId,
			IZId = observerRecord.CurIZId,
			HasReadNotice = HasReadNotice,
			IslandResources_List = new List<IslandResource_勘探强化>(IslandResource_Dict.Values)
		};
		GameLocalDataManager.SetTypeToProtoBase64("GvGTalent勘探强化Manager.SaveDataKey", value);
		PlayerPrefs.Save();
	}

	private void StartTimeCounting()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		if (ResourceCountDown_List.Count > 0 && !Timers.inst.Exists(new TimerCallback(CheckTimeCounting)))
		{
			Timers.inst.Add(1f, 0, new TimerCallback(CheckTimeCounting));
		}
	}

	private void CheckTimeCounting(object param)
	{
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		for (int num = ResourceCountDown_List.Count - 1; num >= 0; num--)
		{
			IslandResource_勘探强化 islandResource_勘探强化 = ResourceCountDown_List[num];
			if (islandResource_勘探强化.IsExpired())
			{
				ResourceCountDown_List.RemoveAt(num);
				List<IslandResource_勘探强化> list = new List<IslandResource_勘探强化>(IslandResource_Dict.Values);
				foreach (IslandResource_勘探强化 item in list)
				{
					if (item.EndTimestamp != islandResource_勘探强化.EndTimestamp)
					{
						continue;
					}
					IslandResource_Dict.Remove(item.IslandId);
					if (GvGWorldMapController.IsInstanceCreated)
					{
						IslandController islandController = GvGWorldMapController.Instance.LoaderManager.GetIslandController(item.IslandId);
						if (!((Object)(object)islandController == (Object)null))
						{
							islandController.OnChangeDetectedResource(eResourceState.Destroy);
						}
					}
				}
			}
			else if (islandResource_勘探强化.GetPassedCountdownPecent() >= ResourceBlinkTimePercent && GvGWorldMapController.IsInstanceCreated)
			{
				List<IslandResource_勘探强化> list2 = new List<IslandResource_勘探强化>(IslandResource_Dict.Values);
				foreach (IslandResource_勘探强化 item2 in list2)
				{
					if (item2.EndTimestamp == islandResource_勘探强化.EndTimestamp)
					{
						IslandController islandController2 = GvGWorldMapController.Instance.LoaderManager.GetIslandController(item2.IslandId);
						if (!((Object)(object)islandController2 == (Object)null))
						{
							islandController2.OnChangeDetectedResource(eResourceState.Blink);
						}
					}
				}
			}
		}
		if (ResourceCountDown_List.Count == 0)
		{
			Timers.inst.Remove(new TimerCallback(CheckTimeCounting));
		}
	}

	public bool IsActive()
	{
		return Singleton<WorldStateManager>.Instance.Data.Talents.HasTalent(eTalent.勘探强化);
	}

	public bool IsLoaded()
	{
		return ShipCountDown_Dict != null;
	}

	public bool HasNotice()
	{
		return !HasReadNotice && IsActive();
	}

	public ShipCountDown_勘探强化 GetShipCountDown(string shipId)
	{
		ShipCountDown_Dict.TryGetValue(shipId, out var value);
		return value ?? new ShipCountDown_勘探强化
		{
			ShipId = shipId,
			StartTimestamp = -2,
			EndTimestamp = -1
		};
	}

	public IslandResource_勘探强化 GetIslandResource(int islandId)
	{
		IslandResource_Dict.TryGetValue(islandId, out var value);
		if (value != null && value.IsExpired())
		{
			IslandResource_Dict.Remove(value.IslandId);
			return null;
		}
		return value;
	}

	public void SyncShipCountDown()
	{
		if (!IsActive())
		{
			ShipCountDown_Dict = new Dictionary<string, ShipCountDown_勘探强化>();
			OnChangeShipCountDown?.Invoke();
			return;
		}
		Singleton<WorldStateManager>.Instance.GetTalent勘探强化CountDown(delegate(C2S_GetTalent勘探强化CountDown.Response res)
		{
			ShipCountDown_Dict = new Dictionary<string, ShipCountDown_勘探强化>();
			if (res.ShipCountDown_List != null)
			{
				foreach (ShipCountDown_勘探强化 shipCountDown_ in res.ShipCountDown_List)
				{
					ShipCountDown_Dict[shipCountDown_.ShipId] = shipCountDown_;
				}
			}
			OnChangeShipCountDown?.Invoke();
		});
	}

	public void DetectIslandResource(string shipId)
	{
		if (!IsLoaded())
		{
			return;
		}
		if (ShipCountDown_Dict.TryGetValue(shipId, out var value) && value.EndTimestamp > (int)GameController.Instance.GetServerRealtimeSeconds())
		{
			ILRuntimeDebug.LogError($"[GvGTalent勘探强化Manager] 飞空艇的冷却还没结束 shipId={shipId} EndTimestamp={value.EndTimestamp}");
			return;
		}
		ShipStateModel myshipState = Singleton<WorldStateManager>.Instance.TryGetMyShip(shipId);
		if (myshipState == null)
		{
			ILRuntimeDebug.LogError("[GvGTalent勘探强化Manager] 飞空艇ShipStateModel shipId=" + shipId);
			return;
		}
		int entityId = myshipState.EntityId;
		ShipController shipController = GvGWorldMapController.Instance.LoaderManager.GetShipController(entityId);
		if ((Object)(object)shipController == (Object)null)
		{
			ILRuntimeDebug.LogError($"[GvGTalent勘探强化Manager] DetectIslandResource 找不到ShipController entityId={entityId}");
		}
		else
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(StartDetectIslandResource());
		}
		IEnumerator StartDetectIslandResource()
		{
			GvGWorldMapController.Instance.FocusShipByEntityId(entityId, 0.4f);
			yield return (object)new WaitForSeconds(0.4f);
			Vector3 shipPos = ((Component)shipController).transform.localPosition;
			_ = (int)(shipPos.x * 1000f);
			_ = (int)(shipPos.z * 1000f);
			C2S_UseTalent勘探强化Detect.Response response = null;
			Singleton<WorldStateManager>.Instance.UseTalent勘探强化Detect(entityId, delegate(C2S_UseTalent勘探强化Detect.Response res)
			{
				response = res;
			});
			while (response == null)
			{
				yield return null;
			}
			if (response.ErrorCode >= 0 && GvGWorldMapController.IsInstanceCreated)
			{
				HasReadNotice = true;
				ShipCountDown_Dict[response.ShipCountDown.ShipId] = response.ShipCountDown;
				OnChangeShipCountDown?.Invoke();
				GameObject effect = GvGWorldMapController.Instance.InstantiateFromPrefab("ScanIsland");
				effect.transform.SetParent(((Component)GvGWorldMapController.Instance).gameObject.transform, false);
				effect.transform.localPosition = new Vector3((float)response.X / 1000f, shipPos.y, (float)response.Y / 1000f);
				effect.transform.localScale = Vector3.one * myshipState.ShipSightRange;
				effect.SetActive(true);
				Timers.inst.Add(2.3f, 1, (TimerCallback)delegate
				{
					if ((Object)(object)effect != (Object)null)
					{
						Object.Destroy((Object)(object)effect);
					}
				});
				yield return (object)new WaitForSeconds(1f);
				if (GvGWorldMapController.IsInstanceCreated)
				{
					List<IslandResource_勘探强化> rcList = response.IslandResource_List;
					if (rcList != null && rcList.Count > 0)
					{
						ResourceCountDown_List.Add(rcList.First());
						foreach (IslandResource_勘探强化 rc in rcList)
						{
							IslandResource_Dict[rc.IslandId] = rc;
						}
						StartTimeCounting();
						yield return null;
						if (GvGWorldMapController.IsInstanceCreated)
						{
							foreach (IslandResource_勘探强化 rc2 in rcList)
							{
								IslandController islandController = GvGWorldMapController.Instance.LoaderManager.GetIslandController(rc2.IslandId);
								islandController.OnChangeDetectedResource(eResourceState.Init);
								yield return (object)new WaitForSeconds(0.05f);
								if (!GvGWorldMapController.IsInstanceCreated)
								{
									yield break;
								}
							}
							yield return (object)new WaitForSeconds(1f);
							Save();
						}
					}
				}
			}
		}
	}
}
