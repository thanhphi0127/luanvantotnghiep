﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ThapHanoi_Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        bool KiemTraTaiKhoan(string tk, string mk);
    }
  
}
