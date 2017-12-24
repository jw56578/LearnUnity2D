using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this class represents whatever asset object you added this script file to as a component
// i have no idea how this assocication is made in code or at runtime
// all public fields will be observable from the unity IDE editor
//this is no different then creating windows forms in the designer mode and assinging properties from the properies dialog box

public class PaddleScript : MonoBehaviour {

    //https://docs.unity3d.com/ScriptReference/Rigidbody2D.html
    //a rigidbody is the concept of saying that an asset is now something that can be controlled by the physics engine
    //simple asset objects can't move so they don't have the velocity property, so you have to assign the rigidbody object to work with velocity
   
    //making this public field means that the script needs this thing to be assigned to it from the editor designer interface
    public Rigidbody2D rb;

    //another piece of info that needs to come from the unity designer ide
    public float speed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //all the inputs are configured through unity project settings -> input
        //by default there is an input called horizontal where it sets up what buttons make a range of values from -1 to 1
        //you can set this up to be anything you want but by default it says that pushing the left arrow key will create a value of -1
        // and pressing the right arrow key will create a value of 1
        // when there is no input from any of them, the value is 0
        //it is up to you to decide what to do when its either 0, between 0 and 1, or between 0 and -1
        
        float x = Input.GetAxis("Horizontal");

        if (x < 0)
        {
            MoveLeft();
        }
        else if (x > 0)
        {
            MoveRight();
        }
        else
            Stop();

        //somehow the asset gets associated to the script file when you make the script file a component of it
        // i have no idea how
        //this seems very screwy that this class represents the actual asset object but you still have to assign the rigid object
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -1.87f, 1.87f);
        transform.position = pos;

    }

    void MoveLeft() {
        //you are telling the object to start moving in this direction at some speed
        //the engine handles knowing where to move it to based on frame rate and desired speed
        // a vector is just a coordinate in this case x,y
        //negative means move left if its the x axis
        rb.velocity = new Vector2(-speed, 0);
       
    }
    void MoveRight()
    {
        //positive means move right on the x axis
        rb.velocity = new Vector2(speed, 0);
    }
    void Stop()
    {
        //if you assign a velocity then the object will just keep moving forever
        //you have to stop it if that is what should be done
        rb.velocity = Vector2.zero;
    }
}
