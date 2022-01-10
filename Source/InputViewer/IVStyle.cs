using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace InputViewer
{
    public static class IVStyle
    {

        readonly static string bundlesFolder = Path.Combine(Path.GetDirectoryName(InputViewer.Instance.Info.Location), "Bundles");

        public static AssetBundle uiBundle;
        public static Font inputViewerFont;
        public static Dictionary<string, Texture2D> uiTexture2DAssets = new Dictionary<string, Texture2D>();
        public static Texture2D viewerBG;

        static void LoadAssets()
        {
            uiBundle = AssetBundle.LoadFromFile(Path.Combine(bundlesFolder, "UI"));
            Texture2D[] texture = uiBundle.LoadAllAssets<Texture2D>();
            for (int i = 0; i < texture.Length; i++)
            {
                uiTexture2DAssets.Add(texture[i].name, texture[i]);
            }
            uiTexture2DAssets.Add("BlankTexture", new Texture2D(0, 0));
            inputViewerFont = uiBundle.LoadAsset<Font>("assets/ui/elements.ttf");
            foreach (var s in IVStyle.uiTexture2DAssets) Debug.Log(s.Key);
        }

        public static void ATInit()
        {
            LoadAssets();
        }

        public static GUIStyle InputViewerBG
        {
            get
            {
                GUIStyleState bg = new GUIStyleState();
                bool express = InputViewer.Instance.excludeExpressions.Value;
                //string viewerBg = express ? "ViewerMiniBG" : "ViewerBG";
                string viewerBg = "ViewerBG";
                switch (InputViewer.Instance.backgroundTransparency.Value)
                {
                    case 6:
                        bg.background = uiTexture2DAssets[$"BlankTexture"]; break;
                    case 5:
                        bg.background = uiTexture2DAssets[$"{viewerBg}_50"]; break;
                    case 4:
                        bg.background = uiTexture2DAssets[$"{viewerBg}_60"]; break;
                    case 3:
                        bg.background = uiTexture2DAssets[$"{viewerBg}_70"]; break;
                    case 2:
                        bg.background = uiTexture2DAssets[$"{viewerBg}_80"]; break;
                    case 1:
                        bg.background = uiTexture2DAssets[$"{viewerBg}_90"]; break;
                    default:
                        bg.background = uiTexture2DAssets[$"{viewerBg}"]; break;
                }
                bg.textColor = Color.white;

                GUIStyle gUIStyle = new GUIStyle()
                {
                    font = inputViewerFont,
                    normal = bg,
                    onNormal = bg,
                    hover = bg,
                    onHover = bg,
                    active = bg,
                    onActive = bg,
                };
                return gUIStyle;
            }
        }

        static readonly int combatKeySize = 32;
        static readonly RectOffset btnMargin = new RectOffset(-3, -3, -3, -3);

        public static GUIStyle CombatBtnStyle
        {
            get
            {
                GUIStyle gUIStyle = new GUIStyle()
                {
                    fontSize = 20,
                    alignment = TextAnchor.MiddleCenter,
                    fontStyle = FontStyle.Bold,
                    padding = new RectOffset(4, 4, 4, 4),
                    margin = btnMargin,
                    fixedHeight = combatKeySize,
                    fixedWidth = combatKeySize,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle SwingStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["SwingOff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["SwingOn"],
                    textColor = Color.black
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle BuntStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["BuntOff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["BuntOn"],
                    textColor = Color.black
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle GrabStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["GrabOff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["GrabOn"],
                    textColor = Color.black
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle TauntStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["TauntOff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["TauntOn"],
                    textColor = Color.black
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle JumpStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["JumpOff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["JumpOn"],
                    textColor = Color.black
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle DirUpStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["ArrowUOff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["ArrowUOn"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle DirDwnStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["ArrowDOff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["ArrowDOn"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle DirLefStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["ArrowLOff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["ArrowLOn"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle DirRigStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["ArrowROff"],
                    textColor = Color.black
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["ArrowROn"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(CombatBtnStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle ExpressStyle
        {
            get
            {
                GUIStyle gUIStyle = new GUIStyle()
                {
                    alignment = TextAnchor.MiddleCenter,
                    fontStyle = FontStyle.Bold,
                    padding = new RectOffset(0, 0, 0, 0),
                    margin = new RectOffset(0, 0, 0, 0),
                    fixedWidth = 64,
                    fixedHeight = 32,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle ExpNiceStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["NiceOff"],
                    textColor = Color.white
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["NiceOn"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(ExpressStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle ExpOopsStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["OopsOff"],
                    textColor = Color.white
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["OopsOn"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(ExpressStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }
        public static GUIStyle ExpWowStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["WowOff"],
                    textColor = Color.white
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["WowOn"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(ExpressStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }

        public static GUIStyle ExpBringItStyle
        {
            get
            {
                GUIStyleState off = new GUIStyleState
                {
                    background = uiTexture2DAssets["BringItOff"],
                    textColor = Color.white
                };

                GUIStyleState on = new GUIStyleState
                {
                    background = uiTexture2DAssets["BringItOn"],
                    textColor = Color.white
                };

                GUIStyle gUIStyle = new GUIStyle(ExpressStyle)
                {
                    normal = off,
                    hover = off,
                    active = off,
                    onNormal = on,
                    onHover = on,
                    onActive = on,
                };
                return gUIStyle;
            }
        }

    }
}
