using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New building", menuName = "PlaceObject")]
public class PlacedObjectTypeSO : ScriptableObject
{
    public static Dir GetNextDir(Dir dir)
    {
        switch (dir)
        {default:
            case Dir.Down: return Dir.Left;
            case Dir.Left: return Dir.Up;
            case Dir.Up: return Dir.Right;
            case Dir.Right: return Dir.Down;
            
        }
    }
    
    //offset the position of placeObeject cause we rotate it around it pivet
    public Vector2Int GetRotationOffset(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return new Vector2Int(0, 0);
            case Dir.Left: return new Vector2Int(0, width);
            case Dir.Up: return new Vector2Int(width, height);
            case Dir.Right: return new Vector2Int(height, 0);
        }    
    }
    
    public enum  Dir
    {
        Down,
        Left,
        Up,
        Right,

    }
    public string nameString;
    public Turret prefab;
    public Transform visual;
    public int price = 10;
    public Sprite icon;
    public int Damage = 10;
    
    [Header("Size")]
    public int width;
    public int height;

    public int GetRotationAngle(Dir dir)
    {
        switch (dir)
        {
            default:
                case  Dir.Down: return 0;
                case  Dir.Left: return 90;
                case  Dir.Up: return 180;
                case  Dir.Right: return 270;
        }
    }
    
    public List<Vector2Int> GetGridPositionList(Vector2Int offset, Dir dir)
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>();
        switch (dir)
        { 
            default:
                case Dir.Down:
                case Dir.Up:
                    for (int x = 0; x < width; x++)
                    {
                        for (int z = 0; z < height; z++)
                        {
                            gridPositionList.Add(offset + new Vector2Int(x, z));
                        }
                    }
                    break;
                case Dir.Left:
                case Dir.Right:
                    for (int x = 0; x < height; x++)
                    {
                        for (int z = 0; z < width; z++)
                        {
                            gridPositionList.Add(offset + new Vector2Int(x, z));
                        }
                    }
                    break;
        }
        return gridPositionList;

    }
}
