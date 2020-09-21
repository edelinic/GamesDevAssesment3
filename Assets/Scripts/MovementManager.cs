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

       item.transform.position = new Vector3 (-13,14,0);
    }

    // Update is called once per frame
    void Update()
    {

        //increment timer
        timer += Time.deltaTime;
        
        Vector3 directionVector = Vector3.right;
        float directionDuration = 0.5f;

        if (timer > 2.5f){ 
            directionVector = Vector3.down; 
            animatorController.SetTrigger("DownParam");
            };
        if (timer > 4.5f) { 
            directionVector = Vector3.left ;
            animatorController.SetTrigger("LeftParam");
            };
        if (timer > 7.5f) { 
            directionVector = Vector3.up ;
            animatorController.SetTrigger("UpParam");
            };
        
        if (timer < 9.5f) {
            Vector3 endPos =  item.transform.position + directionVector;
            tweener.addTween(item.transform, item.transform.position, endPos, directionDuration);
        }
    }

}

