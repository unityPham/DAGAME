# DAGAME

using UnityEngine;
using PathCreation;

public class PathCreatorPluss : MonoBehaviour
{
    public GameObject pathCreatorObject, roadObject, getTransformGrandObj, getTransformParentObj,getTransformChildObj;
    public PathCreator pathCreator;

    public void FixPathScale()
    {
        getTransformParentObj.transform.localScale = new Vector3(
            1 / pathCreatorObject.transform.localScale.x, 
            1 / pathCreatorObject.transform.localScale.y,
            1 / pathCreatorObject.transform.localScale.z         );
    }
    public Vector3 OnPathCreatorPosition(Vector3 onPathCreatorPosition)
    {
        getTransformGrandObj.transform.position = pathCreator.path.GetPointAtDistance(onPathCreatorPosition.z);
        getTransformGrandObj.transform.rotation = pathCreator.path.GetRotationAtDistance(onPathCreatorPosition.z);
        getTransformChildObj.transform.localPosition = new Vector3(onPathCreatorPosition.x, onPathCreatorPosition.y, 0);
        return getTransformChildObj.transform.position;
    }

    public Quaternion OnPathCreatorRotation(Vector3 onPathCreatorPosition)
    {
        getTransformGrandObj.transform.position = pathCreator.path.GetPointAtDistance(onPathCreatorPosition.z);
        getTransformGrandObj.transform.rotation = pathCreator.path.GetRotationAtDistance(onPathCreatorPosition.z);
        getTransformChildObj.transform.localRotation = new Quaternion(0,0,0,0);
        return getTransformChildObj.transform.rotation;
    }
}
