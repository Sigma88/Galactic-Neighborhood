using System.Linq;
using UnityEngine;


namespace GalacticNeighborhoodPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class ConfigNodeRemover : MonoBehaviour
    {
        void Start()
        {
            foreach (UrlDir.UrlConfig node in GameDatabase.Instance.GetConfigs("GalacticNeighborhood").Where(c => c.url != "GalacticNeighborhood/Settings/GalacticNeighborhood"))
            {
                node.parent.configs.Remove(node);
            }
        }
    }
}
