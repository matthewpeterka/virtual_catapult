using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotateController : MonoBehaviour
{

    float rotateSpeed = 10f;
    Vector2 touchStartPos;
    Transform touchItem;
    //
    [SerializeField] LayerMask touchItemsMask;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 0f, touchItemsMask);

            if (hit.collider != null && hit.transform.CompareTag(GameConstants.TAG_RELEASE_ANGLE_BAR))
            {
                touchItem = hit.transform;
                touchStartPos = mousePos2D;
            }
        }
        else if (Input.GetMouseButton(0))
        {

            if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_RELEASE_ANGLE_BAR))
            {

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                //RotateReleaseAngleBar(touchStartPos, mousePos2D);
                RotateFollowPoint(mousePos2D);

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchItem = null;
        }
    }


    // rotate pivot parent
    //public void RotateReleaseAngleBar(Vector2 touchStartPosition, Vector2 touchPosition)
    //{
    //    if (touchStartPosition.x > touchPosition.x)
    //    {
    //        transform.parent.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    //    }
    //    else if (touchStartPosition.x < touchPosition.x)
    //    {
    //        transform.parent.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);
    //    }
    //}

    //sets the angle of the bar to point in the direction of targetPoint2D
    void RotateFollowPoint(Vector2 targetPoint2D)
    {

        Vector2 position2D = new Vector2(transform.parent.position.x, transform.parent.position.y);
        float angle = Vector2.Angle(Vector2.right, targetPoint2D - position2D);

        if (targetPoint2D.y < position2D.y)
            angle *= -1;

        transform.parent.eulerAngles = new Vector3(0, 0, angle - 90f);
    }


}