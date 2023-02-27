using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.InfraData.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(ProductName,Description,Image,Stock,Price,Favorite,CategoryId)VALUES(" +
                "'T-shirt cropped Snoopy and his black friends | Peanuts', " +
                "'The length of having the T-shirt cropped Snoopy and his black friends | Peanuts in your cart will be the same as you turn a comic page. So enjoy this request!\r\n\r\nFeatures:\r\nBrand: Peanuts\r\nCotton 100%\r\nBald Collar\r\nShort Sleeve Modeling\r\nCropped\r\nSnoopy Print and his profile friends\r\n\r\nModel Measurements: height: 1.8m; bust: 82cm; waist: 60cm; Hip: 90cm. Model is wearing: M\r\n\r\nThe trend of the moment, croppeds are characterized by being more curtinhos stopping above the navel. This piece that originated in 1930 as a bathing suit, being the word \"cropped\", from English, means cut, and is found in blouses, regattas, jackets and shirts. Currently this type of length has marked a generation that likes to dare, rediscover itself and reinvent itself.\r\n\r\nThe color of the product in the photos reproduced with models may change due to the use of the flash.'," +
                "'https://static.riachuelo.com.br/RCHLO/14889820001/portrait/751a9431ac15ba7ff1d8d38cf5dae4a9ca08db6b.jpg?imwidth=400',25,49.90,1,4)");

            mb.Sql("INSERT INTO Products(ProductName,Description,Image,Stock,Price,Favorite,CategoryId)VALUES(" +
                "'Cropped regatta of knit and green back neckline | Pool by Riachuelo','Features:\r\nBrand: Pool by Riachuelo\r\nViscose 50%; Acrylic 50%\r\nMedium collar\r\nMade of knit Posterior\r\nneckline on the back Model\r\n\r\nmeasurements: height: 1.71m; bust: 81cm; waist: 62cm; Hip: 88cm. Model is wearing:\r\n\r\nTimeless and comfortable m knitting pieces are a good choice for mid-season and winter days. Produced from the technique of interlacing the yarn, knitting or knitting, it has a handmade appearance that conveys a warm and comfortable image, and relies on the malleability and elasticity of a mesh. Whether it is a sweater, cardigan or even a skirt it is always good to have at least one piece of knitting in the wardrobe.\r\n\r\nCreated thinking about what is most current in the world of fashion, the brand Pool by Riachuelo brings together from lightness for the little ones, to the young attitude with a fashionista footprint for the wardrobe of those who love to always be on top of trends! Bringing in your identity modern pieces, stripped, basic and the good old jeans.\r\n\r\nThe color of the product in the photos reproduced with models may change as a result of the use of the flash.'," +
                "'https://static.riachuelo.com.br/RCHLO/14759640005/portrait/ddad976f30e445dc0d736384b9d1b6ba53455525.jpg?imwidth=400',32,99.90,1,6)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
