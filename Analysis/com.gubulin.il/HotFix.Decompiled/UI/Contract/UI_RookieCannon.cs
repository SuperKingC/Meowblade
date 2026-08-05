using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace UI.Contract;

public class UI_RookieCannon : GButton
{
	public Controller button;

	public GGraph graph;

	public GGraph CannonWrapper;

	public Transition Fire;

	public const string URL = "ui://avplaivdi7untkq";

	public static string Name = "UI_RookieCannon";

	private const string CardCannonName = "card_cannon";

	private SkeletonAnimation cardCannonSkeletonAnimation;

	private const float CardCannonSize = 100f;

	private const string CannonOpen = "open";

	private const string CannonWork = "work";

	private const string CannonClose = "close";

	private const string SkinName = "skin2";

	private bool SkipFire { get; set; }

	public static string GetURL()
	{
		return "ui://avplaivdi7untkq";
	}

	public static UI_RookieCannon CreateInstance()
	{
		return (UI_RookieCannon)(object)UIPackage.CreateObject("Contract", "RookieCannon");
	}

	public static UI_RookieCannon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RookieCannon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdi7untkq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		graph = (GGraph)((GComponent)this).GetChild("graph");
		CannonWrapper = (GGraph)((GComponent)this).GetChild("CannonWrapper");
		Fire = ((GComponent)this).GetTransition("Fire");
	}

	public void CardCannonOpen()
	{
		if (!((GObject)this).isDisposed && !SkipFire)
		{
			cardCannonSkeletonAnimation = UiHelper.SpineLoad(CannonWrapper, "card_cannon", 100f, "skin2", "open", null, isMask: false, aniLoop: false);
		}
	}

	public void CardCannonWork()
	{
		if (((GObject)this).isDisposed || SkipFire)
		{
			return;
		}
		Fire.Play();
		SkeletonAnimation obj = cardCannonSkeletonAnimation;
		if (obj != null)
		{
			AnimationState animationState = obj.AnimationState;
			if (animationState != null)
			{
				animationState.SetAnimation(0, "work", false);
			}
		}
	}

	public void CardCannonClose()
	{
		if (((GObject)this).isDisposed || SkipFire)
		{
			return;
		}
		SkeletonAnimation obj = cardCannonSkeletonAnimation;
		if (obj != null)
		{
			AnimationState animationState = obj.AnimationState;
			if (animationState != null)
			{
				animationState.ClearTracks();
			}
		}
		SkeletonAnimation obj2 = cardCannonSkeletonAnimation;
		if (obj2 != null)
		{
			AnimationState animationState2 = obj2.AnimationState;
			if (animationState2 != null)
			{
				animationState2.SetAnimation(0, "close", false);
			}
		}
	}

	public void CardCannonSkip()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		SkipFire = true;
		if (!Object.op_Implicit((Object)(object)cardCannonSkeletonAnimation))
		{
			cardCannonSkeletonAnimation = UiHelper.SpineLoad(CannonWrapper, "card_cannon", 100f, "skin2", "close", null, isMask: false, aniLoop: false);
		}
		SkeletonAnimation obj = cardCannonSkeletonAnimation;
		if (obj != null)
		{
			AnimationState animationState = obj.AnimationState;
			if (animationState != null)
			{
				animationState.SetAnimation(0, "close", false);
			}
		}
		if (cardCannonSkeletonAnimation?.state != null)
		{
			cardCannonSkeletonAnimation.state.GetCurrent(0).AnimationStart = 0.5f;
		}
	}
}
