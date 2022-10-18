using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public float Intensity = 1f;
    public float Mass = 1f;
    public float Stiffness = 1f;
    public float Damping = 0.75f;

    private Mesh _originalMesh, _meshClone;
    private MeshRenderer _meshRenderer;
    private JellyVertex[] jv;
    private Vector3[] vertexArray;

    private void Start()
    {
        _originalMesh = GetComponent<MeshFilter>().sharedMesh;
        _meshClone = Instantiate(_originalMesh);
        GetComponent<MeshFilter>().sharedMesh = _meshClone;
        _meshRenderer = GetComponent<MeshRenderer>();
        jv = new JellyVertex[_meshClone.vertices.Length];
        for (int i = 0; i < _meshClone.vertices.Length; i++)
        {
            jv[i] = new JellyVertex(i, transform.TransformPoint(_meshClone.vertices[i]));
        }
    }

    private void FixedUpdate()
    {
        vertexArray = _originalMesh.vertices;
        for (int i = 0; i < jv.Length; i++)
        {
            Vector3 target = transform.TransformPoint(vertexArray[jv[i].ID]);
            float intensity = (1 - (_meshRenderer.bounds.max.y - target.y) / _meshRenderer.bounds.size.y) * Intensity;
            jv[i].Shake(target, Mass, Stiffness, Damping);
            target = transform.InverseTransformPoint(jv[i].Position);
            vertexArray[jv[i].ID] = Vector3.Lerp(vertexArray[jv[i].ID], target, intensity);
        }

        _meshClone.vertices = vertexArray;

    }

    public class JellyVertex
    {
        public int ID;
        public Vector3 Position;
        public Vector3 Velocity, Force;

        public JellyVertex(int _id, Vector3 _pos)
        {
            ID = _id;
            Position = _pos;
        }

        public void Shake(Vector3 target, float m, float s, float d)
        {
            Force = (target - Position) * s;
            Velocity = (Velocity + Force / m) * d;
            Position += Velocity;
            if ((Velocity + Force + Force / m).magnitude < 0.001f)
            {
                Position = target;
            }
        }

    }
}
