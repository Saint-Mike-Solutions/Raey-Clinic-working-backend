using AutoMapper;
using DentalClinic.Context;
using DentalClinic.DTOs.ReportDTO;
using DentalClinic.Models;
using DentalClinic.Services.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text.Json;

namespace DentalClinic.Services.ReportService
{
    public class ReportService : IReportService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public ReportService(DataContext context, IMapper mapper, IToolsService toolsService)
        {
            _context = context;
            _mapper = mapper;
            _toolsService = toolsService;
        }
        //public async Task<List<ProcedureGenderDisplayDTO>> ProcedureGender()
        //{
        //    var procedure = await _context.Procedures.Where(p => p.)
        //}
        public async Task<RevenuesDisplayDTO> TotalNumberOfPatient()
        {
            var Patient = await _context.Patients.ToListAsync();
            RevenuesDisplayDTO DTO = new RevenuesDisplayDTO();
            DTO.TotalRevenues = Patient.Count;
            return DTO;
        }
        public async Task<RevenuesDisplayDTO> TotalNumberOfDentists()
        {
            var Dentist = await _context.Employees
                .Include(e => e.UserAccount.Role) // Ensure Role is loaded
                .ToListAsync();

            var dentistCount = Dentist.Count(e => e.UserAccount.Role.RoleName.Equals("Dentist", StringComparison.OrdinalIgnoreCase));

            RevenuesDisplayDTO DTO = new RevenuesDisplayDTO();
            DTO.TotalRevenues = dentistCount;
            return DTO;
        }

