using System;

namespace Shift.Legion.ClientApi.Models;

[AttributeUsage(AttributeTargets.Class)]
public class FrameActionIdAttribute : Attribute
{
	public readonly int Id;

	public FrameActionIdAttribute(int id)
	{
		Id = id;
	}
}
