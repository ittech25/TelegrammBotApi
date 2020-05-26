using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleTest.SQL
{
    /// <summary>
    /// Структура из БД
    /// </summary>
    public class StructureBdProducts
    {
        //id, catId, name, description, price
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int CategorysId { get; set; }
        [MaxLength(150)]
        public string name { get; set; }
        [MaxLength(2000), Required]
        public string description { get; set; }
        [Required]
        public double price { get; set; }

        [ForeignKey("CategorysId")]
        public virtual StructureBdCategorys Categorys { get; set; }

        public virtual ICollection<StructureBdCart> Cart { get; set; }
    }

    public class StructureBdCategorys
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(30)]
        public string catName { get; set; }

        public virtual ICollection<StructureBdProducts> Products { get; set; }
    }


    [Table("cart")]
    public class StructureBdCart
    {
        //id, user_name, productId
        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [MaxLength(30)]
        public string user_name { get; set; }
        public int productId { get; set; }
        [ForeignKey("productId")]
        public virtual StructureBdProducts Products { get; set; }

    }

}
