/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
 using UnityEngine;

/// <summary>
/// allows the movement of camera 
/// </summary>
public class CameraController : MonoBehaviour
{
    // allow/forbid the camera movement
    private bool doMovement = false;

    /// <summary>
    /// panSpeed            - the speed of camera movement
    /// panBorderThickness  - how far from the edge of screen is enough to move camera
    /// scrollSpeed         - speed of scrolling the camera
    /// min/maxY            - min/max camera height
    /// </summary>
    [Header("Camera Directional Movement Attributes")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    [Header("Camera Scroll Movement Attributes")]
    public float scrollSpeed = 5f;
    public float minY = 80f;
    public float maxY = 180f;

    /// <summary>
    /// handles the movement itself
    /// </summary>
    void Update()
    {

        if (GameMaster.gameEnded)
        {
            enabled = false;
        }
        // allow/forbid the camera movement on hotkey
        if (Input.GetKeyDown(KeyCode.M))
            doMovement = !doMovement;
        // stops there if doMovement is set to false
        if (!doMovement)
            return;

        // moving in directions iva wasd or mouse
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        // zooming in/out
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // position of camera itself
        Vector3 cameraPos = transform.position;

        // scroll speed and limits of camera height
        cameraPos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        cameraPos.y = Mathf.Clamp(cameraPos.y, minY, maxY);

        // actual movement of camera
        transform.position = cameraPos;
    }
}
