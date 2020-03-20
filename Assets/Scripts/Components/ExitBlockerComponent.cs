using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBlockerComponent : MonoBehaviour
{
    public Transform target;
    public float distance;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < distance)
        {
            text.color = Color.white;
        }
        else
        {
            text.color = Color.clear;
        }
    }
}
