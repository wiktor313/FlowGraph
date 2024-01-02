using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class NewBehaviourScript : MonoBehaviour
{
    private RenderTexture renderTexture;
    private Camera renderCamera;
    private Vector4 bounds;

    private int resolution = 160;
    private float cameraDistance = -2.0f;

    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.P) && !EventSystem.current.currentSelectedGameObject)
        {
            DoScreen();
        }
    }
    void DoScreen()
    {
        gameObject.AddComponent(typeof(Camera));
        renderCamera = GetComponent<Camera>();
        renderCamera.enabled = true;
        renderCamera.cameraType = CameraType.Game;
        renderCamera.forceIntoRenderTexture = true;
        renderCamera.orthographic = true;
        renderCamera.orthographicSize = 5;
        renderCamera.aspect = 1.0f;
        renderCamera.targetDisplay = 2;

        renderTexture = new RenderTexture(resolution, resolution, 24);

        renderCamera.targetTexture = renderTexture;

        bounds = new Vector4();

        {
            object[] gameObjects = FindObjectsOfType(typeof(GameObject));

            foreach (object gameObj in gameObjects)
            {
                GameObject levelElement = (GameObject)gameObj;
                Bounds boundaries = new Bounds();

                if (levelElement.GetComponentInChildren<Renderer>() != null)
                {
                    boundaries = levelElement.GetComponentInChildren<Renderer>().bounds;
                }
                else if (levelElement.GetComponentInChildren<Collider2D>() != null)
                {
                    boundaries = levelElement.GetComponentInChildren<Collider2D>().bounds;
                }
                else
                {
                    continue;
                }

                if (boundaries != null)
                {
                    bounds.w = Mathf.Min(bounds.w, boundaries.min.x);
                    bounds.x = Mathf.Max(bounds.x, boundaries.max.x);
                    bounds.y = Mathf.Min(bounds.y, boundaries.min.y);
                    bounds.z = Mathf.Max(bounds.z, boundaries.max.y);
                }
            }
        }

        int xRes = Mathf.RoundToInt(resolution * ((bounds.x - bounds.w) / (renderCamera.aspect * renderCamera.orthographicSize * 2 * renderCamera.aspect)));
        int yRes = Mathf.RoundToInt(resolution * ((bounds.z - bounds.y) / (renderCamera.aspect * renderCamera.orthographicSize * 2 / renderCamera.aspect)));

        Texture2D screenshot = new Texture2D(xRes, yRes, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;

        for (float i = bounds.w, xPos = 0; i < bounds.x; i += renderCamera.aspect * renderCamera.orthographicSize * 2, xPos++)
        {
            for (float j = bounds.y, yPos = 0; j < bounds.z; j += renderCamera.aspect * renderCamera.orthographicSize * 2, yPos++)
            {
                gameObject.transform.position = new Vector3(i + renderCamera.aspect * renderCamera.orthographicSize, j + renderCamera.aspect * renderCamera.orthographicSize, cameraDistance);
                renderCamera.Render();
                screenshot.ReadPixels(new Rect(0, 0, resolution, resolution), (int)xPos * resolution, (int)yPos * resolution);
            }
        }
        RenderTexture.active = null;
        renderCamera.targetTexture = null;
        byte[] diagram = screenshot.EncodeToPNG();
        var path = EditorUtility.SaveFilePanel("Zapisz jako PNG", "", "Diagram.png", "png");
        
        if (path == null)
            return;
        File.WriteAllBytes(path, diagram);
        Destroy(renderCamera);
        Debug.Log("Zapisano obraz");
    }
}
