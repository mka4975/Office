using UnityEngine;

public class movementCamera : MonoBehaviour
{
    public float speed = 2.0f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Vector3 previousPosition = new Vector3(0, 0, 0);
    private Quaternion previousRotation = new Quaternion(0, 0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        //rotating the camera with the mouse
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        ///move camera with arrowkeys
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveRight();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDown();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveUp();
        }

        //Left mouse button goes to center position
        if (Input.GetMouseButtonDown(0))
        {
            moveToCenterPosition();
        }

        //Right mouse button goes to previous position
        if (Input.GetMouseButtonDown(1))
        {
            moveToPreviousPosition();
        }
    }

    #region Movement Methods
    private void moveRight()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    private void moveLeft()
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }

    private void moveDown()
    {
        transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
    }

    private void moveUp()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    private void moveToCenterPosition()
    {
        previousPosition = transform.position;
        previousRotation = transform.rotation;
        transform.position = new Vector3(-0.56f, 2.51f, 0.21f);
    }

    private void moveToPreviousPosition()
    {
        transform.position = previousPosition;
        transform.rotation = previousRotation;
    }
    #endregion
}
