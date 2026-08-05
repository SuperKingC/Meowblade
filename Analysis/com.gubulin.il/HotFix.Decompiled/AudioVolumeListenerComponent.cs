using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AudioVolumeListenerComponent : IComponent
{
	public List<IAudioVolumeListener> value;
}
