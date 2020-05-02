using Newtonsoft.Json;
using PayMeForYou.Backend.Library.Common;
using PayMeForYou.Backend.Library.Services.Interface;
using PayMeForYou.Entity.Entities;
using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.RequestModules.Role;
using PayMeForYou.Entity.Views.Role;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PayMeForYou.Backend.Library.Services
{
    public class RoleService : IRoleService
    {
        private const string _baseUrl = "api/role";
        private readonly RequestHelper _requestHelper;
        public RoleService(RequestHelper requestHelper)
        {
            _requestHelper = requestHelper;
        }

        #region Permission Function
        public List<PermissionSection> GetAllPermissionSections(string permissions = null)
        {
            permissions = permissions != null ? $",{permissions}," : "";
            return new List<PermissionSection>
            {
                new PermissionSection
                {
                    SectionName = "Merchant",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        GetPermissionCheckBoxItem(Permission.CREATE_MERCHANT, permissions),
                        GetPermissionCheckBoxItem(Permission.UPDATE_MERCHANT, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_MERCHANT, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_INTEGRATION, permissions),
                        GetPermissionCheckBoxItem(Permission.UPDATE_INTEGRATION, permissions)
                    }
                },
                new PermissionSection
                {
                    SectionName = "User",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        GetPermissionCheckBoxItem(Permission.CREATE_USER, permissions),
                        GetPermissionCheckBoxItem(Permission.UPDATE_USER, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_USER, permissions)
                    }
                },
                new PermissionSection
                {
                    SectionName = "Role",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        GetPermissionCheckBoxItem(Permission.CREATE_ROLE, permissions),
                        GetPermissionCheckBoxItem(Permission.UPDATE_ROLE, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_ROLE, permissions)
                    }
                },
                new PermissionSection
                {
                    SectionName = "Transaction",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        GetPermissionCheckBoxItem(Permission.UPDATE_TRANSACTION, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_FUNDOUT_TRANSACTION, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_FUNDIN_TRANSACTION, permissions),
                        GetPermissionCheckBoxItem(Permission.MANUAL_CREATE_FUNDIN_TRANSACTION, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_BANK_TRANSACTION_STATEMENT, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_SETTLEMENT_TRANSACTION, permissions),
                        GetPermissionCheckBoxItem(Permission.UPDATE_SETTLEMENT_TRANSACTION, permissions),
                        GetPermissionCheckBoxItem(Permission.CREATE_SETTLEMENT_TRANSACTION, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_TOP_UP_TRANSACTION, permissions)
                    }
                },
                new PermissionSection
                {
                    SectionName = "Report",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        GetPermissionCheckBoxItem(Permission.VIEW_SETTLEMENT_REPORT, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_FUNDOUT_REPORT, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_FUNDIN_REPORT, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_MERCHANT_SUMMARY_REPORT, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_FUND_STATEMENT, permissions)
                    }
                },
                new PermissionSection
                {
                    SectionName = "Administrator",
                    Permissions = new List<CustomCheckBoxItem>
                    {
                        GetPermissionCheckBoxItem(Permission.TOP_UP, permissions),
                        GetPermissionCheckBoxItem(Permission.BALANCE_ADJUSTMENT, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_FUND_ACCOUNT, permissions),
                        GetPermissionCheckBoxItem(Permission.VIEW_TESTING_TOOL, permissions)
                    }
                }
            };
        }
        private CustomCheckBoxItem GetPermissionCheckBoxItem(Permission permission, string permissions) => new CustomCheckBoxItem { Id = permission.ToString(), Text = permission.ToString(), Selected = permissions.Contains($",{permission.ToString()},") };
        private string GetPermissions(List<PermissionSection> permissionSections)
        {
            var permissionList = new List<string>();
            foreach (var section in permissionSections)
                permissionList.AddRange(section.Permissions.Where(p => p.Selected).Select(p => p.Id));

            return string.Join(',', permissionList);
        }
        #endregion

        #region Get
        public async Task<RoleView> GetRoleAsync(int id) => JsonConvert.DeserializeObject<RoleView>(await _requestHelper.SendRequestAsync($"{_baseUrl}/{id}", HttpMethod.Get));
        public async Task<List<RoleView>> GetRolesAsync() => JsonConvert.DeserializeObject<List<RoleView>>(await _requestHelper.SendRequestAsync(_baseUrl, HttpMethod.Get));
        #endregion

        #region Create
        public async Task CreateRoleAsync(CreateRoleView view)
        {
            var request = new CreateRoleRequest
            {
                RoleName = view.RoleName,
                Permissions = GetPermissions(view.PermissionSections),
                Description = view.Description,
                CreatedBy = "Klen"
            };
            await _requestHelper.SendRequestAsync(_baseUrl, HttpMethod.Post, JsonConvert.SerializeObject(request, Formatting.None));
        }
        #endregion

        #region Update
        public async Task UpdateRoleAsync(UpdateRoleView view)
        {
            var request = new UpdateRoleRequest
            {
                Id = view.Id,
                RoleName = view.RoleName,
                Permissions = GetPermissions(view.PermissionSections),
                Description = view.Description,
                UpdatedBy = "Klen"
            };
            await _requestHelper.SendRequestAsync(_baseUrl, HttpMethod.Put, JsonConvert.SerializeObject(request, Formatting.None));
        }
        #endregion
    }
}
