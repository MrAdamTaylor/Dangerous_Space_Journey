using UnityEngine;

namespace DefaultNamespace
{
    public static class MathModule
    {
        private static int[] _bufferClockwise = new int[2]; 
        
        
        public static void AddClockwiseInBuffer(int value)
        {
            if (_bufferClockwise[0] != 0)
            {
                if (_bufferClockwise[1] != 0)
                {
                    int temp = _bufferClockwise[0];
                    _bufferClockwise[0] = value;
                    _bufferClockwise[1] = temp;
                }
                else
                {
                    _bufferClockwise[1] = _bufferClockwise[0];
                    _bufferClockwise[0] = value;
                }
            }
            else
            {
                _bufferClockwise[0] = value;
            }
            //Debug.Log($"Buffer: CurrentValue: {_bufferClockwise[0]} PastValue: {_bufferClockwise[1]}");
        }

        public static bool CompareBuffValue()
        {
            if (_bufferClockwise[1] != 0)
            {
                if (_bufferClockwise[0] != _bufferClockwise[1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static float AroundAngle(float angle)
        {
            while (angle > Constants.MAXANGLEVALUE)
            {
                angle = angle - Constants.MAXANGLEVALUE;
            }
            return angle;
        }

        public static float DotProductXY(Vector3 vec1, Vector3 vec2)
        {
            float dot = vec1.x * vec2.x + vec1.y * vec2.y;
            //Debug.Log($"(Static class): Dot product between object = {dot}");
            return dot;
        }

        public static float AngleBetween(float dot, Vector3 vec1, Vector3 vec2)
        {
            float angle = Mathf.Acos(dot / (vec1.magnitude * vec2.magnitude));
            //Debug.Log($"(StaticMethod): Magnitude from vec1: {vec1.magnitude}, Magnitude from vec2: {vec2.magnitude}, Angle between {angle}");
            return angle;
        }

        public static float TranslateAngleInDegrees(float angle)
        {
            float _angleDegrees = angle * Mathf.Rad2Deg;
            //Debug.Log($"(StaticMethod): Angle in Degree = {_angleDegrees} ");
            return _angleDegrees;
        }

        public static Vector3 CrossProduct(Vector3 v, Vector3 w)
        {
            float xMult = v.y * w.z - v.z * w.y;
            float yMult = v.x * w.z - v.z * w.x;
            float zMult = v.x * w.y - v.y * w.x;
            Vector3 cross = new Vector3(xMult, yMult, zMult);
            //Debug.Log($"(Static Method): Cross Vector: {cross}");
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
            //Debug.Log($"(StaticMethod): Direction {clockwise}");
            return clockwise;
        }


        public static bool DifferenceBetween(float value1, float value2)
        {
            float bigValue;
            float smallValue;

            if (Mathf.Abs(value1) > Mathf.Abs(value2))
            {
                bigValue = value1;
                smallValue = value2;
            }
            else
            {
                bigValue = value2;
                smallValue = value1;
            }

            if ((bigValue - smallValue) > Constants.AngleEpsilon)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static float AngleWithChangeDirection(float _currentValue)
        {
            float new_current = (360f - _currentValue) + 180f;
            return new_current;
        }
        
    }
}