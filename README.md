# DL.Issues.EFCore.EagerLoading

This repository is for the investigation of EF Core Eager Loading issue I found (previously opened at https://github.com/aspnet/EntityFrameworkCore/issues/11860).

It seems like random items from the source collection won't load their collection navigation properties when there is additional filter like .Contain() involved.

### Notes:
- The database will be migrated and seeded everytime the application starts up.

### Conclusion:
It looks like I can't reproduce the issue I had. The linking between Product and ProductImage, Product and ProductSpecification are working fine!!
