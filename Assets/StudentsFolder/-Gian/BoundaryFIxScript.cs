using UnityEngine;

public class BoundaryFIxScript : MonoBehaviour
{
    // declare variables
    public float respawn_x;
    public float respawn_y;
    public float respawn_z;

    //set it to false for release
    public bool debug_spawn = true;

    public bool flag_isOutofBounds = false;
    public int outOfBoundsTimer = 0;

    void Start()
    {
        // then declare the float values
        respawn_x = 11.708f;
        respawn_y = 1.371f;
        respawn_z = 6.84f;

        //reset to default values
        flag_isOutofBounds = false;
        outOfBoundsTimer = 0;
    }

    void Update()
    {
        //debug purposes
        if (Input.GetKeyDown(KeyCode.U) && debug_spawn)
        {
            Debug.Log("DEBUG: Respawned Player.");
            respawnPlayer();
        }

        // this loop is checked each frame if the player is in the area or not
        checkBoundary();
        // begin timer if the flag is enabled
        if (flag_isOutofBounds)
        {
            outOfBoundsTimer++;
        }

        // if timer reaches a certain amount, respawn player and reset the values
        if (outOfBoundsTimer > 200)
        {
            respawnPlayer();
            outOfBoundsTimer = 0;
            flag_isOutofBounds = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //check if the player collides with any object with a specific tag
        if (col.gameObject.tag == "OutOfBounds")
        {
            respawnPlayer();
        }
    }

    public void checkBoundary()
    {
        // is player out of bounds? enable flag and begin timer
        if (transform.position.z >= 9 || transform.position.z < -0.5 || transform.position.x >= 14.5 || transform.position.x <= 5.7)
        {
            flag_isOutofBounds = true;
        }
    }

    public void respawnPlayer()
    {
        //repsawn player to a proper location
        transform.position = new Vector3(respawn_x, respawn_y, respawn_z);
        Debug.Log("Out of bounds detected! Respawning player properly...");
    }
}
