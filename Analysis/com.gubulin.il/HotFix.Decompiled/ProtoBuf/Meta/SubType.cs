using System;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta;

public sealed class SubType
{
	internal sealed class Comparer : IComparer, IComparer<SubType>
	{
		public static readonly Comparer Default = new Comparer();

		public int Compare(object x, object y)
		{
			return Compare(x as SubType, y as SubType);
		}

		public int Compare(SubType x, SubType y)
		{
			if (x == y)
			{
				return 0;
			}
			if (x == null)
			{
				return -1;
			}
			if (y == null)
			{
				return 1;
			}
			return x.FieldNumber.CompareTo(y.FieldNumber);
		}
	}

	private int _fieldNumber;

	private readonly MetaType derivedType;

	private readonly DataFormat dataFormat;

	private IProtoSerializer serializer;

	public int FieldNumber
	{
		get
		{
			return _fieldNumber;
		}
		internal set
		{
			if (_fieldNumber != value)
			{
				MetaType.AssertValidFieldNumber(value);
				ThrowIfFrozen();
				_fieldNumber = value;
			}
		}
	}

	public MetaType DerivedType => derivedType;

	internal IProtoSerializer Serializer => serializer ?? (serializer = BuildSerializer());

	private void ThrowIfFrozen()
	{
		if (serializer != null)
		{
			throw new InvalidOperationException("The type cannot be changed once a serializer has been generated");
		}
	}

	public SubType(int fieldNumber, MetaType derivedType, DataFormat format)
	{
		if (derivedType == null)
		{
			throw new ArgumentNullException("derivedType");
		}
		if (fieldNumber <= 0)
		{
			throw new ArgumentOutOfRangeException("fieldNumber");
		}
		_fieldNumber = fieldNumber;
		this.derivedType = derivedType;
		dataFormat = format;
	}

	private IProtoSerializer BuildSerializer()
	{
		WireType wireType = WireType.String;
		if (dataFormat == DataFormat.Group)
		{
			wireType = WireType.StartGroup;
		}
		IProtoSerializer tail = new SubItemSerializer(derivedType.Type, derivedType.GetKey(demand: false, getBaseKey: false), derivedType, recursionCheck: false);
		return new TagDecorator(_fieldNumber, wireType, strict: false, tail);
	}
}
