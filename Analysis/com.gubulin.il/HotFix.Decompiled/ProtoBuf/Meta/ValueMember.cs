using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta;

public class ValueMember
{
	internal sealed class Comparer : IComparer, IComparer<ValueMember>
	{
		public static readonly Comparer Default = new Comparer();

		public int Compare(object x, object y)
		{
			return Compare(x as ValueMember, y as ValueMember);
		}

		public int Compare(ValueMember x, ValueMember y)
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

	private readonly MemberInfo originalMember;

	private MemberInfo backingMember;

	private readonly Type parentType;

	private readonly Type itemType;

	private readonly Type defaultType;

	private readonly Type memberType;

	private object defaultValue;

	private readonly RuntimeTypeModel model;

	private IProtoSerializer serializer;

	private DataFormat dataFormat;

	private DataFormat mapKeyFormat;

	private DataFormat mapValueFormat;

	private string mapKeyTypeName;

	private string mapValueTypeName;

	private MethodInfo getSpecified;

	private MethodInfo setSpecified;

	private string name;

	private const byte OPTIONS_IsStrict = 1;

	private const byte OPTIONS_IsPacked = 2;

	private const byte OPTIONS_IsRequired = 4;

	private const byte OPTIONS_OverwriteList = 8;

	private const byte OPTIONS_SupportNull = 16;

	private const byte OPTIONS_AsReference = 32;

	private const byte OPTIONS_IsMap = 64;

	private const byte OPTIONS_DynamicType = 128;

	private byte flags;

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

	public MemberInfo Member => originalMember;

	public MemberInfo BackingMember
	{
		get
		{
			return backingMember;
		}
		set
		{
			if (backingMember != value)
			{
				ThrowIfFrozen();
				backingMember = value;
			}
		}
	}

	public Type ItemType => itemType;

	public Type MemberType => memberType;

	public Type DefaultType => defaultType;

	public Type ParentType => parentType;

	public object DefaultValue
	{
		get
		{
			return defaultValue;
		}
		set
		{
			if (defaultValue != value)
			{
				ThrowIfFrozen();
				defaultValue = value;
			}
		}
	}

	internal IProtoSerializer Serializer => serializer ?? (serializer = BuildSerializer());

	public DataFormat DataFormat
	{
		get
		{
			return dataFormat;
		}
		set
		{
			if (value != dataFormat)
			{
				ThrowIfFrozen();
				dataFormat = value;
			}
		}
	}

	public bool IsStrict
	{
		get
		{
			return HasFlag(1);
		}
		set
		{
			SetFlag(1, value, throwIfFrozen: true);
		}
	}

	public bool IsPacked
	{
		get
		{
			return HasFlag(2);
		}
		set
		{
			SetFlag(2, value, throwIfFrozen: true);
		}
	}

	public bool OverwriteList
	{
		get
		{
			return HasFlag(8);
		}
		set
		{
			SetFlag(8, value, throwIfFrozen: true);
		}
	}

	public bool IsRequired
	{
		get
		{
			return HasFlag(4);
		}
		set
		{
			SetFlag(4, value, throwIfFrozen: true);
		}
	}

	public bool AsReference
	{
		get
		{
			return HasFlag(32);
		}
		set
		{
			SetFlag(32, value, throwIfFrozen: true);
		}
	}

	public bool DynamicType
	{
		get
		{
			return HasFlag(128);
		}
		set
		{
			SetFlag(128, value, throwIfFrozen: true);
		}
	}

	public bool IsMap
	{
		get
		{
			return HasFlag(64);
		}
		set
		{
			SetFlag(64, value, throwIfFrozen: true);
		}
	}

	public DataFormat MapKeyFormat
	{
		get
		{
			return mapKeyFormat;
		}
		set
		{
			if (mapKeyFormat != value)
			{
				ThrowIfFrozen();
				mapKeyFormat = value;
			}
		}
	}

	public DataFormat MapValueFormat
	{
		get
		{
			return mapValueFormat;
		}
		set
		{
			if (mapValueFormat != value)
			{
				ThrowIfFrozen();
				mapValueFormat = value;
			}
		}
	}

	public string MapKeyTypeName
	{
		get
		{
			return mapKeyTypeName;
		}
		set
		{
			mapKeyTypeName = value;
		}
	}

