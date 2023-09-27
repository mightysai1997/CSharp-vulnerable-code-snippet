using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dvcsharp_core_api.Models;
using dvcsharp_core_api.Data;

namespace dvcsharp_core_api
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly GenericDataContext _context;

        public ProductsController(GenericDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            // Get a list of all products from the database and return them as JSON.
            return _context.Products.ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            // This method handles HTTP POST requests to create a new product.

            if (!ModelState.IsValid)
            {
                // If the provided data doesn't pass validation, return a BadRequest response
                // with details about the validation errors.
                return BadRequest(ModelState);
            }

            // Check if a product with the same name or SKU already exists in the database.
            var existingProduct = _context.Products
                .Where(b => (b.name == product.name) || (b.skuId == product.skuId))
                .FirstOrDefault();

            if (existingProduct != null)
            {
                // If a product with the same name or SKU exists, return a BadRequest response
                // with an error message indicating that the name or SKU is already taken.
                ModelState.AddModelError("name", "Product name or skuId is already taken");
                return BadRequest(ModelState);
            }

            // If the product is valid and doesn't already exist, add it to the database
            // and save changes.
            _context.Products.Add(product);
            _context.SaveChanges();

            // Return a 200 OK response with the newly created product.
            return Ok(product);
        }

        [HttpGet("export")]
        public void Export()
        {
            // This method exports product data as XML.

            // Define the XML root element name.
            XmlRootAttribute root = new XmlRootAttribute("Entities");

            // Create an XML serializer for the Product array.
            XmlSerializer serializer = new XmlSerializer(typeof(Product[]), root);

            // Set the response content type to indicate XML.
            Response.ContentType = "application/xml";

            // Serialize the product data to the HTTP response body.
            serializer.Serialize(HttpContext.Response.Body, _context.Products.ToArray());
        }

        [HttpGet("search")]
        public IActionResult Search(string keyword)
        {
            // This method handles a search for products based on a keyword.

            if (String.IsNullOrEmpty(keyword))
            {
                // If the keyword is empty or null, return a message indicating that
                // a keyword is required.
                return Ok("Cannot search without a keyword");
            }

            // Construct a SQL query to search for products with names or descriptions
            // containing the specified keyword.
            var query = $"SELECT * From Products WHERE name LIKE '%{keyword}%' OR description LIKE '%{keyword}%'";

            // Execute the SQL query and return the results as a list of products.
            var products = _context.Products
                .FromSql(query)
                .ToList();

            // Return the list of matching products as a JSON response.
            return Ok(products);
        }

        [HttpPost("import")]
        public IActionResult Import()
        {
            // This method handles the import of product data from an XML request.

            // Create an XML reader from the HTTP request body.
            XmlReader reader = XmlReader.Create(HttpContext.Request.Body);

            // Define the XML root element name.
            XmlRootAttribute root = new XmlRootAttribute("Entities");

            // Create an XML serializer for the Product array.
            XmlSerializer serializer = new XmlSerializer(typeof(Product[]), root);

            // Deserialize the XML data from the reader into an array of Product objects.
            var entities = (Product[])serializer.Deserialize(reader);
            reader.Close();

            // Return the deserialized product data as a JSON response.
            return Ok(entities);
        }
    }
}
