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
        IEnumerable<ProductOptions> Options { get; }
        IEnumerable<HtmlBlocks> HtmlBlocks { get; }

        void SaveGame(ProductGame game);
        void SaveSEO(SEO seo);
        void SaveProduct(ProductDetails productDetails);
        void SaveOption(ProductOptions productOptions);
        void SaveHtmlBlock(HtmlBlocks htmlBlock);


    }
}
