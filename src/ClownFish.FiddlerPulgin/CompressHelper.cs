using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.FiddlerPulgin
{
	public static class CompressHelper
	{
		public static string GzipCompress(string input)
		{
			if( string.IsNullOrEmpty(input) )
				return input;

			byte[] bb = Encoding.UTF8.GetBytes(input);
			byte[] gzipBB = GzipCompress(bb);
			return Convert.ToBase64String(gzipBB);
		}

		public static string GzipDecompress(string base64)
		{
			if( string.IsNullOrEmpty(base64) )
				return base64;

			byte[] bb = Convert.FromBase64String(base64);
			byte[] gzipBB = GzipDecompress(bb);
			return Encoding.UTF8.GetString(gzipBB);
		}

		public static byte[] GzipCompress(byte[] input)
		{
			if( input == null )
				throw new ArgumentNullException("input");


			using( MemoryStream sourceStream = new MemoryStream(input) ) {
				using( MemoryStream resultStream = new MemoryStream() ) {
					using( GZipStream gZipStream = new GZipStream(resultStream, CompressionMode.Compress, true) ) {

						byte[] buffer = new byte[1024 * 4]; //缓冲区大小

						int sourceBytes = sourceStream.Read(buffer, 0, buffer.Length);
						while( sourceBytes > 0 ) {
							gZipStream.Write(buffer, 0, sourceBytes);
							sourceBytes = sourceStream.Read(buffer, 0, buffer.Length);
						}
						//gZipStream.Flush();
						gZipStream.Close();

						resultStream.Position = 0;
						return resultStream.ToArray();
					}
				}
			}
		}

		public static byte[] GzipDecompress(byte[] input)
		{
			if( input == null )
				throw new ArgumentNullException("input");


			using( MemoryStream sourceStream = new MemoryStream(input) ) {
				using( GZipStream gZipStream = new GZipStream(sourceStream, CompressionMode.Decompress, true) ) {
					using( MemoryStream resultStream = new MemoryStream() ) {
						byte[] buffer = new byte[1024 * 4]; //缓冲区大小
						int sourceBytes = gZipStream.Read(buffer, 0, buffer.Length);
						while( sourceBytes > 0 ) {
							resultStream.Write(buffer, 0, sourceBytes);
							sourceBytes = gZipStream.Read(buffer, 0, buffer.Length);
						}
						resultStream.Position = 0;
						return resultStream.ToArray();
					}
				}
			}
		}




	}
}
