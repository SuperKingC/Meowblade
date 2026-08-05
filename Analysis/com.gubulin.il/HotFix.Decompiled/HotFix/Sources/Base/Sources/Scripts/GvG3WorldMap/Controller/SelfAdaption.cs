using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;

public class SelfAdaption
{
	public ComponentAlignType AlignType;

	public float Scale;

	public float PerSize { get; set; }

	public float AnchorPoint { get; set; } = 0f;

	public List<IslandComponentLodWrapper<Transform>> Objects { get; set; } = new List<IslandComponentLodWrapper<Transform>>();

	public Func<GameObject, bool> ObjectIsActive { get; set; }
}
