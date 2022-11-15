using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data
{
    public interface IData
    {
        Guid Id { get; set; }
    }

    public class Data : IData
    {
        [Key]
        public Guid Id { get; set; }
    }
}
