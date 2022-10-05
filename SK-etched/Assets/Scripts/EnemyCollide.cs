using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    public string borderTag;
    GameObject sceneManager; // integrate with UI team

    // Start is called before the first frame update
    void Start()
    {
        GameObject border = GameObject.FindGameObjectWithTag(borderTag);
        Collider2D thisCollider = GetComponent<Collider2D>();
        Collider2D[] borderColliders = border.GetComponents<Collider2D>();
        foreach (Collider2D c in borderColliders)
            Physics2D.IgnoreCollision(thisCollider, c); // no overlap = no gmod collision. check if that's ok
        //sceneManager = GameObject.FindGameObjectWithTag("Scene Manager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Destroy(this.gameObject);
            
        }
        else if (collision.gameObject.tag == "Projectile")
        { // be sure to change tag w weapon/player team
            
            Destroy(collision.gameObject);//Destroys the weapon/bullet
            //sceneManager.SendMessage("AddPoints"); ex of ui usage
            Destroy(this.gameObject);
        }
    }
}
