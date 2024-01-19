using UnityEngine;

public class FootIK : MonoBehaviour
{
    public Transform leftFootTransform;
    public Transform RightFootTransform;
    public LayerMask layerMask;

    private Vector3 rightFootLocation;
    private Vector3 leftFootLocation;

    public Animator animator;
    public float threshold;
    public float strength;
    public float footSmoothing = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnAnimatorIK(int layerIndex)
    {
        AdjustFoot(true);
        AdjustFoot(false);
    }

    private void AdjustFoot(bool isRight = true)
    {
        Ray footRay = new Ray();
        footRay.direction = -(isRight ? RightFootTransform.up : leftFootTransform.up);
        footRay.origin = isRight ? RightFootTransform.position : leftFootTransform.position;

        Debug.DrawRay(footRay.origin, footRay.direction * 5f, Color.blue);

        if (Physics.Raycast(footRay, out RaycastHit hitInfo, 5f, layerMask))
        {
            if (Vector3.Distance(isRight ? rightFootLocation : leftFootLocation, hitInfo.point) > threshold)
            {
                if (isRight)
                {
                    rightFootLocation = hitInfo.point;
                }
                else
                {
                    leftFootLocation = hitInfo.point;
                }
            }
        }

        bool shouldUseIK = GetComponent<Movements>().playerMove_.magnitude > 0;

        animator.SetIKPositionWeight(isRight ? AvatarIKGoal.RightFoot : AvatarIKGoal.LeftFoot, shouldUseIK ? 0 : strength);
        Vector3 current = animator.GetIKPosition(isRight ? AvatarIKGoal.RightFoot : AvatarIKGoal.LeftFoot);
        Vector3 target = isRight ? rightFootLocation : leftFootLocation;
        animator.SetIKPosition(isRight ? AvatarIKGoal.RightFoot : AvatarIKGoal.LeftFoot, Vector3.Lerp(current, target, Time.deltaTime * footSmoothing));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
