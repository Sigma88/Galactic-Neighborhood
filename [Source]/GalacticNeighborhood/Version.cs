using UnityEngine;


namespace GalacticNeighborhoodPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Version : MonoBehaviour
    {
        void Awake()
        {
            Debug.Log("[SigmaLog] Version Check:   Galactic Neighborhood v0.4.3");
        }
    }
}
