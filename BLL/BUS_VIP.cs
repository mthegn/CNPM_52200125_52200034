﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BUS_VIP
    {
        public bool CreateVIP_BUS(DTO_VIP vip)
        {
            if (vip.Name == "") { return false; }
            if (vip.Phone == "") { return false; }
            return DAL_VIP.CreateVIP_DAL(vip);
        }
    }
}
