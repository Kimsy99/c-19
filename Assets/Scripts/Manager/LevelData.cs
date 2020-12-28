using System;

[Serializable]
public class LevelData
{
	public float health;
	public float infection;
	public Weapon[] weapons = new Weapon[5];
}
