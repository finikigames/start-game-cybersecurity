using PasswordGame.Configs;
using Zenject;

namespace PasswordGame.Services {
    public class MainPasswordService : IInitializable,
                                       ITickable {
        private readonly PasswordGameSceneSettings _sceneSettings;
        private readonly LetterGeneratorService _letterGeneratorService;
        private readonly PasswordMiniGameConfig _config;

        public MainPasswordService(PasswordGameSceneSettings sceneSettings,
                                   LetterGeneratorService letterGeneratorService,
                                   PasswordMiniGameConfig config) {
            _sceneSettings = sceneSettings;
            _letterGeneratorService = letterGeneratorService;
            _config = config;
        }
        
        public void Initialize() {
            
        }

        public void Tick() {
        }
    }
}