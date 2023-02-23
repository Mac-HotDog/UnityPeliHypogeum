using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopLeave : MonoBehaviour
{
    public void LeaveShop()
    {
        GameManager.instance.LevelChangLogic();
    }
}
