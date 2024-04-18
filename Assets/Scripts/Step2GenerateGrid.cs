using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Step2GenerateGrid : MonoBehaviour
{
    [SerializeField] GameObject blockGameObject;
    [SerializeField] GameObject objectToSpawn;

    [SerializeField] public float gridSizeX=50;
    [SerializeField] public float gridSizeZ=50;
    [SerializeField] public float noiseHeight=5;
    [SerializeField] public float gridOffSet=1;

    private List<Vector3> blockPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        for (int x=0; x<gridSizeX; x++) {       // iterate through the x intervals left to right
            for (int z=0; z<gridSizeZ; z++) {   // iterate through the z intervals up and down
                
                // position of x and z for block
                Vector3 pos = new Vector3(x * gridOffSet, 
                    generatedNoise(x,z,8f), 
                    z * gridOffSet);

                // create block into the position
                GameObject block = Instantiate(blockGameObject, 
                    pos, 
                    Quaternion.identity);

                // add to our list, to keep track
                blockPositions.Add(block.transform.position);
                
                // set the orientation the right way
                block.transform.SetParent(this.transform);
            }
        }
        SpawnObject();
    }
    private void SpawnObject()
    {
        for (int c=0; c < 20; c++) {
            GameObject toPlaceObject = Instantiate(objectToSpawn,
                ObjectSpawnLocation(),
                Quaternion.identity);
        }
    }
    private Vector3 ObjectSpawnLocation() {
        int rndIndex = Random.Range(0, blockPositions.Count);

        Vector3 newPos = new Vector3(
            blockPositions[rndIndex].x,
            blockPositions[rndIndex].y + 0.5f,
            blockPositions[rndIndex].z
            );
        blockPositions.RemoveAt(rndIndex);


        return newPos;
    }
    private float generatedNoise(int x, int z, float detailScale)
    {
        float xNoise = (x + this.transform.position.x) / detailScale;
        float zNoise = (z + this.transform.position.y) / detailScale;

        return Mathf.PerlinNoise(xNoise, zNoise);
    }
}
