using LLHandlers;
using LLScreen;
using UnityEngine;
using UnityEngine.UI;

namespace InputViewer
{
    class InputViewer : MonoBehaviour
    {

#pragma warning disable IDE0051 // Remove unused private members
        private const string modVersion = "1.1";
        private const string repositoryOwner = "Daioutzu";
        private const string repositoryName = "LLBMM-InputViewer";
#pragma warning restore IDE0051

        public static InputViewer Instance { get; private set; } = null;
        public static ModMenuIntegration MMI = null;
        private bool modIntegrated;
        public static void Initialize()
        {
            GameObject gameObject = new GameObject("InputViewer"); //The game object is what we use to interact with our mod
            Instance = gameObject.AddComponent<InputViewer>();
            DontDestroyOnLoad(gameObject); // Makes sure our game object isn't destroyed
            IVStyle.ATInit();
        }

        private void Start()
        {
            if (MMI == null) { MMI = gameObject.AddComponent<ModMenuIntegration>(); Debug.Log("[LLBMM] InputViewer: Added GameObject \"ModMenuIntegration\""); }
            Debug.Log("[LLBMM] InputViewer Started");
        }

        private void OnDestroy()
        {
            Debug.Log("[LLBMM] InputViewer Destroyed");
        }

        bool InGame => World.instance != null && (GetCurrentGameState() == JOFJHDJHJGI.CDOFDJMLGLO || GetCurrentGameState() == JOFJHDJHJGI.LGILIJKMKOD) && !UIScreen.loadingScreenActive;
        float selectViewingMode = 4;
        public int BackgroundTransparency { get; private set; }
        bool showInLobby = false;
        bool altLocation = true;

        void ModMenuInit()
        {
            if ((MMI != null && !modIntegrated) || LLModMenu.ModMenu.Instance.currentOpenMod == "InputViewer")
            {
                selectViewingMode = MMI.GetSliderValue("(slider)selectViewingMode");
                BackgroundTransparency = MMI.GetSliderValue("(slider)backgroundTransparency");
                showInLobby = MMI.GetTrueFalse(MMI.configBools["(bool)showInLobby"]);
                altLocation = MMI.GetTrueFalse(MMI.configBools["(bool)altLocation"]);
                if (!modIntegrated) { Debug.Log("[LLBMM] InputViewer: ModMenuIntegration Done"); };
                modIntegrated = true;
            }
        }
        //Method to Log all the active game objects
#if DEBUG
        void PrintAllGameObjects()
        {
            string txt = "";
            foreach (var name in FindObjectsOfType<GameObject>())
            {
                string str = (name.transform.parent != null) ? name.transform.parent.gameObject.name : "NO_PARENT";
                txt += $"{str}/{name.name}\n";
            }
            Debug.Log(txt);
        }
#endif
        void Update()
        {
            ModMenuInit();
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Cursor.visible = !Cursor.visible;
            }

            //Experimental Code - not much to see here.
#if DEBUG
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                Cursor.visible = !Cursor.visible;
                GameObject header = new GameObject("header", typeof(Image), typeof(LayoutElement));
                GameObject body = new GameObject("body", typeof(Image), typeof(LayoutElement));
                GameObject frame = new GameObject("frame", typeof(VerticalLayoutGroup));
                GameObject panel = new GameObject("panel", typeof(Image));
                GameObject canvas = new GameObject("canvas", typeof(Canvas), typeof(CanvasScaler));

                panel.transform.SetParent(canvas.transform);
                frame.transform.SetParent(panel.transform);
                header.transform.SetParent(frame.transform);
                body.transform.SetParent(frame.transform);

                header.GetComponent<LayoutElement>().minHeight = 50;
                body.GetComponent<LayoutElement>().minHeight = 100;
                body.GetComponent<LayoutElement>().preferredHeight = 999;

                canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                canvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
                canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1280, 720);

                panel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
                panel.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                panel.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                panel.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);

                RectTransform frameRect = frame.GetComponent<RectTransform>();
                VerticalLayoutGroup frameVertGroup = frame.GetComponent<VerticalLayoutGroup>();
                frameRect.anchorMin = new Vector2(0, 0);
                frameRect.anchorMax = new Vector2(0, 0);
                frameRect.pivot = new Vector2(0.5f, 0.5f);
                frameRect.sizeDelta = new Vector2(550, 300);
                frameRect.position = new Vector2(300, 203);
                frameVertGroup.spacing = 10;
                frameVertGroup.childControlHeight = true;
                frameVertGroup.childControlWidth = true;
                frameVertGroup.childForceExpandHeight = true;
                frameVertGroup.childForceExpandWidth = true;
            }
