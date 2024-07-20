using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Employees;
using TrackMaster.Domain.ResolverGroups;
using TrackMaster.Domain.Persistence;
using TrackMaster.Domain.Repository;
using TrackMaster.Infrastructure.Services;
using TrackMaster.Domain.Tasks;
using TrackMaster.Infrastructure.Repository;

namespace TrackMaster.Domain
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TrackMasterContext>(
                option => option.UseSqlServer(
                        configuration.GetConnectionString("TrackMaster"),
                        x => x.UseHierarchyId()
                    )
                );
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployee, EmployeeRepository>();
            services.AddScoped<IResolverGroupRepository, ResolverGroupRepository>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITaskAttachmentRepository, FileAttachmentRepository>();
            services.AddScoped<ITaskCommentRepository, CommentRepository>();
            services.AddScoped<ITaskStatusRepository, TaskStatusRepository>();

            services.AddScoped<ITaskRepository, TaskRepository>();
            return services;
        }
    }

    
}
