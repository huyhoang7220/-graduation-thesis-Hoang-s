﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    public class Slide
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Anh { get; set; }
        public int IdSP { get; set; }
    }
}
