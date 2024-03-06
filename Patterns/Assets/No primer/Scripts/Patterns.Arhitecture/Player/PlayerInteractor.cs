using UnityEngine;

namespace Patterns.Arhitecture
{
    public class PlayerInteractor : Interactor
    {
        public Player player { get; private set; }

        public override void Initzialize()
        {
            base.Initzialize();

            var goPlayer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            goPlayer.name = "Player";
            this.player = goPlayer.AddComponent<Player>();
        }

    }
}
