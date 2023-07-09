using System;
using System.Runtime.InteropServices;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder
{
	internal class RawRgbaFloat16Encoder : IRawEncoder
	{
		public byte[] Encode(ReadOnlyMemory<ColorRgba32> pixels)
		{
			var span = pixels.Span;

			var output = new byte[pixels.Length * 2 * 4];
			var outputFloat16 = MemoryMarshal.Cast<byte, Half>(output);

			for (var i = 0; i < pixels.Length; i++)
			{
				outputFloat16[i * 4] = span[i].b;
				outputFloat16[i * 4 + 1] = span[i].g;
				outputFloat16[i * 4 + 2] = span[i].r;
				outputFloat16[i * 4 + 3] = span[i].a;
			}
			return output;
		}

		public GlInternalFormat GetInternalFormat() => throw new NotImplementedException();
		public GlFormat GetBaseInternalFormat() => throw new NotImplementedException();
		public GlFormat GetGlFormat() => throw new NotImplementedException();
		public GlType GetGlType() => throw new NotImplementedException();
		public uint GetGlTypeSize() => throw new NotImplementedException();

		public DxgiFormat GetDxgiFormat()
		{
			return DxgiFormat.DxgiFormatR16G16B16A16Float;
		}
	}
}
