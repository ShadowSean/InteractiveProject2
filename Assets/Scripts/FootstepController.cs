using UnityEngine;
[RequireComponent (typeof(PlayerMovement))]

public class FootstepController : MonoBehaviour
{
    // holds the step amount
    public float footstepDistance;
    // holds the footstep clip
    public AudioSource footstepClip;
    // holds the distance travelled in total
    public float distanceTravelled;
    //Holds your last position
    public Vector3 lastPos;

    private PlayerMovement mMovement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mMovement = GetComponent<PlayerMovement>();
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // calculation for distance travelled
        float distanceCurrentFrame = Vector3.Distance(transform.position, lastPos);

        if (mMovement.grounded) distanceTravelled += distanceCurrentFrame;

        //only play the footstep audio if enough distance is travelled
        if (distanceTravelled >= footstepDistance &&
            isMoving() &&
            mMovement.grounded
            )
        {
            //plays the audio clip
            footstepClip.PlayOneShot(footstepClip.clip);
            //resets the distance travelled
            distanceTravelled = 0f;
        }

        lastPos = transform.position;
    }

    //calculates if player is moving and returns horizontal velocity
    bool isMoving()
    {
        return (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0);
    }
}
