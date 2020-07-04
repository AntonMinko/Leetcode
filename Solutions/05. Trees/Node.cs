namespace Solutions
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }
        public int Value { get; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}