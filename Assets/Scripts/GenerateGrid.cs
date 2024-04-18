using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    [SerializeField] GameObject blockGameObject;

    [SerializeField] public float gridSizeX=10;
    //[SerializeField] public float gridSizeY=10;
    [SerializeField] public float gridSizeZ=10;

    [SerializeField] public float gridOffSet=1;

    // Start is called before the first frame update
    void Start()
    {
        for (int x=0; x<gridSizeX; x++) {       // iterate through the x intervals left to right
            for (int z=0; z<gridSizeZ; z++) {   // iterate through the z intervals up and down

                Vector3 pos = new Vector3(x * gridOffSet, 0, z * gridOffSet);

                GameObject block = Instantiate(blockGameObject, pos, Quaternion.identity);

                block.transform.SetParent(this.transform);
            }
        }
    }

}
