using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStomper : MonoBehaviour
{

    public int damagerToDeal;
    private Rigidbody2D myBody;
    public float bounceForce;

    // Start is called before the first frame update
    void Start()
    {
        myBody = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Hurtbox"))
        {            
            var monsterHP = collision.gameObject.GetComponent<MonsterHP>();
            monsterHP.TakeDamager(damagerToDeal);
            myBody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
