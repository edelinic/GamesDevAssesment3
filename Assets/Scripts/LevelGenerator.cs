using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject mapContainer;
    public GameObject wall0;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject wall5;
    public GameObject wall6;
    public GameObject wall7;


    int[,] levelMap =
    {
    {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
    {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
    {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
    {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
    {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
    {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
    {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
    {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
    {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
    {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
    {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
    {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
    {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
    {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
    {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    }; 

    int[,] rotationMap = {
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {3,0,0,0,0,0,0,0,0,0,0,0,0,1},
    {3,0,0,0,0,1,0,0,0,0,0,1,0,1},
    {3,0,1,0,0,1,0,1,0,0,0,1,0,1},
    {3,0,3,2,2,2,0,3,2,2,2,2,0,3},
    {3,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {3,0,0,0,0,1,0,0,1,0,0,0,0,0},
    {3,0,3,0,0,2,0,3,3,0,3,0,0,1},
    {3,0,0,0,0,0,0,3,3,0,0,0,0,1},
    {3,2,2,2,2,1,0,3,3,0,0,1,0,1},
    {0,0,0,0,0,1,0,3,0,0,0,2,0,3},
    {0,0,0,0,0,1,0,3,3,0,0,0,0,0},
    {0,0,0,0,0,1,0,3,3,0,0,0,0,0},
    {0,0,2,2,2,2,0,3,2,0,1,0,0,0},
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    };

    // Start is called before the first frame update
    void Start()
    {
    
    GameObject[] walls = {wall0, wall1, wall2, wall3, wall4, wall5, wall6, wall7};

    //instantiate quadrant
    for (int j = 0; j < 14; j++)
        {
            for (int i = 0; i < 14; i++ ){
                GameObject wallClone = Instantiate(walls[levelMap[j,i]], new Vector3(i * 1.0F, j * -1.0F, 0 ), Quaternion.Euler(0, 0, -90 * rotationMap[j,i]));
                wallClone.transform.parent = mapContainer.transform;
                wallClone.name = "WallClone[" + i + "," + j + "]";
            }
        }

    //Instantiate(mapContainer,  new Vector3(5, 5, 0 ), Quaternion.identity );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
