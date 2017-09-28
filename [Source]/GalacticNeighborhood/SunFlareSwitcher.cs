using System.Collections.Generic;
using UnityEngine;
using Kopernicus.Components;


namespace GalacticNeighborhoodPlugin
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    class SunFlareSwitcher : MonoBehaviour
    {
        static KopernicusStar activeStar = null;
        internal static Dictionary<string, Flare> activeFlares = new Dictionary<string, Flare>();
        static Flare oldFlare = null;

        void Awake()
        {
            // Don't destroy SunFlareFixer if needed
            if (activeFlares.Count > 0)
                DontDestroyOnLoad(this);
        }

        void Update()
        {
            // When StarLightSwitcher changes the active star
            if (KopernicusStar.Current != activeStar && activeFlares.ContainsKey(KopernicusStar.Current.name))
            {
                // Restore default sunFlare
                if (activeStar != null && oldFlare != null)
                    activeStar.sunFlare.flare = oldFlare;

                // Select current activeStar
                activeStar = KopernicusStar.Current;

                // Backup default flare and load activeFlare
                if (activeStar != null && activeStar.sunFlare != null)
                {
                    oldFlare = activeStar.sunFlare.flare;
                    activeStar.sunFlare.flare = activeFlares[activeStar.name];
                }
            }
        }
    }
}
