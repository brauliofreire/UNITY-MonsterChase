using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    public int monsterHP;
    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = monsterHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void TakeDamager(int damager)
    {
        currentHP -= damager;
    }
}
