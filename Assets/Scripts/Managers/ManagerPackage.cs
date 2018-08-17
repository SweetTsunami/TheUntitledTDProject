///*  File:       ManagerPackage
// *  Creator:    Sweet
// *  Date:       
// *  Location:   Brno, Czech Republic
// *  Project:    
// *  Desc:       
// *  Usage:                  
// */
 
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class ManagerPackage : MonoBehaviour 
//{
//    public static ManagerPackage managerPackage;
//    public GameObject inGameUI;
//    public GameObject worldMapUI;
//    public enum MenuMode { WORLDMAP, INGAME, OTHER};
//    public static MenuMode menuMode;

//    void OnEnable()
//    {
//        MakeThisTheOnlyPackage();
//        SetMenuMode();
//        Debug.Log(menuMode);
//        if (menuMode == MenuMode.WORLDMAP)
//        {
//            worldMapUI.SetActive(true);
//        }
//        else if (menuMode == MenuMode.INGAME)
//        {
//            inGameUI.SetActive(true);
//        }
//        else if (menuMode == MenuMode.OTHER)
//        {
//            worldMapUI.SetActive(false);
//            inGameUI.SetActive(false);
//        }
//    }

//    void SetMenuMode()
//    {
//        var sceneIndex = SceneManager.GetActiveScene().buildIndex;

//        if (sceneIndex < 3)
//        {
//            menuMode = MenuMode.OTHER;
//        }
//        else if (sceneIndex == 3)
//        {
//            menuMode = MenuMode.WORLDMAP;
//        }
//        else if (sceneIndex > 3)
//        {
//            menuMode = MenuMode.INGAME;
//        }
//        else
//        {
//            menuMode = MenuMode.OTHER;
//        }
//    }

//    void MakeThisTheOnlyPackage()
//    {
//        if (managerPackage == null)
//        {
//            DontDestroyOnLoad(gameObject);
//            managerPackage = this;
//        }
//        else
//        {
//            if (managerPackage != this)
//            {
//                Destroy(gameObject);
//            }
//        }
//    }
//}
