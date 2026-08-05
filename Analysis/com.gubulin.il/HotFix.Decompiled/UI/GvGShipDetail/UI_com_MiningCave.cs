using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Spine.Unity;
using UnityEngine;

namespace UI.GvGShipDetail;

public class UI_com_MiningCave : GComponent
{
	public GImage n177;

	public GGraph SpineLoader_Port;

	public GGraph r0_0;

	public GGraph r0_1;

	public GGraph r0_2;

	public GGraph r0_3;

	public GGraph r1_0;

	public GGraph r1_1;

	public GGraph r1_2;

	public GGraph r2_0;

	public GGraph r2_1;

	public GGraph r2_2;

	public GGraph r2_3;

	public GGraph rr0_0;

	public GGraph rr0_1;

	public GGraph rr1_0;

	public GGraph rr1_1;

	public UI_com_MiningWorker Worker0;

	public UI_com_MiningWorker Worker1;

	public UI_com_MiningWorker Worker2;

	public UI_com_MiningWorker Worker3;

	public UI_com_MiningWorker Worker4;

	public GImage n179;

	public UI_com_MiningWorker Worker5;

	public UI_com_MiningWorker Worker6;

	public UI_com_MiningWorker Worker7;

	public UI_com_MiningWorker Worker8;

	public UI_com_MiningWorker Worker9;

	public GImage n180;

	public UI_com_MiningWorker Worker10;

	public UI_com_MiningWorker Worker11;

	public UI_com_MiningWorker Worker12;

	public UI_com_MiningWorker Worker13;

	public UI_com_MiningWorker Worker14;

	public GImage n178;

	public const string URL = "ui://u6x0b1gnnk3v73";

	public static string Name = "UI_com_MiningCave";

	private List<UI_com_MiningWorker> Workers;

	private int ShipEntityId;

	private List<List<Vector2>> Routes;

	private List<List<Vector2>> RandomRoutes;

	private Coroutine Coroutine;

	private GameObject PortSpineObj;

	private long NextSyncTimestamp;

	public bool IsRunning = false;

	private const int DelayTimes = 3;

	private int delay = 0;

	public static string GetURL()
	{
		return "ui://u6x0b1gnnk3v73";
	}

	public static UI_com_MiningCave CreateInstance()
	{
		return (UI_com_MiningCave)(object)UIPackage.CreateObject("GvGShipDetail", "com_MiningCave");
	}

