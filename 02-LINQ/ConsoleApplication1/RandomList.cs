using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class RandomList<T>
    {
        private readonly List<T> _list;

        public RandomList()
        {
            _list = new List<T>();
        }

        public void Add(T input)
        {
            if((new Random()).Next(0,2) == 0)
                _list.Add(input);
            else
                _list.Insert(0, input);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _list.Count) throw new Exception("Index out of range");
            return _list[(new Random()).Next(0, index+1)];
        }

        public bool IsEmpty()
        {
            return _list.Count == 0;
        }
    }

}
