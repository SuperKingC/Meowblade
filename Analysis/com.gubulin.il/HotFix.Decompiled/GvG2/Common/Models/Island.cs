using System;
using System.Collections.Generic;
using UnityEngine;

namespace GvG2.Common.Models;

public class Island
{
	public string Id;

	public IslandProps Props;

	public GameObject IslandObject;

	public GameObject IslandPlane;

	public GameObject IslandModel;

	public Collider Collider;

	public DockingManagerBase DockingManager;

	public IslandStateManager IslandStateManager;

	public Action OnChangeState = delegate
	{
	};

	private static Dictionary<IslandType, string> IslandTypeName = new Dictionary<IslandType, string>
	{
		{
			IslandType.Moon,
			"月岛"
		},
		{
			IslandType.Star,
			"星岛"
		},
		{
			IslandType.CampBase,
			"主城"
		}
	};

	public string Name => Props.Name;

	public void Init()
	{
		if (Props.Sprite == "i_big")
		{
			DockingManager = new MoonDockingManager(this);
		}
		else if (Props.Sprite == "i_small")
		{
			DockingManager = new StarDockingManager(this);
		}
		else
		{
			DockingManager = new CampDockingManager(this);
		}
	}

	public void SetState(IslandSummary islandSummary)
	{
		if (IslandStateManager == null)
		{
			IslandStateManager = new IslandStateManager(this, delegate
			{
				OnChangeState?.Invoke();
			});
		}
		IslandStateManager.SetState(islandSummary);
	}

	public void RenderIslandPlane()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = IslandPlane.transform;
		transform.localPosition = Vector3.zero;
		transform.localScale = new Vector3(Props.S, transform.localScale.y, Props.S);
		transform.rotation = Quaternion.AngleAxis(Props.Ang_Model, Vector3.up);
		Transform val = transform.Find("plane");
		Transform trans = val.Find("name");
		GvGHelper.SetOutlineText(trans, Name);
		DockingManager?.RenderSlots();
		IslandStateManager?.Render();
	}
}
