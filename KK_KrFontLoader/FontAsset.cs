using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace KK_KrFontLoader
{
	internal class FontAsset
	{
		static UnityEngine.AssetBundle fFont_asset = null;
		static bool fLoaded = false;

		public static UnityEngine.AssetBundle Asset
		{
			get
			{
				if (fFont_asset == null && !fLoaded)
				{
					fLoaded = true;

					using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(Plugin.Font_Path))
					{
						if (stream != null)
						{
							byte[] ba = new byte[stream.Length];
							stream.Read(ba, 0, ba.Length);
							fFont_asset = UnityEngine.AssetBundle.LoadFromMemory(ba);
						}
					}

					if (fFont_asset == null)
                    {
						Plugin.LogError("Failed to load font!");
                    }
                }

				return fFont_asset;
			}
		}
	}
}
