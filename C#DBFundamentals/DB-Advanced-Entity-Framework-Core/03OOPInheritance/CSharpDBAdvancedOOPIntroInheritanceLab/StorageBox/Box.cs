using System;
using System.Linq;

public class Box<Type>
{
    private Type[] data;
    private int count;

    public Box()
    {
        this.data = new Type[4];
        this.count = 0;
    }

    public int Count
    {
        get { return this.count; }
        private set
        {
            if (value > data.Length)
            {
                throw new IndexOutOfRangeException("Collection is full.");
            }
            this.count = value;
        }
    }
    public Type[] Data
    {
        get { return this.data; }
        private set
        {
            this.data = value;
        }
    }
    public void Add(Type element)
    {
        if (this.Count >= this.data.Length)
        {
            var newData = new Type[data.Length * 2];
            this.data.CopyTo(newData, 0);
            this.data = newData;
        }
        this.Data[this.Count] = element;
        Count++;
    }
    public Type Remove()
    {
        int index = this.Count - 1;
        Type element = this.Data[index];
        this.Data[index] = default(Type);
        Count--;
        return element;
    }
    public override string ToString()
    {
        return String.Join(", ", this.Data.Take(this.Count));
    }
}
