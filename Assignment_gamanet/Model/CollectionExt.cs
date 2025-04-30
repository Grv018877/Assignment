using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_gamanet.Model
{
    public static class CollectionExt
    {
        public static void SubscribeToProperty<T>(this IEnumerable<T> source, string propertyName, Action<T> onChanged)
       where T : INotifyPropertyChanged
        {
            foreach (var item in source)
            {
                item.PropertyChanged += (s, e) => {
                    if (e.PropertyName == propertyName)
                        onChanged((T)s);
                };
            }
        }
    }
}
