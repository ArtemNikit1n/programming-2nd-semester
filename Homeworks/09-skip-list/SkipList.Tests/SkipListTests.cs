namespace SkipList.Tests;

#pragma warning disable SA1600
public class SkipListTests
{
    private SkipList<int> listWithNonReferenceType;
    private SkipList<string> listWithReferenceType;

    [SetUp]
    public void InitializeLists()
    {
        this.listWithNonReferenceType = [];
        this.listWithReferenceType = [];
    }

    [Test]
    public void Add_ShouldAddOneItem()
    {
        this.listWithNonReferenceType.Add(1);
    }

    [Test]
    public void Add_ShouldAddOneItem_ReferenceType()
    {
        this.listWithReferenceType.Add("123");
    }

    [Test]
    public void Add_ShouldBeInsertedCorrectlyInMiddleOfList()
    {
        this.listWithNonReferenceType.Add(1);
        this.listWithNonReferenceType.Add(2);
        this.listWithNonReferenceType.Add(3);
        this.listWithNonReferenceType.Add(4);
        this.listWithNonReferenceType.Add(7);
        this.listWithNonReferenceType.Add(10);
        this.listWithNonReferenceType.Add(11);
        this.listWithNonReferenceType.Add(30);
        this.listWithNonReferenceType.Add(5);
    }
}
#pragma warning restore SA1600
