﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BL
{
    public class UserForGridView
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
