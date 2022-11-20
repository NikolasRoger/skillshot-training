using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public float life;
    public float maxLife;
    public Image lifebar;

    private GameController gameController;
    private Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        maxLife = 100;
        movement = GetComponent<Movement>();
        lifebar = GameObject.FindGameObjectWithTag("Hud").GetComponent<HudController>().LifeBarImage;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update() 
    {
        if(life <= 0) 
        {
            movement.Die();
            gameController.endAt = new Time();
        }
        if(life > 100) {
            life = 100;
        }
        lifebar.fillAmount = life / maxLife;
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
    }
}
