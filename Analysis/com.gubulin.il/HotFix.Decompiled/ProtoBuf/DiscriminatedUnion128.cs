using System;
using System.Runtime.InteropServices;

namespace ProtoBuf;

[StructLayout(LayoutKind.Explicit)]
public readonly struct DiscriminatedUnion128
{
	[FieldOffset(0)]
	private readonly int _discriminator;

	[FieldOffset(8)]
	public readonly long Int64;

	[FieldOffset(8)]
	public readonly ulong UInt64;

	[FieldOffset(8)]
	public readonly int Int32;

	[FieldOffset(8)]
	public readonly uint UInt32;

	[FieldOffset(8)]
	public readonly bool Boolean;

	[FieldOffset(8)]
	public readonly float Single;

	[FieldOffset(8)]
	public readonly double Double;

	[FieldOffset(8)]
	public readonly DateTime DateTime;

	[FieldOffset(8)]
	public readonly TimeSpan TimeSpan;

	[FieldOffset(8)]
	public readonly Guid Guid;

	public int Discriminator => _discriminator;

	private DiscriminatedUnion128(int discriminator)
	{
		this = default(DiscriminatedUnion128);
		_discriminator = discriminator;
	}

	public bool Is(int discriminator)
	{
		return _discriminator == discriminator;
	}

	public DiscriminatedUnion128(int discriminator, long value)
		: this(discriminator)
	{
		Int64 = value;
	}

	public DiscriminatedUnion128(int discriminator, int value)
		: this(discriminator)
	{
		Int32 = value;
	}

	public DiscriminatedUnion128(int discriminator, ulong value)
		: this(discriminator)
	{
		UInt64 = value;
	}

	public DiscriminatedUnion128(int discriminator, uint value)
		: this(discriminator)
	{
		UInt32 = value;
	}

	public DiscriminatedUnion128(int discriminator, float value)
		: this(discriminator)
	{
		Single = value;
	}

	public DiscriminatedUnion128(int discriminator, double value)
		: this(discriminator)
	{
		Double = value;
	}

	public DiscriminatedUnion128(int discriminator, bool value)
		: this(discriminator)
	{
		Boolean = value;
	}

	public DiscriminatedUnion128(int discriminator, DateTime? value)
		: this(value.HasValue ? discriminator : 0)
	{
		DateTime = value.GetValueOrDefault();
	}

	public DiscriminatedUnion128(int discriminator, TimeSpan? value)
		: this(value.HasValue ? discriminator : 0)
	{
		TimeSpan = value.GetValueOrDefault();
	}

	public DiscriminatedUnion128(int discriminator, Guid? value)
		: this(value.HasValue ? discriminator : 0)
	{
		Guid = value.GetValueOrDefault();
	}

	public static void Reset(ref DiscriminatedUnion128 value, int discriminator)
	{
		if (value.Discriminator == discriminator)
		{
			value = default(DiscriminatedUnion128);
		}
	}
}
