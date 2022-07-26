using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    private float length, starPos;
    public GameObject cam;
    public float parallax;

    // Start is called before the first frame update
    void Start()
    {
        starPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallax));
        float dist = (cam.transform.position.x*parallax) ;
        transform.position = new Vector3(starPos + dist, transform.position.y, transform.position.z);

        if (temp > starPos + length) starPos += length;
        else if (temp < starPos - length) starPos -= length;
    }
}
