using UnityEngine;

namespace EXPToolkit
{
    public class Easing
    {
        public static float InOutQuad(float t)
        {
            if (t < 0.5)
                return 2.0f * t * t;
            return (-2.0f * t * t) + (4 * t) - 1.0f;
        }

        public static float OutQuart(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return -c * (t * t * t * t - 1) + b;
        }

        public static float InOutCubic(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t + 2) + b;
        }

        public static float BackEaseInOut(float t, float b, float c, float d)
        {
            float s = 1.70158f;
            if ((t /= d / 2) < 1)
            {
                return c / 2 * (t * t * (((s *= (1.525f)) + 1) * t - s)) + b;
            }
            return c / 2 * ((t -= 2) * t * (((s *= (1.525f)) + 1) * t + s) + 2) + b;
        }

        public static float BackEaseIn(float t, float b, float c, float d)
        {
            float s = 1.70158f;
            return c * (t /= d) * t * ((s + 1) * t - s) + b;
        }

        public static float ElasticEaseInOut(float t, float b, float c, float d)
        {
            if (t == 0) return b; if ((t /= d / 2) == 2) return b + c;
            float p = d * (.3f * 1.5f);
            float a = c;
            float s = p / 4;
            if (t < 1) return -.5f * (a * (float)Mathf.Pow(2, 10 * (t -= 1)) * (float)Mathf.Sin((t * d - s) * (2 * (float)Mathf.PI) / p)) + b;
            return a * (float)Mathf.Pow(2, -10 * (t -= 1)) * (float)Mathf.Sin((t * d - s) * (2 * (float)Mathf.PI) / p) * .5f + c + b;
        }
    }
}