        public async Task<RevenuesDisplayDTO> TotalNumberOfEmployees()
        {
            var employees = await _context.Employees
                .ToListAsync();
            RevenuesDisplayDTO DTO = new RevenuesDisplayDTO();
            DTO.TotalRevenues = employees.Count;

             return DTO;
        }
        public async Task<List<Object>> GenderBySubCity(DateTimeRangeDTOForCity DTO)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            if (DTO.ActionName.Equals("daily", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.Date; // Start of the current day
                endDate = startDate.AddDays(1).AddSeconds(-1); // End of the current day
            }
            else if (DTO.ActionName.Equals("weekly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                endDate = startDate.AddDays(6);
            }
            else if (DTO.ActionName.Equals("monthly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("yearly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1);
                endDate = startDate.AddYears(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("AllTime", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(2000, 1, 1);
            }
            else
            {
                startDate = DTO.StartDate;
                endDate = DTO.EndDate;
            }

            var data = _context.Patients
                .Where(patient =>
                    (patient.CreatedAt >= startDate) &&
                    (patient.CreatedAt <= endDate) &&
                    ((DTO.CityName.Equals("All", StringComparison.OrdinalIgnoreCase) && DTO.CountryName.Equals("All", StringComparison.OrdinalIgnoreCase)) ||
                     (DTO.CountryName.Equals("All", StringComparison.OrdinalIgnoreCase) && patient.City == DTO.CityName) ||
                     (DTO.CityName.Equals("All", StringComparison.OrdinalIgnoreCase) && patient.Country == DTO.CountryName) ||
                     (patient.Country == DTO.CountryName && patient.City == DTO.CityName)))
                .AsEnumerable()
                .GroupBy(p => p.Subcity)
                .Select(g => new
                {
                    SubCity = g.Key,
                    Male = g.Count(p => p.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase)),
                    Female = g.Count(p => p.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                })
                .ToList();

            return data.Cast<object>().ToList();
        }

        //public async Task<RevenuesDisplayDTO> Revenues()
        //{
        //    List<Payment> payments = await _context.Payments.ToListAsync();

        //    decimal totalRevenue = payments.Sum(payment => payment.Total);

        //    RevenuesDisplayDTO rv = new RevenuesDisplayDTO
        //    {
        //        TotalRevenues = totalRevenue,
        //    };
        //    return rv;
        //}
        public async Task<RevenuesDisplayDTO> Revenues(DateTimeRangeDTO DTO)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            if (DTO.ActionName.Equals("daily", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.Date; // Start of the current day
                endDate = startDate.AddDays(1).AddSeconds(-1); // End of the current day
            }
            else if (DTO.ActionName.Equals("weekly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                endDate = startDate.AddDays(6);
            }
            else if (DTO.ActionName.Equals("monthly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("yearly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1);
                endDate = startDate.AddYears(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("AllTime", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(2000, 1, 1);
            }
            else
            {
                startDate = DTO.StartDate;
                endDate = DTO.EndDate;
            }

            List<Payment> payments = await _context.Payments
                .Where(payment =>
                    (payment.PaymentDate >= startDate) &&
                    (payment.PaymentDate <= endDate))
                .ToListAsync();

            decimal totalRevenue = payments.Sum(payment => payment.Total);

            RevenuesDisplayDTO rv = new RevenuesDisplayDTO
            {
                TotalRevenues = totalRevenue,
                // Add other properties as needed (collected amount, credited amount, etc.)
            };

            return rv;
        }



        public async Task<RevenuesDisplayDTO> CollectedAmounts(DateTimeRangeDTO DTO)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            if (DTO.ActionName.Equals("daily", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.Date; // Start of the current day
                endDate = startDate.AddDays(1).AddSeconds(-1); // End of the current day
            }
            else if (DTO.ActionName.Equals("weekly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                endDate = startDate.AddDays(6);
            }
            else if (DTO.ActionName.Equals("monthly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("yearly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1);
                endDate = startDate.AddYears(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("AllTime", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(2000, 1, 1);
            }
            else
            {
                startDate = DTO.StartDate;
                endDate = DTO.EndDate;
            }

            List<Payment> payments = await _context.Payments
                .Where(payment =>
                    (payment.PaymentDate >= startDate) &&
                    (payment.PaymentDate <= endDate) && (payment.IsCredit == false))
                .ToListAsync();

            decimal totalRevenue = payments.Sum(payment => payment.Total);



            RevenuesDisplayDTO rv = new RevenuesDisplayDTO
            {
                TotalRevenues = totalRevenue,
                // Add other properties as needed (collected amount, credited amount, etc.)
            };

            return rv;
        }
        public async Task<RevenuesDisplayDTO> CreditedAmount(DateTimeRangeDTO DTO)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            if (DTO.ActionName.Equals("daily", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.Date; // Start of the current day
                endDate = startDate.AddDays(1).AddSeconds(-1); // End of the current day
            }
            else if (DTO.ActionName.Equals("weekly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                endDate = startDate.AddDays(6);
            }
            else if (DTO.ActionName.Equals("monthly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("yearly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1);
                endDate = startDate.AddYears(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("AllTime", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(2000, 1, 1);
            }
            else
            {
                startDate = DTO.StartDate;
                endDate = DTO.EndDate;
            }

            List<Payment> payments = await _context.Payments
                .Where(payment =>
                    (payment.PaymentDate >= startDate) &&
                    (payment.PaymentDate <= endDate) && (payment.IsCredit == true))
                .ToListAsync();

            decimal totalRevenue = payments.Sum(payment => payment.Total);



            RevenuesDisplayDTO rv = new RevenuesDisplayDTO
            {
                TotalRevenues = totalRevenue,
                // Add other properties as needed (collected amount, credited amount, etc.)
            };

            return rv;
        }


        public async Task<List<Object>> TotalNumberofPatientByGender()
        {
            var data = _context.Patients
                    .GroupBy(p => p.Gender)
                    .Select(g => new
        {
            Gender = g.Key,
            Male = g.Count(p => p.Gender == "Male" || p.Gender == "male" || p.Gender == "MALE"),
            Female = g.Count(p => p.Gender == "Female" || p.Gender == "female" || p.Gender == "FEMALE")
        })
        .ToList();
            return data.Cast<object>().ToList();
        }
        //Total Users By Gender
        public async Task<List<object>> TotalUsers()
        {
            var data = await _context.Employees
                .ToListAsync();

            var result = data
                .GroupBy(p => p.EmployeeGender)
                .Select(g => new
                {
                    Gender = g.Key,
                    Male = g.Count(p => p.EmployeeGender.Equals("Male", StringComparison.OrdinalIgnoreCase)),
                    Female = g.Count(p => p.EmployeeGender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                });

            return result.Cast<object>().ToList();
        }

        public async Task<RevenuesDisplayDTO> TotalNumberOfProcedures()
        {
            var data = await _context.Procedures.ToListAsync();
            int totalNumberOfProcedures = data.Count;
            RevenuesDisplayDTO DTO = new RevenuesDisplayDTO
            {
                TotalRevenues = totalNumberOfProcedures,
            };
            return DTO;
        }
        public async Task<List<object>> TotalDentistsPerGender()
        {
            var data = await _context.Employees
                .Include(p => p.UserAccount)
                    .ThenInclude(p => p.Role)
                .ToListAsync();

            var dentists = data
                .Where(p => p.UserAccount.Role.RoleName.Equals("Dentist", StringComparison.OrdinalIgnoreCase));

            var result = dentists
                .GroupBy(p => p.EmployeeGender)
                .Select(g => new
                {
                    Gender = g.Key,
                    Count = g.Count()
                });

            return result.Cast<object>().ToList();
        }


        public async Task<List<Object>> TotalRevenuesPerGender(DateTimeRangeDTO DTO)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            if (DTO.ActionName.Equals("daily", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.Date; // Start of the current day
                endDate = startDate.AddDays(1).AddSeconds(-1); // End of the current day
            }
            else if (DTO.ActionName.Equals("weekly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                endDate = startDate.AddDays(6);
            }
            else if (DTO.ActionName.Equals("monthly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("yearly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1);
                endDate = startDate.AddYears(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("AllTime", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(2000, 1, 1);
            }
            else
            {
                startDate = DTO.StartDate;
                endDate = DTO.EndDate;
            }
            var data = await _context.Payments
                 .Where(payment =>
                    (payment.PaymentDate >= startDate) &&
                    (payment.PaymentDate <= endDate))
                .Include(p => p.Patient) // Include the related Patient
                .GroupBy(p => p.Patient.Gender) // Group by patient's gender
                .Select(g => new
                {
                    Gender = g.Key,
                    TotalRevenue = g.Sum(p => p.Total)
                })
                .ToListAsync();

            return data.Cast<Object>().ToList();
        }

        public async Task<List<object>> GetRoleGenderCounts()
        {
            var data = await _context.UserAccounts
                .Include(u => u.Role)
                .Include(u => u.Employee)
                .Where(u => u.Employee != null && u.Employee.EmployeeGender != null)
                .GroupBy(u => u.Role.RoleName)
                .Select(g => new
                {
                    RoleName = g.Key,
                    Employees = g.Select(u => u.Employee)
                })
                .ToListAsync();

            var result = data.Select(g => new
            {
                RoleName = g.RoleName,
                Male = g.Employees.Count(e => string.Equals(e.EmployeeGender, "Male", StringComparison.OrdinalIgnoreCase)),
                Female = g.Employees.Count(e => string.Equals(e.EmployeeGender, "Female", StringComparison.OrdinalIgnoreCase))
            });

            return result.Cast<object>().ToList();
        }



        public async Task<List<Object>> TotalActiveInactiveEmployeesByRole()
        {

            var data = await _context.Roles
                .Include(role => role.UserAccounts)
                    .ThenInclude(userAccount => userAccount.Employee)
                .Select(role => new
                {
                    RoleName = role.RoleName,
                    ActiveCount = role.UserAccounts.Count(u => u.Employee != null && u.Employee.IsCurrentlyActive),
                    InactiveCount = role.UserAccounts.Count(u => u.Employee != null && !u.Employee.IsCurrentlyActive)
                })
                .ToListAsync();

            return data.Cast<Object>().ToList();
        }
        public async Task<List<ProcedureUsage>> GetProcedureUsage(DateTimeRangeDTO DTO)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            if (DTO.ActionName.Equals("daily", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.Date; // Start of the current day
                endDate = startDate.AddDays(1).AddSeconds(-1); // End of the current day
            }
            else if (DTO.ActionName.Equals("weekly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                endDate = startDate.AddDays(6);
            }
            else if (DTO.ActionName.Equals("monthly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("yearly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1);
                endDate = startDate.AddYears(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("AllTime", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(2000, 1, 1);
            }
            else
            {
                startDate = DTO.StartDate;
                endDate = DTO.EndDate;
            }
            List<ProcedureUsage> procedureUsageList = new List<ProcedureUsage>();
            var _medicalRecords = await _context.MedicalRecords
                                              .Where(mr => mr.Date >= startDate && mr.Date <= endDate)
                                              .Include(p => p.Patient).ToListAsync();

            foreach (var record in _medicalRecords)
            {
                var procedureIds = string.IsNullOrEmpty(record.ProcedureIDs) ? new int[] {  } : JsonSerializer.Deserialize<int[]>(record.ProcedureIDs);
                if (procedureIds.IsNullOrEmpty())
                {
                    throw new KeyNotFoundException("Trying to Access Deleted Procedure");
                }
                foreach (var procedureId in procedureIds)
                {
                    var procedureName = await GetProcedureNameById(procedureId); // Await here

                    var existingUsage = procedureUsageList.FirstOrDefault(p => p.Procedures == procedureName);

                    if (existingUsage != null)
                    {
                        if (record.Patient.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase)) // Assuming PatientId is used for gender differentiation
                            existingUsage.Male++;
                        else
                            existingUsage.Female++;
                    }
                    else
                    {
                        var usage = new ProcedureUsage
                        {
                            Procedures = procedureName,
                            Male = record.Patient.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ? 1 : 0,
                            Female = record.Patient.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase) ? 1 : 0
                        };
                        procedureUsageList.Add(usage);
                    }
                }
            }

            return procedureUsageList;
        }

        // Inner class private method

        // procedure wise amount
        public async Task<List<ProcedureRevenue>> GetProcedureRevenues(DateTimeRangeDTO DTO)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            if (DTO.ActionName.Equals("daily", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.Date; // Start of the current day
                endDate = startDate.AddDays(1).AddSeconds(-1); // End of the current day
            }
            else if (DTO.ActionName.Equals("weekly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                endDate = startDate.AddDays(6);
            }
            else if (DTO.ActionName.Equals("monthly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("yearly", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1);
                endDate = startDate.AddYears(1).AddDays(-1);
            }
            else if (DTO.ActionName.Equals("AllTime", StringComparison.OrdinalIgnoreCase))
            {
                startDate = new DateTime(2000, 1, 1);
            }
            else
            {
                startDate = DTO.StartDate;
                endDate = DTO.EndDate;
            }
            List<ProcedureRevenue> procedureRevenueList = new List<ProcedureRevenue>();
            var _medicalRecords = await _context.MedicalRecords
                                                            .Where(mr=> mr.Date>=startDate && mr.Date <= endDate)
                                                            .Include(p => p.Patient).ToListAsync();

            foreach (var record in _medicalRecords)
            {
                var procedureIds = string.IsNullOrEmpty(record.ProcedureIDs) ? new int[] { } : JsonSerializer.Deserialize<int[]>(record.ProcedureIDs);
                var quantities = string.IsNullOrEmpty(record.Quantities) ? new int[] { } : JsonSerializer.Deserialize<int[]>(record.Quantities);

                if (procedureIds.Length != quantities.Length)
                {
                    throw new InvalidOperationException("Procedure IDs and Quantities do not match.");
                }

                for (int i = 0; i < procedureIds.Length; i++)
                {
                    int procedureId = procedureIds[i];
                    int quantity = quantities[i];

                    var procedureName = await GetProcedureNameById(procedureId);
                    var procedurePrice = await GetProcedurePriceById(procedureId);

                    decimal subtotal = quantity * procedurePrice;
                    decimal discountAmount = subtotal * (record.DiscountPercent / 100m);
                    decimal totalAmount = subtotal - discountAmount;

                    var existingProcedure = procedureRevenueList.FirstOrDefault(p => p.Procedure == procedureName);

                    if (existingProcedure != null)
                    {
                        existingProcedure.Revenue += totalAmount;
                    }
                    else
                    {
                        var procedureRevenue = new ProcedureRevenue
                        {
                            Procedure = procedureName,
                            Revenue = totalAmount
                        };
                        procedureRevenueList.Add(procedureRevenue);
                    }
                }
            }

            return procedureRevenueList;
        }
        // Inner class private method to get procedure price
        private async Task<decimal> GetProcedurePriceById(int procedureId)
        {
            var procedure = await _context.Procedures
                .Where(p => p.ProcedureID == procedureId)
                .FirstOrDefaultAsync();

            return (decimal)procedure.Price;
        }
        private async Task<string> GetProcedureNameById(int procedureId)
        {
            var procedure = await _context.Procedures
                .Where(p => p.ProcedureID == procedureId)
                .FirstOrDefaultAsync();
            var name = procedure.ProcedureName.ToString();

            return name;
        }
        //public async Task<List<Object>> TotalRevenuePerMonthPastYear()
        //{
        //    DateTime startDate = DateTime.Now.AddMonths(-12);

        //    var data = await _context.Payments
        //        .Where(p => p.PaymentDate >= startDate)
        //        .GroupBy(p => new { p.PaymentDate.Year, p.PaymentDate.Month })
        //        .Select(g => new
        //        {
        //            Year = g.Key.Year,
        //            Month = g.Key.Month,
        //            TotalRevenue = g.Sum(p => p.Total)
        //        })
        //        .ToListAsync();

        //    var result = new List<Object>();

        //    for (int i = 1; i < 13; i++)
        //    {
        //        var date = startDate.AddMonths(i);
        //        var monthData = data.SingleOrDefault(d => d.Year == date.Year && d.Month == date.Month);

        //        result.Add(new
        //        {
        //            Year = date.Year,
        //            Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month),
        //            TotalRevenue = monthData != null ? monthData.TotalRevenue : 0
        //        });
        //    }

        //    return result.Cast<Object>().ToList();
        //}
        public async Task<List<Object>> TotalRevenuePerMonthPastFiveYears()
        {
            var result = new List<Object>();

            for (int yearOffset = 0; yearOffset < 5; yearOffset++)
            {
                DateTime startDate = DateTime.Now.AddYears(-yearOffset);
                var data = await _context.Payments
                    .Where(p => p.PaymentDate.Year == startDate.Year)
                    .GroupBy(p => new { p.PaymentDate.Year, p.PaymentDate.Month })
                    .Select(g => new
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        TotalRevenue = g.Sum(p => p.Total)
                    })
                    .ToListAsync();

                var monthlyData = new List<object>();

                for (int i = 1; i <= 12; i++)
                {
                    var monthData = data.SingleOrDefault(d => d.Month == i);

                    monthlyData.Add(new
                    {
                        x = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i),
                        y = monthData != null ? monthData.TotalRevenue : 0
                    });
                }

                result.Add(new
                {
                    id = startDate.Year.ToString(),
                    data = monthlyData
                });
            }

            return result;
        }



        // Function to get abbreviated month name
        private string GetAbbreviatedMonthName(int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month).ToLower();
        }








    }
}
