using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using Kopernicus.Components;
using Kopernicus.Configuration;

using SigmaGalacticNeighborhood.Configuration;


namespace SigmaGalacticNeighborhood
{
    namespace Components
    {
        public class MKelFixer : MonoBehaviour
        {

            public string realReference;
            public double realSMA;

            void Start()
            {
                CelestialBody body = GetComponent<CelestialBody>();

                if (!MKelLoader.ArchivesFixerList.Contains("MK1A"))
                    MKelLoader.ArchivesFixerList.Add("MK1A");
                if (!MKelLoader.ArchivesFixerList.Contains("MK1B"))
                    MKelLoader.ArchivesFixerList.Add("MK1B");
                if (!MKelLoader.ArchivesFixerList.Contains("MK1C"))
                    MKelLoader.ArchivesFixerList.Add("MK1C");

                if (!string.IsNullOrEmpty(realReference))
                {
                    if (realSMA > 0)
                    {
                        body.orbit.semiMajorAxis = realSMA;
                        Debug.Log("MKELog: SMA for body " + body.name + " was changed to " + body.orbit.semiMajorAxis.ToString());
                    }
                    foreach (CelestialBody reference in FlightGlobals.Bodies)
                    {
                        if (reference.name == realReference)
                        {
                            body.orbit.ObTAtEpoch = body.orbit.ObTAtEpoch * Math.Pow(body.referenceBody.Mass / reference.Mass, 0.5);
                            body.orbitDriver.referenceBody = reference;
                            body.orbit.period = 2 * Math.PI * Math.Sqrt(Math.Pow(body.orbit.semiMajorAxis, 3) / (6.674E-11 * reference.Mass));
                            Debug.Log("MKELog: Reference for body " + body.name + " was changed to " + reference.name);
                        }
                    }
                }
            }
        }
    }
}
