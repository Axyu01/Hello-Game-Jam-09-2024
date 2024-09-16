using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshProcedural : MonoBehaviour
{
    public NavMeshSurface Surface2D;

    void Start()
    {
        Surface2D.BuildNavMeshAsync();
    }
    private void Update()
    {
        Surface2D.UpdateNavMesh(Surface2D.navMeshData);
    }
}
