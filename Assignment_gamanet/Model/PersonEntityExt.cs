using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_gamanet.Model
{
    public static class PersonEntityExt
    {
        /// <summary>
        /// Copies data from another <see cref="PersonEntity"/> instance to this instance.
        /// </summary>
        /// <param name="target">The target <see cref="PersonEntity"/> to receive the copied values.</param>
        /// <param name="source">The source <see cref="PersonEntity"/> from which values are copied.</param>
        /// <exception cref="ArgumentNullException">Thrown when the source is null.</exception>
        public static void CopyFrom(this PersonEntity target, PersonEntity source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            target.Name = source.Name;
            target.Country = source.Country;
            target.Address = source.Address;
            target.PostalZip = source.PostalZip;
            target.Email = source.Email;
            target.Phone = source.Phone;
        }
    }
}
