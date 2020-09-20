using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
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
    {0,0,0,0,0,0,0,0,0,0,1,0,0,0},
    };

    // Start is called before the first frame update
    void Start()
    {
        generateQuadrants();


    }

    void generateQuadrants(){
        //create all 4 quadrants 
        for (int i = 1; i <= 4; i++){
            GameObject quadrant= createQuadrant(i);

            int caseSwitch = i;
            switch(caseSwitch){
                case 2:
                    quadrant.transform.Translate(-1,0,0);
                    quadrant.transform.Rotate(0.0f, 180f, 0f);
                    break;
                case 3: 
                    quadrant.transform.Translate(0,1,0);
                    quadrant.transform.Rotate(180f, 0f, 0f);
                    break;
                case 4: 
                    quadrant.transform.Translate(-1,1,0);
                    quadrant.transform.Rotate(180f, 180f, 0f);
                    break;
                default:
                    break;

            }

        }

    }

    GameObject createQuadrant(int quadrantNumber){   //position is of left bottom corner

        
        GameObject[] walls = {wall0, wall1, wall2, wall3, wall4, wall5, wall6, wall7};

        GameObject quadrant = new GameObject("quadrant" + quadrantNumber);

        //determine size of quadrant based on quadrantNumber
        int mapSizeX = 14;
        int mapSizeY = (quadrantNumber > 2) ? 14: 15;

        //instantiate quadrant
        for (int j = 0; j < mapSizeY; j++)
            {
                for (int i = 0; i < mapSizeX; i++ ){
                    
                    //instantiate wall piece
                    GameObject wallClone = Instantiate(walls[levelMap[j,i]], new Vector3(0,0,0), Quaternion.Euler(0, 0, -90 * rotationMap[j,i]));
                    wallClone.transform.SetParent(quadrant.transform);
                    wallClone.transform.localPosition = new Vector3(i - (mapSizeX), -j + (mapSizeY), 0 );

                    wallClone.name = "WallClone[" + i + "," + j + "]"; //rename object

                }
            }

        return quadrant;

    }
  
    
}
