using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day3MvcDBFirstDemo.Models
{
    [ModelMetadataType(typeof(CategoryDataAnnotation))]
    public partial class Category
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class CategoryDataAnnotation
    {
        [RegularExpression("^[a-zA-Z]{100}$")]
        public string Name { get; set; }

    }
}
