using System;

namespace ProtoBuf;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class ProtoPartialIgnoreAttribute : ProtoIgnoreAttribute
{
	public string MemberName { get; }

	public ProtoPartialIgnoreAttribute(string memberName)
	{
		if (string.IsNullOrEmpty(memberName))
		{
			throw new ArgumentNullException("memberName");
		}
		MemberName = memberName;
	}
}
