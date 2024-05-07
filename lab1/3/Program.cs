using System;

namespace zadanie_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree root = new Tree(1);
            Tree child1 = new Tree(2);
            Tree child2 = new Tree(3);
            Tree grandchild11 = new Tree(4);
            Tree grandchild21 = new Tree(5);
            Tree grandchild12 = new Tree(6);
            Tree doubleGrandchild = new Tree(7);

            root.addChild(child1);
            root.addChild(child2);

            child1.addChild(grandchild11);
            child1.addChild(grandchild21);

            child2.addChild(grandchild12);

            grandchild21.addChild(doubleGrandchild);

            root.ShowFamily();
        }
    }
}