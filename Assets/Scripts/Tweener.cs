using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null){
            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f){
            //calculate time fraction
            float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;
            
            //lerp towards the end point
            Vector3 newPos = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
            activeTween.Target.position = newPos;
        }
        else{
            activeTween.Target.position = activeTween.EndPos;
            activeTween = null;
        }

        }

    }

    public void addTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration){
        if (activeTween is null){
           activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration); 
        }
    }
}
