using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestMenu : MonoBehaviour
{
    [SerializeField]
    int goToLevel = 0;

    [SerializeField]
    int goToLevel2 = 0;

    [SerializeField]
    int goToLevel3 = 0;

    public Text buttonText;
    public Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown("h"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void PressStart()
    {
        buttonText.text = "Pressed";
        myButton.image.color = Color.red;
        SceneManager.LoadScene(goToLevel);
    }

    public void PressReplay()
    {
        //buttonText.text = "Pressed";
        //myButton.image.color = Color.red;
        SceneManager.LoadScene(goToLevel2);
    }

    public void PressTitleScreen()
    {
        //buttonText.text = "Pressed";
        //myButton.image.color = Color.red;
        SceneManager.LoadScene(goToLevel3);
    }
}
