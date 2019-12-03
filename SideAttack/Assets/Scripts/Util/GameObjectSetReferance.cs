using System;

[Serializable]
public class GameObjectSetReferance
{
    public bool useConstant = true;
    public GameObjectSet constantValue = new GameObjectSet();

    public GameObjectSetReferance() { }

    public GameObjectSetReferance(GameObjectSet value)
    {
        useConstant = true;
        constantValue = value;
    }

}