using AppArchi.Infra;

namespace AppArchi.Facades
{
    public class InfraCore
    {
        private static AudioManager audioManager;
        public static AudioManager AudioManager => audioManager;

        private static EventCenter eventCenter;
        public static EventCenter EventCenter => eventCenter;

        private static ResManager resManager;
        public static ResManager ResManager => resManager;

        private static SceneMgr sceneManager;
        public static SceneMgr SceneManager => sceneManager;

        private static MonoManager monoManager;
        public static MonoManager MonoManager => monoManager;

        public void Init()
        {
            audioManager = new AudioManager();
            eventCenter = new EventCenter();
            resManager = new ResManager();
            sceneManager = new SceneMgr();

            audioManager.Init();
            eventCenter.Init();
        }

        public void Tick()
        {
            monoManager.Tick();
        }
    }

}
