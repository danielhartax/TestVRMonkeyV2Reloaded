using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public Transform respawnPosition;
    public ParticleSystem recharge;
    public AudioSource rechargeSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == StealthPlayerController.getInstance().gameObject)
        {
            StealthPlayerController.getInstance().ResetEnergy();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject== StealthPlayerController.getInstance().gameObject)
        {
            GameLogic.instance.SetCheckpoint(respawnPosition.position);
            recharge.time = 0;
            recharge.Play();
            rechargeSound.Play();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject == StealthPlayerController.getInstance().gameObject)
        {
            recharge.Stop();
            rechargeSound.Stop();
        }
    }
}
