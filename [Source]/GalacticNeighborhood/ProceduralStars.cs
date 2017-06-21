using UnityEngine;
using Kopernicus;
using Kopernicus.Configuration;
using Kopernicus.Components;


namespace GalacticNeighborhoodPlugin
{
    [ParserTargetExternal("Body", "ProceduralStar", "Kopernicus")]
    public class ProceduralStar : BaseLoader, IParserEventSubscriber
    {
        [ParserTarget("type", optional = true)]
        public EnumParser<StarType> type = StarType.MainSequence;

        [ParserTarget("temperature", optional = true)]
        public NumericParser<int> temperature = 5772;

        [ParserTarget("emitColor0", optional = true)]
        public Texture2DParser emitColor0;

        [ParserTarget("emitColor1", optional = true)]
        public Texture2DParser emitColor1;

        [ParserTarget("emitColorMult", optional = true)]
        public NumericParser<float> emitColorMult;

        [ParserTarget("sunspotColor", optional = true)]
        public Texture2DParser sunspotColor;

        [ParserTarget("sunspotTemp", optional = true)]
        public NumericParser<int> sunspotTemp;

        [ParserTarget("sunspotColorMult", optional = true)]
        public NumericParser<float> sunspotColorMult = 1;

        [ParserTarget("lightColor", optional = true)]
        public Texture2DParser lightColors;

        [ParserTarget("lightColorMult", optional = true)]
        public NumericParser<float> lightColorMult = 1;

        [ParserTarget("rimColorMult", optional = true)]
        public NumericParser<float> rimColorMult;

        [ParserTarget("setOrbit", optional = true)]
        public NumericParser<bool> setOrbit = true;

        void IParserEventSubscriber.Apply(ConfigNode node)
        {
        }

        void IParserEventSubscriber.PostApply(ConfigNode node)
        {
            // Apply changes to the Material
            Material material = generatedBody.scaledVersion.GetComponent<Renderer>()?.sharedMaterial;

            if (material != null)
            {
                if (emitColor0 != null)
                {
                    Color color = Pick(emitColor0);

                    material.SetColor("_EmitColor0", color);

                    if (emitColorMult != null)
                        material.SetColor("_EmitColor1", color * emitColorMult);

                    if (rimColorMult != null)
                        material.SetColor("_RimColor", color * rimColorMult);
                }

                if (emitColor1 != null)
                    material.SetColor("_EmitColor1", Pick(emitColor1));

                if (sunspotColor == null)
                    sunspotColor = emitColor0;

                if (sunspotTemp == null)
                    sunspotTemp = temperature;

                material.SetColor("_SunspotColor", Pick(sunspotColor, sunspotTemp) * sunspotColorMult);

                if (type == StarType.WhiteDwarf)
                {
                    material.SetColor("_EmitColor0", new Color(0.9f, 0.9f, 0.9f, 1));
                    material.SetColor("_EmitColor1", material.GetColor("_EmitColor1") * 0.925f);
                }
            }


            // Apply changes to the LightShifter
            LightShifter light = generatedBody.scaledVersion.GetComponentInChildren<LightShifter>();

            if (light != null)
            {
                if (lightColors == null)
                    lightColors = emitColor0;

                Color color = Pick(lightColors) * lightColorMult;

                light.ambientLightColor = new Color(0, 0, 0, 1);
                light.IVASunColor = color;
                light.scaledSunlightColor = color;
                light.sunlightColor = color;
            }


            // Set Orbit Color
            if (setOrbit.value && emitColor0 != null)
                generatedBody.orbitRenderer.SetColor(Pick(emitColor0));
        }

        Color Pick(Texture2D texture)
        {
            return Pick(texture, temperature);
        }

        Color Pick(Texture2D texture, int temperature)
        {
            int x = (temperature - 2400) / 50;
            x = x < 0 ? 0 : x > texture.width - 1 ? texture.width - 1 : x;

            return texture.GetPixel(x, 0);
        }

        public enum StarType
        {
            BrownDwarf,
            MainSequence,
            RedGiant,
            WhiteDwarf
        }
    }
}
