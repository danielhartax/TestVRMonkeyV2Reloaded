using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{

    public bool friend = false;
    public float damage = 10;
    public float speed = 6;
    public float lifetime = 2;
    float currentTime = 0;

    public GameObject explosao;


    void FixedUpdate()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        currentTime += Time.deltaTime;
        if (currentTime > lifetime)
        {
            DestroyBullet(false);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Scenario"))
            {
                DestroyBullet(true);
            }
        }
    }



    void DestroyBullet(bool effect = true)
    {
        if (effect && explosao != null)
        {
            GameObject ef = Instantiate(explosao, transform.position, Quaternion.identity);
            Destroy(ef.gameObject, 3f);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {


        Character colCharacter = col.GetComponent<Character>();
        if (colCharacter != null && colCharacter.friend != friend)
        {
            /*colCharacter.DealDamage(damage);
            DestroyBullet();*/

            if (colCharacter.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                colCharacter.DealDamage(damage);
                DestroyBullet(true);

            }
            else
            {
                DestroyBullet(true);
                colCharacter.GetComponent<AIAgent>().Shutdown();
            }
        }
    }




}