	public static UI_com_MiningCave CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MiningCave).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnnk3v73", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
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
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n177 = (GImage)((GComponent)this).GetChild("n177");
		SpineLoader_Port = (GGraph)((GComponent)this).GetChild("SpineLoader_Port");
		r0_0 = (GGraph)((GComponent)this).GetChild("r0_0");
		r0_1 = (GGraph)((GComponent)this).GetChild("r0_1");
		r0_2 = (GGraph)((GComponent)this).GetChild("r0_2");
		r0_3 = (GGraph)((GComponent)this).GetChild("r0_3");
		r1_0 = (GGraph)((GComponent)this).GetChild("r1_0");
		r1_1 = (GGraph)((GComponent)this).GetChild("r1_1");
		r1_2 = (GGraph)((GComponent)this).GetChild("r1_2");
		r2_0 = (GGraph)((GComponent)this).GetChild("r2_0");
		r2_1 = (GGraph)((GComponent)this).GetChild("r2_1");
		r2_2 = (GGraph)((GComponent)this).GetChild("r2_2");
		r2_3 = (GGraph)((GComponent)this).GetChild("r2_3");
		rr0_0 = (GGraph)((GComponent)this).GetChild("rr0_0");
		rr0_1 = (GGraph)((GComponent)this).GetChild("rr0_1");
		rr1_0 = (GGraph)((GComponent)this).GetChild("rr1_0");
		rr1_1 = (GGraph)((GComponent)this).GetChild("rr1_1");
		Worker0 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker0");
		Worker1 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker1");
		Worker2 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker2");
		Worker3 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker3");
		Worker4 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker4");
		n179 = (GImage)((GComponent)this).GetChild("n179");
		Worker5 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker5");
		Worker6 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker6");
		Worker7 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker7");
		Worker8 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker8");
		Worker9 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker9");
		n180 = (GImage)((GComponent)this).GetChild("n180");
		Worker10 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker10");
		Worker11 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker11");
		Worker12 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker12");
		Worker13 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker13");
		Worker14 = (UI_com_MiningWorker)(object)((GComponent)this).GetChild("Worker14");
		n178 = (GImage)((GComponent)this).GetChild("n178");
	}

	public void Init(int shipEntityId)
	{
		S2C_CanNotCollecting.OnPushEvent = (Action<S2C_CanNotCollecting.Request>)Delegate.Combine(S2C_CanNotCollecting.OnPushEvent, new Action<S2C_CanNotCollecting.Request>(OnCanNotCollecting));
		IsRunning = true;
		ShipEntityId = shipEntityId;
		Routes = GetRoutesByPrefix("r");
		RandomRoutes = GetRoutesByPrefix("rr");
		Workers = new List<UI_com_MiningWorker>();
		int num = 0;
		while (true)
		{
			UI_com_MiningWorker uI_com_MiningWorker = (UI_com_MiningWorker)(object)((GComponent)this).GetChild($"Worker{num}");
			if (uI_com_MiningWorker == null)
			{
				break;
			}
			uI_com_MiningWorker.Init(num, Routes, RandomRoutes, this);
			Workers.Add(uI_com_MiningWorker);
			num++;
		}
		Coroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetData());
		PortSpineObj = UiHelper.LoadSpine_AB(((GObject)SpineLoader_Port).asGraph, "chuansongmen", 100f, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "chuansongmen");
			animation.AnimationState.SetAnimation(0, "chuansongmen", true);
		});
		((GObject)n178).sortingOrder = (int)((GObject)n178).y;
		((GObject)n179).sortingOrder = (int)((GObject)n179).y;
		((GObject)n180).sortingOrder = (int)((GObject)n180).y;
	}

	private List<List<Vector2>> GetRoutesByPrefix(string prefix)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		List<List<Vector2>> list = new List<List<Vector2>>();
		for (int i = 0; ((GComponent)this).GetChild($"{prefix}{i}_{0}") != null; i++)
		{
			list.Add(new List<Vector2>());
			int num = 0;
			while (true)
			{
				GObject child = ((GComponent)this).GetChild($"{prefix}{i}_{num}");
				if (child == null)
				{
					break;
				}
				list[i].Add(child.xy);
				num++;
			}
		}
		return list;
	}

	private void OnCanNotCollecting(S2C_CanNotCollecting.Request request)
	{
		int canNotCollectingReason = request.CanNotCollectingReason;
		$"GvG3CanNotCollectingReason_{canNotCollectingReason}".ToLanguage().ToConfirmPopup(null, null, (AlignType)0, 40, mirrorBtns: false, needCancelButton: false);
	}

	public void StopMining()
	{
		OnDestroy();
	}

	private IEnumerator GetData()
	{
		while (!((GObject)this).isDisposed)
		{
			long now = (long)(GameController.Instance.GetServerRealtimeSeconds() * 1000.0);
			if (now > NextSyncTimestamp)
			{
				NextSyncTimestamp = now + 30000;
				SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_SyncShipCollectingProduceState
				{
					Req = new C2S_SyncShipCollectingProduceState.Request
					{
						ShipEntityId = ShipEntityId
					}
				}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
				{
					C2S_SyncShipCollectingProduceState.Response response = (C2S_SyncShipCollectingProduceState.Response)context_response.Resp;
					if (response.ErrorCode != 0)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
					}
					else if (!((GObject)this).isDisposed)
					{
						if (response.WorkersProduceStates == null || response.WorkersProduceStates.Count == 0)
						{
							delay++;
							NextSyncTimestamp = now + 1000;
						}
						else
						{
							delay = 0;
							OnCollectingSync(response.WorkersProduceStates ?? new List<ProduceState>());
							if (response.WorkersProduceStates != null)
							{
								foreach (ProduceState workersProduceState in response.WorkersProduceStates)
								{
									if (workersProduceState.ProduceEndAt < NextSyncTimestamp)
									{
										NextSyncTimestamp = workersProduceState.ProduceEndAt;
									}
								}
							}
						}
					}
				});
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
	}

	private void OnCollectingSync(List<ProduceState> dataList)
	{
		int count = dataList.Count;
		for (int i = 0; i < Workers.Count; i++)
		{
			if (i < count)
			{
				Workers[i].SetProduceState(dataList[i]);
			}
			else
			{
				Workers[i].Deactivate();
			}
		}
	}

	public void OnDestroy()
	{
		IsRunning = false;
		if ((Object)(object)PortSpineObj != (Object)null)
		{
			Object.Destroy((Object)(object)PortSpineObj);
			PortSpineObj = null;
		}
		if (Coroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(Coroutine);
			Coroutine = null;
		}
		foreach (UI_com_MiningWorker worker in Workers)
		{
			worker.Destroy();
		}
		Workers.Clear();
		S2C_CanNotCollecting.OnPushEvent = (Action<S2C_CanNotCollecting.Request>)Delegate.Remove(S2C_CanNotCollecting.OnPushEvent, new Action<S2C_CanNotCollecting.Request>(OnCanNotCollecting));
	}
}
