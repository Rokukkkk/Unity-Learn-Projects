using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float speed = 0;
    [SerializeField] private float rpm = 0;
    [SerializeField] private float turnSpeed = 0;
    [SerializeField] private List<WheelCollider> allWheels;
    private Rigidbody playerRb;
    private TextMeshProUGUI speedometerText;
    private TextMeshProUGUI rpmText;
    private GameObject com;
    private float horizontalInput = 0;
    private float forwardInput = 0;
    private float wheelsOnGround;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        speedometerText = GameObject.Find("Speedometer").GetComponent<TextMeshProUGUI>();
        rpmText = GameObject.Find("Rpm").GetComponent<TextMeshProUGUI>();
        com = GameObject.Find("COM");

        playerRb.centerOfMass = com.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");


        if (isOnGround())
        {
            // Move the vehical forward
            // transform.Translate(speed * forwardInput * Time.deltaTime * Vector3.forward);

            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
            playerRb.AddRelativeForce(horsePower * forwardInput * Vector3.forward);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + " KM/S");
            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
