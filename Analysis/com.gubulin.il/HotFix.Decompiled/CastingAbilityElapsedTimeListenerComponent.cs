using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class CastingAbilityElapsedTimeListenerComponent : IComponent
{
	public List<ICastingAbilityElapsedTimeListener> value;
}
