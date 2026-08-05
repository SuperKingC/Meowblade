using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class DeviceInfo
{
	[ProtoMember(1)]
	public float BatteryLevel;

	[ProtoMember(2)]
	public string BatteryStatus;

	[ProtoMember(3)]
	public string CopyTextureSupport;

	[ProtoMember(4)]
	public string DeviceModel;

	[ProtoMember(5)]
	public string DeviceName;

	[ProtoMember(6)]
	public string DeviceType;

	[ProtoMember(7)]
	public string DeviceUniqueIdentifier;

	[ProtoMember(8)]
	public int GraphicsDeviceId;

	[ProtoMember(9)]
	public string GraphicsDeviceName;

	[ProtoMember(10)]
	public string GraphicsDeviceType;

	[ProtoMember(11)]
	public string GraphicsDeviceVendor;

	[ProtoMember(12)]
	public int GraphicsDeviceVendorId;

	[ProtoMember(13)]
	public string GraphicsDeviceVersion;

	[ProtoMember(14)]
	public int GraphicsMemorySize;

	[ProtoMember(15)]
	public bool GraphicsMultiThreaded;

	[ProtoMember(16)]
	public int GraphicsShaderLevel;

	[ProtoMember(17)]
	public bool GraphicsUvStartsAtTop;

	[ProtoMember(18)]
	public bool HasDynamicUniformArrayIndexingInFragmentShaders;

	[ProtoMember(19)]
	public bool HasHiddenSurfaceRemovalOnGpu;

	[ProtoMember(20)]
	public bool HasMipMaxLevel;

	[ProtoMember(21)]
	public int MaxComputeBufferInputsCompute;

	[ProtoMember(22)]
	public int MaxComputeBufferInputsDomain;

	[ProtoMember(23)]
	public int MaxComputeBufferInputsFragment;

	[ProtoMember(24)]
	public int MaxComputeBufferInputsGeometry;

	[ProtoMember(25)]
	public int MaxComputeBufferInputsHull;

	[ProtoMember(26)]
	public int MaxComputeBufferInputsVertex;

	[ProtoMember(27)]
	public int MaxComputeWorkGroupSize;

	[ProtoMember(28)]
	public int MaxComputeWorkGroupSizeX;

	[ProtoMember(29)]
	public int MaxComputeWorkGroupSizeY;

	[ProtoMember(30)]
	public int MaxComputeWorkGroupSizeZ;

	[ProtoMember(31)]
	public int MaxCubemapSize;

	[ProtoMember(32)]
	public int MaxTextureSize;

	[ProtoMember(33)]
	public int MinConstantBufferOffsetAlignment;

	[ProtoMember(34)]
	public string NpotSupport;

	[ProtoMember(35)]
	public string OperatingSystem;

	[ProtoMember(36)]
	public string OperatingSystemFamily;

	[ProtoMember(37)]
	public int ProcessorCount;

	[ProtoMember(38)]
	public int ProcessorFrequency;

	[ProtoMember(39)]
	public string ProcessorType;

	[ProtoMember(40)]
	public int RenderingThreadingMode;

	[ProtoMember(41)]
	public int SupportedRandomWriteTargetCount;

	[ProtoMember(42)]
	public int SupportedRenderTargetCount;

	[ProtoMember(43)]
	public bool Supports2DArrayTextures;

	[ProtoMember(44)]
	public bool Supports32BitsIndexBuffer;

	[ProtoMember(45)]
	public bool Supports3DRenderTextures;

	[ProtoMember(46)]
	public bool Supports3DTextures;

	[ProtoMember(47)]
	public bool SupportsAccelerometer;

	[ProtoMember(48)]
	public bool SupportsAsyncCompute;

	[ProtoMember(49)]
	public bool SupportsAsyncGpuReadback;

	[ProtoMember(50)]
	public bool SupportsAudio;

	[ProtoMember(51)]
	public bool SupportsComputeShaders;

	[ProtoMember(52)]
	public bool SupportsCubemapArrayTextures;

	[ProtoMember(53)]
	public bool SupportsGeometryShaders;

	[ProtoMember(54)]
	public bool SupportsGraphicsFence;

	[ProtoMember(55)]
	public bool SupportsGyroscope;

	[ProtoMember(56)]
	public bool SupportsHardwareQuadTopology;

	[ProtoMember(57)]
	public bool SupportsInstancing;

	[ProtoMember(58)]
	public bool SupportsLocationService;

	[ProtoMember(59)]
	public bool SupportsMipStreaming;

	[ProtoMember(60)]
	public bool SupportsMotionVectors;

	[ProtoMember(61)]
	public bool SupportsMultisampleAutoResolve;

	[ProtoMember(62)]
	public int SupportsMultisampledTextures;

	[ProtoMember(63)]
	public bool SupportsRawShadowDepthSampling;

	[ProtoMember(64)]
	public bool SupportsRayTracing;

	[ProtoMember(65)]
	public bool SupportsSeparatedRenderTargetsBlend;

	[ProtoMember(66)]
	public bool SupportsSetConstantBuffer;

	[ProtoMember(67)]
	public bool SupportsShadows;

	[ProtoMember(68)]
	public bool SupportsSparseTextures;

	[ProtoMember(69)]
	public bool SupportsTessellationShaders;

	[ProtoMember(70)]
	public int SupportsTextureWrapMirrorOnce;

	[ProtoMember(71)]
	public bool SupportsVibration;

	[ProtoMember(72)]
	public int SystemMemorySize;

	[ProtoMember(73)]
	public bool UsesLoadStoreActions;

	[ProtoMember(74)]
	public bool UsesReversedZBuffer;

	[ProtoMember(200)]
	public string IDFA;
}
