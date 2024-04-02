using FluentAssertions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Contracts.Clients.Dao;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Repositories.Mock.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Clients.Extensions;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients;
using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Contracts.Clients.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Services.Tests
{
    public class ClientsServiceTests
    {
        IClientsService clientsService;

        public ClientsServiceTests()
        {
            var clientsRepository = new ClientsRepository(new Repositories.Mock.DB.ClientsDB());

            clientsService = new ClientsService(clientsRepository, clientsRepository);
        }

        [Fact]
        public async Task GetClientsAsync_With_NoFilter_Return_Full_List()
        {
            //var clientCatalog = await clientsService.GetClientsAsync(new CatalogFilter());

            //clientCatalog.Should().NotBeNull();
            //clientCatalog.Should().BeOfType<Catalog<Client>>();
            //clientCatalog.List.Should().NotBeNull();
            //clientCatalog.Total.Should().Be(300);
            //clientCatalog.TotalFiltered.Should().Be(300);
        }

        [Fact]
        public async Task GetClientsAsync_With_Filter_Return_Full_List()
        {
            //var clientCatalog = await clientsService.GetClientsAsync(new CatalogFilter()
            //{
            //    PageIndex = 1,
            //    PageSize = 5,
            //    SortByName = "Name",
            //    SortDirection = System.ComponentModel.ListSortDirection.Descending,
            //    Search = "Nom Test 1"
            //});

            //clientCatalog.Should().NotBeNull();
            //clientCatalog.Should().BeOfType<Catalog<Client>>();
            //clientCatalog.List.Should().NotBeNull();
            //clientCatalog.Total.Should().Be(300);
            //clientCatalog.TotalFiltered.Should().Be(111);
            //clientCatalog.List.Count.Should().Be(5);
            //clientCatalog.List.First().Id.Should().Be(194);
            //clientCatalog.List.First().Name.Should().Be("Nom Test 194");
        }

        [Fact]
        public async Task GetClientByIdAsync_Return_GoodElement()
        {
            var client = await clientsService.GetClientByIdAsync(1);

            client.Should().NotBeNull();
            client.Should().BeOfType<Client>();
            client.Id.Should().Be(1);
            client.Name.Should().Be("Nom Test 1");
        }

        [Fact]
        public async Task GetClientByNameAsync_Return_GoodElement()
        {
            var client = await clientsService.GetClientByNameAsync("Nom Test 2");

            client.Should().NotBeNull();
            client.Should().BeOfType<Client>();
            client.Id.Should().Be(2);
            client.Name.Should().Be("Nom Test 2");
        }

        [Fact]
        public async Task AddClientAsync_Return_NewElementAdd()
        {
            var newEntity = new Client()
            {
                Id = 31,
                Name = "Nom Test 31"
            };

            var client = await clientsService.AddClientAsync(newEntity);

            client.Should().NotBeNull();
            client.Should().BeOfType<Client>();
            client.Id.Should().Be(newEntity.Id);
            client.Name.Should().Be(newEntity.Name);

            var checkClient = await clientsService.GetClientByIdAsync(newEntity.Id);

            checkClient.Should().NotBeNull();
            checkClient.Should().BeOfType<Client>();
            checkClient.Id.Should().Be(newEntity.Id);
            checkClient.Name.Should().Be(newEntity.Name);
        }

        [Fact]
        public async Task UpdateClientAsync_Return_UpdatedElement()
        {
            var updatedEntity = new Client()
            {
                Id = 14,
                Name = "My New Name"
            };

            var client = await clientsService.UpdateClientAsync(updatedEntity);

            client.Should().NotBeNull();
            client.Should().BeOfType<Client>();
            client.Id.Should().Be(updatedEntity.Id);
            client.Name.Should().Be(updatedEntity.Name);

            var checkClient = await clientsService.GetClientByIdAsync(updatedEntity.Id);

            checkClient.Should().NotBeNull();
            checkClient.Should().BeOfType<Client>();
            checkClient.Id.Should().Be(updatedEntity.Id);
            checkClient.Name.Should().Be(updatedEntity.Name);
        }


        [Fact]
        public async Task DeleteClientAsync_Return_True()
        {
            var newEntity = new Client()
            {
                Id = 302,
                Name = "Nom Test 302"
            };

            await clientsService.AddClientAsync(newEntity);

            var isDeleted = await clientsService.DeleteClientAsync(302);

            isDeleted.Should().BeTrue();

            var checkClient = await clientsService.GetClientByIdAsync(302);

            checkClient.Should().BeNull();
        }
    }
}
