using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] position;
    public int level;

    public PlayerData(Player player) {
        level = Player.level;
        health = Player.health;

        position = new float[3];

        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
