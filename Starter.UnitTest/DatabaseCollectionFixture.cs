using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starter.UnitTest;
using Xunit;

namespace Starter.UnitTest;

[CollectionDefinition("Database")]
public class DatabaseCollectionFixture : ICollectionFixture<DatabaseFixture>
{
}