using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCat : MonoBehaviour
{
    Transform Target;
    [SerializeField] float snapSpd = 15f;
    [SerializeField] Vector3 offset = new Vector3(0, 0, -20);
    Vector3 Final, Smoothing;
    float roomW, roomH, camBoxH, camBoxW, aspectRatio;


    void Awake()
    {
        Target = GameObject.Find("catowo").GetComponent<Transform>();
        roomW = GameObject.Find("Room").GetComponent<Renderer>().bounds.extents.x;
        roomH = GameObject.Find("Room").GetComponent<Renderer>().bounds.extents.y;
        camBoxH = GetComponent<Camera>().orthographicSize;
    }

    void Update()
    {
        aspectRatio = (float) Screen.width / (float) Screen.height;
        camBoxW = aspectRatio * camBoxH;
    }

    void FixedUpdate()
    {   
        Final = Target.position + offset;
        Smoothing = Vector3.Lerp(transform.position, Final, snapSpd * Time.deltaTime);
        if(Smoothing.x + camBoxW > roomW){Smoothing.x = roomW - camBoxW;}
        if(Smoothing.x - camBoxW < -roomW){Smoothing.x = -roomW + camBoxW;}
        if(Smoothing.y + camBoxH > roomH){Smoothing.y = roomH - camBoxH;}
        transform.position = Smoothing;
    }
}
