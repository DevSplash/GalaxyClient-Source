using MelonLoader;

namespace Galaxy.Main
{
    public class GalaxyClient : MelonMod
    {  
#pragma warning disable CS0612 // Type or member is obsolete
        public override void OnApplicationStart() => Load.OnStar();
#pragma warning restore CS0612 // Type or member is obsolete

        public override void OnUpdate() => Load.NONOMETHOD();

        public override void OnApplicationLateStart() => Load.OVERSLEEP();

        public override void OnApplicationQuit() => Load.Quitter();
    }
}
