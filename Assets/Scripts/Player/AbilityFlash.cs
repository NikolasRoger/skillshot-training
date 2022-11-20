using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityFlash : MonoBehaviour
{
    public Image abilityImage;
    public float abilityCooldown;
    public bool abilityIsCd = false;
    public float abilityRange = 3.5f;
    public KeyCode abilityKey;
    public Movement movement;
    public ParticleSystem flashVfx;
    public AudioSource flashAudio;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        abilityCooldown = 15f;
        abilityImage = GameObject.FindGameObjectWithTag("Hud").GetComponent<HudController>().AbilityFlashImage;
        abilityImage.fillAmount = 1;
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        Active();
    }


    void Active()
    {
        if (Input.GetKey(abilityKey) && !movement.casting && !abilityIsCd)
        {
            abilityIsCd = true;
            abilityImage.fillAmount = 0;
            movement.Stop();
            movement.LookAtCursor();
            target = GetMousePositionWithMaxRange();
            flashVfx.Play();
            flashAudio.Play();
            transform.position = target;
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

    Vector3 GetMousePositionWithMaxRange()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        groundPlane.Raycast(cameraRay, out rayLength);
        Vector3 pointToLook = cameraRay.GetPoint(rayLength);
        var hitPosDir = (pointToLook - transform.position).normalized;

        float distance = Vector3.Distance(pointToLook, transform.position);
        distance = Mathf.Min(distance, abilityRange);
        return transform.position + hitPosDir * distance;
    }
}
