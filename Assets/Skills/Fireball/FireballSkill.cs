using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : MonoBehaviour
{
    public float speed;
    public string type;
    public GameObject ExplosionPrefab;

    void Start()
    {
        gameObject.layer = 8;
        speed = 12;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyObject());
        gameObject.transform.TransformDirection(Vector3.forward);
        gameObject.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(type == "Player") 
        {
            if(other.tag == "Enemy" && !other.GetComponent<BotMovement>().die) {
                other.GetComponent<BotMovement>().Die();
                Instantiate(ExplosionPrefab, other.transform.position, new Quaternion(0,0,0,0));
                Destroy(gameObject);
            }
        } else {
            if (other.tag == "Player" && !other.GetComponent<Movement>().die)
            {
                other.GetComponent<PlayerStats>().TakeDamage(30f);
                Instantiate(ExplosionPrefab, other.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(gameObject);
            }
        }
    }
}
