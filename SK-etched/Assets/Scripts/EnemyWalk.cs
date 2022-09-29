using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    // Start is called before the first frame update
    // documentation of base idea https://docs.unity3d.com/ScriptReference/Vector2.MoveTowards.html
    private GameObject player;
    private float speed = 1.5f;
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }
}
