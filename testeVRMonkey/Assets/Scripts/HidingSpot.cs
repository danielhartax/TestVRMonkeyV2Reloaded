using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            StealthPlayerController.getInstance().hidden = true;
            GameObject poof = GameObject.Instantiate(EffectsManager.getInstance().boxEffect, transform.position, Quaternion.identity);
            Destroy(poof, 1f);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            //GameObject.Instantiate(EffectsManager.getInstance().boxEffect, transform.position, Quaternion.identity);
            StealthPlayerController.getInstance().hidden = false;
        }
    }
}
