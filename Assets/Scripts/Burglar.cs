using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burglar : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
        damageCount = 8f;
        base.DifficultyChecker();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
    

    protected override void EnemyMovement()
    {
        base.EnemyMovement();
    }

    protected override void Shoot()
    {
        base.Shoot();
    }
}