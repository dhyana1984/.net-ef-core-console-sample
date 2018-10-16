﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample.Entity
{
   public class Student
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public byte Status { get; set; }
        public string Name { get; set; } 
       // public DateTime CreatedTime { get; set; } 定义成狭隘属性
        public Int64 Int64 { get; set; }
        public float Float { get; set; }
        public double Double { get; set; }
        public decimal Decimal { get; set; }
      

    }
}
