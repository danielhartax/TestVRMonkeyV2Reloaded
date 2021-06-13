using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainEffect : MonoBehaviour
{
    public LineRenderer laser;
    public Transform inicio, fim;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        laser.SetPosition(0, transform.TransformPoint(inicio.transform.localPosition));
        laser.SetPosition(1, transform.TransformPoint(fim.transform.localPosition));
    }
}
