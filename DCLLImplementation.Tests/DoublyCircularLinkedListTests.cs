using DSA;

namespace DCLLImplementation.Tests;

public class DoublyCircularLinkedListTests
{
    [Fact]
    public void NewList_ShouldHaveZeroCount()
    {
        var list = new DoublyCircularLinkedList<int>();

        Assert.Equal(0, list.Count);
        Assert.Null(list.Head);
        Assert.Null(list.Tail);
    }

    [Fact]
    public void AppendList_ShouldAddElements()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(10);
        list.AppendList(20);
        list.AppendList(30);

        Assert.Equal(3, list.Count);
        Assert.Equal(new[] { 10, 20, 30 }, list.ToArray());
    }

    [Fact]
    public void PrependList_ShouldAddElementAtBeginning()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(20);
        list.AppendList(30);
        list.PrependList(10);

        Assert.Equal(new[] { 10, 20, 30 }, list.ToArray());
    }

    [Fact]
    public void InsertInList_ShouldInsertInMiddle()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(10);
        list.AppendList(30);

        list.InsertInList(20, 2);

        Assert.Equal(new[] { 10, 20, 30 }, list.ToArray());
    }

    [Fact]
    public void DeleteFromFront_ShouldRemoveFirstElement()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(10);
        list.AppendList(20);
        list.AppendList(30);

        list.DeleteFromFront();

        Assert.Equal(new[] { 20, 30 }, list.ToArray());
    }

    [Fact]
    public void DeleteFromRear_ShouldRemoveLastElement()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(10);
        list.AppendList(20);
        list.AppendList(30);

        list.DeleteFromRear();

        Assert.Equal(new[] { 10, 20 }, list.ToArray());
    }

    [Fact]
    public void UpdateNode_ShouldUpdateCorrectPosition()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(10);
        list.AppendList(20);
        list.AppendList(30);

        Assert.True(list.UpdateNode(200, 2));
        Assert.Equal(new[] { 10, 200, 30 }, list.ToArray());
    }

    [Fact]
    public void UpdateNode_InvalidPosition_ShouldReturnFalse()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(10);
        list.AppendList(20);

        Assert.False(list.UpdateNode(100, 0));
        Assert.False(list.UpdateNode(100, -1));
        Assert.False(list.UpdateNode(100, 3));
    }

    [Fact]
    public void RotateForward_ShouldMoveHeadForward()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(10);
        list.AppendList(20);
        list.AppendList(30);
        list.AppendList(40);

        list.RotateForward(1);

        Assert.Equal(new[] { 20, 30, 40, 10 }, list.ToArray());
    }

    [Fact]
    public void RotateBackward_ShouldMoveHeadBackward()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(10);
        list.AppendList(20);
        list.AppendList(30);
        list.AppendList(40);

        list.RotateBackward(1);

        Assert.Equal(new[] { 40, 10, 20, 30 }, list.ToArray());
    }

    [Fact]
    public void SingleNode_ShouldPointToItself()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(10);

        Assert.Same(list.Head, list.Tail);
        Assert.Same(list.Head, list.Head!.Next);
        Assert.Same(list.Head, list.Head!.Prev);
    }

    [Fact]
    public void List_ShouldMaintainCircularLinks()
    {
        var list = new DoublyCircularLinkedList<int>();

        list.AppendList(10);
        list.AppendList(20);
        list.AppendList(30);

        Assert.Same(list.Head, list.Tail!.Next);
        Assert.Same(list.Tail, list.Head!.Prev);
    }
}