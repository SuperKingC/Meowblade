using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ProtoBuf.Meta;

public abstract class TypeModel : IProtoInput<Stream>, IProtoInput<ArraySegment<byte>>, IProtoInput<byte[]>, IProtoOutput<Stream>
{
	private sealed class DeserializeItemsIterator<T> : DeserializeItemsIterator, IEnumerator<T>, IEnumerator, IDisposable, IEnumerable<T>, IEnumerable
	{
		public new T Current => (T)base.Current;

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this;
		}

		void IDisposable.Dispose()
		{
		}

		public DeserializeItemsIterator(TypeModel model, Stream source, PrefixStyle style, int expectedField, SerializationContext context)
			: base(model, source, model.MapType(typeof(T)), style, expectedField, null, context)
		{
		}
	}

	private class DeserializeItemsIterator : IEnumerator, IEnumerable
	{
		private bool haveObject;

		private object current;

		private readonly Stream source;

		private readonly Type type;

		private readonly PrefixStyle style;

		private readonly int expectedField;

		private readonly Serializer.TypeResolver resolver;

		private readonly TypeModel model;

		private readonly SerializationContext context;

		public object Current => current;

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this;
		}

		public bool MoveNext()
		{
			if (haveObject)
			{
				current = model.DeserializeWithLengthPrefix(source, null, type, style, expectedField, resolver, out var _, out haveObject, context);
			}
			return haveObject;
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		public DeserializeItemsIterator(TypeModel model, Stream source, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver, SerializationContext context)
		{
			haveObject = true;
			this.source = source;
			this.type = type;
			this.style = style;
			this.expectedField = expectedField;
			this.resolver = resolver;
			this.model = model;
			this.context = context;
		}
	}

	private readonly struct KnownTypeKey
	{
		public int Key { get; }

		public Type Type { get; }

		public KnownTypeKey(Type type, int key)
		{
			Type = type;
			Key = key;
		}
	}

	protected internal enum CallbackType
	{
		BeforeSerialize,
		AfterSerialize,
		BeforeDeserialize,
		AfterDeserialize
	}

	private static readonly Type ilist = typeof(IList);

	private readonly Dictionary<Type, KnownTypeKey> knownKeys = new Dictionary<Type, KnownTypeKey>();

	public event TypeFormatEventHandler DynamicTypeFormatting;

	protected internal virtual bool SerializeDateTimeKind()
	{
		return false;
	}

	protected internal Type MapType(Type type)
	{
		return MapType(type, demand: true);
	}

	protected internal virtual Type MapType(Type type, bool demand)
	{
		return type;
	}

	private WireType GetWireType(ProtoTypeCode code, DataFormat format, ref Type type, out int modelKey)
	{
		modelKey = -1;
		if (Helpers.IsEnum(type))
		{
			modelKey = GetKey(ref type);
			return WireType.Variant;
		}
		switch (code)
		{
		case ProtoTypeCode.Int64:
		case ProtoTypeCode.UInt64:
			return (format == DataFormat.FixedSize) ? WireType.Fixed64 : WireType.Variant;
		case ProtoTypeCode.Boolean:
		case ProtoTypeCode.Char:
		case ProtoTypeCode.SByte:
		case ProtoTypeCode.Byte:
		case ProtoTypeCode.Int16:
		case ProtoTypeCode.UInt16:
		case ProtoTypeCode.Int32:
		case ProtoTypeCode.UInt32:
			return (format == DataFormat.FixedSize) ? WireType.Fixed32 : WireType.Variant;
		case ProtoTypeCode.Double:
			return WireType.Fixed64;
		case ProtoTypeCode.Single:
			return WireType.Fixed32;
		case ProtoTypeCode.Decimal:
		case ProtoTypeCode.DateTime:
		case ProtoTypeCode.String:
		case ProtoTypeCode.TimeSpan:
		case ProtoTypeCode.ByteArray:
		case ProtoTypeCode.Guid:
		case ProtoTypeCode.Uri:
			return WireType.String;
		default:
			if ((modelKey = GetKey(ref type)) >= 0)
			{
				return WireType.String;
			}
			return WireType.None;
		}
	}

	internal bool TrySerializeAuxiliaryType(ProtoWriter writer, Type type, DataFormat format, int tag, object value, bool isInsideList, object parentList)
	{
		if (type == null)
		{
			type = value.GetType();
		}
		ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
		int modelKey;
		WireType wireType = GetWireType(typeCode, format, ref type, out modelKey);
		if (modelKey >= 0)
		{
			if (Helpers.IsEnum(type))
			{
				Serialize(modelKey, value, writer);
				return true;
			}
			ProtoWriter.WriteFieldHeader(tag, wireType, writer);
			switch (wireType)
			{
			case WireType.None:
				throw ProtoWriter.CreateException(writer);
			case WireType.String:
			case WireType.StartGroup:
			{
				SubItemToken token = ProtoWriter.StartSubItem(value, writer);
				Serialize(modelKey, value, writer);
				ProtoWriter.EndSubItem(token, writer);
				return true;
			}
			default:
				Serialize(modelKey, value, writer);
				return true;
			}
		}
		if (wireType != WireType.None)
		{
			ProtoWriter.WriteFieldHeader(tag, wireType, writer);
		}
		switch (typeCode)
		{
		case ProtoTypeCode.Int16:
			ProtoWriter.WriteInt16((short)value, writer);
			return true;
		case ProtoTypeCode.Int32:
			ProtoWriter.WriteInt32((int)value, writer);
			return true;
		case ProtoTypeCode.Int64:
			ProtoWriter.WriteInt64((long)value, writer);
			return true;
		case ProtoTypeCode.UInt16:
			ProtoWriter.WriteUInt16((ushort)value, writer);
			return true;
		case ProtoTypeCode.UInt32:
			ProtoWriter.WriteUInt32((uint)value, writer);
			return true;
		case ProtoTypeCode.UInt64:
			ProtoWriter.WriteUInt64((ulong)value, writer);
			return true;
		case ProtoTypeCode.Boolean:
			ProtoWriter.WriteBoolean((bool)value, writer);
			return true;
		case ProtoTypeCode.SByte:
			ProtoWriter.WriteSByte((sbyte)value, writer);
			return true;
		case ProtoTypeCode.Byte:
			ProtoWriter.WriteByte((byte)value, writer);
			return true;
		case ProtoTypeCode.Char:
			ProtoWriter.WriteUInt16((char)value, writer);
			return true;
		case ProtoTypeCode.Double:
			ProtoWriter.WriteDouble((double)value, writer);
			return true;
		case ProtoTypeCode.Single:
			ProtoWriter.WriteSingle((float)value, writer);
			return true;
		case ProtoTypeCode.DateTime:
			if (SerializeDateTimeKind())
			{
				BclHelpers.WriteDateTimeWithKind((DateTime)value, writer);
			}
			else
			{
				BclHelpers.WriteDateTime((DateTime)value, writer);
			}
			return true;
		case ProtoTypeCode.Decimal:
			BclHelpers.WriteDecimal((decimal)value, writer);
			return true;
		case ProtoTypeCode.String:
			ProtoWriter.WriteString((string)value, writer);
			return true;
		case ProtoTypeCode.ByteArray:
			ProtoWriter.WriteBytes((byte[])value, writer);
			return true;
		case ProtoTypeCode.TimeSpan:
			BclHelpers.WriteTimeSpan((TimeSpan)value, writer);
			return true;
		case ProtoTypeCode.Guid:
			BclHelpers.WriteGuid((Guid)value, writer);
			return true;
		case ProtoTypeCode.Uri:
			ProtoWriter.WriteString(((Uri)value).OriginalString, writer);
			return true;
		default:
			if (value is IEnumerable enumerable)
			{
				if (isInsideList)
				{
					throw CreateNestedListsNotSupported(parentList?.GetType());
				}
				foreach (object item in enumerable)
				{
					if (item == null)
					{
						throw new NullReferenceException();
					}
					if (!TrySerializeAuxiliaryType(writer, null, format, tag, item, isInsideList: true, enumerable))
					{
						ThrowUnexpectedType(item.GetType());
					}
				}
				return true;
			}
			return false;
		}
	}

	private void SerializeCore(ProtoWriter writer, object value)
	{
		SerializeCore(writer, PType.GetPType(value), value);
	}

	private void SerializeCore(ProtoWriter writer, Type type, object value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		int key = GetKey(ref type);
		if (key >= 0)
		{
			Serialize(key, value, writer);
		}
		else if (!TrySerializeAuxiliaryType(writer, type, DataFormat.Default, 1, value, isInsideList: false, null))
		{
			ThrowUnexpectedType(type);
		}
	}

	public void Serialize(Stream dest, object value)
	{
		Serialize(dest, value, null);
	}

	public void Serialize(Stream dest, object value, SerializationContext context)
	{
		using ProtoWriter protoWriter = ProtoWriter.Create(dest, this, context);
		protoWriter.SetRootObject(value);
		SerializeCore(protoWriter, value);
		protoWriter.Close();
	}

	public void Serialize(ProtoWriter dest, object value)
	{
		if (dest == null)
		{
			throw new ArgumentNullException("dest");
		}
		dest.CheckDepthFlushlock();
		dest.SetRootObject(value);
		SerializeCore(dest, value);
		dest.CheckDepthFlushlock();
		ProtoWriter.Flush(dest);
	}

	public object DeserializeWithLengthPrefix(Stream source, object value, Type type, PrefixStyle style, int fieldNumber)
	{
		long bytesRead;
		return DeserializeWithLengthPrefix(source, value, type, style, fieldNumber, (Serializer.TypeResolver)null, out bytesRead);
	}

	public object DeserializeWithLengthPrefix(Stream source, object value, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver)
	{
		long bytesRead;
		return DeserializeWithLengthPrefix(source, value, type, style, expectedField, resolver, out bytesRead);
	}

	public object DeserializeWithLengthPrefix(Stream source, object value, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver, out int bytesRead)
	{
		long bytesRead2;
		bool haveObject;
		object result = DeserializeWithLengthPrefix(source, value, type, style, expectedField, resolver, out bytesRead2, out haveObject, null);
		bytesRead = checked((int)bytesRead2);
		return result;
	}

	public object DeserializeWithLengthPrefix(Stream source, object value, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver, out long bytesRead)
	{
		bool haveObject;
		return DeserializeWithLengthPrefix(source, value, type, style, expectedField, resolver, out bytesRead, out haveObject, null);
	}

	private object DeserializeWithLengthPrefix(Stream source, object value, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver, out long bytesRead, out bool haveObject, SerializationContext context)
	{
		haveObject = false;
		bytesRead = 0L;
		if (type == null && (style != PrefixStyle.Base128 || resolver == null))
		{
			throw new InvalidOperationException("A type must be provided unless base-128 prefixing is being used in combination with a resolver");
		}
		long num;
		bool flag2;
		do
		{
			bool flag = expectedField > 0 || resolver != null;
			num = ProtoReader.ReadLongLengthPrefix(source, flag, style, out var fieldNumber, out var bytesRead2);
			if (bytesRead2 == 0)
			{
				return value;
			}
			bytesRead += bytesRead2;
			if (num < 0)
			{
				return value;
			}
			if (style == PrefixStyle.Base128)
			{
				if (flag && expectedField == 0 && type == null && resolver != null)
				{
					type = resolver(fieldNumber);
					flag2 = type == null;
				}
				else
				{
					flag2 = expectedField != fieldNumber;
				}
			}
			else
			{
				flag2 = false;
			}
			if (flag2)
			{
				if (num == long.MaxValue)
				{
					throw new InvalidOperationException();
				}
				ProtoReader.Seek(source, num, null);
				bytesRead += num;
			}
		}
		while (flag2);
		ProtoReader protoReader = null;
		try
		{
			protoReader = ProtoReader.Create(source, this, context, num);
			int key = GetKey(ref type);
			if (key >= 0 && !Helpers.IsEnum(type))
			{
				value = Deserialize(key, value, protoReader);
			}
			else if (!TryDeserializeAuxiliaryType(protoReader, DataFormat.Default, 1, type, ref value, skipOtherFields: true, asListItem: false, autoCreate: true, insideList: false, null) && num != 0)
			{
				ThrowUnexpectedType(type);
			}
			bytesRead += protoReader.LongPosition;
			haveObject = true;
			return value;
		}
		finally
		{
			ProtoReader.Recycle(protoReader);
		}
	}

	public IEnumerable DeserializeItems(Stream source, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver)
	{
		return DeserializeItems(source, type, style, expectedField, resolver, null);
	}

	public IEnumerable DeserializeItems(Stream source, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver, SerializationContext context)
	{
		return new DeserializeItemsIterator(this, source, type, style, expectedField, resolver, context);
	}

	public IEnumerable<T> DeserializeItems<T>(Stream source, PrefixStyle style, int expectedField)
	{
		return DeserializeItems<T>(source, style, expectedField, null);
	}

	public IEnumerable<T> DeserializeItems<T>(Stream source, PrefixStyle style, int expectedField, SerializationContext context)
	{
		return new DeserializeItemsIterator<T>(this, source, style, expectedField, context);
	}

	public void SerializeWithLengthPrefix(Stream dest, object value, Type type, PrefixStyle style, int fieldNumber)
	{
		SerializeWithLengthPrefix(dest, value, type, style, fieldNumber, null);
	}

	public void SerializeWithLengthPrefix(Stream dest, object value, Type type, PrefixStyle style, int fieldNumber, SerializationContext context)
	{
		if (type == null)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			type = MapType(value.GetType());
		}
		int key = GetKey(ref type);
		using ProtoWriter protoWriter = ProtoWriter.Create(dest, this, context);
		switch (style)
		{
		case PrefixStyle.None:
			Serialize(key, value, protoWriter);
			break;
		case PrefixStyle.Base128:
		case PrefixStyle.Fixed32:
		case PrefixStyle.Fixed32BigEndian:
			ProtoWriter.WriteObject(value, key, protoWriter, style, fieldNumber);
			break;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
		protoWriter.Close();
	}

	public object Deserialize(Stream source, object value, Type type)
	{
		return Deserialize(source, value, type, null);
	}

	public object Deserialize(Stream source, object value, Type type, SerializationContext context)
	{
		bool noAutoCreate = PrepareDeserialize(value, ref type);
		ProtoReader protoReader = null;
		try
		{
			protoReader = ProtoReader.Create(source, this, context, -1L);
			if (value != null)
			{
				protoReader.SetRootObject(value);
			}
			object result = DeserializeCore(protoReader, type, value, noAutoCreate);
			protoReader.CheckFullyConsumed();
			return result;
		}
		catch (Exception ex)
		{
			Debug.LogException(ex);
			throw;
		}
		finally
		{
			ProtoReader.Recycle(protoReader);
		}
	}

	private bool PrepareDeserialize(object value, ref Type type)
	{
		if (type == null)
		{
			if (value == null)
			{
				throw new ArgumentNullException("type");
			}
			type = MapType(value.GetType());
		}
		bool result = true;
		Type underlyingType = Helpers.GetUnderlyingType(type);
		if (underlyingType != null)
		{
			type = underlyingType;
			result = false;
		}
		return result;
	}

	public object Deserialize(Stream source, object value, Type type, int length)
	{
		return Deserialize(source, value, type, length, null);
	}

	public object Deserialize(Stream source, object value, Type type, long length)
	{
		return Deserialize(source, value, type, length, null);
	}

	public object Deserialize(Stream source, object value, Type type, int length, SerializationContext context)
	{
		return Deserialize(source, value, type, (length == int.MaxValue) ? long.MaxValue : length, context);
	}

	public object Deserialize(Stream source, object value, Type type, long length, SerializationContext context)
	{
		bool noAutoCreate = PrepareDeserialize(value, ref type);
		ProtoReader protoReader = null;
		try
		{
			protoReader = ProtoReader.Create(source, this, context, length);
			if (value != null)
			{
				protoReader.SetRootObject(value);
			}
			object result = DeserializeCore(protoReader, type, value, noAutoCreate);
			protoReader.CheckFullyConsumed();
			return result;
		}
		finally
		{
			ProtoReader.Recycle(protoReader);
		}
	}

	public object Deserialize(ProtoReader source, object value, Type type)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		bool noAutoCreate = PrepareDeserialize(value, ref type);
		if (value != null)
		{
			source.SetRootObject(value);
		}
		object result = DeserializeCore(source, type, value, noAutoCreate);
		source.CheckFullyConsumed();
		return result;
	}

	private object DeserializeCore(ProtoReader reader, Type type, object value, bool noAutoCreate)
	{
		int key = GetKey(ref type);
		if (key >= 0 && !Helpers.IsEnum(type))
		{
			return Deserialize(key, value, reader);
		}
		TryDeserializeAuxiliaryType(reader, DataFormat.Default, 1, type, ref value, skipOtherFields: true, asListItem: false, noAutoCreate, insideList: false, null);
		return value;
	}

	internal static MethodInfo ResolveListAdd(TypeModel model, Type listType, Type itemType, out bool isList)
	{
		isList = model.MapType(ilist).IsAssignableFrom(listType);
		Type[] array = new Type[1] { itemType };
		MethodInfo instanceMethod = Helpers.GetInstanceMethod(listType, "Add", array);
		if (instanceMethod == null)
		{
			bool flag = listType.IsInterface && model.MapType(typeof(IEnumerable<>)).MakeGenericType(array).IsAssignableFrom(listType);
			Type type = model.MapType(typeof(ICollection<>)).MakeGenericType(array);
			if (flag || type.IsAssignableFrom(listType))
			{
				instanceMethod = Helpers.GetInstanceMethod(type, "Add", array);
			}
		}
		if (instanceMethod == null)
		{
			Type[] interfaces = listType.GetInterfaces();
			foreach (Type type2 in interfaces)
			{
				if (type2.Name == "IProducerConsumerCollection`1" && type2.IsGenericType && type2.GetGenericTypeDefinition().FullName == "System.Collections.Concurrent.IProducerConsumerCollection`1")
				{
					instanceMethod = Helpers.GetInstanceMethod(type2, "TryAdd", array);
					if (instanceMethod != null)
					{
						break;
					}
				}
			}
		}
		if (instanceMethod == null)
		{
			array[0] = model.MapType(typeof(object));
			instanceMethod = Helpers.GetInstanceMethod(listType, "Add", array);
		}
		if ((instanceMethod == null) & isList)
		{
			instanceMethod = Helpers.GetInstanceMethod(model.MapType(ilist), "Add", array);
		}
		return instanceMethod;
	}

	internal static Type GetListItemType(TypeModel model, Type listType)
	{
		if (listType == model.MapType(typeof(string)) || listType.IsArray || !model.MapType(typeof(IEnumerable)).IsAssignableFrom(listType))
		{
			return null;
		}
		if (listType.FullName == "System.String")
		{
			return null;
		}
		BasicList basicList = new BasicList();
		MethodInfo[] methods = listType.GetMethods();
		foreach (MethodInfo methodInfo in methods)
		{
			if (!methodInfo.IsStatic && !(methodInfo.Name != "Add"))
			{
				ParameterInfo[] parameters = methodInfo.GetParameters();
				Type parameterType;
				if (parameters.Length == 1 && !basicList.Contains(parameterType = parameters[0].ParameterType))
				{
					basicList.Add(parameterType);
				}
			}
		}
		string name = listType.Name;
		if (name == null || (name.IndexOf("Queue") < 0 && name.IndexOf("Stack") < 0))
		{
			TestEnumerableListPatterns(model, basicList, listType);
			Type[] interfaces = listType.GetInterfaces();
			foreach (Type iType in interfaces)
			{
				TestEnumerableListPatterns(model, basicList, iType);
			}
		}
		PropertyInfo[] properties = listType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (!(propertyInfo.Name != "Item") && !basicList.Contains(propertyInfo.PropertyType))
			{
				ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
				if (indexParameters.Length == 1 && !(indexParameters[0].ParameterType != model.MapType(typeof(int))))
				{
					basicList.Add(propertyInfo.PropertyType);
				}
			}
		}
		switch (basicList.Count)
		{
		case 0:
			return null;
		case 1:
			if ((Type)basicList[0] == listType)
			{
				return null;
			}
			return (Type)basicList[0];
		case 2:
			if ((Type)basicList[0] != listType && CheckDictionaryAccessors(model, (Type)basicList[0], (Type)basicList[1]))
			{
				return (Type)basicList[0];
			}
			if ((Type)basicList[1] != listType && CheckDictionaryAccessors(model, (Type)basicList[1], (Type)basicList[0]))
			{
				return (Type)basicList[1];
			}
			break;
		}
		return null;
	}

	private static void TestEnumerableListPatterns(TypeModel model, BasicList candidates, Type iType)
	{
		if (!iType.IsGenericType)
		{
			return;
		}
		Type genericTypeDefinition = iType.GetGenericTypeDefinition();
		if (genericTypeDefinition == model.MapType(typeof(IEnumerable<>)) || genericTypeDefinition == model.MapType(typeof(ICollection<>)) || genericTypeDefinition.FullName == "System.Collections.Concurrent.IProducerConsumerCollection`1")
		{
			Type[] genericArguments = iType.GetGenericArguments();
			if (!candidates.Contains(genericArguments[0]))
			{
				candidates.Add(genericArguments[0]);
			}
		}
	}

	private static bool CheckDictionaryAccessors(TypeModel model, Type pair, Type value)
	{
		return pair.IsGenericType && pair.GetGenericTypeDefinition() == model.MapType(typeof(KeyValuePair<, >)) && pair.GetGenericArguments()[1] == value;
	}

	private bool TryDeserializeList(TypeModel model, ProtoReader reader, DataFormat format, int tag, Type listType, Type itemType, ref object value)
	{
		bool isList;
		MethodInfo methodInfo = ResolveListAdd(model, listType, itemType, out isList);
		if (methodInfo == null)
		{
			throw new NotSupportedException("Unknown list variant: " + listType.FullName);
		}
		bool result = false;
		object value2 = null;
		IList list = value as IList;
		object[] array = (isList ? null : new object[1]);
		BasicList basicList = (listType.IsArray ? new BasicList() : null);
		while (TryDeserializeAuxiliaryType(reader, format, tag, itemType, ref value2, skipOtherFields: true, asListItem: true, autoCreate: true, insideList: true, value ?? listType))
		{
			result = true;
			if (value == null && basicList == null)
			{
				value = CreateListInstance(listType, itemType);
				list = value as IList;
			}
			if (list != null)
			{
				list.Add(value2);
			}
			else if (basicList != null)
			{
				basicList.Add(value2);
			}
			else
			{
				array[0] = value2;
				methodInfo.Invoke(value, array);
			}
			value2 = null;
		}
		if (basicList != null)
		{
			if (value != null)
			{
				if (basicList.Count != 0)
				{
					Array array2 = (Array)value;
					Array array3 = Array.CreateInstance(itemType, array2.Length + basicList.Count);
					Array.Copy(array2, array3, array2.Length);
					basicList.CopyTo(array3, array2.Length);
					value = array3;
				}
			}
			else
			{
				Array array3 = Array.CreateInstance(itemType, basicList.Count);
				basicList.CopyTo(array3, 0);
				value = array3;
			}
		}
		return result;
	}

	private static object CreateListInstance(Type listType, Type itemType)
	{
		Type type = listType;
		if (listType.IsArray)
		{
			return Array.CreateInstance(itemType, 0);
		}
		if (!listType.IsClass || listType.IsAbstract || Helpers.GetConstructor(listType, Helpers.EmptyTypes, nonPublic: true) == null)
		{
			bool flag = false;
			string fullName;
			if (listType.IsInterface && (fullName = listType.FullName) != null && fullName.IndexOf("Dictionary") >= 0)
			{
				if (listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof(IDictionary<, >))
				{
					Type[] genericArguments = listType.GetGenericArguments();
					type = typeof(Dictionary<, >).MakeGenericType(genericArguments);
					flag = true;
				}
				if (!flag && listType == typeof(IDictionary))
				{
					type = typeof(Hashtable);
					flag = true;
				}
			}
			if (!flag)
			{
				type = typeof(List<>).MakeGenericType(itemType);
				flag = true;
			}
			if (!flag)
			{
				type = typeof(ArrayList);
				flag = true;
			}
		}
		return Activator.CreateInstance(type);
	}

	internal bool TryDeserializeAuxiliaryType(ProtoReader reader, DataFormat format, int tag, Type type, ref object value, bool skipOtherFields, bool asListItem, bool autoCreate, bool insideList, object parentListOrType)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		Type type2 = null;
		ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
		int modelKey;
		WireType wireType = GetWireType(typeCode, format, ref type, out modelKey);
		bool flag = false;
		if (wireType == WireType.None)
		{
			type2 = GetListItemType(this, type);
			if (type2 == null && type.IsArray && type.GetArrayRank() == 1 && type != typeof(byte[]))
			{
				type2 = type.GetElementType();
			}
			if (type2 != null)
			{
				if (insideList)
				{
					throw CreateNestedListsNotSupported((parentListOrType as Type) ?? parentListOrType?.GetType());
				}
				flag = TryDeserializeList(this, reader, format, tag, type, type2, ref value);
				if (!flag && autoCreate)
				{
					value = CreateListInstance(type, type2);
				}
				return flag;
			}
			ThrowUnexpectedType(type);
		}
		while (!(flag && asListItem))
		{
			int num = reader.ReadFieldHeader();
			if (num <= 0)
			{
				break;
			}
			if (num != tag)
			{
				if (skipOtherFields)
				{
					reader.SkipField();
					continue;
				}
				throw ProtoReader.AddErrorData(new InvalidOperationException("Expected field " + tag + ", but found " + num), reader);
			}
			flag = true;
			reader.Hint(wireType);
			if (modelKey >= 0)
			{
				WireType wireType2 = wireType;
				WireType wireType3 = wireType2;
				if ((uint)(wireType3 - 2) <= 1u)
				{
					SubItemToken token = ProtoReader.StartSubItem(reader);
					value = Deserialize(modelKey, value, reader);
					ProtoReader.EndSubItem(token, reader);
				}
				else
				{
					value = Deserialize(modelKey, value, reader);
				}
				continue;
			}
			switch (typeCode)
			{
			case ProtoTypeCode.Int16:
				value = reader.ReadInt16();
				break;
			case ProtoTypeCode.Int32:
				value = reader.ReadInt32();
				break;
			case ProtoTypeCode.Int64:
				value = reader.ReadInt64();
				break;
			case ProtoTypeCode.UInt16:
				value = reader.ReadUInt16();
				break;
			case ProtoTypeCode.UInt32:
				value = reader.ReadUInt32();
				break;
			case ProtoTypeCode.UInt64:
				value = reader.ReadUInt64();
				break;
			case ProtoTypeCode.Boolean:
				value = reader.ReadBoolean();
				break;
			case ProtoTypeCode.SByte:
				value = reader.ReadSByte();
				break;
			case ProtoTypeCode.Byte:
				value = reader.ReadByte();
				break;
			case ProtoTypeCode.Char:
				value = (char)reader.ReadUInt16();
				break;
			case ProtoTypeCode.Double:
				value = reader.ReadDouble();
				break;
			case ProtoTypeCode.Single:
				value = reader.ReadSingle();
				break;
			case ProtoTypeCode.DateTime:
				value = BclHelpers.ReadDateTime(reader);
				break;
			case ProtoTypeCode.Decimal:
				value = BclHelpers.ReadDecimal(reader);
				break;
			case ProtoTypeCode.String:
				value = reader.ReadString();
				break;
			case ProtoTypeCode.ByteArray:
				value = ProtoReader.AppendBytes((byte[])value, reader);
				break;
			case ProtoTypeCode.TimeSpan:
				value = BclHelpers.ReadTimeSpan(reader);
				break;
			case ProtoTypeCode.Guid:
				value = BclHelpers.ReadGuid(reader);
				break;
			case ProtoTypeCode.Uri:
				value = new Uri(reader.ReadString(), UriKind.RelativeOrAbsolute);
				break;
			}
		}
		if (!flag && !asListItem && autoCreate && type != typeof(string))
		{
			value = Activator.CreateInstance(type);
		}
		return flag;
	}

	[Obsolete("Please use RuntimeTypeModel.Create", false)]
	public static RuntimeTypeModel Create()
	{
		return RuntimeTypeModel.Create();
	}

	protected internal static Type ResolveProxies(Type type)
	{
		if (type == null)
		{
			return null;
		}
		if (type.IsGenericParameter)
		{
			return null;
		}
		Type underlyingType = Helpers.GetUnderlyingType(type);
		if (underlyingType != null)
		{
			return underlyingType;
		}
		string fullName = type.FullName;
		if (fullName != null && fullName.StartsWith("System.Data.Entity.DynamicProxies."))
		{
			return type.BaseType;
		}
		Type[] interfaces = type.GetInterfaces();
		Type[] array = interfaces;
		foreach (Type type2 in array)
		{
			switch (type2.FullName)
			{
			case "NHibernate.Proxy.INHibernateProxy":
			case "NHibernate.Proxy.DynamicProxy.IProxy":
			case "NHibernate.Intercept.IFieldInterceptorAccessor":
				return type.BaseType;
			}
		}
		return null;
	}

	public bool IsDefined(Type type)
	{
		return GetKey(ref type) >= 0;
	}

	protected internal int GetKey(ref Type type)
	{
		if (type == null)
		{
			return -1;
		}
		lock (knownKeys)
		{
			if (knownKeys.TryGetValue(type, out var value))
			{
				type = value.Type;
				return value.Key;
			}
		}
		int keyImpl = GetKeyImpl(type);
		Type key = type;
		if (keyImpl < 0)
		{
			Type type2 = ResolveProxies(type);
			if (type2 != null && type2 != type)
			{
				type = type2;
				keyImpl = GetKeyImpl(type);
			}
		}
		lock (knownKeys)
		{
			knownKeys[key] = new KnownTypeKey(type, keyImpl);
		}
		return keyImpl;
	}

	internal void ResetKeyCache()
	{
		lock (knownKeys)
		{
			knownKeys.Clear();
		}
	}

	protected abstract int GetKeyImpl(Type type);

	protected internal abstract void Serialize(int key, object value, ProtoWriter dest);

	protected internal abstract object Deserialize(int key, object value, ProtoReader source);

	public object DeepClone(object value)
	{
		if (value == null)
		{
			return null;
		}
		Type type = value.GetType();
		int key = GetKey(ref type);
		if (key >= 0 && !Helpers.IsEnum(type))
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ProtoWriter protoWriter = ProtoWriter.Create(memoryStream, this))
				{
					protoWriter.SetRootObject(value);
					Serialize(key, value, protoWriter);
					protoWriter.Close();
				}
				memoryStream.Position = 0L;
				ProtoReader protoReader = null;
				try
				{
					protoReader = ProtoReader.Create(memoryStream, this, null, -1L);
					return Deserialize(key, null, protoReader);
				}
				finally
				{
					ProtoReader.Recycle(protoReader);
				}
			}
		}
		if (type == typeof(byte[]))
		{
			byte[] array = (byte[])value;
			byte[] array2 = new byte[array.Length];
			Buffer.BlockCopy(array, 0, array2, 0, array.Length);
			return array2;
		}
		if (GetWireType(Helpers.GetTypeCode(type), DataFormat.Default, ref type, out var modelKey) != WireType.None && modelKey < 0)
		{
			return value;
		}
		using MemoryStream memoryStream2 = new MemoryStream();
		using (ProtoWriter protoWriter2 = ProtoWriter.Create(memoryStream2, this))
		{
			if (!TrySerializeAuxiliaryType(protoWriter2, type, DataFormat.Default, 1, value, isInsideList: false, null))
			{
				ThrowUnexpectedType(type);
			}
			protoWriter2.Close();
		}
		memoryStream2.Position = 0L;
		ProtoReader reader = null;
		try
		{
			reader = ProtoReader.Create(memoryStream2, this, null, -1L);
			value = null;
			TryDeserializeAuxiliaryType(reader, DataFormat.Default, 1, type, ref value, skipOtherFields: true, asListItem: false, autoCreate: true, insideList: false, null);
			return value;
		}
		finally
		{
			ProtoReader.Recycle(reader);
		}
	}

	protected internal static void ThrowUnexpectedSubtype(Type expected, Type actual)
	{
		if (expected != ResolveProxies(actual))
		{
			throw new InvalidOperationException("Unexpected sub-type: " + actual.FullName);
		}
	}

	protected internal static void ThrowUnexpectedType(Type type)
	{
		string text = ((type == null) ? "(unknown)" : type.FullName);
		if (type != null)
		{
			Type baseType = type.BaseType;
			if (baseType != null && baseType.IsGenericType && baseType.GetGenericTypeDefinition().Name == "GeneratedMessage`2")
			{
				throw new InvalidOperationException("Are you mixing protobuf-net and protobuf-csharp-port? See https://stackoverflow.com/q/11564914/23354; type: " + text);
			}
		}
		throw new InvalidOperationException("Type is not expected, and no contract can be inferred: " + text);
	}

	internal static Exception CreateNestedListsNotSupported(Type type)
	{
		return new NotSupportedException("Nested or jagged lists and arrays are not supported: " + (type?.FullName ?? "(null)"));
	}

	public static void ThrowCannotCreateInstance(Type type)
	{
		throw new ProtoException("No parameterless constructor found for " + (type?.FullName ?? "(null)"));
	}

	internal static string SerializeType(TypeModel model, Type type)
	{
		if (model != null)
		{
			TypeFormatEventHandler typeFormatEventHandler = model.DynamicTypeFormatting;
			if (typeFormatEventHandler != null)
			{
				TypeFormatEventArgs e = new TypeFormatEventArgs(type);
				typeFormatEventHandler(model, e);
				if (!string.IsNullOrEmpty(e.FormattedName))
				{
					return e.FormattedName;
				}
			}
		}
		return type.AssemblyQualifiedName;
	}

	internal static Type DeserializeType(TypeModel model, string value)
	{
		if (model != null)
		{
			TypeFormatEventHandler typeFormatEventHandler = model.DynamicTypeFormatting;
			if (typeFormatEventHandler != null)
			{
				TypeFormatEventArgs e = new TypeFormatEventArgs(value);
				typeFormatEventHandler(model, e);
				if (e.Type != null)
				{
					return e.Type;
				}
			}
		}
		return Type.GetType(value);
	}

	public bool CanSerializeContractType(Type type)
	{
		return CanSerialize(type, allowBasic: false, allowContract: true, allowLists: true);
	}

	public bool CanSerialize(Type type)
	{
		return CanSerialize(type, allowBasic: true, allowContract: true, allowLists: true);
	}

	public bool CanSerializeBasicType(Type type)
	{
		return CanSerialize(type, allowBasic: true, allowContract: false, allowLists: true);
	}

	private bool CanSerialize(Type type, bool allowBasic, bool allowContract, bool allowLists)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		Type underlyingType = Helpers.GetUnderlyingType(type);
		if (underlyingType != null)
		{
			type = underlyingType;
		}
		ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
		ProtoTypeCode protoTypeCode = typeCode;
		ProtoTypeCode protoTypeCode2 = protoTypeCode;
		if ((uint)protoTypeCode2 > 1u)
		{
			return allowBasic;
		}
		int key = GetKey(ref type);
		if (key >= 0)
		{
			return allowContract;
		}
		if (allowLists)
		{
			Type type2 = null;
			if (type.IsArray)
			{
				if (type.GetArrayRank() == 1)
				{
					type2 = type.GetElementType();
				}
			}
			else
			{
				type2 = GetListItemType(this, type);
			}
			if (type2 != null)
			{
				return CanSerialize(type2, allowBasic, allowContract, allowLists: false);
			}
		}
		return false;
	}

	public virtual string GetSchema(Type type)
	{
		return GetSchema(type, ProtoSyntax.Proto2);
	}

	public virtual string GetSchema(Type type, ProtoSyntax syntax)
	{
		throw new NotSupportedException();
	}

	internal virtual Type GetType(string fullName, Assembly context)
	{
		return ResolveKnownType(fullName, this, context);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Type ResolveKnownType(string name, TypeModel model, Assembly assembly)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		try
		{
			Type type = Type.GetType(name);
			if (type != null)
			{
				return type;
			}
		}
		catch
		{
		}
		try
		{
			int num = name.IndexOf(',');
			string name2 = ((num > 0) ? name.Substring(0, num) : name).Trim();
			if (assembly == null)
			{
				assembly = Assembly.GetCallingAssembly();
			}
			Type type2 = assembly?.GetType(name2);
			if (type2 != null)
			{
				return type2;
			}
		}
		catch
		{
		}
		return null;
	}

	private static SerializationContext CreateContext(object userState)
	{
		if (userState == null)
		{
			return SerializationContext.Default;
		}
		if (userState is SerializationContext result)
		{
			return result;
		}
		SerializationContext serializationContext = new SerializationContext
		{
			Context = userState
		};
		serializationContext.Freeze();
		return serializationContext;
	}

	T IProtoInput<Stream>.Deserialize<T>(Stream source, T value, object userState)
	{
		return (T)Deserialize(source, value, typeof(T), CreateContext(userState));
	}

	T IProtoInput<ArraySegment<byte>>.Deserialize<T>(ArraySegment<byte> source, T value, object userState)
	{
		using MemoryStream source2 = new MemoryStream(source.Array, source.Offset, source.Count);
		return (T)Deserialize(source2, value, typeof(T), CreateContext(userState));
	}

	T IProtoInput<byte[]>.Deserialize<T>(byte[] source, T value, object userState)
	{
		using MemoryStream source2 = new MemoryStream(source);
		return (T)Deserialize(source2, value, typeof(T), CreateContext(userState));
	}

	void IProtoOutput<Stream>.Serialize<T>(Stream destination, T value, object userState)
	{
		Serialize(destination, value, CreateContext(userState));
	}
}
