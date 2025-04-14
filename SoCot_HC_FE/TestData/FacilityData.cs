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
                    Id = Guid.NewGuid(),
                    AccreditationNo = $"ACC-{i:D3}",
                    FacilityName = $"Facility {i}",
                    Street = $"{i} Sample Street",
                    EmailAddress = $"facility{i}@example.com",
                    TelephoneNumber = $"123-45{i:D3}",
                    ContactNumber = $"0917{i:D7}",
                    Sector = i % 2 == 0 ? "Public" : "Private",
                    AddressId = Guid.NewGuid(),
                    BarangayId = i,
                    city_municipality_id = 100 + i,
                    province_id = 200 + i,
                    Zipcode = $"10{i:D2}",
                    CipherKey = $"key{i:D3}",
                    Status = true,
                    TypeofFacility = i % 3 == 0 ? "Hospital" : "Clinic"
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