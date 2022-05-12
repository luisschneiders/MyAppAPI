using System;
using System.ComponentModel.DataAnnotations;
using BaseLibrary.Models;
using DepartmentLibrary.Models;

namespace LabelLibrary.Models
{
    public abstract class Label : Base
    {
        [Required]
        public string? CompanyName { get; set; }

        [ValidateComplexType]
        public Department Department { get; set; } = new();

        [Required]
        public string? Location { get; set; }

        // Shadow properties
        public Guid DepartmentId { get; set; }
    }
}
