using UnityEngine;


namespace GalacticNeighborhoodPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class Version : MonoBehaviour
    {
        public static readonly System.Version number = new System.Version("0.4.6");

        void Awake()
        {
            Debug.Log("[SigmaLog] Version Check:   Galactic Neighborhood v" + number);
        }
    }
}
