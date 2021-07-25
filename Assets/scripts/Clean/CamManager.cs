using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public SpriteRenderer ground;

    // Start is called before the first frame update
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = ground.bounds.size.x / ground.bounds.size.y;

        if(screenRatio >= targetRatio)
		{
            Camera.main.orthographicSize = ground.bounds.size.y/2;
		}
		else
		{
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = ground.bounds.size.y / 2 * differenceInSize;
        }
    }

}
