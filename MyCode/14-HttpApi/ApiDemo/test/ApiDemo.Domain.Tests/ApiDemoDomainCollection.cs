﻿using ApiDemo.EntityFrameworkCore;
using Xunit;

namespace ApiDemo;

[CollectionDefinition(ApiDemoTestConsts.CollectionDefinitionName)]
public class ApiDemoDomainCollection : ApiDemoEntityFrameworkCoreCollectionFixtureBase
{

}
