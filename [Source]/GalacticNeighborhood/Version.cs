using UnityEngine;


namespace GalacticNeighborhoodPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Version : MonoBehaviour
    {
        public static readonly string number = "v.0.4.5";
        void Awake()
        {
            Debug.Log("[SigmaLog] Version Check:   Galactic Neighborhood " + number);
        }
    }
}
