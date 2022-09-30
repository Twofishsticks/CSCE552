using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserMovement : MonoBehaviour
{
    public float speed = 7f;
    public float flighttime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(this.gameObject, flighttime);
        Physics2D.IgnoreLayerCollision(6,6);
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 direction = Input.mousePosition;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.Translate(mousePosition * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Wall" | collision.gameObject.tag == "Enemy")
        Destroy(this.gameObject);
    }
}
