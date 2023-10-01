using System;
using Main.UI;

namespace Main.Configs {
    [Serializable]
    public class PasswordMiniGameConfig {
        public float StartCatchPosition;
        public float CatchDelta;

        public float SpawnDelta;
        public float LetterSpeed;
        
        public string Password;
        public string[] OtherCharacters;
        public LetterView Prefab;
    }
}