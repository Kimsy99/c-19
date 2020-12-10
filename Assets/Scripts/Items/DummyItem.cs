public class DummyItem : Item
{
	public override void Use()
	{
		Count--;
		print(Count + " left");
	}
}
