namespace MessageAppDemo2.Backend.SystemData.FakeDataCreator
{
    public interface IFaker<Item>
    {
        Item CreateFakeData();
    }
}
