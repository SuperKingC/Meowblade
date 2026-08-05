using System;
using System.ComponentModel;
using ProtoBuf.Meta;

namespace ProtoBuf;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
public sealed class ProtoIncludeAttribute : Attribute
{
	public int Tag { get; }

	public string KnownTypeName { get; }

	public Type KnownType => TypeModel.ResolveKnownType(KnownTypeName, null, null);

	[DefaultValue(DataFormat.Default)]
	public DataFormat DataFormat { get; set; } = DataFormat.Default;

	public ProtoIncludeAttribute(int tag, Type knownType)
		: this(tag, (knownType == null) ? "" : knownType.AssemblyQualifiedName)
	{
	}

	public ProtoIncludeAttribute(int tag, string knownTypeName)
	{
		if (tag <= 0)
		{
			throw new ArgumentOutOfRangeException("tag", "Tags must be positive integers");
		}
		if (string.IsNullOrEmpty(knownTypeName))
		{
			throw new ArgumentNullException("knownTypeName", "Known type cannot be blank");
		}
		Tag = tag;
		KnownTypeName = knownTypeName;
	}
}
