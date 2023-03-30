using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TexturePrepare : EditorWindow
{
    private Texture2D texture;
    private TextureType textureType;
    private enum TextureType { Type3 = 3,Type4 = 4,Type5 = 5,Type6 = 6,Type7 = 7}

    [MenuItem("Tools/TexturePrepare")]
    private static void TexturePrepareWindow()
    {
        TexturePrepare puzzleSlicerWIndow = GetWindow<TexturePrepare>(typeof(TexturePrepare));
        puzzleSlicerWIndow.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Assign Texture",EditorStyles.boldLabel);
        GUILayout.Label("Texture type", EditorStyles.boldLabel);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        texture = EditorGUILayout.ObjectField(texture, typeof(Texture2D), false) as Texture2D;
        textureType = (TextureType)EditorGUILayout.EnumPopup(textureType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Set Texture"))
        {
            if (texture != null)
            {
                SetTexture();
            }
            else { Debug.LogWarning("Texture Missing"); }
        }
       
    }

    private void SetTexture()
    {
        string assetPath = AssetDatabase.GetAssetPath(texture);
        TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
        if (textureType != 0)
        {
            importer.spriteImportMode = SpriteImportMode.Multiple;
            importer.spritePixelsPerUnit = texture.width / (int)textureType;
         
        }
        else
        {
            Debug.LogWarning("Texture type has not been set!");
        }
    }




   

}
