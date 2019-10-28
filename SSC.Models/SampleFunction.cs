﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Models
{
    public class SampleFunction
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ClientCompany Client { get; set; }
        public bool IsEnabled { get; set; }
    }
}
