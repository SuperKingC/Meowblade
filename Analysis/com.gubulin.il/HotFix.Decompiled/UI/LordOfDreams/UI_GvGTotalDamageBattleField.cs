using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_GvGTotalDamageBattleField : GComponent
{
	public Controller SfxController;

	public GMovieClip n25;

	public GImage n27;

	public GImage n20;

	public GImage n13;

	public GImage n14;

	public GImage n18;

	public GMovieClip n21;

	public GMovieClip n22;

	public GMovieClip n24;

	public GMovieClip n23;

	public GImage n8;

	public GImage n9;

	public GTextField Damage;

	public GMovieClip n10;

	public GMovieClip n11;

	public GMovieClip n12;

	public GMovieClip n15;

	public GMovieClip n16;

	public GMovieClip n17;

	public GMovieClip n19;

	public GImage n26;

	public GTextField n5;

	public GTextField SoldierNum;

	public UI_HeadPortrait Avatar;

	public GImage n30;

	public Transition D1_D2;

	public Transition D3_D6;

	public const string URL = "ui://0i520nzmj3iwobv";

	public static string Name = "UI_GvGTotalDamageBattleField";

	public long CurDamage;

	public float NextGetDataTimeStamp;

	private const float TimeInterval = 1f;

	public int EntityId;

	public string BattleId;

	public int UserId;

	public string WBId;

	private int MaxSoldierNum;

	private Coroutine BattleDamageInfoUpdateCoroutine;

	public static string ShipId;

	public static List<GvGShipRecord> ShipRecords;

	public static string GetURL()
	{
		return "ui://0i520nzmj3iwobv";
	}

	public static UI_GvGTotalDamageBattleField CreateInstance()
	{
		return (UI_GvGTotalDamageBattleField)(object)UIPackage.CreateObject("LordOfDreams", "GvGTotalDamageBattleField");
	}

	public static UI_GvGTotalDamageBattleField CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGTotalDamageBattleField).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmj3iwobv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SfxController = ((GComponent)this).GetController("SfxController");
		n25 = (GMovieClip)((GComponent)this).GetChild("n25");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n21 = (GMovieClip)((GComponent)this).GetChild("n21");
		n22 = (GMovieClip)((GComponent)this).GetChild("n22");
		n24 = (GMovieClip)((GComponent)this).GetChild("n24");
		n23 = (GMovieClip)((GComponent)this).GetChild("n23");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		Damage = (GTextField)((GComponent)this).GetChild("Damage");
		n10 = (GMovieClip)((GComponent)this).GetChild("n10");
		n11 = (GMovieClip)((GComponent)this).GetChild("n11");
		n12 = (GMovieClip)((GComponent)this).GetChild("n12");
		n15 = (GMovieClip)((GComponent)this).GetChild("n15");
		n16 = (GMovieClip)((GComponent)this).GetChild("n16");
		n17 = (GMovieClip)((GComponent)this).GetChild("n17");
		n19 = (GMovieClip)((GComponent)this).GetChild("n19");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://0i520nzmj3iwobv".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		SoldierNum = (GTextField)((GComponent)this).GetChild("SoldierNum");
		Avatar = (UI_HeadPortrait)(object)((GComponent)this).GetChild("Avatar");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		D1_D2 = ((GComponent)this).GetTransition("D1_D2");
		D3_D6 = ((GComponent)this).GetTransition("D3_D6");
	}

	public void Init(string _WBId)
	{
		WBId = _WBId;
		CurDamage = 0L;
		NextGetDataTimeStamp = -1f;
		ShipId = null;
		ShipRecords = new List<GvGShipRecord>();
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<BroadcastGroupInitInfo>("ON_GVG_USER_GROUP_CREATE", OnUserGroupCreate);
		SharedMessenger.AddListener<bool>("ON_GVG_USER_GROUP_FIGHTING", OnUserGroupFighting);
		SharedMessenger.AddListener("ON_GVG_USER_GROUP_DEAD", Destroy);
		SharedMessenger.AddListener<S2C_StartOneBattle.Request>("ON_GVG_ONE_BATTLE_START", StartOneBattle);
		SharedMessenger.AddListener<S2C_BroadcastBattleDamageInfo.Request>("ON_GVG_BROADCAST_DAMAGE", OnBroadcastDamage);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<BroadcastGroupInitInfo>("ON_GVG_USER_GROUP_CREATE", OnUserGroupCreate);
		SharedMessenger.RemoveListener<bool>("ON_GVG_USER_GROUP_FIGHTING", OnUserGroupFighting);
		SharedMessenger.RemoveListener("ON_GVG_USER_GROUP_DEAD", Destroy);
		SharedMessenger.RemoveListener<S2C_StartOneBattle.Request>("ON_GVG_ONE_BATTLE_START", StartOneBattle);
		SharedMessenger.RemoveListener<S2C_BroadcastBattleDamageInfo.Request>("ON_GVG_BROADCAST_DAMAGE", OnBroadcastDamage);
	}

	public void Destroy()
	{
		ShipId = null;
		ShipRecords.Clear();
		if (BattleDamageInfoUpdateCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(BattleDamageInfoUpdateCoroutine);
			FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
		}
	}

	private void OnUserGroupCreate(BroadcastGroupInitInfo group_data)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		EntityId = group_data.EntityId;
		UserId = group_data.UserId;
		GetCurBattleDetailInfo(group_data);
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, group_data.UserId, Avatar.icon, new GTextField()));
	}

	private void OnUserGroupFighting(bool isImmediate)
	{
		if (BattleDamageInfoUpdateCoroutine == null)
		{
			NextGetDataTimeStamp = Time.time + 1f + 1f;
			BattleDamageInfoUpdateCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(BattleDamageInfoUpdate(CurDamage, CurDamage, 0f));
		}
	}

	private void GetCurBattleDetailInfo(BroadcastGroupInitInfo group_data)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3Island).Request(new C2S_GetCurBattleDetailInfo
		{
			Req = new C2S_GetCurBattleDetailInfo.Request
			{
				EntityId = EntityId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetCurBattleDetailInfo.Response response = context_response.Resp as C2S_GetCurBattleDetailInfo.Response;
			BattleId = response.BattleId;
			ShipId = response.ShipId;
			MaxSoldierNum = response.SoldierInitValue;
			((GObject)SoldierNum).text = $"{response.SoldierRemaining}/{MaxSoldierNum}";
			CurDamage = response.Damage;
			((GObject)Damage).text = $"{response.Damage}";
			((GObject)this).visible = true;
			if (response.HistoryRecord != null)
			{
				ShipRecords = response.HistoryRecord;
			}
		});
	}

	private void GetBattleDamageInfo()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3Island).Request(new C2S_GetBattleDamageDetailInfo
		{
			Req = new C2S_GetBattleDamageDetailInfo.Request
			{
				EntityId = EntityId,
				BattleId = BattleId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetBattleDamageDetailInfo.Response response = context_response.Resp as C2S_GetBattleDamageDetailInfo.Response;
			if (!((GObject)this).isDisposed && response.ErrorCode >= 0)
			{
				if (BattleDamageInfoUpdateCoroutine != null)
				{
					((MonoBehaviour)FGUIManager.Instance).StopCoroutine(BattleDamageInfoUpdateCoroutine);
				}
				BattleDamageInfoUpdateCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(BattleDamageInfoUpdate(CurDamage, response.Damage, NextGetDataTimeStamp));
			}
		});
	}

	public void StartOneBattle(S2C_StartOneBattle.Request req)
	{
		NextGetDataTimeStamp = Time.time + 1f;
		BattleId = req.BattleId;
	}

	private void OnBroadcastDamage(S2C_BroadcastBattleDamageInfo.Request req)
	{
		if (req.DamageInfos_Dict.TryGetValue(EntityId, out var value))
		{
			ShipRecords.Add(new GvGShipRecord
			{
				BattleId = value.BattleId,
				BlueUserId = -1,
				RedUserId = UserId,
				TotalDamage = value.DamageTotal.ToString(),
				Winner = 200,
				WBId = WBId
			});
			if (BattleDamageInfoUpdateCoroutine != null)
			{
				((MonoBehaviour)FGUIManager.Instance).StopCoroutine(BattleDamageInfoUpdateCoroutine);
			}
			BattleDamageInfoUpdateCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(BattleDamageInfoUpdate(CurDamage, value.DamageTotal, NextGetDataTimeStamp));
			((GObject)SoldierNum).text = $"{value.SoldierRemaining}/{MaxSoldierNum}";
		}
	}

	private IEnumerator BattleDamageInfoUpdate(long startDamage, long nextDamage, float nexTimestamp)
	{
		if (nextDamage < CurDamage)
		{
			nextDamage = CurDamage;
		}
		while (!((GObject)this).isDisposed)
		{
			if (Time.time <= nexTimestamp)
			{
				float deltaTime = nexTimestamp - Time.time;
				CurDamage = (long)((float)(nextDamage - startDamage) * (1f - deltaTime / 1f)) + startDamage;
				((GObject)Damage).text = $"{CurDamage}";
			}
			else if (CurDamage != nextDamage)
			{
				CurDamage = nextDamage;
				((GObject)Damage).text = $"{nextDamage}";
			}
			SwitchSfxByDamage(CurDamage);
			if (NextGetDataTimeStamp != -1f && Time.time > NextGetDataTimeStamp)
			{
				NextGetDataTimeStamp += 1f;
				GetBattleDamageInfo();
			}
			yield return (object)new WaitForEndOfFrame();
		}
	}

	private void SwitchSfxByDamage(long damage)
	{
		if (damage <= 500000)
		{
			SfxController.selectedIndex = 0;
		}
		else if (damage <= 1000000)
		{
			SfxController.selectedIndex = 1;
		}
		else if (damage <= 2500000)
		{
			SfxController.selectedIndex = 2;
		}
		else if (damage <= 5000000)
		{
			SfxController.selectedIndex = 3;
		}
		else if (damage <= 10000000)
		{
			SfxController.selectedIndex = 4;
		}
		else
		{
			SfxController.selectedIndex = 5;
		}
	}
}
