using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NWH.WheelController3D
{
    public static class WheelControllerUtility
    {
        /// <summary>
        /// Calculates the rotation matrix without allocating new memory.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CalculateRotationMatrix(float steerAngle, ref Matrix4x4 rotationMatrix, ref Quaternion rotationQuaternion)
        {
            // Calculate quaternion from angle axis
            float halfAngle = steerAngle * 0.5f * Mathf.Deg2Rad;
            float sin = Mathf.Sin(halfAngle);
            float cos = Mathf.Cos(halfAngle);
            rotationQuaternion.x = 0;
            rotationQuaternion.y = sin;
            rotationQuaternion.z = 0;
            rotationQuaternion.w = cos;

            // Manually create the rotation matrix from the quaternion
            float x2 = rotationQuaternion.x * rotationQuaternion.x;
            float y2 = rotationQuaternion.y * rotationQuaternion.y;
            float z2 = rotationQuaternion.z * rotationQuaternion.z;
            float xy = rotationQuaternion.x * rotationQuaternion.y;
            float xz = rotationQuaternion.x * rotationQuaternion.z;
            float yz = rotationQuaternion.y * rotationQuaternion.z;
            float wx = rotationQuaternion.w * rotationQuaternion.x;
            float wy = rotationQuaternion.w * rotationQuaternion.y;
            float wz = rotationQuaternion.w * rotationQuaternion.z;

            rotationMatrix.m00 = 1.0f - 2.0f * (y2 + z2);
            rotationMatrix.m01 = 2.0f * (xy - wz);
            rotationMatrix.m02 = 2.0f * (xz + wy);
            rotationMatrix.m03 = 0.0f;

            rotationMatrix.m10 = 2.0f * (xy + wz);
            rotationMatrix.m11 = 1.0f - 2.0f * (x2 + z2);
            rotationMatrix.m12 = 2.0f * (yz - wx);
            rotationMatrix.m13 = 0.0f;

            rotationMatrix.m20 = 2.0f * (xz - wy);
            rotationMatrix.m21 = 2.0f * (yz + wx);
            rotationMatrix.m22 = 1.0f - 2.0f * (x2 + y2);
            rotationMatrix.m23 = 0.0f;

            rotationMatrix.m30 = 0.0f;
            rotationMatrix.m31 = 0.0f;
            rotationMatrix.m32 = 0.0f;
            rotationMatrix.m33 = 1.0f;
        }
        
        /// <summary>
        /// Creates wheel cylinder mesh.
        /// </summary>
        public static Mesh CreateCylinderMesh(int subdivisions, float height, float radius)
        {
            Mesh mesh = new Mesh();

            Vector3[] vertices = new Vector3[(subdivisions + 1) * 2];
            int[] triangles = new int[subdivisions * 6];

            // Create vertices
            float angleStep = 2 * Mathf.PI / subdivisions;
            for (int i = 0; i <= subdivisions; i++)
            {
                float angle = i * angleStep;
                float y = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;
                vertices[i] = new Vector3(-height / 2, y, z);
                vertices[i + subdivisions + 1] = new Vector3(height / 2, y, z);
            }

            // Create triangles
            for (int i = 0; i < subdivisions; i++)
            {
                int mod = subdivisions + 1;
                triangles[i * 6 + 0] = i;
                triangles[i * 6 + 1] = (i + 1) % mod;
                triangles[i * 6 + 2] = 0;
                triangles[i * 6 + 3] = i + mod;
                triangles[i * 6 + 4] = (i + 1) % mod + mod;
                triangles[i * 6 + 5] = mod;
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;

            return mesh;
        }
    }
}
