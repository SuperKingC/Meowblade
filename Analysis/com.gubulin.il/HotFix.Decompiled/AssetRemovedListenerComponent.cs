using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[DontGenerate(false)]
public sealed class AssetRemovedListenerComponent : IComponent
{
	public List<IAssetRemovedListener> value;
}
