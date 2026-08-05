using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
[Event(EventTarget.Self, EventType.Added, 0)]
public sealed class FloatingTextComponent : IComponent
{
	public Color color;

	public string text;
}
