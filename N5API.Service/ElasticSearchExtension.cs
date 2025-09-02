using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N5API.Domain.Entities;
using Nest;

namespace N5API.Service
{
    public static class ElasticSearchExtension
    {
        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["ElasticSettings:baseUrl"];
            var index = configuration["ElasticSettings:defaultIndex"];
            var settings = new ConnectionSettings(new Uri(baseUrl ?? "")).DefaultIndex(index);
            settings.EnableApiVersioningHeader();
            AddDefaultMappings(settings);
            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);
            CreateIndex(client, index);
        }
        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings.DefaultMappingFor<Permission>(m => m.Ignore(p => p.PermissionType));
        }
        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName, index => index.Map<Permission>(x => x.AutoMap()));
        }
    }
}
