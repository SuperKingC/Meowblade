using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.GvGOuterTech;
using UnityEngine;

namespace UI.GvGExpeditionHall;

public class UI_com_OuterTechEntryBtn : GComponent
{
	public Controller IsAvailable;

	public Controller NoticeType;

	public Controller AccStatus;

	public GImage n125;

	public GImage n127;

	public GGroup n139;

	public GImage n137;

	public GImage n138;

	public GImage n134;

	public GImage n135;

	public GGroup n136;

	public GGroup n148;

	public GImage n146;

	public GImage n147;

	public GImage n133;

	public GImage n149;

	public GImage n126;

	public GTextField n117;

	public GGraph SpineLoader;

	public GGroup n130;

	public GImage n128;

	public GImage n119;

	public GTextField n120;

	public GImage n121;

	public GTextField n122;

	public GTextField Level;

	public GTextField Points;

	public GGroup n129;

	public GImage n131;

	public UI_com_01 n132;

	public UI_com_02 n151;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://k19peou7u2yw1b";

	public static string Name = "UI_com_OuterTechEntryBtn";

	private readonly List<GameObject> _aniObjs = new List<GameObject>(1);

	public static string GetURL()
	{
		return "ui://k19peou7u2yw1b";
	}

	public static UI_com_OuterTechEntryBtn CreateInstance()
	{
		return (UI_com_OuterTechEntryBtn)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_OuterTechEntryBtn");
	}

	public static UI_com_OuterTechEntryBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OuterTechEntryBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7u2yw1b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsAvailable = ((GComponent)this).GetController("IsAvailable");
		NoticeType = ((GComponent)this).GetController("NoticeType");
		AccStatus = ((GComponent)this).GetController("AccStatus");
		n125 = (GImage)((GComponent)this).GetChild("n125");
		n127 = (GImage)((GComponent)this).GetChild("n127");
		n139 = (GGroup)((GComponent)this).GetChild("n139");
		n137 = (GImage)((GComponent)this).GetChild("n137");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		n136 = (GGroup)((GComponent)this).GetChild("n136");
		n148 = (GGroup)((GComponent)this).GetChild("n148");
		n146 = (GImage)((GComponent)this).GetChild("n146");
		n147 = (GImage)((GComponent)this).GetChild("n147");
		n133 = (GImage)((GComponent)this).GetChild("n133");
		n149 = (GImage)((GComponent)this).GetChild("n149");
		n126 = (GImage)((GComponent)this).GetChild("n126");
		n117 = (GTextField)((GComponent)this).GetChild("n117");
		string id = "ui://k19peou7u2yw1b".Replace("ui://", "") + "-" + ((GObject)n117).id;
		((GObject)n117).text = LanguagesManager.GetDesc(id);
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		n130 = (GGroup)((GComponent)this).GetChild("n130");
		n128 = (GImage)((GComponent)this).GetChild("n128");
		n119 = (GImage)((GComponent)this).GetChild("n119");
		n120 = (GTextField)((GComponent)this).GetChild("n120");
		string id2 = "ui://k19peou7u2yw1b".Replace("ui://", "") + "-" + ((GObject)n120).id;
		((GObject)n120).text = LanguagesManager.GetDesc(id2);
		n121 = (GImage)((GComponent)this).GetChild("n121");
		n122 = (GTextField)((GComponent)this).GetChild("n122");
		string id3 = "ui://k19peou7u2yw1b".Replace("ui://", "") + "-" + ((GObject)n122).id;
		((GObject)n122).text = LanguagesManager.GetDesc(id3);
		Level = (GTextField)((GComponent)this).GetChild("Level");
		Points = (GTextField)((GComponent)this).GetChild("Points");
		n129 = (GGroup)((GComponent)this).GetChild("n129");
		n131 = (GImage)((GComponent)this).GetChild("n131");
		n132 = (UI_com_01)(object)((GComponent)this).GetChild("n132");
		n151 = (UI_com_02)(object)((GComponent)this).GetChild("n151");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}

	public void Init()
	{
		if (Singleton<GvGOuterTechManager>.Instance.IsAvailable)
		{
			IsAvailable.selectedIndex = 1;
			((GObject)this).touchable = true;
			OnNoticeChange();
			LoadSpine();
			AccStatus.selectedIndex = 0;
		}
		else
		{
			IsAvailable.selectedIndex = 0;
			((GObject)this).touchable = false;
		}
	}

	public void OnDestroy()
	{
		UnloadSpine();
	}

	public void RegisterUiEventListeners()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OnClickEntryBtn));
		GvGOuterTechManager instance = Singleton<GvGOuterTechManager>.Instance;
		instance.OnNoticeChange = (Action)Delegate.Combine(instance.OnNoticeChange, new Action(OnNoticeChange));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)this).onClick.Clear();
		GvGOuterTechManager instance = Singleton<GvGOuterTechManager>.Instance;
		instance.OnNoticeChange = (Action)Delegate.Remove(instance.OnNoticeChange, new Action(OnNoticeChange));
	}

	private void OnNoticeChange()
	{
		if (Singleton<GvGMode3RoomManager>.Instance.ObserverRecord != null)
		{
			UpdateNotice();
		}
		else
		{
			Singleton<GvGMode3RoomManager>.Instance.GetGSObserverRecord(UpdateNotice);
		}
	}

	private void OnClickEntryBtn()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGOuterTechPanel.Name, null);
	}

	private void UpdateNotice()
	{
		NoticeType.selectedIndex = 0;
		if (Singleton<GvGOuterTechManager>.Instance.HasRedDot)
		{
			if (Singleton<GvGOuterTechManager>.Instance.HasDrawChance)
			{
				NoticeType.selectedIndex = 1;
			}
			else if (Singleton<GvGOuterTechManager>.Instance.HasPushedGiftBag)
			{
				NoticeType.selectedIndex = 2;
			}
		}
	}

	private void LoadSpine()
	{
		GameObject item = UiHelper.LoadSpine_AB(SpineLoader, "yuanzhengdatingtx2", 100f, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "daiji", true);
		});
		_aniObjs.Add(item);
	}

	private void UnloadSpine()
	{
		foreach (GameObject aniObj in _aniObjs)
		{
			if ((Object)(object)aniObj != (Object)null)
			{
				Object.Destroy((Object)(object)aniObj);
			}
		}
		_aniObjs.Clear();
	}
}
