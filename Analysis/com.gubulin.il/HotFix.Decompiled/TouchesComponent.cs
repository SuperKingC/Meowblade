using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input]
[Unique]
public sealed class TouchesComponent : IComponent
{
	public int count;

	public List<Touch> value;
}
