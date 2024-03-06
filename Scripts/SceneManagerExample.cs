namespace Patterns.Arhitecture
{
    public class SceneManagerExample : SceneManagerBase
    {
        public override void InitzializeMap()
        {
            this.sceneConfigMap[SceneConfigExample.SceneName] = new SceneConfigExample();
        }
    }
}
