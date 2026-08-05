using System;

namespace ProtoBuf.Meta;

public sealed class TypeAddedEventArgs : EventArgs
{
	public bool ApplyDefaultBehaviour { get; set; }

	public MetaType MetaType { get; }

	public Type Type => MetaType.Type;

	public RuntimeTypeModel Model => MetaType.Model as RuntimeTypeModel;

	internal TypeAddedEventArgs(MetaType metaType)
	{
		MetaType = metaType;
		ApplyDefaultBehaviour = true;
	}
}