	public string MapValueTypeName
	{
		get
		{
			return mapValueTypeName;
		}
		set
		{
			mapValueTypeName = value;
		}
	}

	public string Name
	{
		get
		{
			return string.IsNullOrEmpty(name) ? originalMember.Name : name;
		}
		set
		{
			SetName(value);
		}
	}

	public bool SupportNull
	{
		get
		{
			return HasFlag(16);
		}
		set
		{
			SetFlag(16, value, throwIfFrozen: true);
		}
	}

	public ValueMember(RuntimeTypeModel model, Type parentType, int fieldNumber, MemberInfo member, Type memberType, Type itemType, Type defaultType, DataFormat dataFormat, object defaultValue)
		: this(model, fieldNumber, memberType, itemType, defaultType, dataFormat)
	{
		if (parentType == null)
		{
			throw new ArgumentNullException("parentType");
		}
		if (fieldNumber < 1 && !Helpers.IsEnum(parentType))
		{
			throw new ArgumentOutOfRangeException("fieldNumber");
		}
		originalMember = member ?? throw new ArgumentNullException("member");
		this.parentType = parentType;
		if (fieldNumber < 1 && !Helpers.IsEnum(parentType))
		{
			throw new ArgumentOutOfRangeException("fieldNumber");
		}
		if (defaultValue != null && model.MapType(defaultValue.GetType()) != memberType)
		{
			defaultValue = ParseDefaultValue(memberType, defaultValue);
		}
		this.defaultValue = defaultValue;
		MetaType metaType = model.FindWithoutAdd(memberType);
		if (metaType != null)
		{
			AsReference = metaType.AsReferenceDefault;
		}
		else
		{
			AsReference = MetaType.GetAsReferenceDefault(model, memberType);
		}
	}

	internal ValueMember(RuntimeTypeModel model, int fieldNumber, Type memberType, Type itemType, Type defaultType, DataFormat dataFormat)
	{
		_fieldNumber = fieldNumber;
		this.memberType = memberType ?? throw new ArgumentNullException("memberType");
		this.itemType = itemType;
		this.defaultType = defaultType;
		this.model = model ?? throw new ArgumentNullException("model");
		this.dataFormat = dataFormat;
	}

	internal object GetRawEnumValue()
	{
		return ((FieldInfo)originalMember).GetRawConstantValue();
	}

	private static object ParseDefaultValue(Type type, object value)
	{
		Type underlyingType = Helpers.GetUnderlyingType(type);
		if (underlyingType != null)
		{
			type = underlyingType;
		}
		if (value is string text)
		{
			if (Helpers.IsEnum(type))
			{
				return Helpers.ParseEnum(type, text);
			}
			switch (Helpers.GetTypeCode(type))
			{
			case ProtoTypeCode.Boolean:
				return bool.Parse(text);
			case ProtoTypeCode.Byte:
				return byte.Parse(text, NumberStyles.Integer, CultureInfo.InvariantCulture);
			case ProtoTypeCode.Char:
				if (text.Length == 1)
				{
					return text[0];
				}
				throw new FormatException("Single character expected: \"" + text + "\"");
			case ProtoTypeCode.DateTime:
				return DateTime.Parse(text, CultureInfo.InvariantCulture);
			case ProtoTypeCode.Decimal:
				return decimal.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
			case ProtoTypeCode.Double:
				return double.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
			case ProtoTypeCode.Int16:
				return short.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
			case ProtoTypeCode.Int32:
				return int.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
			case ProtoTypeCode.Int64:
				return long.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
			case ProtoTypeCode.SByte:
				return sbyte.Parse(text, NumberStyles.Integer, CultureInfo.InvariantCulture);
			case ProtoTypeCode.Single:
				return float.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
			case ProtoTypeCode.String:
				return text;
			case ProtoTypeCode.UInt16:
				return ushort.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
			case ProtoTypeCode.UInt32:
				return uint.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
			case ProtoTypeCode.UInt64:
				return ulong.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
			case ProtoTypeCode.TimeSpan:
				return TimeSpan.Parse(text);
			case ProtoTypeCode.Uri:
				return text;
			case ProtoTypeCode.Guid:
				return new Guid(text);
			}
		}
		if (Helpers.IsEnum(type))
		{
			return Enum.ToObject(type, value);
		}
		if (value is int)
		{
			return (int)value;
		}
		if (value is long)
		{
			return (long)value;
		}
		if (value is sbyte)
		{
			return (sbyte)value;
		}
		if (value is float)
		{
			return (float)value;
		}
		if (value is double)
		{
			return (double)value;
		}
		if (value is decimal)
		{
			return (decimal)value;
		}
		if (value is byte[])
		{
			return (byte[])value;
		}
		if (value is sbyte[])
		{
			return (sbyte[])value;
		}
		if (value is short[])
		{
			return (short[])value;
		}
		if (value is ushort[])
		{
			return (ushort[])value;
		}
		if (value is uint[])
		{
			return (uint[])value;
		}
		if (value is ulong[])
		{
			return (ulong[])value;
		}
		if (value is bool)
		{
			return (bool)value;
		}
		return Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
	}

