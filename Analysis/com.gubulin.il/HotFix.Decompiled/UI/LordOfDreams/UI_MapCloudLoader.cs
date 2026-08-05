using System;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Spine;
using Spine.Unity;

namespace UI.LordOfDreams;

public class UI_MapCloudLoader : GComponent
{
	public Controller StageController;

	public GGraph ClickMask;

	public GGraph Mask;

	public GGraph MapCloud;

	public UI_MapCloudTime MapCloudTime;

	public Transition ZeroToOne;

	public Transition OneToZero;

	public const string URL = "ui://0i520nzmh82loe8";

	public static string Name = "UI_MapCloudLoader";

	private AnimationState MapCloudState;

	private TrackEntry MapCloudTrackEntry;

	public static string GetURL()
	{
		return "ui://0i520nzmh82loe8";
	}

	public static UI_MapCloudLoader CreateInstance()
	{
		return (UI_MapCloudLoader)(object)UIPackage.CreateObject("LordOfDreams", "MapCloudLoader");
	}

	public static UI_MapCloudLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MapCloudLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmh82loe8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		StageController = ((GComponent)this).GetController("StageController");
		ClickMask = (GGraph)((GComponent)this).GetChild("ClickMask");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		MapCloud = (GGraph)((GComponent)this).GetChild("MapCloud");
		MapCloudTime = (UI_MapCloudTime)(object)((GComponent)this).GetChild("MapCloudTime");
		ZeroToOne = ((GComponent)this).GetTransition("ZeroToOne");
		OneToZero = ((GComponent)this).GetTransition("OneToZero");
	}

	public void PlayStageChange2to3()
	{
		if (MapCloudState != null)
		{
			MapCloudState.SetAnimation(0, "gvg_change", false);
			return;
		}
		UiHelper.LoadSpine_AB(MapCloud, "Map_Cloud", 80f, delegate(SkeletonAnimation animation)
		{
			MapCloudState = animation.AnimationState;
			MapCloudTrackEntry = MapCloudState.SetAnimation(0, "gvg_change", false);
		}, isMask: true);
	}

	public void ShowMapCloud(int rebornTimeStamp, bool skip = false)
	{
		int num = (int)GameController.Instance.GetServerTime();
		int timeLeft = 0;
		UpdateIsland7BossRebornTime(timeLeft);
		if (MapCloudState != null)
		{
			return;
		}
		GTweenCallback val = default(GTweenCallback);
		UiHelper.LoadSpine_AB(MapCloud, "Map_Cloud", 80f, delegate(SkeletonAnimation animation)
		{
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Expected O, but got Unknown
			//IL_00c5: Expected O, but got Unknown
			MapCloudState = animation.AnimationState;
			MapCloudTrackEntry = MapCloudState.SetAnimation(0, "gvg_change", false);
			if (skip)
			{
				MapCloudTrackEntry.AnimationStart = 0.75f;
				MapCloudTrackEntry.AnimationLast = 0.75f;
				MapCloudState.TimeScale = 0f;
				StageController.selectedIndex = 1;
			}
			else
			{
				GTweener obj = ((GComponent)(object)this).SetTimeout(0.75f);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						StageController.selectedIndex = 1;
						MapCloudState.TimeScale = 0f;
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				obj.OnComplete(obj2);
			}
		}, isMask: true);
	}

	public void MapCloudDisappear(Action action)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		StageController.selectedIndex = 0;
		if (MapCloudState != null)
		{
			MapCloudState.TimeScale = 1f;
		}
		((GComponent)(object)this).SetTimeout(2.25f).OnComplete((GTweenCallback)delegate
		{
			action?.Invoke();
		});
	}

	public void UpdateIsland7BossRebornTime(int timeLeft)
	{
		if (StageController.selectedIndex == 1)
		{
			if (timeLeft < 0)
			{
				timeLeft = 0;
			}
			((GObject)MapCloudTime.Time).text = UiHelper.ParseTime(Convert.ToInt32(timeLeft));
		}
	}
}
