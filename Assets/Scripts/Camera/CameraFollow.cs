using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject FollowGameObject;

    // Start is called before the first frame update
    void Start()
    {
        if(FollowGameObject == null) 
        {
            Debug.LogWarning("No follow object was defined, camera will not follow anything");
        }    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowObject();
    }

    private void FollowObject() 
    {

        if(FollowGameObject == null) {
            return;
        }

        Vector3 currOjectPosition = this.FollowGameObject.transform.position;

        Vector3 newCameraPos = new Vector3(currOjectPosition.x,currOjectPosition.y,this.transform.position.z);
        this.transform.position = newCameraPos;
    }
}