	public void SetSpecified(MethodInfo getSpecified, MethodInfo setSpecified)
	{
		if (this.getSpecified != getSpecified || this.setSpecified != setSpecified)
		{
			if (getSpecified != null && (getSpecified.ReturnType != model.MapType(typeof(bool)) || getSpecified.IsStatic || getSpecified.GetParameters().Length != 0))
			{
				throw new ArgumentException("Invalid pattern for checking member-specified", "getSpecified");
			}
			ParameterInfo[] parameters;
			if (setSpecified != null && (setSpecified.ReturnType != model.MapType(typeof(void)) || setSpecified.IsStatic || (parameters = setSpecified.GetParameters()).Length != 1 || parameters[0].ParameterType != model.MapType(typeof(bool))))
			{
				throw new ArgumentException("Invalid pattern for setting member-specified", "setSpecified");
			}
			ThrowIfFrozen();
			this.getSpecified = getSpecified;
			this.setSpecified = setSpecified;
		}
	}

	private void ThrowIfFrozen()
	{
		if (serializer != null)
		{
			throw new InvalidOperationException("The type cannot be changed once a serializer has been generated");
		}
	}

	internal bool ResolveMapTypes(out Type dictionaryType, out Type keyType, out Type valueType)
	{
		dictionaryType = (keyType = (valueType = null));
		try
		{
			Type type = memberType;
			if (ImmutableCollectionDecorator.IdentifyImmutable(model, MemberType, out var _, out var _, out var _, out var _, out var _, out var _))
			{
				return false;
			}
			if (type.IsInterface && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<, >))
			{
				Type[] genericArguments = memberType.GetGenericArguments();
				if (IsValidMapKeyType(genericArguments[0]))
				{
					keyType = genericArguments[0];
					valueType = genericArguments[1];
					dictionaryType = memberType;
				}
				return false;
			}
			Type[] interfaces = memberType.GetInterfaces();
			foreach (Type type2 in interfaces)
			{
				type = type2;
				if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<, >))
				{
					if (dictionaryType != null)
					{
						throw new InvalidOperationException("Multiple dictionary interfaces implemented by type: " + memberType.FullName);
					}
					Type[] genericArguments2 = type2.GetGenericArguments();
					if (IsValidMapKeyType(genericArguments2[0]))
					{
						keyType = genericArguments2[0];
						valueType = genericArguments2[1];
						dictionaryType = memberType;
					}
				}
			}
			if (dictionaryType == null)
			{
				return false;
			}
			Type type3 = null;
			Type type4 = null;
			model.ResolveListTypes(valueType, ref type3, ref type4);
			if (type3 != null)
			{
				return false;
			}
			return dictionaryType != null;
		}
		catch
		{
			return false;
		}
	}

	private static bool IsValidMapKeyType(Type type)
	{
		if (type == null || Helpers.IsEnum(type))
		{
			return false;
		}
		ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
		ProtoTypeCode protoTypeCode = typeCode;
		if ((uint)(protoTypeCode - 3) <= 9u || protoTypeCode == ProtoTypeCode.String)
		{
			return true;
		}
		return false;
	}

	private IProtoSerializer BuildSerializer()
	{
		int opaqueToken = 0;
		try
		{
			model.TakeLock(ref opaqueToken);
			MemberInfo memberInfo = backingMember ?? originalMember;
			IProtoSerializer protoSerializer3;
			if (IsMap)
			{
				ResolveMapTypes(out var dictionaryType, out var keyType, out var valueType);
				Type type = keyType;
				Type type2 = valueType;
				if (type != null && type.FullName == "ILRuntime.Runtime.Intepreter.ILTypeInstance")
				{
					type = PType.FindType(mapKeyTypeName);
				}
				if (type2 != null && type2.FullName == "ILRuntime.Runtime.Intepreter.ILTypeInstance")
				{
					type2 = PType.FindType(mapValueTypeName);
				}
				if (dictionaryType != null)
				{
					dictionaryType = typeof(Dictionary<, >).MakeGenericType(keyType, valueType);
				}
				if (dictionaryType == null)
				{
					throw new InvalidOperationException("Unable to resolve map type for type: " + memberType.FullName);
				}
				Type type3 = defaultType;
				if (type3 == null && Helpers.IsClass(memberType))
				{
					type3 = memberType;
				}
				WireType defaultWireType;
				IProtoSerializer protoSerializer = TryGetCoreSerializer(model, MapKeyFormat, type, out defaultWireType, asReference: false, dynamicType: false, overwriteList: false, allowComplexTypes: false);
				if (!AsReference)
				{
					AsReference = MetaType.GetAsReferenceDefault(model, valueType);
				}
				WireType defaultWireType2;
				IProtoSerializer protoSerializer2 = TryGetCoreSerializer(model, MapValueFormat, type2, out defaultWireType2, AsReference, DynamicType, overwriteList: false, allowComplexTypes: true);
				ConstructorInfo[] constructors = typeof(MapDecorator<, , >).MakeGenericType(dictionaryType, keyType, valueType).GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (constructors.Length != 1)
				{
					throw new InvalidOperationException("Unable to resolve MapDecorator constructor");
				}
				protoSerializer3 = (IProtoSerializer)constructors[0].Invoke(new object[9]
				{
					model,
					type3,
					protoSerializer,
					protoSerializer2,
					_fieldNumber,
					(DataFormat == DataFormat.Group) ? WireType.StartGroup : WireType.String,
					defaultWireType,
					defaultWireType2,
					OverwriteList
				});
			}
			else
			{
				Type type4 = itemType ?? memberType;
				protoSerializer3 = TryGetCoreSerializer(model, dataFormat, type4, out var defaultWireType3, AsReference, DynamicType, OverwriteList, allowComplexTypes: true);
				if (protoSerializer3 == null)
				{
					throw new InvalidOperationException("No serializer defined for type: " + type4.FullName);
				}
				if (itemType != null && SupportNull)
				{
					if (IsPacked)
					{
						throw new NotSupportedException("Packed encodings cannot support null values");
					}
					protoSerializer3 = new TagDecorator(1, defaultWireType3, IsStrict, protoSerializer3);
					protoSerializer3 = new NullDecorator(model, protoSerializer3);
					protoSerializer3 = new TagDecorator(_fieldNumber, WireType.StartGroup, strict: false, protoSerializer3);
				}
				else
				{
					protoSerializer3 = new TagDecorator(_fieldNumber, defaultWireType3, IsStrict, protoSerializer3);
				}
				if (itemType != null)
				{
					Type type5 = (SupportNull ? itemType : (Helpers.GetUnderlyingType(itemType) ?? itemType));
					protoSerializer3 = ((!memberType.IsArray) ? ((ProtoDecoratorBase)ListDecorator.Create(model, memberType, defaultType, protoSerializer3, _fieldNumber, IsPacked, defaultWireType3, memberInfo != null && PropertyDecorator.CanWrite(model, memberInfo), OverwriteList, SupportNull)) : ((ProtoDecoratorBase)new ArrayDecorator(model, protoSerializer3, _fieldNumber, IsPacked, defaultWireType3, memberType, OverwriteList, SupportNull)));
				}
				else if (defaultValue != null && !IsRequired && getSpecified == null)
				{
					protoSerializer3 = new DefaultValueDecorator(model, defaultValue, protoSerializer3);
				}
				if (memberType == model.MapType(typeof(Uri)))
				{
					protoSerializer3 = new UriDecorator(model, protoSerializer3);
				}
			}
			if (memberInfo != null)
			{
				if (memberInfo is PropertyInfo property)
				{
					protoSerializer3 = new PropertyDecorator(model, parentType, property, protoSerializer3);
				}
				else
				{
					if (!(memberInfo is FieldInfo field))
					{
						throw new InvalidOperationException();
					}
					protoSerializer3 = new FieldDecorator(parentType, field, protoSerializer3);
				}
				if (getSpecified != null || setSpecified != null)
				{
					protoSerializer3 = new MemberSpecifiedDecorator(getSpecified, setSpecified, protoSerializer3);
				}
			}
			return protoSerializer3;
		}
		finally
		{
			model.ReleaseLock(opaqueToken);
		}
	}

	private static WireType GetIntWireType(DataFormat format, int width)
	{
		switch (format)
		{
		case DataFormat.ZigZag:
			return WireType.SignedVariant;
		case DataFormat.FixedSize:
			return (width != 32) ? WireType.Fixed64 : WireType.Fixed32;
		case DataFormat.Default:
		case DataFormat.TwosComplement:
			return WireType.Variant;
		default:
			throw new InvalidOperationException();
		}
	}

	private static WireType GetDateTimeWireType(DataFormat format)
	{
		switch (format)
		{
		case DataFormat.Group:
			return WireType.StartGroup;
		case DataFormat.FixedSize:
			return WireType.Fixed64;
		case DataFormat.Default:
		case DataFormat.WellKnown:
			return WireType.String;
		default:
			throw new InvalidOperationException();
		}
	}

	internal static IProtoSerializer TryGetCoreSerializer(RuntimeTypeModel model, DataFormat dataFormat, Type type, out WireType defaultWireType, bool asReference, bool dynamicType, bool overwriteList, bool allowComplexTypes)
	{
		Type underlyingType = Helpers.GetUnderlyingType(type);
		if (underlyingType != null)
		{
			type = underlyingType;
		}
		if (Helpers.IsEnum(type))
		{
			if (allowComplexTypes && model != null)
			{
				defaultWireType = WireType.Variant;
				return new EnumSerializer(type, model.GetEnumMap(type));
			}
			defaultWireType = WireType.None;
			return null;
		}
		switch (Helpers.GetTypeCode(type))
		{
		case ProtoTypeCode.Int32:
			defaultWireType = GetIntWireType(dataFormat, 32);
			return new Int32Serializer(model);
		case ProtoTypeCode.UInt32:
			defaultWireType = GetIntWireType(dataFormat, 32);
			return new UInt32Serializer(model);
		case ProtoTypeCode.Int64:
			defaultWireType = GetIntWireType(dataFormat, 64);
			return new Int64Serializer(model);
		case ProtoTypeCode.UInt64:
			defaultWireType = GetIntWireType(dataFormat, 64);
			return new UInt64Serializer(model);
		case ProtoTypeCode.String:
			defaultWireType = WireType.String;
			if (asReference)
			{
				return new NetObjectSerializer(model, model.MapType(typeof(string)), 0, BclHelpers.NetObjectOptions.AsReference);
			}
			return new StringSerializer(model);
		case ProtoTypeCode.Single:
			defaultWireType = WireType.Fixed32;
			return new SingleSerializer(model);
		case ProtoTypeCode.Double:
			defaultWireType = WireType.Fixed64;
			return new DoubleSerializer(model);
		case ProtoTypeCode.Boolean:
			defaultWireType = WireType.Variant;
			return new BooleanSerializer(model);
		case ProtoTypeCode.DateTime:
			defaultWireType = GetDateTimeWireType(dataFormat);
			return new DateTimeSerializer(dataFormat, model);
		case ProtoTypeCode.Decimal:
			defaultWireType = WireType.String;
			return new DecimalSerializer(model);
		case ProtoTypeCode.Byte:
			defaultWireType = GetIntWireType(dataFormat, 32);
			return new ByteSerializer(model);
		case ProtoTypeCode.SByte:
			defaultWireType = GetIntWireType(dataFormat, 32);
			return new SByteSerializer(model);
		case ProtoTypeCode.Char:
			defaultWireType = WireType.Variant;
			return new CharSerializer(model);
		case ProtoTypeCode.Int16:
			defaultWireType = GetIntWireType(dataFormat, 32);
			return new Int16Serializer(model);
		case ProtoTypeCode.UInt16:
			defaultWireType = GetIntWireType(dataFormat, 32);
			return new UInt16Serializer(model);
		case ProtoTypeCode.TimeSpan:
			defaultWireType = GetDateTimeWireType(dataFormat);
			return new TimeSpanSerializer(dataFormat, model);
		case ProtoTypeCode.Guid:
			defaultWireType = ((dataFormat == DataFormat.Group) ? WireType.StartGroup : WireType.String);
			return new GuidSerializer(model);
		case ProtoTypeCode.Uri:
			defaultWireType = WireType.String;
			return new StringSerializer(model);
		case ProtoTypeCode.ByteArray:
			defaultWireType = WireType.String;
			return new BlobSerializer(model, overwriteList);
		case ProtoTypeCode.Type:
			defaultWireType = WireType.String;
			return new SystemTypeSerializer(model);
		default:
		{
			IProtoSerializer protoSerializer = (model.AllowParseableTypes ? ParseableSerializer.TryCreate(type, model) : null);
			if (protoSerializer != null)
			{
				defaultWireType = WireType.String;
				return protoSerializer;
			}
			if (allowComplexTypes && model != null)
			{
				int key = model.GetKey(type, demand: false, getBaseKey: true);
				MetaType metaType = null;
				if (key >= 0)
				{
					metaType = model[type];
					if (dataFormat == DataFormat.Default && metaType.IsGroup)
					{
						dataFormat = DataFormat.Group;
					}
				}
				if (asReference || dynamicType)
				{
					BclHelpers.NetObjectOptions netObjectOptions = BclHelpers.NetObjectOptions.None;
					if (asReference)
					{
						netObjectOptions |= BclHelpers.NetObjectOptions.AsReference;
					}
					if (dynamicType)
					{
						netObjectOptions |= BclHelpers.NetObjectOptions.DynamicType;
					}
					if (metaType != null)
					{
						if (asReference && Helpers.IsValueType(type))
						{
							string text = "AsReference cannot be used with value-types";
							text = ((!(type.Name == "KeyValuePair`2")) ? (text + ": " + type.FullName) : (text + "; please see https://stackoverflow.com/q/14436606/23354"));
							throw new InvalidOperationException(text);
						}
						if (asReference && metaType.IsAutoTuple)
						{
							netObjectOptions |= BclHelpers.NetObjectOptions.LateSet;
						}
						if (metaType.UseConstructor)
						{
							netObjectOptions |= BclHelpers.NetObjectOptions.UseConstructor;
						}
					}
					defaultWireType = ((dataFormat == DataFormat.Group) ? WireType.StartGroup : WireType.String);
					return new NetObjectSerializer(model, type, key, netObjectOptions);
				}
				if (key >= 0)
				{
					defaultWireType = ((dataFormat == DataFormat.Group) ? WireType.StartGroup : WireType.String);
					return new SubItemSerializer(type, key, metaType, recursionCheck: true);
				}
			}
			defaultWireType = WireType.None;
			return null;
		}
		}
	}

	internal void SetName(string name)
	{
		if (name != this.name)
		{
			ThrowIfFrozen();
			this.name = name;
		}
	}

	private bool HasFlag(byte flag)
	{
		return (flags & flag) == flag;
	}

	private void SetFlag(byte flag, bool value, bool throwIfFrozen)
	{
		if (throwIfFrozen && HasFlag(flag) != value)
		{
			ThrowIfFrozen();
		}
		if (value)
		{
			flags |= flag;
		}
		else
		{
			flags = (byte)(flags & ~flag);
		}
	}

	internal string GetSchemaTypeName(bool applyNetObjectProxy, ref RuntimeTypeModel.CommonImports imports)
	{
		Type type = ItemType;
		if (type == null)
		{
			type = MemberType;
		}
		return model.GetSchemaTypeName(type, DataFormat, applyNetObjectProxy && AsReference, applyNetObjectProxy && DynamicType, ref imports);
	}
}
