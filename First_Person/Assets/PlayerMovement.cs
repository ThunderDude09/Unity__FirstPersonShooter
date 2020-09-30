using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float rotSpeed = 0;

    [SerializeField]
    float rotSpeed2 = 0;

    [SerializeField]
    Transform lookUpDown;


    [SerializeField]
    float moveSpeed = 1;

    [SerializeField]
    float jumpSpeed = 1;

    [SerializeField]
    Transform cam;

    [SerializeField]
    int goToLevel2 = 0;

    [SerializeField]
    Image bar;
    float playerHp = 60;

    [SerializeField]
    int goToLevel = 0;

    public bool isGrounded;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateHUD();
    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, x * rotSpeed, 0));
        lookUpDown.Rotate(new Vector3(y * rotSpeed2, 0, 0));

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool player_jump = Input.GetButtonDown("Jump");

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camForward * v * moveSpeed) + (camRight * h * moveSpeed);

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        if (player_jump && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x,
                                  jumpSpeed,
                                  rb.velocity.z);
        }

        if (Input.GetKeyDown("g"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown("h"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("AmmoBox"))
        {
            Destroy(collision.gameObject);
            PlayerShoot.instance.UpdateAmmo();
        }
        if (collision.gameObject.CompareTag("KillZone"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(goToLevel);
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            playerHp -= 1;
            Debug.Log(playerHp);
            UpdateHUD();
        }

        if (playerHp == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(goToLevel);
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

    void UpdateHUD()
    {
        bar.fillAmount = (float)playerHp / 60;
    }
}
