using System;
using System.Collections.Generic;
using System.Text;

namespace Glav.PasswordMgr.Engine
{
    /// <summary>
    /// Represents the possible versinsof the data file.
    /// </summary>
    public enum DataFileFileVersions
    {
        V1=0,
        V2=1,
        V3=2  // While there was never any file data version prior to V3 of this format, this data file version represents the 3rd iteration of this
              // code and is the first data file version for the .net V2 inarnation of this product.
    }
}
