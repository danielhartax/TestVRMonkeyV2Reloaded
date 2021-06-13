using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float resistencia = 3;
    private Renderer material;
    private float crackDoEscudo;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>();
        crackDoEscudo = 2 / resistencia;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "BulletPlayer")
        {
            if (resistencia > 0)
            {
                resistencia--;

                float valor = material.material.GetFloat("_DissolveHide");
                valor += crackDoEscudo;
                material.material.SetFloat("_DissolveHide", valor);
            }
            else
            {
                transform.parent.GetComponent<Boss>().Killed();
            }
            other.SendMessage("DestroyBullet", true);
        }
    }
}
