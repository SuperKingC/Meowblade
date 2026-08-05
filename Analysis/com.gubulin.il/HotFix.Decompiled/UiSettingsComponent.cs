using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public sealed class UiSettingsComponent : IComponent
{
	public Dictionary<string, UiSetting> value;
}
