using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Spine.Unity;
using UnityEngine;

namespace UI.GvGShipDetail;

public class UI_com_OarDeck : GComponent
{
	public GImage back;

	public GGraph TrackLoader0;

	public GGraph TrackLoader1;

	public GGraph TrackLoader2;

	public GGraph Worker0;

	public GGraph Worker1;

	public GGraph Worker2;

	public GGraph Worker3;

	public GGraph Worker4;

	public GImage n108;

	public GGraph Worker5;

	public GGraph Worker6;

	public GGraph Worker7;

	public GGraph Worker8;

	public GGraph Worker9;

	public GImage n110;

	public GGraph Worker10;

	public GGraph Worker11;

	public GGraph Worker12;

	public GGraph Worker13;

	public GGraph Worker14;

	public GImage n109;

	public GImage n105;

	public GImage n106;

	public GImage n107;

	public Transition t0;

	public const string URL = "ui://u6x0b1gnsayz75";

	public static string Name = "UI_com_OarDeck";

	private int WorkersOnboardCount;

	private List<OarDeckWorker> Workers;

	private Coroutine Coroutine;

	private float NextChooseTime;

	private List<GameObject> TrackSpineObj_List;

	public static string GetURL()
	{
		return "ui://u6x0b1gnsayz75";
	}

	public static UI_com_OarDeck CreateInstance()
	{
		return (UI_com_OarDeck)(object)UIPackage.CreateObject("GvGShipDetail", "com_OarDeck");
	}

	public static UI_com_OarDeck CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OarDeck).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnsayz75", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		TrackLoader0 = (GGraph)((GComponent)this).GetChild("TrackLoader0");
		TrackLoader1 = (GGraph)((GComponent)this).GetChild("TrackLoader1");
		TrackLoader2 = (GGraph)((GComponent)this).GetChild("TrackLoader2");
		Worker0 = (GGraph)((GComponent)this).GetChild("Worker0");
		Worker1 = (GGraph)((GComponent)this).GetChild("Worker1");
		Worker2 = (GGraph)((GComponent)this).GetChild("Worker2");
		Worker3 = (GGraph)((GComponent)this).GetChild("Worker3");
		Worker4 = (GGraph)((GComponent)this).GetChild("Worker4");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		Worker5 = (GGraph)((GComponent)this).GetChild("Worker5");
		Worker6 = (GGraph)((GComponent)this).GetChild("Worker6");
		Worker7 = (GGraph)((GComponent)this).GetChild("Worker7");
		Worker8 = (GGraph)((GComponent)this).GetChild("Worker8");
		Worker9 = (GGraph)((GComponent)this).GetChild("Worker9");
		n110 = (GImage)((GComponent)this).GetChild("n110");
		Worker10 = (GGraph)((GComponent)this).GetChild("Worker10");
		Worker11 = (GGraph)((GComponent)this).GetChild("Worker11");
		Worker12 = (GGraph)((GComponent)this).GetChild("Worker12");
		Worker13 = (GGraph)((GComponent)this).GetChild("Worker13");
		Worker14 = (GGraph)((GComponent)this).GetChild("Worker14");
		n109 = (GImage)((GComponent)this).GetChild("n109");
		n105 = (GImage)((GComponent)this).GetChild("n105");
		n106 = (GImage)((GComponent)this).GetChild("n106");
		n107 = (GImage)((GComponent)this).GetChild("n107");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(int entityId)
	{
		WorkersOnboardCount = Singleton<WorldStateManager>.Instance.TryGetShip(entityId).WorkersOnboardCount;
		Workers = new List<OarDeckWorker>();
		int num = 0;
		while (true)
		{
			GObject child = ((GComponent)this).GetChild($"Worker{num}");
			if (child == null)
			{
				break;
			}
			Workers.Add(new OarDeckWorker(child.asGraph, num < WorkersOnboardCount));
			num++;
		}
		TrackSpineObj_List = new List<GameObject>();
		int activeTrackCount = Mathf.CeilToInt((float)WorkersOnboardCount / 5f);
		int i = 0;
		while (true)
		{
			GObject child2 = ((GComponent)this).GetChild($"TrackLoader{i}");
			if (child2 == null)
			{
				break;
			}
			TrackSpineObj_List.Add(UiHelper.LoadSpine_AB(child2.asGraph, "chuansongdai", 60f, delegate(SkeletonAnimation animation)
			{
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin_chuangsongdai");
				if (i < activeTrackCount)
				{
					animation.AnimationState.SetAnimation(0, "work", true);
				}
				else
				{
					animation.AnimationState.SetAnimation(0, "stop", true);
				}
			}));
			int num2 = i + 1;
			i = num2;
		}
		Coroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RandomChooseWorkers());
	}

	private IEnumerator RandomChooseWorkers()
	{
		while (true)
		{
			if (Time.time > NextChooseTime)
			{
				NextChooseTime = Time.time + Random.Range(3f, 15f);
				int max = Mathf.Max(1, Mathf.FloorToInt((float)WorkersOnboardCount / 4f));
				int randNum = Random.Range(0, max + 1);
				int i = 0;
				while (i < randNum)
				{
					Workers[Random.Range(0, WorkersOnboardCount)].StartSlackingOff();
					int num = i + 1;
					i = num;
				}
			}
			yield return null;
		}
	}

	public void OnDestroy()
	{
		((MonoBehaviour)FGUIManager.Instance).StopCoroutine(Coroutine);
		foreach (OarDeckWorker worker in Workers)
		{
			worker.Destroy();
		}
		foreach (GameObject trackSpineObj_ in TrackSpineObj_List)
		{
			Object.Destroy((Object)(object)trackSpineObj_);
		}
	}
}
