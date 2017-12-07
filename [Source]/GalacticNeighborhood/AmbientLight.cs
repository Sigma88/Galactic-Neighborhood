using UnityEngine;


namespace GalacticNeighborhoodPlugin
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class AmbientLightFix : MonoBehaviour
    {
        void Start()
        {
            if (GameSettings.AMBIENTLIGHT_BOOSTFACTOR == 0)
                GameSettings.AMBIENTLIGHT_BOOSTFACTOR = -0.75f;
        }
    }
}
