using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [8/08/2024]
 * [Allows Player to move around and interact with game environment]
 */

public class PlayerController : MonoBehaviour
{
    //default game player controller values
    public float playerSpeed = 5f;

    //custom player defined player controller values (loaded for player save)

    //Vector2 movement values
    private Vector2 moveValueX;
    private Vector2 moveValueY;

    //reference to a player save config file
    //public PlayerSaveConfig playerSave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //move in the direction of the current x and y movement values * players speed
        transform.Translate(new Vector3(moveValueX.x, moveValueY.y, 0f) * (Time.deltaTime * playerSpeed));
    }

    /// <summary>
    /// Allows the player to move around
    /// </summary>
    /// <param name="context"> the context in which the button was pressed </param>
    public void OnMove(InputAction.CallbackContext context)
    {
        //store x and y Vector 2 movement values and set the players looking direction on move
        moveValueX = context.ReadValue<Vector2>();
        moveValueY = context.ReadValue<Vector2>();
        //SetRotation(moveValueX, moveValueY);
    }

    /// <summary>
    /// Set the player model's rotation based on the movement direction
    /// </summary>
    /// <param name="moveX"> the x value input </param>
    /// <param name="moveY"> the y value input </param>
    private void SetRotation(Vector2 moveX, Vector2 moveY)
    {
        switch (moveY.y)
        {
            //if moveY.y is equal to -1 rotate to 180 degrees
            case -1f:
                transform.GetChild(0).eulerAngles = new Vector3(0f, 180f, 0f);
                break;
            //if moveY.y is equal to 1 rotate to 0 degrees
            case 1f:
                transform.GetChild(0).eulerAngles = new Vector3(0f, 0f, 0f);
                break;
        }

        switch (moveX.x)
        {
            //if moveX.x is equal to -1 rotate to -90 degrees
            case -1f:
                transform.GetChild(0).eulerAngles = new Vector3(0f, -90f, 0f);
                break;
            //if moveX.x is equal to 1 rotate to 90 degrees
            case 1f:
                transform.GetChild(0).eulerAngles = new Vector3(0f, 90f, 0f);
                break;
        }

        //if moveX.x is between 0.7f and 0.9f
        if (moveX.x > 0.7f && moveX.x < 0.9f)
        {
            //if moveY.y is between 0.7f and 0.9f
            if (moveY.y > 0.7f && moveY.y < 0.9f)
            {
                //rotate to 45 degrees
                transform.GetChild(0).eulerAngles = new Vector3(0f, 45f, 0f);
            }
            //if moveY.y is between -0.7f and -0.9f
            else if (moveY.y < -0.7f && moveY.y > -0.9f)
            {
                //rotate to 135 degrees
                transform.GetChild(0).eulerAngles = new Vector3(0f, 135f, 0f);
            }
        }
        //if moveX.x is between -0.7f and -0.9f
        else if (moveX.x < -0.7f && moveX.x > -0.9f)
        {
            //if moveY.y is between 0.7f and 0.9f
            if (moveY.y > 0.7f && moveY.y < 0.9f)
            {
                //rotate to -45 degrees
                transform.GetChild(0).eulerAngles = new Vector3(0f, -45f, 0f);
            }
            //if moveY.y is between -0.7f and -0.9f
            else if (moveY.y < -0.7f && moveY.y > -0.9f)
            {
                //rotate to -135 degrees
                transform.GetChild(0).eulerAngles = new Vector3(0f, -135f, 0f);
            }
        }
    }
}
