using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthPotionController : MonoBehaviour
{
    public Image abilityImage;
    public TMPro.TextMeshProUGUI QtdText;
    public float Qtd;
    public KeyCode abilityKey;
    public float damage;

    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage = GameObject.FindGameObjectWithTag("Hud").GetComponent<HudController>().AbilityPotionImage;
        QtdText = GameObject.FindGameObjectWithTag("Hud").GetComponent<HudController>().AbilityPotionText;
        playerStats = GetComponent<PlayerStats>();
        damage = 30;
    }

    // Update is called once per frame
    void Update()
    {
        QtdText.text = Qtd.ToString();
        VerifyUse();
    }

    void VerifyUse()
    {
        if(Input.GetKeyDown(abilityKey) && Qtd > 0)
        {
            Qtd--;
            playerStats.life += damage;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Drop")) {
            Qtd++;
            Destroy(other.gameObject);
        }
    }
}
