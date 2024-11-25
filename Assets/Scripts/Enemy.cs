using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float damageCount;
    [SerializeField] protected string difficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShotTime");
        difficulty = PlayerPrefs.GetString("Difficulty", "Medium");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void EnemyMovement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected virtual void Shoot()
    {
        
    }

    protected virtual void DifficultyChecker()
    {
        switch (difficulty)
        {
            case "Easy":
                speed -= 1;
                damageCount -= 1;
                break;
            case "Normal":
                speed = speed;
                damageCount = damageCount;
                break;
            case "Hard":
                speed += 2;
                damageCount += 2;
                break;
        }
    }

    IEnumerator ShotTime()
    {
        yield return new WaitForSeconds(3);
        Shoot();
    }
}