using UnityEngine;

public class IKTest : MonoBehaviour
{
    public Animator animator;
    public Transform lookObj;
    public Transform objectToHold;

    public Transform playerRightHand;

    float positionweight = 0f;
    float rotationweight = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK()
    {
        if (animator)
        {
            animator.SetIKPosition(AvatarIKGoal.RightHand, objectToHold.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, objectToHold.rotation);

            if (objectToHold != null)
            {
                if (Input.GetKey(KeyCode.Q)) //
                {
                    //playerRightHand.transform.Rotate(new Vector3(-90, 0, 0));

                    positionweight += Time.deltaTime;
                    positionweight = Mathf.Clamp(positionweight, 0f, 1f);
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, positionweight);

                    rotationweight += Time.deltaTime;
                    rotationweight = Mathf.Clamp(rotationweight, 0f, 1f);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rotationweight);

                }
                else
                {
                    //playerRightHand.transform.Rotate(new Vector3(0, 0, 0));

                    rotationweight -= Time.deltaTime;
                    rotationweight = Mathf.Clamp(rotationweight, 0f, 1f);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rotationweight);

                    positionweight -= Time.deltaTime;
                    positionweight = Mathf.Clamp(positionweight, 0f, 1f);
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, positionweight);
                }
            }
        }
    }

}
#region commented
/*if (lookObj != null)
                {
                    animator.SetLookAtWeight(positionweight);
                    animator.SetLookAtPosition(lookObj.position);
                }*/
//animator.SetLookAtWeight(positionweight);
#endregion