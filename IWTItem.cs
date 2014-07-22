using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WTUSA
{
    public abstract class IWTItem : Object
    {
        //private WTRegistry.RegistryItem _registryItemType;
        public WTRegistry.RegistryItem RegistryItemType;
        //make implementation of PKID implicit so that update works with dapper extensions, otherwise PKID is unknown to dapper
        public object PKID;

        //public WTUSA.WTRegistry.RegistryItem RegistryItemType
        //{
        //    get
        //    {
        //        return _registryItemType;
        //    }
        //    set
        //    {
        //        _registryItemType = RegistryItemType;
        //    }
        //}

        /// <summary>
        /// Return a string declaring whether the implementation of the WTItem uses the term "Id" or "Nr" as a PK in the database.
        /// </summary>
        /// <returns>String "Id" or "Nr".</returns>
        public abstract string IdOrNr();

        /// <summary>
        /// Update the registry to set Active&lt;ItemType&gt; and call the relevant WTRefresh function to redraw the window.
        /// </summary>
        public abstract void Show();

        public abstract override string ToString();
    }
}
