using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    float ballSpeed = 15f;
    void Start()
    {
        if(this.gameObject != null)
        {
            Destroy(this.gameObject, 3f);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * ballSpeed);
    }
}
