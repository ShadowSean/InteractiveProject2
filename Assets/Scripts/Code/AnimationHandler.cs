using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class AnimationHandler : MonoBehaviour
{
    public GameObject MainBody;
    public GameObject AlembicBody;
    private AlembicStreamPlayer alembic;
    private GameObject parentobject;
    public float speed = 1f; 
    public bool playAnimation = false;
    public float timeEnd;

    private void Start()
    {
        alembic = AlembicBody.GetComponent<AlembicStreamPlayer>();
        MainBody.SetActive(true);
        AlembicBody.SetActive(false);
        parentobject = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playAnimation)
        {
            playAnimation = true;
            MainBody.SetActive(false);
            AlembicBody.SetActive(true);
            alembic.CurrentTime = 0f;
            //PlayerMovement  = other.transform.parent.GetComponent<PlayerMovement>();
          
        }
    }

    void Update()
    {
        if (playAnimation)
        {          
            alembic.CurrentTime += Time.deltaTime * speed;

            if (alembic.CurrentTime >= timeEnd)
            {
                Destroy(parentobject);
            }
        }
    }
}
