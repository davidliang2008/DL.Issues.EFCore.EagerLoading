using Data.EFCore;
using Data.EFCore.Entities;
using Data.EFCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Web.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDataServices(this.Configuration);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            AppDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SeedData(dbContext);

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        private void SeedData(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            #region Create some product types

            var cabinet = new ProductTypeEntity
            {
                Id = Guid.NewGuid(),
                Name = "Cabinet",
                Slug = "cabinet",
                Status = Domain.ProductTypes.ProductTypeStatus.Published
            };

            var backsplash = new ProductTypeEntity
            {
                Id = Guid.NewGuid(),
                Name = "Backsplash",
                Slug = "backsplash",
                Status = Domain.ProductTypes.ProductTypeStatus.Published
            };

            #endregion

            #region Create some product categories

            var wallCabinet = new ProductCategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Wall Cabinet",
                Slug = "wall-cabinet",
                Status = Domain.ProductCategories.ProductCategoryStatus.Published,
                ProductType = cabinet
            };

            var vanityCabinet = new ProductCategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Vanity Cabinet",
                Slug = "vanity-cabinet",
                Status = Domain.ProductCategories.ProductCategoryStatus.Published,
                ProductType = cabinet
            };

            var wallTileBacksplash = new ProductCategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = "Wall Tile Backsplash",
                Slug = "wall-tile-backsplash",
                Status = Domain.ProductCategories.ProductCategoryStatus.Published,
                ProductType = backsplash
            };

            #endregion

            #region Create some products

            var bengalStoneWallTileBacksplash = new ProductEntity
            {
                Id = Guid.NewGuid(),
                Name = "Bengal Stone Wall Tile Backsplash",
                Slug = "bengal-stone-wall-tile-backsplash",
                Status = Domain.Products.ProductStatus.Published,
                ProductCategory = wallTileBacksplash,
                ProductImages = new List<ProductImageEntity>
                    {
                        new ProductImageEntity
                        {
                            Id = Guid.NewGuid(),
                            Url = "bengal-1",
                            IsThumbnail = true,
                            Ordinal = 1
                        }
                    },
                ProductSpecifications = new List<ProductSpecificationEntity>
                    {
                        new ProductSpecificationEntity
                        {
                            Value = "bengal-specification-1",
                            Price = 23.4
                        },
                        new ProductSpecificationEntity
                        {
                            Value = "bengal-specification-2",
                            Price = 40,
                            DiscountedPrice = 30
                        },
                        new ProductSpecificationEntity
                        {
                            Value = "bengal-specification-3",
                            Price = 20,
                            DiscountedPrice = 12.5
                        }
                    }
            };

            var metroCarreraWallTileBacksplash = new ProductEntity
            {
                Id = Guid.NewGuid(),
                Name = "Metro Carrera Wall Tile Backsplash",
                Slug = "metro-carrera-wall-tile-backsplash",
                Status = Domain.Products.ProductStatus.Published,
                ProductCategory = wallTileBacksplash,
                ProductImages = new List<ProductImageEntity>
                    {
                        new ProductImageEntity
                        {
                            Id = Guid.NewGuid(),
                            Url = "carrera-1",
                            IsThumbnail = true,
                            Ordinal = 1
                        },
                        new ProductImageEntity
                        {
                            Id = Guid.NewGuid(),
                            Url = "carrera-2",
                            IsThumbnail = false,
                            Ordinal = 2
                        }
                    },
                ProductSpecifications = new List<ProductSpecificationEntity>
                    {
                        new ProductSpecificationEntity
                        {
                            Value = "carrera-specification-1",
                            Price = 23
                        },
                        new ProductSpecificationEntity
                        {
                            Value = "carrera-specification-2",
                            Price = 20,
                            DiscountedPrice = 10
                        }
                    }
            };

            var cabinetChoices = new ProductEntity
            {
                Id = Guid.NewGuid(),
                Name = "Cabinet Choices",
                Slug = "cabinet-choices",
                Status = Domain.Products.ProductStatus.Published,
                ProductCategory = wallCabinet,
                ProductImages = new List<ProductImageEntity>
                    {
                        new ProductImageEntity
                        {
                            Id = Guid.NewGuid(),
                            Url = "cabinet-choice-1",
                            IsThumbnail = false,
                            Ordinal = 1
                        },
                        new ProductImageEntity
                        {
                            Id = Guid.NewGuid(),
                            Url = "cabinet-choice-2",
                            IsThumbnail = true,
                            Ordinal = 2
                        },
                        new ProductImageEntity
                        {
                            Id = Guid.NewGuid(),
                            Url = "cabinet-choice-3",
                            IsThumbnail = false,
                            Ordinal = 3
                        },
                        new ProductImageEntity
                        {
                            Id = Guid.NewGuid(),
                            Url = "cabinet-choice-4",
                            IsThumbnail = false,
                            Ordinal = 4
                        },
                        new ProductImageEntity
                        {
                            Id = Guid.NewGuid(),
                            Url = "cabinet-choice-5",
                            IsThumbnail = false,
                            Ordinal = 5
                        },
                        new ProductImageEntity
                        {
                            Id = Guid.NewGuid(),
                            Url = "cabinet-choice-6",
                            IsThumbnail = false,
                            Ordinal = 6
                        }
                    }
            };

            #endregion

            context.ProductTypes.Add(cabinet);
            context.DomainEvents.Add(new DomainEventEntity
            {
                AggregateType = "Domain.ProductTypes.ProductType",
                SequenceNumber = 1,
                EventType = "Domain.ProductTypes.Events.ProductTypeCreated",
                EntityId = cabinet.Id,
                TimeStamp = DateTime.UtcNow
            });

            context.ProductTypes.Add(backsplash);
            context.DomainEvents.Add(new DomainEventEntity
            {
                AggregateType = "Domain.ProductTypes.ProductType",
                SequenceNumber = 2,
                EventType = "Domain.ProductTypes.Events.ProductTypeCreated",
                EntityId = backsplash.Id,
                TimeStamp = DateTime.UtcNow
            });

            context.ProductCategories.Add(wallCabinet);
            context.DomainEvents.Add(new DomainEventEntity
            {
                AggregateType = "Domain.ProductCategories.ProductCategory",
                SequenceNumber = 1,
                EventType = "Domain.ProductCategories.Events.ProductCategoryCreated",
                EntityId = wallCabinet.Id,
                TimeStamp = DateTime.UtcNow
            });

            context.ProductCategories.Add(vanityCabinet);
            context.DomainEvents.Add(new DomainEventEntity
            {
                AggregateType = "Domain.ProductCategories.ProductCategory",
                SequenceNumber = 2,
                EventType = "Domain.ProductCategories.Events.ProductCategoryCreated",
                EntityId = vanityCabinet.Id,
                TimeStamp = DateTime.UtcNow
            });

            context.ProductCategories.Add(wallTileBacksplash);
            context.DomainEvents.Add(new DomainEventEntity
            {
                AggregateType = "Domain.ProductCategories.ProductCategory",
                SequenceNumber = 3,
                EventType = "Domain.ProductCategories.Events.ProductCategoryCreated",
                EntityId = wallTileBacksplash.Id,
                TimeStamp = DateTime.UtcNow
            });

            context.Products.Add(bengalStoneWallTileBacksplash);
            context.DomainEvents.Add(new DomainEventEntity
            {
                AggregateType = "Domain.Products.Product",
                SequenceNumber = 1,
                EventType = "Domain.Products.Events.ProductCreated",
                EntityId = bengalStoneWallTileBacksplash.Id,
                TimeStamp = DateTime.UtcNow
            });

            context.Products.Add(metroCarreraWallTileBacksplash);
            context.DomainEvents.Add(new DomainEventEntity
            {
                AggregateType = "Domain.Products.Product",
                SequenceNumber = 2,
                EventType = "Domain.Products.Events.ProductCreated",
                EntityId = metroCarreraWallTileBacksplash.Id,
                TimeStamp = DateTime.UtcNow
            });

            context.Products.Add(cabinetChoices);
            context.DomainEvents.Add(new DomainEventEntity
            {
                AggregateType = "Domain.Products.Product",
                SequenceNumber = 3,
                EventType = "Domain.Products.Events.ProductCreated",
                EntityId = cabinetChoices.Id,
                TimeStamp = DateTime.UtcNow
            });

            context.SaveChanges();
        }
    }
}
