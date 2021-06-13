using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject explosao;

    public void Start()
    {
        GameLogic.instance.showFinalKey(false);

    }

    public void Killed()
    {
        GameLogic.instance.RemoveChaser();
        GameLogic.instance.showFinalKey(true);
        GameObject e = Instantiate(explosao, transform.position, Quaternion.identity);
        Destroy(e, 5f);
        Destroy(gameObject);
    }
}
