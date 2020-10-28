using LLHandlers;
using LLModdingTools;
using LLScreen;
using UnityEngine;

namespace InputViewer
{
    class InputViewer : MonoBehaviour
    {

#pragma warning disable IDE0051 // Remove unused private members
        public const string modVersion = "1.2.0";
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
            Instance.tag = "InputViewer";
            DontDestroyOnLoad(gameObject); // Makes sure our game object isn't destroyed
            IVStyle.ATInit();
        }

        static JOFJHDJHJGI CurrentGameState => DNPFJHMAIBP.HHMOGKIMBNM();
        static GameMode CurrentGameMode => JOMBNFKIHIC.GIGAKBJGFDI.PNJOKAICMNN;
        static bool IsOnline => JOMBNFKIHIC.GDNFJCCCKDM;

        void Awake()
        {
            SaveSystem.Init();
        }

        private void Start()
        {
            Debug.Log("[LLBMM] InputViewer Started");
            if (MMI == null) { MMI = gameObject.AddComponent<ModMenuIntegration>(); Debug.Log("[LLBMM] InputViewer: Added GameObject \"ModMenuIntegration\""); }
            Load_InputViewerPosition();
        }

        private void OnDestroy()
        {
            Debug.Log("[LLBMM] InputViewer Destroyed");
        }

        bool InGame => World.instance != null && (CurrentGameState == JOFJHDJHJGI.CDOFDJMLGLO || CurrentGameState == JOFJHDJHJGI.LGILIJKMKOD) && !UIScreen.loadingScreenActive;
        float selectViewingMode = 4;
        public int BackgroundTransparency { get; private set; }
        bool scaleToResolution = false;
        public bool excludeExpressions = false;

        void ModMenuInit()
        {
            if ((MMI != null && !modIntegrated) || LLModMenu.ModMenu.Instance.currentOpenMod == "InputViewer")
            {
                selectViewingMode = MMI.GetSliderValue("(slider)selectViewingMode");
                excludeExpressions = MMI.GetTrueFalse(MMI.configBools["(bool)miniInputViewer"]);
                BackgroundTransparency = MMI.GetSliderValue("(slider)backgroundTransparency");
                scaleToResolution = MMI.GetTrueFalse(MMI.configBools["(bool)scaleWithResolution"]);
                if (!modIntegrated) { Debug.Log("[LLBMM] InputViewer: ModMenuIntegration Done"); };
                modIntegrated = true;
            }
        }
#if DEBUG
        //Method to Log all the active game objects
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

        void Auto_Save()
        {
            if (inputRect.position != posUpdated)
            {
                saveTimer += Time.deltaTime;
                if (CountDown(ref saveTimer, 5f))
                {
                    Save_InputViewerPosition();
                    posUpdated = inputRect.position;
                }
            }
        }

        void Save_InputViewerPosition()
        {
            SaveData save = new SaveData
            {
                inputViwerPos = inputRect.position,
            };
            string json = JsonUtility.ToJson(save);
            SaveSystem.Save(json);
            Debug.Log("[LLBMM] Saved");
        }
        void Load_InputViewerPosition(bool isReload = false)
        {
            string saveString = SaveSystem.Load();
            if (saveString != null)
            {
                SaveData saveLoad = JsonUtility.FromJson<SaveData>(saveString);
                posUpdated = inputRect.position = saveLoad.inputViwerPos;
                Debug.Log("[LLBMM] InputViewer: Loaded Overlay Position");
            }
            else if (isReload == false)
            {
                string json = JsonUtility.ToJson(new SaveData());
                SaveSystem.Save(json);
                Debug.Log("[LLBMM] InputViewer: Default Save Data Created");
                Load_InputViewerPosition(true);
            }
            else
            {
                Debug.Log("[LLBMM] (Debug) InputViewer: Load Failed");
            }
        }

        Vector2 posUpdated;
        float saveTimer;

        static bool CountDown(ref float timer, float duration)
        {
            if (timer > 0 && timer < duration) // Cooldown in seconds
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
            }
            return timer == 0;
        }

        void Update()
        {
            ModMenuInit();
            Auto_Save();
#if DEBUG
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                Save_InputViewerPosition();
            }

            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                Load_InputViewerPosition();
            }
#endif

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

        Vector2 inputSizeMini = new Vector2(165, 117);
        Vector2 inputSize = new Vector2(300, 117);
        Rect inputRect = new Rect(30, GUITools.GUI_Height - 147, 300, 117);

        void OnGUI()
        {
            if (scaleToResolution)
            {
                GUITools.ScaleGUIToViewPort();
            }
            if (ViewingMode((ViewMode)selectViewingMode) || LLModMenu.ModMenu.Instance.inModOptions)
            {
                inputRect.size = excludeExpressions ? inputSizeMini : inputSize;

                inputRect = GUILayout.Window(102289, inputRect, InputWindow, "", IVStyle.InputViewerBG);
            }
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

        bool ViewingMode(ViewMode selectedView)
        {
            switch (selectedView)
            {
                case ViewMode.Off:
                    return false;
                case ViewMode.Training:
                    return CurrentGameMode == GameMode.TRAINING && InGame;
                case ViewMode.local:
                    return !IsOnline && InGame;
                case ViewMode.Online:
                    return IsOnline && InGame;
                case ViewMode.All:
                    return InGame;
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
                margin = new RectOffset(5, 5, 6, 16),
                padding = new RectOffset(0, 0, 0, 0),
                wordWrap = false,
                clipping = TextClipping.Overflow,
            };

            GUIStyle border = new GUIStyle()
            {
                padding = new RectOffset(3, 3, 0, 0),
            };

            GUI.DragWindow();
            GUILayoutOption[] gUILayoutOption = new GUILayoutOption[]
            {
                GUILayout.MinWidth(inputRect.size.x),
                GUILayout.MinHeight(inputRect.size.y),
                GUILayout.MaxWidth(inputRect.size.x),
                GUILayout.MaxHeight(inputRect.size.y),
            };
            GUILayout.BeginHorizontal(border, gUILayoutOption);

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

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            if (excludeExpressions == false)
            {
                GUILayout.BeginVertical();
                GUILayout.FlexibleSpace();
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
            }
            GUILayout.EndHorizontal();
        }

    }
}
