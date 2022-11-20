using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ability1 : MonoBehaviour
{ 
    public Image abilityImage;
    public float abilityCooldown = 0.5f;
    public bool abilityIsCd = false;
    public KeyCode abilityKey;
    public Animator animator;
    public Movement movement;

    public GameObject spawnPoint;
    public GameObject abilityPrefab;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage = GameObject.FindGameObjectWithTag("Hud").GetComponent<HudController>().Ability1Image;
        abilityImage.fillAmount = 1;
        animator = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Active();
    }

    void Active() 
    {
        if (Input.GetKey(abilityKey) && !movement.casting && !abilityIsCd)
        {
            movement.casting = true;
            abilityIsCd = true;
            abilityImage.fillAmount = 0;
            movement.Stop();
            movement.LookAtCursor();
            animator.SetTrigger("Ability1");
        }

        if (abilityIsCd)
        {
            abilityImage.fillAmount += 1 / abilityCooldown * Time.deltaTime;

            if (abilityImage.fillAmount >= 1)
            {
                abilityImage.fillAmount = 1;
                abilityIsCd = false;
            }
        }
    }

    void Cast()
    {
        movement.casting = false;
        GameObject skill = Instantiate(abilityPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        skill.GetComponent<FireballSkill>().type = "Player";
    }
}
