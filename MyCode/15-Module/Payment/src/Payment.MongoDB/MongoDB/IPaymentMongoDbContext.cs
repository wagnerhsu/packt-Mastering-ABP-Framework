﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Payment.MongoDB;

[ConnectionStringName(PaymentDbProperties.ConnectionStringName)]
public interface IPaymentMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
