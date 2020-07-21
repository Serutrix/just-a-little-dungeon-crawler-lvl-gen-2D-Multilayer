using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks : MonoBehaviour
{

    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;

    int vertexIndex = 0;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();

    bool[,,] voxelMap = new bool[VoxelD.ChunkWidth, VoxelD.Chunkhight, VoxelD.ChunkWidth];




    void Start()
    {

        PopulateVoxelMap();
        CreateChunkMesh();
        madeMesh();



    }

    void PopulateVoxelMap()
    {
        for (int y = 0; y < VoxelD.Chunkhight; y++)
        {


            for (int x = 0; x < VoxelD.ChunkWidth; x++)
            {


                for (int z = 0; z < VoxelD.ChunkWidth; z++)
                {
                    voxelMap[x, y, z] = true;



                }
            }
        }
    }

    void CreateChunkMesh()
    {

        for (int y = 0; y < VoxelD.Chunkhight; y++)
        {


            for (int x = 0; x < VoxelD.ChunkWidth; x++)
            {


                for (int z = 0; z < VoxelD.ChunkWidth; z++)
                {
                    AddVoxelDataToChunk(new Vector3(x, y, z));




                }
            }
        }
    }

    bool CheckVoxel (Vector3 pos)
    {
        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(pos.y);
        int z = Mathf.FloorToInt(pos.z);

        if (x < 0 || x > VoxelD.ChunkWidth - 1 || y < 0 || y > VoxelD.Chunkhight - 1 || z < 0 || z > VoxelD.ChunkWidth - 1)
            return false;



        return voxelMap[x, y, z];

    }





    void AddVoxelDataToChunk( Vector3 pos)
    {
        for (int p = 0; p < 6; p++)
        {

            if (!CheckVoxel(pos + VoxelD.faceChecks[p])) { 

            for (int i = 0; i < 6; i++)
            {



                int dreieckverzeichnis = VoxelD.voxelDreieck[p, i];
                vertices.Add(VoxelD.voxelPoints[dreieckverzeichnis] + pos);
                triangles.Add(vertexIndex);

                uvs.Add(Vector2.zero);


                vertexIndex++;


            }
        }
        }
    }

    void madeMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }

}
