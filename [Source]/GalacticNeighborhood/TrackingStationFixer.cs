﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace GalacticNeighborhoodPlugin
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    class TrackingStationFixer : MonoBehaviour
    {
        void Start()
        {
            // Remove barycenters from the tracking station
            List<MapObject> trackingstation = new List<MapObject>();
            string[] hide = { "MK1A", "MK1B", "MK1C", "MK2A", "MK2B", "MK2C", "MK3A", "MK3B", "MK3C", "MKelA", "MKelB", "MKelC" };

            foreach (MapObject m in PlanetariumCamera.fetch.targets)
            {
                if (m != null)
                {
                    if (!hide.Contains(m.celestialBody.transform.name))
                    {
                        trackingstation.Add(m);
                    }
                    if (m.celestialBody.transform.name == "MKel")
                    {
                        foreach (string c in new[] { "MKelA", "MKelB", "MKelC" })
                        {
                            trackingstation.Add(PlanetariumCamera.fetch.targets.Find(obj => obj?.celestialBody?.transform?.name == c));
                        }
                    }
                }
            }

            PlanetariumCamera.fetch.targets.Clear();
            PlanetariumCamera.fetch.targets.AddRange(trackingstation);

            // Fix initialTarget (Multiple Kerbin templates bug workaround)
            Resources.FindObjectsOfTypeAll<PlanetariumCamera>().FirstOrDefault().initialTarget = Resources.FindObjectsOfTypeAll<ScaledMovement>().FirstOrDefault(o => o.celestialBody.isHomeWorld);
        }
    }
}
