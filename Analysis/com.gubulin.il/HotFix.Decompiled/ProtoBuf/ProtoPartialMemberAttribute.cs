using System;

namespace ProtoBuf;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class ProtoPartialMemberAttribute : ProtoMemberAttribute
{
	public string MemberName { get; private set; }

	public ProtoPartialMemberAttribute(int tag, string memberName)
		: base(tag)
	{
		if (string.IsNullOrEmpty(memberName))
		{
			throw new ArgumentNullException("memberName");
		}
		MemberName = memberName;
	}
}
