namespace ProtoBuf;

public readonly struct DiscriminatedUnionObject
{
	public readonly object Object;

	public int Discriminator { get; }

	public bool Is(int discriminator)
	{
		return Discriminator == discriminator;
	}

	public DiscriminatedUnionObject(int discriminator, object value)
	{
		Discriminator = discriminator;
		Object = value;
	}

	public static void Reset(ref DiscriminatedUnionObject value, int discriminator)
	{
		if (value.Discriminator == discriminator)
		{
			value = default(DiscriminatedUnionObject);
		}
	}
}
