namespace MessageAppDemo.Backend.SystemData.FakeDataCreator
{
    public interface IFaker<Item>
    {
        Item CreateFakeData();
    }
}
