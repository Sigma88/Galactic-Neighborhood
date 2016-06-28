using System;
using UnityEngine;


namespace GalacticNeighborhoodPlugin
{
    namespace Components
    {
        public class GalacticNeighborhood : MonoBehaviour
        {
            void Start()
            {
                CelestialBody body = GetComponent<CelestialBody>();
                
                if (body.name == "M-Kel A")
                {
                    foreach (CelestialBody rb in FlightGlobals.Bodies)
                    {
                        if (rb.name == "MK3A")
                        {
                            body.orbit.referenceBody = rb;
                            body.orbitDriver.orbit = new Orbit(body.orbit.inclination, body.orbit.eccentricity, body.orbit.semiMajorAxis / 3d, body.orbit.LAN, body.orbit.argumentOfPeriapsis, body.orbit.meanAnomalyAtEpoch, body.orbit.epoch, body.orbit.referenceBody);
                            body.orbit.ObTAtEpoch = body.orbit.ObTAtEpoch / body.orbit.period;
                            body.orbit.period = 2 * Math.PI * Math.Sqrt(Math.Pow(body.orbit.semiMajorAxis, 3) / (6.674E-11 * rb.Mass));
                            body.orbit.ObTAtEpoch = body.orbit.ObTAtEpoch * body.orbit.period;
                        }
                    }
                }
                if (body.name == "M-Kel B")
                {
                    foreach (CelestialBody rb in FlightGlobals.Bodies)
                    {
                        if (rb.name == "MK3B")
                        {
                            body.orbit.referenceBody = rb;
                            body.orbitDriver.orbit = new Orbit(body.orbit.inclination, body.orbit.eccentricity, body.orbit.semiMajorAxis / 3d, body.orbit.LAN, body.orbit.argumentOfPeriapsis, body.orbit.meanAnomalyAtEpoch, body.orbit.epoch, body.orbit.referenceBody);
                            body.orbit.ObTAtEpoch = body.orbit.ObTAtEpoch / body.orbit.period;
                            body.orbit.period = 2 * Math.PI * Math.Sqrt(Math.Pow(body.orbit.semiMajorAxis, 3) / (6.674E-11 * rb.Mass));
                            body.orbit.ObTAtEpoch = body.orbit.ObTAtEpoch * body.orbit.period;
                        }
                    }
                }
                if (body.name == "M-Kel C")
                {
                    foreach (CelestialBody rb in FlightGlobals.Bodies)
                    {
                        if (rb.name == "MK3C")
                        {
                            body.orbit.referenceBody = rb;
                            body.orbitDriver.orbit = new Orbit(body.orbit.inclination, body.orbit.eccentricity, body.orbit.semiMajorAxis / 3d, body.orbit.LAN, body.orbit.argumentOfPeriapsis, body.orbit.meanAnomalyAtEpoch, body.orbit.epoch, body.orbit.referenceBody);
                            body.orbit.ObTAtEpoch = body.orbit.ObTAtEpoch / body.orbit.period;
                            body.orbit.period = 2 * Math.PI * Math.Sqrt(Math.Pow(body.orbit.semiMajorAxis, 3) / (6.674E-11 * rb.Mass));
                            body.orbit.ObTAtEpoch = body.orbit.ObTAtEpoch * body.orbit.period;
                        }
                    }
                }
            }
        }
    }
}
