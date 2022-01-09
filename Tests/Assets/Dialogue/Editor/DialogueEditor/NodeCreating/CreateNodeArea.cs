using System;
using UnityEngine;

public class CreateNodeArea
{
    public readonly CreateNodeAreaDrawer Drawer;
    private readonly CreateNodeAreaDrawModel _drawModel;

    public CreateNodeArea()
    {
        _drawModel = new CreateNodeAreaDrawModel();
        Drawer = new CreateNodeAreaDrawer(_drawModel);
    }

}

public enum CreateType
{
    None,
    Speech,
}