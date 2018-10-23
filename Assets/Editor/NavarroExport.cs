using UnityEngine;
using System.Collections;
using UnityEditor;

public static class NavarroExport
{

    [MenuItem("Tools/Tayassu/Export project package with tags and physics layers")]

    public static void ExportPackage()
    {
        string[] projectContent = AssetDatabase.GetAllAssetPaths();
        string fileName = "Sokoban";
        string fileNameDate = System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute;
        AssetDatabase.ExportPackage(projectContent, fileName + "-" + fileNameDate + ".unitypackage", ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets);
        Debug.Log("Project Exported");
    }

}
