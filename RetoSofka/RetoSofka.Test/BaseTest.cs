using RetoSofka.Infrastructure.Inventario;
using RetoSofka.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RetoSofka.Test
{
    public class BaseTest
    {

        public readonly ApplicationDbContext _dbContext;
        public readonly OperationProduct operationProduct;
        public BaseTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;
            _dbContext = new ApplicationDbContext(options);
            _dbContext.Database.EnsureCreated();
            this.operationProduct = new OperationProduct(_dbContext);
        }


    }
}
