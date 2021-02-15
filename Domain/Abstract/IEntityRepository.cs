using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WowCarry.Domain.Entities;

namespace WowCarry.Domain.Abstract
{
    public interface IEntityRepository
    {
        IEnumerable<ProductGame> Games { get; }
        IEnumerable<Realms> Realms { get; }
        IEnumerable<SEO> SEOs { get; }
        IEnumerable<Product> Products { get; }
        IEnumerable<ProductOptions> ProductOptions { get; }
        IEnumerable<HtmlBlocks> HtmlBlocks { get; }
        IEnumerable<TemplateOptions> TemplateOptions { get; }
        IEnumerable<Users> Users { get; }
        IEnumerable<Ranks> Ranks { get; }
        IEnumerable<Customers> Customers { get; }
        IEnumerable<Orders> Orders { get; }
        IEnumerable<Roles> Roles { get; }
        IEnumerable<Article> Articles { get; }
        IEnumerable<ProductCategory> ProductCategory { get; }
        IEnumerable<ProductSubCategory> ProductSubCategories { get; }




        void SaveGame(ProductGameDetails productGameDetails);
        void SaveSEO(SeoDetails seoDetails);
        void SaveProduct(ProductDetails productDetails);
        void SaveProductOption(ProductOptionDetails productOptionsDetails);
        void SaveContext();
        void SaveHtmlBlock(HtmlBlockDetails htmlBlockDetails);
        void SaveTemplateOption(TemplateOptionDetails templateOptionDetails);
        void SaveUsers(UsersDetails usersDetails);
        void SaveRanks(RankDetails rankDetails);
        void SaveCustomers(CustomersDetails customersDetails);
        void SaveRoles(RolesDetails rolesDetails);
        void SaveOrders(OrderDetails orderDetails);
        void SaveArticle(ArticleDetails articleDetails);
        void SaveProductCategory(ProductCategoryDetails productCategoryDetails);
        void SaveSaveProductSubCategory(ProductSubCategoryDetails productSubCategoryDetails);
        void RemoveHtmlBlock(Guid htmlBlockId);
    }
}
