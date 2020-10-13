using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField]
    GameObject item; 
    public Tweener tweener;
    public Animator animatorController;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
       tweener = GetComponent<Tweener>();

       item.transform.position = new Vector3 (-13,14,2);
    }

    // Update is called once per frame
    void Update()
    {

        // //increment timer
        // timer += Time.deltaTime;
        
        // Vector3 directionVector = Vector3.right;
        // float directionDuration = 0.5f;

        // Vector3 endPos =  item.transform.position + directionVector;
        // tweener.addTween(item.transform, item.transform.position, endPos, directionDuration);

        }
    }

}

