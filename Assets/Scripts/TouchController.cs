using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    Transform touchItem;
    //
    [SerializeField] LayerMask touchItemsMask;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && !Utility.IsPointerOverUIObject())
        {
            // mouse down event
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 0f, touchItemsMask);
            if (hit.collider != null && hit.transform.CompareTag(GameConstants.TAG_PIN_ELEVATION_BOLT))
            {
                touchItem = hit.transform;
                touchItem.GetComponent<PinElevationBolt>().EnableValuePointer();
            }
            else if (hit.collider != null && hit.transform.CompareTag(GameConstants.TAG_CUP_ELEVATION_PIN))
            {
                touchItem = hit.transform;
                touchItem.GetComponent<CupElevationPin>().EnableValuePointer();
            }
            else if (hit.collider != null && hit.transform.CompareTag(GameConstants.TAG_BAR_ELEVATION_PIN))
            {
                touchItem = hit.transform;
                touchItem.GetComponent<BarElevationPin>().EnableValuePointer();
            }
            else if (hit.collider != null && hit.transform.CompareTag(GameConstants.TAG_RELEASE_ANGLE_BAR))
            {
                touchItem = hit.transform;
                touchItem.GetComponent<ReleaseAngleBar>().EnableValuePointer();
            }
            else if (hit.collider != null && hit.transform.CompareTag(GameConstants.TAG_LOCK_PIN))
            {
                touchItem = hit.transform;
                touchItem.GetComponent<LockPin>().OnTouchDownLockPin();
            }
        }
        else if (Input.GetMouseButton(0) && !Utility.IsPointerOverUIObject())
        {
            // mouse hold event
            if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_PIN_ELEVATION_BOLT))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                touchItem.GetComponent<PinElevationBolt>().MoveElevationBolt(mousePos2D);
            }
            else if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_CUP_ELEVATION_PIN))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                touchItem.GetComponent<CupElevationPin>().MoveElevationPin(mousePos2D);
            }
            else if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_BAR_ELEVATION_PIN))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                touchItem.GetComponent<BarElevationPin>().MoveElevationPin(mousePos2D);
            }
            else if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_RELEASE_ANGLE_BAR))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                //RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 0f, touchItemsMask);
                //if (hit.collider != null && hit.transform.CompareTag(GameConstants.TAG_RELEASE_ANGLE_BAR))
                //{
                    touchItem.GetComponent<ReleaseAngleBar>().RotateFollowPoint(mousePos2D);
                //}

            }
            else if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_LOCK_PIN))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                //RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 0f, touchItemsMask);
                //if (hit.collider != null && hit.transform.CompareTag(GameConstants.TAG_LOCK_PIN))
                //{
                    touchItem.GetComponent<LockPin>().OnTouchDragLockPin(mousePos2D);
                //}

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // mouse up event
            if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_PIN_ELEVATION_BOLT))
            {
                touchItem.GetComponent<PinElevationBolt>().DisableValuePointer();
            }
            else if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_CUP_ELEVATION_PIN))
            {
                touchItem.GetComponent<CupElevationPin>().DisableValuePointer();
            }
            else if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_BAR_ELEVATION_PIN))
            {
                touchItem.GetComponent<BarElevationPin>().DisableValuePointer();
            }
            else if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_RELEASE_ANGLE_BAR))
            {
                touchItem.GetComponent<ReleaseAngleBar>().DisableValuePointer();
            }
            else if (touchItem != null && touchItem.CompareTag(GameConstants.TAG_LOCK_PIN))
            {
                touchItem.GetComponent<LockPin>().OnTouchUpLockPin();
            }

            touchItem = null;
        }

    }

}
