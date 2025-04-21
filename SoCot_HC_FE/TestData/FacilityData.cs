using SoCot_HC_FE.Handler;
using SoCot_HC_FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SoCot_HC_FE.TestData
{
    public class FacilityData
    {
        public async Task<PaginationHandler<Facility>> GetListofFacility(int pageNumber, int pageSize)
        {
            List<Facility> facilities = new List<Facility>();

            for (int i = 1; i <= 20; i++)
            {
                facilities.Add(new Facility
                {
                    FacilityId = i ,
                    AccreditationNo = $"ACC-{i:D3}",
                    FacilityName = $"Facility {i}",
                    EmailAddress = $"facility{i}@example.com",
                    ContactNumber = $"0917{i:D7}",
                    Sector = i % 2 == 0 ? "Public" : "Private",
                    AddressId = Guid.NewGuid(),
                    IsActive = true
                });
            }

            int totalRecords = facilities.Count;
            var pagedItems = facilities
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return await Task.FromResult(new PaginationHandler<Facility>(pagedItems, totalRecords, pageNumber, pageSize));
        }
    }
}