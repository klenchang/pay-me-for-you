﻿using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.RepositoryModules;
using PayMeForYou.Service.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Repositories
{
    internal class MerchantRepository : IMerchantRepository
    {
        public async Task CreateMerchantAsync(Merchant merchant)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Merchant> GetMerchantAsync(int merchantId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Merchant>> GetMerchantsAsync(string merchantName, SettlementMethod settlementMethod, bool status)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateMerchantAsync(Merchant merchant)
        {
            throw new System.NotImplementedException();
        }
    }
}
