using Newtonsoft.Json;
using PayMeForYou.Backend.Library.Services.Interface;
using PayMeForYou.Entity.Entities;
using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.RequestModules.Role;
using PayMeForYou.Entity.Views.Role;
using PayMeForYou.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PayMeForYou.Backend.Library.Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClientHelper _httpClientHelper;
        public RoleService(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }
        public List<PermissionSection> GetAllPermissionSections(string permissions = null)
        {
            return new List<PermissionSection>
            {
                new PermissionSection
                {
                    SectionName = "Merchant",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        new CustomCheckBoxItem { Id = Permission.CREATE_MERCHANT.ToString(), Text = Permission.CREATE_MERCHANT.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.UPDATE_MERCHANT.ToString(), Text = Permission.UPDATE_MERCHANT.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_MERCHANT.ToString(), Text = Permission.VIEW_MERCHANT.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_INTEGRATION.ToString(), Text = Permission.VIEW_INTEGRATION.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.UPDATE_INTEGRATION.ToString(), Text = Permission.UPDATE_INTEGRATION.ToString(), Selected = false }
                    }
                },
                new PermissionSection
                {
                    SectionName = "User",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        new CustomCheckBoxItem { Id = Permission.CREATE_USER.ToString(), Text = Permission.CREATE_USER.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.UPDATE_USER.ToString(), Text = Permission.UPDATE_USER.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_USER.ToString(), Text = Permission.VIEW_USER.ToString(), Selected = false }
                    }
                },
                new PermissionSection
                {
                    SectionName = "Role",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        new CustomCheckBoxItem { Id = Permission.CREATE_ROLE.ToString(), Text = Permission.CREATE_ROLE.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.UPDATE_ROLE.ToString(), Text = Permission.UPDATE_ROLE.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_ROLE.ToString(), Text = Permission.VIEW_ROLE.ToString(), Selected = false }
                    }
                },
                new PermissionSection
                {
                    SectionName = "Transaction",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        new CustomCheckBoxItem { Id = Permission.UPDATE_TRANSACTION.ToString(), Text = Permission.UPDATE_TRANSACTION.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_FUNDOUT_TRANSACTION.ToString(), Text = Permission.VIEW_FUNDOUT_TRANSACTION.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_FUNDIN_TRANSACTION.ToString(), Text = Permission.VIEW_FUNDIN_TRANSACTION.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.MANUAL_CREATE_FUNDIN_TRANSACTION.ToString(), Text = Permission.MANUAL_CREATE_FUNDIN_TRANSACTION.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_BANK_TRANSACTION_STATEMENT.ToString(), Text = Permission.VIEW_BANK_TRANSACTION_STATEMENT.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_SETTLEMENT_TRANSACTION.ToString(), Text = Permission.VIEW_SETTLEMENT_TRANSACTION.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.UPDATE_SETTLEMENT_TRANSACTION.ToString(), Text = Permission.UPDATE_SETTLEMENT_TRANSACTION.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.CREATE_SETTLEMENT_TRANSACTION.ToString(), Text = Permission.CREATE_SETTLEMENT_TRANSACTION.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_TOP_UP_TRANSACTION.ToString(), Text = Permission.VIEW_TOP_UP_TRANSACTION.ToString(), Selected = false }
                    }
                },
                new PermissionSection
                {
                    SectionName = "Report",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        new CustomCheckBoxItem { Id = Permission.VIEW_SETTLEMENT_REPORT.ToString(), Text = Permission.VIEW_SETTLEMENT_REPORT.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_FUNDOUT_REPORT.ToString(), Text = Permission.VIEW_FUNDOUT_REPORT.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_FUNDIN_REPORT.ToString(), Text = Permission.VIEW_FUNDIN_REPORT.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_MERCHANT_SUMMARY_REPORT.ToString(), Text = Permission.VIEW_MERCHANT_SUMMARY_REPORT.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_FUND_STATEMENT.ToString(), Text = Permission.VIEW_FUND_STATEMENT.ToString(), Selected = false }
                    }
                },
                new PermissionSection
                {
                    SectionName = "Administrator",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        new CustomCheckBoxItem { Id = Permission.TOP_UP.ToString(), Text = Permission.TOP_UP.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.BALANCE_ADJUSTMENT.ToString(), Text = Permission.BALANCE_ADJUSTMENT.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_FUND_ACCOUNT.ToString(), Text = Permission.VIEW_FUND_ACCOUNT.ToString(), Selected = false },
                        new CustomCheckBoxItem { Id = Permission.VIEW_TESTING_TOOL.ToString(), Text = Permission.VIEW_TESTING_TOOL.ToString(), Selected = false }
                    }
                }
            };
        }
        public async Task CreateRoleAsync(CreateRoleView view)
        {
            var request = new CreateRoleRequest
            {
                RoleName = view.RoleName,
                Permissions = GetPermissions(view.PermissionSections),
                Description = view.Description,
                CreatedBy = "Klen"
            };

            _httpClientHelper.Url = "api/role";
            _httpClientHelper.ContentType = HttpEntity.ContentType.Application_Json;
            _httpClientHelper.FormMethod = HttpMethod.Post;
            _httpClientHelper.FormContent = new StringContent(JsonConvert.SerializeObject(request, Formatting.None));

            await _httpClientHelper.SubmitAsync();
        }
        private string GetPermissions(List<PermissionSection> permissionSections)
        {
            var permissionList = new List<string>();
            foreach (var section in permissionSections)
                permissionList.AddRange(section.Permissions.Where(p => p.Selected).Select(p => p.Id));

            return string.Join(',', permissionList);
        }
    }
}
