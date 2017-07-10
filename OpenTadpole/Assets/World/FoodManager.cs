using UnityEngine;
using System.Collections;

public class FoodManager : MonoBehaviour {

    public HeadTadpole head;
    public GameObject manager;

    private int counter = 1;
    private int con = 0;

    void FixedUpdate() 
    {
        con++;
        if (con > 3) 
        {
            con = 1;
            Smell();
        }
    }

    void Smell() 
    {
        Vector2 L1 = head.GetComponent<HeadTadpole>().pointL1.transform.position;
        Vector2 L2 = head.GetComponent<HeadTadpole>().pointL2.transform.position;
        Vector2 FL = head.GetComponent<HeadTadpole>().LF.transform.position;
        Vector2 FR = head.GetComponent<HeadTadpole>().RF.transform.position;
        Vector2 FoodPoint = transform.position;

        if (!areCrossing(L1, L2, FL, FoodPoint)) 
        {
            float distanceL = Vector2.SqrMagnitude(FoodPoint - FL);
            if (distanceL < 300000) 
            {
                if (Mathf.RoundToInt(distanceL / 3000) == 0) manager.GetComponent<IndicatorFlair>().LeftUp();
                else
                if (counter % Mathf.RoundToInt(distanceL / 3000) == 0) 
                {
                    manager.GetComponent<IndicatorFlair>().LeftUp();
                }
            } 
        }

        if (!areCrossing(L1, L2, FR, FoodPoint)) 
        {
            float distanceR = Vector2.SqrMagnitude(FoodPoint - FR);
            if (distanceR < 300000)
            {
                if (Mathf.RoundToInt(distanceR / 3000) == 0) manager.GetComponent<IndicatorFlair>().RightUp();
                else
                if (counter % Mathf.RoundToInt(distanceR / 3000) == 0)
                {
                    manager.GetComponent<IndicatorFlair>().RightUp();
                }
            }
        }

        counter++;
        if (counter > 10000000) counter = 1;
    }

    private float vector_mult(float ax, float ay, float bx, float by) //векторное произведение
    {
        return ax * by - bx * ay;
    }

    public bool areCrossing(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)//проверка пересечения
    {
        float v1 = vector_mult(p4.x - p3.x, p4.y - p3.y, p1.x - p3.x, p1.y - p3.y);
        float v2 = vector_mult(p4.x - p3.x, p4.y - p3.y, p2.x - p3.x, p2.y - p3.y);
        float v3 = vector_mult(p2.x - p1.x, p2.y - p1.y, p3.x - p1.x, p3.y - p1.y);
        float v4 = vector_mult(p2.x - p1.x, p2.y - p1.y, p4.x - p1.x, p4.y - p1.y);
        if ((v1 * v2) < 0 && (v3 * v4) < 0)
            return true;
        return false;
    }
}
