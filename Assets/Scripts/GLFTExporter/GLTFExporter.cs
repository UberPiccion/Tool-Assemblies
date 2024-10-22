using UnityEngine;
using GLTFast.Export;
using System.IO;
using GLTFast.Logging;
using GLTFast;
using UnityEngine.UI;

public class GLTFExporter : MonoBehaviour
{
    [SerializeField]
    GameObject[] objectsToExport;
    [SerializeField]
    string path;
    [SerializeField]
    Text text;

    public void ExportGLFT()
    {
        AdvancedExport();
    }

        

        async void AdvancedExport()
        {
        text.text = "Assembling!";
        var exportSettings = new ExportSettings
            {
                Format = GltfFormat.Binary,
                FileConflictResolution = FileConflictResolution.Overwrite,
                // Export everything except cameras or animation
                ComponentMask = ~(ComponentType.Camera | ComponentType.Animation),
                // Boost light intensities 
                LightIntensityFactor = 100f,
            };
            var gameObjectExportSettings = new GameObjectExportSettings
            {
                // Include inactive GameObjects in export
                OnlyActiveInHierarchy = false,
                // Also export disabled components
                DisabledComponents = true,
                // Only export GameObjects on certain layers
                LayerMask = LayerMask.GetMask("Default", "MyCustomLayer"),
            };

            
            var export = new GameObjectExport(exportSettings, gameObjectExportSettings);


        
        export.AddScene(objectsToExport, "My new glTF scene");
            string destinationPath = Path.Combine(Application.dataPath, path);
            var success = await export.SaveToFileAndDispose(destinationPath);

            if (!success)
            {

            text.text = "Something Went Wrong!";
            } else
            { text.text = "Assembled"; }
        }
    }