#endif
        }

        Rect inputRectLeft = new Rect(30, Screen.height - 147, 300, 117);
        Rect inputRectRight = new Rect(Screen.width - 350, Screen.height - 147, 300, 117);

        void OnGUI()
        {
            if (ViewingMode((ViewMode)selectViewingMode) || LLModMenu.ModMenu.Instance.inModOptions)
            {
                if (altLocation)
                {
                    inputRectRight = GUILayout.Window(102289, inputRectRight, InputWindow, "", IVStyle.InputViewerBG);
                }
                else
                {
                    inputRectLeft = GUILayout.Window(102289, inputRectLeft, InputWindow, "", IVStyle.InputViewerBG);
                }
            }
        }

        JOFJHDJHJGI GetCurrentGameState()
        {
            return DNPFJHMAIBP.HHMOGKIMBNM();
        }

        GameMode GetCurrentGameMode()
        {
            return JOMBNFKIHIC.GIGAKBJGFDI.PNJOKAICMNN;
        }

        bool IsOnline()
        {
            return JOMBNFKIHIC.GDNFJCCCKDM;
        }

        enum ViewMode
        {
            Off,
            Training,
            local,
            Online,
            All,
        }

        enum GameState
        {
            LOBBY_STORY = 23,
            LOBBY_TUTORIAL = 12,
            LOBBY_TRAINING = 11,
            LOBBY_CHALLENGE = 6,
            LOBBY_LOCAL = 4,
            GAME = 19,
            GAME_PAUSE = 20,
            LOBBY_ONLINE = 5,
        }

        bool LocalLobby()
        {
            if (!showInLobby) return false;

            switch (GetCurrentGameState())
            {
                case (JOFJHDJHJGI)GameState.LOBBY_LOCAL:
                case (JOFJHDJHJGI)GameState.LOBBY_TRAINING:
                case (JOFJHDJHJGI)GameState.LOBBY_CHALLENGE:
                case (JOFJHDJHJGI)GameState.LOBBY_TUTORIAL:
                case (JOFJHDJHJGI)GameState.LOBBY_STORY:
                    return true;
                default:
                    return false;
            }
        }

        bool OnlineLobby()
        {
            if (!showInLobby) return false;

            switch (GetCurrentGameState())
            {
                case (JOFJHDJHJGI)GameState.LOBBY_ONLINE:
                    return true;
                default:
                    return false;
            }
        }

        bool ViewingMode(ViewMode selectedView)
        {
            switch (selectedView)
            {
                case ViewMode.Off:
                    return false;
                case ViewMode.Training:
                    return GetCurrentGameMode() == GameMode.TRAINING && (InGame || (showInLobby && GetCurrentGameState() == (JOFJHDJHJGI)GameState.LOBBY_TRAINING));
                case ViewMode.local:
                    return !IsOnline() && (InGame || LocalLobby());
                case ViewMode.Online:
                    return IsOnline() && (InGame || OnlineLobby());
                case ViewMode.All:
                    return InGame || LocalLobby() || OnlineLobby();
                default:
                    return false;
            }
        }

        void InputWindow(int wId)
        {
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                if (ALDOKEMAOMB.BJDPHEHJJJK(i).GAFCIHKIGNM && ALDOKEMAOMB.BJDPHEHJJJK(i).NGLDMOLLPLK)
                {
                    index = i;
                    i = 4;
                }
            };
            ALDOKEMAOMB player = ALDOKEMAOMB.BJDPHEHJJJK(index);

            GUIStyle headerStyle = new GUIStyle(GUI.skin.label)
            {
                font = IVStyle.inputViewerFont,
                fontSize = 20,
                alignment = TextAnchor.MiddleLeft,
                margin = new RectOffset(10, 0, 3, 14),
                wordWrap = false,
            };

            GUIStyle border = new GUIStyle()
            {
                padding = new RectOffset(4, 4, 0, 0),
            };

            GUIStyle expressBorder = new GUIStyle()
            {
                padding = new RectOffset(8, 8, 8, 8),
                fixedWidth = 150,
            };

            GUI.DragWindow();
            GUILayout.BeginHorizontal(border);

            GUILayout.BeginVertical();
            GUILayout.Label("Input Viewer", headerStyle);
            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.JUMP)] == 100, "", IVStyle.JumpStyle);
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.UP)] == 100, "", IVStyle.DirUpStyle);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.LEFT)] == 100, "", IVStyle.DirLefStyle);
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.DOWN)] == 100, "", IVStyle.DirDwnStyle);
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.RIGHT)] == 100, "", IVStyle.DirRigStyle);
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.SWING)] == 100, "", IVStyle.SwingStyle); //Swing Button
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.BUNT)] == 100, "", IVStyle.BuntStyle); //Bunt Button
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.GRAB)] == 100, "", IVStyle.GrabStyle); //Grab Button
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.TAUNT)] == 100, "", IVStyle.TauntStyle); //Taunt Button
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();

            GUILayout.BeginVertical(expressBorder);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.EXPRESS_UP)] == 100, "", IVStyle.ExpNiceStyle);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.EXPRESS_LEFT)] == 100, "", IVStyle.ExpOopsStyle);
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.EXPRESS_RIGHT)] == 100, "", IVStyle.ExpWowStyle);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Toggle(InputHandler.currentInput[player.CJFLMDNNMIE, InputAction.ActionToIndex(InputAction.EXPRESS_DOWN)] == 100, "", IVStyle.ExpBringItStyle);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
        }

    }
}
