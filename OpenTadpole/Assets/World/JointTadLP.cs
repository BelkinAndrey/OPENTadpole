using UnityEngine;
using System.Collections;

public class JointTadLP : MonoBehaviour {

    public LPJointDistance[] LeftMuscle;
    public LPJointDistance[] RightMuscle;

    public float[] LeftMuscleForce = new float[8];
    public float[] RightMuscleForce = new float[8];

    public float force;
    public float relax;

    private int _reduction;
    public int reduction 
    {
        get { return _reduction; }
        set 
        {
            if (value > 10000000) _reduction = 0;
            else _reduction = value;
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < 8; i++)
        {
            float Ldistance = LPAPIJoint.GetDistanceJointLength(LeftMuscle[i].GetPtr());
            float Rdistance = LPAPIJoint.GetDistanceJointLength(RightMuscle[i].GetPtr());

            float act = Ldistance - LeftMuscleForce[i];
            if (act < 0) act = 0;
            if (act < 10) act += relax;
            LPAPIJoint.SetDistanceJointLength(LeftMuscle[i].GetPtr(), act);
            LeftMuscleForce[i] = 0;

            act = Rdistance - RightMuscleForce[i];
            if (act < 0) act = 0;
            if (act < 10) act += relax;
            LPAPIJoint.SetDistanceJointLength(RightMuscle[i].GetPtr(), act);
            RightMuscleForce[i] = 0;

        }
    }

    #region Events

    public void EventS1L()
    {
        LeftMuscleForce[0] += force;
        reduction++;
    }

    public void EventS1R()
    {
        RightMuscleForce[0] += force;
        reduction++;
    }

    public void EventS2L()
    {
        LeftMuscleForce[1] += force;
        reduction++;
    }

    public void EventS2R()
    {
        RightMuscleForce[1] += force;
        reduction++;
    }

    public void EventS3L()
    {
        LeftMuscleForce[2] += force;
        reduction++;
    }

    public void EventS3R()
    {
        RightMuscleForce[2] += force;
        reduction++;
    }

    public void EventS4L()
    {
        LeftMuscleForce[3] += force;
        reduction++;
    }

    public void EventS4R()
    {
        RightMuscleForce[3] += force;
        reduction++;
    }

    public void EventS5L()
    {
        LeftMuscleForce[4] += force;
        reduction++;
    }

    public void EventS5R()
    {
        RightMuscleForce[4] += force;
        reduction++;
    }

    public void EventS6L()
    {
        LeftMuscleForce[5] += force;
        reduction++;
    }

    public void EventS6R()
    {
        RightMuscleForce[5] += force;
        reduction++;
    }

    public void EventS7L()
    {
        LeftMuscleForce[6] += force;
        reduction++;
    }

    public void EventS7R()
    {
        RightMuscleForce[6] += force;
        reduction++;
    }

    public void EventS8L()
    {
        LeftMuscleForce[7] += force;
        reduction++;
    }

    public void EventS8R()
    {
        RightMuscleForce[7] += force;
        reduction++;
    }

    #endregion
}
