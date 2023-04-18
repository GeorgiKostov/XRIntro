using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DistanceScaler : MonoBehaviour
{
    public GameObject xrOrigin;

    public float distance;

    private Vector3 startingScale = new Vector3(.001f, .001f, .001f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.xrOrigin != null)
        {
            this.distance = Vector3.Distance(this.transform.position, this.xrOrigin.transform.position);
            this.transform.localScale = new Vector3(startingScale.x * distance, startingScale.y * distance, startingScale.z * distance);
        }
    }

    public void DebugPress()
    {
        Debug.Log("Pressed");
    }
}
