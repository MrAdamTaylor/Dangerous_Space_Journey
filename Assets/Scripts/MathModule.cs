using UnityEngine;

namespace DefaultNamespace
{
    public static class MathModule
    {

        public static float DotProductXY(Vector3 vec1, Vector3 vec2)
        {
            float dot = vec1.x * vec2.x + vec1.y * vec2.y;
            //Debug.Log($"(Static class): Dot product between object = {dot}");
            return dot;
        }

        public static float AngleBetween(float dot, Vector3 vec1, Vector3 vec2)
        {
            float angle = Mathf.Acos(dot / (vec1.magnitude * vec2.magnitude));
            Debug.Log($"(StaticMethod): Magnitude from vec1: {vec1.magnitude}, Magnitude from vec2: {vec2.magnitude}, Angle between {angle}");
            return angle;
        }

        public static float TranslateAngleInDegrees(float angle)
        {
            float _angleDegrees = angle * Mathf.Rad2Deg;
            Debug.Log($"(StaticMethod): Angle in Degree = {_angleDegrees} ");
            return _angleDegrees;
        }

        public static Vector3 CrossProduct(Vector3 v, Vector3 w)
        {
            float xMult = v.y * w.z - v.z * w.y;
            float yMult = v.x * w.z - v.z * w.x;
            float zMult = v.x * w.y - v.y * w.x;
            Vector3 cross = new Vector3(xMult, yMult, zMult);
            Debug.Log($"(Static Method): Cross Vector: {cross}");
            //Debug.DrawRay(Rect.transform.position, cross, Color.blue, 10f);
            return cross;
        }


        public static int GetClockWise(Vector3 cross)
        {
            int clockwise = -1;
            if (cross.z > 0)
            {
                clockwise = 1; 
            }
            Debug.Log($"(StaticMethod): Direction {clockwise}");
            return clockwise;
        }
    }
}