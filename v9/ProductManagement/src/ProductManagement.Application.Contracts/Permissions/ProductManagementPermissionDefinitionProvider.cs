using ProductManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace ProductManagement.Permissions;

public class ProductManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProductManagementPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(ProductManagementPermissions.MyPermission1, L("Permission:MyPermission1"));

        var categoryPermission = myGroup.AddPermission(ProductManagementPermissions.Category.Default, L("Permission:Category"));
        categoryPermission.AddChild(ProductManagementPermissions.Category.Create, L("Permission:Create"));
        categoryPermission.AddChild(ProductManagementPermissions.Category.Update, L("Permission:Update"));
        categoryPermission.AddChild(ProductManagementPermissions.Category.Delete, L("Permission:Delete"));

        var productPermission = myGroup.AddPermission(ProductManagementPermissions.Product.Default, L("Permission:Product"));
        productPermission.AddChild(ProductManagementPermissions.Product.Create, L("Permission:Create"));
        productPermission.AddChild(ProductManagementPermissions.Product.Update, L("Permission:Update"));
        productPermission.AddChild(ProductManagementPermissions.Product.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProductManagementResource>(name);
    }
}
