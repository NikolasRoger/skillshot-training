using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;
    public int selectedIndex;

    [SerializeField]
    private TMPro.TextMeshProUGUI CharacterNameText;

    private void Start() {
        selectedIndex = 0;
        LookToTarget();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.RightArrow)) Next();
        if(Input.GetKeyDown(KeyCode.LeftArrow)) Previous();
    }

    private void LookToTarget()
    {
        Vector3 targetPos = characters[selectedIndex].transform.position;
        Vector3 newPos = targetPos;
        newPos.z += 5;
        newPos.y += 5;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = newPos;
        targetPos.y += 5;
        Animator selectedAnimator = characters[selectedIndex].GetComponent<Animator>();
        selectedAnimator.SetTrigger("Pose");
        CharacterNameText.text = characters[selectedIndex].name;
        transform.LookAt(targetPos);
    }

    public void Next()
    {
        if(selectedIndex <= 0) {
            selectedIndex = characters.Length - 1;
        } else {
            selectedIndex -= 1;
        }
        LookToTarget();
    }
    
    public void Previous()
    {
        if(selectedIndex >= characters.Length - 1) {
            selectedIndex = 0;
        } else {
            selectedIndex += 1;
        }
        LookToTarget();
    }

    public void SelectCharacter()
    {
        Debug.Log(characters[selectedIndex].name);
        PlayerPrefs.SetString("character", characters[selectedIndex].name);
        SceneLoader.Instance.LoadSceneAsync("MenuScene");
    }

}
