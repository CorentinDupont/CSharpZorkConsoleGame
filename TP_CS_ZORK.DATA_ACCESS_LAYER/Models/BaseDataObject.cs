﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_CS_ZORK.DATA_ACCESS_LAYER.Models
{
    public abstract class BaseDataObject
    {
        public int Id { get; set; }
    }
}
