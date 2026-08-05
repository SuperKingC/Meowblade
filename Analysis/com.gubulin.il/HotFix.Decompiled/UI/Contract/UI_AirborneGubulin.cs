using System;
using FairyGUI;
using FairyGUI.Utils;
using Spine.Unity;
using UnityEngine;

namespace UI.Contract;

public class UI_AirborneGubulin : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n5;

	public GGraph carrier;

	public GGraph WorkerLoader;

	public Transition left_handed;

	public Transition right_handed;

	public const string URL = "ui://avplaivdi7untks";

	public static string Name = "UI_AirborneGubulin";

	private const float AirborneHeight = 833f;

	private string _explosionSfxName { get; set; }

	private Action _action { get; set; }

	public static string GetURL()
	{
		return "ui://avplaivdi7untks";
	}

	public static UI_AirborneGubulin CreateInstance()
	{
		return (UI_AirborneGubulin)(object)UIPackage.CreateObject("Contract", "AirborneGubulin");
	}

	public static UI_AirborneGubulin CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AirborneGubulin).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdi7untks", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		carrier = (GGraph)((GComponent)this).GetChild("carrier");
		WorkerLoader = (GGraph)((GComponent)this).GetChild("WorkerLoader");
		left_handed = ((GComponent)this).GetTransition("left-handed");
		right_handed = ((GComponent)this).GetTransition("right-handed");
	}

	public void Gubulin_Init(Vector2 startPos, string sfxName, Action action)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)this).isDisposed)
		{
			return;
		}
		_explosionSfxName = sfxName;
		_action = action;
		((GObject)this).SetScale(0.25f, 0.25f);
		LoadSkeleon(WorkerLoader, "Goblinworker_001", 50f, -1, "run");
		((GComponent)UnityUiService.Instance.maskCover).AddChild((GObject)(object)this);
		Vector2 val = TransformLocalPos(startPos);
		Vector2 localPos = startPos + new Vector2(0f, 833f);
		Vector2 val2 = TransformLocalPos(localPos);
		((GObject)this).SetXY(val.x, val.y);
		Type.selectedIndex = 0;
		right_handed.Play(-1, 0f, (PlayCompleteCallback)null);
		((GObject)this).TweenMove(val2, 0.5f).OnComplete((GTweenCallback)delegate
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			if (!((GObject)this).isDisposed)
			{
				right_handed.Stop();
				FGUIManager.Instance.AddTextSpecialEffects(carrier, _explosionSfxName, new Vector3(120f, 120f, 120f));
				Type.selectedIndex = 1;
				_action?.Invoke();
				Gubulin_Run();
			}
		});
		((GObject)this).TweenScale(Vector2.one, 0.5f);
	}

	public SkeletonAnimation LoadSkeleon(GGraph graph, string soldierId, float spineScale, int dir, string animationName)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		((GObject)graph).displayObject.Dispose();
		Object obj = Object.Instantiate(Resources.Load("SpineTest"));
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		SkeletonAnimation animation = ((val != null) ? val.GetComponent<SkeletonAnimation>() : null);
		SpawnManager.Instance.LoadAnimation(soldierId).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if ((Object)(object)asset != (Object)null && (Object)(object)animation != (Object)null && !((GObject)this).isDisposed)
			{
				((SkeletonRenderer)animation).skeletonDataAsset = asset;
				((SkeletonRenderer)animation).Initialize(true);
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin_default");
				animation.AnimationState.AddAnimation(1, animationName, true, 0f);
				animation.timeScale = 1.5f;
			}
		});
		if ((Object)(object)val != (Object)null)
		{
			val.transform.localScale = new Vector3(spineScale, spineScale, spineScale);
			val.transform.localPosition = -new Vector3(0f, 0f, 0f);
			val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val2 = new GoWrapper(val);
			((DisplayObject)val2).SetXY(0f, 0f);
			((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val2).scaleX = dir;
			graph.SetNativeObject((DisplayObject)(object)val2);
		}
		return animation;
	}

	private void Gubulin_Run()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			return;
		}
		float num = ((GObject)this).x + ((GObject)GRoot.inst).width;
		((GObject)this).TweenMoveX(num, 2f).OnComplete((GTweenCallback)delegate
		{
			if (!((GObject)this).isDisposed)
			{
				Destroy();
			}
		});
	}

	private Vector2 TransformLocalPos(Vector2 localPos)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return localPos;
	}

	public void Destroy()
	{
		if (!((GObject)this).isDisposed)
		{
			((GComponent)UnityUiService.Instance.maskCover).RemoveChild((GObject)(object)this, true);
		}
	}
}
