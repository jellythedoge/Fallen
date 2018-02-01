using System;

namespace Fallen.Other
{
    class Maths
    {
        public struct QAngle
        {
            public float x;
            public float y;
            public float z;

            public QAngle(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        };

        public struct Vector3D
        {
            public float x;
            public float y;
            public float z;

            public Vector3D(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public static Vector3D operator +(Vector3D v1, Vector3D v2)
            {
                return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
            }

            public static Vector3D operator -(Vector3D v1, Vector3D v2)
            {
                return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
            }

            public static Vector3D operator *(Vector3D v1, Vector3D v2)
            {
                return new Vector3D(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
            }

            public static Vector3D operator /(Vector3D v1, Vector3D v2)
            {
                return new Vector3D(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
            }

            public float VectorDistance(Vector3D v1, Vector3D v2)
            {
                return (float)Math.Sqrt(Math.Pow(v1.x - v2.x, 2) + Math.Pow(v1.y - v2.y, 2) + Math.Pow(v1.z - v2.z, 2));
            }

            public Vector3D VectorClone()
            {
                return new Vector3D(x, y, z);
            }
        };

        public struct Vector2D
        {
            public float x;
            public float y;

            public Vector2D(float x, float y)
            {
                this.x = x;
                this.y = y;
            }

            public static Vector2D operator +(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.x + v2.x, v1.y + v2.y);
            }

            public static Vector2D operator -(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.x - v2.x, v1.y - v2.y);
            }

            public static Vector2D operator *(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.x * v2.x, v1.y * v2.y);
            }

            public static Vector2D operator /(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.x / v2.x, v1.y / v2.y);
            }

            public float VectorDistance(Vector2D v1, Vector2D v2)
            {
                return (float)Math.Sqrt(Math.Pow(v1.x - v2.x, 2) + Math.Pow(v1.y - v2.y, 2));
            }

            public Vector2D VectorClone()
            {
                return new Vector2D(x, y);
            }
        };

        public static Vector3D ClampAngle(Vector3D angle)
        {
            while (angle.y > 180) angle.y -= 360;
            while (angle.y < -180) angle.y += 360;

            if (angle.x > 89.0f) angle.x = 89.0f;
            if (angle.x < -89.0f) angle.x = -89.0f;

            angle.z = 0f;

            return angle;
        }

        public static Vector3D NormalizeAngle(Vector3D angle)
        {
            while (angle.x < -180.0f) angle.x += 360.0f;
            while (angle.x > 180.0f) angle.x -= 360.0f;

            while (angle.x < -180.0f) angle.y += 360.0f;
            while (angle.x > 180.0f) angle.y -= 360.0f;

            while (angle.z < -180.0f) angle.z += 360.0f;
            while (angle.z > 180.0f) angle.z -= 360.0f;

            return angle;
        }
    }
}