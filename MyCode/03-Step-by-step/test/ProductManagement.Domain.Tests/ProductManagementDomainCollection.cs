using ProductManagement.EntityFrameworkCore;
using Xunit;

namespace ProductManagement;

[CollectionDefinition(ProductManagementTestConsts.CollectionDefinitionName)]
public class ProductManagementDomainCollection : ProductManagementEntityFrameworkCoreCollectionFixtureBase
{

}
