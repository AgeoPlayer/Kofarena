using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace RVDataConverter.Modelos
{
    public class Table<T>
    {
        private Dictionary<int, T> _data;

        public Table()
        {
            _data = new Dictionary<int, T>();
        }

        public void Add(int key, T value)
        {
            _data[key] = value;
        }

        public T Get(int key)
        {
            return _data.ContainsKey(key) ? _data[key] : default(T);
        }

        public Dictionary<int, T> Data => _data;
    }
}
