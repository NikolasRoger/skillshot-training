using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCanvasController : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats;
    
    [SerializeField]
    private Image lifeBarImage;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0,0,0);
        lifeBarImage.fillAmount = playerStats.life / playerStats.maxLife;
    }
}
