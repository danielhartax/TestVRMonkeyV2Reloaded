using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    public GameObject splash;

    public AudioSource som;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            GameObject s = Instantiate(splash, col.transform.position, Quaternion.Euler(new Vector3(-90f, 0f, 0f)));
            som.Play();
            Destroy(s, 3f);
            StealthPlayerController colCharacter = col.GetComponent<StealthPlayerController>();
            colCharacter.SetEnergy(0.5f);
        }

    }
}
