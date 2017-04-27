using UnityEngine;
using System.Collections;

public class CustomizeWallR : CustomizeWallAbs{

    protected override void Init()
    {
        activeWall = false;
        returnWall = false;
        maxMove = 4;
        defaultMove = transform.position.x;
    }

    protected override void Move()
    {
        if (activeWall && transform.position.x >= maxMove)
        {
            transform.position += new Vector3(-0.5f, 0,0);
        }
        else if(!activeWall && transform.position.x <= defaultMove)
        {
            transform.position += new Vector3(0.3f, 0, 0);
        }
    }
    
    /// <summary>
    ///  両壁の有効化、無効化
    /// </summary>
    /// <param name="active">bool</param>
    public override void SetActiveWall(bool active)
    {
        activeWall = active;
    }
}
