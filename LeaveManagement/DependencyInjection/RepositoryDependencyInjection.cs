using Microsoft.Extensions.DependencyInjection;
using LeaveManagement.Contracts;
using LeaveManagement.Repository;

namespace LeaveManagement.DependencyInjection
{
    public static class RepositoryDependencyInjection
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<ILeaveTypeRepository,LeaveTypeRepository>();
            services.AddScoped<ILeaveHistoryRepository, LeaveHistoryRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        }
    }
}
