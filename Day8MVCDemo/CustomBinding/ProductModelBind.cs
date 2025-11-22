using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Day8MVCDemo.CustomBinding
{
    public class ProductModelBind : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string productId = bindingContext.HttpContext.Request.Form["ProductId"].ToString();
            string name = bindingContext.HttpContext.Request.Form["Name"].ToString();
            string description = bindingContext.HttpContext.Request.Form["Description"].ToString();
            string price = bindingContext.HttpContext.Request.Form["Price"].ToString();
            string photoPath = bindingContext.HttpContext.Request.Form["PhotoPath"].ToString();
            string categoryId = bindingContext.HttpContext.Request.Form["categoryId"].ToString();
            //create New Price 
            decimal newPrice = Convert.ToDecimal(price) + 100m;
            int Id;
            int.TryParse(productId, out Id);


            //Check the Category
            if (int.Parse(categoryId) == 0)
            {
                bindingContext.ModelState.AddModelError("categoryId", "Must Select the Category");
                // bindingContext.ModelState.AddModelError(string.Empty, "Must send the Photo"); //Without any Model Member
            }


            Product newProduct = new Product
            {
                ProductId = Id,
                Name = name,
                Price = newPrice,
                Description = description,
                PhotoPath = photoPath ?? string.Empty,
                categoryId = int.Parse(categoryId)
            };
            bindingContext.Result = ModelBindingResult.Success(newProduct);
            return Task.CompletedTask;
        }
    }
}
