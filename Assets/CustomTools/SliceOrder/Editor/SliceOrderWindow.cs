using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SliceOrderWindow : EditorWindow
{
    private PuzzleDataSO puzzleDataSO;

    public static void Open(PuzzleDataSO puzzleDataSO)
    {
        SliceOrderWindow window = GetWindow<SliceOrderWindow>("Order Sprites Editor");
        window.puzzleDataSO = puzzleDataSO;
    }
    private void OnGUI()
    {
        GUILayout.Label("Reorder Sprites");
        if(GUILayout.Button("Reorder"))
        {
            ChangeOrder();
        }
    }
    public void ChangeOrder()
    {

        if (puzzleDataSO.puzzleSprites.Count == 9 && puzzleDataSO.spritesReordered == false)
        {
            SwapSprites(6, 0);
            SwapSprites(6, 2);
            SwapSprites(6, 8);
            SwapSprites(1, 5);
            SwapSprites(1, 7);
            SwapSprites(1, 3);
            puzzleDataSO.spritesReordered = true;
            puzzleDataSO.SetMatriceType(3);


        }
        else if (puzzleDataSO.puzzleSprites.Count == 16 && puzzleDataSO.spritesReordered == false)
        {
            SwapSprites(12, 0);
            SwapSprites(12, 3);
            SwapSprites(12, 15);
            SwapSprites(8, 1);
            SwapSprites(8, 7);
            SwapSprites(8, 14);
            SwapSprites(4, 2);
            SwapSprites(4, 11);
            SwapSprites(4, 13);
            SwapSprites(9, 5);
            SwapSprites(9, 6);
            SwapSprites(9, 10);
            puzzleDataSO.spritesReordered = true;
            puzzleDataSO.SetMatriceType(4);
        }
        else if (puzzleDataSO.puzzleSprites.Count == 25 && puzzleDataSO.spritesReordered == false)
        {
            SwapSprites(20, 0);
            SwapSprites(20, 4);
            SwapSprites(20, 24);
            SwapSprites(15, 1);
            SwapSprites(15, 9);
            SwapSprites(15, 23);
            SwapSprites(10, 2);
            SwapSprites(10, 14);
            SwapSprites(10, 22);
            SwapSprites(5, 3);
            SwapSprites(5, 19);
            SwapSprites(5, 21);
            SwapSprites(16, 6);
            SwapSprites(16, 8);
            SwapSprites(16, 18);
            SwapSprites(11, 7);
            SwapSprites(11, 13);
            SwapSprites(11, 17);
            puzzleDataSO.spritesReordered = true;
            puzzleDataSO.SetMatriceType(5);

        }
        else if (puzzleDataSO.puzzleSprites.Count == 36 && puzzleDataSO.spritesReordered == false)
        {
            SwapSprites(30, 0);
            SwapSprites(30, 5);
            SwapSprites(30, 35);
            SwapSprites(24, 1);
            SwapSprites(24, 11);
            SwapSprites(24, 34);
            SwapSprites(18, 2);
            SwapSprites(18, 17);
            SwapSprites(18, 33);
            SwapSprites(12, 3);
            SwapSprites(12, 23);
            SwapSprites(12, 32);
            SwapSprites(6, 4);
            SwapSprites(6, 29);
            SwapSprites(6, 31);
            SwapSprites(25, 7);
            SwapSprites(25, 10);
            SwapSprites(25, 28);
            SwapSprites(19, 8);
            SwapSprites(19, 16);
            SwapSprites(19, 27);
            SwapSprites(13, 9);
            SwapSprites(13, 22);
            SwapSprites(13, 26);
            SwapSprites(20, 14);
            SwapSprites(20, 15);
            SwapSprites(20, 21);
            puzzleDataSO.spritesReordered = true;
            puzzleDataSO.SetMatriceType(6);
        }
        else if (puzzleDataSO.puzzleSprites.Count == 49 && puzzleDataSO.spritesReordered == false)
        {
            SwapSprites(42, 0);
            SwapSprites(42, 6);
            SwapSprites(42, 48);
            SwapSprites(35, 1);
            SwapSprites(35, 13);
            SwapSprites(35, 47);
            SwapSprites(28, 2);
            SwapSprites(28, 20);
            SwapSprites(28, 46);
            SwapSprites(21, 3);
            SwapSprites(21, 27);
            SwapSprites(21, 45);
            SwapSprites(14, 4);
            SwapSprites(14, 34);
            SwapSprites(14, 44);
            SwapSprites(7, 5);
            SwapSprites(7, 41);
            SwapSprites(7, 43);
            SwapSprites(36, 8);
            SwapSprites(36, 12);
            SwapSprites(36, 40);
            SwapSprites(29, 9);
            SwapSprites(29, 19);
            SwapSprites(29, 39);
            SwapSprites(22, 10);
            SwapSprites(22, 26);
            SwapSprites(22, 38);
            SwapSprites(15, 11);
            SwapSprites(15, 33);
            SwapSprites(15, 37);
            SwapSprites(30, 16);
            SwapSprites(30, 18);
            SwapSprites(30, 32);
            SwapSprites(23, 17);
            SwapSprites(23, 25);
            SwapSprites(23, 31);
            puzzleDataSO.spritesReordered = true;
            puzzleDataSO.SetMatriceType(7);
        }
        else
        {
            Debug.LogWarning("Rules:Only 9, 16, 25, 36, 49 members are alowed and sprite reordered must be false!");
        }
    }

    private void SwapSprites(int source, int target)
    {
        Sprite temporaryMember = puzzleDataSO.puzzleSprites[target];
        puzzleDataSO.puzzleSprites[target] = puzzleDataSO.puzzleSprites[source];
        puzzleDataSO.puzzleSprites[source] = temporaryMember;
    }
   
}
