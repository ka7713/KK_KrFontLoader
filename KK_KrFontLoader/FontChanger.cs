using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KK_KrFontLoader
{
	internal class ChangeFontUGUI
	{
		static UnityEngine.Font fFont = null;
		static bool fLoaded = false;

		private static void LoadFont()
		{
			if (fFont == null && !fLoaded)
			{
				fLoaded = true;

				fFont = FontAsset.Asset?.LoadAsset<UnityEngine.Font>(Plugin.Font_Chat);

				if (fFont == null)
				{
#if DEBUG
					Plugin.LogMessage("Failed to load UnityEngine.Font");
#endif
				}
			}
		}

		public static void SetFont(object graphic)
		{
			if (!(graphic is UnityEngine.UI.Text))
			{
#if DEBUG
				Plugin.LogMessage("not found type 1 {0}", graphic.GetType());
#endif
				return;
			}

			LoadFont();

			if (fFont != null)
			{
				try
				{
					if (graphic is UnityEngine.UI.Text)
					{
						var tmp = graphic as UnityEngine.UI.Text;
						if (tmp.font != fFont)
						{
#if DEBUG
							Plugin.LogMessage("{0} {1} p {2}", tmp.font.name, tmp.font.fontSize, tmp.transform.parent.name);
#endif
							tmp.font = fFont;
							tmp.material = fFont.material;
						}
					}
					else
					{
#if DEBUG
						Plugin.LogMessage("found type 2 {0}", graphic.GetType());
#endif
					}
				}
				catch (Exception e)
				{
					Plugin.LogError(e.ToString());
				}
			}
		}
	}

	internal class ChangeFontTMP
	{
		static TMPro.TMP_FontAsset fTMPro_Font = null;
		static bool fLoaded = false;

		private static void LoadFont()
		{
			if (fTMPro_Font == null && !fLoaded)
			{
				fTMPro_Font = FontAsset.Asset?.LoadAsset< TMPro.TMP_FontAsset>(Plugin.Font_TMP);

				if (fTMPro_Font == null)
				{
					Plugin.LogError("Failed to load TMP_FontAsset {0}", Plugin.Font_TMP);
				}
			}
		}

		public static void SetFont(object graphic)
		{
			if (!(graphic is TMPro.TextMeshProUGUI))
			{
				if (!(graphic is UnityEngine.UI.Text))
				{
#if DEBUG
					Plugin.LogMessage("found type {0}", graphic.GetType());
#endif
				}

				return;
			}

			LoadFont();

			if (fTMPro_Font != null)
			{
				try
				{
					if (graphic is TMPro.TextMeshProUGUI)
					{
						var tmp = graphic as TMPro.TextMeshProUGUI;
						if (tmp.font != fTMPro_Font)
						{
							tmp.font = fTMPro_Font;
							tmp.fontSharedMaterial = fTMPro_Font.material;
						}
					}
					else
					{
#if DEBUG
						Plugin.LogMessage("found type {0}", graphic.GetType());
#endif
					}
				}
				catch (Exception e)
				{
					Plugin.LogError(e.ToString());
				}
			}
		}
	}
}
